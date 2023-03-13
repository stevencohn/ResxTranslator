namespace ResxTranslator.Panels
{
	partial class TextControlPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextControlPanel));
			this.textBox = new System.Windows.Forms.TextBox();
			this.resultsLabel = new System.Windows.Forms.Label();
			this.logbox = new System.Windows.Forms.RichTextBox();
			this.cmdPanel = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.translateButton = new System.Windows.Forms.Button();
			this.toCodeLabel = new System.Windows.Forms.Label();
			this.toCodeBox = new ResxTranslator.Panels.LanguageComboBox();
			this.fromCodeBox = new ResxTranslator.Panels.LanguageComboBox();
			this.fromCodeLabel = new System.Windows.Forms.Label();
			this.resultLabelPanel = new System.Windows.Forms.Panel();
			this.cmdPanel.SuspendLayout();
			this.resultLabelPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox.Location = new System.Drawing.Point(0, 60);
			this.textBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(1009, 202);
			this.textBox.TabIndex = 3;
			this.textBox.TextChanged += new System.EventHandler(this.EnableControlsOnTextChanged);
			// 
			// resultsLabel
			// 
			this.resultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.resultsLabel.AutoSize = true;
			this.resultsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.resultsLabel.Location = new System.Drawing.Point(3, 12);
			this.resultsLabel.Name = "resultsLabel";
			this.resultsLabel.Size = new System.Drawing.Size(63, 20);
			this.resultsLabel.TabIndex = 4;
			this.resultsLabel.Text = "Results";
			// 
			// logbox
			// 
			this.logbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logbox.Location = new System.Drawing.Point(0, 306);
			this.logbox.Margin = new System.Windows.Forms.Padding(0);
			this.logbox.Name = "logbox";
			this.logbox.Size = new System.Drawing.Size(1009, 382);
			this.logbox.TabIndex = 6;
			this.logbox.Text = "";
			// 
			// cmdPanel
			// 
			this.cmdPanel.Controls.Add(this.cancelButton);
			this.cmdPanel.Controls.Add(this.translateButton);
			this.cmdPanel.Controls.Add(this.toCodeLabel);
			this.cmdPanel.Controls.Add(this.toCodeBox);
			this.cmdPanel.Controls.Add(this.fromCodeBox);
			this.cmdPanel.Controls.Add(this.fromCodeLabel);
			this.cmdPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmdPanel.Location = new System.Drawing.Point(0, 0);
			this.cmdPanel.Name = "cmdPanel";
			this.cmdPanel.Padding = new System.Windows.Forms.Padding(0, 9, 0, 9);
			this.cmdPanel.Size = new System.Drawing.Size(1009, 60);
			this.cmdPanel.TabIndex = 5;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.AutoSize = true;
			this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
			this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cancelButton.Location = new System.Drawing.Point(884, 6);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 8, 3, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(69, 46);
			this.cancelButton.TabIndex = 15;
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Visible = false;
			this.cancelButton.Click += new System.EventHandler(this.CancelOnClick);
			// 
			// translateButton
			// 
			this.translateButton.AutoSize = true;
			this.translateButton.Enabled = false;
			this.translateButton.Image = ((System.Drawing.Image)(resources.GetObject("translateButton.Image")));
			this.translateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.translateButton.Location = new System.Drawing.Point(804, 6);
			this.translateButton.Name = "translateButton";
			this.translateButton.Size = new System.Drawing.Size(69, 46);
			this.translateButton.TabIndex = 4;
			this.translateButton.UseVisualStyleBackColor = true;
			this.translateButton.Click += new System.EventHandler(this.TranslateOnClick);
			// 
			// toCodeLabel
			// 
			this.toCodeLabel.AutoSize = true;
			this.toCodeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.toCodeLabel.Location = new System.Drawing.Point(429, 15);
			this.toCodeLabel.Name = "toCodeLabel";
			this.toCodeLabel.Size = new System.Drawing.Size(97, 20);
			this.toCodeLabel.TabIndex = 3;
			this.toCodeLabel.Text = "Translate to:";
			// 
			// toCodeBox
			// 
			this.toCodeBox.FormattingEnabled = true;
			this.toCodeBox.Items.AddRange(new object[] {
            "auto (Detect)",
            "Afrikaans",
            "Albanian",
            "Amharic",
            "Arabic",
            "Armenian",
            "Azerbaijani",
            "Basque",
            "Belarusian",
            "Bangla",
            "Bosnian",
            "Bulgarian",
            "Catalan",
            "Cebuano",
            "Chichewa",
            "Chinese (Simplified, PRC)",
            "Chinese (Traditional, Taiwan)",
            "Corsican",
            "Croatian",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Esperanto",
            "Estonian",
            "Filipino (Philippines)",
            "Finnish",
            "French",
            "Frisian",
            "Galician",
            "Georgian",
            "German",
            "Greek",
            "Gujarati",
            "Hausa",
            "Haitian Creole",
            "Hawaiian",
            "Hebrew",
            "Hindi",
            "Hmong",
            "Hungarian",
            "Icelandic",
            "Igbo",
            "Indonesian",
            "Irish",
            "Italian",
            "Japanese",
            "Javanese",
            "Kannada",
            "Kazakh",
            "Khmer",
            "Kinyarwanda",
            "Korean",
            "Central Kurdish",
            "Kyrgyz",
            "Lao",
            "Latin",
            "Latvian",
            "Lithuanian",
            "Luxembourgish",
            "Macedonian",
            "Malagasy",
            "Malay",
            "Malayalam",
            "Maltese",
            "Maori",
            "Marathi",
            "Mongolian",
            "Burmese",
            "Nepali",
            "Norwegian",
            "Odia",
            "Pashto",
            "Persian",
            "Polish",
            "Portuguese",
            "Punjabi",
            "Romanian",
            "Russian",
            "Samoan",
            "Serbian",
            "Scottish Gaelic",
            "Southern Sotho",
            "Shona",
            "Sindhi",
            "Sinhala",
            "Slovak",
            "Slovenian",
            "Somali",
            "Spanish",
            "Sudanese",
            "Kiswahili",
            "Swedish",
            "Tajik",
            "Tamil",
            "Tatar",
            "Telugu",
            "Thai",
            "Turkish",
            "Turkmen",
            "Ukrainian",
            "Urdu",
            "Uyghur",
            "Uzbek",
            "Vietnamese",
            "Welsh",
            "isiXhosa",
            "Yiddish",
            "Yoruba",
            "isiZulu"});
			this.toCodeBox.Location = new System.Drawing.Point(532, 12);
			this.toCodeBox.Name = "toCodeBox";
			this.toCodeBox.Size = new System.Drawing.Size(250, 28);
			this.toCodeBox.TabIndex = 2;
			this.toCodeBox.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguagesOnSelectedIndexChanged);
			// 
			// fromCodeBox
			// 
			this.fromCodeBox.FormattingEnabled = true;
			this.fromCodeBox.Items.AddRange(new object[] {
            "auto (Detect)",
            "Afrikaans",
            "Albanian",
            "Amharic",
            "Arabic",
            "Armenian",
            "Azerbaijani",
            "Basque",
            "Belarusian",
            "Bangla",
            "Bosnian",
            "Bulgarian",
            "Catalan",
            "Cebuano",
            "Chichewa",
            "Chinese (Simplified, PRC)",
            "Chinese (Traditional, Taiwan)",
            "Corsican",
            "Croatian",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Esperanto",
            "Estonian",
            "Filipino (Philippines)",
            "Finnish",
            "French",
            "Frisian",
            "Galician",
            "Georgian",
            "German",
            "Greek",
            "Gujarati",
            "Hausa",
            "Haitian Creole",
            "Hawaiian",
            "Hebrew",
            "Hindi",
            "Hmong",
            "Hungarian",
            "Icelandic",
            "Igbo",
            "Indonesian",
            "Irish",
            "Italian",
            "Japanese",
            "Javanese",
            "Kannada",
            "Kazakh",
            "Khmer",
            "Kinyarwanda",
            "Korean",
            "Central Kurdish",
            "Kyrgyz",
            "Lao",
            "Latin",
            "Latvian",
            "Lithuanian",
            "Luxembourgish",
            "Macedonian",
            "Malagasy",
            "Malay",
            "Malayalam",
            "Maltese",
            "Maori",
            "Marathi",
            "Mongolian",
            "Burmese",
            "Nepali",
            "Norwegian",
            "Odia",
            "Pashto",
            "Persian",
            "Polish",
            "Portuguese",
            "Punjabi",
            "Romanian",
            "Russian",
            "Samoan",
            "Serbian",
            "Scottish Gaelic",
            "Southern Sotho",
            "Shona",
            "Sindhi",
            "Sinhala",
            "Slovak",
            "Slovenian",
            "Somali",
            "Spanish",
            "Sudanese",
            "Kiswahili",
            "Swedish",
            "Tajik",
            "Tamil",
            "Tatar",
            "Telugu",
            "Thai",
            "Turkish",
            "Turkmen",
            "Ukrainian",
            "Urdu",
            "Uyghur",
            "Uzbek",
            "Vietnamese",
            "Welsh",
            "isiXhosa",
            "Yiddish",
            "Yoruba",
            "isiZulu"});
			this.fromCodeBox.Location = new System.Drawing.Point(142, 12);
			this.fromCodeBox.Name = "fromCodeBox";
			this.fromCodeBox.Size = new System.Drawing.Size(250, 28);
			this.fromCodeBox.TabIndex = 1;
			this.fromCodeBox.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguagesOnSelectedIndexChanged);
			// 
			// fromCodeLabel
			// 
			this.fromCodeLabel.AutoSize = true;
			this.fromCodeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.fromCodeLabel.Location = new System.Drawing.Point(3, 15);
			this.fromCodeLabel.Name = "fromCodeLabel";
			this.fromCodeLabel.Size = new System.Drawing.Size(134, 20);
			this.fromCodeLabel.TabIndex = 0;
			this.fromCodeLabel.Text = "Source language:";
			// 
			// resultLabelPanel
			// 
			this.resultLabelPanel.Controls.Add(this.resultsLabel);
			this.resultLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.resultLabelPanel.Location = new System.Drawing.Point(0, 262);
			this.resultLabelPanel.Name = "resultLabelPanel";
			this.resultLabelPanel.Size = new System.Drawing.Size(1009, 44);
			this.resultLabelPanel.TabIndex = 7;
			// 
			// TextControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.logbox);
			this.Controls.Add(this.resultLabelPanel);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.cmdPanel);
			this.Name = "TextControlPanel";
			this.Size = new System.Drawing.Size(1009, 688);
			this.cmdPanel.ResumeLayout(false);
			this.cmdPanel.PerformLayout();
			this.resultLabelPanel.ResumeLayout(false);
			this.resultLabelPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Label resultsLabel;
		private System.Windows.Forms.RichTextBox logbox;
		private System.Windows.Forms.Panel cmdPanel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button translateButton;
		private System.Windows.Forms.Label toCodeLabel;
		private Panels.LanguageComboBox toCodeBox;
		private Panels.LanguageComboBox fromCodeBox;
		private System.Windows.Forms.Label fromCodeLabel;
		private System.Windows.Forms.Panel resultLabelPanel;
	}
}
