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
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuMessage
    {
        public BuMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void SelectMsgDetails(ref EnMessage message, ref EnMember member1, ref EnMemberProfile memberpro, ref EnMember member2, ref EnGroup group)
        {
            DaMessage msg = new DaMessage();
            msg.SelectMessageDetails(ref message, ref member1, ref memberpro, ref member2, ref group);
        }

        public static void InsertMessage(EnMessage msg, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            n.InsertMessage(msg, mbr);
        }

        public static int SelectTopicId(EnMessage msg)
        {
            DaMessage n = new DaMessage();
            int intTpcId = n.SelectTopicId(msg);
            return intTpcId;
        }

        public static int SelectForumId(EnMessage msg)
        {
            DaMessage n = new DaMessage();
            int intFrmId = n.SelectForumId(msg);
            return intFrmId;
        }

        public static EnMessage SelectMessage(EnMessage msg)
        {
            EnMessage n = new EnMessage();
            DaMessage dn = new DaMessage();
            n = dn.SelectMessage(msg);
            return n;
        }

        public static void UpdateMessage(EnMessage msg, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            n.UpdateMessage(msg, mbr);
        }

        public static void DeleteMessage(EnMessage msg)
        {
            DaMessage n = new DaMessage();
            n.DeleteMessage(msg);
        }

        public static SqlDataReader SelectMsgSearch(string strTake, string strView, EnPagerF pager, EnMember mbr)
        {
            DaMessage topic = new DaMessage();
            SqlDataReader datrTopic = topic.SelectMsgSearch(strTake, strView, pager, mbr);
            return datrTopic;
        }

        public static int SelectMsgSearchCount(string strTake, string strView, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            int intItems = n.SelectMsgSchCount(strTake, strView, mbr);
            return intItems;
        }

        public static SqlDataReader SelectMsgForum(int intForum, string strView, EnPagerF pager, EnMember mbr)
        {
            DaMessage topic = new DaMessage();
            SqlDataReader datrTopic = topic.SelectMsgForum(intForum, strView, pager, mbr);
            return datrTopic;
        }

        public static int SelectMsgForCount(int intForum, string strView, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            int intItems = n.SelectMsgForCount(intForum, strView, mbr);
            return intItems;
        }

        public static int SelectMessageNex(EnTopic tpc)
        {
            DaMessage n = new DaMessage();
            int intTpcId = n.SelectMessageNex(tpc);
            return intTpcId;
        }

        public static int SelectMessagePre(EnTopic tpc)
        {
            DaMessage n = new DaMessage();
            int intTpcId = n.SelectMessagePre(tpc);
            return intTpcId;
        }

        public static int SelectTpcSchCount(int intForum, string strView, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            int intItems = n.SelectTopicSchCount(intForum, strView, mbr);
            return intItems;
        }

        public static SqlDataReader SelectTpcSchForum(int intForum, string strView, EnPagerF pager, EnMember mbr)
        {
            DaMessage topic = new DaMessage();
            SqlDataReader datrTopic = topic.SelectTopicSchF(intForum, strView, pager, mbr);
            return datrTopic;
        }

        public static int SelectTpcSchCountA(string strView, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            int intItems = n.SelectTopicSchCountA(strView, mbr);
            return intItems;
        }

        public static SqlDataReader SelectTpcSchForumA(string strView, EnPagerF pager, EnMember mbr)
        {
            DaMessage topic = new DaMessage();
            SqlDataReader datrTopic = topic.SelectTopicSchFA(strView, pager, mbr);
            return datrTopic;
        }

        public static SqlDataReader SearchAdv(int forumid, string strView,
                bool bolTitle, EnMember mbr, bool bolOrder, EnPagerF pager, EnMember mbr2)
        {
            DaMessage adv = new DaMessage();
            SqlDataReader dtrAdv = adv.SearchAdvRes(forumid, strView, bolTitle, mbr, bolOrder, pager, mbr2);
            return dtrAdv;
        }

        public static int SearchAdvCount(int intForumId, string strView, bool bolTitle, EnMember mbr, EnMember mbr2)
        {
            DaMessage n = new DaMessage();
            int intItems = n.SearchAdvResCount(intForumId, strView, bolTitle, mbr, mbr2);
            return intItems;
        }

        public static void UpdateMsgApproved(EnMessage msg, bool bolIsApproved)
        {
            DaMessage n = new DaMessage();
            n.UpdateMsgApproved(msg, bolIsApproved);
        }

        public static void InsertThanks(EnMessage msg, EnMember mbr)
        {
            DaMessage n = new DaMessage();
            n.InsertThanks(msg, mbr);
        }

        public static SqlDataReader SelectThanks(EnMessage msg)
        {
            DaMessage n = new DaMessage();
            return n.SelectThanks(msg);
        }
    }
}
