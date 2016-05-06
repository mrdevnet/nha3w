using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BLogs
    {
        public BLogs()
        {
        }

        public static List<ELogs> Logs(ELogs lg)
        {
            DLogs n = new DLogs();
            return n.LstLogs(lg);
        }

        public static void ILogs(ELogs lg)
        {
            DLogs g = new DLogs();
            g.ILogs(lg);
        }

        //private static List<ESets> LstSets()
        //{
        //    DSets p = new DSets();
        //    string cache = "lstSets";
        //    if (BServer.Get(cache) == null)
        //    {
        //        BServer.Insert(cache, p.LstSets(), "Sets");
        //    }
        //    return (List<ESets>)BServer.Get(cache);
        //}

        //public static List<ESets> Sets()
        //{
        //    List<ESets> tmp = new List<ESets>();
        //    tmp = LstSets();
        //    if (tmp == null || tmp.Count == 0)
        //    {
        //        BServer.Remove("Sets", true);
        //        tmp = LstSets();
        //    }
        //    return tmp;
        //}

    }
}

