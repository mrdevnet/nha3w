using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BPosts
    {
        //protected static DPosts p;
        public BPosts()
        {
           
        }

        //public List<EPosts> ListPosts()
        //{
        //    string cache = "lstPosts";
        //    if (BServer.Get(cache) == null)
        //    {
        //        BServer.Insert(cache, p.LstPosts(), "Posts");
        //    }
        //    return (List<EPosts>)BServer.Get(cache);
        //}

        public static int IPost(EPosts ps, EProperties pro)
        {
            DPosts br = new DPosts();
            return br.IPost(ps, pro);
        }

        public static void UPost(EPosts ps, EProperties pro)
        {
            DPosts br = new DPosts();
            br.UPost(ps, pro);
        }

        public static void States(ref int sta1, ref int sta2, ref int sta4, ref int sta3, ref int sta0, string strUser)
        {
            DPosts br = new DPosts();
            br.States(ref sta1, ref sta2, ref sta4, ref sta3, ref sta0, strUser);
        }

        private static List<EPosts> LstPost(EPager pager)
        {
            DPosts p = new DPosts();
            string cache = "lstPosts";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache,p.LstPosts(pager), "Posts");
            }
            return (List<EPosts>)BServer.Get(cache);
        }

        public static List<EPosts> LstPosts(EPager pager)
        {
            List<EPosts> tmp = new List<EPosts>();
            tmp = LstPost(pager);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Posts", true);
                tmp = LstPost(pager);
            }
            return tmp;
        }

        public static List<EPosts> Lists(EPager pager)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager,c);
        }

        public static List<EPosts> Lists(EPager pager, EMember c)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c);
        }

        public static List<EPosts> Lists(EPager pager, EAnas a, int sj, int us)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, a, sj, us);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c, ECities y)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c,y);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c, EDistricts d)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c, d);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c, EDistricts d, EClasses l)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c, d,l);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c, EDistricts d, EStreets t)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c, d, t);
        }

        public static List<EPosts> Lists(EPager pager, ECategories c, EDistricts d, EWards a)
        {
            DPosts p = new DPosts();
            return p.LstPosts(pager, c, d, a);
        }

        public static EPosts Pdt(EPosts e)
        {
            DPosts p = new DPosts();
            return p.Post(e);
        }

        public static int Total()
        {
            DPosts p = new DPosts();
            return p.Total();
        }

        public static int Total(ECategories c)
        {
            DPosts p = new DPosts();
            return p.Total(c);
        }

        public static int Total(EMember c)
        {
            DPosts p = new DPosts();
            return p.Total(c);
        }

        public static int Total(EAnas c,int sj, int us)
        {
            DPosts p = new DPosts();
            return p.Total(c, sj, us);
        }

        public static int Total(ECategories c, ECities y)
        {
            DPosts p = new DPosts();
            return p.Total(c,y);
        }

        public static int Total(ECategories c, EDistricts d)
        {
            DPosts p = new DPosts();
            return p.Total(c, d);
        }

        public static int Total(ECategories c, EDistricts d, EClasses l)
        {
            DPosts p = new DPosts();
            return p.Total(c, d,l);
        }

        public static int Total(ECategories c, EDistricts d, EStreets t)
        {
            DPosts p = new DPosts();
            return p.Total(c, d, t);
        }

        public static int Total(ECategories c, EDistricts d, EWards a)
        {
            DPosts p = new DPosts();
            return p.Total(c, d, a);
        }

        public static DataTable MngPst(int st, int ct, int dt, string ur)
        {
            DPosts p = new DPosts();
            return p.MngPst(st, ct, dt,ur);
        }

        public static DataTable MngSvs(int ct, int dt, string ur)
        {
            DPosts p = new DPosts();
            return p.MngSvs(ct, dt, ur);
        }

        public static void UStaPst(EPosts c, string s, int a)
        {
            DPosts p = new DPosts();
            p.UStaPst(c, s, a);
        }

        public static DataTable MrPst(int st, int ct, int dt, int ur)
        {
            DPosts p = new DPosts();
            return p.MrPst(st, ct, dt, ur);
        }

        public static void UStaPst2(EPosts c, string s, int a)
        {
            DPosts p = new DPosts();
            p.UStaPst2(c,s,a);
        }

        public static void EPosts(int i)
        {
            DPosts p = new DPosts();
            p.EPosts(i);
        }

        public static void UPosts(int i)
        {
            DPosts p = new DPosts();
            p.UPosts(i);
        }

        public static void solos(ref int a, ref int c, ref int d)
        {
            DPosts p = new DPosts();
            p.solos(ref a, ref c, ref d);
        }

        public static int APstR(int i)
        {
            DPosts p = new DPosts();
            return p.APstR(i);
        }

    }
}
