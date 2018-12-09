using System;
using SynManager;
using Mindjet.MindManager.Interop;
using System.IO;

namespace Changes
{
    internal class ReceiveChanges : MMEnums
    {
        public static void GetChanges(Document _doc, string _filepath) // _filepath to .txt file in share folder
        {
            //string[] files = Directory.GetFiles(mapFolderPath, "*.txt");

            float x=0, y=0; // callouts, main and floating topics
            int index = 1;  // subtopic index in a branch
            string line = "";
            string _case = "";
            string _what = ""; // case details
            string rollup = SUtils.rollupuri;
            //string numbering = SUtils.numberinguri;

            string mapfolderpath = Path.GetDirectoryName(_filepath) + "\\";

            //foreach (string file in files)
            {
                System.IO.StreamReader _file = null;
                try
                {
                    _file = new System.IO.StreamReader(_filepath);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "ReceiveChanges:StreamReader");
                    return;
                }
                
                line = _file.ReadLine(); // line 1: case
                _case = line;
                int colon = line.IndexOf(":");

                if (colon != -1)
                {
                    _case = line.Substring(0, colon); // before colon
                    _what = line.Substring(++colon);  // after colon
                    if (!int.TryParse(_what, out index))
                        index = 1;

                }

                MapCompanion.received = true; // to repulse event handlers

                switch (_case)
                {
                    ///////////////////////// MODIFY TOPIC ///////////////////////
                    case "modify":

                        // line 2: topic Guid
                        _t = SUtils.FindTopicByAttrGuid(_doc, _file.ReadLine());
                        if (_t == null)
                        {
                            System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseModify.TopicNotFound");
                            break; //TODO
                        }

                        if (_what == "rollup") // set or remove rollup
                        {                            
                            if (_t.HasAttributesNamespace[rollup])
                                _t.IsTaskRollupTopic = false;
                            else
                                _t.IsTaskRollupTopic = true;
                            break;
                        }

                        // line 3: topic text (for chat)
                        forchat = _file.ReadLine();

                        // line 4: timestamp (to attributes)
                        TransactionsWrapper.SetATTR(_t, SUtils.TMODIFIED, _file.ReadLine());

                        // line 5: offset
                        line = _file.ReadLine();
                        if (line != "")
                        {
                            if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
                            {
                                int w = line.IndexOf(";");
                                float.TryParse(line.Substring(0, w), out x);
                                float.TryParse(line.Substring(w + 1), out y);
                            }
                        }

                        // line 6 to end: value
                        line = _file.ReadLine();
                        string _value = line;

                        while (line != null)
                        {                            
                            line = _file.ReadLine();
                            if (line != null)
                                _value = _value + Environment.NewLine + line;
                        }

                        if (_what != "offset")
                            PortraitSet.TopicPortrait(_t, _what, _value, mapfolderpath);

                        if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
                            _t.SetOffset(x, y); //restore topic position

                        break; 
                    ////////////////// MODIFY case ends ///////////////////

                    /////////////////////////// ADD TOPIC ////////////////////////
                    case "add":

                        Topic _parent = null;
                        Boundary _bparent = null;
                        Relationship _rparent = null;

                        // line 2: parent guid
                        line = _file.ReadLine();
                        if (line != "") // empty if floating topic
                        {
                            if (_what == "relcallout")
                                _rparent = SUtils.FindRelationshipByAttrGuid(_doc, line);
                            else if (_what == "bndcallout")
                                _bparent = SUtils.FindBoundaryByAttrGuid(_doc, line);
                            else
                                _parent = SUtils.FindTopicByAttrGuid(_doc, line);
                            if (_parent == null && _rparent == null && _bparent == null)
                            {
                                System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseAdd.ObjectNotFound");
                                break; // TODO обнаружить ошибку - сообщить пользователю? 
                            }
                        }                                     

                        // line 3: topic text - for chat
                        forchat = _file.ReadLine();

                        // line 4: added topic guid : add topic
                        line = _file.ReadLine();
                        if (_what == "floating")
                        {
                            _t = _doc.AllFloatingTopics.Add();
                        }
                        else if (_what == "callout")
                        {
                            _t = _parent.AllCalloutTopics.Add();
                        }
                        else if (_what == "relcallout")
                        {
                            _t = _rparent.AllCalloutTopics.Add();
                        }
                        else if (_what == "bndcallout")
                        {
                            _t = _bparent.CreateSummaryTopic(MMUtils.GetString("callout.text"));
                        }
                        else
                        {
                            _t = _parent.AllSubTopics.Add();
                            _parent.AllSubTopics.Insert(_t, index); // EventDocumentClipboardPaste fires!                            
                            MapCompanion.paste = false; // so, neutralize it...
                        }

                        TransactionsWrapper.SetATTR(_t, SUtils.OGUID, line);

                        // line 5: timestamp
                        line = _file.ReadLine();
                        TransactionsWrapper.SetATTR(_t, SUtils.TADDED, line);
                        TransactionsWrapper.SetATTR(_t, SUtils.TMODIFIED, line);

                        // line 6: offset
                        line = _file.ReadLine();
                        if (line != "") // skip standart topics
                        {
                            int w = line.IndexOf(";");
                            float.TryParse(line.Substring(0, w), out x);
                            float.TryParse(line.Substring(w + 1), out y);
                        }
                        if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
                            _t.SetOffset(x, y);

                        // line 7: skip if new topic added, otherwise (topic was pasted) replace whole topic xml
                        line = _file.ReadLine(); // <?xml version="1.0" standalone="no"?>
                        if (line != "newtopic")
                        {
                            _t.Xml = line + _file.ReadLine(); // topic XML
                            if (_t.IsFloatingTopic || _t.IsMainTopic || _t.IsCalloutTopic)
                                _t.SetOffset(x, y);
                        }

                        _parent = null; _rparent = null; _bparent = null;
                        break; 
                    ///////////////////// ADD TOPIC case ends ////////////////////////

                    //////////// DELETE TOPIC OR RELATIONSHIP OR BOUNDARY ////////////
                    case "delete":

                        // line 2: guid of object to delete
                        line = _file.ReadLine();

                        DocumentObject m_objtodelete = null;
                        m_objtodelete = SUtils.FindObjectByAttrGuid(_doc, line);

                        if (m_objtodelete == null)
                        {
                            System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseDelete.ObjectNotFound");
                            break; // TODO map synchro failure, do something
                        }

                        m_objtodelete.Delete();
                        m_objtodelete = null;

                        // line 3: for chat: topic text or "relationship" or "boundary" 
                        forchat = _file.ReadLine();

                        // line 4: for chat: name of user who deleted object
                        username = _file.ReadLine();

                        break; 
                    //////////////////// DELETE case ends ////////////////////

                    //////////////////// RELATIONSHIP ADD, MODIFY //////////////////
                    case "relationship":
                        Relationship rel = null;

                        // line 2: relationship guid
                        line = _file.ReadLine();
                        if (_what == "modify")
                        {
                            rel = SUtils.FindRelationshipByAttrGuid(_doc, line);
                            if (rel == null)
                            {
                                System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseRelationships.RelNotFound");
                                break;
                            }
                        }

                        // line 3: Guid of connection 1st object
                        string Guid1 = _file.ReadLine();
                        Topic t1 = null, t2 = null;

                        Boundary b1 = SUtils.FindBoundaryByAttrGuid(_doc, Guid1);
                        if (b1 == null)
                            t1 = SUtils.FindTopicByAttrGuid(_doc, Guid1);

                        if (b1 == null && t1 == null)
                        {
                            System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseRelationships.Object1NotFound");
                            break; // TODO
                        }

                        // line 4: 
                        string Guid2 = _file.ReadLine();

                        Boundary b2 = SUtils.FindBoundaryByAttrGuid(_doc, Guid2);
                        if (b2 == null)
                            t2 = SUtils.FindTopicByAttrGuid(_doc, Guid2);

                        if (b2 == null && t2 == null)
                        {
                            System.Windows.Forms.MessageBox.Show("ReceiveChanges.CaseRelationships.Object2NotFound");
                            break; // TODO
                        }

                        if (b1 == null)
                        {
                            if (b2 == null)
                                if (_what == "modify")
                                {
                                    rel.SetConnection1ToTopic(t1);
                                    rel.SetConnection2ToTopic(t2);
                                }
                                else
                                {
                                    rel = t1.AllRelationships.AddToTopic(t2);
                                    TransactionsWrapper.SetAttributes(rel, line);
                                }
                            else
                                if (_what == "modify")
                                {
                                    rel.SetConnection1ToTopic(t1);
                                    rel.SetConnection2ToBoundary(b2);
                                }
                                else
                                {
                                    rel = t1.AllRelationships.AddToBoundary(b2);
                                    TransactionsWrapper.SetAttributes(rel, line);
                                }
                        }
                        else
                        {
                            if (b2 == null)
                                if (_what == "modify")
                                {
                                    rel.SetConnection1ToBoundary(b1);
                                    rel.SetConnection2ToTopic(t2);
                                }
                                else
                                {
                                    rel = b1.AllRelationships.AddToTopic(t2);
                                    TransactionsWrapper.SetAttributes(rel, line);
                                }
                            else
                                if (_what == "modify")
                                {
                                    rel.SetConnection1ToBoundary(b1);
                                    rel.SetConnection2ToBoundary(b2);
                                }
                                else
                                {
                                    rel = b1.AllRelationships.AddToBoundary(b2);
                                    TransactionsWrapper.SetAttributes(rel, line);
                                }
                        }

                        // line 5-8: control points
                        if ((line = _file.ReadLine()) == null) //new rel added, go out
                            break;
                        rel.SetControlPoints(
                            Convert.ToSingle(line),
                            Convert.ToSingle(_file.ReadLine()), 
                            Convert.ToSingle(_file.ReadLine()), 
                            Convert.ToSingle(_file.ReadLine())
                            );

                        // line 9-10:

                        rel.Shape1 = RelationshipShape(_file.ReadLine());
                        rel.Shape2 = RelationshipShape(_file.ReadLine());

                        // line 11:
                        rel.LineColor.Value = Convert.ToInt32(_file.ReadLine());

                        // line 12:
                        rel.LineDashStyle = LineDashStyle(_file.ReadLine());

                        // line 13:
                        rel.LineShape = LineShape(_file.ReadLine());

                        // line 14:
                        rel.LineWidth = Convert.ToSingle(_file.ReadLine());

                        // line 15:
                        rel.AutoRouting = Convert.ToBoolean(_file.ReadLine());

                        rel = null; t1 = null; t2 = null; b1 = null; b2 = null;

                        break; 
                    /////////////// RELATIONSHIP case ends //////////

                    /////////////////// ADD OR MODIFY BOUNDARY ////////////////
                    case "boundary":
                        // line 2: topic guid
                        _t = SUtils.FindTopicByAttrGuid(_doc, _file.ReadLine());
                        Boundary b = null;

                        // line 3: boundary shape or portrait
                        if (_what == "add")
                        {
                            b = _t.CreateBoundary();
                            b.Shape = BoundaryShape(_file.ReadLine());
                        }
                        else // modify boundary
                        {
                            b = _t.Boundary;
                            string[] bvalues = _file.ReadLine().Split(';');

                            b.Shape = MMEnums.BoundaryShape(bvalues[0]);
                            b.FillColor.Value = Convert.ToInt32(bvalues[1]);
                            b.LineColor.Value = Convert.ToInt32(bvalues[2]);
                            b.LineDashStyle = MMEnums.LineDashStyle(bvalues[3]);
                            b.LineWidth = Convert.ToInt32(bvalues[4]);
                        }

                        // line 4: boundary guid
                        TransactionsWrapper.SetAttributes(b, _file.ReadLine());

                        b = null;
                        break; 
                    ////////////// BOUNDARY case ends ////////////////
                }

                MapCompanion.received = false;
                _file.Close();
                _t = null; // TODO dooble-check! very important!!
                //File.Delete(file);
            } // foreach files
            
            //MMBase.SendMessage("received"); // TODO nedeed?
        }

        private static Topic _t = null;
        public static string username = "";
        public static string forchat = "";
    }
}
