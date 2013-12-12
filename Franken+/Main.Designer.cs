namespace Franken_
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ingestGlyphsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontBox = new System.Windows.Forms.ComboBox();
            this.editFontButton = new System.Windows.Forms.Button();
            this.createFontButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tiffXMLBrowseButton = new System.Windows.Forms.Button();
            this.tiffXMLInputBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.createTiffBoxButton = new System.Windows.Forms.Button();
            this.transTextBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.transTextBox = new System.Windows.Forms.TextBox();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subTransBox = new System.Windows.Forms.CheckBox();
            this.subIngestBox = new System.Windows.Forms.CheckBox();
            this.delSubButton = new System.Windows.Forms.Button();
            this.newSubButton = new System.Windows.Forms.Button();
            this.substitutionsList = new System.Windows.Forms.ListBox();
            this.trainTessButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.createLangButton = new System.Windows.Forms.Button();
            this.langBox = new System.Windows.Forms.ComboBox();
            this.copyFontButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ingestGlyphsButton
            // 
            this.ingestGlyphsButton.Location = new System.Drawing.Point(7, 62);
            this.ingestGlyphsButton.Name = "ingestGlyphsButton";
            this.ingestGlyphsButton.Size = new System.Drawing.Size(95, 23);
            this.ingestGlyphsButton.TabIndex = 1;
            this.ingestGlyphsButton.Text = "Ingest Glyphs";
            this.ingestGlyphsButton.UseVisualStyleBackColor = true;
            this.ingestGlyphsButton.Click += new System.EventHandler(this.ingestGlyphsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Font:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Language:";
            // 
            // fontBox
            // 
            this.fontBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontBox.FormattingEnabled = true;
            this.fontBox.Location = new System.Drawing.Point(233, 48);
            this.fontBox.Name = "fontBox";
            this.fontBox.Size = new System.Drawing.Size(200, 21);
            this.fontBox.TabIndex = 13;
            // 
            // editFontButton
            // 
            this.editFontButton.Location = new System.Drawing.Point(233, 75);
            this.editFontButton.Name = "editFontButton";
            this.editFontButton.Size = new System.Drawing.Size(60, 24);
            this.editFontButton.TabIndex = 14;
            this.editFontButton.Text = "Edit";
            this.editFontButton.UseVisualStyleBackColor = true;
            this.editFontButton.Click += new System.EventHandler(this.editFontButton_Click);
            // 
            // createFontButton
            // 
            this.createFontButton.Location = new System.Drawing.Point(299, 75);
            this.createFontButton.Name = "createFontButton";
            this.createFontButton.Size = new System.Drawing.Size(66, 24);
            this.createFontButton.TabIndex = 15;
            this.createFontButton.Text = "Create";
            this.createFontButton.UseVisualStyleBackColor = true;
            this.createFontButton.Click += new System.EventHandler(this.createFontButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.ingestGlyphsButton);
            this.groupBox3.Controls.Add(this.tiffXMLBrowseButton);
            this.groupBox3.Controls.Add(this.tiffXMLInputBox);
            this.groupBox3.Location = new System.Drawing.Point(15, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 98);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aletheia TIF/XML";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Input Folder";
            // 
            // tiffXMLBrowseButton
            // 
            this.tiffXMLBrowseButton.Location = new System.Drawing.Point(171, 34);
            this.tiffXMLBrowseButton.Name = "tiffXMLBrowseButton";
            this.tiffXMLBrowseButton.Size = new System.Drawing.Size(23, 23);
            this.tiffXMLBrowseButton.TabIndex = 1;
            this.tiffXMLBrowseButton.Text = "...";
            this.tiffXMLBrowseButton.UseVisualStyleBackColor = true;
            this.tiffXMLBrowseButton.Click += new System.EventHandler(this.tiffXMLBrowseButton_Click);
            // 
            // tiffXMLInputBox
            // 
            this.tiffXMLInputBox.Location = new System.Drawing.Point(7, 36);
            this.tiffXMLInputBox.Name = "tiffXMLInputBox";
            this.tiffXMLInputBox.Size = new System.Drawing.Size(162, 20);
            this.tiffXMLInputBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.createTiffBoxButton);
            this.groupBox4.Controls.Add(this.transTextBrowseButton);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.transTextBox);
            this.groupBox4.Location = new System.Drawing.Point(15, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 104);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Synthesize TIF/Box Pair";
            // 
            // createTiffBoxButton
            // 
            this.createTiffBoxButton.Location = new System.Drawing.Point(7, 68);
            this.createTiffBoxButton.Name = "createTiffBoxButton";
            this.createTiffBoxButton.Size = new System.Drawing.Size(132, 23);
            this.createTiffBoxButton.TabIndex = 4;
            this.createTiffBoxButton.Text = "Create TIF/Box Pairs";
            this.createTiffBoxButton.UseVisualStyleBackColor = true;
            this.createTiffBoxButton.Click += new System.EventHandler(this.createTiffBoxButton_Click);
            // 
            // transTextBrowseButton
            // 
            this.transTextBrowseButton.Location = new System.Drawing.Point(171, 38);
            this.transTextBrowseButton.Name = "transTextBrowseButton";
            this.transTextBrowseButton.Size = new System.Drawing.Size(23, 23);
            this.transTextBrowseButton.TabIndex = 3;
            this.transTextBrowseButton.Text = "...";
            this.transTextBrowseButton.UseVisualStyleBackColor = true;
            this.transTextBrowseButton.Click += new System.EventHandler(this.transTextBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Transcription Text";
            // 
            // transTextBox
            // 
            this.transTextBox.Location = new System.Drawing.Point(7, 41);
            this.transTextBox.Name = "transTextBox";
            this.transTextBox.Size = new System.Drawing.Size(162, 20);
            this.transTextBox.TabIndex = 0;
            // 
            // fileBrowser
            // 
            this.fileBrowser.Filter = "Text Files|*.txt";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subTransBox);
            this.groupBox1.Controls.Add(this.subIngestBox);
            this.groupBox1.Controls.Add(this.delSubButton);
            this.groupBox1.Controls.Add(this.newSubButton);
            this.groupBox1.Controls.Add(this.substitutionsList);
            this.groupBox1.Location = new System.Drawing.Point(233, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 217);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unicode Substitutions";
            // 
            // subTransBox
            // 
            this.subTransBox.AutoSize = true;
            this.subTransBox.Location = new System.Drawing.Point(7, 41);
            this.subTransBox.Name = "subTransBox";
            this.subTransBox.Size = new System.Drawing.Size(184, 17);
            this.subTransBox.TabIndex = 7;
            this.subTransBox.Text = "Use with synthetic image creation";
            this.subTransBox.UseVisualStyleBackColor = true;
            // 
            // subIngestBox
            // 
            this.subIngestBox.AutoSize = true;
            this.subIngestBox.Location = new System.Drawing.Point(7, 19);
            this.subIngestBox.Name = "subIngestBox";
            this.subIngestBox.Size = new System.Drawing.Size(112, 17);
            this.subIngestBox.TabIndex = 6;
            this.subIngestBox.Text = "Use with ingestion";
            this.subIngestBox.UseVisualStyleBackColor = true;
            // 
            // delSubButton
            // 
            this.delSubButton.Enabled = false;
            this.delSubButton.Location = new System.Drawing.Point(88, 181);
            this.delSubButton.Name = "delSubButton";
            this.delSubButton.Size = new System.Drawing.Size(106, 23);
            this.delSubButton.TabIndex = 5;
            this.delSubButton.Text = "Delete Selected";
            this.delSubButton.UseVisualStyleBackColor = true;
            this.delSubButton.Click += new System.EventHandler(this.delSubButton_Click);
            // 
            // newSubButton
            // 
            this.newSubButton.Location = new System.Drawing.Point(7, 181);
            this.newSubButton.Name = "newSubButton";
            this.newSubButton.Size = new System.Drawing.Size(75, 23);
            this.newSubButton.TabIndex = 4;
            this.newSubButton.Text = "Create New";
            this.newSubButton.UseVisualStyleBackColor = true;
            this.newSubButton.Click += new System.EventHandler(this.newSubButton_Click);
            // 
            // substitutionsList
            // 
            this.substitutionsList.FormattingEnabled = true;
            this.substitutionsList.Location = new System.Drawing.Point(7, 64);
            this.substitutionsList.Name = "substitutionsList";
            this.substitutionsList.Size = new System.Drawing.Size(187, 108);
            this.substitutionsList.TabIndex = 0;
            this.substitutionsList.SelectedIndexChanged += new System.EventHandler(this.substitutionsList_SelectedIndexChanged);
            // 
            // trainTessButton
            // 
            this.trainTessButton.Location = new System.Drawing.Point(124, 78);
            this.trainTessButton.Name = "trainTessButton";
            this.trainTessButton.Size = new System.Drawing.Size(91, 23);
            this.trainTessButton.TabIndex = 20;
            this.trainTessButton.Text = "Train Tesseract";
            this.trainTessButton.UseVisualStyleBackColor = true;
            this.trainTessButton.Click += new System.EventHandler(this.trainTessButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseConnectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.importFontToolStripMenuItem,
            this.exportFontToolStripMenuItem,
            this.toolStripSeparator2,
            this.helpToolStripMenuItem2});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.settingsToolStripMenuItem.Text = "Menu";
            // 
            // databaseConnectionToolStripMenuItem
            // 
            this.databaseConnectionToolStripMenuItem.Name = "databaseConnectionToolStripMenuItem";
            this.databaseConnectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.databaseConnectionToolStripMenuItem.Text = "Settings";
            this.databaseConnectionToolStripMenuItem.Click += new System.EventHandler(this.databaseConnectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // importFontToolStripMenuItem
            // 
            this.importFontToolStripMenuItem.Name = "importFontToolStripMenuItem";
            this.importFontToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.importFontToolStripMenuItem.Text = "Import Font...";
            this.importFontToolStripMenuItem.Click += new System.EventHandler(this.importFontToolStripMenuItem_Click);
            // 
            // exportFontToolStripMenuItem
            // 
            this.exportFontToolStripMenuItem.Name = "exportFontToolStripMenuItem";
            this.exportFontToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportFontToolStripMenuItem.Text = "Export Font...";
            this.exportFontToolStripMenuItem.Click += new System.EventHandler(this.exportFontToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.helpToolStripMenuItem2.Text = "Help";
            this.helpToolStripMenuItem2.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // createLangButton
            // 
            this.createLangButton.Location = new System.Drawing.Point(14, 78);
            this.createLangButton.Name = "createLangButton";
            this.createLangButton.Size = new System.Drawing.Size(101, 23);
            this.createLangButton.TabIndex = 22;
            this.createLangButton.Text = "Create Language";
            this.createLangButton.UseVisualStyleBackColor = true;
            this.createLangButton.Click += new System.EventHandler(this.createLangButton_Click);
            // 
            // langBox
            // 
            this.langBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langBox.FormattingEnabled = true;
            this.langBox.Location = new System.Drawing.Point(12, 48);
            this.langBox.Name = "langBox";
            this.langBox.Size = new System.Drawing.Size(203, 21);
            this.langBox.TabIndex = 23;
            // 
            // copyFontButton
            // 
            this.copyFontButton.Location = new System.Drawing.Point(371, 75);
            this.copyFontButton.Name = "copyFontButton";
            this.copyFontButton.Size = new System.Drawing.Size(62, 24);
            this.copyFontButton.TabIndex = 24;
            this.copyFontButton.Text = "Copy";
            this.copyFontButton.UseVisualStyleBackColor = true;
            this.copyFontButton.Click += new System.EventHandler(this.copyFontButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 343);
            this.Controls.Add(this.copyFontButton);
            this.Controls.Add(this.langBox);
            this.Controls.Add(this.createLangButton);
            this.Controls.Add(this.trainTessButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.createFontButton);
            this.Controls.Add(this.editFontButton);
            this.Controls.Add(this.fontBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Franken+";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ingestGlyphsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fontBox;
        private System.Windows.Forms.Button editFontButton;
        private System.Windows.Forms.Button createFontButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tiffXMLBrowseButton;
        private System.Windows.Forms.TextBox tiffXMLInputBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button createTiffBoxButton;
        private System.Windows.Forms.Button transTextBrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox transTextBox;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delSubButton;
        private System.Windows.Forms.Button newSubButton;
        private System.Windows.Forms.ListBox substitutionsList;
        private System.Windows.Forms.CheckBox subTransBox;
        private System.Windows.Forms.CheckBox subIngestBox;
        private System.Windows.Forms.Button trainTessButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button createLangButton;
        private System.Windows.Forms.ComboBox langBox;
        private System.Windows.Forms.Button copyFontButton;
        private System.Windows.Forms.ToolStripMenuItem databaseConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
    }
}

