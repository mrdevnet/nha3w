using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BReports
    {
        //protected DAnas n;
        public BReports()
        {
        }

        //public static List<EClasses> Classes()
        //{
        //    DClasses n = new DClasses();
        //    return n.LstClasses();
        //}

        private static List<EReports> LstReports()
        {
            DReports p = new DReports();
            string cache = "lstReports";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstReports(), "Reports");
            }
            return (List<EReports>)BServer.Get(cache);
        }

        private static List<EReports> LstReports2()
        {
            DReports p = new DReports();
            string cache = "lstReports2";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstReports2(), "Reports2");
            }
            return (List<EReports>)BServer.Get(cache);
        }

        public static List<EReports> Reports()
        {
            List<EReports> tmp = new List<EReports>();
            tmp = LstReports();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Reports", true);
                tmp = LstReports();
            }
            return tmp;
        }

        public static List<EReports> Reports2()
        {
            List<EReports> tmp = new List<EReports>();
            tmp = LstReports2();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Reports2", true);
                tmp = LstReports2();
            }
            return tmp;
        }

        public static void IRpts(EReports c)
        {
            DReports p = new DReports();
            p.IRpts(c);
        }

        public static void URpts(EReports c)
        {
            DReports p = new DReports();
            p.URpts(c);
        }

    }
}

