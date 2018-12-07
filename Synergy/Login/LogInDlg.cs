using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Login
{
    public partial class LogInDlg : Form
    {
        public LogInDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "start.htm");

            Text = MMUtils.GetString("loginDlg.dlgtitle.text");
            linkRegister.Text = MMUtils.GetString("loginDlg.linkRegister.text");
            lblEmail.Text = MMUtils.GetString("loginDlg.lblEmail.text");
            lblPassword.Text = MMUtils.GetString("loginDlg.lblPassword.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            checkBoxRemember.Text = MMUtils.GetString("loginDlg.checkBoxRemember.text");
            linkForgetPassword.Text = MMUtils.GetString("loginDlg.linkForgetPassword.text");

            lblUserNoExists.Text = "";
            lblPasswordNoMatch.Text = "";

            this.Location = new System.Drawing.Point(MMUtils.MindManager.Left + MMUtils.MindManager.Width - this.Width-280,
                            MMUtils.MindManager.Top + MMUtils.MindManager.Height - this.Height-17);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool passed = false;
            bool userfound = false;
            string loginoremail = "LOGIN";
            aEmail = txtEmail.Text;

            if (txtEmail.Text == "")
                lblEmail.ForeColor = System.Drawing.Color.Red;
            else if (txtPassword.Text == "")
                lblPassword.ForeColor = System.Drawing.Color.Red;
            else
            {
                if (Internet.EmailIsValid(txtEmail.Text) == true)
                    loginoremail = "EMAIL";

                UsersDB _db = new UsersDB();
                DataTable _dt = _db.ExecuteQuery("select * from USERS");
                foreach (DataRow _row in _dt.Rows)
                {
                    if (_row[loginoremail].ToString() == txtEmail.Text) // user found
                    {
                        userfound = true;
                        aName = _row["NAME"].ToString();
                        aEmail = _row["EMAIL"].ToString();
                        if (_row["PASS"].ToString() == txtPassword.Text) // TODO password decrypt?
                        {
                            passed = true;
                            MMUtils.SetRegistry("", "CurrentUserName", aName);
                            MMUtils.SetRegistry("", "CurrentUserEmail", aEmail);
                            if (checkBoxRemember.Checked == true)
                            {
                                MMUtils.SetRegistry("", "RememberMe", "1");
                                MMUtils.SetRegistry("", "RememberedUserName", aName);
                                MMUtils.SetRegistry("", "RememberedUserEmail", aEmail);
                            }
                            break;
                        }
                        else //password wrong
                        {
                            string _arg = MMUtils.GetString("loginDlg.login.text");
                            if (loginoremail == "EMAIL")
                                _arg = MMUtils.GetString("loginDlg.Email.text");
                            lblPasswordNoMatch.Text = String.Format(MMUtils.GetString("loginDlg.wrongpassword.text"), _arg);
                        }
                    }
                }

                _db.Dispose();

                if (!userfound)
                    lblUserNoExists.Text = MMUtils.GetString("loginDlg.usernoexists.text");

                if (passed)
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void linkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO отправить письмо с паролем
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (NewUserDlg _dlg = new NewUserDlg())
            {
                DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                if (result != DialogResult.Cancel)
                {
                    txtEmail.Text = NewUserDlg.aLogin;
                    txtPassword.Text = NewUserDlg.aPassword;
                }
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            lblEmail.ForeColor = System.Drawing.Color.Black;
            lblUserNoExists.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            lblPassword.ForeColor = System.Drawing.Color.Black;
            lblPasswordNoMatch.Text = "";
        }

        public static string aName = "";
        public static string aEmail = "";
    }
}
