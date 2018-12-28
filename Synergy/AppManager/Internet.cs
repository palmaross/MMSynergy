using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Mindjet.MindManager.Interop;

namespace SynManager
{
    internal class Internet
    {
        public static string CheckInternetAndProcess(string _guid, string _site, string _placepath, string _cause)
        {
            // For cloud and network
            if (_placepath != "")
                if (System.IO.Directory.Exists(_placepath))
                {
                    if (Places.Contains(_placepath))
                    {
                        Places.Remove(_placepath);

                        if (_cause != "publish")
                            Maps.MapStatus.SetOnlineStatus(_guid, null);
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
                            Maps.MapStatus.SetOfflineStatus(_guid, "place");

                        return "placefail";
                    }
                }

            // For cloud storages
            if (_site != "") // todo!
                if (InternetConnection(_site))
                {
                    if (Sites.Contains(_site))
                    {
                        Sites.Remove(_site);

                        if (_cause != "publish")
                            Maps.MapStatus.SetOnlineStatus(_guid, null);
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
                            Maps.MapStatus.SetOfflineStatus(_guid, "site");

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

            // Alternative!
            //try
            //{
            //    using (WebClient client = new WebClient())
            //    {
            //        using (client.OpenRead("http://www.google.com/"))
            //        {
            //            return true;
            //        }
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
        }

        private static List<string> Places = new List<string>();
        private static List<string> Sites = new List<string>();
    }
}
