using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BModers
    {
        //protected DAnas n;
        public BModers()
        {
        }

        public static DataTable AModers()
        {
            DModers d = new DModers();
            return d.AModers();
        }

        public static DataTable AModers2(EMember c)
        {
            DModers d = new DModers();
            return d.AModers2(c);
        }

        public static void IModer(EModers c)
        {
            DModers d = new DModers();
            d.IModer(c);
        }

        public static void EGroups(EModers c)
        {
            DModers d = new DModers();
            d.EModers(c);
        }

        public static void UModers(EModers c)
        {
            DModers d = new DModers();
            d.UModers(c);
        }

        public static void UModers2(int i, int j)
        {
            DModers d = new DModers();
            d.UModers2(i,j);
        }

        public static void EModers2(int i)
        {
            DModers d = new DModers();
            d.EModers2(i);
        }

        public static int IsMdrs(EMember c)
        {
            DModers d = new DModers();
            return d.IsMdrs(c);
        }

        public static SqlDataReader AAdmins()
        {
            DModers d = new DModers();
            return d.AAdmins();
        }

        public static DataTable AAdmins2(EMember c)
        {
            DModers d = new DModers();
            return d.AAdmins2(c);
        }

        public static void IAdmns(int a, int c)
        {
            DModers d = new DModers();
            d.IAdmns(a, c);
        }

        public static void EAdmns(int a, int c)
        {
            DModers d = new DModers();
            d.EAdmns(a, c);
        }

        public static int IsAdns(EMember c)
        {
            DModers d = new DModers();
            return d.IsAdns(c);
        }

        public static int IsAuAdns(EMember c, string strPr)
        {
            DModers d = new DModers();
            return d.IsAuAdns(c,strPr);
        }

    }
}
