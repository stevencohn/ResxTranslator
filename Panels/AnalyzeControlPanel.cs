//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator.Panels
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Windows.Forms;
	using System.Xml.Linq;

	public partial class AnalyzeControlPanel : UserControl
	{
		private const string NL = "\n";


		public AnalyzeControlPanel()
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


		private void BrowseOnClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				sourceBox.Text = openFileDialog.FileName;
			}
		}


		private void EnableControlsOnTextChanged(object sender, EventArgs e)
		{
			analyzeButton.Enabled =
				sourceBox.Text.Length > 0 &&
				File.Exists(sourceBox.Text);
		}


		private void AnalyzeOnClick(object sender, EventArgs e)
		{
			logbox.Clear();

			var root = XElement.Load(sourceBox.Text);

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

			Log($"Resx contains {data.Count()} strings" + NL);

			var groups = data.GroupBy(d => d.Element("value").Value);
			Log($"Found {groups.Count()} unique strings" + NL);

			var unique = groups.Where(g => g.Count() > 1);
			Log($"Found {unique.Count()} duplicate strings" + NL + NL);

			Log(new String('=', 100) + NL);

			var delims = new[] { ' ', '\n', '\r' };

			var words = unique.Where(g => !delims.Any(d => g.Key.Contains(d)));
			Log($"found {words.Count()} single-word duplicates" + NL, Color.DarkRed);
			foreach (var group in words.OrderBy(w => w.Key))
			{
				Log(NL + group.Key + NL, Color.Red);
				foreach (var item in group)
				{
					Log($" . . . {item.Attribute("name").Value}" + NL);
				}
			}

			Log(NL + new String('=', 100) + NL);

			var phrases = unique.Where(g => delims.Any(d => g.Key.Contains(d)));
			Log($"found {phrases.Count()} multi-word duplicate phrases" + NL, Color.DarkBlue);
			foreach (var group in phrases.OrderBy(p => p.Key))
			{
				Log(NL + group.Key + NL, Color.Blue);
				foreach (var item in group)
				{
					Log($" . . . {item.Attribute("name").Value}" + NL);
				}
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
