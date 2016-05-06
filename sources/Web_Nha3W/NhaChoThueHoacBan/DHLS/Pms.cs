using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DPms
    {
        public DPms()
        {
        }
        public DataTable PMS_Inbox(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"ToMemberId", id);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_PMS_Inbox", pr);
        }
        public DataTable PMS_Outbox(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"FromMember", id);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_PMS_Outbox", pr);
        }
        public DataTable PMS_InboxIs(int id, bool ir)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"ToMemberId", id);
            pr[1] = new SqlParameter(@"IsRead", ir);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_PMS_InboxIs", pr);
        }
        public DataTable PMS_OutboxIs(int id, bool ir)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"FromMember", id);
            pr[1] = new SqlParameter(@"IsRead", ir);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_PMS_OutboxIs", pr);
        }
        public void PMS_Delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@PmId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_Del", pr);
        }
        public void PMS_Read(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@PmId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_Read", pr);
        }
        public void PMS_DelInbox(int fid)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ToMemberId", fid);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_DelInbox", pr);
        }
        public void PMS_DelOutbox(int tid)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@FromMember", tid);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_DelOutbox", pr);
        }
        public void PMS_Insert(EPms pm)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@FromMember", pm.FromMember);
            pr[1] = new SqlParameter("@ToMemberId", pm.ToMemberId);
            pr[2] = new SqlParameter("@Title", pm.Title);
            pr[3] = new SqlParameter("@Message", pm.Message);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_Insert", pr);
        }
        public string PMS_NewInbox(int tid)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"ToMemberId", tid);
            SqlDataReader ordHLS_PMS = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_PMS_Count", pr);
            ordHLS_PMS.Read();
            string i = "0";
            if (ordHLS_PMS.HasRows)
            {
                i = Convert.ToString(ordHLS_PMS["Number"]);
            }
            if (!ordHLS_PMS.IsClosed)
            {
                ordHLS_PMS.Close();
                ordHLS_PMS.Dispose();
            }
            return i;
        }

        public void PMS_Insert2(EPms pm,EMember c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@FromMember", c.UserName);
            pr[1] = new SqlParameter("@ToMemberId", pm.ToMemberId);
            pr[2] = new SqlParameter("@Title", pm.Title);
            pr[3] = new SqlParameter("@Message", pm.Message);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_PMS_Insert2", pr);
        }
    }
}
