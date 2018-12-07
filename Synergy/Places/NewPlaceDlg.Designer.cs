namespace Places
{
    partial class NewPlaceDlg
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
            this.lblChoosePlace = new System.Windows.Forms.Label();
            this.rbtnCloudStorage = new System.Windows.Forms.RadioButton();
            this.rbtnNetworkDisk = new System.Windows.Forms.RadioButton();
            this.rbtnWebSite = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblChoosePlace
            // 
            this.lblChoosePlace.AutoSize = true;
            this.lblChoosePlace.Location = new System.Drawing.Point(12, 14);
            this.lblChoosePlace.Name = "lblChoosePlace";
            this.lblChoosePlace.Size = new System.Drawing.Size(157, 13);
            this.lblChoosePlace.TabIndex = 0;
            this.lblChoosePlace.Text = "Где будет находиться место?";
            // 
            // rbtnCloudStorage
            // 
            this.rbtnCloudStorage.AutoSize = true;
            this.rbtnCloudStorage.Location = new System.Drawing.Point(15, 41);
            this.rbtnCloudStorage.Name = "rbtnCloudStorage";
            this.rbtnCloudStorage.Size = new System.Drawing.Size(133, 17);
            this.rbtnCloudStorage.TabIndex = 1;
            this.rbtnCloudStorage.TabStop = true;
            this.rbtnCloudStorage.Text = "Облачное хранилище";
            this.rbtnCloudStorage.UseVisualStyleBackColor = true;
            // 
            // rbtnNetworkDisk
            // 
            this.rbtnNetworkDisk.AutoSize = true;
            this.rbtnNetworkDisk.Enabled = false;
            this.rbtnNetworkDisk.Location = new System.Drawing.Point(15, 64);
            this.rbtnNetworkDisk.Name = "rbtnNetworkDisk";
            this.rbtnNetworkDisk.Size = new System.Drawing.Size(94, 17);
            this.rbtnNetworkDisk.TabIndex = 2;
            this.rbtnNetworkDisk.TabStop = true;
            this.rbtnNetworkDisk.Text = "Сетевой диск";
            this.rbtnNetworkDisk.UseVisualStyleBackColor = true;
            // 
            // rbtnWebSite
            // 
            this.rbtnWebSite.AutoSize = true;
            this.rbtnWebSite.Location = new System.Drawing.Point(15, 87);
            this.rbtnWebSite.Name = "rbtnWebSite";
            this.rbtnWebSite.Size = new System.Drawing.Size(49, 17);
            this.rbtnWebSite.TabIndex = 3;
            this.rbtnWebSite.TabStop = true;
            this.rbtnWebSite.Text = "Сайт";
            this.rbtnWebSite.UseVisualStyleBackColor = true;
            this.rbtnWebSite.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(204, 133);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(123, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewPlaceDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 171);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.rbtnWebSite);
            this.Controls.Add(this.rbtnNetworkDisk);
            this.Controls.Add(this.rbtnCloudStorage);
            this.Controls.Add(this.lblChoosePlace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlaceDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое общее место: где?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoosePlace;
        private System.Windows.Forms.RadioButton rbtnCloudStorage;
        private System.Windows.Forms.RadioButton rbtnNetworkDisk;
        private System.Windows.Forms.RadioButton rbtnWebSite;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}