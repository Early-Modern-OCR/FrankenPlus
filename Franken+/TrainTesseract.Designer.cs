namespace Franken_
{
    partial class TrainTesseract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainTesseract));
            this.fontList = new System.Windows.Forms.CheckedListBox();
            this.langNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wordFreqPathBox = new System.Windows.Forms.TextBox();
            this.wordFreqBrowseButton = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.makeLibraryButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.wordDictBrowseButton = new System.Windows.Forms.Button();
            this.wordDictPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.doTiffBoxBox = new System.Windows.Forms.CheckBox();
            this.doCreateTRFilesBox = new System.Windows.Forms.CheckBox();
            this.doTrainingBox = new System.Windows.Forms.CheckBox();
            this.doCombineBox = new System.Windows.Forms.CheckBox();
            this.doClearTrainingBox = new System.Windows.Forms.CheckBox();
            this.doFontPropertiesFile = new System.Windows.Forms.CheckBox();
            this.doProcessWordListsBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.testGoButton = new System.Windows.Forms.Button();
            this.testFolderBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.testFolderBox = new System.Windows.Forms.TextBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.unicharUnambigsBrowseButton = new System.Windows.Forms.Button();
            this.unicharUnambigsPathBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontList
            // 
            this.fontList.FormattingEnabled = true;
            this.fontList.Location = new System.Drawing.Point(6, 19);
            this.fontList.Name = "fontList";
            this.fontList.Size = new System.Drawing.Size(188, 169);
            this.fontList.TabIndex = 0;
            // 
            // langNameLabel
            // 
            this.langNameLabel.AutoSize = true;
            this.langNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langNameLabel.Location = new System.Drawing.Point(12, 13);
            this.langNameLabel.Name = "langNameLabel";
            this.langNameLabel.Size = new System.Drawing.Size(126, 17);
            this.langNameLabel.TabIndex = 1;
            this.langNameLabel.Text = "Language Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Frequent Words List";
            // 
            // wordFreqPathBox
            // 
            this.wordFreqPathBox.Location = new System.Drawing.Point(6, 75);
            this.wordFreqPathBox.Name = "wordFreqPathBox";
            this.wordFreqPathBox.Size = new System.Drawing.Size(149, 20);
            this.wordFreqPathBox.TabIndex = 3;
            // 
            // wordFreqBrowseButton
            // 
            this.wordFreqBrowseButton.Location = new System.Drawing.Point(161, 73);
            this.wordFreqBrowseButton.Name = "wordFreqBrowseButton";
            this.wordFreqBrowseButton.Size = new System.Drawing.Size(33, 22);
            this.wordFreqBrowseButton.TabIndex = 4;
            this.wordFreqBrowseButton.Text = "...";
            this.wordFreqBrowseButton.UseVisualStyleBackColor = true;
            this.wordFreqBrowseButton.Click += new System.EventHandler(this.wordFreqBrowseButton_Click);
            // 
            // makeLibraryButton
            // 
            this.makeLibraryButton.Location = new System.Drawing.Point(12, 249);
            this.makeLibraryButton.Name = "makeLibraryButton";
            this.makeLibraryButton.Size = new System.Drawing.Size(613, 28);
            this.makeLibraryButton.TabIndex = 14;
            this.makeLibraryButton.Text = "Make Library";
            this.makeLibraryButton.UseVisualStyleBackColor = true;
            this.makeLibraryButton.Click += new System.EventHandler(this.makeLibraryButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // wordDictBrowseButton
            // 
            this.wordDictBrowseButton.Location = new System.Drawing.Point(161, 112);
            this.wordDictBrowseButton.Name = "wordDictBrowseButton";
            this.wordDictBrowseButton.Size = new System.Drawing.Size(33, 22);
            this.wordDictBrowseButton.TabIndex = 6;
            this.wordDictBrowseButton.Text = "...";
            this.wordDictBrowseButton.UseVisualStyleBackColor = true;
            this.wordDictBrowseButton.Click += new System.EventHandler(this.wordDictBrowseButton_Click);
            // 
            // wordDictPathBox
            // 
            this.wordDictPathBox.Location = new System.Drawing.Point(6, 114);
            this.wordDictPathBox.Name = "wordDictPathBox";
            this.wordDictPathBox.Size = new System.Drawing.Size(149, 20);
            this.wordDictPathBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Other Words List";
            // 
            // doTiffBoxBox
            // 
            this.doTiffBoxBox.AutoSize = true;
            this.doTiffBoxBox.Checked = true;
            this.doTiffBoxBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doTiffBoxBox.Location = new System.Drawing.Point(7, 66);
            this.doTiffBoxBox.Name = "doTiffBoxBox";
            this.doTiffBoxBox.Size = new System.Drawing.Size(111, 17);
            this.doTiffBoxBox.TabIndex = 9;
            this.doTiffBoxBox.Text = "Copy tiff/box pairs";
            this.doTiffBoxBox.UseVisualStyleBackColor = true;
            // 
            // doCreateTRFilesBox
            // 
            this.doCreateTRFilesBox.AutoSize = true;
            this.doCreateTRFilesBox.Checked = true;
            this.doCreateTRFilesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doCreateTRFilesBox.Location = new System.Drawing.Point(7, 89);
            this.doCreateTRFilesBox.Name = "doCreateTRFilesBox";
            this.doCreateTRFilesBox.Size = new System.Drawing.Size(133, 17);
            this.doCreateTRFilesBox.TabIndex = 10;
            this.doCreateTRFilesBox.Text = "Create training (.tr) files";
            this.doCreateTRFilesBox.UseVisualStyleBackColor = true;
            // 
            // doTrainingBox
            // 
            this.doTrainingBox.AutoSize = true;
            this.doTrainingBox.Checked = true;
            this.doTrainingBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doTrainingBox.Location = new System.Drawing.Point(7, 112);
            this.doTrainingBox.Name = "doTrainingBox";
            this.doTrainingBox.Size = new System.Drawing.Size(99, 17);
            this.doTrainingBox.TabIndex = 11;
            this.doTrainingBox.Text = "Perform training";
            this.doTrainingBox.UseVisualStyleBackColor = true;
            // 
            // doCombineBox
            // 
            this.doCombineBox.AutoSize = true;
            this.doCombineBox.Checked = true;
            this.doCombineBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doCombineBox.Location = new System.Drawing.Point(6, 158);
            this.doCombineBox.Name = "doCombineBox";
            this.doCombineBox.Size = new System.Drawing.Size(110, 17);
            this.doCombineBox.TabIndex = 13;
            this.doCombineBox.Text = "Combine tessdata";
            this.doCombineBox.UseVisualStyleBackColor = true;
            // 
            // doClearTrainingBox
            // 
            this.doClearTrainingBox.AutoSize = true;
            this.doClearTrainingBox.Checked = true;
            this.doClearTrainingBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doClearTrainingBox.Location = new System.Drawing.Point(6, 20);
            this.doClearTrainingBox.Name = "doClearTrainingBox";
            this.doClearTrainingBox.Size = new System.Drawing.Size(104, 17);
            this.doClearTrainingBox.TabIndex = 7;
            this.doClearTrainingBox.Text = "Clear old training";
            this.doClearTrainingBox.UseVisualStyleBackColor = true;
            // 
            // doFontPropertiesFile
            // 
            this.doFontPropertiesFile.AutoSize = true;
            this.doFontPropertiesFile.Checked = true;
            this.doFontPropertiesFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doFontPropertiesFile.Location = new System.Drawing.Point(6, 43);
            this.doFontPropertiesFile.Name = "doFontPropertiesFile";
            this.doFontPropertiesFile.Size = new System.Drawing.Size(143, 17);
            this.doFontPropertiesFile.TabIndex = 8;
            this.doFontPropertiesFile.Text = "Create font properties file";
            this.doFontPropertiesFile.UseVisualStyleBackColor = true;
            // 
            // doProcessWordListsBox
            // 
            this.doProcessWordListsBox.AutoSize = true;
            this.doProcessWordListsBox.Checked = true;
            this.doProcessWordListsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doProcessWordListsBox.Location = new System.Drawing.Point(6, 135);
            this.doProcessWordListsBox.Name = "doProcessWordListsBox";
            this.doProcessWordListsBox.Size = new System.Drawing.Size(110, 17);
            this.doProcessWordListsBox.TabIndex = 12;
            this.doProcessWordListsBox.Text = "Process word lists";
            this.doProcessWordListsBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.testGoButton);
            this.groupBox1.Controls.Add(this.testFolderBrowseButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.testFolderBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 102);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Library";
            // 
            // testGoButton
            // 
            this.testGoButton.Location = new System.Drawing.Point(7, 62);
            this.testGoButton.Name = "testGoButton";
            this.testGoButton.Size = new System.Drawing.Size(75, 23);
            this.testGoButton.TabIndex = 17;
            this.testGoButton.Text = "Go";
            this.testGoButton.UseVisualStyleBackColor = true;
            this.testGoButton.Click += new System.EventHandler(this.testGoButton_Click);
            // 
            // testFolderBrowseButton
            // 
            this.testFolderBrowseButton.Location = new System.Drawing.Point(154, 38);
            this.testFolderBrowseButton.Name = "testFolderBrowseButton";
            this.testFolderBrowseButton.Size = new System.Drawing.Size(33, 22);
            this.testFolderBrowseButton.TabIndex = 16;
            this.testFolderBrowseButton.Text = "...";
            this.testFolderBrowseButton.UseVisualStyleBackColor = true;
            this.testFolderBrowseButton.Click += new System.EventHandler(this.testFolderBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Test OCR on this folder of .tifs:";
            // 
            // testFolderBox
            // 
            this.testFolderBox.Location = new System.Drawing.Point(6, 39);
            this.testFolderBox.Name = "testFolderBox";
            this.testFolderBox.Size = new System.Drawing.Size(142, 20);
            this.testFolderBox.TabIndex = 15;
            // 
            // unicharUnambigsBrowseButton
            // 
            this.unicharUnambigsBrowseButton.Location = new System.Drawing.Point(161, 34);
            this.unicharUnambigsBrowseButton.Name = "unicharUnambigsBrowseButton";
            this.unicharUnambigsBrowseButton.Size = new System.Drawing.Size(33, 22);
            this.unicharUnambigsBrowseButton.TabIndex = 2;
            this.unicharUnambigsBrowseButton.Text = "...";
            this.unicharUnambigsBrowseButton.UseVisualStyleBackColor = true;
            this.unicharUnambigsBrowseButton.Click += new System.EventHandler(this.unicharUnambigsBrowseButton_Click);
            // 
            // unicharUnambigsPathBox
            // 
            this.unicharUnambigsPathBox.Location = new System.Drawing.Point(6, 36);
            this.unicharUnambigsPathBox.Name = "unicharUnambigsPathBox";
            this.unicharUnambigsPathBox.Size = new System.Drawing.Size(149, 20);
            this.unicharUnambigsPathBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Unicharambigs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.doClearTrainingBox);
            this.groupBox2.Controls.Add(this.doTiffBoxBox);
            this.groupBox2.Controls.Add(this.doCreateTRFilesBox);
            this.groupBox2.Controls.Add(this.doTrainingBox);
            this.groupBox2.Controls.Add(this.doCombineBox);
            this.groupBox2.Controls.Add(this.doProcessWordListsBox);
            this.groupBox2.Controls.Add(this.doFontPropertiesFile);
            this.groupBox2.Location = new System.Drawing.Point(424, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 200);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training Steps";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fontList);
            this.groupBox3.Location = new System.Drawing.Point(12, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 200);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fonts to Include";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.wordFreqPathBox);
            this.groupBox4.Controls.Add(this.unicharUnambigsBrowseButton);
            this.groupBox4.Controls.Add(this.wordFreqBrowseButton);
            this.groupBox4.Controls.Add(this.unicharUnambigsPathBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.wordDictPathBox);
            this.groupBox4.Controls.Add(this.wordDictBrowseButton);
            this.groupBox4.Location = new System.Drawing.Point(218, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 200);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Files to Include";
            // 
            // TrainTesseract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 398);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.makeLibraryButton);
            this.Controls.Add(this.langNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainTesseract";
            this.Text = "Franken+";
            this.Load += new System.EventHandler(this.TrainTesseract_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox fontList;
        private System.Windows.Forms.Label langNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wordFreqPathBox;
        private System.Windows.Forms.Button wordFreqBrowseButton;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.Button makeLibraryButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button wordDictBrowseButton;
        private System.Windows.Forms.TextBox wordDictPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox doTiffBoxBox;
        private System.Windows.Forms.CheckBox doCreateTRFilesBox;
        private System.Windows.Forms.CheckBox doTrainingBox;
        private System.Windows.Forms.CheckBox doCombineBox;
        private System.Windows.Forms.CheckBox doClearTrainingBox;
        private System.Windows.Forms.CheckBox doFontPropertiesFile;
        private System.Windows.Forms.CheckBox doProcessWordListsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button testGoButton;
        private System.Windows.Forms.Button testFolderBrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox testFolderBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button unicharUnambigsBrowseButton;
        private System.Windows.Forms.TextBox unicharUnambigsPathBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}