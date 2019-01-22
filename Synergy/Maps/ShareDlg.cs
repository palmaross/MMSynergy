using System;
using System.Windows.Forms;
using SynManager;
using System.Collections.Generic;
using System.Linq;

namespace Maps
{
    internal partial class ShareDlg : Form
    {
        /// <summary>
        /// Share item: map, project or folder
        /// </summary>
        /// <param name="_foldername">shared folder name or folder where shared map is located</param>
        /// <param name="_folderPath">Place: shared folder path</param>
        /// <param name="_placetype">cloud, ND or site</param>
        /// <param name="_storage">cloud storage name</param>
        /// <param name="_cryptpath">crypted network or site path</param>
        public ShareDlg(string _foldername, string _folderPath, string _storage, string _what, string _cryptpath = "")
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "share.htm");

            Text = MMUtils.GetString("sharemapdlg.dlgtitle.text");           
            lblFolderToShare.Text = MMUtils.GetString("sharemapdlg.lblFolderToShare.text");
            lblPath.Text = _folderPath;
            btnOpenFolder.Text = MMUtils.GetString("sharemapdlg.btnOpenFolder.text");
            groupBoxEmail.Text = MMUtils.GetString("sharemapdlg.groupBoxEmail.text");
            lblShareWhom.Text = MMUtils.GetString("sharemapdlg.lblShareWhom.text");
            txtEmails.Text = MMUtils.GetString("sharemapdlg.txtEmails.text");
            lblTheme.Text = MMUtils.GetString("sharemapdlg.lblTheme.text");
            lblMessage.Text = MMUtils.GetString("sharemapdlg.lblMessage.text");

            linkLabelChangeTemplate.Text = MMUtils.GetString("sharemapdlg.linkLabelChangeTemplate.text");
            btnOK.Text = MMUtils.GetString("sharemapdlg.btnOK.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            
            if (_storage == "ND")
            {
                txtMessage.Text = MMUtils.GetString("sharemapdlg.txtMessage.nd.text");
                this.Height = this.Height - panel1.Height;
            }
            else if (_storage == "synergysite")
            {
                this.Height = this.Height - panel1.Height;
            }
            else if (_storage == "usersite")
            {
                this.Height = this.Height - panel1.Height;
            }
            else // Cloud storage
            {
                txtMessage.Text = MMUtils.GetString("sharemapdlg.txtMessage.cloud.text");               
            }

            // TODO в _cryptpath засунуть ссылку! Если это облако, то всовывается "synergymap"
            string _message = txtMessage.Text;
            _message.Replace("#folder#", _foldername).Replace("#cloud#", _storage).Replace("#link#", _cryptpath);

            listBoxUsers.Visible = false;

            using (UsersDB _db = new UsersDB())
            {
                System.Data.DataTable _dt = _db.ExecuteQuery("select * from USERS order by NAME");
                foreach (System.Data.DataRow _row in _dt.Rows)
                {
                    if (_row["EMAIL"].ToString() != SUtils.currentUserName) // TODO а может и себя добавлять?
                    {
                        listBoxUsers.Items.Add(_row["NAME"].ToString() + "<" + _row["EMAIL"].ToString() + ">");
                    }
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(lblPath.Text))
            {
                string argument = "/select, \"" + lblPath.Text + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        private void btnClickUsers_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.Visible == false)
            {
                listBoxUsers.Visible = true;
                listBoxUsers.BringToFront();
            }
            else
            {
                listBoxUsers.Visible = false;
                listBoxUsers.SendToBack();
            }
        }

        List<string> checkedItems = new List<string>();
        private void listBoxUsers_Click(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(listBoxUsers.Items[e.Index].ToString());
            else
                checkedItems.Remove(listBoxUsers.Items[e.Index].ToString());

            // rewrite emails list
            string emails = "";
            foreach (string item in checkedItems)
            {
                string email = item.Substring(item.IndexOf("<"));
                email = email.Substring(0, email.Length - 1);
                emails = emails + email + ", ";
            }
            txtEmails.Text = emails.Substring(0, emails.Length - 2); // clean last comma
        }

        private void txtEmails_Click(object sender, EventArgs e)
        {
            if (txtEmails.ForeColor == System.Drawing.Color.Gray)
            {
                txtEmails.Text = "";
                txtEmails.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtEmails_TextChanged(object sender, EventArgs e)
        {
            if (txtEmails.ForeColor == System.Drawing.Color.Gray)
                txtEmails.ForeColor = System.Drawing.Color.Black;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEmails.Text == "")
            {
                lblShareWhom.ForeColor = System.Drawing.Color.Red;
                return;
            }
            string mails = txtEmails.Text;
            string theme = txtTheme.Text;
            string body = txtMessage.Text;
            mails = mails.Replace(", ", ",");
            body = body.Replace(" ", "%20").Replace("\r", "%0D").Replace("\n", "%0A");

            string mailto = "mailto:" + mails + "?subject=" + theme + "&body=" + body;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = mailto;
            proc.Start();
        }
    }
}
