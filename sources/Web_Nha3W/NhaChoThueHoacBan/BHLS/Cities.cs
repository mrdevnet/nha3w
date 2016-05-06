using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BCities
    {
        //protected DAnas n;
        public BCities()
        {
        }

        //public static List<ECities> Cities()
        //{
        //    DCities n = new DCities();
        //    return n.LstCities();
        //}

        private static List<ECities> LstCities()
        {
            DCities p = new DCities();
            string cache = "lstCities";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstCities(), "Cities");
            }
            return (List<ECities>)BServer.Get(cache);
        }

        public static List<ECities> Cities()
        {
            List<ECities> tmp = new List<ECities>();
            tmp = LstCities();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Cities", true);
                tmp = LstCities();
            }
            return tmp;
        }

        public static DataTable ACities()
        {
            DCities d = new DCities();
            return d.ACities();
        }

        public static void ICities(ECities c)
        {
            DCities t = new DCities();
            t.ICities(c);
        }

        public static void ECities(ECities c)
        {
            DCities t = new DCities();
            t.ECities(c);
        }

        public static void UCities(ECities c)
        {
            DCities t = new DCities();
            t.UCities(c);
        }

    }
}
