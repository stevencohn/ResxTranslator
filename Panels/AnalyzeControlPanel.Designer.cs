namespace ResxTranslator.Panels
{
	partial class AnalyzeControlPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyzeControlPanel));
			this.introLabel = new System.Windows.Forms.Label();
			this.logbox = new System.Windows.Forms.RichTextBox();
			this.cmdPanel = new System.Windows.Forms.Panel();
			this.analyzeButton = new System.Windows.Forms.Button();
			this.sourceBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.sourceLabel = new System.Windows.Forms.Label();
			this.introPanel = new System.Windows.Forms.Panel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.cmdPanel.SuspendLayout();
			this.introPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// introLabel
			// 
			this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.introLabel.AutoSize = true;
			this.introLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.introLabel.Location = new System.Drawing.Point(6, 26);
			this.introLabel.Name = "introLabel";
			this.introLabel.Size = new System.Drawing.Size(551, 20);
			this.introLabel.TabIndex = 11;
			this.introLabel.Text = "Results - entries with either NODUP or SKIP in their comments will be ignored";
			// 
			// logbox
			// 
			this.logbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logbox.Location = new System.Drawing.Point(0, 106);
			this.logbox.Margin = new System.Windows.Forms.Padding(0);
			this.logbox.Name = "logbox";
			this.logbox.Size = new System.Drawing.Size(1013, 651);
			this.logbox.TabIndex = 12;
			this.logbox.Text = "";
			// 
			// cmdPanel
			// 
			this.cmdPanel.Controls.Add(this.analyzeButton);
			this.cmdPanel.Controls.Add(this.sourceBox);
			this.cmdPanel.Controls.Add(this.browseButton);
			this.cmdPanel.Controls.Add(this.sourceLabel);
			this.cmdPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmdPanel.Location = new System.Drawing.Point(0, 0);
			this.cmdPanel.Name = "cmdPanel";
			this.cmdPanel.Size = new System.Drawing.Size(1013, 55);
			this.cmdPanel.TabIndex = 10;
			// 
			// analyzeButton
			// 
			this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.analyzeButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Translate;
			this.analyzeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.analyzeButton.Enabled = false;
			this.analyzeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.analyzeButton.Location = new System.Drawing.Point(950, 5);
			this.analyzeButton.Name = "analyzeButton";
			this.analyzeButton.Size = new System.Drawing.Size(60, 47);
			this.analyzeButton.TabIndex = 7;
			this.analyzeButton.UseVisualStyleBackColor = true;
			this.analyzeButton.Click += new System.EventHandler(this.AnalyzeOnClick);
			// 
			// sourceBox
			// 
			this.sourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sourceBox.Location = new System.Drawing.Point(119, 15);
			this.sourceBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.sourceBox.Name = "sourceBox";
			this.sourceBox.Size = new System.Drawing.Size(759, 26);
			this.sourceBox.TabIndex = 5;
			this.sourceBox.TextChanged += new System.EventHandler(this.EnableControlsOnTextChanged);
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.AutoSize = true;
			this.browseButton.Image = ((System.Drawing.Image)(resources.GetObject("browseButton.Image")));
			this.browseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.browseButton.Location = new System.Drawing.Point(884, 5);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(60, 47);
			this.browseButton.TabIndex = 6;
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.BrowseOnClick);
			// 
			// sourceLabel
			// 
			this.sourceLabel.AutoSize = true;
			this.sourceLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.sourceLabel.Location = new System.Drawing.Point(9, 18);
			this.sourceLabel.Name = "sourceLabel";
			this.sourceLabel.Size = new System.Drawing.Size(104, 20);
			this.sourceLabel.TabIndex = 4;
			this.sourceLabel.Text = "Source Resx:";
			// 
			// introPanel
			// 
			this.introPanel.Controls.Add(this.introLabel);
			this.introPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.introPanel.Location = new System.Drawing.Point(0, 55);
			this.introPanel.Name = "introPanel";
			this.introPanel.Size = new System.Drawing.Size(1013, 51);
			this.introPanel.TabIndex = 13;
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "resx";
			this.openFileDialog.Filter = "Resx Files (*.resx)|*.resx|Hint Files (*-hints.xml)|*-hints.xml";
			this.openFileDialog.Title = "Choose source resx file";
			// 
			// AnalyzeControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.logbox);
			this.Controls.Add(this.introPanel);
			this.Controls.Add(this.cmdPanel);
			this.Name = "AnalyzeControlPanel";
			this.Size = new System.Drawing.Size(1013, 757);
			this.cmdPanel.ResumeLayout(false);
			this.cmdPanel.PerformLayout();
			this.introPanel.ResumeLayout(false);
			this.introPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label introLabel;
		private System.Windows.Forms.RichTextBox logbox;
		private System.Windows.Forms.Panel cmdPanel;
		private System.Windows.Forms.Button analyzeButton;
		private System.Windows.Forms.TextBox sourceBox;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label sourceLabel;
		private System.Windows.Forms.Panel introPanel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
