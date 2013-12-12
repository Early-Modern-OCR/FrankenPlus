namespace Franken_
{
    partial class Reclassify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reclassify));
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.comboButton = new System.Windows.Forms.RadioButton();
            this.boxButton = new System.Windows.Forms.RadioButton();
            this.boxLabel2 = new System.Windows.Forms.Label();
            this.boxCharLabel = new System.Windows.Forms.Label();
            this.boxLabel1 = new System.Windows.Forms.Label();
            this.boxBox = new System.Windows.Forms.TextBox();
            this.boxPanel = new System.Windows.Forms.Panel();
            this.comboPanel = new System.Windows.Forms.Panel();
            this.comboLabel1 = new System.Windows.Forms.Label();
            this.comboCharLabel = new System.Windows.Forms.Label();
            this.comboLabel2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modeCopyButton = new System.Windows.Forms.RadioButton();
            this.modeReclassButton = new System.Windows.Forms.RadioButton();
            this.boxPanel.SuspendLayout();
            this.comboPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(60, 34);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(130, 27);
            this.comboBox.TabIndex = 8;
            // 
            // comboButton
            // 
            this.comboButton.AutoSize = true;
            this.comboButton.Checked = true;
            this.comboButton.Location = new System.Drawing.Point(13, 122);
            this.comboButton.Name = "comboButton";
            this.comboButton.Size = new System.Drawing.Size(14, 13);
            this.comboButton.TabIndex = 9;
            this.comboButton.TabStop = true;
            this.comboButton.UseVisualStyleBackColor = true;
            this.comboButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // boxButton
            // 
            this.boxButton.AutoSize = true;
            this.boxButton.Location = new System.Drawing.Point(13, 194);
            this.boxButton.Name = "boxButton";
            this.boxButton.Size = new System.Drawing.Size(14, 13);
            this.boxButton.TabIndex = 14;
            this.boxButton.UseVisualStyleBackColor = true;
            this.boxButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // boxLabel2
            // 
            this.boxLabel2.AutoSize = true;
            this.boxLabel2.Location = new System.Drawing.Point(36, 40);
            this.boxLabel2.Name = "boxLabel2";
            this.boxLabel2.Size = new System.Drawing.Size(18, 13);
            this.boxLabel2.TabIndex = 12;
            this.boxLabel2.Text = "as";
            // 
            // boxCharLabel
            // 
            this.boxCharLabel.AutoSize = true;
            this.boxCharLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCharLabel.Location = new System.Drawing.Point(8, 33);
            this.boxCharLabel.Name = "boxCharLabel";
            this.boxCharLabel.Size = new System.Drawing.Size(22, 24);
            this.boxCharLabel.TabIndex = 11;
            this.boxCharLabel.Text = "T";
            // 
            // boxLabel1
            // 
            this.boxLabel1.AutoSize = true;
            this.boxLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxLabel1.Location = new System.Drawing.Point(9, 11);
            this.boxLabel1.Name = "boxLabel1";
            this.boxLabel1.Size = new System.Drawing.Size(181, 13);
            this.boxLabel1.TabIndex = 10;
            this.boxLabel1.Text = "Reclassify all images associated with";
            // 
            // boxBox
            // 
            this.boxBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxBox.Location = new System.Drawing.Point(61, 33);
            this.boxBox.Name = "boxBox";
            this.boxBox.Size = new System.Drawing.Size(129, 27);
            this.boxBox.TabIndex = 15;
            // 
            // boxPanel
            // 
            this.boxPanel.Controls.Add(this.boxBox);
            this.boxPanel.Controls.Add(this.boxLabel1);
            this.boxPanel.Controls.Add(this.boxCharLabel);
            this.boxPanel.Controls.Add(this.boxLabel2);
            this.boxPanel.Enabled = false;
            this.boxPanel.Location = new System.Drawing.Point(41, 169);
            this.boxPanel.Name = "boxPanel";
            this.boxPanel.Size = new System.Drawing.Size(202, 69);
            this.boxPanel.TabIndex = 16;
            // 
            // comboPanel
            // 
            this.comboPanel.Controls.Add(this.comboLabel1);
            this.comboPanel.Controls.Add(this.comboCharLabel);
            this.comboPanel.Controls.Add(this.comboLabel2);
            this.comboPanel.Controls.Add(this.comboBox);
            this.comboPanel.Location = new System.Drawing.Point(41, 94);
            this.comboPanel.Name = "comboPanel";
            this.comboPanel.Size = new System.Drawing.Size(202, 69);
            this.comboPanel.TabIndex = 17;
            // 
            // comboLabel1
            // 
            this.comboLabel1.AutoSize = true;
            this.comboLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLabel1.Location = new System.Drawing.Point(9, 11);
            this.comboLabel1.Name = "comboLabel1";
            this.comboLabel1.Size = new System.Drawing.Size(181, 13);
            this.comboLabel1.TabIndex = 10;
            this.comboLabel1.Text = "Reclassify all images associated with";
            // 
            // comboCharLabel
            // 
            this.comboCharLabel.AutoSize = true;
            this.comboCharLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCharLabel.Location = new System.Drawing.Point(8, 33);
            this.comboCharLabel.Name = "comboCharLabel";
            this.comboCharLabel.Size = new System.Drawing.Size(22, 24);
            this.comboCharLabel.TabIndex = 11;
            this.comboCharLabel.Text = "T";
            // 
            // comboLabel2
            // 
            this.comboLabel2.AutoSize = true;
            this.comboLabel2.Location = new System.Drawing.Point(36, 40);
            this.comboLabel2.Name = "comboLabel2";
            this.comboLabel2.Size = new System.Drawing.Size(18, 13);
            this.comboLabel2.TabIndex = 12;
            this.comboLabel2.Text = "as";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(41, 244);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(123, 244);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modeCopyButton);
            this.groupBox1.Controls.Add(this.modeReclassButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 75);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // modeCopyButton
            // 
            this.modeCopyButton.AutoSize = true;
            this.modeCopyButton.Location = new System.Drawing.Point(6, 44);
            this.modeCopyButton.Name = "modeCopyButton";
            this.modeCopyButton.Size = new System.Drawing.Size(175, 17);
            this.modeCopyButton.TabIndex = 22;
            this.modeCopyButton.Text = "Copy (copy images, keep glyph)";
            this.modeCopyButton.UseVisualStyleBackColor = true;
            this.modeCopyButton.CheckedChanged += new System.EventHandler(this.modeReclassButton_CheckedChanged);
            // 
            // modeReclassButton
            // 
            this.modeReclassButton.AutoSize = true;
            this.modeReclassButton.Checked = true;
            this.modeReclassButton.Location = new System.Drawing.Point(6, 19);
            this.modeReclassButton.Name = "modeReclassButton";
            this.modeReclassButton.Size = new System.Drawing.Size(207, 17);
            this.modeReclassButton.TabIndex = 21;
            this.modeReclassButton.TabStop = true;
            this.modeReclassButton.Text = "Reclassify (moves image, delete glyph)";
            this.modeReclassButton.UseVisualStyleBackColor = true;
            this.modeReclassButton.CheckedChanged += new System.EventHandler(this.modeReclassButton_CheckedChanged);
            // 
            // Reclassify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 277);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.comboPanel);
            this.Controls.Add(this.boxButton);
            this.Controls.Add(this.boxPanel);
            this.Controls.Add(this.comboButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reclassify";
            this.boxPanel.ResumeLayout(false);
            this.boxPanel.PerformLayout();
            this.comboPanel.ResumeLayout(false);
            this.comboPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.RadioButton comboButton;
        private System.Windows.Forms.RadioButton boxButton;
        private System.Windows.Forms.Label boxLabel2;
        private System.Windows.Forms.Label boxCharLabel;
        private System.Windows.Forms.Label boxLabel1;
        private System.Windows.Forms.TextBox boxBox;
        private System.Windows.Forms.Panel boxPanel;
        private System.Windows.Forms.Panel comboPanel;
        private System.Windows.Forms.Label comboLabel1;
        private System.Windows.Forms.Label comboCharLabel;
        private System.Windows.Forms.Label comboLabel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton modeCopyButton;
        private System.Windows.Forms.RadioButton modeReclassButton;

    }
}