using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DDistricts
    {
        public DDistricts()
        {
        }

        public List<EDistricts> LstDistricts(EDistricts cy)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@cy", cy.CityId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shDtn", pr))
            {
                List<EDistricts> p = new List<EDistricts>();
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

        private EDistricts Ct(IDataReader i)
        {
            EDistricts p = new EDistricts();
            p.DistrictId = (int)i["DistrictId"];
            p.DistrictName = (string)i["DistrictName"];
            return p;
        }

        public DataTable ADistricts()
        {
            string strCommandText = "shADistricts";
            return HLSPro.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void IDistricts(EDistricts c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@DistrictName", c.DistrictName);
            pr[1] = new SqlParameter("@CityId", c.CityId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihDistricts", pr);
        }

        public void EDistricts(EDistricts c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@DistrictId", c.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhDistricts", pr);
        }

        public void UDistricts(EDistricts c)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@DistrictId", c.DistrictId);
            pr[1] = new SqlParameter("@CityId", c.CityId);
            pr[2] = new SqlParameter("@DistrictName", c.DistrictName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhDistricts", pr);
        }

        public DataTable ADistricts2(EDistricts c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shADistricts2", pr);
        }


    }
}