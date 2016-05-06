using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DModers
    {
        public DModers()
        {
        }

        public DataTable AModers()
        {
            string strCommandText = "shModers";
            return HLSPro.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable AModers2(EMember c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", c.MemberId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shModerMbr", pr);
        }

        public void IModer(EModers c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ModerName", c.ModerName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihModers", pr);
        }

        public void EModers(EModers c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ModerId", c.ModerId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhModers", pr);
        }

        public void UModers(EModers c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@ModerId", c.ModerId);
            pr[1] = new SqlParameter("@ModerName", c.ModerName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhModers", pr);
        }

        public void UModers2(int i,int j)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", i);
            pr[1] = new SqlParameter("@ModerId", j);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhModersMr", pr);
        }

        public void EModers2(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", i);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhModers2", pr);
        }

        public int IsMdrs(EMember c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", c.UserName);
            SqlDataReader r= HLSPro.ExecuteReader(CommandType.StoredProcedure, "shImdrs", pr);
            int i = 0;
            if (r.Read()) i = int.Parse(r[0].ToString());
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }

        public SqlDataReader AAdmins()
        {
            string strCommandText = "shAdGr";
            return HLSPro.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable AAdmins2(EMember c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UrId", c.MemberId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shAdGrps", pr);
        }

        public void IAdmns(int a,int c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@AdminId", a);
            pr[1] = new SqlParameter("@GroupId", c);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "isAdns", pr);
        }

        public void EAdmns(int a, int c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@AdminId", a);
            pr[1] = new SqlParameter("@GroupId", c);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhAdns", pr);
        }

        public int IsAdns(EMember c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", c.UserName);
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIadns", pr);
            int i = 0;
            if (r.Read()) i = int.Parse(r[0].ToString());
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }

        public int IsAuAdns(EMember c,string strPr)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@urid", strPr.ToString());
            pr[1] = new SqlParameter("@urid2", c.UserName);
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsAuAdns", pr);
            int i = 0;
            if (r.Read()) i = int.Parse(r[0].ToString());
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }


    }
}
