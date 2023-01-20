namespace ExamSheets
{
    partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openDocDialog = new System.Windows.Forms.OpenFileDialog();
         this.dataBox = new System.Windows.Forms.TextBox();
         this.messageBox = new System.Windows.Forms.TextBox();
         this.dateBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.testRadio = new System.Windows.Forms.RadioButton();
         this.examRadio = new System.Windows.Forms.RadioButton();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(3, 4);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
         this.menuStrip1.Size = new System.Drawing.Size(398, 33);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
         this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this.openToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
         this.openToolStripMenuItem.Text = "&Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // toolStripSeparator
         // 
         this.toolStripSeparator.Name = "toolStripSeparator";
         this.toolStripSeparator.Size = new System.Drawing.Size(220, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
         this.exitToolStripMenuItem.Text = "E&xit";
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // contentsToolStripMenuItem
         // 
         this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
         this.contentsToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
         this.contentsToolStripMenuItem.Text = "&Help...";
         this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(173, 6);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
         this.aboutToolStripMenuItem.Text = "&About...";
         // 
         // openDocDialog
         // 
         this.openDocDialog.Filter = "Word docs|*.docx|All files|*.*";
         // 
         // dataBox
         // 
         this.dataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dataBox.Location = new System.Drawing.Point(3, 94);
         this.dataBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.dataBox.Multiline = true;
         this.dataBox.Name = "dataBox";
         this.dataBox.Size = new System.Drawing.Size(396, 589);
         this.dataBox.TabIndex = 4;
         this.dataBox.Text = resources.GetString("dataBox.Text");
         // 
         // messageBox
         // 
         this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.messageBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
         this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.messageBox.Location = new System.Drawing.Point(3, 691);
         this.messageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.messageBox.Multiline = true;
         this.messageBox.Name = "messageBox";
         this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.messageBox.Size = new System.Drawing.Size(396, 180);
         this.messageBox.TabIndex = 4;
         this.messageBox.TabStop = false;
         // 
         // dateBox
         // 
         this.dateBox.Location = new System.Drawing.Point(58, 48);
         this.dateBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.dateBox.Name = "dateBox";
         this.dateBox.Size = new System.Drawing.Size(101, 26);
         this.dateBox.TabIndex = 1;
         this.dateBox.Text = "19.10";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 51);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 20);
         this.label1.TabIndex = 6;
         this.label1.Text = "Date";
         // 
         // testRadio
         // 
         this.testRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.testRadio.AutoSize = true;
         this.testRadio.Location = new System.Drawing.Point(335, 49);
         this.testRadio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.testRadio.Name = "testRadio";
         this.testRadio.Size = new System.Drawing.Size(65, 24);
         this.testRadio.TabIndex = 3;
         this.testRadio.TabStop = true;
         this.testRadio.Text = "Test";
         this.testRadio.UseVisualStyleBackColor = true;
         // 
         // examRadio
         // 
         this.examRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.examRadio.AutoSize = true;
         this.examRadio.Checked = true;
         this.examRadio.Location = new System.Drawing.Point(258, 49);
         this.examRadio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.examRadio.Name = "examRadio";
         this.examRadio.Size = new System.Drawing.Size(74, 24);
         this.examRadio.TabIndex = 2;
         this.examRadio.TabStop = true;
         this.examRadio.Text = "Exam";
         this.examRadio.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(404, 879);
         this.Controls.Add(this.examRadio);
         this.Controls.Add(this.testRadio);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.dateBox);
         this.Controls.Add(this.messageBox);
         this.Controls.Add(this.dataBox);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.MinimumSize = new System.Drawing.Size(335, 361);
         this.Name = "MainForm";
         this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Text = "Exam Sheets";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDocDialog;
        private System.Windows.Forms.TextBox dataBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton testRadio;
        private System.Windows.Forms.RadioButton examRadio;
    }
}

