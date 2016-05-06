using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DUtilities
    {
        public DUtilities()
        {
        }

        private EUtilities uti(IDataReader i)
        {
            EUtilities p = new EUtilities();
            p.UtilityId = int.Parse(i["UtilityId"].ToString());
            return p;
        }

        public List<EUtilities> pr(EProperties p)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pid", p.PostId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shus", pr))
            {
                List<EUtilities> e = new List<EUtilities>();
                while (r.Read())
                {
                    e.Add(uti(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return e;
            }
        }

        public void IUtilities(EUtilities t)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UtilityId", t.UtilityId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihUpro", pr);
        }

        public void UUtilities(EUtilities t)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@UtilityId", t.UtilityId);
            pr[1] = new SqlParameter("@PostId", t.PostId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhUpro", pr);
        }

    }
}
