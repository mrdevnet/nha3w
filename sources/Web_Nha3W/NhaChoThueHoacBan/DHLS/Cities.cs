using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DCities
    {
        public DCities()
        {
        }

        public List<ECities> LstCities()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shCyn", null))
            {
                List<ECities> p = new List<ECities>();
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

        private ECities Ct(IDataReader i)
        {
            ECities p = new ECities();
            p.CityId = (int)i["CityId"];
            p.CityName = (string)i["CityName"];
            return p;
        }

        public DataTable ACities()
        {
            string strCommandText = "shACities";
            return HLSPro.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void ICities(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityName", c.CityName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihCities", pr);
        }

        public void ECities(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhCities", pr);
        }

        public void UCities(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            pr[1] = new SqlParameter("@CityName", c.CityName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhCities", pr);
        }


    }
}
