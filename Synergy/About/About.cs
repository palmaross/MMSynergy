using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;

namespace About
{
    class AboutGroup
    {
        public void Create(ribbonTab myTab)
        {
            m_myTab = myTab;
            string imagePath = MMUtils.imagePath;

            m_rgMaps = m_myTab.Groups.Add(0, MMUtils.GetString("about.group.name"), "www.palmaross.com", imagePath + "lists_s.png");

            m_cmdHelp = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "SynergyHelp");
            m_cmdHelp.Caption = MMUtils.GetString("about.commands.help.caption");
            m_cmdHelp.ToolTip = MMUtils.GetString("about.commands.help.tooltip") + "\n" + m_cmdHelp.Caption;
            m_cmdHelp.LargeImagePath = MMUtils.imagePath + "common_stock.png";
            m_cmdHelp.ImagePath = imagePath + "audio.png";
            m_cmdHelp.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdHelp_UpdateState);
            m_cmdHelp.Click += new ICommandEvents_ClickEventHandler(m_cmdHelp_Click);
            m_ctrlHelp = m_rgMaps.GroupControls.AddButton(m_cmdHelp);
        }

        private void m_cmdHelp_Click() 
        {
            string instPath = MMUtils.GetRegistry("", "InstPath");
            string chmPath = instPath + "\\Synergy.chm";

            System.Diagnostics.Process.Start(chmPath);
        }

        public void m_cmdHelp_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        public void Destroy()
        {
            m_ctrlHelp.Delete(); Marshal.ReleaseComObject(m_ctrlHelp); m_ctrlHelp = null;
            Marshal.ReleaseComObject(m_cmdHelp); m_cmdHelp = null;

            m_rgMaps.Delete();
            m_myTab = null;
        }

        public static ribbonTab m_myTab = null;
        private RibbonGroup m_rgMaps = null;

        private Command m_cmdHelp = null;
        public static Control m_ctrlHelp = null;
    }
}
