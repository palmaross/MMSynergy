namespace Synergy18
{
	using System;
	using Extensibility;
	using System.Runtime.InteropServices;
    using Mindjet.MindManager.Interop;
    using System.Diagnostics;
    using SynManager;
    using Maps;
    using Projects;
    using Places;
    using About;

	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("38155112-4ED9-46D8-8A2D-BCB2ECB9A12F"), ProgId("Synergy18.Connect")]
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
            addInInstance = addInInst;
            MMUtils.AddinName = T_AddInName;
            MMUtils.Version = 18;
            MMUtils.MindManager = (Application)application;
            DocumentStorage.Init();

            PLACES = new PlacesGroup();
            PROJECTS = new ProjectsGroup();
            MAPS = new MapsGroup();
            ABOUT = new AboutGroup();

            m_myTab = MMUtils.MindManager.Ribbon.Tabs.Add(0, MMUtils.GetString("main.name"), "www.sergioross.com/api/documentation/demos/ribbontab");
            m_myTab.Visible = false;

            PLACES.Create(m_myTab);
            PROJECTS.Create(m_myTab);
            MAPS.Create(m_myTab);
            ABOUT.Create(m_myTab);
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
            m_myTab.Delete();
            m_myTab = null;

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
        private string T_AddInName = "Synergy18.Connect";
        public static ribbonTab m_myTab;
        private MapsGroup MAPS;
        private ProjectsGroup PROJECTS;
        private PlacesGroup PLACES;
        private AboutGroup ABOUT;
	}
}