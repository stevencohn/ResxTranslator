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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.tabs = new System.Windows.Forms.TabControl();
			this.resxTab = new System.Windows.Forms.TabPage();
			this.clearBox = new System.Windows.Forms.CheckBox();
			this.restartButton = new System.Windows.Forms.Button();
			this.compareBox = new System.Windows.Forms.CheckBox();
			this.optionsLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.sheetPanel = new System.Windows.Forms.Panel();
			this.logBox = new System.Windows.Forms.RichTextBox();
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
			this.resultBox = new System.Windows.Forms.RichTextBox();
			this.textCmdPanel = new System.Windows.Forms.Panel();
			this.cancelOneButton = new System.Windows.Forms.Button();
			this.translateTextButton = new System.Windows.Forms.Button();
			this.toCodeLabel = new System.Windows.Forms.Label();
			this.toCodeBox = new System.Windows.Forms.ComboBox();
			this.fromCodeBox = new System.Windows.Forms.ComboBox();
			this.fromCodeLabel = new System.Windows.Forms.Label();
			this.analyzeTab = new System.Windows.Forms.TabPage();
			this.analyzeResultsLabel = new System.Windows.Forms.Label();
			this.reportBox = new System.Windows.Forms.RichTextBox();
			this.analyzeCmdPanel = new System.Windows.Forms.Panel();
			this.analyzeButton = new System.Windows.Forms.Button();
			this.analyzeSourceBox = new System.Windows.Forms.TextBox();
			this.analyzeBrowseButton = new System.Windows.Forms.Button();
			this.analyzeSourceLabel = new System.Windows.Forms.Label();
			this.toolsPage = new System.Windows.Forms.TabPage();
			this.toolsReportBox = new System.Windows.Forms.RichTextBox();
			this.toolsUpdateLabel = new System.Windows.Forms.Label();
			this.toolsUpdateButton = new System.Windows.Forms.Button();
			this.toolsSortLabel = new System.Windows.Forms.Label();
			this.toolsSortButton = new System.Windows.Forms.Button();
			this.toolsCmdPanel = new System.Windows.Forms.Panel();
			this.toolsSourceBox = new System.Windows.Forms.TextBox();
			this.toolsBrowseButton = new System.Windows.Forms.Button();
			this.toolsSourceLabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.sortBox = new System.Windows.Forms.CheckBox();
			this.tabs.SuspendLayout();
			this.resxTab.SuspendLayout();
			this.sheetPanel.SuspendLayout();
			this.textTab.SuspendLayout();
			this.textCmdPanel.SuspendLayout();
			this.analyzeTab.SuspendLayout();
			this.analyzeCmdPanel.SuspendLayout();
			this.toolsPage.SuspendLayout();
			this.toolsCmdPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.resxTab);
			this.tabs.Controls.Add(this.textTab);
			this.tabs.Controls.Add(this.analyzeTab);
			this.tabs.Controls.Add(this.toolsPage);
			resources.ApplyResources(this.tabs, "tabs");
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			// 
			// resxTab
			// 
			this.resxTab.Controls.Add(this.sortBox);
			this.resxTab.Controls.Add(this.clearBox);
			this.resxTab.Controls.Add(this.restartButton);
			this.resxTab.Controls.Add(this.compareBox);
			this.resxTab.Controls.Add(this.optionsLabel);
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
			// clearBox
			// 
			resources.ApplyResources(this.clearBox, "clearBox");
			this.clearBox.Checked = true;
			this.clearBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clearBox.Name = "clearBox";
			this.clearBox.UseVisualStyleBackColor = true;
			// 
			// restartButton
			// 
			resources.ApplyResources(this.restartButton, "restartButton");
			this.restartButton.Name = "restartButton";
			this.toolTip.SetToolTip(this.restartButton, resources.GetString("restartButton.ToolTip"));
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Click += new System.EventHandler(this.Restart);
			// 
			// compareBox
			// 
			resources.ApplyResources(this.compareBox, "compareBox");
			this.compareBox.Checked = true;
			this.compareBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.compareBox.Name = "compareBox";
			this.compareBox.UseVisualStyleBackColor = true;
			this.compareBox.CheckedChanged += new System.EventHandler(this.CompareChanged);
			// 
			// optionsLabel
			// 
			resources.ApplyResources(this.optionsLabel, "optionsLabel");
			this.optionsLabel.Name = "optionsLabel";
			// 
			// cancelButton
			// 
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.Name = "cancelButton";
			this.toolTip.SetToolTip(this.cancelButton, resources.GetString("cancelButton.ToolTip"));
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
			this.toolTip.SetToolTip(this.translateButton, resources.GetString("translateButton.ToolTip"));
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
			this.toolTip.SetToolTip(this.browseFolderButton, resources.GetString("browseFolderButton.ToolTip"));
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
			this.toolTip.SetToolTip(this.browseFileButton, resources.GetString("browseFileButton.ToolTip"));
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
			this.textCmdPanel.Controls.Add(this.cancelOneButton);
			this.textCmdPanel.Controls.Add(this.translateTextButton);
			this.textCmdPanel.Controls.Add(this.toCodeLabel);
			this.textCmdPanel.Controls.Add(this.toCodeBox);
			this.textCmdPanel.Controls.Add(this.fromCodeBox);
			this.textCmdPanel.Controls.Add(this.fromCodeLabel);
			this.textCmdPanel.Name = "textCmdPanel";
			// 
			// cancelOneButton
			// 
			resources.ApplyResources(this.cancelOneButton, "cancelOneButton");
			this.cancelOneButton.Name = "cancelOneButton";
			this.toolTip.SetToolTip(this.cancelOneButton, resources.GetString("cancelOneButton.ToolTip"));
			this.cancelOneButton.UseVisualStyleBackColor = true;
			this.cancelOneButton.Click += new System.EventHandler(this.CancelTranslateOne);
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
			// analyzeTab
			// 
			this.analyzeTab.Controls.Add(this.analyzeResultsLabel);
			this.analyzeTab.Controls.Add(this.reportBox);
			this.analyzeTab.Controls.Add(this.analyzeCmdPanel);
			resources.ApplyResources(this.analyzeTab, "analyzeTab");
			this.analyzeTab.Name = "analyzeTab";
			this.analyzeTab.UseVisualStyleBackColor = true;
			// 
			// analyzeResultsLabel
			// 
			resources.ApplyResources(this.analyzeResultsLabel, "analyzeResultsLabel");
			this.analyzeResultsLabel.Name = "analyzeResultsLabel";
			// 
			// reportBox
			// 
			resources.ApplyResources(this.reportBox, "reportBox");
			this.reportBox.Name = "reportBox";
			// 
			// analyzeCmdPanel
			// 
			resources.ApplyResources(this.analyzeCmdPanel, "analyzeCmdPanel");
			this.analyzeCmdPanel.Controls.Add(this.analyzeButton);
			this.analyzeCmdPanel.Controls.Add(this.analyzeSourceBox);
			this.analyzeCmdPanel.Controls.Add(this.analyzeBrowseButton);
			this.analyzeCmdPanel.Controls.Add(this.analyzeSourceLabel);
			this.analyzeCmdPanel.Name = "analyzeCmdPanel";
			// 
			// analyzeButton
			// 
			resources.ApplyResources(this.analyzeButton, "analyzeButton");
			this.analyzeButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Translate;
			this.analyzeButton.Name = "analyzeButton";
			this.analyzeButton.UseVisualStyleBackColor = true;
			this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButtonClick);
			// 
			// analyzeSourceBox
			// 
			resources.ApplyResources(this.analyzeSourceBox, "analyzeSourceBox");
			this.analyzeSourceBox.Name = "analyzeSourceBox";
			this.analyzeSourceBox.TextChanged += new System.EventHandler(this.AnalyzeBoxTextChanged);
			// 
			// analyzeBrowseButton
			// 
			resources.ApplyResources(this.analyzeBrowseButton, "analyzeBrowseButton");
			this.analyzeBrowseButton.Name = "analyzeBrowseButton";
			this.toolTip.SetToolTip(this.analyzeBrowseButton, resources.GetString("analyzeBrowseButton.ToolTip"));
			this.analyzeBrowseButton.UseVisualStyleBackColor = true;
			this.analyzeBrowseButton.Click += new System.EventHandler(this.BrowseFiles);
			// 
			// analyzeSourceLabel
			// 
			resources.ApplyResources(this.analyzeSourceLabel, "analyzeSourceLabel");
			this.analyzeSourceLabel.Name = "analyzeSourceLabel";
			// 
			// toolsPage
			// 
			this.toolsPage.Controls.Add(this.toolsReportBox);
			this.toolsPage.Controls.Add(this.toolsUpdateLabel);
			this.toolsPage.Controls.Add(this.toolsUpdateButton);
			this.toolsPage.Controls.Add(this.toolsSortLabel);
			this.toolsPage.Controls.Add(this.toolsSortButton);
			this.toolsPage.Controls.Add(this.toolsCmdPanel);
			resources.ApplyResources(this.toolsPage, "toolsPage");
			this.toolsPage.Name = "toolsPage";
			this.toolsPage.UseVisualStyleBackColor = true;
			// 
			// toolsReportBox
			// 
			resources.ApplyResources(this.toolsReportBox, "toolsReportBox");
			this.toolsReportBox.Name = "toolsReportBox";
			// 
			// toolsUpdateLabel
			// 
			resources.ApplyResources(this.toolsUpdateLabel, "toolsUpdateLabel");
			this.toolsUpdateLabel.Name = "toolsUpdateLabel";
			// 
			// toolsUpdateButton
			// 
			this.toolsUpdateButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Update;
			resources.ApplyResources(this.toolsUpdateButton, "toolsUpdateButton");
			this.toolsUpdateButton.Name = "toolsUpdateButton";
			this.toolsUpdateButton.UseVisualStyleBackColor = true;
			this.toolsUpdateButton.Click += new System.EventHandler(this.UpdateHints);
			// 
			// toolsSortLabel
			// 
			resources.ApplyResources(this.toolsSortLabel, "toolsSortLabel");
			this.toolsSortLabel.Name = "toolsSortLabel";
			// 
			// toolsSortButton
			// 
			this.toolsSortButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Sort;
			resources.ApplyResources(this.toolsSortButton, "toolsSortButton");
			this.toolsSortButton.Name = "toolsSortButton";
			this.toolsSortButton.UseVisualStyleBackColor = true;
			this.toolsSortButton.Click += new System.EventHandler(this.SortResx);
			// 
			// toolsCmdPanel
			// 
			resources.ApplyResources(this.toolsCmdPanel, "toolsCmdPanel");
			this.toolsCmdPanel.Controls.Add(this.toolsSourceBox);
			this.toolsCmdPanel.Controls.Add(this.toolsBrowseButton);
			this.toolsCmdPanel.Controls.Add(this.toolsSourceLabel);
			this.toolsCmdPanel.Name = "toolsCmdPanel";
			// 
			// toolsSourceBox
			// 
			resources.ApplyResources(this.toolsSourceBox, "toolsSourceBox");
			this.toolsSourceBox.Name = "toolsSourceBox";
			this.toolsSourceBox.TextChanged += new System.EventHandler(this.ToolsSourceBoxTextChanged);
			// 
			// toolsBrowseButton
			// 
			resources.ApplyResources(this.toolsBrowseButton, "toolsBrowseButton");
			this.toolsBrowseButton.Name = "toolsBrowseButton";
			this.toolTip.SetToolTip(this.toolsBrowseButton, resources.GetString("toolsBrowseButton.ToolTip"));
			this.toolsBrowseButton.UseVisualStyleBackColor = true;
			this.toolsBrowseButton.Click += new System.EventHandler(this.BrowseFiles);
			// 
			// toolsSourceLabel
			// 
			resources.ApplyResources(this.toolsSourceLabel, "toolsSourceLabel");
			this.toolsSourceLabel.Name = "toolsSourceLabel";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "resx";
			this.openFileDialog.FileName = "openFileDialog1";
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// folderBrowserDialog
			// 
			resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
			// 
			// sortBox
			// 
			resources.ApplyResources(this.sortBox, "sortBox");
			this.sortBox.Checked = true;
			this.sortBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.sortBox.Name = "sortBox";
			this.sortBox.UseVisualStyleBackColor = true;
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
			this.sheetPanel.ResumeLayout(false);
			this.textTab.ResumeLayout(false);
			this.textTab.PerformLayout();
			this.textCmdPanel.ResumeLayout(false);
			this.textCmdPanel.PerformLayout();
			this.analyzeTab.ResumeLayout(false);
			this.analyzeTab.PerformLayout();
			this.analyzeCmdPanel.ResumeLayout(false);
			this.analyzeCmdPanel.PerformLayout();
			this.toolsPage.ResumeLayout(false);
			this.toolsPage.PerformLayout();
			this.toolsCmdPanel.ResumeLayout(false);
			this.toolsCmdPanel.PerformLayout();
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
		private System.Windows.Forms.RichTextBox resultBox;
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
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label optionsLabel;
		private System.Windows.Forms.CheckBox compareBox;
		private System.Windows.Forms.Button restartButton;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button cancelOneButton;
		private System.Windows.Forms.RichTextBox logBox;
		private System.Windows.Forms.CheckBox clearBox;
		private System.Windows.Forms.TabPage analyzeTab;
		private System.Windows.Forms.Label analyzeResultsLabel;
		private System.Windows.Forms.RichTextBox reportBox;
		private System.Windows.Forms.Panel analyzeCmdPanel;
		private System.Windows.Forms.TextBox analyzeSourceBox;
		private System.Windows.Forms.Button analyzeBrowseButton;
		private System.Windows.Forms.Label analyzeSourceLabel;
		private System.Windows.Forms.Button analyzeButton;
		private System.Windows.Forms.TabPage toolsPage;
		private System.Windows.Forms.Panel toolsCmdPanel;
		private System.Windows.Forms.TextBox toolsSourceBox;
		private System.Windows.Forms.Button toolsBrowseButton;
		private System.Windows.Forms.Label toolsSourceLabel;
		private System.Windows.Forms.Button toolsSortButton;
		private System.Windows.Forms.Label toolsSortLabel;
		private System.Windows.Forms.Label toolsUpdateLabel;
		private System.Windows.Forms.Button toolsUpdateButton;
		private System.Windows.Forms.RichTextBox toolsReportBox;
		private System.Windows.Forms.CheckBox sortBox;
	}
}

