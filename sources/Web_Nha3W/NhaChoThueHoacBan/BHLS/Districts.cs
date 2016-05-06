using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BDistricts
    {
        //protected DAnas n;
        public BDistricts()
        {
        }

        public static List<EDistricts> Districts(EDistricts t)
        {
            DDistricts n = new DDistricts();
            return n.LstDistricts(t);
        }

        public static DataTable ADistricts()
        {
            DDistricts n = new DDistricts();
            return n.ADistricts();
        }

        public static void IDistricts(EDistricts c)
        {
            DDistricts n = new DDistricts();
            n.IDistricts(c);
        }

        public static void EDistricts(EDistricts c)
        {
            DDistricts n = new DDistricts();
            n.EDistricts(c);
        }

        public static void UDistricts(EDistricts c)
        {
            DDistricts n = new DDistricts();
            n.UDistricts(c);
        }

        public static DataTable ADistricts2(EDistricts c)
        {
            DDistricts n = new DDistricts();
            return n.ADistricts2(c);
        }

    }
}