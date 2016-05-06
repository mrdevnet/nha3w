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

namespace SLMF.DataAccess
{
    public class DaForum
    {
        public DaForum()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        //public SqlDataReader SelectForum(EnCategory category, EnMember mbr)
        //{
        //    string strCommandText = "selForumList";

        //    SqlParameter[] paraLocal = new SqlParameter[2];
        //    paraLocal[0] = new SqlParameter("@CategoryId", category.CategoryId);
        //    paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
        //    SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    return datrCate;
        //}

        public List<EnForum> SelectForum(EnCategory category, EnMember mbr)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@CategoryId", category.CategoryId);
            pr[1] = new SqlParameter("@UserName", mbr.UserName);
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selForumList", pr))
            {
                List<EnForum> p = new List<EnForum>();
                while (r.Read())
                {
                    p.Add(PstSelForum(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EnForum PstSelForum(IDataReader i)
        {
            EnForum p = new EnForum();
            p.ForumId = (int)i["ForumId"];
            p.Name = (string)i["Name"];
            p.Description = (string)i["Description"];
            p.TypeId = (int)i["TypeId"];
            return p;
        }


        public SqlDataReader SelectForumSubDesc(EnForum forum)
        {
            string strCommandText = "selForumSubDesc";

            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);

            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            return datrCate;
        }

        public void SelectForumInCate(ref EnForum forum, ref EnCategory category)
        {
            string strCommandText = "selForumInCate";

            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);

            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            CreateForumInCate(datrCate, ref forum, ref category);

            if (datrCate.IsClosed == false)
            {
                datrCate.Close();
                datrCate.Dispose();
            }
        }

        private void CreateForumInCate(IDataReader reader,ref EnForum forum, ref EnCategory category)
        {
            if (reader.Read())
            {
                forum.ForumId = int.Parse(reader["ForumId"].ToString());
                forum.Name = reader["Name"].ToString();
                category.CategoryId = int.Parse(reader["CateId"].ToString());
                category.CateName = reader["CateName"].ToString();
            }
        }


        public SqlDataReader SelectSub(EnForum forum, ref int intResult)
        {
            string strCommandText = "selForumInF";

            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[1].Direction = ParameterDirection.Output;

            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            intResult = int.Parse(paraLocal[1].Value.ToString());
            return datrCate;
        }

        public List<EnForum> SelectSub2(EnForum forum, ref int intResult)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@ForumId", forum.ForumId);
            pr[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            pr[1].Direction = ParameterDirection.Output;
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selForumInF", pr))
            {
                List<EnForum> p = new List<EnForum>();
                while (r.Read())
                {
                    p.Add(PstSelSubs(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "selForumInF", pr);
                intResult = int.Parse(pr[1].Value.ToString());
                return p;
            }
        }

        private EnForum PstSelSubs(IDataReader i)
        {
            EnForum p = new EnForum();
            p.ForumId = (int)i["ForumId"];
            p.Name = (string)i["Name"];
            p.TotalTopics = (int)i["TotalTopics"];
            p.TotalMessages = (int)i["TotalMessages"];
            return p;
        }



        public EnForum SelectSubInF(EnForum forum)
        {
            string strCommandText = "selForumInF";

            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            
            SqlDataReader datrForum = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            EnForum newfourm = new EnForum();
            newfourm = CreateSub(datrForum);

            if (datrForum.IsClosed == false)
            {
                datrForum.Close();
                datrForum.Dispose();
            }
            return newfourm;
        }

        private EnForum CreateSub(IDataReader reader)
        {
            EnForum newforum = new EnForum();

            if (reader.Read())
            {
                newforum.TotalTopics = int.Parse(reader["TotalTopics"].ToString());
                newforum.TotalMessages = int.Parse(reader["TotalMessages"].ToString());
                newforum.Name = reader["Name"].ToString();
                newforum.ForumId = int.Parse(reader["ForumId"].ToString());
            }
            return newforum;
        }

        public EnForum SelectForumDetails(ref int intResult, EnForum forum, ref EnTopic topic, ref EnMessage message, ref EnMember member)
        {
            string strCommandText = "selForumDetails";

            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[1].Direction = ParameterDirection.Output;

            SqlDataReader datrForum = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            intResult = int.Parse(paraLocal[1].Value.ToString());
            
            EnForum newfourm = new EnForum();
            newfourm = CreateFromReader(datrForum,ref topic, ref message, ref member, intResult);

            if (datrForum.IsClosed == false)
            {
                datrForum.Close();
                datrForum.Dispose();
            }
            return newfourm;
        }

        private EnForum CreateFromReader(IDataReader reader,ref EnTopic topic, ref EnMessage message, ref EnMember member, int intResult)
        {
            EnForum newforum = new EnForum();

            if (reader.Read())
            {
                if (intResult == 1)
                {
                    topic.TopicId = int.Parse(reader["TopicId"].ToString());

                    newforum.TotalTopics = int.Parse(reader["TotalTopics"].ToString());

                    newforum.TotalMessages = int.Parse(reader["TotalMessages"].ToString());

                    message.Title = reader["Title"].ToString();

                    message.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());

                    member.UserName = reader["UserName"].ToString();

                    member.MemberId = int.Parse(reader["MemberId"].ToString());

                    message.MessageId = int.Parse(reader["MessageId"].ToString());
                }
                else
                {
                    newforum.TotalTopics = int.Parse(reader["TotalTopics"].ToString());

                    newforum.TotalMessages = int.Parse(reader["TotalMessages"].ToString());
                }
            }
            return newforum;
        }

        public SqlDataReader SelectJumper(EnCategory cate, EnMember mbr)
        {
            string strCommandText = "selForumJ";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@CategoryId", cate.CategoryId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader jump = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return jump;
        }

        public SqlDataReader SelectJumper2(EnForum frm, EnMember mbr)
        {
            string strCommandText = "selForumJump";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            SqlDataReader jump = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return jump;
        }

        public bool SelectPaForum(ref EnForum frm)
        {
            bool bolRe = false;
            string strCommandText = "selForumIfSub";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);            
            SqlDataReader pfrm = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            bolRe = ParForum(pfrm, ref frm);
            if (pfrm.IsClosed == false)
            {
                pfrm.Close();
                pfrm.Dispose();
            }
            return bolRe;
        }

        private bool ParForum(IDataReader reader,ref EnForum frm)
        {
            bool reslt = false;
            if (reader.Read())
            {
                frm.ForumId = int.Parse(reader["ForumId"].ToString());
                frm.Name = reader["Name"].ToString();
                reslt = true;
            }            
            return reslt;
        }

        //public SqlDataReader SelectForumAnalytics()
        //{
        //    string strCommandText = "selForumAnal";
        //    SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        //    return r;
        //}

        public EnAnalytics SelectForumAnalytics()
        {
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selForumAnal", null))
            {
                EnAnalytics p = new EnAnalytics();
                while (r.Read())
                {
                    p = PstSelFrAnl(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EnAnalytics PstSelFrAnl(IDataReader i)
        {
            EnAnalytics p = new EnAnalytics();
            p.Members = (int)i["Members"];
            p.Messages = (int)i["Messages"];
            p.Topics = (int)i["Topics"];
            p.Forums = (int)i["Forums"];
            p.MemberId = (int)i["MemberId"];
            p.UserName = (string)i["UserName"];
            if (i["NewMemberId"] != null && i["NewMemberId"].ToString() != "") p.NewestMemberId = (int)i["NewMemberId"];
            if (i["NewMember"] != null && i["NewMember"].ToString() != "") p.NewMember = (string)i["NewMember"];
            if (i["NewPost"] != null && i["NewPost"].ToString() != "") p.NewPost = (DateTime)i["NewPost"];
            return p;
        }

        public int SelectItemCount(EnForum forum)
        {
            string strCommandText = "selTopicCount";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public int SelectTopicInF(EnForum forum)
        {
            string strCommandText = "selTopicInF";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public int SelectLstCount(string strLst, EnMember mbr)
        {
            string strCommandText = "selTopicLstCount";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@TakeIn", strLst.ToString());
            paraLocal[1] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@UserName", mbr.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public int SelectItemCountSort(EnForum forum, int intSortId)
        {
            string strCommandText = "selTopicCountSort";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@SortId", intSortId);
            paraLocal[2] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[2].Value.ToString());
            return intCount;
        }

        public SqlDataReader SelectAllForumType()
        {
            string strCommandText = "selAllTypeForum";
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public void InsertForums(EnForum forum)
        {
            string strCommandText = "insForums";
            SqlParameter[] paraLocal = new SqlParameter[7];
            paraLocal[0] = new SqlParameter("@Name", forum.Name);
            paraLocal[1] = new SqlParameter("@Description", forum.Description);
            paraLocal[2] = new SqlParameter("@SubForumId", forum.SubForumId);
            paraLocal[3] = new SqlParameter("@TypeId", forum.TypeId);
            paraLocal[4] = new SqlParameter("@TotalTopics", forum.TotalTopics);
            paraLocal[5] = new SqlParameter("@TotalMessages", forum.TotalMessages);
            paraLocal[6] = new SqlParameter("@CateId", forum.CateId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAllForums(EnForum frm)
        {
            string strCommandText = "selForumsAll";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CateId", frm.CateId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteForum(EnForum frm)
        {
            string strCommandText = "delForums";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectForumFrId(ref EnForum forum, ref EnForum frm2, ref EnForumType type, ref EnCategory cate)
        {
            string strCommandText = "selForumDetailsFrmId";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            SqlDataReader datrForum = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateFrmFrId(datrForum, ref forum, ref frm2, ref type, ref cate);
            if (datrForum.IsClosed == false)
            {
                datrForum.Close();
                datrForum.Dispose();
            }
        }

        private void CreateFrmFrId(IDataReader reader, ref EnForum frm, ref EnForum frm2, ref EnForumType type, ref EnCategory cate)
        {
            if (reader.Read())
            {
                frm.Name = reader["ForumName"].ToString();
                frm.Description = reader["Description"].ToString();
                frm.SubForumId = int.Parse(reader["SubForumId"].ToString());
                frm2.Name = reader["ParForum"].ToString();
                type.TypeId = int.Parse(reader["TypeId"].ToString());
                type.Name = reader["TypeName"].ToString();
                frm.TotalTopics = int.Parse(reader["TotalTopics"].ToString());
                frm.TotalMessages = int.Parse(reader["TotalMessages"].ToString());
                cate.CategoryId = int.Parse(reader["CateId"].ToString());
                cate.CateName = reader["CateName"].ToString();
            }
        }

        public void UpdateForums(EnForum forum)
        {
            string strCommandText = "updForums";
            SqlParameter[] paraLocal = new SqlParameter[8];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@Name", forum.Name);
            paraLocal[2] = new SqlParameter("@Description", forum.Description);
            paraLocal[3] = new SqlParameter("@SubForumId", forum.SubForumId);
            paraLocal[4] = new SqlParameter("@TypeId", forum.TypeId);
            paraLocal[5] = new SqlParameter("@TotalTopics", forum.TotalTopics);
            paraLocal[6] = new SqlParameter("@TotalMessages", forum.TotalMessages);
            paraLocal[7] = new SqlParameter("@CateId", forum.CateId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAllGrpFrm(EnForum frm)
        {
            string strCommandText = "selGrpFrm";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public EnMemberAuthorize SelectGrpFrmAuthor(EnGroup grp, EnForum frm)
        {
            EnMemberAuthorize mbrauthr = new EnMemberAuthorize();
            string strCommandText = "selGrpFrmAuthor";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[1] = new SqlParameter("@ForumId", frm.ForumId);
            SqlDataReader datrForum = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            mbrauthr = CreateGrpFrmAuthor(datrForum);
            if (datrForum.IsClosed == false)
            {
                datrForum.Close();
                datrForum.Dispose();
            }
            return mbrauthr;
        }

        private EnMemberAuthorize CreateGrpFrmAuthor(IDataReader reader)
        {
            EnMemberAuthorize mbr = new EnMemberAuthorize();
            if (reader.Read())
            {
                mbr.PostAuthor = bool.Parse(reader["PostAuthor"].ToString());
                mbr.ReplyAuthor = bool.Parse(reader["ReplyAuthor"].ToString());
                mbr.PollAuthor = bool.Parse(reader["PollAuthor"].ToString());
                mbr.VoteAuthor = bool.Parse(reader["VoteAuthor"].ToString());
                mbr.RatingAuthor = bool.Parse(reader["RatingAuthor"].ToString());
                mbr.ViewProfile = bool.Parse(reader["ViewProfile"].ToString());
                mbr.UploadAuthor = bool.Parse(reader["UploadAuthor"].ToString());
                mbr.SizeAuthor = int.Parse(reader["SizeAuthor"].ToString());
                mbr.IsApproved = bool.Parse(reader["IsApproved"].ToString());
                mbr.EditMsgAuthor = bool.Parse(reader["EditMsgAuthor"].ToString());
                mbr.DeleteMsgAuthor = bool.Parse(reader["DeleteMsgAuthor"].ToString());
                mbr.DeleteTopicAuthor = bool.Parse(reader["DeleteTopicAuthor"].ToString());
                mbr.LockTopicAuthor = bool.Parse(reader["LockTopicAuthor"].ToString());
                mbr.StickTopicAuthor = bool.Parse(reader["StickTopicAuthor"].ToString());
                mbr.MoveTopicAuthor = bool.Parse(reader["MoveTopicAuthor"].ToString());
                mbr.QuoteMsgAuthor = bool.Parse(reader["QuoteMsgAuthor"].ToString());
                mbr.ForwardMsgAuthor = bool.Parse(reader["ForwardMsgAuthor"].ToString());
                mbr.SendPm = bool.Parse(reader["SendPm"].ToString());
                mbr.SendEm = bool.Parse(reader["SendEm"].ToString());
                mbr.UnLockTopic = bool.Parse(reader["UnLckTopicAuthor"].ToString());
                mbr.ApproveMsg = bool.Parse(reader["ApproveAuthor"].ToString());
                mbr.ViewIp = bool.Parse(reader["ViewIP"].ToString());
                mbr.ReportAuthor = bool.Parse(reader["ReportAuthor"].ToString());
                mbr.ThankAuthor = bool.Parse(reader["ThankAuthor"].ToString());
            }
            return mbr;
        }

        public int UpdateGrpFrmAuthor(EnMemberAuthorize frm, int intTypeId, int intDefault)
        {
            string strCommandText = "updGrpFrmAuthor";
            SqlParameter[] paraLocal = new SqlParameter[28];
            paraLocal[0] = new SqlParameter("@GroupId", frm.GroupId);
            paraLocal[1] = new SqlParameter("@ForumId", frm.ForumId);
            paraLocal[2] = new SqlParameter("@PostAuthor", frm.PostAuthor);
            paraLocal[3] = new SqlParameter("@ReplyAuthor", frm.ReplyAuthor);
            paraLocal[4] = new SqlParameter("@PollAuthor", frm.PollAuthor);
            paraLocal[5] = new SqlParameter("@VoteAuthor", frm.VoteAuthor);
            paraLocal[6] = new SqlParameter("@RatingAuthor", frm.RatingAuthor);
            paraLocal[7] = new SqlParameter("@ViewProfile", frm.ViewProfile);
            paraLocal[8] = new SqlParameter("@UploadAuthor", frm.UploadAuthor);
            paraLocal[9] = new SqlParameter("@SizeAuthor", frm.SizeAuthor);
            paraLocal[10] = new SqlParameter("@IsApproved", frm.IsApproved);
            paraLocal[11] = new SqlParameter("@EditMsgAuthor", frm.EditMsgAuthor);
            paraLocal[12] = new SqlParameter("@DeleteMsgAuthor", frm.DeleteMsgAuthor);
            paraLocal[13] = new SqlParameter("@DeleteTopicAuthor", frm.DeleteTopicAuthor);
            paraLocal[14] = new SqlParameter("@LockTopicAuthor", frm.LockTopicAuthor);
            paraLocal[15] = new SqlParameter("@StickTopicAuthor", frm.StickTopicAuthor);
            paraLocal[16] = new SqlParameter("@MoveTopicAuthor", frm.MoveTopicAuthor);
            paraLocal[17] = new SqlParameter("@QuoteMsgAuthor", frm.QuoteMsgAuthor);
            paraLocal[18] = new SqlParameter("@ForwardMsgAuthor", frm.ForwardMsgAuthor);
            paraLocal[19] = new SqlParameter("@SendPm", frm.SendPm);
            paraLocal[20] = new SqlParameter("@SendEm", frm.SendEm);
            paraLocal[21] = new SqlParameter("@UnLckTopicAuthor", frm.UnLockTopic);
            paraLocal[22] = new SqlParameter("@ApproveAuthor", frm.ApproveMsg);
            paraLocal[23] = new SqlParameter("@ViewIP", frm.ViewIp);
            paraLocal[24] = new SqlParameter("@ReportAuthor", frm.ReportAuthor);
            paraLocal[25] = new SqlParameter("@TypeId", intTypeId);
            paraLocal[26] = new SqlParameter("@Default", intDefault);
            paraLocal[27] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[27].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[27].Value.ToString());
        }

        public void DeleteGrpFrmAuthor(EnMemberAuthorize mbr)
        {
            string strCommandText = "delGrpFrmAuthor";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@GroupId", mbr.GroupId);
            paraLocal[1] = new SqlParameter("@ForumId", mbr.ForumId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectPrivFrms()
        {
            string strCommandText = "selPrivateFrms";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectPrivUserFrm(EnForum frm)
        {
            string strCommandText = "selPriUserFrm";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public bool InsertPrivUsersFrms(EnForum forum, EnMember mbr)
        {
            string strCommandText = "insPrivUsersFrms";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[2].Value.ToString());
        }

        public void DeletePrivUsersFrms(EnForum forum, EnMember mbr)
        {
            string strCommandText = "delPrivUsersFrms";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@MemberId", mbr.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }
    }
}
