using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DHouses
    {
        public DHouses()
        {
        }

        public void IHouses(EHouses t)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Images", t.Images);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihPhs", pr);
        }

        public void UHouses(EHouses t)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@Images", t.Images);
            pr[1] = new SqlParameter("@PostId", t.PostId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhPhs", pr);
        }

        private EHouses house(IDataReader i)
        {
            EHouses p = new EHouses();
            p.Images = i["Images"].ToString();
            p.HouseId = int.Parse(i["HouseId"].ToString());
            p.PostId = int.Parse(i["PostId"].ToString());
            return p;
        }

        private EHouses housest(IDataReader i)
        {
            EHouses p = new EHouses();
            p.Images = i["Images"].ToString();
            p.HouseId = int.Parse(i["HouseId"].ToString());
            p.PostId = int.Parse(i["PostId"].ToString());
            p.CreationDate = DateTime.Parse(i["creationdate"].ToString());
            return p;
        }

        public List<EHouses> pr(EHouses p)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pid", p.PostId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shHouses", pr))
            {
                List<EHouses> e = new List<EHouses>();
                while (r.Read())
                {
                    e.Add(house(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return e;
            }
        }

        public List<EHouses> prst(EHouses p)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pid", p.PostId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shHousesLsts", pr))
            {
                List<EHouses> e = new List<EHouses>();
                while (r.Read())
                {
                    e.Add(housest(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return e;
            }
        }

        public void EHouses(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@HouseId", i);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhHouses", pr);
        }

    }
}
