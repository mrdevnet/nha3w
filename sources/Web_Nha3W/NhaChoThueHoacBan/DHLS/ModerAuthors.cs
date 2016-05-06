using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DModerAuthors
    {
        public DModerAuthors()
        {
        }

        public EModerAuthors ModerAuthors(EModers m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ModerId", m.ModerId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shMorderAuthors", pr))
            {
                EModerAuthors pros = new EModerAuthors();
                if (r.Read())
                {
                    pros = Pro(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        public EModerAuthors ModerAuthors2(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@User", m.UserName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shMorderAuthors2", pr))
            {
                EModerAuthors pros = new EModerAuthors();
                if (r.Read())
                {
                    pros = Pro(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        private EModerAuthors Pro(IDataReader i)
        {
            EModerAuthors p = new EModerAuthors();
            p.Edit = (bool)i["Edit"];
            p.Del = (bool)i["Del"];
            p.Approve = (bool)i["Approve"];
            p.Vip = (bool)i["Vip"];
            p.Silver = (bool)i["Silver"];
            p.Renew = (bool)i["Renew"];
            p.Ups = (bool)i["Ups"];
            return p;
        }

        public void UModerAuthors(EModerAuthors c)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("@ModerId", c.ModerId);
            pr[1] = new SqlParameter("@Edit", c.Edit);
            pr[2] = new SqlParameter("@Del", c.Del);
            pr[3] = new SqlParameter("@Approve", c.Approve);
            pr[4] = new SqlParameter("@Vip", c.Vip);
            pr[5] = new SqlParameter("@Silver", c.Silver);
            pr[6] = new SqlParameter("@Renew", c.Renew);
            pr[7] = new SqlParameter("@Ups", c.Ups);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhModerAuthors", pr);
        }

    }
}
