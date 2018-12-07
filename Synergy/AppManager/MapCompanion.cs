using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindjet.MindManager.Interop;

namespace SynManager
{
    class MapCompanion : Object, IDisposable
    {
        public MapCompanion() { }
        public MapCompanion(Document aDocument)
        {
            m_document = aDocument;

            m_beforeObjectDeleted = MMUtils.MindManager.Events.AddDocumentEvent(
                DocumentStorage.EventBeforeObjectDeleted,
                true, false, m_document);
            m_beforeObjectDeleted.UndoCaption = "BeforeObjectDeleted";
            m_beforeObjectDeleted.AutomaticCallbackContext = false;
            m_beforeObjectDeleted.Fire += new IEventEvents_FireEventHandler(m_beforeObjectDeleted_Fire);

            m_afterObjectAdded = MMUtils.MindManager.Events.AddDocumentEvent(
                DocumentStorage.EventObjectAdded,
                false, true, m_document);
            m_afterObjectAdded.UndoCaption = "AfterObjectAdded";
            m_afterObjectAdded.AutomaticCallbackContext = false;
            m_afterObjectAdded.Fire += new IEventEvents_FireEventHandler(m_afterObjectAdded_Fire);

            //m_beforeObjectChanged = MMUtils.MindManager.Events.AddDocumentEvent(
            //    DocumentStorage.EventObjectModified,
            //    true, false, m_document);
            //m_beforeObjectChanged.UndoCaption = "AfterObjectChanged";
            //m_beforeObjectChanged.AutomaticCallbackContext = false;
            //m_beforeObjectChanged.Fire += new IEventEvents_FireEventHandler(m_beforeObjectChanged_Fire);

            m_afterObjectChanged = MMUtils.MindManager.Events.AddDocumentEvent(
                DocumentStorage.EventObjectModified,
                false, true, m_document);
            m_afterObjectChanged.UndoCaption = "AfterObjectChanged";
            m_afterObjectChanged.AutomaticCallbackContext = false;
            m_afterObjectChanged.Fire += new IEventEvents_FireEventHandler(m_afterObjectChanged_Fire);
        }

        ~MapCompanion()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.m_disposed)
            {
                {
                    m_beforeObjectDeleted.Fire -= m_beforeObjectDeleted_Fire;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_beforeObjectDeleted);
                    m_beforeObjectDeleted = null;

                    m_afterObjectAdded.Fire -= m_afterObjectAdded_Fire;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_afterObjectAdded);
                    m_afterObjectAdded = null;

                    //m_beforeObjectChanged.Fire -= m_beforeObjectChanged_Fire;
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(m_beforeObjectChanged);
                    //m_beforeObjectChanged = null;

                    m_afterObjectChanged.Fire -= m_afterObjectChanged_Fire;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_afterObjectChanged);
                    m_afterObjectChanged = null;
                }

                m_document = null;
                extraTopic = null;
                // Call the appropriate methods to clean up unmanaged resources here.
                // If disposing is false, only the following code is executed.
                // Note disposing has been done.
                m_disposed = true;
            }
        }

        // Event handlers
        void m_afterObjectAdded_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra)
        {
            if (received)
                return;

            if (copypast) // Skip all add-events in a paste scope
                return;
            else
            {
                if (paste)
                {
                    MMBase.SendMessage("paste", m_document);
                    copypast = true; // resets in the m_afterObjectChanged_Fire via SendMessage()
                    return;
                }
            }

            string _what = "",_extra = "";
            objectAdded = true;

            foreach (MMBase _parent in DocumentStorage.m_parent)
                _parent.onAfterObjectAddedBase(new MMEventArgs(pSource, _what, _extra, this));
        }

        // For catch delete image event only
        void m_beforeObjectChanged_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra) //TODO needed?
        {
            if (received)
                return;

            Topic _topic = pSource as Topic;

            if (_topic == null)
                return;

            string _what = "";

            if (pExtra is Array)
            {
                Array _pExtraAsArray = pExtra as Array;

                if (_pExtraAsArray.GetLength(0) > 0 && eventFlag == DocumentStorage.EventObjectModified)
                    _what = _pExtraAsArray.GetValue(0).ToString().ToLower();
            }

            if (_what == "oneimage")
            {
                reset++;
                if (reset > 1)  // reset сбрасывается на 0 в таймере
                    return;     // иначе будет куча проходов и запуска таймера, нужен только один для удаления картинки
                extracase = "deleteimage";
                extraTopic = _topic;
                DocumentStorage.m_timer200.Start();
            }

            _topic = null;
        }

        void m_afterObjectChanged_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra)
        {
            if (received)
               return;

            if (extracase == "deleteimage")
            {
                 extracase = ""; // отбиваем таймер удаления картинки
            }

            // TODO при добавлении связи может быть _what "AutoRoute"! И выходит исключение

            string _what = "", _extra = "";

            if (pExtra is Array)
            {
                Array _pExtraAsArray = pExtra as Array;
                if (_pExtraAsArray.GetLength(0) > 0 && eventFlag == DocumentStorage.EventObjectModified)
                    _what = _pExtraAsArray.GetValue(0).ToString().ToLower();
                if (_pExtraAsArray.GetLength(0) > 1)
                    _extra = _pExtraAsArray.GetValue(1).ToString();
            }

            // TODO если выбран не топик, не граница и не связь, то выбран фоновой объект!
            if (_what == "collapsed" || _what == "selection") 
                return;

            //if (paste && _what == "oneimage")
            //{
            //    extraTopic = null;
            //    return;
            //}

            if (objectAdded)
            {
                if (_what != "offset") // все оффсетные события нахер
                    objectAdded = false;
                return;
            }

            string sMessage = MMBase.SynergyMessage(m_document);

            //// Message sent from m_beforeObjectChanged_Fire when image deleted
            //if (sMessage == "deleteimage" && _what != "oneimage")
            //{
            //    MMBase.SendMessage("", m_document);
            //    _what = "oneimage";
            //    pSource = extraTopic;
            //}

            //extraTopic = null;

            if (paste && sMessage != "paste") // отбиваем все пасты, которые не от копипаста или драгдропа ТОПИКОВ
                paste = false;
            if (paste && _what == "offset")
                return;
            //if (paste && !_topic.IsCentralTopic) // учитываем только paste, который пришел от message
            //    return;

            if (_extra == SUtils.SYNERGYNAMESPACE) // отбиваются synergy-изменения в атрибутах объекта
                return;

            Topic _topic = pSource as Topic;

            if (_what == "custom" && _topic != null) // TODO (addins only?) addins: Synergy, Numbering, Rollup(Gantt)
            {
                if (_topic.IsCentralTopic && _extra == SUtils.SYNERGYMESSAGE) //SendMessage went off
                {
                    if (sMessage == "paste") // SendMessage was emited from m_afterObjectAdded_Fire at starting paste copied objects
                    {                       // so, paste events now is ended, we can process pasted objects
                        foreach (MMBase _parent in DocumentStorage.m_parent)
                            _parent.onAfterPasteBase(new MMEventArgs(pSource, _what, _extra, this));
                        paste = false;
                        copypast = false;
                    }
                    //else if (sMessage == "received") // SendMessage was emited from ReceiveChanges   
                    //    received = false; // прием закончен

                    m_document.CentralTopic.get_Attributes(SUtils.SYNERGYMESSAGE).DeleteAll();

                    _topic = null;
                    return;
                }

                if (_extra == SUtils.SYNERGYNAMESPACE && rollup) // all subtopics already skipped, rollup operation finished 
                {
                    rollup = false;
                    _topic = null;
                    return;
                }
            }

            if (rollup) // skip all rollup subtopics, change only parent
            {
                _topic = null; 
                return;
            }

            if (_what == "task") // TODO впадает в цикл, если изменять Duration, Effort и ресурсы через панель Task Info                
                if (Changes.SaveChanges._topicxml == MMUtils.getCleanTopicXML(_topic.Xml))
                {
                    _topic = null; return;
                }

            if (_topic != null)
            {
                // TODO надо как-то уловить последний оффсет для них и процессировать
                if ((_topic.IsFloatingTopic || _topic.IsCalloutTopic) && _what == "offset")
                {
                    _topic = null; return; // number of offsets = number of floating topics in the map
                }

                if (_what == "task" && _extra == "") 
                {   // если при запуске карты выбран топик с задачей, то почему-то сразу срабатывает событие на task
                    _topic = null; return; 
                }

                //if (_what == "task" && _topic.Task.IsEmpty)
                //    return; // при запуске карты может быть такое, если выбрано несколько топиков, один из который задача

                if (_extra == SUtils.numberinguri)
                    _what = "numbering";

                _extra = Changes.PortraitGet.TopicPortrait(_topic, ref _what, _extra, mc_MapFolderPath);
                //System.Windows.Forms.Clipboard.SetText(_extra);

                if (_extra == SUtils.rollupuri)
                {
                    System.Windows.Forms.MessageBox.Show("'Комбинировать информацию о задании' пока не поддерживается, другие пользователи не получат это изменение", 
                        MMUtils.GetString("maps.synergywarning.caption"));
                    return;
                }

                if (_extra == "queue")
                {
                    System.Windows.Forms.MessageBox.Show("Произведенное изменение пока не поддерживается в Synergy, другие пользователи не получат это изменение",
                        MMUtils.GetString("maps.synergywarning.caption"));
                    return;
                }
            }

            foreach (MMBase _parent in DocumentStorage.m_parent)
                _parent.onAfterObjectChangedBase(new MMEventArgs(pSource, _what, _extra, this));
        }

        void m_beforeObjectDeleted_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra)
        {
            if (received)
                return;

            if (pSource is Topic _topic && !_topic.IsFloatingTopic) // плавающий пропускаем дальше
            {
                if (!_topic.IsSelected) // если топик не выбран - отбой, удалится вместе с родителем
                {
                    _topic = null; return;
                }

                Topic _t = _topic;
                // пропускаем дальше выноски связей и выноски границ
                while (!_t.IsCentralTopic && !_t.IsFloatingTopic && _t.ParentRelationship == null && _t.ParentBoundary == null)
                {
                    if (_t.ParentTopic.IsSelected)  // если выше по ветке находится выбранный топик - отбой, удалится вместе с ним
                    {
                        _topic = null; _t = null; return;
                    }
                    _t = _t.ParentTopic;
                }

                _t = null;
            }

            String _what = "", _extra = "";

            if (pSource is Boundary bnd)
                if (!bnd.IsSelected) // если граница не выбрана, значит удаляется ее топик и она удалится вместе с топиком
                {
                    bnd = null; return;
                }

            if (pSource is Relationship rel)
                if (!rel.IsSelected) // если связь не выбрана, значит удаляется ее топик и она удалится вместе с топиком
                {
                    rel = null; return;
                }

            foreach (MMBase _parent in DocumentStorage.m_parent)
                    _parent.onBeforeObjectRemovedBase(new MMEventArgs(pSource, _what, _extra, this));

            _topic = null; bnd = null; rel = null;
        }

        /// <summary>
        /// Contained document
        /// </summary>
        public virtual Document Document
        {
            get
            {
                return m_document;
            }
        }

        /// <summary>
        /// MindManager's Guid
        /// </summary>
        public String MapGuid
        {
            get
            {
                try
                {
                    return m_document != null ? Document.Guid : "";
                }
                catch { }
                return "";
            }
        }

        /// <summary>//TODO может собрать сюда имена всех пользователей карты?
        /// Get list of Guid's of all topics in Document
        /// </summary>
        /// <param name="aUseFloatingTopics">Whether to get floating topics</param>
        /// <param name="aUseCalloutTopics">Whether to get Callout topics</param>
        /// <returns></returns>
        public virtual List<String> GetAllTopics(bool aUseFloatingTopics = false, bool aUseCalloutTopics = false)
        {
            List<String> _rc = new List<string>();
            if (m_document == null)
                return _rc;
            foreach (Topic _topic in m_document.Range(MmRange.mmRangeAllTopics, true))
            {
                if (_topic.IsCalloutTopic && !aUseCalloutTopics)
                    continue;
                if (_topic.IsFloatingTopic && !aUseFloatingTopics)
                    continue;
                _rc.Add(_topic.Guid);
            }

            return _rc;
        }

        protected Document m_document = null;
        protected bool m_disposed = false;
        //
        // Document Events
        //
        protected Event m_afterObjectAdded = null;
        protected Event m_beforeObjectChanged = null;
        protected Event m_afterObjectChanged = null;
        protected Event m_beforeObjectDeleted = null;

        public string mc_MapFolderPath { get; set; }

        private bool objectAdded = false;
        private bool copypast = false;

        public static bool received = false;
        public static bool rollup = false;
        public static bool paste = false;
        public static bool publishpaste = false;

        // For onBeforeChanged
        public static string extracase = "";
        public static int reset = 0;
        public static Topic extraTopic = null;
    }
}
