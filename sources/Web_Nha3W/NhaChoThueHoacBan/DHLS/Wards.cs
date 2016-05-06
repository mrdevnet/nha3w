using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DWards
    {
        public DWards()
        {
        }

        public List<EWards> LstWards(EWards w)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@dt", w.DistrictId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shWan", pr))
            {
                List<EWards> p = new List<EWards>();
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

        private EWards Ct(IDataReader i)
        {
            EWards p = new EWards();
            p.WardId = (int)i["WardId"];
            p.WardName = (string)i["WardName"];
            return p;
        }

        public DataTable AWards(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shWards", pr);
        }

        public DataTable AWards2(EWards c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@DistrictId", c.DistrictId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shWards2", pr);
        }

        public void IWards(EWards p)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@WardName", p.WardName);
            pr[1] = new SqlParameter("@DistrictId", p.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihWards", pr);
        }

        public void EWards(EWards c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@WardId", c.WardId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhWards", pr);
        }

        public void UWards(EWards c)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@WardId", c.WardId);
            pr[1] = new SqlParameter("@WardName", c.WardName);
            pr[2] = new SqlParameter("@DistrictId", c.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhWards", pr);
        }


    }
}

