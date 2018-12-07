using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Diagnostics;
using Mindjet.MindManager.Interop;

namespace SynManager
{
    public class Internet
    {
        public static string CheckInternetAndProcess(
            string _guid, string _storage, string _process, string _site, string _placepath, string _cause)
        {
            // For cloud storages
            if (_process != "")
                if (CloudProcessLaunched(_process, _storage))
                {
                    if (Processes.Contains(_process))
                    {
                        Processes.Remove(_process);

                        if (_cause != "publish")
                            SetOnlineStatus(_guid);
                    }
                }
                else
                {
                    if (Processes.Contains(_process))
                    {
                        if (_cause == "publish")
                            return "processfail";
                        else
                            return ""; // не дергаться, потому что как было, так и есть
                    }
                    else
                    {
                        Processes.Add(_process);

                        if (_cause != "publish")
                            SetOfflineStatus(_guid, "process");

                        return "processfail";
                    }
                }

            // For cloud and network
            if (_placepath != "")
                if (System.IO.Directory.Exists(_placepath))
                {
                    if (Places.Contains(_placepath))
                    {
                        Places.Remove(_placepath);

                        if (_cause != "publish")
                            SetOnlineStatus(_guid);
                    }
                }
                else
                {
                    if (Places.Contains(_placepath))
                    {
                        if (_cause == "publish")
                            return "processfail";
                        else
                            return ""; // не дергаться, потому что как было, так и есть
                    }
                    else
                    {
                        Places.Add(_placepath);

                        if (_cause != "publish")
                            SetOfflineStatus(_guid, "place");

                        return "placefail";
                    }
                }

            // For cloud storages
            if (_site == "") // todo!
                if (InternetConnection(_site))
                {
                    if (Sites.Contains(_site))
                    {
                        Sites.Remove(_site);

                        if (_cause != "publish")
                            SetOnlineStatus(_guid);
                    }
                }
                else
                {
                    if (Sites.Contains(_site))
                    {
                        if (_cause == "publish")
                            return "processfail";
                        else
                            return ""; // не дергаться, потому что как было, так и есть
                    }
                    else
                    {
                        Sites.Add(_site);

                        if (_cause != "publish")
                            SetOfflineStatus(_guid, "site");

                        return "sitefail";
                    }
                }

            return "";
        }

        public static bool InternetConnection(string aSite)
        {
            //Maps.MapsGroup.InternetChecking.Show(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));

            bool connected = ConnectionAvailable(aSite);

            //Maps.MapsGroup.InternetChecking.Visible = false;

            if (connected)
                return true;
            else
                return false;
        }

        public static bool CloudProcessLaunched(string aProcess, string aStorage)
        {
            if (Process.GetProcessesByName(aProcess).Any())
                return true;
            else
                return false;
        }

        public static bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool ConnectionAvailable(string strServer = "https://www.google.com")
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
                reqFP.Timeout = 5000;
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();

                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Internet here
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // no Internet... no website?
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // no Internet
                return false;
            }
        }

        static void SetOnlineStatus(string _guid) // TODO 
        {
            foreach (Timers item in Maps.MapsGroup.TIMERS)
                if (_guid == item.m_Guid)
                {
                    if (Processes.Contains(item.m_Process) || 
                        Places.Contains(item.m_PlacePath)  ||
                        Sites.Contains(item.m_Site))
                        return;

                    item.waitTime = DateTime.UtcNow.AddSeconds(item.secToWait).ToLocalTime().ToShortTimeString();
                    item.m_Status = "waitonline";
                    item.waitOnline_timer.Start();

                    if (item.doc == MMUtils.ActiveDocument)
                        item.refresh = true; // for refreshIndicator_timer
                }
        }

        static void SetOfflineStatus(string _guid, string _cause) // TODO 
        {
            Document _doc = null;

            foreach (Watchers _item in Maps.MapsGroup.WATCHERS)
                if (_item.aMapGuid == _guid)
                {
                    _doc = _item.doc;
                    _item.Dispose();
                    Maps.MapsGroup.WATCHERS.Remove(_item);
                    break;
                }

            DocumentStorage.Sync(_doc, false); // Unsubscribe this map

            foreach (Timers item in Maps.MapsGroup.TIMERS)
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

                    if (_cause == "process")    { _message = messageProcess; arg = item.m_Storage; }
                    else if (_cause == "place") { _message = messagePlace;   arg = item.m_PlacePath; }
                    else if (_cause == "site")  { _message = messageSite;    arg = item.m_Site; }

                    System.Windows.Forms.MessageBox.Show(
                        String.Format(_message, arg) + endMessage,
                        String.Format(MMUtils.GetString("internet.failed.caption"), item.doc.Name),
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);

                    System.IO.File.SetAttributes(item.m_LocalPath, System.IO.FileAttributes.ReadOnly);
                  
                    if (item.doc == MMUtils.ActiveDocument)
                        item.refresh = true; // for refreshIndicator_timer

                    break;
                }
        }

        static List<string> Processes = new List<string>();
        static List<string> Places = new List<string>();
        static List<string> Sites = new List<string>();
    }
}
