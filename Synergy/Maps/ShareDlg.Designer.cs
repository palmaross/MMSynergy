namespace Maps
{
    partial class ShareDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareDlg));
            this.lblFolderToShare = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblShareWhat = new System.Windows.Forms.Label();
            this.lblShareWhom = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.CheckedListBox();
            this.rbtnMap = new System.Windows.Forms.RadioButton();
            this.rbtnProject = new System.Windows.Forms.RadioButton();
            this.rbtnFolder = new System.Windows.Forms.RadioButton();
            this.linkLabelChangeTemplate = new System.Windows.Forms.LinkLabel();
            this.groupBoxEmail = new System.Windows.Forms.GroupBox();
            this.btnClickUsers = new System.Windows.Forms.PictureBox();
            this.txtEmails = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelRadio = new System.Windows.Forms.Panel();
            this.groupBoxEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClickUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFolderToShare
            // 
            this.lblFolderToShare.AutoSize = true;
            this.lblFolderToShare.Location = new System.Drawing.Point(6, 9);
            this.lblFolderToShare.Name = "lblFolderToShare";
            this.lblFolderToShare.Size = new System.Drawing.Size(195, 13);
            this.lblFolderToShare.TabIndex = 1;
            this.lblFolderToShare.Text = "Папка, к которой нужно дать доступ:";
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(6, 33);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(381, 26);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "folder";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 98);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(68, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Сообщение:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpenFolder.Location = new System.Drawing.Point(220, 62);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(171, 23);
            this.btnOpenFolder.TabIndex = 6;
            this.btnOpenFolder.Text = "Открыть папку в Проводнике";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.AutoSize = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(9, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Отправить письмо";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(9, 114);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(381, 95);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.Text = resources.GetString("txtMessage.Text");
            // 
            // lblShareWhat
            // 
            this.lblShareWhat.AutoSize = true;
            this.lblShareWhat.Location = new System.Drawing.Point(6, 7);
            this.lblShareWhat.Name = "lblShareWhat";
            this.lblShareWhat.Size = new System.Drawing.Size(82, 13);
            this.lblShareWhat.TabIndex = 9;
            this.lblShareWhat.Text = "Чем делитесь:";
            // 
            // lblShareWhom
            // 
            this.lblShareWhom.AutoSize = true;
            this.lblShareWhom.Location = new System.Drawing.Point(6, 22);
            this.lblShareWhom.Name = "lblShareWhom";
            this.lblShareWhom.Size = new System.Drawing.Size(36, 13);
            this.lblShareWhom.TabIndex = 11;
            this.lblShareWhom.Text = "Кому:";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(76, 197);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(323, 20);
            this.txtTheme.TabIndex = 14;
            this.txtTheme.Text = "Приглашение в MindManager Synergy";
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(6, 66);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(37, 13);
            this.lblTheme.TabIndex = 13;
            this.lblTheme.Text = "Тема:";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.CheckOnClick = true;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(57, 41);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(333, 94);
            this.listBoxUsers.TabIndex = 15;
            this.listBoxUsers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxUsers_Click);
            // 
            // rbtnMap
            // 
            this.rbtnMap.AutoSize = true;
            this.rbtnMap.Checked = true;
            this.rbtnMap.Location = new System.Drawing.Point(123, 5);
            this.rbtnMap.Name = "rbtnMap";
            this.rbtnMap.Size = new System.Drawing.Size(54, 17);
            this.rbtnMap.TabIndex = 16;
            this.rbtnMap.TabStop = true;
            this.rbtnMap.Text = "карта";
            this.rbtnMap.UseVisualStyleBackColor = true;
            // 
            // rbtnProject
            // 
            this.rbtnProject.AutoSize = true;
            this.rbtnProject.Location = new System.Drawing.Point(220, 5);
            this.rbtnProject.Name = "rbtnProject";
            this.rbtnProject.Size = new System.Drawing.Size(60, 17);
            this.rbtnProject.TabIndex = 17;
            this.rbtnProject.Text = "проект";
            this.rbtnProject.UseVisualStyleBackColor = true;
            // 
            // rbtnFolder
            // 
            this.rbtnFolder.AutoSize = true;
            this.rbtnFolder.Location = new System.Drawing.Point(313, 5);
            this.rbtnFolder.Name = "rbtnFolder";
            this.rbtnFolder.Size = new System.Drawing.Size(55, 17);
            this.rbtnFolder.TabIndex = 18;
            this.rbtnFolder.Text = "папка";
            this.rbtnFolder.UseVisualStyleBackColor = true;
            // 
            // linkLabelChangeTemplate
            // 
            this.linkLabelChangeTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelChangeTemplate.AutoSize = true;
            this.linkLabelChangeTemplate.Location = new System.Drawing.Point(233, 214);
            this.linkLabelChangeTemplate.Name = "linkLabelChangeTemplate";
            this.linkLabelChangeTemplate.Size = new System.Drawing.Size(159, 13);
            this.linkLabelChangeTemplate.TabIndex = 19;
            this.linkLabelChangeTemplate.TabStop = true;
            this.linkLabelChangeTemplate.Text = "Изменить шаблон сообщения";
            // 
            // groupBoxEmail
            // 
            this.groupBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEmail.Controls.Add(this.btnClickUsers);
            this.groupBoxEmail.Controls.Add(this.txtEmails);
            this.groupBoxEmail.Controls.Add(this.linkLabelChangeTemplate);
            this.groupBoxEmail.Controls.Add(this.lblShareWhom);
            this.groupBoxEmail.Controls.Add(this.lblTheme);
            this.groupBoxEmail.Controls.Add(this.lblMessage);
            this.groupBoxEmail.Controls.Add(this.txtMessage);
            this.groupBoxEmail.Controls.Add(this.listBoxUsers);
            this.groupBoxEmail.Location = new System.Drawing.Point(9, 133);
            this.groupBoxEmail.Name = "groupBoxEmail";
            this.groupBoxEmail.Size = new System.Drawing.Size(396, 238);
            this.groupBoxEmail.TabIndex = 20;
            this.groupBoxEmail.TabStop = false;
            this.groupBoxEmail.Text = "Отправить письмо";
            // 
            // btnClickUsers
            // 
            this.btnClickUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnClickUsers.Image")));
            this.btnClickUsers.Location = new System.Drawing.Point(370, 23);
            this.btnClickUsers.Name = "btnClickUsers";
            this.btnClickUsers.Size = new System.Drawing.Size(18, 18);
            this.btnClickUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClickUsers.TabIndex = 21;
            this.btnClickUsers.TabStop = false;
            this.btnClickUsers.Click += new System.EventHandler(this.btnClickUsers_Click);
            // 
            // txtEmails
            // 
            this.txtEmails.ForeColor = System.Drawing.Color.Gray;
            this.txtEmails.Location = new System.Drawing.Point(57, 22);
            this.txtEmails.Name = "txtEmails";
            this.txtEmails.Size = new System.Drawing.Size(333, 20);
            this.txtEmails.TabIndex = 20;
            this.txtEmails.Text = "Новый контакт - введите email (добавьте через запятую)";
            this.txtEmails.Click += new System.EventHandler(this.txtEmails_Click);
            this.txtEmails.TextChanged += new System.EventHandler(this.txtEmails_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblFolderToShare);
            this.panel1.Controls.Add(this.lblPath);
            this.panel1.Controls.Add(this.btnOpenFolder);
            this.panel1.Location = new System.Drawing.Point(9, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 85);
            this.panel1.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(293, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panelRadio
            // 
            this.panelRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRadio.Controls.Add(this.lblShareWhat);
            this.panelRadio.Controls.Add(this.rbtnFolder);
            this.panelRadio.Controls.Add(this.rbtnMap);
            this.panelRadio.Controls.Add(this.rbtnProject);
            this.panelRadio.Location = new System.Drawing.Point(9, 12);
            this.panelRadio.Name = "panelRadio";
            this.panelRadio.Size = new System.Drawing.Size(396, 27);
            this.panelRadio.TabIndex = 23;
            // 
            // ShareDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 412);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBoxEmail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRadio);
            this.Name = "ShareDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поделиться";
            this.groupBoxEmail.ResumeLayout(false);
            this.groupBoxEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClickUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRadio.ResumeLayout(false);
            this.panelRadio.PerformLayout();
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
        private System.Windows.Forms.Label lblShareWhat;
        private System.Windows.Forms.Label lblShareWhom;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.CheckedListBox listBoxUsers;
        private System.Windows.Forms.RadioButton rbtnMap;
        private System.Windows.Forms.RadioButton rbtnProject;
        private System.Windows.Forms.RadioButton rbtnFolder;
        private System.Windows.Forms.LinkLabel linkLabelChangeTemplate;
        private System.Windows.Forms.GroupBox groupBoxEmail;
        private System.Windows.Forms.PictureBox btnClickUsers;
        private System.Windows.Forms.TextBox txtEmails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelRadio;
    }
}