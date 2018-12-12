using System;

namespace SynManager
{
    internal class UsersDB : DatabaseWrapper
    {
        public void KillDatabase()
        {
            try
            {
                System.IO.File.Delete(GetDatabaseName());
            }
            catch { }
        }

        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "users.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE USERS(NAME text, EMAIL text, LOGIN text, PASS text, ROLE text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }
    }

    internal class MapsDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "maps.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE MAPS(STORAGE text, PLACENAME text, PROJECTNAME text, MAPGUID text, MAPNAME text," +
                                 "PATHTOPLACE text, LOCALPATH text, PUBATTRS text," +
                                 "reserved1 text, reserved2 integer, reserved3 text, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }

        /// <summary>
        /// Add map to MapsDB
        /// </summary>
        /// <param name="aStorage">Storage name</param>
        /// <param name="aPlace">Place name</param>
        /// <param name="aProject">Project name</param>
        /// <param name="aGuid">Map Synergy guid</param>
        /// <param name="aMapName">Map file name</param>
        /// <param name="aPathToPlace">Path to map folder in Place - with backslash!</param>
        /// <param name="aLocalPath">Path to map in Local Storage</param>
        /// <param name="pubAttrs">date stamp + current user name + current user email</param>
        public static void AddMapToDB(string aStorage, string aPlace, string aProject, string aGuid, string aMapName,
                                      string aPathToPlace, string aLocalPath, string pubAttrs)
        {
            using (MapsDB _db = new MapsDB())
            {
                _db.ExecuteNonQuery("INSERT INTO MAPS VALUES(" +
                "`" + aStorage + "`," +
                "`" + aPlace + "`," +
                "`" + aProject + "`," +
                "`" + aGuid + "`," +
                "`" + aMapName + "`," +
                "`" + aPathToPlace + "`," +
                "`" + aLocalPath + "`," +
                "`" + pubAttrs + "`, ``, 0, ``, 0)");
            }
        }
    }

    internal class StoragesDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "storages.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE STORAGES(STORAGENAME text, PROCESS text, SITE text, TYPE text," + 
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");

            AddStorageToDB(MMUtils.GetString("storage1.text"), "OneDrive", "https://onedrive.live.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage2.text"), "googledrivesync", "https://drive.google.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage3.text"), "Dropbox", "https://www.dropbox.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage4.text"), "box", "https://www.box.com", "cloud"); // TODO site
            
            m_db.ExecuteNonQuery("END");
        }

        protected void AddStorageToDB(string aStorage, string aProcess, string aSite, string aType)
        {
            m_db.ExecuteNonQuery("insert into STORAGES values(" +
                "`" + aStorage + "`," +
                "`" + aProcess + "`," +
                "`" + aSite + "`," +
                "`" + aType + "`, ``, ``, 0, 0)");
        }
    }

    internal class PlacesDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "places.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE PLACES(STORAGE text, PLACENAME text, PLACEPATH text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");

            m_db.ExecuteNonQuery("END");
        }
    }

    internal class ProjectsDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "projects.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE PROJECTS(STORAGE text, PLACENAME text, PROJECTNAME text, PROJECTPATH text, LOCALPATH text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }

        public static void AddProjectToDB(string aStorage, string aPlaceName, string aProjectName, string aPathToProject, string aLocalPath)
        {
            using (ProjectsDB _db = new ProjectsDB())
            {
                _db.ExecuteNonQuery("INSERT INTO PROJECTS VALUES(" +
                "`" + aStorage + "`," +
                "`" + aPlaceName + "`," +
                "`" + aProjectName + "`," +
                "`" + aPathToProject + "`," +
                "`" + aLocalPath + "`, ``, ``, 0, 0)");
            }
        }
    }
}
