﻿//************************************************************************************************
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
	using System.Threading.Tasks;
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

			cancelOneButton.Top = translateTextButton.Top;
			cancelOneButton.Left = translateTextButton.Left;

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
				analyzeSourceBox.Text = inputPath;
				toolsSourceBox.Text = inputPath;
			}
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
			translateTextButton.Visible = false;
			cancelOneButton.Visible = true;

			resultBox.Clear();
			resultBox.ForeColor = Color.Black;

			var fromCode = fromCodeBox.SelectedIndex == 0
				? "auto"
				: Translator.Codes[fromCodeBox.SelectedIndex];

			var toCode = Translator.Codes[toCodeBox.SelectedIndex];

			var translator = new Translator();

			var watch = new Stopwatch();
			watch.Start();

			try
			{
				using (cancellation = new CancellationTokenSource())
				{
					var parts = textBox.Text.Split('\n');
					for (int i = 0; i < parts.Length; i++)
					{
						var result = await translator.Translate(
							parts[i], fromCode, toCode, cancellation);

						watch.Stop();

						if (cancellation.IsCancellationRequested)
						{
							LogOne("Cancelled" + NL, Color.Red);
							break;
						}
						else
						{
							LogOne(result + NL);

							if (translator.Inflated(parts[i], result))
							{
								LogOne("*** possible inflation detected ***" + NL, Color.Maroon);
							}

							LogOne($"ellapsed time {watch.ElapsedMilliseconds}ms{NL}", Color.DarkCyan);
						}
					}
				}
			}
			catch (TaskCanceledException)
			{
				LogOne("Cancelled" + NL, Color.DarkRed);
			}
			catch (HttpException exc)
			{
				LogOne(exc.Message + NL, Color.Red);
			}
			finally
			{
				if (watch.IsRunning)
				{
					watch.Stop();
				}
			}

			cancelOneButton.Visible = false;
			translateTextButton.Visible = true;
		}


		private void LogOne(string message, Color? color = null)
		{
			if (color == null || color.Equals(Color.Black))
			{
				resultBox.AppendText(message);
				return;
			}

			var fore = logBox.SelectionColor;
			resultBox.SelectionColor = (Color)color;
			resultBox.AppendText(message);
			resultBox.SelectionColor = fore;
		}


		private void CancelTranslateOne(object sender, EventArgs e)
		{
			cancellation.Cancel();
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
				else if (sender == toolsBrowseButton)
				{
					toolsSourceBox.Text = openFileDialog.FileName;
				}
				else
				{
					analyzeSourceBox.Text = openFileDialog.FileName;
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
			estimationLabel.ForeColor = compareBox.Checked ? Color.Gray : Color.Black;
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

			if (!compareBox.Checked)
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

				if (compareBox.Checked && File.Exists(outputFile))
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
						SaveTranslations(root, data, inputPath, outputFile);
						Log($"Saved {outputFile}{NL}", Color.Blue);
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
			compareBox.Enabled = false;
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


		private void SaveTranslations(
			XElement root, List<XElement> data, string inputPath, string outputFile)
		{
			// add or update changes...

			if (compareBox.Checked && File.Exists(outputFile))
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

			deleted.Remove();

			if (sortBox.Checked)
			{
				ResxProvider.SortData(root);
			}

			root.Save(outputFile);
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
			clearBox.Enabled = true;

			languageList.Visible = true;
			logBox.Visible = false;
			logBox.Clear();

			statusLabel.Text = "Status...";
			progressBar.Value = 0;

			restartButton.Visible = false;
			translateButton.Visible = true;
		}


		//========================================================================================
		// Analyze Tab...

		private void AnalyzeBoxTextChanged(object sender, EventArgs e)
		{
			analyzeButton.Enabled =
				analyzeSourceBox.Text.Length > 0 &&
				File.Exists(analyzeSourceBox.Text);
		}


		private void AnalyzeButtonClick(object sender, EventArgs e)
		{
			reportBox.Clear();

			var root = XElement.Load(analyzeSourceBox.Text);

			var data = root.Elements("data")
				.Where(d => d.Attribute("type") == null)
				.Select(d => new
				{
					Data = d,
					Comment = d.Element("comment")?.Value
				})
				.Where(a => string.IsNullOrWhiteSpace(a.Comment) ||
					!(a.Comment.Contains("SKIP") || a.Comment.Contains("NODUP")))
				.Select(d => d.Data);

			Loga($"Resx contains {data.Count()} strings" + NL);

			var groups = data.GroupBy(d => d.Element("value").Value);
			Loga($"Found {groups.Count()} unique strings" + NL);

			var unique = groups.Where(g => g.Count() > 1);
			Loga($"Found {unique.Count()} duplicate strings" + NL + NL);

			Loga(new String('=', 100) + NL);

			var delims = new[] { ' ', '\n', '\r' };

			var words = unique.Where(g => !delims.Any(d => g.Key.Contains(d)));
			Loga($"found {words.Count()} single-word duplicates" + NL, Color.DarkRed);
			foreach (var group in words.OrderBy(w => w.Key))
			{
				Loga(NL + group.Key + NL, Color.Red);
				foreach (var item in group)
				{
					Loga($" . . . {item.Attribute("name").Value}" + NL);
				}
			}

			Loga(NL + new String('=', 100) + NL);

			var phrases = unique.Where(g => delims.Any(d => g.Key.Contains(d)));
			Loga($"found {phrases.Count()} multi-word duplicate phrases" + NL, Color.DarkBlue);
			foreach (var group in phrases.OrderBy(p => p.Key))
			{
				Loga(NL + group.Key + NL, Color.Blue);
				foreach (var item in group)
				{
					Loga($" . . . {item.Attribute("name").Value}" + NL);
				}
			}
		}


		private void Loga(string message, Color? color = null)
		{
			if (color == null || color.Equals(Color.Black))
			{
				reportBox.AppendText(message);
				return;
			}

			var fore = logBox.SelectionColor;
			reportBox.SelectionColor = (Color)color;
			reportBox.AppendText(message);
			reportBox.SelectionColor = fore;
		}



		//========================================================================================
		// Tools Tab...

		private void ToolsSourceBoxTextChanged(object sender, EventArgs e)
		{
			var path = Environment.ExpandEnvironmentVariables(toolsSourceBox.Text.Trim());
			if (path.Length > 0 && File.Exists(path))
			{
				var type = Path.GetExtension(path);
				if (type.Equals(".resx", StringComparison.InvariantCultureIgnoreCase))
				{
					toolsSortButton.Enabled = toolsSortLabel.Enabled = true;
					toolsUpdateButton.Enabled = toolsUpdateLabel.Enabled = false;
				}
				else
				{
					toolsSortButton.Enabled = toolsSortLabel.Enabled = false;
					toolsUpdateButton.Enabled = toolsUpdateLabel.Enabled = true;
				}
			}
			else
			{
				toolsSortButton.Enabled = toolsSortLabel.Enabled = false;
				toolsUpdateButton.Enabled = toolsUpdateLabel.Enabled = false;
			}
		}


		private void SortResx(object sender, EventArgs e)
		{
			toolsReportBox.Clear();

			var path = Environment.ExpandEnvironmentVariables(toolsSourceBox.Text);
			if (File.Exists(path))
			{
				var root = XElement.Load(path);
				ResxProvider.SortData(root);
				root.Save(path, SaveOptions.None);
				Logt($"{Path.GetFileName(path)} sorted and saved{NL}", Color.Green);
			}
		}


		private void UpdateHints(object sender, EventArgs e)
		{
			toolsReportBox.Clear();

			var path = Environment.ExpandEnvironmentVariables(toolsSourceBox.Text);
			if (!File.Exists(path))
			{
				Logt($"could not find {path}{NL}", Color.Red);
				return;
			}

			var xpath = Path.Combine(Path.GetDirectoryName(path), "Resources.resx");
			if (!File.Exists(xpath))
			{
				Logt($"could not find {xpath}{NL}", Color.Red);
				return;
			}

			var xroot = XElement.Load(xpath);
			var hroot = XElement.Load(path);
			var updated = 0;
			var renamed = 0;
			var errors = 0;

			var hints = hroot.Elements("hint").ToList();

			hints.ForEach(hint =>
			{
				hint.Remove();

				var name = hint.Attribute("name").Value;
				var data = xroot.Elements("data")
					.FirstOrDefault(d => d.Attribute("name").Value.Equals(
						name, StringComparison.InvariantCultureIgnoreCase));

				if (data != null)
				{
					// should only be a case-difference
					var dataname = data.Attribute("name").Value;
					if (dataname != name)
					{
						Logt($"correcting name {dataname}{NL}");
						hint.Attribute("name").Value = dataname;
						renamed++;
					}

					var source = hint.Element("source");
					if (source != null)
					{
						var value = data.Element("value").Value.Trim();
						if (source.Value.Trim() != value)
						{
							Logt($"updating source for {name}{NL}");
							source.Value = data.Element("value").Value;
							updated++;
						}
					}
					else
					{
						Logt($"adding missing source for {name}{NL}");
						hint.AddFirst(new XElement("source", data.Element("value").Value));
						updated++;
					}
				}
				else
				{
					errors++;
				}
			});

			Logt($"{NL}Summary{NL}", Color.DarkBlue);

			if (updated == 0 && renamed == 0 && errors == 0)
			{
				Logt($"... No updates needed{NL}");
				return;
			}

			if (updated > 0)
			{
				Logt($"... {updated} sources updated{NL}", Color.Blue);
			}

			if (renamed > 0)
			{
				Logt($"... {renamed} name corrections", Color.Blue);
			}

			if (errors > 0)
			{
				Logt($"... {errors} errors were found!", Color.Red);
			}

			if (updated > 0 || renamed > 0)
			{
				hroot.Add(hints.OrderBy(d => d.Attribute("name").Value));
				hroot.Save(path, SaveOptions.None);
			}
		}


		private void Logt(string message, Color? color = null)
		{
			if (color == null || color.Equals(Color.Black))
			{
				toolsReportBox.AppendText(message);
				return;
			}

			var fore = logBox.SelectionColor;
			toolsReportBox.SelectionColor = (Color)color;
			toolsReportBox.AppendText(message);
			toolsReportBox.SelectionColor = fore;
		}
	}
}
