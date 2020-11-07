namespace ResxTranslator
{
	partial class MainWindow
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.tabs = new System.Windows.Forms.TabControl();
			this.resxTab = new System.Windows.Forms.TabPage();
			this.recommendationLabel = new System.Windows.Forms.Label();
			this.delayBox = new System.Windows.Forms.NumericUpDown();
			this.delayLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.sheetPanel = new System.Windows.Forms.Panel();
			this.logBox = new System.Windows.Forms.TextBox();
			this.languageList = new System.Windows.Forms.ListView();
			this.estimationLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.translateButton = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.translationsLabel = new System.Windows.Forms.Label();
			this.browseFolderButton = new System.Windows.Forms.Button();
			this.outputBox = new System.Windows.Forms.TextBox();
			this.outputLabel = new System.Windows.Forms.Label();
			this.browseFileButton = new System.Windows.Forms.Button();
			this.codeBox = new System.Windows.Forms.ComboBox();
			this.inputBox = new System.Windows.Forms.TextBox();
			this.inputLabel = new System.Windows.Forms.Label();
			this.textTab = new System.Windows.Forms.TabPage();
			this.textBox = new System.Windows.Forms.TextBox();
			this.resultsLabel = new System.Windows.Forms.Label();
			this.resultBox = new System.Windows.Forms.TextBox();
			this.textCmdPanel = new System.Windows.Forms.Panel();
			this.translateTextButton = new System.Windows.Forms.Button();
			this.toCodeLabel = new System.Windows.Forms.Label();
			this.toCodeBox = new System.Windows.Forms.ComboBox();
			this.fromCodeBox = new System.Windows.Forms.ComboBox();
			this.fromCodeLabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tabs.SuspendLayout();
			this.resxTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.delayBox)).BeginInit();
			this.sheetPanel.SuspendLayout();
			this.textTab.SuspendLayout();
			this.textCmdPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.resxTab);
			this.tabs.Controls.Add(this.textTab);
			resources.ApplyResources(this.tabs, "tabs");
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			// 
			// resxTab
			// 
			this.resxTab.Controls.Add(this.recommendationLabel);
			this.resxTab.Controls.Add(this.delayBox);
			this.resxTab.Controls.Add(this.delayLabel);
			this.resxTab.Controls.Add(this.cancelButton);
			this.resxTab.Controls.Add(this.sheetPanel);
			this.resxTab.Controls.Add(this.estimationLabel);
			this.resxTab.Controls.Add(this.statusLabel);
			this.resxTab.Controls.Add(this.translateButton);
			this.resxTab.Controls.Add(this.progressBar);
			this.resxTab.Controls.Add(this.translationsLabel);
			this.resxTab.Controls.Add(this.browseFolderButton);
			this.resxTab.Controls.Add(this.outputBox);
			this.resxTab.Controls.Add(this.outputLabel);
			this.resxTab.Controls.Add(this.browseFileButton);
			this.resxTab.Controls.Add(this.codeBox);
			this.resxTab.Controls.Add(this.inputBox);
			this.resxTab.Controls.Add(this.inputLabel);
			resources.ApplyResources(this.resxTab, "resxTab");
			this.resxTab.Name = "resxTab";
			this.resxTab.UseVisualStyleBackColor = true;
			// 
			// recommendationLabel
			// 
			resources.ApplyResources(this.recommendationLabel, "recommendationLabel");
			this.recommendationLabel.Name = "recommendationLabel";
			// 
			// delayBox
			// 
			resources.ApplyResources(this.delayBox, "delayBox");
			this.delayBox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.delayBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.delayBox.Name = "delayBox";
			this.delayBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.delayBox.ValueChanged += new System.EventHandler(this.ChangedResxInput);
			// 
			// delayLabel
			// 
			resources.ApplyResources(this.delayLabel, "delayLabel");
			this.delayLabel.Name = "delayLabel";
			// 
			// cancelButton
			// 
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelTranslation);
			// 
			// sheetPanel
			// 
			resources.ApplyResources(this.sheetPanel, "sheetPanel");
			this.sheetPanel.Controls.Add(this.logBox);
			this.sheetPanel.Controls.Add(this.languageList);
			this.sheetPanel.Name = "sheetPanel";
			// 
			// logBox
			// 
			resources.ApplyResources(this.logBox, "logBox");
			this.logBox.Name = "logBox";
			// 
			// languageList
			// 
			this.languageList.CheckBoxes = true;
			this.languageList.HideSelection = false;
			resources.ApplyResources(this.languageList, "languageList");
			this.languageList.Name = "languageList";
			this.languageList.UseCompatibleStateImageBehavior = false;
			this.languageList.View = System.Windows.Forms.View.List;
			this.languageList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.CheckedLanguage);
			// 
			// estimationLabel
			// 
			resources.ApplyResources(this.estimationLabel, "estimationLabel");
			this.estimationLabel.Name = "estimationLabel";
			// 
			// statusLabel
			// 
			resources.ApplyResources(this.statusLabel, "statusLabel");
			this.statusLabel.Name = "statusLabel";
			// 
			// translateButton
			// 
			resources.ApplyResources(this.translateButton, "translateButton");
			this.translateButton.Name = "translateButton";
			this.translateButton.UseVisualStyleBackColor = true;
			this.translateButton.Click += new System.EventHandler(this.TranslateFile);
			// 
			// progressBar
			// 
			resources.ApplyResources(this.progressBar, "progressBar");
			this.progressBar.Name = "progressBar";
			// 
			// translationsLabel
			// 
			resources.ApplyResources(this.translationsLabel, "translationsLabel");
			this.translationsLabel.Name = "translationsLabel";
			// 
			// browseFolderButton
			// 
			resources.ApplyResources(this.browseFolderButton, "browseFolderButton");
			this.browseFolderButton.Name = "browseFolderButton";
			this.browseFolderButton.UseVisualStyleBackColor = true;
			this.browseFolderButton.Click += new System.EventHandler(this.BrowseFolders);
			// 
			// outputBox
			// 
			resources.ApplyResources(this.outputBox, "outputBox");
			this.outputBox.Name = "outputBox";
			this.outputBox.TextChanged += new System.EventHandler(this.ChangedResxInput);
			// 
			// outputLabel
			// 
			resources.ApplyResources(this.outputLabel, "outputLabel");
			this.outputLabel.Name = "outputLabel";
			// 
			// browseFileButton
			// 
			resources.ApplyResources(this.browseFileButton, "browseFileButton");
			this.browseFileButton.Name = "browseFileButton";
			this.browseFileButton.UseVisualStyleBackColor = true;
			this.browseFileButton.Click += new System.EventHandler(this.BrowseFiles);
			// 
			// codeBox
			// 
			resources.ApplyResources(this.codeBox, "codeBox");
			this.codeBox.DropDownWidth = 230;
			this.codeBox.FormattingEnabled = true;
			this.codeBox.Name = "codeBox";
			// 
			// inputBox
			// 
			resources.ApplyResources(this.inputBox, "inputBox");
			this.inputBox.Name = "inputBox";
			this.inputBox.TextChanged += new System.EventHandler(this.ChangedResxInput);
			// 
			// inputLabel
			// 
			resources.ApplyResources(this.inputLabel, "inputLabel");
			this.inputLabel.Name = "inputLabel";
			// 
			// textTab
			// 
			this.textTab.Controls.Add(this.textBox);
			this.textTab.Controls.Add(this.resultsLabel);
			this.textTab.Controls.Add(this.resultBox);
			this.textTab.Controls.Add(this.textCmdPanel);
			resources.ApplyResources(this.textTab, "textTab");
			this.textTab.Name = "textTab";
			this.textTab.UseVisualStyleBackColor = true;
			// 
			// textBox
			// 
			resources.ApplyResources(this.textBox, "textBox");
			this.textBox.Name = "textBox";
			this.textBox.TextChanged += new System.EventHandler(this.ChangeTransInput);
			// 
			// resultsLabel
			// 
			resources.ApplyResources(this.resultsLabel, "resultsLabel");
			this.resultsLabel.Name = "resultsLabel";
			// 
			// resultBox
			// 
			resources.ApplyResources(this.resultBox, "resultBox");
			this.resultBox.Name = "resultBox";
			// 
			// textCmdPanel
			// 
			resources.ApplyResources(this.textCmdPanel, "textCmdPanel");
			this.textCmdPanel.Controls.Add(this.translateTextButton);
			this.textCmdPanel.Controls.Add(this.toCodeLabel);
			this.textCmdPanel.Controls.Add(this.toCodeBox);
			this.textCmdPanel.Controls.Add(this.fromCodeBox);
			this.textCmdPanel.Controls.Add(this.fromCodeLabel);
			this.textCmdPanel.Name = "textCmdPanel";
			// 
			// translateTextButton
			// 
			resources.ApplyResources(this.translateTextButton, "translateTextButton");
			this.translateTextButton.Name = "translateTextButton";
			this.translateTextButton.UseVisualStyleBackColor = true;
			this.translateTextButton.Click += new System.EventHandler(this.TranslateOne);
			// 
			// toCodeLabel
			// 
			resources.ApplyResources(this.toCodeLabel, "toCodeLabel");
			this.toCodeLabel.Name = "toCodeLabel";
			// 
			// toCodeBox
			// 
			this.toCodeBox.FormattingEnabled = true;
			resources.ApplyResources(this.toCodeBox, "toCodeBox");
			this.toCodeBox.Name = "toCodeBox";
			this.toCodeBox.SelectedIndexChanged += new System.EventHandler(this.ChangeTransInput);
			// 
			// fromCodeBox
			// 
			this.fromCodeBox.FormattingEnabled = true;
			resources.ApplyResources(this.fromCodeBox, "fromCodeBox");
			this.fromCodeBox.Name = "fromCodeBox";
			this.fromCodeBox.SelectedIndexChanged += new System.EventHandler(this.ChangeTransInput);
			// 
			// fromCodeLabel
			// 
			resources.ApplyResources(this.fromCodeLabel, "fromCodeLabel");
			this.fromCodeLabel.Name = "fromCodeLabel";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// MainWindow
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabs);
			this.Name = "MainWindow";
			this.tabs.ResumeLayout(false);
			this.resxTab.ResumeLayout(false);
			this.resxTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.delayBox)).EndInit();
			this.sheetPanel.ResumeLayout(false);
			this.sheetPanel.PerformLayout();
			this.textTab.ResumeLayout(false);
			this.textTab.PerformLayout();
			this.textCmdPanel.ResumeLayout(false);
			this.textCmdPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage textTab;
		private System.Windows.Forms.Panel textCmdPanel;
		private System.Windows.Forms.Button translateTextButton;
		private System.Windows.Forms.Label toCodeLabel;
		private System.Windows.Forms.ComboBox toCodeBox;
		private System.Windows.Forms.ComboBox fromCodeBox;
		private System.Windows.Forms.Label fromCodeLabel;
		private System.Windows.Forms.TabPage resxTab;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Label resultsLabel;
		private System.Windows.Forms.TextBox resultBox;
		private System.Windows.Forms.Button translateButton;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ListView languageList;
		private System.Windows.Forms.Label translationsLabel;
		private System.Windows.Forms.Button browseFolderButton;
		private System.Windows.Forms.TextBox outputBox;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.Button browseFileButton;
		private System.Windows.Forms.ComboBox codeBox;
		private System.Windows.Forms.TextBox inputBox;
		private System.Windows.Forms.Label inputLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label estimationLabel;
		private System.Windows.Forms.Panel sheetPanel;
		private System.Windows.Forms.TextBox logBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.NumericUpDown delayBox;
		private System.Windows.Forms.Label delayLabel;
		private System.Windows.Forms.Label recommendationLabel;
	}
}

