using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DPolls
    {
        public DPolls()
        {
        }
        public DataTable SelectAll()
        {
            DataTable all = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Poll_SelectAll", null);
            return all;
        }
        public void Insert(EPolls OPoll)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"Title", OPoll.Title);
            pr[1] = new SqlParameter(@"Repeat", OPoll.Repeat);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Poll_Insert", pr);
        }
        public void Update(EPolls OPoll)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"PollId", OPoll.PollId);
            pr[1] = new SqlParameter(@"Title", OPoll.Title);
            pr[2] = new SqlParameter(@"Repeat", OPoll.Repeat);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Poll_Update", pr);
        }
        
        public void Delete(int PollId)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"PollId", PollId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Poll_Delete", pr);
        }

        public EPolls SelectByID(int PollId)
        {
            EPolls OPoll = new EPolls();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"PollId", PollId);
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Poll_SelectByID", pr);
            if (idr.Read()) OPoll = GetOnEPoll(idr);
            if (!idr.IsClosed)
            {
                idr.Close();
                idr.Dispose();
            }
            return OPoll;
        }

        public EPolls SelectShow()
        {
            EPolls OPoll = new EPolls();
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Poll_SelectShow", null);
            if (idr.Read()) OPoll = GetOnEPoll(idr);
            if (!idr.IsClosed)
            {
                idr.Close();
                idr.Dispose();
            }
            return OPoll;
        }

        private EPolls GetOnEPoll(IDataReader idr)
        {
            EPolls OPoll = new EPolls();
            if (idr["PollId"] != DBNull.Value)
                OPoll.PollId = (int)idr["PollId"];
            if (idr["Title"] != DBNull.Value)
                OPoll.Title = (string)idr["Title"];
            if (idr["Total"] != DBNull.Value)
                OPoll.Total = (int)idr["Total"];
            if (idr["Repeat"] != DBNull.Value)
                OPoll.Repeat = (bool)idr["Repeat"];
            if (idr["FinishDate"] != DBNull.Value)
                OPoll.FinishDate = (DateTime)idr["FinishDate"];
            return OPoll;
        }

        public List<EPolls> ListAll()
        {
            List<EPolls> list = new List<EPolls>();
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Poll_SelectAll", null);
            while (idr.Read()) list.Add(GetOnEPoll(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
      }
  }

