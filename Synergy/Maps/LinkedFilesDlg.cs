using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SynManager;
using Mindjet.MindManager.Interop;

namespace Maps
{
    internal partial class LinkedFilesDlg : Form
    {
        public LinkedFilesDlg(List<string> links, Document _doc)
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            checkedListBox.MouseHover += new EventHandler(checkedListBox_MouseHover);
            checkedListBox.MouseMove += new MouseEventHandler(checkedListBox_MouseMove);

            Text = MMUtils.GetString("linkedfilesdlg.dlgtitle.text");
            lblList.Text = MMUtils.GetString("linkedfilesdlg.lblList.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");

            _links = links;
            doc = _doc;
            aLocalPath = doc.Path + "\\"; // path to map folder

            foreach (string link in links)
            {
                string fn = System.IO.Path.GetFileName(link);
                checkedListBox.Items.Add(fn);             
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (int idx in checkedListBox.CheckedIndices)
            {
                string _pathorig = _links[idx];
                string _pathdest = aLocalPath + checkedListBox.Items[idx];
                try
                {
                    if (System.IO.File.Exists(_pathdest)) // TODO потом сделать диалог
                    {
                        if (MessageBox.Show(String.Format(MMUtils.GetString("linkedfilesdlg.fileexists.message"), ""), 
                        MMUtils.GetString("linkedfilesdlg.fileexists.caption"), 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            System.IO.File.Copy(_pathorig, _pathdest, true);
                    }
                    else
                        System.IO.File.Copy(_pathorig, _pathdest);
                }
                catch (Exception _e) // TODO cause!!! read-only, etc...
                {
                    MessageBox.Show(this, "Error " + _e.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            // TODO меняем ссылку в локальной карте
            foreach (Topic t in doc.Range(MmRange.mmRangeAllTopics))
            {
                if (t.Hyperlinks.Count > 0)
                {
                    foreach (Hyperlink h in t.Hyperlinks)
                    {
                        foreach (int idx in checkedListBox.CheckedIndices)
                        {
                            string _path = _links[idx];
                            if (h.Address == _path)
                            {
                                h.Address = checkedListBox.Items[idx].ToString();
                                h.Absolute = false;
                                break;
                            }
                        }
                    }
                }
            }

            doc.Save();
            _links.Clear();
        }

        private void checkedListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ttIndex != checkedListBox.IndexFromPoint(e.Location))
                ShowToolTip();
        }

        private void checkedListBox_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip();
        }

        private void ShowToolTip()
        {
            ttIndex = checkedListBox.IndexFromPoint(checkedListBox.PointToClient(MousePosition));
            if (ttIndex > -1)
                toolTip1.SetToolTip(checkedListBox, _links[ttIndex].ToString());
        }

        private List<string> _links;
        private int ttIndex;
        private string aLocalPath;
        private Document doc;
    }
}
