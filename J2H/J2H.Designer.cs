namespace J2H
{
    partial class J2H
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(J2H));
            this.grpbJson = new System.Windows.Forms.GroupBox();
            this.btnJsonFileLocation = new System.Windows.Forms.Button();
            this.lblJsonFileLocation = new System.Windows.Forms.Label();
            this.txtbJsonFileLocation = new System.Windows.Forms.TextBox();
            this.grpbHtml = new System.Windows.Forms.GroupBox();
            this.lblHtmlFileName = new System.Windows.Forms.Label();
            this.txtbHtmlFileName = new System.Windows.Forms.TextBox();
            this.btnHtmlFileLocation = new System.Windows.Forms.Button();
            this.lblHtmlFileLocation = new System.Windows.Forms.Label();
            this.txtbHtmlFileLocation = new System.Windows.Forms.TextBox();
            this.btnCreateHtmlFile = new System.Windows.Forms.Button();
            this.btnShowHtmlFile = new System.Windows.Forms.Button();
            this.opnfdJsonFile = new System.Windows.Forms.OpenFileDialog();
            this.fldbdHtmlFileLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.grpbJson.SuspendLayout();
            this.grpbHtml.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbJson
            // 
            this.grpbJson.Controls.Add(this.btnJsonFileLocation);
            this.grpbJson.Controls.Add(this.lblJsonFileLocation);
            this.grpbJson.Controls.Add(this.txtbJsonFileLocation);
            this.grpbJson.Location = new System.Drawing.Point(12, 12);
            this.grpbJson.Name = "grpbJson";
            this.grpbJson.Size = new System.Drawing.Size(464, 121);
            this.grpbJson.TabIndex = 0;
            this.grpbJson.TabStop = false;
            this.grpbJson.Text = "JSON";
            // 
            // btnJsonFileLocation
            // 
            this.btnJsonFileLocation.Location = new System.Drawing.Point(363, 74);
            this.btnJsonFileLocation.Name = "btnJsonFileLocation";
            this.btnJsonFileLocation.Size = new System.Drawing.Size(75, 26);
            this.btnJsonFileLocation.TabIndex = 2;
            this.btnJsonFileLocation.Text = "Search";
            this.btnJsonFileLocation.UseVisualStyleBackColor = true;
            this.btnJsonFileLocation.Click += new System.EventHandler(this.btnJsonFileLocation_Click);
            // 
            // lblJsonFileLocation
            // 
            this.lblJsonFileLocation.AutoSize = true;
            this.lblJsonFileLocation.Location = new System.Drawing.Point(23, 41);
            this.lblJsonFileLocation.Name = "lblJsonFileLocation";
            this.lblJsonFileLocation.Size = new System.Drawing.Size(97, 20);
            this.lblJsonFileLocation.TabIndex = 1;
            this.lblJsonFileLocation.Text = "File location:";
            // 
            // txtbJsonFileLocation
            // 
            this.txtbJsonFileLocation.Location = new System.Drawing.Point(27, 74);
            this.txtbJsonFileLocation.Name = "txtbJsonFileLocation";
            this.txtbJsonFileLocation.Size = new System.Drawing.Size(340, 26);
            this.txtbJsonFileLocation.TabIndex = 0;
            this.txtbJsonFileLocation.TextChanged += new System.EventHandler(this.txtbJsonFileHtmlFile_TextChanged);
            // 
            // grpbHtml
            // 
            this.grpbHtml.Controls.Add(this.lblHtmlFileName);
            this.grpbHtml.Controls.Add(this.txtbHtmlFileName);
            this.grpbHtml.Controls.Add(this.btnHtmlFileLocation);
            this.grpbHtml.Controls.Add(this.lblHtmlFileLocation);
            this.grpbHtml.Controls.Add(this.txtbHtmlFileLocation);
            this.grpbHtml.Location = new System.Drawing.Point(12, 157);
            this.grpbHtml.Name = "grpbHtml";
            this.grpbHtml.Size = new System.Drawing.Size(464, 172);
            this.grpbHtml.TabIndex = 3;
            this.grpbHtml.TabStop = false;
            this.grpbHtml.Text = "HTML";
            // 
            // lblHtmlFileName
            // 
            this.lblHtmlFileName.AutoSize = true;
            this.lblHtmlFileName.Location = new System.Drawing.Point(23, 45);
            this.lblHtmlFileName.Name = "lblHtmlFileName";
            this.lblHtmlFileName.Size = new System.Drawing.Size(55, 20);
            this.lblHtmlFileName.TabIndex = 4;
            this.lblHtmlFileName.Text = "Name:";
            // 
            // txtbHtmlFileName
            // 
            this.txtbHtmlFileName.Location = new System.Drawing.Point(84, 42);
            this.txtbHtmlFileName.Name = "txtbHtmlFileName";
            this.txtbHtmlFileName.Size = new System.Drawing.Size(113, 26);
            this.txtbHtmlFileName.TabIndex = 3;
            this.txtbHtmlFileName.TextChanged += new System.EventHandler(this.txtbJsonFileHtmlFile_TextChanged);
            // 
            // btnHtmlFileLocation
            // 
            this.btnHtmlFileLocation.Location = new System.Drawing.Point(363, 126);
            this.btnHtmlFileLocation.Name = "btnHtmlFileLocation";
            this.btnHtmlFileLocation.Size = new System.Drawing.Size(75, 26);
            this.btnHtmlFileLocation.TabIndex = 2;
            this.btnHtmlFileLocation.Text = "Set";
            this.btnHtmlFileLocation.UseVisualStyleBackColor = true;
            this.btnHtmlFileLocation.Click += new System.EventHandler(this.btnHtmlFileLocation_Click);
            // 
            // lblHtmlFileLocation
            // 
            this.lblHtmlFileLocation.AutoSize = true;
            this.lblHtmlFileLocation.Location = new System.Drawing.Point(23, 93);
            this.lblHtmlFileLocation.Name = "lblHtmlFileLocation";
            this.lblHtmlFileLocation.Size = new System.Drawing.Size(97, 20);
            this.lblHtmlFileLocation.TabIndex = 1;
            this.lblHtmlFileLocation.Text = "File location:";
            // 
            // txtbHtmlFileLocation
            // 
            this.txtbHtmlFileLocation.Location = new System.Drawing.Point(27, 126);
            this.txtbHtmlFileLocation.Name = "txtbHtmlFileLocation";
            this.txtbHtmlFileLocation.Size = new System.Drawing.Size(340, 26);
            this.txtbHtmlFileLocation.TabIndex = 0;
            this.txtbHtmlFileLocation.TextChanged += new System.EventHandler(this.txtbJsonFileHtmlFile_TextChanged);
            // 
            // btnCreateHtmlFile
            // 
            this.btnCreateHtmlFile.Location = new System.Drawing.Point(311, 376);
            this.btnCreateHtmlFile.Name = "btnCreateHtmlFile";
            this.btnCreateHtmlFile.Size = new System.Drawing.Size(165, 39);
            this.btnCreateHtmlFile.TabIndex = 5;
            this.btnCreateHtmlFile.Text = "Create";
            this.btnCreateHtmlFile.UseVisualStyleBackColor = true;
            this.btnCreateHtmlFile.Click += new System.EventHandler(this.btnCreateHtmlFile_Click);
            // 
            // btnShowHtmlFile
            // 
            this.btnShowHtmlFile.Location = new System.Drawing.Point(12, 376);
            this.btnShowHtmlFile.Name = "btnShowHtmlFile";
            this.btnShowHtmlFile.Size = new System.Drawing.Size(165, 39);
            this.btnShowHtmlFile.TabIndex = 6;
            this.btnShowHtmlFile.Text = "Show";
            this.btnShowHtmlFile.UseVisualStyleBackColor = true;
            this.btnShowHtmlFile.Click += new System.EventHandler(this.btnShowHtmlFile_Click);
            // 
            // opnfdJsonFile
            // 
            this.opnfdJsonFile.FileName = "openFileDialog1";
            // 
            // J2H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 433);
            this.Controls.Add(this.btnShowHtmlFile);
            this.Controls.Add(this.btnCreateHtmlFile);
            this.Controls.Add(this.grpbHtml);
            this.Controls.Add(this.grpbJson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "J2H";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "J2H";
            this.grpbJson.ResumeLayout(false);
            this.grpbJson.PerformLayout();
            this.grpbHtml.ResumeLayout(false);
            this.grpbHtml.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbJson;
        private System.Windows.Forms.Button btnJsonFileLocation;
        private System.Windows.Forms.Label lblJsonFileLocation;
        private System.Windows.Forms.TextBox txtbJsonFileLocation;
        private System.Windows.Forms.GroupBox grpbHtml;
        private System.Windows.Forms.Label lblHtmlFileName;
        private System.Windows.Forms.TextBox txtbHtmlFileName;
        private System.Windows.Forms.Button btnHtmlFileLocation;
        private System.Windows.Forms.Label lblHtmlFileLocation;
        private System.Windows.Forms.TextBox txtbHtmlFileLocation;
        private System.Windows.Forms.Button btnCreateHtmlFile;
        private System.Windows.Forms.Button btnShowHtmlFile;
        private System.Windows.Forms.OpenFileDialog opnfdJsonFile;
        private System.Windows.Forms.FolderBrowserDialog fldbdHtmlFileLocation;
    }
}

