using System;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;

namespace Projects
{
    internal class ProjectsGroup
    {
        public void Create(ribbonTab myTab)
        {
            m_myTab = myTab;
            string imagePath = MMUtils.imagePath;

            m_rgProjects = m_myTab.Groups.Add(0, MMUtils.GetString("projects.group.name"), "www.palmaross.com", imagePath + "lists_s.png");

            m_cmdNewProject = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "NewProject");
            m_cmdNewProject.Caption = MMUtils.GetString("projects.commands.newproject.caption");
            m_cmdNewProject.ToolTip = MMUtils.GetString("projects.commands.newproject.tooltip") + "\n" + m_cmdNewProject.Caption;
            m_cmdNewProject.LargeImagePath = imagePath + "common_stock.png";
            m_cmdNewProject.ImagePath = imagePath + "audio.png";
            m_cmdNewProject.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdNewProject_UpdateState);
            m_cmdNewProject.Click += new ICommandEvents_ClickEventHandler(m_cmdNewProject_Click);
            m_ctrlNewProject = m_rgProjects.GroupControls.AddButton(m_cmdNewProject);

            m_cmdManageProjects = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ManageProjects");
            m_cmdManageProjects.Caption = MMUtils.GetString("projects.commands.manageprojects.caption");
            m_cmdManageProjects.ToolTip = MMUtils.GetString("projects.commands.manageprojects.tooltip") + "\n" + m_cmdManageProjects.Caption;
            m_cmdManageProjects.LargeImagePath = imagePath + "common_stock.png";
            m_cmdManageProjects.ImagePath = imagePath + "audio.png";
            m_cmdManageProjects.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdManageProjects_UpdateState);
            m_cmdManageProjects.Click += new ICommandEvents_ClickEventHandler(m_cmdManageProjects_Click);
            m_ctrlManageProjects = m_rgProjects.GroupControls.AddTwoPartButton(m_cmdManageProjects);

            m_cmdShareProjects = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ShareProjects");
            m_cmdShareProjects.Caption = MMUtils.GetString("projects.commands.shareprojects.caption");
            m_cmdShareProjects.ToolTip = MMUtils.GetString("projects.commands.shareprojects.tooltip") + "\n" + m_cmdShareProjects.Caption;
            m_cmdShareProjects.LargeImagePath = imagePath + "common_stock.png";
            m_cmdShareProjects.ImagePath = imagePath + "audio.png";
            m_cmdShareProjects.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdShareProjects_UpdateState);
            m_cmdShareProjects.Click += new ICommandEvents_ClickEventHandler(m_cmdShareProjects_Click);
            m_ctrlShareProjects = m_rgProjects.GroupControls.AddButton(m_cmdShareProjects);

            m_cmdShareProject = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ShareProject");
            m_cmdShareProject.Caption = MMUtils.GetString("projects.commands.shareproject.caption");
            m_cmdShareProject.ImagePath = imagePath + "audio.png";
            m_cmdShareProject.Click += new ICommandEvents_ClickEventHandler(m_cmdShareProject_Click);
            m_cmdShareProject.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdShareProject_UpdateState);
            m_ctrlShareProject = m_ctrlShareProjects.Controls.AddButton(m_cmdShareProject);

            m_cmdReceiveProject = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ReceiveProject");
            m_cmdReceiveProject.Caption = MMUtils.GetString("projects.commands.receiveproject.caption");
            m_cmdReceiveProject.ImagePath = imagePath + "audio.png";
            m_cmdReceiveProject.Click += new ICommandEvents_ClickEventHandler(m_cmdReceiveProject_Click);
            m_cmdReceiveProject.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdReceiveProject_UpdateState);
            m_ctrlReceiveProject = m_ctrlShareProjects.Controls.AddButton(m_cmdReceiveProject);
        }

        private void m_cmdNewProject_Click()
        {
            using (CreateProjectDlg _dlg = new CreateProjectDlg())
            {
                System.Windows.Forms.DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));

                if (result == System.Windows.Forms.DialogResult.OK)
                    System.Windows.Forms.MessageBox.Show(String.Format(
                        MMUtils.GetString("createprojectdlg.newprojectcreated.message"), _dlg.txtProjectName.Text));
            }
        }

        private void m_cmdNewProject_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdManageProjects_Click()
        {

        }

        private void m_cmdManageProjects_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdShareProjects_Click()
        {

        }

        private void m_cmdShareProjects_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdShareProject_Click()
        {

        }

        private void m_cmdShareProject_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdReceiveProject_Click()
        {

        }

        private void m_cmdReceiveProject_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        public void Destroy()
        {
            m_ctrlNewProject.Delete(); Marshal.ReleaseComObject(m_ctrlNewProject); m_ctrlNewProject = null;
            Marshal.ReleaseComObject(m_cmdNewProject); m_cmdNewProject = null;

            m_ctrlManageProjects.Delete(); Marshal.ReleaseComObject(m_ctrlManageProjects); m_ctrlManageProjects = null;
            Marshal.ReleaseComObject(m_cmdManageProjects); m_cmdManageProjects = null;

            m_ctrlShareProject.Delete(); Marshal.ReleaseComObject(m_ctrlShareProject); m_ctrlShareProject = null;
            Marshal.ReleaseComObject(m_cmdShareProject); m_cmdShareProject = null;
            m_ctrlReceiveProject.Delete(); Marshal.ReleaseComObject(m_ctrlReceiveProject); m_ctrlReceiveProject = null;
            Marshal.ReleaseComObject(m_cmdReceiveProject); m_cmdReceiveProject = null;
            m_ctrlShareProjects.Delete(); Marshal.ReleaseComObject(m_ctrlShareProjects); m_ctrlShareProjects = null;
            Marshal.ReleaseComObject(m_cmdShareProjects); m_cmdShareProjects = null;

            m_rgProjects.Delete();
            m_myTab = null;
        }

        private ribbonTab m_myTab = null;
        private RibbonGroup m_rgProjects = null;

        private Command m_cmdNewProject = null;
        private Control m_ctrlNewProject = null;

        private Command m_cmdManageProjects = null;
        private Control m_ctrlManageProjects = null;

        private Command m_cmdShareProjects = null;
        private Control m_ctrlShareProjects = null;
        private Command m_cmdShareProject = null;
        private Control m_ctrlShareProject = null;
        private Command m_cmdReceiveProject = null;
        private Control m_ctrlReceiveProject = null;
    }
}
