using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DLocations
    {
        public DLocations()
        {
        }

        public List<ELocations> LstLocations()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLtn", null))
            {
                List<ELocations> p = new List<ELocations>();
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

        private ELocations Ct(IDataReader i)
        {
            ELocations p = new ELocations();
            p.LocationId = (int)i["LocationId"];
            p.LocaName = (string)i["LocaName"];
            return p;
        }


    }
}
