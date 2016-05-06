using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DTracks
    {
        public DTracks()
        {
        }

        public void ICalls(ETracks c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@MemberId", c.IName);
            pr[1] = new SqlParameter("@LstName", c.LstName);
            pr[2] = new SqlParameter("@LstDesc", c.LstDesc);
            pr[3] = new SqlParameter("@Prive", c.Prive);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihTrcks", pr);
        }

        public void UCalls(ETracks c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@MemberId", c.ListId);
            pr[1] = new SqlParameter("@LstName", c.LstName);
            pr[2] = new SqlParameter("@LstDesc", c.LstDesc);
            pr[3] = new SqlParameter("@Prive", c.Prive);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhTrcks1", pr);
        }

        public void DCalls(int c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", c);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhTrcks1", pr);
        }

        public List<ETracks> LstTracks(string i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTrcks", pr))
            {
                List<ETracks> p = new List<ETracks>();
                while (r.Read())
                {
                    p.Add(Flwis(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public void GrpDtls(ref ETracks i)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", i.IName);
            pr[1] = new SqlParameter("@LstId", i.ListId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTrckswm", pr))
            {
                while (r.Read())
                {
                    i = Flwis3(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
            }
        }

        private ETracks Flwis3(IDataReader i)
        {
            ETracks p = new ETracks();
            p.LstName = (string)i["LstName"];
            p.LstDesc = (string)i["LstDesc"];
            p.Prive = (bool)i["Prive"];
            p.LstDate = (DateTime)i["LstDate"];
            if (i["Flw"] != null && i["Flw"].ToString() != "") p.IsList = (int)i["Flw"];
            p.MemberId = (int)i["MemberId"];
            return p;
        }

        private ETracks Flwis(IDataReader i)
        {
            ETracks p = new ETracks();
            p.ListId = (int)i["lstid"];
            p.LstName = (string)i["LstName"];
            p.LstDesc = (string)i["LstDesc"];
            p.Prive = (bool)i["Prive"];
            p.LstDate = (DateTime)i["LstDate"];
            return p;
        }

        public ETracks LstTracks1(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTrcks1", pr))
            {
                ETracks p = new ETracks();
                while (r.Read())
                {
                    p = Flwis(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }
    }
}

