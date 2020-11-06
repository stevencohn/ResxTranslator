//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

#pragma warning disable S1066 // Collapsible "if" statements should be merged

namespace ResxTranslator
{
	using System;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Text.RegularExpressions;
	using System.Threading;
	using System.Web;
	using System.Windows.Forms;
	using System.Xml.Linq;

	public partial class MainWindow : Form
	{
		private const string CodePattern = @".+\.(?<code>.+)\.resx";
		private const string FilePattern = @"(?<file>.+)(\.(?<code>.+)){0,1}\.resx";

		private int strings = 0;


		public MainWindow()
		{
			InitializeComponent();

			PopulateLanguages();

			languageList.Dock = DockStyle.Fill;
			logBox.Dock = DockStyle.Fill;
			logBox.Visible = false;

			openFileDialog.Filter = "Resx Files (*.resx)|*.resx";
			openFileDialog.Title = "Choose source resx file";
			openFileDialog.DefaultExt = ".resx";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;

			folderBrowserDialog.Description = "Choose output folder";
			folderBrowserDialog.ShowNewFolderButton = true;
		}


		private void PopulateLanguages()
		{
			fromCodeBox.Items.Add("auto (Detect)");

			foreach (var code in Translator.Codes)
			{
				var info = CultureInfo.GetCultureInfo(code);

				var name = info.EnglishName.StartsWith("Unknown")
					? $"{code} (not installed)"
					: info.DisplayName;

				fromCodeBox.Items.Add(name);
				toCodeBox.Items.Add(name);
				codeBox.Items.Add($"{name} [{code}]");
				languageList.Items.Add(name);
			}

			fromCodeBox.SelectedIndex = 0;

			var index = Translator.Codes.IndexOf(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
			toCodeBox.SelectedIndex = index < 0 ? Translator.Codes.IndexOf("en") : index;
		}


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// Translate Text

		private void ChangeTransInput(object sender, EventArgs e)
		{
			translateTextButton.Enabled =
				fromCodeBox.SelectedIndex >= 0 &&
				toCodeBox.SelectedIndex >= 0 &&
				textBox.Text.Length > 0;
		}


		private async void TranslateOne(object sender, EventArgs e)
		{
			var fromCode = fromCodeBox.SelectedIndex == 0
				? "auto"
				: Translator.Codes[fromCodeBox.SelectedIndex];

			var toCode = Translator.Codes[toCodeBox.SelectedIndex];

			var translator = new Translator();

			try
			{
				var result = await translator.Translate(textBox.Text, fromCode, toCode);

				resultBox.Clear();
				resultBox.ForeColor = Color.Black;
				resultBox.Text = result;
			}
			catch (HttpException exc)
			{
				resultBox.ForeColor = Color.Red;
				resultBox.Text = exc.Message;
			}
		}


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// Translate File

		private void ChangedResxInput(object sender, EventArgs e)
		{
			var fileOK = inputBox.Text.Length > 0 && File.Exists(inputBox.Text);

			if (fileOK)
			{
				var match = Regex.Match(
					Path.GetFileName(inputBox.Text), CodePattern);

				if (match.Success)
				{
					var code = match.Groups["code"].Value.ToLower();
					codeBox.SelectedIndex = Translator.Codes.IndexOf(code);
				}
				else
				{
					codeBox.SelectedIndex = Translator.Codes.IndexOf("en");
				}
			}

			if (sender == inputBox)
			{
				if (Translator.Estimate(inputBox.Text, out strings, out var seconds))
				{
					var span = new TimeSpan(0, 0, seconds);
					estimationLabel.Text = strings == 0
						? string.Empty
						: $"{strings} strings. Estimated time to complete {span}";
				}
			}

			if (strings > 0 && languageList.CheckedIndices.Count > 0)
			{
				progressBar.Maximum = strings * languageList.CheckedIndices.Count;
			}

			if (progressBar.Value > 0)
			{
				// reset after last run
				statusLabel.Text = string.Empty;
				progressBar.Value = 0;
			}

			if (logBox.Visible)
			{
				languageList.Visible = true;
				logBox.Visible = false;
				logBox.Clear();
			}

			translateButton.Enabled =
				fileOK &&
				languageList.CheckedIndices.Count > 0 &&
				estimationLabel.Text.Length > 0;
		}


		private void BrowseFiles(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				inputBox.Text = openFileDialog.FileName;
			}
		}

		private void BrowseFolders(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				outputBox.Text = folderBrowserDialog.SelectedPath;
			}
		}


		private void CheckedLanguage(object sender, ItemCheckedEventArgs e)
		{
			ChangedResxInput(sender, e);
		}


		private async void TranslateFile(object sender, EventArgs e)
		{
			languageList.Visible = false;
			logBox.Visible = true;
			logBox.Clear();

			var inputPath = Path.GetFullPath(inputBox.Text);
			var fromCode = Translator.Codes[codeBox.SelectedIndex];

			var outputPath = outputBox.Text.Length > 0
				? Path.GetFullPath(outputBox.Text)
				: Path.GetDirectoryName(inputPath);

			if (!Directory.Exists(outputPath))
			{
				Directory.CreateDirectory(outputPath);
			}

			string filepath = null;
			var match = Regex.Match(inputPath, FilePattern);
			if (match.Success)
			{
				filepath = match.Groups["file"].Value;
			}

			var translator = new Translator();

			foreach (var index in languageList.CheckedIndices)
			{
				var toCode = Translator.Codes[(int)index];

				statusLabel.Text = $"Translating to {toCode}";

				// load source resx for every target language
				// this will be translated in memory and stored for each language
				var root = XElement.Load(inputPath);

				try
				{
					var success = await translator.TranslateResx(root, fromCode, toCode,
						(ok, count, message) =>
						{
							if (ok)
							{
								progressBar.Increment(count);
							}
							else
							{
								logBox.AppendText(message + Environment.NewLine);
							}
						});

					if (success)
					{
						// convert two-letter language "en" to five-letter "en-US"
						// this will presume a default country code if one is not included...
						var info = CultureInfo.GetCultureInfo(toCode);
						root.Save($"{filepath}.{info.TextInfo.CultureName}.resx");
					}
				}
				catch (HttpException exc)
				{
					logBox.AppendText(exc.Message + Environment.NewLine);
				}
			}

			statusLabel.Text = "Done";
		}
	}
}
