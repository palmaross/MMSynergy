using System;
using System.Data;
using System.Windows.Forms;
using SynManager;

namespace Login
{
    internal partial class NewUserDlg : Form
    {
        public NewUserDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "start.htm");

            Text = MMUtils.GetString("newuserDlg.dlgtitle.text");
            lblPrompt.Text = MMUtils.GetString("newuserDlg.lblPrompt.text");
            lblName.Text = MMUtils.GetString("newuserDlg.lblName.text");
            lblLogin.Text = MMUtils.GetString("newuserDlg.lblLogin.text");
            lblPassword.Text = MMUtils.GetString("newuserDlg.lblPassword.text");
            lblRole.Text = MMUtils.GetString("newuserDlg.lblRole.text");
            rbtnAdmin.Text = MMUtils.GetString("newuserDlg.rbtnAdmin.text");
            rbtnDAdmin.Text = MMUtils.GetString("newuserDlg.rbtnDAdmin.text");
            rbtnMember.Text = MMUtils.GetString("newuserDlg.rbtnMember.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");

            toolTipName.SetToolTip(this.lblName, MMUtils.GetString("newuserDlg.name.tooltip"));
            toolTipLogin.SetToolTip(this.lblLogin, MMUtils.GetString("newuserDlg.login.tooltip"));
            toolTipEmail.SetToolTip(this.lblEmail, MMUtils.GetString("newuserDlg.email.tooltip"));
            toolTipPassword.SetToolTip(this.lblPassword, MMUtils.GetString("newuserDlg.password.tooltip"));
            toolTipAdmin.SetToolTip(this.rbtnAdmin, MMUtils.GetString("newuserDlg.admin.tooltip"));
            toolTipDAdmin.SetToolTip(this.rbtnDAdmin, MMUtils.GetString("newuserDlg.dadmin.tooltip"));
            toolTipMember.SetToolTip(this.rbtnMember, MMUtils.GetString("newuserDlg.member.tooltip"));

            txtName.Text = MMUtils.MindManager.Options.UserName;
            txtEmail.Text = MMUtils.MindManager.Options.UserEmail;

            lblRequired.Text = "";
            rbtnMember.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (LoginToSynergy.EmailIsValid(txtEmail.Text) == false)
            {
                lblRequired.Text = MMUtils.GetString("newuserDlg.wrongemail.text"); //wrong email format
            }
            else if (txtEmail.Text == "" || txtLogin.Text == "" || txtName.Text == "" || txtPassword.Text == "")
            {
                lblRequired.Text = MMUtils.GetString("newuserDlg.allfieldsrequired.text");
            }
            else
            {
                aLogin = txtLogin.Text;
                aPassword = txtPassword.Text; //TODO crypt password?
                lblRequired.Text = "";

                using (UsersDB dbUsers = new UsersDB())
                {
                    DataTable _dt = dbUsers.ExecuteQuery("select * from USERS");
                    foreach (DataRow _row in _dt.Rows)
                        if (_row["LOGIN"].ToString() == txtLogin.Text) //this login already exists!
                        {
                            lblRequired.Text = MMUtils.GetString("newuserDlg.loginexists.text");
                            break;
                        }
                        else if (_row["EMAIL"].ToString() == txtEmail.Text) //this email already exists!
                        {
                            lblRequired.Text = MMUtils.GetString("newuserDlg.emailexists.text");
                            break;
                        }
                }

                if (lblRequired.Text == "")
                {
                    string _role = "";
                    if (rbtnAdmin.Checked)
                        _role = "Admin";
                    else if (rbtnAdmin.Checked)
                        _role = "DAdmin";
                    else
                        _role = "Member";

                    using (UsersDB _db = new UsersDB())
                    {
                        _db.ExecuteNonQuery("INSERT INTO USERS VALUES(" +
                        "`" + txtName.Text + "`," +
                        "`" + txtEmail.Text + "`," +
                        "`" + aLogin + "`," +
                        "`" + aPassword + "`," +
                        "`" + _role + "`, ``, ``, 0, 0)");
                    }

                    //TODO может отправить письмо?
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        public static string aLogin = "";
        public static string aPassword = "";
    }
}
