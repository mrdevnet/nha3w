using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
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
    public class DaTopic
    {
        public DaTopic()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectTopic(EnForum forum, EnPagerF pager)
        {
            string strCommandText = "selTopicMessage";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int InsertTopic(EnMember member, EnForum forum, EnTopic topic, EnMessage message)
        {
            string strCommandText = "insTopicNew";
            SqlParameter[] paraLocal = new SqlParameter[9];

            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@IsPinned", topic.IsPinned);
            paraLocal[2] = new SqlParameter("@UserName", member.UserName);
            paraLocal[3] = new SqlParameter("@IsApproved", topic.IsApproved);
            paraLocal[4] = new SqlParameter("@Title", message.Title);
            paraLocal[5] = new SqlParameter("@Message", SqlDbType.NText);
            paraLocal[5].Value = message.Message;
            paraLocal[6] = new SqlParameter("@IP", message.IP);
            paraLocal[7] = new SqlParameter("@Signature", message.Signature);
            paraLocal[8] = new SqlParameter("@TopicNew", SqlDbType.Int);
            paraLocal[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[8].Value.ToString());
            return intResult;
        }

        public void SelectTopicDetails(ref EnTopic topic, ref EnMember member1, ref EnMember member2, ref EnMessage message)
        {
            string strCommandText = "selTopicDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);

            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            CreateTopicDetails(datrTopic, ref member1, ref member2, ref message, ref topic);

            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

        private void CreateTopicDetails(IDataReader reader,ref EnMember member1, ref EnMember member2, ref EnMessage message, ref EnTopic topic)
        {
            if (reader.Read())
            {
                member1.UserName = reader["Starter"].ToString();
                member1.MemberId = int.Parse(reader["StarterId"].ToString());
                message.Title = reader["Title"].ToString();
                member2.UserName = reader["LastPoster"].ToString();
                member2.MemberId = int.Parse(reader["LastPosterId"].ToString());
                message.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
                message.MessageId = int.Parse(reader["LastMessage"].ToString());
                topic.IsPinned = bool.Parse(reader["IsPinned"].ToString());
                topic.IsLocked = bool.Parse(reader["IsLocked"].ToString());
            }            
        }

        public SqlDataReader SelectShowTopic(EnTopic topic, EnPagerF pager)
        {
            string strCommandText = "selShowTopic";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            SqlDataReader datr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datr;
        }

        public SqlDataReader SelectTopicLinks(EnTopic topic)
        {
            string strCommandText = "selTopicLinks";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public EnForum SelectForumId(EnTopic topic)
        {
            string strCommandText = "selForumInT";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[1].Value.ToString());
            EnForum forum = new EnForum();
            forum.ForumId = intResult;
            return forum;
        }

        public int SelectLastMessage(EnTopic tpc)
        {
            string strCommandText = "selTopicLastM";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[1].Value.ToString());
            return intResult;
        }

        public void DeleteTopic(EnTopic topic)
        {
            string strCommandText = "delTopic";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int SelectItemCount(EnTopic topic)
        {
            string strCommandText = "selMessageCount";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);            
            paraLocal[1] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public void UpdateViews(EnTopic topic)
        {
            string strCommandText = "updTopicViews";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int SelectRowId(EnTopic topic, EnPagerF pager, EnMessage msg)
        {
            string strCommandText = "selShowTopic";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            SqlDataReader datr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intId = CreateRowId(datr, msg);
            if (datr.IsClosed == false)
            {
                datr.Close();
                datr.Dispose();
            }
            return intId;
        }

        private int CreateRowId(IDataReader reader, EnMessage msg)
        {
            int intRowId = 0;
            while (reader.Read())
            {
                if (msg.MessageId == int.Parse(reader["MessageId"].ToString()))
                {
                    intRowId = int.Parse(reader["RecordId"].ToString());
                }
            }
            return intRowId;
        }

        public int SelectRecordId(EnTopic topic, EnMessage msg)
        {
            string strCommandText = "selMessageRec";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            SqlDataReader datr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intId = CreateRecId(datr, msg);
            if (datr.IsClosed == false)
            {
                datr.Close();
                datr.Dispose();
            }
            return intId;
        }

        private int CreateRecId(IDataReader reader, EnMessage msg)
        {
            int intRowId = 0;
            while (reader.Read())
            {
                if (msg.MessageId == int.Parse(reader["MessageId"].ToString()))
                {
                    intRowId = int.Parse(reader["RecordId"].ToString());
                }
            }
            return intRowId;
        }

        public SqlDataReader SelectList(string strList, EnPagerF pager, EnMember mbr)
        {
            string strCommandText = "selTopicActLst";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@TakeIn", strList.ToString());
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[3] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        //public SqlDataReader SelectTopicLive(EnMember mbr)
        //{
        //    string strCommandText = "selTopicLive";
        //    SqlParameter[] paraLocal = new SqlParameter[1];
        //    paraLocal[0] = new SqlParameter("@UserName", mbr.UserName);
        //    SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    return datrTopic;
        //}

        public List<EnTopic> SelectTopicLive(EnMember mbr)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UserName", mbr.UserName);
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selTopicLive", pr))
            {
                List<EnTopic> p = new List<EnTopic>();
                while (r.Read())
                {
                    p.Add(PstTpcLive(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EnTopic PstTpcLive(IDataReader i)
        {
            EnTopic p = new EnTopic();
            p.Title = (string)i["Title"];
            p.TopicId = (int)i["TopicId"];
            p.Name = (string)i["Name"];
            p.TotalViews = (int)i["TotalViews"];
            p.TotalReplies = (int)i["TotalReplies"];
            p.LastAuthor = (string)i["LastAuthor"];
            p.LastAuthorId = (int)i["LastAuthorId"];
            p.MessageId = (int)i["MessageId"];
            return p;
        }


        //public SqlDataReader SelectTopicLive2(EnMember mbr)
        //{
        //    string strCommandText = "selTopicLive2";
        //    SqlParameter[] paraLocal = new SqlParameter[1];
        //    paraLocal[0] = new SqlParameter("@UserName", mbr.UserName);
        //    SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    return datrTopic;
        //}

        public List<EnTopic> SelectTopicLive2(EnMember mbr)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UserName", mbr.UserName);
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selTopicLive2", pr))
            {
                List<EnTopic> p = new List<EnTopic>();
                while (r.Read())
                {
                    p.Add(PstTpcLive(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public SqlDataReader SelectTopicSort(EnForum forum, EnPagerF pager, int intSortId)
        {
            string strCommandText = "selTopicMsgSort";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            paraLocal[3] = new SqlParameter("@SortId", intSortId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public void LockTopic(EnTopic topic, bool bolIsLock)
        {
            string strCommandText = "updTopicIsLocked";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@Lock", bolIsLock);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateMoveTo(EnTopic topic, bool bolTypeId)
        {
            string strCommandText = "updTopicMoveTo";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@ForumId", topic.MoveTo);
            paraLocal[2] = new SqlParameter("@TypeId", bolTypeId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public bool SelectTypeTopic(EnTopic topic, EnMember mbr, ref int TypeId)
        {
            string strCommandText = "selTypeTopic";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@TopicId", topic.TopicId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[2] = new SqlParameter("@TypeId", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@AccessId", SqlDbType.Bit);
            paraLocal[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            TypeId = int.Parse(paraLocal[2].Value.ToString());
            return bool.Parse(paraLocal[3].Value.ToString());
        }
    }
}
