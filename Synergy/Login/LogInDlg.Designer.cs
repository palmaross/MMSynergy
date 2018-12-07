namespace Login
{
    partial class LogInDlg
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserNoExists = new System.Windows.Forms.Label();
            this.linkForgetPassword = new System.Windows.Forms.LinkLabel();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.lblPasswordNoMatch = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 33);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Login or Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(18, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Click += new System.EventHandler(this.txtEmail_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(18, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(223, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.Location = new System.Drawing.Point(18, 150);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(77, 17);
            this.checkBoxRemember.TabIndex = 6;
            this.checkBoxRemember.Text = "Remember";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(18, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(166, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUserNoExists
            // 
            this.lblUserNoExists.AutoSize = true;
            this.lblUserNoExists.ForeColor = System.Drawing.Color.Red;
            this.lblUserNoExists.Location = new System.Drawing.Point(15, 74);
            this.lblUserNoExists.Name = "lblUserNoExists";
            this.lblUserNoExists.Size = new System.Drawing.Size(65, 13);
            this.lblUserNoExists.TabIndex = 9;
            this.lblUserNoExists.Text = "usernoexists";
            // 
            // linkForgetPassword
            // 
            this.linkForgetPassword.AutoSize = true;
            this.linkForgetPassword.Location = new System.Drawing.Point(15, 171);
            this.linkForgetPassword.Name = "linkForgetPassword";
            this.linkForgetPassword.Size = new System.Drawing.Size(91, 13);
            this.linkForgetPassword.TabIndex = 10;
            this.linkForgetPassword.TabStop = true;
            this.linkForgetPassword.Text = "Забыли пароль?";
            this.linkForgetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPassword_LinkClicked);
            // 
            // linkRegister
            // 
            this.linkRegister.AutoSize = true;
            this.linkRegister.Location = new System.Drawing.Point(16, 9);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(229, 13);
            this.linkRegister.TabIndex = 11;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "Первый раз в Synergy? Зарегистрируйтесь!";
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // lblPasswordNoMatch
            // 
            this.lblPasswordNoMatch.AutoSize = true;
            this.lblPasswordNoMatch.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordNoMatch.Location = new System.Drawing.Point(15, 131);
            this.lblPasswordNoMatch.Name = "lblPasswordNoMatch";
            this.lblPasswordNoMatch.Size = new System.Drawing.Size(81, 13);
            this.lblPasswordNoMatch.TabIndex = 12;
            this.lblPasswordNoMatch.Text = "passwordwrong";
            // 
            // LogInDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 238);
            this.ControlBox = false;
            this.Controls.Add(this.lblPasswordNoMatch);
            this.Controls.Add(this.linkRegister);
            this.Controls.Add(this.linkForgetPassword);
            this.Controls.Add(this.lblUserNoExists);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "LogInDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserNoExists;
        private System.Windows.Forms.LinkLabel linkForgetPassword;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Label lblPasswordNoMatch;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}