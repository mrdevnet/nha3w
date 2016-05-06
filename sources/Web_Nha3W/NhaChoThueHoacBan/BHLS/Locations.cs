using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BLocations
    {
        //protected DAnas n;
        public BLocations()
        {
        }

        //public static List<ELocations> Locations()
        //{
        //    DLocations n = new DLocations();
        //    return n.LstLocations();
        //}

        private static List<ELocations> LstLocations()
        {
            DLocations p = new DLocations();
            string cache = "lstLocations";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstLocations(), "Locations");
            }
            return (List<ELocations>)BServer.Get(cache);
        }

        public static List<ELocations> Locations()
        {
            List<ELocations> tmp = new List<ELocations>();
            tmp = LstLocations();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Locations", true);
                tmp = LstLocations();
            }
            return tmp;
        }

    }
}
