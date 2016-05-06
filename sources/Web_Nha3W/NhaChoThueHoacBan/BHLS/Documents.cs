using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BDocuments
    {
        //protected DAnas n;
        public BDocuments()
        {
        }

        //public static List<ESets> Sets()
        //{
        //    DSets n = new DSets();
        //    return n.LstSets();
        //}

        private static List<EDocuments> LstDocuments()
        {
            DDocuments p = new DDocuments();
            string cache = "lstDocuments";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstDocuments(), "Documents");
            }
            return (List<EDocuments>)BServer.Get(cache);
        }

        public static List<EDocuments> Documents()
        {
            List<EDocuments> tmp = new List<EDocuments>();
            tmp = LstDocuments();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Documents", true);
                tmp = LstDocuments();
            }
            return tmp;
        }

    }
}