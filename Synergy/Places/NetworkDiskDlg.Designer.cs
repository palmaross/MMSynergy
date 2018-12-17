namespace Places
{
    partial class NetworkDiskDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDiskDlg));
            this.lblPlace = new System.Windows.Forms.Label();
            this.txtNetworkDiskName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPlaceExists = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.helpPath = new System.Windows.Forms.PictureBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblPlaceTaken = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.helpPath)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(8, 19);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(66, 13);
            this.lblPlace.TabIndex = 0;
            this.lblPlace.Text = "Имя места:";
            // 
            // txtNetworkDiskName
            // 
            this.txtNetworkDiskName.Location = new System.Drawing.Point(11, 36);
            this.txtNetworkDiskName.Name = "txtNetworkDiskName";
            this.txtNetworkDiskName.Size = new System.Drawing.Size(268, 20);
            this.txtNetworkDiskName.TabIndex = 1;
            this.txtNetworkDiskName.Click += new System.EventHandler(this.txtNetworkDiskName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(120, 142);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(224, 142);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPlaceExists
            // 
            this.lblPlaceExists.AutoSize = true;
            this.lblPlaceExists.ForeColor = System.Drawing.Color.Red;
            this.lblPlaceExists.Location = new System.Drawing.Point(12, 59);
            this.lblPlaceExists.Name = "lblPlaceExists";
            this.lblPlaceExists.Size = new System.Drawing.Size(59, 13);
            this.lblPlaceExists.TabIndex = 9;
            this.lblPlaceExists.Text = "placeexists";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(237, 95);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(40, 22);
            this.btnBrowse.TabIndex = 58;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(11, 96);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(220, 20);
            this.txtFolderPath.TabIndex = 57;
            // 
            // helpPath
            // 
            this.helpPath.Image = ((System.Drawing.Image)(resources.GetObject("helpPath.Image")));
            this.helpPath.Location = new System.Drawing.Point(283, 101);
            this.helpPath.Name = "helpPath";
            this.helpPath.Size = new System.Drawing.Size(16, 16);
            this.helpPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpPath.TabIndex = 56;
            this.helpPath.TabStop = false;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(8, 78);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(76, 13);
            this.lblPath.TabIndex = 59;
            this.lblPath.Text = "Путь к месту:";
            // 
            // lblPlaceTaken
            // 
            this.lblPlaceTaken.AutoSize = true;
            this.lblPlaceTaken.ForeColor = System.Drawing.Color.Red;
            this.lblPlaceTaken.Location = new System.Drawing.Point(12, 119);
            this.lblPlaceTaken.Name = "lblPlaceTaken";
            this.lblPlaceTaken.Size = new System.Drawing.Size(60, 13);
            this.lblPlaceTaken.TabIndex = 60;
            this.lblPlaceTaken.Text = "placetaken";
            // 
            // NetworkDiskDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 178);
            this.Controls.Add(this.lblPlaceTaken);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.helpPath);
            this.Controls.Add(this.lblPlaceExists);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtNetworkDiskName);
            this.Controls.Add(this.lblPlace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkDiskDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое место: сетевой диск";
            ((System.ComponentModel.ISupportInitialize)(this.helpPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPlaceExists;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.PictureBox helpPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblPlaceTaken;
        public System.Windows.Forms.TextBox txtNetworkDiskName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}