using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindjet.MindManager.Interop;
using SynManager;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using Maps;

namespace Changes
{
    class SaveChanges : MMBase
    {
        public SaveChanges()
        {
            DocumentStorage.Subscribe(this);
        }

        public override void onTimer200()
        {
            DocumentStorage.m_timer200.Stop();
            MapCompanion.reset = 0;

            if (MapCompanion.extracase == "deleteimage")
            {
                Topic _t = MapCompanion.extraTopic;
                SendMessage("deleteimage", _t.Document);
                _t = null;
            }
        }

        // TODO needed?
        public override void onDocumentClipboardDrag(MMEventArgs aArgs)
        {
            
        }

        public override void onAfterPaste(MMEventArgs aArgs)
        {
            Document _doc = aArgs.Document;

            // if boundary selected
            if (_doc.Selection.HasBoundary && !_doc.Selection.HasTopic) //if any topic in selection, any boundaries are ignored
            {
                Boundary bnd = null;
                foreach (Boundary b in _doc.Selection)
                {
                    bnd = b; // take the first one
                    break;
                }
                aArgs.target = bnd.Topic;
                aArgs.what = "boundary";
                onObjectChanged(aArgs);
                _doc = null;
                bnd = null;
                return;
            }

            MapCompanion.publishpaste = true;
            Topic _t = null;

            foreach (DocumentObject obj in _doc.Selection) // находим "верхний" топик в выборе
            {
                _t = obj as Topic;
                if (_t == null)
                    continue;

                aArgs.target = _t;
                ProcessBranch(_t);
                onObjectAdded(aArgs);
            }
            _t = null;
            _doc = null;

            string rootfolder = aArgs.aMapFolderPath + "share\\";
            string _path;

            // Process relationships if any
            if (!restrict)
            {
                foreach (Relationship r in BranchRelationships) // list of branch relationships
                {
                    _path = rootfolder + SUtils.modtime + "&" + SUtils.currentUserName + ".txt";

                    SUtils.ProcessRelationship(r, _path, "relationship:paste");

                    foreach (Topic callout in r.AllCalloutTopics)
                        RelationshipTopics(callout, aArgs);
                }
            }

            for (int i = 0; i <= BranchRelationships.Count; i++)
                BranchRelationships[i] = null; // TODO needed?
            BranchRelationships.Clear();
        }

        void RelationshipTopics(Topic _t, MMEventArgs aArgs)
        {
            aArgs.target = _t;
            onObjectAdded(aArgs);

            foreach (Topic t in _t.AllSubTopics)
                RelationshipTopics(t, aArgs);

            foreach (Topic t in _t.AllCalloutTopics)
                RelationshipTopics(t, aArgs);
        }

        /// <summary>
        /// Set Synergy attributes to all objects in the branch of given topic and collect all relationships
        /// </summary>
        void ProcessBranch(Topic _topic)
        {
            TransactionsWrapper.SetAttributes(_topic);

            if (_topic.HasBoundary)
            {
                TransactionsWrapper.SetAttributes(_topic.Boundary, _topic.Boundary.Guid);

                foreach (Relationship _r in _topic.Boundary.AllRelationships)
                {
                    if (BranchRelationships.Contains(_r))
                        continue;

                    TransactionsWrapper.SetAttributes(_r, _r.Guid);
                    BranchRelationships.Add(_r); // list of relationships to process further

                    foreach (Topic _t in _r.AllCalloutTopics)
                    {
                        TransactionsWrapper.SetAttributes(_t);
                        foreach (Topic _subtopic in _t.AllSubTopics)
                            ProcessBranch(_subtopic);
                    }
                }

                if (_topic.Boundary.HasSummaryTopic)
                {
                    Topic _st = _topic.Boundary.SummaryTopic;
                    TransactionsWrapper.SetAttributes(_st);

                    foreach (Topic _subtopic in _st.AllSubTopics)
                        ProcessBranch(_subtopic);
                    _st = null;
                }
            }

            foreach (Relationship _r in _topic.AllRelationships)
            {
                if (BranchRelationships.Contains(_r))
                    continue;

                TransactionsWrapper.SetAttributes(_r, _r.Guid);
                BranchRelationships.Add(_r); // list of relationships to process further

                foreach (Topic _t in _r.AllCalloutTopics)
                {
                    TransactionsWrapper.SetAttributes(_t);
                    foreach (Topic _subtopic in _t.AllSubTopics)
                        ProcessBranch(_subtopic);
                }
            }

            foreach (Topic _subtopic in _topic.AllSubTopics)
                ProcessBranch(_subtopic);

            foreach (Topic _subtopic in _topic.AllCalloutTopics)
                ProcessBranch(_subtopic);
        }

        ////////////////////////////////////////////////////////////////////////

        public override void onObjectChanged(MMEventArgs aArgs)
        {
            string _what = aArgs.what;

            Topic _t = aArgs.target as Topic;
            Relationship _r = aArgs.target as Relationship;
            Boundary _b = aArgs.target as Boundary;

            string rootfolder = aArgs.aMapFolderPath + "share\\";
            string _path = rootfolder + SUtils.modtime + "&" + SUtils.currentUserName + ".txt";

            if (_r != null)
            {
                SUtils.ProcessRelationship(_r, _path, "relationship:modify");
                _r = null;
                return;
            }

            if (_b != null)
            {
                SUtils.ProcessBoundary(_b, _path, "boundary:modify");
                _b = null;
                return;
            }

            string rollup = SUtils.rollupuri;
            string _offset = "";
            string _extra = "";

            if (_t == null)
                return; // TODO case?

            _extra = aArgs.extra;
            //if (_extra != "")
            //    System.Windows.Forms.Clipboard.SetText(_extra); // TODO для чего?

            if (aArgs.extra.ToString() == rollup)
            {
                _what = "rollup";
                MapCompanion.rollup = true;
            }

            if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
            {
                float x, y;
                _t.GetOffset(out x, out y);
                _offset = x.ToString() + ";" + y.ToString();
            }

            string _shorttext = MMUtils.TShortText(_t.Text);
            string _attrs = SUtils.TimeStamp + ";" + SUtils.currentUserName + ";" + SUtils.currentUserEmail;

            TransactionsWrapper.SetATTR(_t, SUtils.TMODIFIED, _attrs);

            string tXML = MMUtils.getCleanTopicXML(_t.Xml);

            if (_what == "task")
                _topicxml = tXML; // впадает в цикл, если изменять Duration, Effort и ресурсы

            string _tguid = _t.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);

            _t = null;

            try
            {
                StreamWriter sw = new StreamWriter(File.Create(_path));
                sw.WriteLine("modify:" + _what);
                sw.WriteLine(_tguid);
                sw.WriteLine(_shorttext); // short topic text for chat
                sw.WriteLine(_attrs);
                sw.WriteLine(_offset);
                sw.WriteLine(_extra);
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "SaveChanges:onObjectChanged");
            }
        }

        public override void onObjectAdded(MMEventArgs aArgs) // only for new topics
        {
            Topic _t = aArgs.target as Topic;
            Relationship _r = aArgs.target as Relationship;
            Boundary _b = aArgs.target as Boundary;

            string rootfolder = aArgs.aMapFolderPath + "share\\";
            string _path = rootfolder + SUtils.modtime + "&" + SUtils.currentUserName + ".txt";
            string _what = "add:";
            string pGuid = "";
            string offset = "";
            int a = 0;

            if (_r != null) // add relationship
            {
                SUtils.ProcessRelationship(_r, _path, "relationship:add");
                _r = null;
                return;
            }
            if (_b != null) // add boundary
            {
                SUtils.ProcessBoundary(_b, _path, "boundary:add");
                System.Threading.Thread.Sleep(100); // иначе выноска границы может вперед прийти по облачному хранилищу
                _b = null;
                return;
            }

            if (_t == null)
                return; // TODO case?

            if (_t.IsFloatingTopic)
                _what = "add:floating";

            if (_t.IsCalloutTopic || _t.IsSummaryTopic)
            {
                _what = "add:callout";
                if (_t.ParentRelationship != null) // add callout to relationship
                {
                    _what = "add:relcallout";
                    Relationship rel = _t.ParentRelationship;
                    pGuid = rel.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
                }
                if (_t.ParentBoundary != null) // add callout to boundary
                {
                    _what = "add:bndcallout";
                    Boundary bnd = _t.ParentBoundary;
                    pGuid = bnd.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
                }
            }

            if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
            {
                float x, y;
                _t.GetOffset(out x, out y);
                offset = x.ToString() + ";" + y.ToString();
                if (_t.IsMainTopic) a = -1;                  
            }
            if (!_t.IsFloatingTopic && _what != "add:relcallout" && _what != "add:bndcallout")
            {
                pGuid = _t.ParentTopic.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
                a = MMUtils.SubtopicIndex(_t);
            }

            if (!_t.IsCalloutTopic && !_t.IsFloatingTopic && !_t.IsSummaryTopic)
                _what = _what + a.ToString();

            string _shorttext = MMUtils.TShortText(_t.Text);

            TransactionsWrapper.SetAttributes(_t);

            string _tGuid = _t.Guid;
            string _topicdata = "";

            if (_t.IsDefaultTopicText)
                _topicdata = "newtopic";
            else
                _topicdata = _t.Xml;

            _t = null;

            try
            {
                StreamWriter sw = new StreamWriter(File.Create(_path));
                sw.WriteLine(_what);
                sw.WriteLine(pGuid); // parent topic's guid - to which add topic(s)               
                sw.WriteLine(_shorttext); // topic text or what added - for chat
                sw.WriteLine(_tGuid);
                sw.WriteLine(SUtils.TimeStamp + ";" + SUtils.currentUserName + ";" + SUtils.currentUserEmail);
                sw.WriteLine(offset); // for main, floating or callout topic 
                sw.WriteLine(_topicdata);
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "SaveChanges:onObjectAdded");
            }
        }

        public override void onBeforeObjectRemoved(MMEventArgs aArgs)
        {
            string _what = "delete:topic";
            string Guid = "";
            string _shorttext = "";
            string name = MMUtils.GetRegistry("", "CurrentUserName");
            string rootfolder = aArgs.aMapFolderPath + "share\\";
            string _path = rootfolder + SUtils.modtime + "&" + name + ".txt";

            Topic _t = aArgs.target as Topic;
            Relationship _r = aArgs.target as Relationship;
            Boundary _b = aArgs.target as Boundary;

            if (_t != null)
            {
                _shorttext = MMUtils.TShortText(_t.Text);
                Guid = _t.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            }
            else if (_b != null)
            {
                _what = "delete:boundary";
                _shorttext = "boundary";
                Guid = _b.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            }
            else if (_r != null)
            {
                _what = "delete:relationship";
                _shorttext = "relationship";
                Guid = _r.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            }
            else
                return; // TODO case?

            _t = null; _r = null; _b = null;

            try
            {
                StreamWriter sw = new StreamWriter(File.Create(_path));
                sw.WriteLine(_what);
                sw.WriteLine(Guid);
                sw.WriteLine(_shorttext); // for chat
                sw.WriteLine(name); // for chat
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "SaveChanges:onObjectRemoved");
            }
        }

        public void Destroy()
        {
            DocumentStorage.Unsubscribe(this);
            //if (SUtils.SavedRelationships != null)
            //    SUtils.SavedRelationships = null;
        }

        public static string _topicxml = "";
        private List<Relationship> BranchRelationships = new List<Relationship>();

        private bool restrict = true;
    }
}
