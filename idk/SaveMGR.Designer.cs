namespace idk
{
    partial class SaveMGR
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataDisplay = new System.Windows.Forms.ListBox();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.file_pathTXT = new System.Windows.Forms.TextBox();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.sfiledlg = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data to save :";
            // 
            // dataDisplay
            // 
            this.dataDisplay.BackColor = System.Drawing.Color.White;
            this.dataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataDisplay.FormattingEnabled = true;
            this.dataDisplay.Location = new System.Drawing.Point(12, 25);
            this.dataDisplay.Name = "dataDisplay";
            this.dataDisplay.Size = new System.Drawing.Size(301, 340);
            this.dataDisplay.TabIndex = 1;
            // 
            // SaveBTN
            // 
            this.SaveBTN.BackColor = System.Drawing.Color.White;
            this.SaveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBTN.Location = new System.Drawing.Point(11, 407);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(302, 23);
            this.SaveBTN.TabIndex = 2;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = false;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // file_pathTXT
            // 
            this.file_pathTXT.ForeColor = System.Drawing.Color.Black;
            this.file_pathTXT.Location = new System.Drawing.Point(12, 381);
            this.file_pathTXT.Name = "file_pathTXT";
            this.file_pathTXT.Size = new System.Drawing.Size(220, 20);
            this.file_pathTXT.TabIndex = 3;
            this.file_pathTXT.TextChanged += new System.EventHandler(this.file_pathTXT_TextChanged);
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.BackColor = System.Drawing.Color.White;
            this.BrowseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseBTN.Location = new System.Drawing.Point(238, 379);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(75, 23);
            this.BrowseBTN.TabIndex = 4;
            this.BrowseBTN.Text = "Browse...";
            this.BrowseBTN.UseVisualStyleBackColor = false;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // sfiledlg
            // 
            this.sfiledlg.FileName = "save.zsf";
            this.sfiledlg.Filter = "zeGolem\'s save file (*.zsf)|*.zsf";
            this.sfiledlg.FileOk += new System.ComponentModel.CancelEventHandler(this.sfiledlg_ok);
            // 
            // SaveMGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 450);
            this.Controls.Add(this.BrowseBTN);
            this.Controls.Add(this.file_pathTXT);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.dataDisplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveMGR";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save";
            this.Load += new System.EventHandler(this.SaveMGR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox dataDisplay;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.TextBox file_pathTXT;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.SaveFileDialog sfiledlg;
    }
}