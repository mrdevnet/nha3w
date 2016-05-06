using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BWards
    {
        //protected DAnas n;
        public BWards()
        {
        }

        public static List<EWards> Wards(EWards t)
        {
            DWards n = new DWards();
            return n.LstWards(t);
        }

        public static DataTable AWards(ECities c)
        {
            DWards n = new DWards();
            return n.AWards(c);
        }

        public static DataTable AWards2(EWards c)
        {
            DWards n = new DWards();
            return n.AWards2(c);
        }

        public static void IWards(EWards p)
        {
            DWards n = new DWards();
            n.IWards(p);
        }

        public static void EWards(EWards c)
        {
            DWards n = new DWards();
            n.EWards(c);
        }

        public static void UWards(EWards c)
        {
            DWards n = new DWards();
            n.UWards(c);
        }

    }
}