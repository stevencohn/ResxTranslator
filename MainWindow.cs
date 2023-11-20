//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

#pragma warning disable S1066 // Collapsible "if" statements should be merged

namespace ResxTranslator
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Threading;
	using System.Web;
	using System.Windows.Forms;
	using System.Xml.Linq;


	public partial class MainWindow : Form
	{
		private const string CodePattern = @".+\.(?<code>.+)\.resx";
		private const string FilePattern = @"(?<file>.+)(\.(?<code>.+)){0,1}\.resx";
		private const string NL = "\n";

		private int strings = 0;
		private bool backendUpdate = false;
		private CancellationTokenSource cancellation;


		public MainWindow()
		{
			InitializeComponent();

			Width = Math.Min(1700, Screen.FromControl(this).WorkingArea.Width - 600);
			Height = Math.Min(1000, Screen.FromControl(this).WorkingArea.Height - 300);

			PopulateLanguages();

			languageList.Dock = DockStyle.Fill;
			logBox.Dock = DockStyle.Fill;
			logBox.Visible = true;

			cancelButton.Top = translateButton.Top;
			cancelButton.Left = translateButton.Left;
			restartButton.Top = translateButton.Top;
			restartButton.Left = translateButton.Left;

			var settings = new SettingsProvider();
			var inputPath = settings.Get("inputPath");
			if (string.IsNullOrEmpty(inputPath))
			{
				var args = Environment.GetCommandLineArgs();
				if (args.Length > 1)
				{
					if (File.Exists(args[1]))
					{
						inputPath = args[1];
					}

				}
			}

			if (!string.IsNullOrEmpty(inputPath))
			{
				inputBox.Text = inputPath;
			}
		}


		private void PopulateLanguages()
		{
			foreach (var code in Translator.Codes)
			{
				var name = Translator.GetDisplayName(code);

				codeBox.Items.Add($"{name} [{code}]");
				languageList.Items.Add(name);
			}
		}


		private void PrepTabOnSelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabs.SelectedIndex)
			{
				case 2: analyzeControlPanel.SetFilePath(inputBox.Text); break;
				case 3: toolsControlPanel.SetFilePath(inputBox.Text); break;
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
				AutosetLanguages();
			}

			if (sender == inputBox || sender == languageList)
			{
				if (Translator.Estimate(inputBox.Text, out strings, out var seconds))
				{
					var langs = Math.Max(languageList.CheckedIndices.Count, 1);
					var span = new TimeSpan(0, 0, seconds * langs);
					estimationLabel.Text = strings == 0
						? string.Empty
						: $"{strings} strings. Estimated completion in {span}";
				}
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


		private void AutosetLanguages()
		{
			backendUpdate = true;

			var regex = new Regex(@"\.(([a-z]{2,3})\-[A-Z]{2})\.resx");

			var dir = Path.GetDirectoryName(inputBox.Text);
			if (Directory.Exists(dir))
			{
				for (int i = 0; i < languageList.Items.Count; i++)
				{
					languageList.Items[0].Checked = false;
				}

				var files = Directory.GetFiles(dir, "*.resx")
					.Where(f => regex.IsMatch(f))
					.ToList();

				foreach (var file in files)
				{
					var match = regex.Match(file);

					// group 2 is the inner capture
					var lang = match.Groups[2].Value;

					if (lang == "zh")
					{
						// group 1 is the outer capture
						lang = match.Groups[1].Value;
					}

					var index = Translator.Codes.IndexOf(lang);
					if (index >= 0)
					{
						languageList.Items[index].Checked = true;
					}
				}

			}

			backendUpdate = false;
		}


		private void BrowseFiles(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (sender == browseFileButton)
				{
					inputBox.Text = openFileDialog.FileName;
				}
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
			estimationLabel.ForeColor = newStringsBox.Checked ? Color.Gray : Color.Black;
		}


		private void CheckedLanguage(object sender, ItemCheckedEventArgs e)
		{
			if (!backendUpdate)
			{
				ChangedResxInput(sender, e);
			}
		}


		private async void TranslateFile(object sender, EventArgs e)
		{
			LockControls();

			translateButton.Visible = false;
			cancelButton.Visible = true;

			if (!newStringsBox.Checked)
			{
				// this is an estimate
				progressBar.Maximum = strings * languageList.CheckedIndices.Count;
			}

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

			if (sortBox.Checked)
			{
				var root = XElement.Load(inputPath);
				ResxProvider.SortData(root);
				root.Save(inputPath, SaveOptions.None);
			}

			var translator = new Translator();
			cancellation = new CancellationTokenSource();

			var watch = new Stopwatch();
			watch.Start();

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

				var data = ResxProvider.CollectStrings(root);

				if (newStringsBox.Checked && File.Exists(outputFile))
				{
					data = ResxProvider.CollectNewStrings(data, outputFile);
					var span = new TimeSpan(0, 0, (int)(data.Count * 0.1));
					estimationLabel.Text = $"{data.Count} {toCode} strings. Estimated completion in {span}";

					// count per file
					progressBar.Maximum = data.Count;
					progressBar.Value = 0;
				}

				try
				{
					Log($"{NL}Translating {data.Count} strings to {toCode}{NL}", Color.Green);

					translator.LoadHints($"{filepath}.{cultureName}-hints.xml");

					var success = await translator.TranslateResx(
						data, fromCode, toCode, cancellation,
						(message, color, increment) =>
						{
							Log(message, color);

							if (increment)
							{
								progressBar.Increment(1);
							}
						});

					if (cancellation.IsCancellationRequested)
					{
						break;
					}

					if (success)
					{
						root = ApplyTranslations(root, data, inputPath, outputFile, out var deleted);

						var hintCount = 0;
						if (hintOverrideBox.Checked && translator.Hints.HasElements)
						{
							hintCount = ResxProvider.MergeHints(root, translator.Hints);
							Log($"Merged {hintCount} hints{NL}", Color.Green);
						}

						if (data.Count > 0 || hintCount > 0 || deleted > 0)
						{
							root.Save(outputFile);
							Log($"Saved {outputFile}{NL}", Color.Blue);
						}
						else
						{
							Log($"No changes{NL}", Color.Blue);
						}
					}
				}
				catch (HttpException exc)
				{
					Log(exc.Message + NL, Color.Red);
				}
			}

			if (clearBox.Checked && !cancellation.IsCancellationRequested)
			{
				// we're done with this file so clear the EDIT markers
				var count = Translator.ClearMarkers(inputPath);
				if (count > 0)
					Log($"Cleared {count} EDIT markers{NL}");
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

			watch.Stop();
			Log($"ellapsed time {watch.ElapsedMilliseconds}ms{NL}", Color.DarkCyan);

			cancellation.Dispose();

			var settings = new SettingsProvider();
			settings.Set("inputPath", inputPath);
			settings.Save();
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
			newStringsBox.Enabled = false;
			hintOverrideBox.Enabled = false;
			sortBox.Enabled = false;
			clearBox.Enabled = false;
		}


		private void Log(string message, Color? color = null)
		{
			if (color == null || color.Equals(Color.Black))
			{
				logBox.AppendText(message);
				return;
			}

			var fore = logBox.SelectionColor;
			logBox.SelectionColor = (Color)color;
			logBox.AppendText(message);
			logBox.SelectionColor = fore;
		}


		private XElement ApplyTranslations(
			XElement root, List<XElement> data, string inputPath, string outputFile,
			out int deletedCount)
		{
			// add or update changes...

			if (newStringsBox.Checked && File.Exists(outputFile))
			{
				root = XElement.Load(outputFile);
				foreach (var d in data)
				{
					var element = root.Elements("data")
						.FirstOrDefault(e => e.Attribute("name").Value == d.Attribute("name").Value);

					if (element != null)
					{
						if (element.Element("value") is XElement evalue &&
							d.Element("value") is XElement dvalue)
						{
							evalue.Value = dvalue.Value;
						}

						// also pick up any changes to the comment
						var ecomment = element.Element("comment");
						var dcomment = d.Element("comment");
						if (dcomment != null)
						{
							if (ecomment != null)
							{
								// update comment
								ecomment.Value = Translator.ClearMarker(dcomment.Value);
							}
							else
							{
								// restore missing comment
								element.Add(new XElement("comment",
									Translator.ClearMarker(dcomment.Value)));
							}
						}
					}
					else
					{
						root.Add(d);
					}
				}
			}

			// remove deleted items...

			var sourceData = XElement.Load(inputPath).Elements("data");

			var deleted = root.Elements("data")
				.Where(e => !sourceData.Any(d => d.Attribute("name").Value == e.Attribute("name").Value))
				.ToList();

			deleted.ForEach(d =>
			{
				Log($"Deleted {d.Attribute("name").Value}{NL}", Color.DarkRed);
			});

			deletedCount = deleted.Count;
			deleted.Remove();

			if (sortBox.Checked)
			{
				ResxProvider.SortData(root);
			}

			return root;
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
			newStringsBox.Enabled = true;
			hintOverrideBox.Enabled = true;
			sortBox.Enabled = true;
			clearBox.Enabled = true;

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
