namespace ResxTranslator.Panels
{
	partial class ToolsControlPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsControlPanel));
			this.logbox = new System.Windows.Forms.RichTextBox();
			this.updateLabel = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.sortLabel = new System.Windows.Forms.Label();
			this.sortButton = new System.Windows.Forms.Button();
			this.cmdPanel = new System.Windows.Forms.Panel();
			this.sourceBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.sourceLabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolPanel = new System.Windows.Forms.Panel();
			this.cmdPanel.SuspendLayout();
			this.toolPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// logbox
			// 
			this.logbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logbox.Location = new System.Drawing.Point(3, 256);
			this.logbox.Margin = new System.Windows.Forms.Padding(0);
			this.logbox.Name = "logbox";
			this.logbox.Size = new System.Drawing.Size(998, 465);
			this.logbox.TabIndex = 21;
			this.logbox.Text = "";
			// 
			// updateLabel
			// 
			this.updateLabel.AutoSize = true;
			this.updateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.updateLabel.Location = new System.Drawing.Point(133, 132);
			this.updateLabel.Name = "updateLabel";
			this.updateLabel.Size = new System.Drawing.Size(475, 20);
			this.updateLabel.TabIndex = 20;
			this.updateLabel.Text = "Update <source> values in hints file; based on its ./Resources.resx";
			// 
			// updateButton
			// 
			this.updateButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Update;
			this.updateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.updateButton.Enabled = false;
			this.updateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.updateButton.Location = new System.Drawing.Point(39, 116);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(85, 47);
			this.updateButton.TabIndex = 19;
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.UpdateHintsOnClick);
			// 
			// sortLabel
			// 
			this.sortLabel.AutoSize = true;
			this.sortLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.sortLabel.Location = new System.Drawing.Point(133, 44);
			this.sortLabel.Name = "sortLabel";
			this.sortLabel.Size = new System.Drawing.Size(287, 20);
			this.sortLabel.TabIndex = 18;
			this.sortLabel.Text = "Sort all <data> elements in resource file";
			// 
			// sortButton
			// 
			this.sortButton.BackgroundImage = global::ResxTranslator.Properties.Resources.Sort;
			this.sortButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.sortButton.Enabled = false;
			this.sortButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.sortButton.Location = new System.Drawing.Point(39, 28);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(85, 47);
			this.sortButton.TabIndex = 17;
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.SortResourcesOnClick);
			// 
			// cmdPanel
			// 
			this.cmdPanel.Controls.Add(this.sourceBox);
			this.cmdPanel.Controls.Add(this.browseButton);
			this.cmdPanel.Controls.Add(this.sourceLabel);
			this.cmdPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmdPanel.Location = new System.Drawing.Point(3, 3);
			this.cmdPanel.Name = "cmdPanel";
			this.cmdPanel.Size = new System.Drawing.Size(998, 55);
			this.cmdPanel.TabIndex = 16;
			// 
			// sourceBox
			// 
			this.sourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sourceBox.Location = new System.Drawing.Point(119, 15);
			this.sourceBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.sourceBox.Name = "sourceBox";
			this.sourceBox.Size = new System.Drawing.Size(786, 26);
			this.sourceBox.TabIndex = 5;
			this.sourceBox.TextChanged += new System.EventHandler(this.EnableControlsOnTextChanged);
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.AutoSize = true;
			this.browseButton.Image = ((System.Drawing.Image)(resources.GetObject("browseButton.Image")));
			this.browseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.browseButton.Location = new System.Drawing.Point(911, 5);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(60, 47);
			this.browseButton.TabIndex = 6;
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.BrowseFilesOnClick);
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
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "resx";
			this.openFileDialog.Filter = "Resx Files (*.resx)|*.resx|Hint Files (*-hints.xml)|*-hints.xml";
			this.openFileDialog.Title = "Choose source resx file";
			// 
			// toolPanel
			// 
			this.toolPanel.Controls.Add(this.sortButton);
			this.toolPanel.Controls.Add(this.sortLabel);
			this.toolPanel.Controls.Add(this.updateLabel);
			this.toolPanel.Controls.Add(this.updateButton);
			this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolPanel.Location = new System.Drawing.Point(3, 58);
			this.toolPanel.Name = "toolPanel";
			this.toolPanel.Size = new System.Drawing.Size(998, 198);
			this.toolPanel.TabIndex = 22;
			// 
			// ToolsControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.logbox);
			this.Controls.Add(this.toolPanel);
			this.Controls.Add(this.cmdPanel);
			this.Name = "ToolsControlPanel";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(1004, 724);
			this.cmdPanel.ResumeLayout(false);
			this.cmdPanel.PerformLayout();
			this.toolPanel.ResumeLayout(false);
			this.toolPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox logbox;
		private System.Windows.Forms.Label updateLabel;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Label sortLabel;
		private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.Panel cmdPanel;
		private System.Windows.Forms.TextBox sourceBox;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label sourceLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel toolPanel;
	}
}
