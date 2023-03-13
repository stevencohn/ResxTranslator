//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator.Panels
{
	using System;
	using System.Diagnostics;
	using System.Drawing;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web;
	using System.Windows.Forms;


	public partial class TextControlPanel : UserControl
	{
		private const string NL = "\n";

		private CancellationTokenSource cancellation;


		public TextControlPanel()
		{
			InitializeComponent();
			cancellation = new CancellationTokenSource();

			fromCodeBox.Items.Insert(0, "auto (Detect)");
			fromCodeBox.SelectedIndex = 0;

			var index = Translator.Codes.IndexOf(
				Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);

			toCodeBox.SelectedIndex = index < 0 ? Translator.Codes.IndexOf("en") : index;
		}


		private void ChangeLanguagesOnSelectedIndexChanged(object sender, EventArgs e)
		{
			translateButton.Enabled =
				fromCodeBox.SelectedIndex >= 0 &&
				toCodeBox.SelectedIndex >= 0 &&
				textBox.Text.Length > 0;
		}


		private void EnableControlsOnTextChanged(object sender, EventArgs e)
		{
			translateButton.Enabled = textBox.Text.Trim().Length > 0;
		}


		private async void TranslateOnClick(object sender, EventArgs e)
		{
			translateButton.Visible = false;
			cancelButton.Visible = true;

			logbox.Clear();
			logbox.ForeColor = Color.Black;

			var fromCode = fromCodeBox.SelectedIndex == 0
				? "auto"
				: Translator.Codes[fromCodeBox.SelectedIndex - 1];

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
							Log("Cancelled" + NL, Color.Red);
							break;
						}
						else
						{
							Log(result + NL);

							if (translator.Inflated(parts[i], result))
							{
								Log("*** possible inflation detected ***" + NL, Color.Maroon);
							}

							Log($"ellapsed time {watch.ElapsedMilliseconds}ms{NL}", Color.DarkCyan);
						}
					}
				}
			}
			catch (TaskCanceledException)
			{
				Log("Cancelled" + NL, Color.DarkRed);
			}
			catch (HttpException exc)
			{
				Log(exc.Message + NL, Color.Red);
			}
			finally
			{
				if (watch.IsRunning)
				{
					watch.Stop();
				}
			}

			cancelButton.Visible = false;
			translateButton.Visible = true;
		}


		private void CancelOnClick(object sender, EventArgs e)
		{
			cancellation.Cancel();
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
