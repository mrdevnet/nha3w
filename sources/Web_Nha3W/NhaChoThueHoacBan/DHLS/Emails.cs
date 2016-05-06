using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DEmails
    {
        public DEmails()
        {
        }

        public DataTable Emails_Outbox(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"FromMember", id);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Emails_Outbox", pr);
        }
        public void Emails_Del(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MailId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Emails_Del", pr);
        }
        public void Emails_DelOutbox(int fid)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@FromMember", fid);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Emails_DelOutbox", pr);
        }
        public void Emails_Insert(EEmails em)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@FromMember", em.FromMember);
            pr[1] = new SqlParameter("@ToMember", em.ToMember);
            pr[2] = new SqlParameter("@Title", em.Title);
            pr[3] = new SqlParameter("@Message", em.Message);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Emails_Insert", pr);
        }

        public string Group_Email(int GroupId)
        {
            string Email = "";
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"GroupId", GroupId);
            DataTable tb = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Group_Email", pr);
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow row in tb.Rows)
                {
                    if (Email == "")
                        Email = Email + row["Email"].ToString().Trim();
                    else
                        Email = Email + "," + row["Email"].ToString().Trim();
                }
                return Email;
            }
            else
            {
                return Email;
            }

        }
        public string Group_FullName(int GroupId, string Email)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"GroupId", GroupId);
            DataTable tb = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Group_Email", pr);
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow row in tb.Rows)
                {
                    if (row["Email"].ToString().Trim() == Email)
                    {
                        return row["FullName"].ToString().Trim();
                    }
                }
                return "";
            }
            else
            {
                return "";
            }
        }

        public void Emails_Insert2(EEmails em,EMember c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@FromMember", c.UserName);
            pr[1] = new SqlParameter("@ToMemberId", em.ToMember);
            pr[2] = new SqlParameter("@Title", em.Title);
            pr[3] = new SqlParameter("@Message", em.Message);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Emails_Insert2", pr);
        }

    }
}
