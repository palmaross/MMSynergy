using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindjet.MindManager.Interop;

namespace SynManager
{
    class TransactionsWrapper : SUtils
    {
        /// <summary>
        /// Set attributes to added topic
        /// </summary>
        /// <param name="_t">topic to set attrs</param>
        public static void SetAttributes(Topic _t)
        {
            tr_Topic = _t;
            Transaction _tr = _t.Document.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(TrSetAttributes);
            _tr.Start();
        }

        static void TrSetAttributes(Document doc)
        {
            string _attrs = TimeStamp + ";" + currentUserName + ";" + currentUserEmail;
            tr_Topic.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, tr_Topic.Guid);
            tr_Topic.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(TADDED, _attrs);
            tr_Topic.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(TMODIFIED, _attrs);
            tr_Topic = null; // important!!
        }

        public static void SetATTR(Topic _t, string _where, string _attrs)
        {
            tr_Topic = _t;
            tr_attrWhere = _where;
            tr_attrValue = _attrs;

            Transaction _tr = _t.Document.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(TrSetATTR);
            _tr.Start();
        }

        static void TrSetATTR(Document doc)
        {
            tr_Topic.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(tr_attrWhere, tr_attrValue);
            tr_Topic = null; // important!!
        }

        /// <summary>
        /// Set attributes to added relationship
        /// </summary>
        public static void SetAttributes(Relationship r, string _guid)
        {
            tr_Rel = r;
            tr_Guid = _guid;
            Transaction _tr = tr_Rel.Document.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(TrSetAttributesRel);
            _tr.Start();
        }

        static void TrSetAttributesRel(Document doc)
        {
            tr_Rel.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, tr_Guid);
            tr_Rel = null;
        }

        /// <summary>
        /// Set attributes to added boundary
        /// </summary>
        public static void SetAttributes(Boundary b, string _guid)
        {
            tr_Bnd = b;
            tr_Guid = _guid;
            Transaction _tr = tr_Bnd.Document.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(TrSetAttributesBnd);
            _tr.Start();
        }

        static void TrSetAttributesBnd(Document doc)
        {
            tr_Bnd.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, tr_Guid);
            tr_Bnd = null;
        }

        static string tr_attrWhere = "";
        static string tr_attrValue = "";
        static Topic tr_Topic = null;
        static Relationship tr_Rel = null;
        static Boundary tr_Bnd = null;
        static string tr_Guid = "";
    }
}
