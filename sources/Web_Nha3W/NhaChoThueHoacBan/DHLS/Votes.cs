using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DVotes
    {
        public DVotes()
        {
        }

        public DataTable SelectAll()
        {
            DataTable all = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Vote_SelectAll", null);
            return all;
        }
        public void Insert(EVotes OVote)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"PollId", OVote.PollId);
            pr[1] = new SqlParameter(@"UserId", OVote.UserId);
            pr[2] = new SqlParameter(@"IP", OVote.IP);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Vote_Insert", pr);
        }
        public void Update(EVotes OVote)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"VoteId", OVote.VoteId);
            pr[1] = new SqlParameter(@"PollId", OVote.PollId);
            pr[2] = new SqlParameter(@"UserId", OVote.UserId);
            pr[3] = new SqlParameter(@"IP", OVote.IP);
            pr[4] = new SqlParameter(@"VoteDate", OVote.VoteDate);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Vote_Update", pr);
        }
        public DataTable SelectByPollID(int PollID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"PollId", PollID);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Vote_SelectByPollID", pr);
        }
        public void Delete(int VoteId)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"VoteId", VoteId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Vote_Delete", pr);
        }
        public EVotes SelectByID(int VoteId)
        {
            EVotes OVote = new EVotes();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"VoteId", VoteId);
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Vote_SelectByID", pr);
            if (idr.Read()) OVote = GetOnEVote(idr);
            if (!idr.IsClosed)
            {
                idr.Close();
                idr.Dispose();
            }
            return OVote;
        }
        private EVotes GetOnEVote(IDataReader idr)
        {
            EVotes OVote = new EVotes();
            if (idr["VoteId"] != DBNull.Value)
                OVote.VoteId = (int)idr["VoteId"];
            if (idr["PollId"] != DBNull.Value)
                OVote.PollId = (int)idr["PollId"];
            if (idr["UserId"] != DBNull.Value)
                OVote.UserId = (int)idr["UserId"];
            if (idr["IP"] != DBNull.Value)
                OVote.IP = (string)idr["IP"];
            if (idr["VoteDate"] != DBNull.Value)
                OVote.VoteDate = (DateTime)idr["VoteDate"];
            return OVote;
        }
        public bool TestIP(string IP, int PollId)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"IP", IP);
            pr[1] = new SqlParameter(@"PollId", PollId);
            pr[2] = new SqlParameter(@"Test", SqlDbType.Bit);
            pr[2].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Vote_TestIP", pr);
            return Convert.ToBoolean(pr[2].Value);
        }
        public List<EVotes> ListAll()
        {
            List<EVotes> list = new List<EVotes>();
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Vote_SelectAll", null);
            while (idr.Read()) list.Add(GetOnEVote(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        


    }
}