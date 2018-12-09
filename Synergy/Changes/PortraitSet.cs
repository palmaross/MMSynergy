using System;
using Mindjet.MindManager.Interop;
using SynManager;

namespace Changes
{
    internal class PortraitSet : MMEnums
    {
        public static void TopicPortrait(Topic t, string what, string _value, string mapFolderPath)
        {
            int newline = _value.IndexOf(Environment.NewLine);
            string rootfolder = mapFolderPath;
            string firstline = "", nextline = "";

            if (newline == -1)
            {
                firstline = _value;
            }
            else
            {
                firstline = _value.Substring(0, _value.IndexOf("\r\n"));
                nextline = _value.Substring(_value.IndexOf("\r\n") + 2);
            }
///TEXT
            if (what == "text")
            {
                t.Text = _value;
            }
            else if (what == "rtf")
            {
                t.Title.TextRTF = _value;
            }
            else if (what == "font")
            {
                string[] _fontvalues = firstline.Split(';');

                t.Text = nextline;

                if (t.TextColor.Value.ToString() != _fontvalues[0])
                    t.TextColor.Value = Convert.ToInt32(_fontvalues[0]);
                if (t.Font.Bold.ToString() != _fontvalues[1])
                    t.Font.Bold = Convert.ToBoolean(_fontvalues[1]);
                if (t.Font.Italic.ToString() != _fontvalues[2])
                    t.Font.Italic = Convert.ToBoolean(_fontvalues[2]);
                if (t.Font.Strikethrough.ToString() != _fontvalues[3])
                    t.Font.Strikethrough = Convert.ToBoolean(_fontvalues[3]);
                if (t.Font.Underline.ToString() != _fontvalues[4])
                    t.Font.Underline = Convert.ToBoolean(_fontvalues[4]);
                if (t.Font.Size.ToString() != _fontvalues[5])
                    t.Font.Size = Convert.ToSingle(_fontvalues[5]);
                if (t.Font.Name != _fontvalues[6])
                    t.Font.Name = _fontvalues[6];
            }
///TASK
            else if (what == "task")
            {
                if (firstline == "empty")
                {
                    if (t.Task.HasEffort)
                        t.Task.SetEffort(MmDurationUnit.mmDurationUnitDay, 0);
                    t.Task.Complete = -1;
                    t.Task.Priority = MmTaskPriority.mmTaskPriorityNone;
                    t.Task.Resources = "";
                    t.Task.StartDate = MMUtils.NULLDATE;
                    t.Task.DueDate = MMUtils.NULLDATE;
                    t.Task.Milestone = false;
                }
                else
                {
                    string[] _taskvalues = firstline.Split(';');
                    t.Task.Complete = Convert.ToInt32(_taskvalues[0]);
                    t.Task.Priority = MMEnums.Priority(_taskvalues[1]);
                    t.Task.Resources = _taskvalues[2];
                    t.Task.StartDate = Convert.ToDateTime(_taskvalues[3]);
                    t.Task.DueDate = Convert.ToDateTime(_taskvalues[4]);
                    t.Task.DurationUnit = MMEnums.DurationUnit(_taskvalues[5]);
                    t.Task.Milestone = Convert.ToBoolean(_taskvalues[6]);
                    if (_taskvalues[7] == "0")
                    {
                        if (t.Task.HasEffort)
                            t.Task.SetEffort(MmDurationUnit.mmDurationUnitDay, 0);
                    }
                    else
                    {
                        t.Task.EffortUnit = MMEnums.DurationUnit(_taskvalues[7]);
                        t.Task.SetEffort(t.Task.EffortUnit, Convert.ToInt32(_taskvalues[8]));
                    }
                }
            }
///NOTES
            else if (what == "notes")
            {
                string _notesText = firstline;

                if (_notesText == "empty")
                    t.Notes.Text = "";
                else
                {
                    try
                    {
                        t.Notes.TextXHTML = _notesText;
                        t.Notes.Commit();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "Receiving Notes");
                    }
                }
            }
///LINKS
            else if (what == "link")
            {
                foreach (Hyperlink _h in t.Hyperlinks)
                    t.Hyperlinks.Remove(1);

                if (firstline == "empty")
                    return;

                string[] _links;

                if (nextline == "")
                {
                    _links = new string[] { firstline };
                }
                else
                {
                    firstline = firstline + "\r\n" + nextline;
                    nextline = firstline.Replace("\r", "");
                    _links = nextline.Split('\n');
                }

                foreach (string _link in _links)
                {
                    string _what = _link.Substring(0, firstline.IndexOf(":"));
                    string _hlink = _link.Substring(firstline.IndexOf(":") + 1);

                    if (_what == "web" || _what == "file")
                    {
                        t.Hyperlinks.AddHyperlink(_hlink);
                    }
                    else
                    {
                        if (_what == "localtopic")
                        {
                            string _guid = SUtils.FindTopicByAttrGuid(t.Document, _hlink).Guid;
                            t.Hyperlinks.AddHyperlinkToTopicByGuid(_guid);
                        }

                        if (_what == "remotetopic")
                        {
                            string _address = _hlink.Substring(0, _hlink.LastIndexOf(":"));
                            string _guid = _hlink.Substring(_hlink.LastIndexOf(":") + 1);
                            t.Hyperlinks.AddHyperlinkToTopicByGuid(_guid, _address);
                        }
                    }
                }
            }
///NUMBERING
            else if (what == "numbering")
            {
                string ss = t.Text;
                string numbering = SUtils.numberinguri;
                //System.Windows.Forms.Clipboard.SetText(t.Xml);
                if (firstline == "empty")
                    t.get_Attributes(numbering).DeleteAll();
                else
                {
                    string rr = "";
                    string[] nvalues = firstline.Split(';');
                    if (t.ContainsAttributesNamespace(numbering))
                        rr = t.get_Attributes(numbering).GetAttributeValue("Depth");
                    t.get_Attributes(numbering).SetAttributeValue("Depth", nvalues[0].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Level1Text", nvalues[1].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Level2Text", nvalues[2].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Level3Text", nvalues[3].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Level4Text", nvalues[4].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Level5Text", nvalues[5].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Numbering", nvalues[6].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Separators", nvalues[7].ToString());
                    t.get_Attributes(numbering).SetAttributeValue("Repeat", nvalues[8].ToString());
                }
            }
///IMAGE
            else if (what == "oneimage")
            {
                if (t.HasImage)
                    t.Image.Delete();

                if (firstline != "empty")
                {
                    string[] imgvalues = firstline.Split(';');
                    string _filename = imgvalues[0];
                    string _path = rootfolder + _filename;

                    if (t.HasImage)
                        t.Image.Load(_path);
                    else
                        t.CreateImage(_path);

                    t.Image.Height = Convert.ToSingle(imgvalues[1]);
                    t.Image.Width = Convert.ToSingle(imgvalues[2]);
                }
            }
//ICONS
            else if (what == "icons")
            {
                //renove all user icons
                if (t.UserIcons.Count > 0)
                    t.UserIcons.RemoveAll();

                if (firstline == "emptyall")
                {
                    t.Task.Complete = -1;
                    t.Task.Priority = MmTaskPriority.mmTaskPriorityNone;
                }

                if (firstline == "empty" || firstline == "emptyall")
                    return;

                AddIcon(t, firstline, mapFolderPath);

                if (nextline != "")
                {
                    nextline = nextline.Replace("\r", "");
                    string[] _usericons = nextline.Split('\n');

                    foreach (string _iconname in _usericons)
                    {
                        AddIcon(t, _iconname, mapFolderPath);
                    }

                    _usericons = null;
                }
            }

            else if (what == "color")
            {
                string[] _colorvalues = firstline.Split(';');

                if (_colorvalues[0] == "isautomatic")
                    t.FillColor.SetAutomatic();
                else
                    t.FillColor.Value = Convert.ToInt32(_colorvalues[0]);

                if (_colorvalues[1] == "isautomatic")
                    t.LineColor.SetAutomatic();
                else
                    t.LineColor.Value = Convert.ToInt32(_colorvalues[1]);
            }

            else if (what == "subtopicshape")
            {
                if (firstline == "isautomatic")
                    t.Shape.SetAutomatic();
                else
                {
                    string[] _shapevalues = firstline.Split(';');

                    MmStandardTopicShape x = StandardTopicShape(_shapevalues[0]);
                    MmFloatingTopicShape y = FloatingTopicShape(_shapevalues[1]);
                    MmCalloutTopicShape z = CalloutTopicShape(_shapevalues[1]);

                    t.Shape.SetTypes(x, y, z);
                }
            }
        }

        private static void AddIcon(Topic _t, string value, string iconpath)
        {
            MmStockIcon _ico = StockIcon(value);
            if (_ico != 0)
            {
                _t.UserIcons.AddStockIcon(_ico, false); //TODO bool toggleIfMapMarker = mutual-exclusive
            }
            else
            {
                value = iconpath + value;
                _t.UserIcons.AddCustomIcon(value, false); //TODO see above
            }

            _ico = 0;
        }
    }
}
