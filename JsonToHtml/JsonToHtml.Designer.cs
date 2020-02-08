namespace JsonToHtml
{
    partial class fJsonToHtml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fJsonToHtml));
            this.lblInput = new System.Windows.Forms.Label();
            this.txtboxInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtboxOutput = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.ofdInput = new System.Windows.Forms.OpenFileDialog();
            this.fbdOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(30, 30);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(138, 20);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "JSON file location:";
            // 
            // txtboxInput
            // 
            this.txtboxInput.Location = new System.Drawing.Point(34, 64);
            this.txtboxInput.Name = "txtboxInput";
            this.txtboxInput.Size = new System.Drawing.Size(430, 26);
            this.txtboxInput.TabIndex = 1;
            this.txtboxInput.TextChanged += new System.EventHandler(this.TxtboxInputOutput_TextChanged);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(30, 127);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(159, 20);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "HTML folder location:";
            // 
            // txtboxOutput
            // 
            this.txtboxOutput.Location = new System.Drawing.Point(34, 164);
            this.txtboxOutput.Name = "txtboxOutput";
            this.txtboxOutput.Size = new System.Drawing.Size(430, 26);
            this.txtboxOutput.TabIndex = 3;
            this.txtboxOutput.TextChanged += new System.EventHandler(this.TxtboxInputOutput_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(399, 248);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(132, 46);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnShow
            // 
            this.btnShow.Enabled = false;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnShow.Location = new System.Drawing.Point(34, 248);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(132, 46);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // btnInput
            // 
            this.btnInput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnInput.Location = new System.Drawing.Point(461, 64);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(70, 26);
            this.btnInput.TabIndex = 6;
            this.btnInput.Text = "Search";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOutput.Location = new System.Drawing.Point(461, 164);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(70, 26);
            this.btnOutput.TabIndex = 7;
            this.btnOutput.Text = "Set";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // fJsonToHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 326);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtboxOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtboxInput);
            this.Controls.Add(this.lblInput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "fJsonToHtml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JsonToHtml";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtboxInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtboxOutput;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.OpenFileDialog ofdInput;
        private System.Windows.Forms.FolderBrowserDialog fbdOutput;
    }
}

