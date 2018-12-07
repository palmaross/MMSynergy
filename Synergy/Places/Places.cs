using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;
using System.IO;
using System.Data;

namespace Places
{
    class PlacesGroup
    {
        public void Create(ribbonTab myTab)
        {
            m_myTab = myTab;
            string imagePath = MMUtils.imagePath;

            try
            {
                m_rgPlaces = m_myTab.Groups.Add(0, MMUtils.GetString("places.group.name"), "www.palmaross.com", imagePath + "lists_s.png");

                m_cmdNewPlace = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "NewPlace");
                m_cmdNewPlace.Caption = MMUtils.GetString("places.commands.newplace.caption");
                m_cmdNewPlace.ToolTip = MMUtils.GetString("places.commands.newplace.tooltip") + "\n" + m_cmdNewPlace.Caption;
                m_cmdNewPlace.LargeImagePath = MMUtils.imagePath + "common_stock.png";
                m_cmdNewPlace.ImagePath = imagePath + "audio.png";
                m_cmdNewPlace.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdNewPlace_UpdateState);
                m_cmdNewPlace.Click += new ICommandEvents_ClickEventHandler(m_cmdNewPlace_Click);
                m_ctrlNewPlace = m_rgPlaces.GroupControls.AddButton(m_cmdNewPlace);

                m_cmdManagePlaces = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ManagePlaces");
                m_cmdManagePlaces.Caption = MMUtils.GetString("places.commands.manageplaces.caption");
                m_cmdManagePlaces.ToolTip = MMUtils.GetString("places.commands.manageplaces.tooltip") + "\n" + m_cmdManagePlaces.Caption;
                m_cmdManagePlaces.LargeImagePath = MMUtils.imagePath + "common_stock.png";
                m_cmdManagePlaces.ImagePath = imagePath + "audio.png";
                m_cmdManagePlaces.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdManagePlaces_UpdateState);
                m_cmdManagePlaces.Click += new ICommandEvents_ClickEventHandler(m_cmdManagePlaces_Click);
                m_ctrlManagePlaces = m_rgPlaces.GroupControls.AddTwoPartButton(m_cmdManagePlaces);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        void m_cmdNewPlace_Click() 
        {
            using (NewPlaceDlg _dlg = new NewPlaceDlg())
            {
                if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == System.Windows.Forms.DialogResult.OK)
                    System.Windows.Forms.MessageBox.Show(MMUtils.GetString("places.placecreated.message"));
            }
        }

        void m_cmdNewPlace_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        void m_cmdManagePlaces_Click()
        {
            
        }

        void m_cmdManagePlaces_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        public void Destroy()
        {
            m_ctrlNewPlace.Delete(); Marshal.ReleaseComObject(m_ctrlNewPlace); m_ctrlNewPlace = null;
            Marshal.ReleaseComObject(m_cmdNewPlace); m_cmdNewPlace = null;

            m_ctrlManagePlaces.Delete(); Marshal.ReleaseComObject(m_ctrlManagePlaces); m_ctrlManagePlaces = null;
            Marshal.ReleaseComObject(m_cmdManagePlaces); m_cmdManagePlaces = null;

            m_rgPlaces.Delete();
            m_myTab = null;
        }

        private ribbonTab m_myTab = null;
        private RibbonGroup m_rgPlaces = null;

        private Command m_cmdNewPlace = null;
        public static Control m_ctrlNewPlace = null;
        private Command m_cmdManagePlaces = null;
        public static Control m_ctrlManagePlaces = null;
    }
}
