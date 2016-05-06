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
    public class DaModerator
    {
        public DaModerator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public SqlDataReader SelectModerator(EnModerator moderator, ref int intResult)
        //{
        //    string strCommandText = "selModerator";

        //    SqlParameter[] paraLocal = new SqlParameter[2];
        //    paraLocal[0] = new SqlParameter("@ForumId", moderator.ForumId);
        //    paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
        //    paraLocal[1].Direction = ParameterDirection.Output;

        //    SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            
        //    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    intResult = int.Parse(paraLocal[1].Value.ToString());

        //    return datrCate;
        //}

        public List<EnModerator> SelectModerator(EnModerator moderator, ref int intResult)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@ForumId", moderator.ForumId);
            pr[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            pr[1].Direction = ParameterDirection.Output;
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selModerator", pr))
            {
                List<EnModerator> p = new List<EnModerator>();
                while (r.Read())
                {
                    p.Add(PstSelMods(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "selModerator", pr);
                intResult = int.Parse(pr[1].Value.ToString());
                return p;
            }
        }

        private EnModerator PstSelMods(IDataReader i)
        {
            EnModerator p = new EnModerator();
            p.ForumId = (int)i["ForumId"];
            p.MemberId = (int)i["MemberId"];
            p.UserName = (string)i["UserName"];
            return p;
        }



        public EnMemberAuthorize SelectExistModer(EnForum forum, EnMember mbr, string strAut)
        {
            string strCommandText = "selExistModerator";

            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            bool result = bool.Parse(paraLocal[2].Value.ToString());
            SqlDataReader datrCate = null;
            EnMemberAuthorize atr = new EnMemberAuthorize();
            if (result)
            {
                datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
                atr = ModerAuthor(datrCate, strAut);
            }
            if (datrCate != null)
            {
                if (datrCate.IsClosed == false)
                {
                    datrCate.Close();
                }
                datrCate.Dispose();
            }
            return atr;
        }

        private EnMemberAuthorize ModerAuthor(IDataReader reader, string aut)
        {
            EnMemberAuthorize newaut = new EnMemberAuthorize();
            if (reader.Read())
            {
                switch (aut)
                {
                    case "LckTopic":
                        {
                            newaut.LockTopicAuthor = bool.Parse(reader["LockTopicAuthor"].ToString());
                            break;
                        }
                    case "Sticky":
                        {
                            newaut.StickTopicAuthor = bool.Parse(reader["StickTopicAuthor"].ToString());
                            break;
                        }
                    case "Move":
                        {
                            newaut.MoveTopicAuthor = bool.Parse(reader["MoveTopicAuthor"].ToString());
                            break;
                        }
                    case "AlSig":
                        {
                            newaut.AlwaysSig = bool.Parse(reader["Signature"].ToString());
                            break;
                        }
                    case "UnLck":
                        {
                            newaut.UnLockTopic = bool.Parse(reader["UnLckTopicAuthor"].ToString());
                            break;
                        }
                    case "AprMsg":
                        {
                            newaut.ApproveMsg = bool.Parse(reader["ApproveAuthor"].ToString());
                            break;
                        }
                    case "IP":
                        {
                            newaut.ViewIp = bool.Parse(reader["ViewIP"].ToString());
                            break;
                        }
                }
            }
            return newaut;
        }

        public bool SelectIsModer(EnMember member)
        {
            string strCommandText = "selIsModerator";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            bool bolResult = bool.Parse(paraLocal[1].Value.ToString());
            return bolResult;
        }

        public int InsertModer(EnModerator moderator)
        {
            string strCommandText = "insModerator";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@ForumId", moderator.ForumId);
            paraLocal[1] = new SqlParameter("@MemberId", moderator.MemberId);
            paraLocal[2] = new SqlParameter("@GroupId", moderator.GroupId);
            paraLocal[3] = new SqlParameter("@IsSuper", moderator.IsSuper);
            paraLocal[4] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[4].Value.ToString());            
        }

        public DataTable SelectGrpFrmUsers(EnModerator moderator)
        {
            string strCommandText = "selAllModeratorDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", moderator.ForumId);            
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteModerator(EnModerator moderator)
        {
            string strCommandText = "delGrpFrmMbrId";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@GroupId", moderator.GroupId);
            paraLocal[1] = new SqlParameter("@ForumId", moderator.ForumId);
            paraLocal[2] = new SqlParameter("@MemberId", moderator.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAllModers()
        {
            string strCommandText = "selAllModers";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }
    }
}
