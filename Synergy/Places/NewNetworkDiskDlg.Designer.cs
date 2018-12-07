namespace Places
{
    partial class NewNetworkDiskDlg
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDiskName = new System.Windows.Forms.Label();
            this.txtDiskName = new System.Windows.Forms.TextBox();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.lblDiskNameExists = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(34, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(115, 126);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(196, 126);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblDiskName
            // 
            this.lblDiskName.AutoSize = true;
            this.lblDiskName.Location = new System.Drawing.Point(10, 31);
            this.lblDiskName.Name = "lblDiskName";
            this.lblDiskName.Size = new System.Drawing.Size(166, 13);
            this.lblDiskName.TabIndex = 15;
            this.lblDiskName.Text = "Имя для этого сетевого диска:";
            // 
            // txtDiskName
            // 
            this.txtDiskName.Location = new System.Drawing.Point(12, 52);
            this.txtDiskName.Name = "txtDiskName";
            this.txtDiskName.Size = new System.Drawing.Size(259, 20);
            this.txtDiskName.TabIndex = 16;
            this.txtDiskName.Click += new System.EventHandler(this.txtDiskName_Click);
            // 
            // lblDiskNameExists
            // 
            this.lblDiskNameExists.AutoSize = true;
            this.lblDiskNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblDiskNameExists.Location = new System.Drawing.Point(9, 75);
            this.lblDiskNameExists.Name = "lblDiskNameExists";
            this.lblDiskNameExists.Size = new System.Drawing.Size(52, 13);
            this.lblDiskNameExists.TabIndex = 51;
            this.lblDiskNameExists.Text = "diskexists";
            // 
            // NewNetworkDiskDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lblDiskNameExists);
            this.Controls.Add(this.txtDiskName);
            this.Controls.Add(this.lblDiskName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewNetworkDiskDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый сетевой диск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblDiskName;
        public System.Windows.Forms.TextBox txtDiskName;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Label lblDiskNameExists;
    }
}