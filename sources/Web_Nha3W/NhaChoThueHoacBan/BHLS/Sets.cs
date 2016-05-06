using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BSets
    {
        //protected DAnas n;
        public BSets()
        {
        }

        //public static List<ESets> Sets()
        //{
        //    DSets n = new DSets();
        //    return n.LstSets();
        //}

        private static List<ESets> LstSets()
        {
            DSets p = new DSets();
            string cache = "lstSets";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstSets(), "Sets");
            }
            return (List<ESets>)BServer.Get(cache);
        }

        public static List<ESets> Sets()
        {
            List<ESets> tmp = new List<ESets>();
            tmp = LstSets();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Sets", true);
                tmp = LstSets();
            }
            return tmp;
        }

        public static void ISaved(EMember c, int PostId)
        {
            DSets p = new DSets();
            p.ISaved(c, PostId);
        }

        public static bool ASaved(EMember c, int PostId)
        {
            DSets p = new DSets();
            return p.ASaved(c, PostId);
        }

    }
}
