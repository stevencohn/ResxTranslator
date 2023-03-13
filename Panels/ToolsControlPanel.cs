//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator.Panels
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Windows.Forms;
	using System.Xml.Linq;


	public partial class ToolsControlPanel : UserControl
	{
		private const string NL = "\n";


		public ToolsControlPanel()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Set the initial file path, Called from the main window to inherit the path
		/// from the main tab
		/// </summary>
		/// <param name="path"></param>
		public void SetFilePath(string path)
		{
			sourceBox.Text = path;
		}


		private void EnableControlsOnTextChanged(object sender, EventArgs e)
		{
			var path = Environment.ExpandEnvironmentVariables(sourceBox.Text.Trim());
			if (path.Length > 0 && File.Exists(path))
			{
				var type = Path.GetExtension(path);
				if (type.Equals(".resx", StringComparison.InvariantCultureIgnoreCase))
				{
					sortButton.Enabled = sortLabel.Enabled = true;
					updateButton.Enabled = updateLabel.Enabled = false;
				}
				else
				{
					sortButton.Enabled = sortLabel.Enabled = false;
					updateButton.Enabled = updateLabel.Enabled = true;
				}
			}
			else
			{
				sortButton.Enabled = sortLabel.Enabled = false;
				updateButton.Enabled = updateLabel.Enabled = false;
			}
		}


		private void BrowseOnClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				sourceBox.Text = openFileDialog.FileName;
			}
		}


		/// <summary>
		/// Intelligently sorts resources in the specified resource file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SortResourcesOnClick(object sender, EventArgs e)
		{
			logbox.Clear();

			var path = Environment.ExpandEnvironmentVariables(sourceBox.Text);
			if (File.Exists(path))
			{
				var root = XElement.Load(path);
				ResxProvider.SortData(root);
				root.Save(path, SaveOptions.None);
				Log($"{Path.GetFileName(path)} sorted and saved{NL}", Color.Green);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateHintsOnClick(object sender, EventArgs e)
		{
			logbox.Clear();

			var path = Environment.ExpandEnvironmentVariables(sourceBox.Text);
			if (!File.Exists(path))
			{
				Log($"could not find {path}{NL}", Color.Red);
				return;
			}

			var xpath = Path.Combine(Path.GetDirectoryName(path), "Resources.resx");
			if (!File.Exists(xpath))
			{
				Log($"could not find {xpath}{NL}", Color.Red);
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
						Log($"correcting name {dataname}{NL}");
						hint.Attribute("name").Value = dataname;
						renamed++;
					}

					var source = hint.Element("source");
					if (source != null)
					{
						var value = data.Element("value").Value.Trim();
						if (source.Value.Trim() != value)
						{
							Log($"updating source for {name}{NL}");
							source.Value = data.Element("value").Value;
							updated++;
						}
					}
					else
					{
						Log($"adding missing source for {name}{NL}");
						hint.AddFirst(new XElement("source", data.Element("value").Value));
						updated++;
					}
				}
				else
				{
					errors++;
				}
			});

			Log($"{NL}Summary{NL}", Color.DarkBlue);

			if (updated == 0 && renamed == 0 && errors == 0)
			{
				Log($"... No updates needed{NL}");
				return;
			}

			if (updated > 0)
			{
				Log($"... {updated} sources updated{NL}", Color.Blue);
			}

			if (renamed > 0)
			{
				Log($"... {renamed} name corrections", Color.Blue);
			}

			if (errors > 0)
			{
				Log($"... {errors} errors were found!", Color.Red);
			}

			if (updated > 0 || renamed > 0)
			{
				hroot.Add(hints.OrderBy(d => d.Attribute("name").Value));
				hroot.Save(path, SaveOptions.None);
			}
		}


		private void Log(string message, Color? color = null)
		{
			if (color == null || color.Equals(Color.Black))
			{
				logbox.AppendText(message);
				return;
			}

			var fore = logbox.SelectionColor;
			logbox.SelectionColor = (Color)color;
			logbox.AppendText(message);
			logbox.SelectionColor = fore;
		}
	}
}
