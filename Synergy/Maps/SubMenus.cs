using System;
using System.Linq;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;
using System.IO;

namespace Maps
{
    internal class SubMenus
    {
        private string imagePath = MMUtils.imagePath;
        public void AddMapToOpenMenu(string mapGuid, string mapname, string aID)
        {
            m_command = CreateCommand(aID);
            m_command.Caption = mapname;
            m_command.ToolTip = mapGuid;
            m_command.ImagePath = imagePath + "mapfile.png";
            m_command.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_command_UpdateState);
            m_command.Click += new ICommandEvents_ClickEventHandler(m_command_Click);
            //m_control = MapsGroup.m_ctrlOpenMaps.Controls.AddButton(m_command);
        }

        public void m_command_Click() // open map
        {
            string aMapGuid = m_command.ToolTip;
            string _mapName = m_command.Caption;
            string _mapPlacePath = "";
            string aStorage = "";
            string _mapLocalPath = "";
            bool mapnotfound = true;
            string aProject = "";

            using (MapsDB _db = new MapsDB())
            {
                System.Data.DataTable _dt = _db.ExecuteQuery("select * from MAPS where MAPGUID=`" + aMapGuid + "`");
                if (_dt.Rows.Count != 0)
                {
                    mapnotfound = false;
                    _mapLocalPath = _dt.Rows[0]["LOCALPATH"].ToString();
                    _mapPlacePath = _dt.Rows[0]["PATHTOPLACE"].ToString();
                    aStorage = _dt.Rows[0]["STORAGE"].ToString();
                    aProject = _dt.Rows[0]["PROJECTNAME"].ToString();
                }
            }

            if (mapnotfound)
            {
                System.Windows.Forms.MessageBox.Show( String.Format(MMUtils.GetString("maps.mapnoexists.message"), _mapName),
                    MMUtils.GetString("maps.mapnoexists.caption"));
                return; // TODO нужно предложить удалить ее - из БД и из меню
            }

            // if map is opened already
            foreach (Document _map in MMUtils.MindManager.AllDocuments)
                if (SUtils.SynergyMapGuid(_map) == aMapGuid)
                {
                    _map.Activate();
                    return;
                }

            if (Directory.Exists(_mapPlacePath)) // TODO если по причине неподключенного сетевого диска - 
            {              
                string _latestfile = Directory.GetFiles(_mapPlacePath, "*.mmap").Last().ToString();
                long localmap_lastwrite = Convert.ToInt64(File.GetLastWriteTimeUtc(_mapLocalPath).ToString("yyyyMMddHHmmssfff"));
                long placemap_time = Convert.ToInt64(Path.GetFileNameWithoutExtension(_latestfile));

                // Check if map in Place is newer than local map, if yes - replace local map
                if (placemap_time > localmap_lastwrite)
                {
                    try
                    {
                        File.Copy(_latestfile, _mapLocalPath, true); // copy (overwrite) map from its Place to local Synergy
                    }
                    catch { } // TODO 
                }               
            }

            DocumentStorage.reopenmap = false;
            File.SetAttributes(_mapLocalPath, FileAttributes.Normal);
            MMUtils.MindManager.AllDocuments.Open(_mapLocalPath);
        }

        public void m_command_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private Command CreateCommand(string aID)
        {
            Command command = null;
            for (int i = 1; i <= MMUtils.MindManager.Commands.Count; i++)
            {
                command = MMUtils.MindManager.Commands[i];
                if (command.RegisteredAddInName == MMUtils.AddinName && command.RegisteredName == aID)
                {
                    return command;
                }
                else
                {
                    Marshal.ReleaseComObject(command);
                    command = null;
                }
            }

            return MMUtils.MindManager.Commands.Add(MMUtils.AddinName, aID);
        }

        public void Destroy()
        {
            if (m_control != null)
                m_control.Delete(); Marshal.ReleaseComObject(m_control); m_control = null;

            if (m_command != null)
            {
                m_command.Click -= m_command_Click;
                m_command.UpdateState -= m_command_UpdateState;
                Marshal.ReleaseComObject(m_command); m_command = null;
            }
        }

        public Command m_command = null;
        public Control m_control = null;
    }

}
