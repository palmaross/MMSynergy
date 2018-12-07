namespace Maps
{
    partial class ShareMapDlg
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
            this.lblFolderToShare = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFolderToShare
            // 
            this.lblFolderToShare.AutoSize = true;
            this.lblFolderToShare.Location = new System.Drawing.Point(6, 13);
            this.lblFolderToShare.Name = "lblFolderToShare";
            this.lblFolderToShare.Size = new System.Drawing.Size(218, 13);
            this.lblFolderToShare.TabIndex = 1;
            this.lblFolderToShare.Text = "Папка, к которой вам нужно дать доступ:";
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(6, 38);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(393, 26);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "folder";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 72);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(262, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Предоставляя доступ к папке, сообщите коллеге:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpenFolder.Location = new System.Drawing.Point(9, 183);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(171, 23);
            this.btnOpenFolder.TabIndex = 6;
            this.btnOpenFolder.Text = "Открыть папку в Проводнике";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(341, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(58, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(9, 94);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(390, 75);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.Text = "Привет...\r\nЯ предоставил тебе доступ к папке: \"{0}\". Там карта для совместной раб" +
    "оты. \r\nНЕ ОТКРЫВАЙ ЕЕ ОТТУДА - войди в Synergy, кликни \"Принять карту\" и укажи п" +
    "уть к этой папке.";
            // 
            // ShareDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 215);
            this.ControlBox = false;
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblFolderToShare);
            this.Name = "ShareDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поделиться картой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolderToShare;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.TextBox txtMessage;
    }
}