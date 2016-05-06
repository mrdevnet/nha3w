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
using SLMF.Utility;

namespace SLMF.DataAccess
{
    public class DaPoll
    {
        public DaPoll()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertTopicPoll(EnPoll poll, EnTopic topic, string str1, string str2, string str3, string str4,
                    string str5, string str6, string str7, string str8, string str9)
        {
            string strCommandText = "insTopicPoll";
            SqlParameter[] paraLocal = new SqlParameter[13];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@Title", poll.Title);
            paraLocal[2] = new SqlParameter("@Repeat", poll.Repeat);
            paraLocal[3] = new SqlParameter("@FinishDate", poll.NumberOfFinish);
            paraLocal[4] = new SqlParameter("@Title1", str1);
            paraLocal[5] = new SqlParameter("@Title2", str2);
            paraLocal[6] = new SqlParameter("@Title3", str3);
            paraLocal[7] = new SqlParameter("@Title4", str4);
            paraLocal[8] = new SqlParameter("@Title5", str5);
            paraLocal[9] = new SqlParameter("@Title6", str6);
            paraLocal[10] = new SqlParameter("@Title7", str7);
            paraLocal[11] = new SqlParameter("@Title8", str8);
            paraLocal[12] = new SqlParameter("@Title9", str9);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectPollResult(EnTopic tpc, ref bool bolPoll, ref EnPoll poll)
        {
            string strCommandText = "selTopicPoll";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@Poll", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@Question", SqlDbType.NVarChar);
            paraLocal[2].Size = 360;
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@Total", SqlDbType.Int);
            paraLocal[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            bolPoll = bool.Parse(paraLocal[1].Value.ToString());
            if (bolPoll)
            {
                poll.Title = paraLocal[2].Value.ToString();
                poll.Total = int.Parse(paraLocal[3].Value.ToString());
            }
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public void InsertVote(EnResult res, EnVote vote, EnMember mbr)
        {
            string strCommandText = "insPollVote";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ResultId", res.ResultId);
            paraLocal[1] = new SqlParameter("@IP", vote.IP);
            paraLocal[2] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectVoteRes(EnTopic tpc, ref int intmax, EnMember mbr, ref int Count, ref EnPoll poll)
        {
            string strCommandText = "selVoteResult";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@Poll", SqlDbType.SmallInt);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[3] = new SqlParameter("@Sum", SqlDbType.Int);
            paraLocal[3].Direction = ParameterDirection.Output;
            paraLocal[4] = new SqlParameter("@Title", SqlDbType.NVarChar);
            paraLocal[4].Size = 360;
            paraLocal[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            intmax = int.Parse(paraLocal[1].Value.ToString());
            Count = int.Parse(paraLocal[3].Value.ToString());
            poll.Title = paraLocal[4].Value.ToString();
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public bool SelectIsPoll(EnTopic tpc)
        {
            string strCommandText = "selIsPoll";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@Poll", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[1].Value.ToString());
        }
    }
}
