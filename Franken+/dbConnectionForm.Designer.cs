namespace Franken_
{
    partial class dbConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbConnectionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dbHostBox = new System.Windows.Forms.TextBox();
            this.dbDatabaseBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbUserBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbPasswordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbSaveButton = new System.Windows.Forms.Button();
            this.dbCancelButton = new System.Windows.Forms.Button();
            this.dbTestButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dbResetButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dbPortBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tessPathBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // dbHostBox
            // 
            this.dbHostBox.Location = new System.Drawing.Point(6, 33);
            this.dbHostBox.Name = "dbHostBox";
            this.dbHostBox.Size = new System.Drawing.Size(198, 20);
            this.dbHostBox.TabIndex = 1;
            // 
            // dbDatabaseBox
            // 
            this.dbDatabaseBox.Location = new System.Drawing.Point(5, 115);
            this.dbDatabaseBox.Name = "dbDatabaseBox";
            this.dbDatabaseBox.Size = new System.Drawing.Size(199, 20);
            this.dbDatabaseBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database";
            // 
            // dbUserBox
            // 
            this.dbUserBox.Location = new System.Drawing.Point(5, 164);
            this.dbUserBox.Name = "dbUserBox";
            this.dbUserBox.Size = new System.Drawing.Size(199, 20);
            this.dbUserBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User";
            // 
            // dbPasswordBox
            // 
            this.dbPasswordBox.Location = new System.Drawing.Point(5, 217);
            this.dbPasswordBox.Name = "dbPasswordBox";
            this.dbPasswordBox.Size = new System.Drawing.Size(199, 20);
            this.dbPasswordBox.TabIndex = 5;
            this.dbPasswordBox.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // dbSaveButton
            // 
            this.dbSaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dbSaveButton.Location = new System.Drawing.Point(10, 352);
            this.dbSaveButton.Name = "dbSaveButton";
            this.dbSaveButton.Size = new System.Drawing.Size(94, 23);
            this.dbSaveButton.TabIndex = 7;
            this.dbSaveButton.Text = "Save";
            this.dbSaveButton.UseVisualStyleBackColor = true;
            this.dbSaveButton.Click += new System.EventHandler(this.dbSaveButton_Click);
            // 
            // dbCancelButton
            // 
            this.dbCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dbCancelButton.Location = new System.Drawing.Point(110, 352);
            this.dbCancelButton.Name = "dbCancelButton";
            this.dbCancelButton.Size = new System.Drawing.Size(99, 23);
            this.dbCancelButton.TabIndex = 8;
            this.dbCancelButton.Text = "Cancel";
            this.dbCancelButton.UseVisualStyleBackColor = true;
            this.dbCancelButton.Click += new System.EventHandler(this.dbCancelButton_Click);
            // 
            // dbTestButton
            // 
            this.dbTestButton.Location = new System.Drawing.Point(5, 248);
            this.dbTestButton.Name = "dbTestButton";
            this.dbTestButton.Size = new System.Drawing.Size(199, 23);
            this.dbTestButton.TabIndex = 6;
            this.dbTestButton.Text = "Test Connection";
            this.dbTestButton.UseVisualStyleBackColor = true;
            this.dbTestButton.Click += new System.EventHandler(this.dbTestButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(224, 334);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dbResetButton);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dbPortBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dbTestButton);
            this.tabPage1.Controls.Add(this.dbHostBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dbDatabaseBox);
            this.tabPage1.Controls.Add(this.dbPasswordBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dbUserBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(216, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dbResetButton
            // 
            this.dbResetButton.Location = new System.Drawing.Point(6, 278);
            this.dbResetButton.Name = "dbResetButton";
            this.dbResetButton.Size = new System.Drawing.Size(199, 23);
            this.dbResetButton.TabIndex = 12;
            this.dbResetButton.Text = "Reset Database";
            this.dbResetButton.UseVisualStyleBackColor = true;
            this.dbResetButton.Click += new System.EventHandler(this.dbResetButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Port";
            // 
            // dbPortBox
            // 
            this.dbPortBox.Location = new System.Drawing.Point(6, 75);
            this.dbPortBox.Name = "dbPortBox";
            this.dbPortBox.Size = new System.Drawing.Size(198, 20);
            this.dbPortBox.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tessPathBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(216, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tesseract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Path";
            // 
            // tessPathBox
            // 
            this.tessPathBox.Location = new System.Drawing.Point(6, 24);
            this.tessPathBox.Name = "tessPathBox";
            this.tessPathBox.Size = new System.Drawing.Size(198, 20);
            this.tessPathBox.TabIndex = 3;
            // 
            // dbConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 386);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dbSaveButton);
            this.Controls.Add(this.dbCancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dbConnectionForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.dbConnectionForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dbHostBox;
        private System.Windows.Forms.TextBox dbDatabaseBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbUserBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbPasswordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dbSaveButton;
        private System.Windows.Forms.Button dbCancelButton;
        private System.Windows.Forms.Button dbTestButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbPortBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tessPathBox;
        private System.Windows.Forms.Button dbResetButton;
    }
}