//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

#pragma warning disable S1066 // Collapsible "if" statements should be merged

namespace ResxTranslator
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
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
		private CancellationTokenSource cancellation;


		public MainWindow()
		{
			InitializeComponent();

			PopulateLanguages();

			languageList.Dock = DockStyle.Fill;
			logBox.Dock = DockStyle.Fill;
			logBox.Visible = false;

			cancelButton.Top = translateButton.Top;
			cancelButton.Left = translateButton.Left;
			restartButton.Top = translateButton.Top;
			restartButton.Left = translateButton.Left;
		}


		private void PopulateLanguages()
		{
			fromCodeBox.Items.Add("auto (Detect)");

			foreach (var code in Translator.Codes)
			{
				var name = Translator.GetDisplayName(code);

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

			if (sender == inputBox || sender == languageList || sender == delayBox)
			{
				if (Translator.Estimate(inputBox.Text, out strings, (int)delayBox.Value, out var seconds))
				{
					var langs = Math.Max(languageList.CheckedIndices.Count, 1);
					var span = new TimeSpan(0, 0, seconds * langs);
					estimationLabel.Text = strings == 0
						? string.Empty
						: $"{strings} strings. Estimated completion in {span}";
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


		private void CompareChanged(object sender, EventArgs e)
		{
			estimationLabel.ForeColor = compareBox.Checked ? Color.Gray : Color.Black;
		}


		private void CheckedLanguage(object sender, ItemCheckedEventArgs e)
		{
			ChangedResxInput(sender, e);
		}


		private async void TranslateFile(object sender, EventArgs e)
		{
			LockControls();

			translateButton.Visible = false;
			cancelButton.Visible = true;

			var inputPath = Path.GetFullPath(inputBox.Text);
			var fromCode = Translator.Codes[codeBox.SelectedIndex];

			var outputDir = outputBox.Text.Length > 0
				? Path.GetFullPath(outputBox.Text)
				: Path.GetDirectoryName(inputPath);

			if (!Directory.Exists(outputDir))
			{
				Directory.CreateDirectory(outputDir);
			}

			string filepath = null;
			var match = Regex.Match(inputPath, FilePattern);
			if (match.Success)
			{
				filepath = match.Groups["file"].Value;
			}

			var translator = new Translator();
			cancellation = new CancellationTokenSource();

			foreach (var index in languageList.CheckedIndices)
			{
				var toCode = Translator.Codes[(int)index];

				var displayName = Translator.GetDisplayName(toCode);
				var cultureName = Translator.GetCultureName(toCode);
				var outputFile = $"{filepath}.{cultureName}.resx";

				statusLabel.Text = $"Translating to {toCode} - {displayName} ({cultureName})";

				// load source resx for every target language
				// this will be translated in memory and stored for each language
				var root = XElement.Load(inputPath);

				var data = Translator.CollectData(root);

				if (compareBox.Checked)
				{
					if (File.Exists(outputFile))
					{
						data = Translator.FilterData(data, outputFile);
					}
				}

				try
				{
					var success = await translator.TranslateResx(
						data, fromCode, toCode, (int)delayBox.Value, cancellation,
						(status, count, message) =>
						{
							Log(status, count, data.Count, toCode, message);
						});

					if (cancellation.IsCancellationRequested)
					{
						break;
					}

					if (success)
					{
						SaveTranslations(root, data, outputFile);
					}
				}
				catch (HttpException exc)
				{
					logBox.AppendText(exc.Message + Environment.NewLine);
				}
			}

			cancelButton.Visible = false;
			restartButton.Visible = true;

			if (cancellation.IsCancellationRequested)
			{
				statusLabel.Text = "Cancelled";
				progressBar.Value = progressBar.Maximum;
			}
			else
			{
				statusLabel.Text = "Done";
			}

			cancellation.Dispose();
		}


		private void LockControls()
		{
			languageList.Visible = false;
			logBox.Visible = true;
			logBox.Clear();

			inputBox.Enabled = false;
			codeBox.Enabled = false;
			browseFileButton.Enabled = false;
			outputBox.Enabled = false;
			browseFolderButton.Enabled = false;
			compareBox.Enabled = false;
			delayBox.Enabled = false;
		}


		private void Log(Status status, int count, int total, string toCode, string message)
		{
			if (status == Status.OK)
			{
				statusLabel.Text = $"Translating {count}/{total} to {toCode}";
				logBox.AppendText(message + Environment.NewLine);
				progressBar.Increment(1);
			}
			else if (status == Status.Working)
			{
				logBox.AppendText($"{message} ");
			}
			else
			{
				logBox.AppendText(Environment.NewLine + message + Environment.NewLine);
			}
		}


		private void SaveTranslations(XElement root, List<XElement> data, string outputFile)
		{
			if (compareBox.Checked)
			{
				var target = XElement.Load(outputFile);
				foreach (var d in data)
				{
					target.Add(d);
				}

				target.Save(outputFile);
			}
			else
			{
				root.Save(outputFile);
			}
		}


		private void CancelTranslation(object sender, EventArgs e)
		{
			cancellation.Cancel();
			cancelButton.Enabled = false;
		}


		private void Restart(object sender, EventArgs e)
		{
			inputBox.Enabled = true;
			codeBox.Enabled = true;
			browseFileButton.Enabled = true;
			outputBox.Enabled = true;
			browseFolderButton.Enabled = true;
			compareBox.Enabled = true;
			delayBox.Enabled = true;

			languageList.Visible = true;
			logBox.Visible = false;
			logBox.Clear();

			statusLabel.Text = "Status...";
			progressBar.Value = 0;

			restartButton.Visible = false;
			translateButton.Visible = true;
		}
	}
}
