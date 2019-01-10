using System;
using SynManager;
using System.Windows.Forms;

namespace Maps
{
    internal class MapStatus
    {
        public static void SetOnlineStatus(MapTimers _map, bool _wait = true)
        {
            if (_wait)
            {
                _map.m_Status = "waitonline";
                _map.waitingOnline_timer.Start();
                return;
            }

            _map.m_Status = "online";
            MapWatchers MW = new MapWatchers(_map.m_PlacePath)
            {
                doc = _map.doc,
                MapGuid = _map.m_Guid
            };
            MapsGroup.MAPWATCHERS.Add(MW);

            DocumentStorage.Sync(_map.doc, true, _map.m_PlacePath); // subscribe map

            System.IO.File.SetAttributes(_map.m_LocalPath, System.IO.FileAttributes.Normal);

            if (_map.doc == MMUtils.ActiveDocument)
                _map.RefreshIndicator = true; // for refreshIndicator_timer
        }

        public static void SetOfflineStatus(MapTimers _map, bool _wait = false)
        {
            _map.m_Status = "offline";

            foreach (MapWatchers _item in MapsGroup.MAPWATCHERS)
                if (_item.MapGuid == _map.m_Guid)
                {
                    _item.Dispose();
                    MapsGroup.MAPWATCHERS.Remove(_item);
                    break;
                }

            DocumentStorage.Sync(_map.doc, false); // Unsubscribe this map

            _map.m_Status = "offline";
            _map.m_FrozenTime = Convert.ToInt64(SUtils.modtime);
            //item.m_OfflineCause += _cause;

            _map.saveMap_timer.Stop();
            _map.checkOnlineUsers_timer.Stop();

            System.IO.File.Copy(_map.m_LocalPath, _map.m_FrozenPath, true);

            string docName = _map.doc.Name;
            string messageSite = MMUtils.GetString("internet.sitefailed.message");
            string messageProcess = MMUtils.GetString("internet.processfailed.message");
            string messagePlace = MMUtils.GetString("internet.placefail.message");
            string endMessage = MMUtils.GetString("internet.failed.endmessage");

            string _message = "", arg = "";

            if (_map.m_Process != string.Empty) { _message = messageProcess; arg = _map.m_Storage; }
            else if (_map.m_Storage == "ND") { _message = messagePlace; arg = _map.m_PlacePath; }
            else if (_map.m_Site != string.Empty) { _message = messageSite; arg = _map.m_Site; }

            MessageBox.Show(
                String.Format(_message, arg) + endMessage,
                String.Format(MMUtils.GetString("internet.failed.caption"), _map.doc.Name),
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            System.IO.File.SetAttributes(_map.m_LocalPath, System.IO.FileAttributes.ReadOnly);

            if (_map.doc == MMUtils.ActiveDocument)
                _map.RefreshIndicator = true; // for refreshIndicator_timer
        }       
    }
}
