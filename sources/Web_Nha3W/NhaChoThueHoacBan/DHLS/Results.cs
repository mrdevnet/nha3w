using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DResults
    {
        public DResults()
        {
        }
        public DataTable SelectAll()
        {
            DataTable all = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Result_SelectAll", null);
            return all;
        }
        public void Insert(EResults OResult)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"PollId", OResult.PollId);
            pr[1] = new SqlParameter(@"Title", OResult.Title);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Result_Insert", pr);
        }
        public void Update(EResults OResult)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"ResultId", OResult.ResultId);
            pr[1] = new SqlParameter(@"Title", OResult.Title);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Result_Update", pr);
        }
        public void Reply(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"ResultId", ID);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Result_CM", pr);
        }
        public DataTable SelectByPollID(int PollID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"PollId", PollID);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Result_SelectByPollID", pr);
        }
        public void Delete(int ResultId)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"ResultId", ResultId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Result_Delete", pr);
        }
        public EResults SelectByID(int ResultId)
        {
            EResults OResult = new EResults();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"ResultId", ResultId);
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Result_SelectByID", pr);
            if (idr.Read()) OResult = GetOnEResult(idr);
            if (!idr.IsClosed)
            {
                idr.Close();
                idr.Dispose();
            }
            return OResult;
        }
        private EResults GetOnEResult(IDataReader idr)
        {
            EResults OResult = new EResults();
            if (idr["ResultId"] != DBNull.Value)
                OResult.ResultId = (int)idr["ResultId"];
            if (idr["PollId"] != DBNull.Value)
                OResult.PollId = (int)idr["PollId"];
            if (idr["Title"] != DBNull.Value)
                OResult.Title = (string)idr["Title"];
            if (idr["Total"] != DBNull.Value)
                OResult.Total = (int)idr["Total"];
            return OResult;
        }
        public List<EResults> ListAll()
        {
            List<EResults> list = new List<EResults>();
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Result_SelectAll", null);
            while (idr.Read()) list.Add(GetOnEResult(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
    }
}
