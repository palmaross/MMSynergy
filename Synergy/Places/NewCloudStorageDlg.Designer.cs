namespace Places
{
    partial class NewCloudStorageDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCloudStorageDlg));
            this.lblNewStorageName = new System.Windows.Forms.Label();
            this.txtNewStorageName = new System.Windows.Forms.TextBox();
            this.lblProcess = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.helpProcess = new System.Windows.Forms.PictureBox();
            this.lblNameExists = new System.Windows.Forms.Label();
            this.tltHelpProcess = new System.Windows.Forms.ToolTip(this.components);
            this.helpSite = new System.Windows.Forms.PictureBox();
            this.txtSiteUrl = new System.Windows.Forms.TextBox();
            this.lblSiteUrl = new System.Windows.Forms.Label();
            this.tltHelpSite = new System.Windows.Forms.ToolTip(this.components);
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.helpProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpSite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNewStorageName
            // 
            this.lblNewStorageName.AutoSize = true;
            this.lblNewStorageName.Location = new System.Drawing.Point(12, 13);
            this.lblNewStorageName.Name = "lblNewStorageName";
            this.lblNewStorageName.Size = new System.Drawing.Size(177, 13);
            this.lblNewStorageName.TabIndex = 0;
            this.lblNewStorageName.Text = "Имя этого облачного хранилища:";
            // 
            // txtNewStorageName
            // 
            this.txtNewStorageName.Location = new System.Drawing.Point(15, 29);
            this.txtNewStorageName.Name = "txtNewStorageName";
            this.txtNewStorageName.Size = new System.Drawing.Size(267, 20);
            this.txtNewStorageName.TabIndex = 1;
            this.txtNewStorageName.Click += new System.EventHandler(this.txtNewStorageName_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(12, 71);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(158, 13);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "Исполняемый файл/процесс:";
            // 
            // txtProcess
            // 
            this.txtProcess.Location = new System.Drawing.Point(15, 87);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(267, 20);
            this.txtProcess.TabIndex = 3;
            this.txtProcess.Click += new System.EventHandler(this.txtProcess_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(45, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(126, 196);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(207, 196);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // helpProcess
            // 
            this.helpProcess.Image = ((System.Drawing.Image)(resources.GetObject("helpProcess.Image")));
            this.helpProcess.Location = new System.Drawing.Point(265, 69);
            this.helpProcess.Name = "helpProcess";
            this.helpProcess.Size = new System.Drawing.Size(16, 16);
            this.helpProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpProcess.TabIndex = 49;
            this.helpProcess.TabStop = false;
            // 
            // lblNameExists
            // 
            this.lblNameExists.AutoSize = true;
            this.lblNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblNameExists.Location = new System.Drawing.Point(12, 52);
            this.lblNameExists.Name = "lblNameExists";
            this.lblNameExists.Size = new System.Drawing.Size(68, 13);
            this.lblNameExists.TabIndex = 50;
            this.lblNameExists.Text = "storageexists";
            // 
            // helpSite
            // 
            this.helpSite.Image = ((System.Drawing.Image)(resources.GetObject("helpSite.Image")));
            this.helpSite.Location = new System.Drawing.Point(265, 127);
            this.helpSite.Name = "helpSite";
            this.helpSite.Size = new System.Drawing.Size(16, 16);
            this.helpSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpSite.TabIndex = 53;
            this.helpSite.TabStop = false;
            // 
            // txtSiteUrl
            // 
            this.txtSiteUrl.Location = new System.Drawing.Point(15, 145);
            this.txtSiteUrl.Name = "txtSiteUrl";
            this.txtSiteUrl.Size = new System.Drawing.Size(267, 20);
            this.txtSiteUrl.TabIndex = 52;
            this.txtSiteUrl.Click += new System.EventHandler(this.txtSiteUrl_Click);
            // 
            // lblSiteUrl
            // 
            this.lblSiteUrl.AutoSize = true;
            this.lblSiteUrl.Location = new System.Drawing.Point(12, 129);
            this.lblSiteUrl.Name = "lblSiteUrl";
            this.lblSiteUrl.Size = new System.Drawing.Size(73, 13);
            this.lblSiteUrl.TabIndex = 51;
            this.lblSiteUrl.Text = "Адрес сайта:";
            // 
            // NewCloudStorageDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 230);
            this.Controls.Add(this.helpSite);
            this.Controls.Add(this.txtSiteUrl);
            this.Controls.Add(this.lblSiteUrl);
            this.Controls.Add(this.lblNameExists);
            this.Controls.Add(this.helpProcess);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtProcess);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.txtNewStorageName);
            this.Controls.Add(this.lblNewStorageName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCloudStorageDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое облачное хранилище";
            ((System.ComponentModel.ISupportInitialize)(this.helpProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpSite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewStorageName;
        public System.Windows.Forms.TextBox txtNewStorageName;
        private System.Windows.Forms.Label lblProcess;
        public System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox helpProcess;
        private System.Windows.Forms.Label lblNameExists;
        private System.Windows.Forms.ToolTip tltHelpProcess;
        private System.Windows.Forms.PictureBox helpSite;
        public System.Windows.Forms.TextBox txtSiteUrl;
        private System.Windows.Forms.Label lblSiteUrl;
        private System.Windows.Forms.ToolTip tltHelpSite;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}