using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BNews
    {
        //protected DAnas n;
        public BNews()
        {
        }

        public static DataTable SelectAll()
        {
            DNews dn = new DNews();
            return dn.SelectAll();
        }
        public static DataTable ListCatalogId(int Id)
        {
            DNews dn = new DNews();
            return dn.ListByCatalogId(Id);
        }


        //cache

        //public static DataTable SelectTop()
        //{
        //    DNews dn = new DNews();
        //    return dn.SelectTop();
        //}

        private static DataTable LstSelectTops()
        {
            DNews n = new DNews();
            string ch = "lstSelTops";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.SelectTop(), "SelTopNews");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectTop()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelectTops();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelTopNews", true);
                tmp = LstSelectTops();
            }
            return tmp;
        }

        private static List<ENews> TpTp10Ns()
        {
            DNews n = new DNews();
            string ch = "lstTp10Ns";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.LstTp10Ns(), "selTp10Ns");
            }
            return (List<ENews>)BServer.Get(ch);
        }

        public static List<ENews> LstTp10Ns()
        {
            List<ENews> tmp = new List<ENews>();
            tmp = TpTp10Ns();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("selTp10Ns", true);
                tmp = TpTp10Ns();
            }
            return tmp;
        }


        //private static List<ECities> LstCities()
        //{
        //    DCities p = new DCities();
        //    string cache = "lstCities";
        //    if (BServer.Get(cache) == null)
        //    {
        //        BServer.Insert(cache, p.LstCities(), "Cities");
        //    }
        //    return (List<ECities>)BServer.Get(cache);
        //}

        //public static List<ECities> Cities()
        //{
        //    List<ECities> tmp = new List<ECities>();
        //    tmp = LstCities();
        //    if (tmp == null || tmp.Count == 0)
        //    {
        //        BServer.Remove("Cities", true);
        //        tmp = LstCities();
        //    }
        //    return tmp;
        //}



        //public static DataTable SelectVip()
        //{
        //    DNews dn = new DNews();
        //    return dn.SelectVip();
        //}

        private static DataTable LstSelVip()
        {
            DNews n = new DNews();
            string ch = "LstSelVips";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.SelectVip(), "SelectVips");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectVip()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelVip();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelectVips", true);
                tmp = LstSelVip();
            }
            return tmp;
        }


        //public static DataTable SelectTopRating()
        //{
        //    DNews dn = new DNews();
        //    return dn.SelectTopRating();
        //}


        private static DataTable LstSelTopRating()
        {
            DNews n = new DNews();
            string ch = "LstSelTopRatings";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.SelectTopRating(), "SelTopRatings");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectTopRating()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelTopRating();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelTopRatings", true);
                tmp = LstSelTopRating();
            }
            return tmp;
        }



        //public static DataTable SelectTopView()
        //{
        //    DNews dn = new DNews();
        //    return dn.SelectTopView();
        //}


        private static DataTable LstSelTopViews()
        {
            DNews n = new DNews();
            string ch = "LstSelTopViews";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.SelectTopView(), "SelectTopViews");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectTopView()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelTopViews();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelectTopViews", true);
                tmp = LstSelTopViews();
            }
            return tmp;
        }



        public static void Insert(ENews n)
        {
            DNews dn = new DNews();
            dn.Insert(n);
        }
        public static void Update(ENews n)
        {
            DNews dn = new DNews();
            dn.Update(n);
        }
        public static  DateTime Delete(int id)
        {
            DNews dn = new DNews();
            return  dn.Delete(id);
        }
        public static void intViews(int id)
        {
            DNews dn = new DNews();
            dn.intViews(id);
        }
        public static void intRating(int id)
        {
            DNews dn = new DNews();
            dn.intRating(id);
        }
        public static ENews SelectByID(int id)
        {
            DNews dn = new DNews();
            return dn.SelectByID(id);
        }
        public static string AutoID()
        {
            DNews dn = new DNews();
            return dn.AutoID();
        }
        public static DataTable Search(string news, int PageIndex, int Rows)
        {
            DNews dn = new DNews();
            return dn.Search(news, PageIndex, Rows);
        }
        public static List<ENews> ListTopRssByCatalog(int CatalogId)
        {
            DNews dn = new DNews();
            return dn.ListTopRssByCatalog(CatalogId);
        }
        public static int SearchPage(string news)
        {
            DNews dn = new DNews();
            return dn.SearchPage(news);

        }
        public static int SelectByCatalogIdPage(int CatalogId)
        {
            DNews dn = new DNews();
            return dn.SelectByCatalogIdPage(CatalogId);
        }
        public static DataTable SelectByCatalogId(int CatalogId, int PageIndex, int Rows)
        {
            DNews dn = new DNews();
            return dn.SelectByCatalogId(CatalogId, PageIndex, Rows);
        }


        
    }
}
