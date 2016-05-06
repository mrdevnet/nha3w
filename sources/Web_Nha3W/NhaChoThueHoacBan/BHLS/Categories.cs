using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BCategories
    {
        //protected DAnas n;
        public BCategories()
        {
        }

        //public static List<ECategories> Categories()
        //{
        //    DCategories n = new DCategories();
        //    return n.LstCategories();
        //}

        private static List<ECategories> LstCategories()
        {
            DCategories p = new DCategories();
            string cache = "lstCategories";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstCategories(), "Categories");
            }
            return (List<ECategories>)BServer.Get(cache);
        }

        public static List<ECategories> Categories()
        {
            List<ECategories> tmp = new List<ECategories>();
            tmp = LstCategories();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Categories", true);
                tmp = LstCategories();
            }
            return tmp;
        }

    }
}