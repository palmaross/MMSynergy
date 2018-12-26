namespace Login
{
    partial class SynergyMenuDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynergyMenuDlg));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdExplorer = new System.Windows.Forms.Button();
            this.cmdPublish = new System.Windows.Forms.Button();
            this.cmdShare = new System.Windows.Forms.Button();
            this.cmdUsers = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.checkBoxForgetMe = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "explorer.png");
            this.imageList1.Images.SetKeyName(1, "publish_s.png");
            this.imageList1.Images.SetKeyName(2, "share_s.png");
            this.imageList1.Images.SetKeyName(3, "user.png");
            this.imageList1.Images.SetKeyName(4, "Info.png");
            this.imageList1.Images.SetKeyName(5, "connection.png");
            // 
            // cmdExplorer
            // 
            this.cmdExplorer.FlatAppearance.BorderSize = 0;
            this.cmdExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExplorer.ImageIndex = 0;
            this.cmdExplorer.ImageList = this.imageList1;
            this.cmdExplorer.Location = new System.Drawing.Point(8, 6);
            this.cmdExplorer.Name = "cmdExplorer";
            this.cmdExplorer.Size = new System.Drawing.Size(195, 23);
            this.cmdExplorer.TabIndex = 0;
            this.cmdExplorer.Text = " Synergy Explorer";
            this.cmdExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExplorer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExplorer.UseVisualStyleBackColor = true;
            this.cmdExplorer.Click += new System.EventHandler(this.cmdExplorer_Click);
            // 
            // cmdPublish
            // 
            this.cmdPublish.FlatAppearance.BorderSize = 0;
            this.cmdPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPublish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPublish.ImageIndex = 1;
            this.cmdPublish.ImageList = this.imageList1;
            this.cmdPublish.Location = new System.Drawing.Point(8, 35);
            this.cmdPublish.Name = "cmdPublish";
            this.cmdPublish.Size = new System.Drawing.Size(195, 23);
            this.cmdPublish.TabIndex = 1;
            this.cmdPublish.Text = " Опубликовать текущую карту";
            this.cmdPublish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPublish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPublish.UseVisualStyleBackColor = true;
            this.cmdPublish.Click += new System.EventHandler(this.cmdPublish_Click);
            // 
            // cmdShare
            // 
            this.cmdShare.FlatAppearance.BorderSize = 0;
            this.cmdShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShare.ImageIndex = 2;
            this.cmdShare.ImageList = this.imageList1;
            this.cmdShare.Location = new System.Drawing.Point(8, 64);
            this.cmdShare.Name = "cmdShare";
            this.cmdShare.Size = new System.Drawing.Size(195, 23);
            this.cmdShare.TabIndex = 2;
            this.cmdShare.Text = " Поделиться текущей картой";
            this.cmdShare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdShare.UseVisualStyleBackColor = true;
            this.cmdShare.Click += new System.EventHandler(this.cmdShare_Click);
            // 
            // cmdUsers
            // 
            this.cmdUsers.FlatAppearance.BorderSize = 0;
            this.cmdUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUsers.ImageIndex = 3;
            this.cmdUsers.ImageList = this.imageList1;
            this.cmdUsers.Location = new System.Drawing.Point(8, 93);
            this.cmdUsers.Name = "cmdUsers";
            this.cmdUsers.Size = new System.Drawing.Size(195, 23);
            this.cmdUsers.TabIndex = 3;
            this.cmdUsers.Text = " Пользователи";
            this.cmdUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUsers.UseVisualStyleBackColor = true;
            this.cmdUsers.Click += new System.EventHandler(this.cmdUsers_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.FlatAppearance.BorderSize = 0;
            this.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHelp.ImageIndex = 4;
            this.cmdHelp.ImageList = this.imageList1;
            this.cmdHelp.Location = new System.Drawing.Point(8, 122);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(195, 23);
            this.cmdHelp.TabIndex = 4;
            this.cmdHelp.Text = " Помощь";
            this.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.FlatAppearance.BorderSize = 0;
            this.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLogin.ImageIndex = 5;
            this.cmdLogin.ImageList = this.imageList1;
            this.cmdLogin.Location = new System.Drawing.Point(8, 151);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(121, 23);
            this.cmdLogin.TabIndex = 5;
            this.cmdLogin.Text = " Войти в Synergy";
            this.cmdLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // checkBoxForgetMe
            // 
            this.checkBoxForgetMe.AutoSize = true;
            this.checkBoxForgetMe.Location = new System.Drawing.Point(41, 174);
            this.checkBoxForgetMe.Name = "checkBoxForgetMe";
            this.checkBoxForgetMe.Size = new System.Drawing.Size(93, 17);
            this.checkBoxForgetMe.TabIndex = 7;
            this.checkBoxForgetMe.Text = "Забыть меня";
            this.checkBoxForgetMe.UseVisualStyleBackColor = true;
            this.checkBoxForgetMe.Visible = false;
            // 
            // SynergyMenuDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 196);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxForgetMe);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdUsers);
            this.Controls.Add(this.cmdShare);
            this.Controls.Add(this.cmdPublish);
            this.Controls.Add(this.cmdExplorer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SynergyMenuDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExplorer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button cmdPublish;
        private System.Windows.Forms.Button cmdShare;
        private System.Windows.Forms.Button cmdUsers;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.CheckBox checkBoxForgetMe;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}