using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DLogs
    {
        public DLogs()
        {
        }

        public List<ELogs> LstLogs(ELogs lg)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@sid", lg.SdId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLogs", pr))
            {
                List<ELogs> p = new List<ELogs>();
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

        private ELogs Ct(IDataReader i)
        {
            ELogs p = new ELogs();
            p.PostId = (int)i["PostId"];
            p.Title = (string)i["Title"];
            return p;
        }

        public void ILogs(ELogs lg)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@PostId", lg.PostId);
            pr[1] = new SqlParameter("@SdId", lg.SdId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihLogs", pr);
        }


    }
}
