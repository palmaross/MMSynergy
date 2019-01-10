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
        public static bool IsConnected(string _site)
        {
            if (_site == "")
                _site = MMUtils.GetRegistry("", ""); // TODO!

            if (ConnectionAvailable(_site))
                return true;
            return false;
        }

        public static bool ConnectionAvailable(string strServer)
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
    }
}
