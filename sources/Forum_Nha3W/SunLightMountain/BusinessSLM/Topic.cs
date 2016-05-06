using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using SLMF.Entity;
using SLMF.DataAccess;


namespace SLMF.Business
{
    public class BuTopic
    {
        public BuTopic()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectTopic(EnForum forum, EnPagerF pager)
        {
            DaTopic topic = new DaTopic();
            SqlDataReader datrTopic = topic.SelectTopic(forum, pager);
            return datrTopic;
        }

        public static int InsertTopic(EnMember member, EnForum forum, EnTopic topic, EnMessage message)
        {
            DaTopic newtopic = new DaTopic();
            int inta = 0;
            inta = newtopic.InsertTopic(member, forum, topic, message);
            return inta;
        }

        public static void SelectTopicDetails(ref EnTopic topic, ref EnMember member1, ref EnMember member2, ref EnMessage message)
        {
            DaTopic newtopic = new DaTopic();
            newtopic.SelectTopicDetails(ref topic, ref member1, ref member2, ref message);
        }

        public static SqlDataReader SelectShowTopic(EnTopic topic, EnPagerF pager)
        {
            DaTopic datopic = new DaTopic();
            SqlDataReader datr = datopic.SelectShowTopic(topic, pager);
            return datr;
        }

        public static SqlDataReader SelectTopicLinks(EnTopic topic)
        {
            DaTopic dato = new DaTopic();
            SqlDataReader datr = dato.SelectTopicLinks(topic);
            return datr;
        }

        public static EnForum SelectForumId(EnTopic topic)
        {
            DaTopic topicnew = new DaTopic();
            EnForum forum = new EnForum();
            forum = topicnew.SelectForumId(topic);
            return forum;
        }

        public static int SelectLastMessage(EnTopic tpc)
        {
            DaTopic t = new DaTopic();
            int intResult = t.SelectLastMessage(tpc);
            return intResult;
        }

        public static void DeleteTopic(EnTopic tpc)
        {
            DaTopic t = new DaTopic();
            t.DeleteTopic(tpc);
        }

        public static int SelectItemCount(EnTopic tpc)
        {
            DaTopic n = new DaTopic();
            int intItems = n.SelectItemCount(tpc);
            return intItems;
        }

        public static void UpdateViews(EnTopic tpc)
        {
            DaTopic t = new DaTopic();
            t.UpdateViews(tpc);
        }

        public static int SelectRowId(EnTopic topic, EnPagerF pager, EnMessage msg)
        {
            DaTopic datopic = new DaTopic();
            return datopic.SelectRowId(topic, pager, msg);
        }

        public static int SelectRecordId(EnTopic topic, EnMessage msg)
        {
            DaTopic datopic = new DaTopic();
            return datopic.SelectRecordId(topic, msg);
        }

        public static SqlDataReader SelectList(string strLst, EnPagerF pager, EnMember mbr)
        {
            DaTopic topic = new DaTopic();
            SqlDataReader datrTopic = topic.SelectList(strLst, pager, mbr);
            return datrTopic;
        }

        //public static SqlDataReader SelectLive(EnMember mbr)
        //{
        //    DaTopic tp = new DaTopic();
        //    SqlDataReader datrLive = tp.SelectTopicLive(mbr);
        //    return datrLive;
        //}

        private static List<EnTopic> LstSelLive(EnMember mbr)
        {
            DaTopic tp = new DaTopic();
            string ch = "LstSelectLives" + mbr.UserName;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, tp.SelectTopicLive(mbr), "SelectLives");
            }
            return (List<EnTopic>)BServer.Get(ch);
        }

        public static List<EnTopic> SelectLive(EnMember mbr)
        {
            List<EnTopic> tmp = new List<EnTopic>();
            tmp = LstSelLive(mbr);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectLives", true);
                tmp = LstSelLive(mbr);
            }
            return tmp;
        }



        //public static SqlDataReader SelectLive2(EnMember mbr)
        //{
        //    DaTopic tp = new DaTopic();
        //    SqlDataReader datrLive = tp.SelectTopicLive2(mbr);
        //    return datrLive;
        //}

        private static List<EnTopic> LstSelLive2(EnMember mbr)
        {
            DaTopic tp = new DaTopic();
            string ch = "LstSelectLives2" + mbr.UserName;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, tp.SelectTopicLive2(mbr), "SelectLives");
            }
            return (List<EnTopic>)BServer.Get(ch);
        }

        public static List<EnTopic> SelectLive2(EnMember mbr)
        {
            List<EnTopic> tmp = new List<EnTopic>();
            tmp = LstSelLive2(mbr);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectLives", true);
                tmp = LstSelLive2(mbr);
            }
            return tmp;
        }

        public static SqlDataReader SelectTopicSort(EnForum forum, EnPagerF pager, int intSortId)
        {
            DaTopic topic = new DaTopic();
            SqlDataReader datrTopic = topic.SelectTopicSort(forum, pager, intSortId);
            return datrTopic;
        }

        public static void LockTopic(EnTopic topic, bool bolIsLock)
        {
            DaTopic t = new DaTopic();
            t.LockTopic(topic, bolIsLock);
        }

        public static void UpdateMoveTo(EnTopic topic, bool bolTypeId)
        {
            DaTopic t = new DaTopic();
            t.UpdateMoveTo(topic, bolTypeId);
        }

        public static bool SelectTypeTopic(EnTopic topic, EnMember mbr, ref int TypeId)
        {
            DaTopic t = new DaTopic();
            return t.SelectTypeTopic(topic, mbr, ref TypeId);
        }
    }
}
