using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BStreets
    {
        //protected DAnas n;
        public BStreets()
        {
        }

        public static List<EStreets> Streets(EStreets t)
        {
            DStreets n = new DStreets();
            return n.LstStreets(t);
        }

        public static List<EStreets> Streets2(EStreets t)
        {
            DStreets n = new DStreets();
            return n.LstStreets2(t);
        }

        public static DataTable AStreets(ECities c)
        {
            DStreets n = new DStreets();
            return n.AStreets(c);
        }

        public static DataTable AStreets2(EStreets c)
        {
            DStreets n = new DStreets();
            return n.AStreets2(c);
        }

        public static DataTable AStreets3(EStreets c)
        {
            DStreets n = new DStreets();
            return n.AStreets3(c);
        }

        public static void IStreets(EStreets p)
        {
            DStreets n = new DStreets();
            n.IStreets(p);
        }

        public static void EStreets(EStreets c)
        {
            DStreets n = new DStreets();
            n.EStreets(c);
        }

        public static void UStreets(EStreets c)
        {
            DStreets n = new DStreets();
            n.UStreets(c);
        }

    }
}
