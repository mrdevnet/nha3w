using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DStreets
    {
        public DStreets()
        {
        }

        public List<EStreets> LstStreets(EStreets w)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@dt", w.DistrictId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shSea", pr))
            {
                List<EStreets> p = new List<EStreets>();
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

        private EStreets Ct(IDataReader i)
        {
            EStreets p = new EStreets();
            p.StreetId = (int)i["StreetId"];
            p.Name = (string)i["Name"];
            return p;
        }

        public List<EStreets> LstStreets2(EStreets w)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@wa", w.WardId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shSeaw", pr))
            {
                List<EStreets> p = new List<EStreets>();
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

        public DataTable AStreets(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shStreets", pr);
        }

        public DataTable AStreets2(EStreets c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@DistrictId", c.DistrictId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shStreets2", pr);
        }

        public DataTable AStreets3(EStreets c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@WardId", c.WardId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shStreets3", pr);
        }

        public void IStreets(EStreets p)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@Name", p.Name);
            pr[1] = new SqlParameter("@DistrictId", p.DistrictId);
            pr[2] = new SqlParameter("@WardId", p.WardId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihStreets", pr);
        }

        public void EStreets(EStreets c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@StreetId", c.StreetId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhStreets", pr);
        }

        public void UStreets(EStreets c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@StreetId", c.StreetId);
            pr[1] = new SqlParameter("@Name", c.Name);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhStreets", pr);
        }


    }
}
