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
			this.sortBox = new System.Windows.Forms.CheckBox();
			this.clearBox = new System.Windows.Forms.CheckBox();
			this.restartButton = new System.Windows.Forms.Button();
			this.newStringsBox = new System.Windows.Forms.CheckBox();
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
			this.analyzeTab = new System.Windows.Forms.TabPage();
			this.analyzeControlPanel = new ResxTranslator.Panels.AnalyzeControlPanel();
			this.toolsPage = new System.Windows.Forms.TabPage();
			this.toolsControlPanel = new ResxTranslator.Panels.ToolsControlPanel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.textControlPanel = new ResxTranslator.Panels.TextControlPanel();
			this.tabs.SuspendLayout();
			this.resxTab.SuspendLayout();
			this.sheetPanel.SuspendLayout();
			this.textTab.SuspendLayout();
			this.analyzeTab.SuspendLayout();
			this.toolsPage.SuspendLayout();
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
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.PrepTabOnSelectedIndexChanged);
			// 
			// resxTab
			// 
			this.resxTab.Controls.Add(this.sortBox);
			this.resxTab.Controls.Add(this.clearBox);
			this.resxTab.Controls.Add(this.restartButton);
			this.resxTab.Controls.Add(this.newStringsBox);
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
			// sortBox
			// 
			resources.ApplyResources(this.sortBox, "sortBox");
			this.sortBox.Checked = true;
			this.sortBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.sortBox.Name = "sortBox";
			this.sortBox.UseVisualStyleBackColor = true;
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
			resources.ApplyResources(this.newStringsBox, "compareBox");
			this.newStringsBox.Checked = true;
			this.newStringsBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.newStringsBox.Name = "compareBox";
			this.newStringsBox.UseVisualStyleBackColor = true;
			this.newStringsBox.CheckedChanged += new System.EventHandler(this.CompareChanged);
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
			this.textTab.Controls.Add(this.textControlPanel);
			resources.ApplyResources(this.textTab, "textTab");
			this.textTab.Name = "textTab";
			this.textTab.UseVisualStyleBackColor = true;
			// 
			// analyzeTab
			// 
			this.analyzeTab.Controls.Add(this.analyzeControlPanel);
			resources.ApplyResources(this.analyzeTab, "analyzeTab");
			this.analyzeTab.Name = "analyzeTab";
			this.analyzeTab.UseVisualStyleBackColor = true;
			// 
			// analyzeControlPanel
			// 
			resources.ApplyResources(this.analyzeControlPanel, "analyzeControlPanel");
			this.analyzeControlPanel.Name = "analyzeControlPanel";
			// 
			// toolsPage
			// 
			this.toolsPage.Controls.Add(this.toolsControlPanel);
			resources.ApplyResources(this.toolsPage, "toolsPage");
			this.toolsPage.Name = "toolsPage";
			this.toolsPage.UseVisualStyleBackColor = true;
			// 
			// toolsControlPanel
			// 
			resources.ApplyResources(this.toolsControlPanel, "toolsControlPanel");
			this.toolsControlPanel.Name = "toolsControlPanel";
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
			// textControlPanel
			// 
			resources.ApplyResources(this.textControlPanel, "textControlPanel");
			this.textControlPanel.Name = "textControlPanel";
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
			this.analyzeTab.ResumeLayout(false);
			this.toolsPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage textTab;
		private System.Windows.Forms.TabPage resxTab;
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
		private System.Windows.Forms.CheckBox newStringsBox;
		private System.Windows.Forms.Button restartButton;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.RichTextBox logBox;
		private System.Windows.Forms.CheckBox clearBox;
		private System.Windows.Forms.TabPage analyzeTab;
		private System.Windows.Forms.TabPage toolsPage;
		private System.Windows.Forms.CheckBox sortBox;
		private Panels.ToolsControlPanel toolsControlPanel;
		private Panels.AnalyzeControlPanel analyzeControlPanel;
		private Panels.TextControlPanel textControlPanel;
	}
}

