namespace idk
{
    partial class LoadMGR
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
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.file_pathTXT = new System.Windows.Forms.TextBox();
            this.LoadBTN = new System.Windows.Forms.Button();
            this.dataDisplay = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Import_BTN = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.BackColor = System.Drawing.Color.White;
            this.BrowseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseBTN.Location = new System.Drawing.Point(241, 10);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(75, 23);
            this.BrowseBTN.TabIndex = 9;
            this.BrowseBTN.Text = "Browse...";
            this.BrowseBTN.UseVisualStyleBackColor = false;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // file_pathTXT
            // 
            this.file_pathTXT.ForeColor = System.Drawing.Color.Black;
            this.file_pathTXT.Location = new System.Drawing.Point(15, 12);
            this.file_pathTXT.Name = "file_pathTXT";
            this.file_pathTXT.Size = new System.Drawing.Size(220, 20);
            this.file_pathTXT.TabIndex = 8;
            // 
            // LoadBTN
            // 
            this.LoadBTN.BackColor = System.Drawing.Color.White;
            this.LoadBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBTN.Location = new System.Drawing.Point(15, 39);
            this.LoadBTN.Name = "LoadBTN";
            this.LoadBTN.Size = new System.Drawing.Size(302, 23);
            this.LoadBTN.TabIndex = 7;
            this.LoadBTN.Text = "Load";
            this.LoadBTN.UseVisualStyleBackColor = false;
            this.LoadBTN.Click += new System.EventHandler(this.LoadBTN_Click);
            // 
            // dataDisplay
            // 
            this.dataDisplay.BackColor = System.Drawing.Color.White;
            this.dataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataDisplay.FormattingEnabled = true;
            this.dataDisplay.Location = new System.Drawing.Point(12, 98);
            this.dataDisplay.Name = "dataDisplay";
            this.dataDisplay.Size = new System.Drawing.Size(301, 314);
            this.dataDisplay.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data to load :";
            // 
            // Import_BTN
            // 
            this.Import_BTN.BackColor = System.Drawing.Color.White;
            this.Import_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Import_BTN.Location = new System.Drawing.Point(12, 415);
            this.Import_BTN.Name = "Import_BTN";
            this.Import_BTN.Size = new System.Drawing.Size(302, 23);
            this.Import_BTN.TabIndex = 7;
            this.Import_BTN.Text = "Import";
            this.Import_BTN.UseVisualStyleBackColor = false;
            this.Import_BTN.Click += new System.EventHandler(this.Import_BTN_Click);
            // 
            // OFD
            // 
            this.OFD.DefaultExt = "zeGolem\'s save file (*.zsf)|*.zsf";
            this.OFD.FileName = "openFileDialog1";
            // 
            // LoadMGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 450);
            this.Controls.Add(this.BrowseBTN);
            this.Controls.Add(this.file_pathTXT);
            this.Controls.Add(this.Import_BTN);
            this.Controls.Add(this.LoadBTN);
            this.Controls.Add(this.dataDisplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadMGR";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadMGR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.TextBox file_pathTXT;
        private System.Windows.Forms.Button LoadBTN;
        private System.Windows.Forms.ListBox dataDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Import_BTN;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}