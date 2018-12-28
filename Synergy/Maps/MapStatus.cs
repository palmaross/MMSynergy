using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mindjet.MindManager.Interop;
using SynManager;
using System.Windows.Forms;

namespace Maps
{
    internal class MapStatus
    {
        public static void SetOnlineStatus(string _cause, string _name)
        {
            if (_cause == "process")
            {
                foreach (MapTimers item in MapsGroup.TIMERS)
                    if (_name == item.m_Process)
                    {
                        item.waitTime = DateTime.UtcNow.AddSeconds(item.secToWait).ToLocalTime().ToShortTimeString();
                        item.m_Status = "waitonline";
                        item.waitingOnline_timer.Start();

                        if (item.doc == MMUtils.ActiveDocument)
                            item.refresh = true; // for refreshIndicator_timer
                    }
            }
            if (_cause == "process")
            {
                foreach (MapTimers item in MapsGroup.TIMERS)
                    if (_name == item.m_Process)
                    {
                        item.waitTime = DateTime.UtcNow.AddSeconds(item.secToWait).ToLocalTime().ToShortTimeString();
                        item.m_Status = "waitonline";
                        item.waitingOnline_timer.Start();

                        if (item.doc == MMUtils.ActiveDocument)
                            item.refresh = true; // for refreshIndicator_timer
                    }
            }
        }

        public static void SetOfflineStatus(string _cause, string _name)
        {
            Document _doc = null;

            foreach (Watchers _item in MapsGroup.WATCHERS)
                if (_item.aMapGuid == _guid)
                {
                    _doc = _item.doc;
                    _item.Dispose();
                    MapsGroup.WATCHERS.Remove(_item);
                    break;
                }

            DocumentStorage.Sync(_doc, false); // Unsubscribe this map

            foreach (MapTimers item in MapsGroup.TIMERS)
            {
                if (_guid == item.m_Guid)
                {
                    item.m_Status = "offline";
                    item.m_FrozenTime = Convert.ToInt64(SUtils.modtime);
                    //item.m_OfflineCause += _cause;

                    item.saveMap_timer.Stop();
                    item.checkOnlineUsers_timer.Stop();

                    System.IO.File.Copy(item.m_LocalPath, item.m_FrozenPath, true);

                    string docName = item.doc.Name;
                    string messageSite = MMUtils.GetString("internet.sitefailed.message");
                    string messageProcess = MMUtils.GetString("internet.processfailed.message");
                    string messagePlace = MMUtils.GetString("internet.placefail.message");
                    string endMessage = MMUtils.GetString("internet.failed.endmessage");

                    string _message = "", arg = "";

                    if (_cause == "process") { _message = messageProcess; arg = item.m_Storage; }
                    else if (_cause == "place") { _message = messagePlace; arg = item.m_PlacePath; }
                    else if (_cause == "site") { _message = messageSite; arg = item.m_Site; }

                    MessageBox.Show(
                        String.Format(_message, arg) + endMessage,
                        String.Format(MMUtils.GetString("internet.failed.caption"), item.doc.Name),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    System.IO.File.SetAttributes(item.m_LocalPath, System.IO.FileAttributes.ReadOnly);

                    if (item.doc == MMUtils.ActiveDocument)
                        item.refresh = true; // for refreshIndicator_timer

                    break;
                }
            }
        }
    }
}
