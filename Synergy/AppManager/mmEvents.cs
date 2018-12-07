namespace SynManager
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using Mindjet.MindManager.Interop;
    using System.Threading;
    using System.IO;

    /// <summary>
    /// Class to hold event properties
    /// </summary>
    class MMEventArgs
    {
        //TODO needed?
        public enum EventTypeEnum
        {
            UnknownEvent = 0,
            DocumentEvent = 1,
            TopicEvent = 2,
            KeyEvent = 3,
            MouseEvent = 4
        }

        public MMEventArgs(Event aEvent, Document aDocument, String aExtra = "")
        {
            m_eventType = EventTypeEnum.DocumentEvent;
            m_event = aEvent;
            m_target = aDocument;
            extra = aExtra;
        }

        public MMEventArgs(
            Object aTarget,
            string aWhat,
            string aExtra,
            MapCompanion aDocument = null)
        {
            target = aTarget;           
            what = aWhat != "" ? aWhat.ToLower() : DocumentStorage.GetTargetType(aTarget);
            what = what == "connection" ? "relationship" : what;
            extra = aExtra;
            m_document = aDocument != null ? aDocument.Document : null;
            if (m_document != null)
                aMapFolderPath = aDocument.mc_MapFolderPath;
        }

        public Object target
        {
            get { return m_target; }
            set { m_target = value; }
        }

        /// <summary>
        /// Target document, if applicable
        /// </summary>
        public Document Document
        {
            get
            {
                if (m_document != null)
                    return m_document;
                if (m_target is Document)
                    return m_target as Document;
                if (m_target is Topic)
                    return (m_target as Topic).Document;
                return null;
            }
        }

        //----------------------
        protected Document m_document = null;
        protected EventTypeEnum m_eventType = EventTypeEnum.UnknownEvent;
        protected Object m_target = null;
        protected Event m_event = null;
        public string aMapFolderPath = "";
        public string what = "document";
        public string extra = "";
    }

    class MMBase
    {
        public virtual void onTimer200() { }

        public virtual void onDocumentOpened(MMEventArgs aArgs) { }
        public void onAfterDocumentOpenedBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentOpened(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentClosed(MMEventArgs aArgs) { }
        public void onBeforeDocumentClosedBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentClosed(aArgs);
            }
            catch { }
        }

        public virtual void onBeforeDocumentSaved(MMEventArgs aArgs) { }
        public void onBeforeDocumentSavedBase(MMEventArgs aArgs)
        {
            try
            {
                onBeforeDocumentSaved(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentActivated(MMEventArgs aArgs) { }
        public void onAfterDocumentActivatedBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentActivated(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentDeactivated(MMEventArgs aArgs) { }
        public void onAfterDocumentDeactivatedBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentDeactivated(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentClipboardCopy(MMEventArgs aArgs) { }
        public void onBeforeDocumentClipboardCopyBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentClipboardCopy(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentClipboardPaste(MMEventArgs aArgs) { }
        public void onBeforeDocumentClipboardPasteBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentClipboardPaste(aArgs);
            }
            catch { }
        }

        public virtual void onAfterPaste(MMEventArgs aArgs) { }
        public void onAfterPasteBase(MMEventArgs aArgs)
        {
            try
            {
                onAfterPaste(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentClipboardDrag(MMEventArgs aArgs) { }
        public void onBeforeDocumentClipboardDragBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentClipboardDrag(aArgs);
            }
            catch { }
        }

        public virtual void onDocumentClipboardDrop(MMEventArgs aArgs) { }
        public void onBeforeDocumentClipboardDropBase(MMEventArgs aArgs)
        {
            try
            {
                onDocumentClipboardDrop(aArgs);
            }
            catch { }
        }

        public virtual void onObjectChanged(MMEventArgs aArgs) { }
        public void onAfterObjectChangedBase(MMEventArgs aArgs)
        {
            try
            {
                onObjectChanged(aArgs);
            }
            catch { }
        }

        public virtual void onObjectAdded(MMEventArgs aArgs) { }
        public void onAfterObjectAddedBase(MMEventArgs aArgs)
        {
            try
            {
                onObjectAdded(aArgs);
            }
            catch { }
        }

        public virtual void onBeforeObjectRemoved(MMEventArgs aArgs) { }
        public void onBeforeObjectRemovedBase(MMEventArgs aArgs)
        {
            try
            {
                onBeforeObjectRemoved(aArgs);
            }
            catch { }
        }

        public static void TRACE(String aMsg)
        {
            try
            {
                StreamWriter _f = File.AppendText(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SynergyLog.txt");
                _f.WriteLine(aMsg);
                _f.Close();
            }
            catch { }
        }

        public static void SendMessage(string message, Document doc)
        {
            doc.CentralTopic.get_Attributes(SUtils.SYNERGYMESSAGE).SetAttributeValue("MESSAGE", message);
        }

        public static string SynergyMessage(Document doc)
        {
            return doc.CentralTopic.get_Attributes(SUtils.SYNERGYMESSAGE).GetAttributeValue("MESSAGE");
        }

        public virtual bool onKeyDown(MMEventArgs aArgs) { return false; }
        public virtual bool onKeyUp(MMEventArgs aArgs) { return false; }
        public virtual bool onSysKeyDown(MMEventArgs aArgs) { return false; }
        public virtual bool onSysKeyUp(MMEventArgs aArgs) { return false; }

        public static void doEvents()
        {
            System.Windows.Forms.Application.DoEvents();
        }
    }
}
