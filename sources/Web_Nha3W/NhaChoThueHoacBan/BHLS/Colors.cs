using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BColors
    {
        //protected DAnas n;
        public BColors()
        {
        }

        public static void IColors(EColors m)
        {
            DColors cl = new DColors();
            cl.IColors(m);
        }

        public static void IColors2(EColors m)
        {
            DColors cl = new DColors();
            cl.IColors2(m);
        }

        private static List<EColors> LstColors(EColors m)
        {
            DColors p = new DColors();
            int i = BMember.ReturnId(m.AutName);
            string cache = "";
            if (i != m.MemberId) cache = "lstColorsw" + m.MemberId;
            else cache = "lstColors" + m.MemberId;
            if (BServer.Get(cache) == null)
            {
                if (i != m.MemberId) BServer.Insert(cache, p.LstColors(m),"Colorsw" + m.MemberId);
                else BServer.Insert(cache, p.LstColors(m), "Colors" + m.MemberId);
            }
            return (List<EColors>)BServer.Get(cache);
        }

        private static List<EColors> LstColors4a(ETracks m)
        {
            DColors p = new DColors();
            int i = BMember.ReturnId(m.IName);
            string cache = "lstColorsG" + m.ListId + "M" + i;
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstColors4(m), "ColorsG" + m.ListId + "M" + i);
            }
            return (List<EColors>)BServer.Get(cache);
        }

        private static List<EColors> LstClrFava(EMember m)
        {
            DColors p = new DColors();
            string cache = "LstClrFvs1" + m.MemberId;
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, p.LstClrFavs(m), "ClrFavsA" + m.MemberId);
            }
            return (List<EColors>)BServer.Get(cache);
        }

        public static List<EColors> LstClrFavsA(EMember m)
        {
            List<EColors> tmp = new List<EColors>();
            tmp = LstClrFava(m);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("ClrFavsA" + m.MemberId, true);
                tmp = LstClrFava(m);
            }
            return tmp;
        }

        public static void ItrIFlw(ETracks m)
        {
            DColors cl = new DColors();
            cl.ItrIFlw(m);
        }

        public static List<EColors> LstColors4(ETracks m)
        {
            List<EColors> tmp = new List<EColors>();
            tmp = LstColors4a(m);
            int i = BMember.ReturnId(m.IName);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("ColorsG" + m.ListId + "M" + i, true);
                tmp = LstColors4a(m);
            }
            return tmp;
        }

        public static List<EColors> Colors(EColors m)
        {
            List<EColors> tmp = new List<EColors>();
            int i = BMember.ReturnId(m.AutName);
            tmp = LstColors(m);
            if (tmp == null || tmp.Count == 0)
            {
                if (i != m.MemberId) BServer.Remove("Colorsw" + m.MemberId, true);
                else BServer.Remove("Colors" + m.MemberId, true);
                tmp = LstColors(m);
            }
            return tmp;
        }

        public static List<EColorMbrs> LstClrMrs(EColorMbrs m)
        {
            DColors cl = new DColors();
            return cl.LstClrMrs(m);
        }

        public static void FColors(EColors m)
        {
            DColors cl = new DColors();
            cl.FColors(m);
        }

        public static void UColors(EColors m)
        {
            DColors cl = new DColors();
            cl.UColors(m);
        }

        public static void IFavs(EColors m)
        {
            DColors cl = new DColors();
            cl.IFavs(m);
        }

        public static List<EColorMbrs> LstClrFavs(EColorMbrs m)
        {
            DColors cl = new DColors();
            return cl.LstClrFavs(m);
        }

        public static List<EColors> LstClrCmts(EColors m)
        {
            DColors cl = new DColors();
            return cl.LstClrCmts(m);
        }

        public static List<EColors> LstClrCmts3(EColors m)
        {
            DColors cl = new DColors();
            return cl.LstClrCmts3(m);
        }

        public static void FColors2(EColors m)
        {
            DColors cl = new DColors();
            cl.FColors2(m);
        }

        public static int F2c(int i)
        {
            DColors cl = new DColors();
            return cl.F2c(i);
        }

        private static int iF2c2(int i)
        {
            DColors cl = new DColors();
            string cache = "clrcmt" + i;
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, cl.F2c(i), "Comments" + i);
            }
            return (int)BServer.Get(cache);
        }

        public static int F2c2(int i)
        {
            int tmp = iF2c2(i);
            if (tmp == 0)
            {
                BServer.Remove("Comments" + i, true);
                tmp = iF2c2(i);
            }
            return tmp;
        }

        

    }
}

