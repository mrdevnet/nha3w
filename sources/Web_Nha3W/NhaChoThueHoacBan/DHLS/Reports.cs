using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DReports
    {
        public DReports()
        {
        }

        public List<EReports> LstReports()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shRpts", null))
            {
                List<EReports> p = new List<EReports>();
                while (r.Read())
                {
                    p.Add(Ct(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EReports> LstReports2()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shRptsa", null))
            {
                List<EReports> p = new List<EReports>();
                while (r.Read())
                {
                    p.Add(Ct(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EReports Ct(IDataReader i)
        {
            EReports p = new EReports();
            p.RptId = (int)i["RptId"];
            p.Title = (string)i["Title"];
            p.Url = (string)i["Url"];
            p.ByMember = (int)i["ByMember"];
            p.UserName = (string)i["UserName"];
            p.IsShow = (bool)i["IsShow"];
            p.Updated = (DateTime)i["Updated"];
            if (i["Total"] != null && i["Total"].ToString() != "") 
                p.Total = (int)i["Total"];
            return p;
        }

        public void IRpts(EReports c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@Title", c.Title);
            pr[1] = new SqlParameter("@Url", c.Url);
            pr[2] = new SqlParameter("@ByMember", c.UserName);
            pr[3] = new SqlParameter("@Show", c.IsShow);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "isRpts", pr);
        }

        public void URpts(EReports c)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@Id", c.RptId);
            pr[1] = new SqlParameter("@Title", c.Title);
            pr[2] = new SqlParameter("@Url", c.Url);
            pr[3] = new SqlParameter("@ByMember", c.UserName);
            pr[4] = new SqlParameter("@Show", c.IsShow);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhRpts", pr);
        }


    }
}
