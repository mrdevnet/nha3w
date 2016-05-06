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

namespace SLMF.DataAccess
{
    public class DaMemberAuthorize
    {
        public DaMemberAuthorize()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public EnMemberAuthorize  SelectMemberAuthorize(EnMember member, EnForum forum, string atr) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selMemberAuthorize";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@ForumId", forum.ForumId);

            SqlDataReader datrAuthoirze = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            EnMemberAuthorize author = new EnMemberAuthorize();
            author = CreateAuthorize(datrAuthoirze, atr);
            if (datrAuthoirze.IsClosed == false)
            {
                datrAuthoirze.Close();
                datrAuthoirze.Dispose();
            }
            return author;
        }

        private EnMemberAuthorize CreateAuthorize(IDataReader reader, string atr)
        {
            EnMemberAuthorize newaut = new EnMemberAuthorize();
            if (reader.Read())
            {
                switch (atr)
                {
                    case "Post":
                        {
                            newaut.PostAuthor = bool.Parse(reader["PostAuthor"].ToString());
                            break;
                        }
                    case "Reply":
                        {
                            newaut.ReplyAuthor = bool.Parse(reader["ReplyAuthor"].ToString());
                            break;
                        }
                    case "Poll":
                        {
                            newaut.PollAuthor = bool.Parse(reader["PollAuthor"].ToString());
                            break;
                        }
                    case "Vote":
                        {
                            newaut.VoteAuthor = bool.Parse(reader["VoteAuthor"].ToString());
                            break;
                        }
                    case "Rate":
                        {
                            newaut.RatingAuthor = bool.Parse(reader["RatingAuthor"].ToString());
                            break;
                        }
                    case "Profile":
                        {
                            newaut.ViewProfile = bool.Parse(reader["ViewProfile"].ToString());
                            break;
                        }
                    case "Upload":
                        {
                            newaut.UploadAuthor = bool.Parse(reader["UploadAuthor"].ToString());
                            break;
                        }
                    case "Size":
                        {
                            newaut.SizeAuthor = int.Parse(reader["SizeAuthor"].ToString());
                            break;
                        }
                    case "Approve":
                        {
                            newaut.IsApproved = bool.Parse(reader["IsApproved"].ToString());
                            break;
                        }
                    case "EditMsg":
                        {
                            newaut.EditMsgAuthor = bool.Parse(reader["EditMsgAuthor"].ToString());
                            break;
                        }
                    case "DeleteMsg":
                        {
                            newaut.DeleteMsgAuthor = bool.Parse(reader["DeleteMsgAuthor"].ToString());
                            break;
                        }
                    case "DelTopic":
                        {
                            newaut.DeleteTopicAuthor = bool.Parse(reader["DeleteTopicAuthor"].ToString());
                            break;
                        }
                    case "Quote":
                        {
                            newaut.QuoteMsgAuthor = bool.Parse(reader["QuoteMsgAuthor"].ToString());
                            break;
                        }
                    case "Forward":
                        {
                            newaut.ForwardMsgAuthor = bool.Parse(reader["ForwardMsgAuthor"].ToString());
                            break;
                        }
                    case "AlSig":
                        {
                            newaut.AlwaysSig = bool.Parse(reader["Signature"].ToString());
                            break;
                        }
                    case "PM":
                        {
                            newaut.SendPm = bool.Parse(reader["SendPm"].ToString());
                            break;
                        }
                    case "Em":
                        {
                            newaut.SendEm = bool.Parse(reader["SendEm"].ToString());
                            break;
                        }
                    case "Report":
                        {
                            newaut.ReportAuthor = bool.Parse(reader["ReportAuthor"].ToString());
                            break;
                        }
                    case "Thank":
                        {
                            newaut.ThankAuthor = bool.Parse(reader["ThankAuthor"].ToString());
                            break;
                        }
                }
            }
            return newaut;
        }



    }
}
