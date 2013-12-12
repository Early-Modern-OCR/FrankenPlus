namespace Franken_
{
    partial class NewFont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFont));
            this.label1 = new System.Windows.Forms.Label();
            this.fontNameBox = new System.Windows.Forms.TextBox();
            this.fontItalicBox = new System.Windows.Forms.CheckBox();
            this.fontBoldBox = new System.Windows.Forms.CheckBox();
            this.fontFixedBox = new System.Windows.Forms.CheckBox();
            this.fontFrakturBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.glyphBox = new System.Windows.Forms.ComboBox();
            this.fontSerifBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.xOffsetBox = new System.Windows.Forms.NumericUpDown();
            this.yOffsetBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fontLineHeightBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.remAllButton = new System.Windows.Forms.Button();
            this.deleteFont = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.prevPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.reclassifyButton = new System.Windows.Forms.Button();
            this.delGlyphButton = new System.Windows.Forms.Button();
            this.clipboardButton = new System.Windows.Forms.Button();
            this.delRemovedButton = new System.Windows.Forms.Button();
            this.allPagesBox = new System.Windows.Forms.CheckBox();
            this.imageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageContextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.imageContextShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.imageContextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySizeBar = new System.Windows.Forms.TrackBar();
            this.fontDirGroupBox = new System.Windows.Forms.GroupBox();
            this.openTIFBoxDir = new System.Windows.Forms.Button();
            this.openGlyphDir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xOffsetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffsetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontLineHeightBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.imageContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displaySizeBar)).BeginInit();
            this.fontDirGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font Name";
            // 
            // fontNameBox
            // 
            this.fontNameBox.Location = new System.Drawing.Point(13, 30);
            this.fontNameBox.Name = "fontNameBox";
            this.fontNameBox.Size = new System.Drawing.Size(198, 20);
            this.fontNameBox.TabIndex = 1;
            // 
            // fontItalicBox
            // 
            this.fontItalicBox.AutoSize = true;
            this.fontItalicBox.Location = new System.Drawing.Point(16, 57);
            this.fontItalicBox.Name = "fontItalicBox";
            this.fontItalicBox.Size = new System.Drawing.Size(48, 17);
            this.fontItalicBox.TabIndex = 2;
            this.fontItalicBox.Text = "Italic";
            this.fontItalicBox.UseVisualStyleBackColor = true;
            // 
            // fontBoldBox
            // 
            this.fontBoldBox.AutoSize = true;
            this.fontBoldBox.Location = new System.Drawing.Point(70, 57);
            this.fontBoldBox.Name = "fontBoldBox";
            this.fontBoldBox.Size = new System.Drawing.Size(47, 17);
            this.fontBoldBox.TabIndex = 3;
            this.fontBoldBox.Text = "Bold";
            this.fontBoldBox.UseVisualStyleBackColor = true;
            // 
            // fontFixedBox
            // 
            this.fontFixedBox.AutoSize = true;
            this.fontFixedBox.Location = new System.Drawing.Point(123, 57);
            this.fontFixedBox.Name = "fontFixedBox";
            this.fontFixedBox.Size = new System.Drawing.Size(51, 17);
            this.fontFixedBox.TabIndex = 4;
            this.fontFixedBox.Text = "Fixed";
            this.fontFixedBox.UseVisualStyleBackColor = true;
            // 
            // fontFrakturBox
            // 
            this.fontFrakturBox.AutoSize = true;
            this.fontFrakturBox.Location = new System.Drawing.Point(233, 57);
            this.fontFrakturBox.Name = "fontFrakturBox";
            this.fontFrakturBox.Size = new System.Drawing.Size(59, 17);
            this.fontFrakturBox.TabIndex = 5;
            this.fontFrakturBox.Text = "Fraktur";
            this.fontFrakturBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Glyphs";
            // 
            // glyphBox
            // 
            this.glyphBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.glyphBox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.glyphBox.FormattingEnabled = true;
            this.glyphBox.Location = new System.Drawing.Point(12, 109);
            this.glyphBox.Name = "glyphBox";
            this.glyphBox.Size = new System.Drawing.Size(173, 26);
            this.glyphBox.TabIndex = 7;
            this.glyphBox.SelectedIndexChanged += new System.EventHandler(this.glyphBox_SelectedIndexChanged);
            // 
            // fontSerifBox
            // 
            this.fontSerifBox.AutoSize = true;
            this.fontSerifBox.Location = new System.Drawing.Point(180, 57);
            this.fontSerifBox.Name = "fontSerifBox";
            this.fontSerifBox.Size = new System.Drawing.Size(47, 17);
            this.fontSerifBox.TabIndex = 9;
            this.fontSerifBox.Text = "Serif";
            this.fontSerifBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(521, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 28);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save Font";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.AutoScroll = true;
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imagePanel.Location = new System.Drawing.Point(12, 141);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(676, 420);
            this.imagePanel.TabIndex = 12;
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(6, 40);
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(73, 20);
            this.xOffsetBox.TabIndex = 14;
            this.xOffsetBox.ValueChanged += new System.EventHandler(this.xOffsetBox_ValueChanged);
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(85, 40);
            this.yOffsetBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(73, 20);
            this.yOffsetBox.TabIndex = 15;
            this.yOffsetBox.ValueChanged += new System.EventHandler(this.yOffsetBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "X Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Y Offset";
            // 
            // fontLineHeightBox
            // 
            this.fontLineHeightBox.Location = new System.Drawing.Point(219, 30);
            this.fontLineHeightBox.Name = "fontLineHeightBox";
            this.fontLineHeightBox.Size = new System.Drawing.Size(73, 20);
            this.fontLineHeightBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Line Height";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xOffsetBox);
            this.groupBox1.Controls.Add(this.yOffsetBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(520, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 72);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Glyph Offsets";
            // 
            // remAllButton
            // 
            this.remAllButton.Location = new System.Drawing.Point(12, 567);
            this.remAllButton.Name = "remAllButton";
            this.remAllButton.Size = new System.Drawing.Size(85, 23);
            this.remAllButton.TabIndex = 21;
            this.remAllButton.Text = "Remove All";
            this.remAllButton.UseVisualStyleBackColor = true;
            this.remAllButton.Click += new System.EventHandler(this.remAllButton_Click);
            // 
            // deleteFont
            // 
            this.deleteFont.Location = new System.Drawing.Point(602, 13);
            this.deleteFont.Name = "deleteFont";
            this.deleteFont.Size = new System.Drawing.Size(86, 28);
            this.deleteFont.TabIndex = 22;
            this.deleteFont.Text = "Delete Font";
            this.deleteFont.UseVisualStyleBackColor = true;
            this.deleteFont.Click += new System.EventHandler(this.deleteFont_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 574);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Display Size";
            // 
            // prevPageButton
            // 
            this.prevPageButton.Location = new System.Drawing.Point(530, 569);
            this.prevPageButton.Name = "prevPageButton";
            this.prevPageButton.Size = new System.Drawing.Size(75, 23);
            this.prevPageButton.TabIndex = 25;
            this.prevPageButton.Text = "Prev Page";
            this.prevPageButton.UseVisualStyleBackColor = true;
            this.prevPageButton.Click += new System.EventHandler(this.prevPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(611, 569);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(75, 23);
            this.nextPageButton.TabIndex = 26;
            this.nextPageButton.Text = "Next Page";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // reclassifyButton
            // 
            this.reclassifyButton.Location = new System.Drawing.Point(301, 108);
            this.reclassifyButton.Name = "reclassifyButton";
            this.reclassifyButton.Size = new System.Drawing.Size(104, 28);
            this.reclassifyButton.TabIndex = 27;
            this.reclassifyButton.Text = "Reclassify Glyph";
            this.reclassifyButton.UseVisualStyleBackColor = true;
            this.reclassifyButton.Click += new System.EventHandler(this.reclassifyButton_Click);
            // 
            // delGlyphButton
            // 
            this.delGlyphButton.Location = new System.Drawing.Point(410, 108);
            this.delGlyphButton.Name = "delGlyphButton";
            this.delGlyphButton.Size = new System.Drawing.Size(104, 28);
            this.delGlyphButton.TabIndex = 28;
            this.delGlyphButton.Text = "Delete Glyph";
            this.delGlyphButton.UseVisualStyleBackColor = true;
            this.delGlyphButton.Click += new System.EventHandler(this.delGlyphButton_Click);
            // 
            // clipboardButton
            // 
            this.clipboardButton.Location = new System.Drawing.Point(191, 108);
            this.clipboardButton.Name = "clipboardButton";
            this.clipboardButton.Size = new System.Drawing.Size(104, 28);
            this.clipboardButton.TabIndex = 29;
            this.clipboardButton.Text = "Copy to Clipboard";
            this.clipboardButton.UseVisualStyleBackColor = true;
            this.clipboardButton.Click += new System.EventHandler(this.clipboardButton_Click);
            // 
            // delRemovedButton
            // 
            this.delRemovedButton.Location = new System.Drawing.Point(103, 567);
            this.delRemovedButton.Name = "delRemovedButton";
            this.delRemovedButton.Size = new System.Drawing.Size(108, 23);
            this.delRemovedButton.TabIndex = 30;
            this.delRemovedButton.Text = "Delete Removed";
            this.delRemovedButton.UseVisualStyleBackColor = true;
            this.delRemovedButton.Click += new System.EventHandler(this.delRemovedButton_Click);
            // 
            // allPagesBox
            // 
            this.allPagesBox.AutoSize = true;
            this.allPagesBox.Location = new System.Drawing.Point(219, 571);
            this.allPagesBox.Name = "allPagesBox";
            this.allPagesBox.Size = new System.Drawing.Size(103, 17);
            this.allPagesBox.TabIndex = 31;
            this.allPagesBox.Text = "Across all pages";
            this.allPagesBox.UseVisualStyleBackColor = true;
            // 
            // imageContextMenu
            // 
            this.imageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageContextEdit,
            this.imageContextShowInfo,
            this.imageContextDelete});
            this.imageContextMenu.Name = "imageContextMenu";
            this.imageContextMenu.Size = new System.Drawing.Size(131, 70);
            // 
            // imageContextEdit
            // 
            this.imageContextEdit.Name = "imageContextEdit";
            this.imageContextEdit.Size = new System.Drawing.Size(130, 22);
            this.imageContextEdit.Text = "Edit Image";
            // 
            // imageContextShowInfo
            // 
            this.imageContextShowInfo.Name = "imageContextShowInfo";
            this.imageContextShowInfo.Size = new System.Drawing.Size(130, 22);
            this.imageContextShowInfo.Text = "Show Info";
            // 
            // imageContextDelete
            // 
            this.imageContextDelete.Name = "imageContextDelete";
            this.imageContextDelete.Size = new System.Drawing.Size(130, 22);
            this.imageContextDelete.Text = "Delete";
            // 
            // displaySizeBar
            // 
            this.displaySizeBar.LargeChange = 100;
            this.displaySizeBar.Location = new System.Drawing.Point(410, 567);
            this.displaySizeBar.Maximum = 500;
            this.displaySizeBar.Minimum = 50;
            this.displaySizeBar.Name = "displaySizeBar";
            this.displaySizeBar.Size = new System.Drawing.Size(104, 45);
            this.displaySizeBar.SmallChange = 50;
            this.displaySizeBar.TabIndex = 32;
            this.displaySizeBar.Value = 50;
            this.displaySizeBar.Scroll += new System.EventHandler(this.displaySizeBar_Scroll);
            // 
            // fontDirGroupBox
            // 
            this.fontDirGroupBox.Controls.Add(this.openTIFBoxDir);
            this.fontDirGroupBox.Controls.Add(this.openGlyphDir);
            this.fontDirGroupBox.Location = new System.Drawing.Point(298, 12);
            this.fontDirGroupBox.Name = "fontDirGroupBox";
            this.fontDirGroupBox.Size = new System.Drawing.Size(118, 90);
            this.fontDirGroupBox.TabIndex = 33;
            this.fontDirGroupBox.TabStop = false;
            this.fontDirGroupBox.Text = "Open Directories";
            // 
            // openTIFBoxDir
            // 
            this.openTIFBoxDir.Location = new System.Drawing.Point(6, 53);
            this.openTIFBoxDir.Name = "openTIFBoxDir";
            this.openTIFBoxDir.Size = new System.Drawing.Size(104, 28);
            this.openTIFBoxDir.TabIndex = 31;
            this.openTIFBoxDir.Text = "TIF/Box Pairs";
            this.openTIFBoxDir.UseVisualStyleBackColor = true;
            this.openTIFBoxDir.Click += new System.EventHandler(this.openTIFBoxDir_Click);
            // 
            // openGlyphDir
            // 
            this.openGlyphDir.Location = new System.Drawing.Point(6, 19);
            this.openGlyphDir.Name = "openGlyphDir";
            this.openGlyphDir.Size = new System.Drawing.Size(104, 28);
            this.openGlyphDir.TabIndex = 30;
            this.openGlyphDir.Text = "Extracted Glyphs";
            this.openGlyphDir.UseVisualStyleBackColor = true;
            this.openGlyphDir.Click += new System.EventHandler(this.openGlyphDir_Click);
            // 
            // NewFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 603);
            this.Controls.Add(this.fontDirGroupBox);
            this.Controls.Add(this.displaySizeBar);
            this.Controls.Add(this.allPagesBox);
            this.Controls.Add(this.delRemovedButton);
            this.Controls.Add(this.clipboardButton);
            this.Controls.Add(this.delGlyphButton);
            this.Controls.Add(this.reclassifyButton);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.prevPageButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deleteFont);
            this.Controls.Add(this.remAllButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fontLineHeightBox);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fontSerifBox);
            this.Controls.Add(this.glyphBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fontFrakturBox);
            this.Controls.Add(this.fontFixedBox);
            this.Controls.Add(this.fontBoldBox);
            this.Controls.Add(this.fontItalicBox);
            this.Controls.Add(this.fontNameBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewFont";
            this.Text = "Font";
            ((System.ComponentModel.ISupportInitialize)(this.xOffsetBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yOffsetBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontLineHeightBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.imageContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.displaySizeBar)).EndInit();
            this.fontDirGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fontNameBox;
        private System.Windows.Forms.CheckBox fontItalicBox;
        private System.Windows.Forms.CheckBox fontBoldBox;
        private System.Windows.Forms.CheckBox fontFixedBox;
        private System.Windows.Forms.CheckBox fontFrakturBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox glyphBox;
        private System.Windows.Forms.CheckBox fontSerifBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FlowLayoutPanel imagePanel;
        private System.Windows.Forms.NumericUpDown xOffsetBox;
        private System.Windows.Forms.NumericUpDown yOffsetBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown fontLineHeightBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button remAllButton;
        private System.Windows.Forms.Button deleteFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button prevPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button reclassifyButton;
        private System.Windows.Forms.Button delGlyphButton;
        private System.Windows.Forms.Button clipboardButton;
        private System.Windows.Forms.Button delRemovedButton;
        private System.Windows.Forms.CheckBox allPagesBox;
        private System.Windows.Forms.ContextMenuStrip imageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem imageContextEdit;
        private System.Windows.Forms.ToolStripMenuItem imageContextShowInfo;
        private System.Windows.Forms.ToolStripMenuItem imageContextDelete;
        private System.Windows.Forms.TrackBar displaySizeBar;
        private System.Windows.Forms.GroupBox fontDirGroupBox;
        private System.Windows.Forms.Button openTIFBoxDir;
        private System.Windows.Forms.Button openGlyphDir;
    }
}