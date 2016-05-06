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
    public class DaMessage
    {
        public DaMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SelectMessageDetails(ref EnMessage message, ref EnMember member1, ref EnMemberProfile memberpro, ref EnMember member2, ref EnGroup group)
        {
            string strCommandText = "selMessageDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", message.MessageId);

            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            CrtMsgDetails(datrTopic, ref message, ref member1, ref memberpro, ref member2, ref group);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

        private void CrtMsgDetails(IDataReader reader, ref EnMessage msg, ref EnMember mbr1, ref EnMemberProfile mbrpro, ref EnMember mbr2, ref EnGroup grp)
        {
            if (reader.Read())
            {
                msg.Message = reader["Message"].ToString();
                msg.TopicId = int.Parse(reader["TopicId"].ToString());
                msg.IP = reader["IP"].ToString();
                msg.IsApproved = bool.Parse(reader["IsApproved"].ToString());
                msg.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
                msg.Edited = DateTime.Parse(reader["Edited"].ToString());
                msg.Signature = bool.Parse(reader["IsSigned"].ToString());
                mbr1.UserName = reader["Author"].ToString();
                mbr1.Email = reader["Email"].ToString();
                mbr1.DateCreation = DateTime.Parse(reader["DateCreation"].ToString());
                mbrpro.Location = reader["Location"].ToString();
                mbrpro.Yahoo = reader["Yahoo"].ToString();
                mbrpro.Aim = reader["Aim"].ToString();
                mbrpro.Icq = reader["Icq"].ToString();
                mbrpro.Msn = reader["Msn"].ToString();
                mbrpro.Blog = reader["Blog"].ToString();
                mbrpro.HomePage = reader["HomePage"].ToString();
                mbrpro.Avatar = reader["Avatar"].ToString();
                mbrpro.MemberTitle = reader["MemberTitle"].ToString();
                mbrpro.Signature = reader["Signature"].ToString();
                mbrpro.IsEmailPublished = bool.Parse(reader["IsEmailPublished"].ToString());
                mbrpro.TotalPosts = int.Parse(reader["TotalPosts"].ToString());
                mbrpro.UserStatus = bool.Parse(reader["UserStatus"].ToString());
                mbrpro.CanSendE = bool.Parse(reader["CanSendE"].ToString());
                mbrpro.Thank = int.Parse(reader["Thank"].ToString());
                mbrpro.Thanked = int.Parse(reader["Thanked"].ToString());
                mbrpro.MyRSS = reader["MyRss"].ToString();
                mbr2.UserName = reader["Editer"].ToString();
                grp.GroupName = reader["GroupName"].ToString();
                grp.RankImage = reader["RankImage"].ToString();
            }
        }

        public void InsertMessage(EnMessage msg, EnMember mbr)
        {
            string strCommandText = "insMessageNew";
            SqlParameter[] paraLocal = new SqlParameter[7];

            paraLocal[0] = new SqlParameter("@TopicId", msg.TopicId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[2] = new SqlParameter("@Title", msg.Title);
            paraLocal[3] = new SqlParameter("@Message", SqlDbType.NText);
            paraLocal[3].Value = msg.Message;
            paraLocal[4] = new SqlParameter("@IP", msg.IP);
            paraLocal[5] = new SqlParameter("@IsApproved", msg.IsApproved);
            paraLocal[6] = new SqlParameter("@Signature", msg.Signature);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int SelectTopicId(EnMessage msg)
        {
            string strCommandText = "selTopicInM";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);

            SqlDataReader datrTpc = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            int tpcid = CreateTopicId(datrTpc);
            if (datrTpc.IsClosed == false)
            {
                datrTpc.Close();
                datrTpc.Dispose();
            }
            return tpcid;
        }

        private int CreateTopicId(IDataReader reader)
        {
            int intTopicId = 0;
            if (reader.Read())
            {
                intTopicId = int.Parse(reader["TopicId"].ToString());
            }
            return intTopicId;
        }

        public int SelectForumId(EnMessage msg)
        {
            string strCommandText = "selForumInM";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);

            SqlDataReader datr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            int intForumId = CreateForumId(datr);
            if (datr.IsClosed == false)
            {
                datr.Close();
                datr.Dispose();
            }
            return intForumId;
        }

        private int CreateForumId(IDataReader reader)
        {
            int intFrmId = 0;
            if (reader.Read())
            {
                intFrmId = int.Parse(reader["ForumId"].ToString());
            }
            return intFrmId;
        }

        public EnMessage SelectMessage(EnMessage msg)
        {
            string strCommandText = "selMessageDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            SqlDataReader datr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            EnMessage n = new EnMessage();
            n = CreateMessage(datr);
            if (datr.IsClosed == false)
            {
                datr.Close();
                datr.Dispose();
            }
            return n;
        }

        private EnMessage CreateMessage(IDataReader reader)
        {
            EnMessage n = new EnMessage();
            if (reader.Read())
            {
                n.Message = reader["Message"].ToString();
                n.Signature = bool.Parse(reader["IsSigned"].ToString());
                n.AuthorName = reader["Author"].ToString();
            }
            return n;
        }

        public void UpdateMessage(EnMessage msg, EnMember mbr)
        {
            string strCommandText = "updMessage";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[2] = new SqlParameter("@Title", msg.Title);
            paraLocal[3] = new SqlParameter("@Message", SqlDbType.NText);
            paraLocal[3].Value = msg.Message;
            paraLocal[4] = new SqlParameter("@Signature", msg.Signature);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteMessage(EnMessage msg)
        {
            string strCommandText = "delMessage";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectMsgSearch(string strTake, string strView, EnPagerF pager, EnMember mbr)
        {
            string strCommandText = "selMessageSch";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@TakeIn", strTake.ToString());
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[3] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[4] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int SelectMsgSchCount(string strTake, string strView, EnMember mbr)
        {
            string strCommandText = "selMsgSchCount";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@TakeIn", strTake.ToString());
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[2].Value.ToString());
            return intCount;
        }

        public SqlDataReader SelectMsgForum(int intForumId, string strView, EnPagerF pager, EnMember mbr)
        {
            string strCommandText = "selMessageSchForum";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[3] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[4] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int SelectMsgForCount(int intForumId, string strView, EnMember mbr)
        {
            string strCommandText = "selMsgSchCountForum";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[2].Value.ToString());
            return intCount;
        }

        public int SelectMessageNex(EnTopic tpc)
        {
            string strCommandText = "selMessageNex";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicIdIn", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@TopicIdOut", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public int SelectMessagePre(EnTopic tpc)
        {
            string strCommandText = "selMessagePre";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicIdIn", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@TopicIdOut", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public int SelectTopicSchCount(int intForumId, string strView, EnMember mbr)
        {
            string strCommandText = "selTopicSchFCount";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[2].Value.ToString());
            return intCount;
        }

        public SqlDataReader SelectTopicSchF(int intForumId, string strView, EnPagerF pager, EnMember mbr)
        {
            string strCommandText = "selTopicSchForum";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[3] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[4] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int SelectTopicSchCountA(string strView, EnMember mbr)
        {
            string strCommandText = "selTopicSchFACount";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[1] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public SqlDataReader SelectTopicSchFA(string strView, EnPagerF pager, EnMember mbr)
        {
            string strCommandText = "selTopicSchForumA";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[3] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public SqlDataReader SearchAdvRes(int intForumId, string strView,bool bolTitle, EnMember mbr, bool bolOrder, EnPagerF pager, EnMember mbr2)
        {
            string strCommandText = "selSearchAdvance";
            SqlParameter[] paraLocal = new SqlParameter[8];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@View", strView.ToString());
            paraLocal[2] = new SqlParameter("@TitleOrMsg", bolTitle);
            paraLocal[3] = new SqlParameter("@Author", mbr.UserName);
            paraLocal[4] = new SqlParameter("@Order", bolOrder);
            paraLocal[5] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[6] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[7] = new SqlParameter("@UserName", mbr2.UserName);
            SqlDataReader dtrF = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return dtrF;
        }

        public int SearchAdvResCount(int intForumId, string strView, bool bolTitle, EnMember mbr, EnMember mbr2)
        {
            string strCommandText = "selSearchAdvCount";
            SqlParameter[] paraLocal = new SqlParameter[6];
            paraLocal[0] = new SqlParameter("@Forum", intForumId);
            paraLocal[1] = new SqlParameter("@StringView", strView.ToString());
            paraLocal[2] = new SqlParameter("@TitleOrMsg", bolTitle);
            paraLocal[3] = new SqlParameter("@Author", mbr.UserName);
            paraLocal[4] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[4].Direction = ParameterDirection.Output;
            paraLocal[5] = new SqlParameter("@UserName", mbr2.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[4].Value.ToString());
            return intCount;
        }

        public void UpdateMsgApproved(EnMessage msg, bool bolIsApproved)
        {
            string strCommandText = "updMessageApprove";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            paraLocal[1] = new SqlParameter("@Approve", bolIsApproved);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void InsertThanks(EnMessage msg, EnMember mbr)
        {
            string strCommandText = "insThanksMbr";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectThanks(EnMessage msg)
        {
            string strCommandText = "selThanks";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MessageId", msg.MessageId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

    }
}
