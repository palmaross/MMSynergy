namespace Synergy19
{
	using System;
	using System.Runtime.InteropServices;
    using Mindjet.MindManager.Interop;
    using SynManager;
    using Maps;
    using Projects;
    using Places;
    using About;

	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("BBDF2862-7894-4163-B455-EE5412E8ADEB"), ProgId("Synergy19.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2
	{
		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
		}

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
            MMUtils.AddinName = TS_AddInName;
            MMUtils.Version = 19;
            MMUtils.MindManager = (Application)application;
            addInInstance = addInInst;            

            PLACES = new PlacesGroup();
            PROJECTS = new ProjectsGroup();
            MAPS = new MapsGroup();
            ABOUT = new AboutGroup();

            DocumentStorage.Init();
            m_synergyTab = MMUtils.MindManager.Ribbon.Tabs.Add(0, MMUtils.GetString("main.name"), "www.palmaross.com/api/documentation/synergytab");
            
            PLACES.Create(m_synergyTab);
            PROJECTS.Create(m_synergyTab);
            MAPS.Create(m_synergyTab);
            ABOUT.Create(m_synergyTab);

            m_synergyTab.Visible = false;
        }

        /// <summary>
        ///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
        ///     Receives notification that the Add-in is being unloaded.
        /// </summary>
        /// <param term='disconnectMode'>
        ///      Describes how the Add-in is being unloaded.
        /// </param>
        /// <param term='custom'>
        ///      Array of parameters that are host application specific.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
		{
            addInInstance = null;
            PLACES.Destroy();
            MAPS.Destroy();
            PROJECTS.Destroy();
            ABOUT.Destroy();
            DocumentStorage.Destroy();
            MMUtils.MindManager = null;
            m_synergyTab.Delete();
            m_synergyTab = null;

            System.GC.Collect();
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
		}

        private object addInInstance;
        private string TS_AddInName = "Synergy19.Connect";
        private ribbonTab m_synergyTab;

        private MapsGroup MAPS;
        private ProjectsGroup PROJECTS;
        private PlacesGroup PLACES;
        private AboutGroup ABOUT;
	}
}