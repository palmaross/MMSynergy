using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Mindjet.MindManager.Interop;
using System.IO;
using SynManager;

namespace Changes
{
    class PortraitGet : MMUtils
    {
        public static string TopicPortrait(Topic t, ref string what, string extra, string mapFolderPath)
        {
            if (what == "numbering" || what == "notesdata" || what == "businessdata")
                return "queue";

            string _return = "";
            string s = "";
            string rootfolder = mapFolderPath + "share\\";
//TEXT
            if (what == "text")
            {
                xRoot(t.Xml);
                XmlNode _nodeFont = m_root.SelectSingleNode("ap:Text/ap:Font", NSManager);
                XmlNode _nodeFontRange = m_root.SelectSingleNode("ap:Text/ap:FontRange", NSManager);

                if (_nodeFontRange != null && _nodeFontRange.Attributes.Count > 0) // rtf
                {
                    what = "rtf";
                    _return = t.Title.TextRTF;
                }
                else if (_nodeFont != null && _nodeFont.Attributes.Count > 0) // font
                {
                    s = MMEnums.GetFont(t);
                    what = "font";
                    _return = s + "\r\n" + t.Text;
                }
                else // plain text
                {
                    _return = t.Text;
                }

                _nodeFont = null; _nodeFontRange = null; m_manager = null; m_root = null; xDoc = null;
                return _return;
            }
//TASK
            if (what == "task")
            {
                if (t.Task.IsEmpty)
                    return "empty";

                s = t.Task.Complete.ToString() + ";" +
                    t.Task.Priority.ToString() + ";" +
                    t.Task.Resources + ";" +
                    t.Task.StartDate.ToString() + ";" +
                    t.Task.DueDate.ToString() + ";" +
                    t.Task.DurationUnit.ToString() + ";" +
                    t.Task.Milestone.ToString() + ";";

                if (!t.Task.HasEffort)
                    s = s + "0;0";
                else
                    s = s + t.Task.EffortUnit.ToString() + ";" + t.Task.GetEffort(t.Task.EffortUnit).ToString();

                return s;
            }
//NOTES
            if (what == "notesxhtmldata")
            {
                what = "notes";

                if (t.Notes.IsEmpty)
                    return "empty";

                string cleanXML = MMUtils.getCleanTopicXML(t.Xml);
                int _start = cleanXML.IndexOf("<html xmlns");
                int _finish = cleanXML.IndexOf("</ap:NotesXhtmlData>");
                string _noteshtml = cleanXML.Substring(_start, _finish - _start);
                string _head = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"          " +
                               "\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
                _noteshtml = _head + _noteshtml;

                return _noteshtml;
            }
//LINKS
            if (what == "hyperlink" || what == "indexedhyperlink")
            {
                what = "link";

                if (!t.HasHyperlink)
                    return "empty";

                foreach (Hyperlink _h in t.Hyperlinks)
                {
                    string _address = _h.Address;
                    string _guid = _h.TopicLabelGuid;

                    if (_guid == "") //ссылка на файл или web-страницу
                    {
                        if (_address.Substring(0, 4) == "http") //на web-страницу
                            s = s + "web:" + _address + "\r\n";
                        else //TODO local file
                        {
                            s = s + "file:" + _address + "\r\n";

                            //int a = _address.LastIndexOf("\\") + 1; // filename only
                            //s = s + "file:" + _address.Substring(a) + "\r\n";
                            // TODO File.Copy(_address, rootfolder + _address.Substring(a)); // copy to share folder in Place

                            if (_address.Substring(_address.Length - 5) == ".mmap") //ссылка на карту
                            {
                                // TODO

                                //Document _doc = MMUtils.MindManager.AllDocuments.Open(_address, "", false);

                                //if (!_doc.ContainsAttributesNamespace(SYNERGYNAMESPACE)) //publish this map if it is not published
                                //{
                                //    PublishMap(
                                //        _doc, _doc.Guid,
                                //        GetRegistry("", "CurrentUserName"),
                                //        GetRegistry("", "CurrentUserEmail"),
                                //        false  // TODO single map or project!
                                //        );

                                //    _doc.SaveAs(rootfolder + _doc.Name);
                                //    _h.Address = _doc.Name;

                                //    if (!_doc.Window.IsVisible)
                                //        _doc.Close();
                                //}
                            }                       
                        }
                    }
                    else //ссылка на топик
                    {
                        if (_address == "") //в этой же карте
                        {
                            Topic _t = MMUtils.FindTopicByGuid(MMUtils.ActiveDocument, _guid);
                            s = s + "localtopic:" + _t.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID) + "\r\n";
                            _t = null;
                        }
                        else //в другой карте
                        {
                            s = s + "remotetopic:" + _address + ":" + _guid + "\r\n"; //TODO remote topic OGUID?
                        }
                    }
                }

                return s.Remove(s.LastIndexOf("\r\n"), 2);
            }
//NUMBERING
            if (what == "numbering")
            {
                if (!t.HasAttributesNamespace[SUtils.numberinguri])
                    return "empty";
                return MMEnums.GetNumbering(t);
            }
//IMAGE
            if (what == "oneimage")
            {
                if (!t.HasImage)
                    return "empty";

                string _filename = SUtils.modtime + ".png";
                string _path = rootfolder + _filename;
                t.Image.Save(_path, MmGraphicType.mmGraphicTypePng);
                return _filename + ";" + t.Image.Height.ToString() + ";" + t.Image.Width.ToString();
            }

//ICONS
            if (what == "icons" || what == "customiconimagedata")
            {
                what = "icons";

                if (t.UserIcons.Count == 0)
                {
                    if (t.Task.Complete == -1 && t.Task.Priority == MmTaskPriority.mmTaskPriorityNone)
                        return "emptyall";
                    return "empty";
                }

                foreach (Icon _ico in t.UserIcons)
                {
                    if (_ico.Type == MmIconType.mmIconTypeAutomaticTaskComplete ||
                        _ico.Type == MmIconType.mmIconTypeAutomaticTaskPriority)
                        continue;
                    if (_ico.Type == MmIconType.mmIconTypeStock)
                        s = s + _ico.StockIcon.ToString() + "\r\n";
                    if (_ico.Type == MmIconType.mmIconTypeCustom)
                    {
                        string _filename = SUtils.modtime + "&" + SUtils.currentUserName + ".ico";
                        string _path = rootfolder + _filename;

                        _ico.Save(_path, MmGraphicType.mmGraphicTypeGif);
                        s = s + _filename + "\r\n";
                    }
                }

                return s.Remove(s.LastIndexOf("\r\n"), 2);
            }

            if (what == "color")
            {
                if (t.FillColor.IsAutomatic)
                    s = "isautomatic;";
                else
                    s = t.FillColor.Value.ToString() + ";";

                if (t.LineColor.IsAutomatic)
                    return s + "isautomatic";
                else
                    return s + t.LineColor.Value.ToString();
            }

            if (what == "subtopicshape")
            {
                t.Shape.GetAutomatic(out bool xx, out bool yy, out bool zz);
                if (xx && yy && zz)
                    return "isautomatic";

                t.Shape.GetTypes(out MmStandardTopicShape x, out MmFloatingTopicShape y, out MmCalloutTopicShape z);
                return x.ToString() + ";" + y.ToString() + ";" + z.ToString();
            }

            if (what == "offset")
                return "offset";

            return "queue";
        }

        static void xRoot(string objXML)
        {
            xDoc = new XmlDocument();
            xDoc.LoadXml(objXML);
            m_root = xDoc.DocumentElement;
        }

        protected static XmlNamespaceManager NSManager
        {
            get
            {
                if (m_manager == null)
                {
                    m_manager = new XmlNamespaceManager(m_root.OwnerDocument.NameTable);
                    m_manager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
                    m_manager.AddNamespace("ap", "http://schemas.mindjet.com/MindManager/Application/2003");
                    m_manager.AddNamespace("pri", "http://schemas.mindjet.com/MindManager/Primitive/2003");
                    m_manager.AddNamespace("cor", "http://schemas.mindjet.com/MindManager/Core/2003");
                    m_manager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                }
                return m_manager;
            }
        }

        protected static XmlNamespaceManager m_manager = null;
        protected static XmlNode m_root = null;
        protected static XmlDocument xDoc = null;
    }
}
