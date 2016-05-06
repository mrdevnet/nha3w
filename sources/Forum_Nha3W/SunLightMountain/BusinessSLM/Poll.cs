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
    public class BuPoll
    {
        public BuPoll()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertPoll(EnPoll poll, EnTopic topic, string str1, string str2, string str3, string str4,
                    string str5, string str6, string str7, string str8, string str9)
        {
            DaPoll newtopic = new DaPoll();
            newtopic.InsertTopicPoll(poll, topic, str1, str2, str3, str4, str5, str6, str7, str8, str9);
        }

        public static SqlDataReader SelectPollRus(EnTopic tpc, ref bool bolRus, ref EnPoll poll)
        {
            DaPoll p = new DaPoll();
            SqlDataReader datrTopic = p.SelectPollResult(tpc, ref bolRus, ref poll);
            return datrTopic;
        }

        public static void InsertVote(EnResult res, EnVote vote, EnMember mbr)
        {
            DaPoll newtopic = new DaPoll();
            newtopic.InsertVote(res, vote, mbr);
        }

        public static SqlDataReader SelectVoteRes(EnTopic tpc, ref int max, EnMember mbr, ref int count, ref EnPoll poll)
        {
            DaPoll p = new DaPoll();
            SqlDataReader datrTopic = p.SelectVoteRes(tpc, ref max, mbr, ref count, ref poll);
            return datrTopic;
        }

        public static bool SelectIsPoll(EnTopic tpc)
        {
            DaPoll p = new DaPoll();
            return p.SelectIsPoll(tpc);
        }
    }
}
