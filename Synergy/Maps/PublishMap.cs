using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mindjet.MindManager.Interop;
using SynManager;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Maps
{
    internal class PublishMap
    {
        public bool Publish(Document publishDoc, string aPlace, string aMapPathInPlace)
        {
            string _docName = publishDoc.Name;
            string aGuid = publishDoc.Guid;
            string aLocalPath = ""; // path to map in Local Storage
            string aPath = "";      // full path to published map
            string aSite = "";      // website to check for Internet connection
            string aProcess = "";   // cloud app process to check if started
            string aPlacePath = "", aStorage = "";

            if (publishDoc.Path == "") // new map not saved yet
            {
                using (NewMapDlg _dlg = new NewMapDlg())
                {
                    if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                        return false;
                    _docName = _dlg.textBox_MapName.Text + ".mmap";
                }
            }

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME=`" + aPlace + "`");
                aPlacePath = _dt.Rows[0]["PLACEPATH"].ToString();
                aSite = _dt.Rows[0]["SITE"].ToString();
                aProcess = _dt.Rows[0]["PROCESS"].ToString();
                aStorage = _dt.Rows[0]["STORAGE"].ToString();
            }

            if (File.Exists(aMapPathInPlace + _docName)) // map with this name is stored already in this place
            {
                MessageBox.Show(
                    MMUtils.GetString("publishmapdlg.mapexists.message"),
                    MMUtils.GetString("publishmapdlg.mapexists.caption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DirectoryInfo di = Directory.CreateDirectory(MMUtils.m_SynergyLocalPath + aGuid);
            aLocalPath = di.FullName + "\\" + _docName;

            string fail = "";

            string messageSite = MMUtils.GetString("internet.sitefailed.message");
            string messageProcess = MMUtils.GetString("internet.processfailed.message");
            string messagePlace = MMUtils.GetString("internet.network.message");
            string endMessage = MMUtils.GetString("internet.failed.endpubmessage");

            if (aStorage == "ND") // Network disk
            {

            }
            else if (aStorage == "synergysite" || aStorage == "usersite")
            {

            }
            else // Cloud storage
            {

            }

                while ((fail = Internet.CheckInternetAndProcess(aGuid, aStorage, aProcess, aSite, aPlacePath, "publish")) != "")
            {
                string _message = "", arg = "";

                if (fail == "processfail") { _message = messageProcess; arg = aProcess; }
                else if (fail == "networkfail") { _message = messagePlace; arg = aPlacePath; }
                else if (fail == "sitefail") { _message = messageSite; arg = aSite; }

                if (MessageBox.Show(
                    String.Format(_message, arg) + endMessage,
                    String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
                    == DialogResult.Cancel)
                {
                    return false;
                }

                if (fail == "sitefail")
                    System.Diagnostics.Process.Start(arg); // launch website
            }

            try // Save map to Local
            {
                publishDoc.SaveAs(aLocalPath);
            }
            catch (Exception _e) // TODO cause!!! read-only, etc... имя файла уже исключено выше
            {
                MessageBox.Show("Error: " + _e.Message, "PublishMapDlg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //// Publish Map = set attributes to map, topics, relationships and boundaries and process links ////
            Transaction _tr = publishDoc.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(SUtils.PublishMap);
            _tr.Start();
            ///////////////////////////////////////////////////////////////////////////////////

            publishDoc.Save();

            if (SUtils.links.Count > 0)
            {
                using (LinkedFilesDlg _dlg = new LinkedFilesDlg(SUtils.links, publishDoc))
                {
                    DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    SUtils.links.Clear();
                    if (result == DialogResult.Cancel)
                        return false;
                }
            }

            aPath = aPath + "\\"; // Map folder
            string mapFile = SUtils.modtime + ".mmap";

            try // save map to Place
            {
                Directory.CreateDirectory(aPath + "share");
                File.Copy(aLocalPath, aPath + mapFile); // copy as file!!!

                StreamWriter sw = new StreamWriter(File.Create(aPath + "info.ini"));
                //sw.WriteLine(aStorage); // чтобы если нет Интернета или Процесса, выдать сообщение с именем хранилища 
                sw.WriteLine(aGuid);
                sw.WriteLine(aProcess); // чтобы проверить Интернет и Процесс
                sw.WriteLine(aSite);    // чтобы проверить Интернет и Процесс
                sw.Close();
            }
            catch (Exception _e) // TODO cause!!! read-only, etc...
            {
                MessageBox.Show("Error " + _e.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MapsDB.AddMapToDB("", aGuid, _docName, aPath, // aPath - map directory in Place, with backslash
                aLocalPath, SUtils.currentUserName, 0, Convert.ToInt32(DateTime.UtcNow), Convert.ToInt32(DateTime.UtcNow)
            );

            SUtils.ProcessMap(publishDoc);

            // TODO Занести в Synergy Explorer!

            // Share map
            using (ShareDlg _dlg = new ShareDlg(MMUtils.ActiveDocument.Name, aPath, "", "")) // TODO !
            {
                _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
            }
            return true;
        }
    }
}
