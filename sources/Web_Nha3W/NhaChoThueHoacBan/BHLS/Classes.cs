using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BClasses
    {
        //protected DAnas n;
        public BClasses()
        {
        }

        //public static List<EClasses> Classes()
        //{
        //    DClasses n = new DClasses();
        //    return n.LstClasses();
        //}

        private static List<EClasses> LstClasses()
        {
            DClasses p = new DClasses();
            string cache = "lstClasses";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstClasses(), "Classes");
            }
            return (List<EClasses>)BServer.Get(cache);
        }

        public static List<EClasses> Classes()
        {
            List<EClasses> tmp = new List<EClasses>();
            tmp = LstClasses();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Classes", true);
                tmp = LstClasses();
            }
            return tmp;
        }

    }
}
