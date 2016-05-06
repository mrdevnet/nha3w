using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BCatalogs
    {
        //protected DAnas n;
        public BCatalogs()
        {
        }

        //public static List<ECategories> Categories()
        //{
        //    DCategories n = new DCategories();
        //    return n.LstCategories();
        //}

        //private static List<ECategories> LstCategories()
        //{
        //    DCategories p = new DCategories();
        //    string cache = "lstCategories";
        //    if (BServer.Get(cache) == null)
        //    {
        //        BServer.Insert(cache, p.LstCategories(), "Categories");
        //    }
        //    return (List<ECategories>)BServer.Get(cache);
        //}

        //public static List<ECategories> Categories()
        //{
        //    List<ECategories> tmp = new List<ECategories>();
        //    tmp = LstCategories();
        //    if (tmp == null || tmp.Count == 0)
        //    {
        //        BServer.Remove("Categories", true);
        //        tmp = LstCategories();
        //    }
        //    return tmp;
        //}

        //public static DataTable SelectAll()
        //{
        //    DCatalogs dc = new DCatalogs();
        //    return dc.SelectAll();
        //}

        private static DataTable LstSelAll()
        {
            DCatalogs dc = new DCatalogs();
            string ch = "LstSelAll";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, dc.SelectAll(), "SelectAll");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectAll()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelAll();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelectAll", true);
                tmp = LstSelAll();
            }
            return tmp;
        }


        //public static DataTable SelectAllParent()
        //{
        //    DCatalogs dc = new DCatalogs();
        //    return dc.SelectAllParent();
        //}

        private static DataTable LstSelAllParent()
        {
            DCatalogs dc = new DCatalogs();
            string ch = "LstSelAllParent";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, dc.SelectAllParent(), "SelectAllParent");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectAllParent()
        {
            DataTable tmp = new DataTable();
            tmp = LstSelAllParent();
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelectAllParent", true);
                tmp = LstSelAllParent();
            }
            return tmp;
        }







        public static DataTable SelectAllTT()
        {
            DCatalogs dc = new DCatalogs();
            return dc.SelectAllTT();
        }
        //public static DataTable SelectListById(int ID)
        //{
        //    DCatalogs dc = new DCatalogs();
        //    return dc.SelectListByID(ID);
        //}

        private static DataTable LstSelListById(int Id)
        {
            DCatalogs dc = new DCatalogs();
            string ch = "lstSelListById" + Id;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, dc.SelectListByID(Id), "SelectListById");
            }
            return (DataTable)BServer.Get(ch);
        }

        public static DataTable SelectListById(int id)
        {
            DataTable tmp = new DataTable();
            tmp = LstSelListById(id);
            if (tmp == null || tmp.Rows.Count == 0)
            {
                BServer.Remove("SelectListById", true);
                tmp = LstSelListById(id);
            }
            return tmp;
        }




        public static DataTable SelectAllDL()
        {
            DCatalogs dc = new DCatalogs();
            return dc.SelectAllDL();
        }
        public static void Insert(ECatalogs c)
        {
            DCatalogs dc = new DCatalogs();
            dc.Insert(c);
        }
        public static void Update(ECatalogs c)
        {
            DCatalogs dc = new DCatalogs();
            dc.Update(c);
        }
        public static void Delete(int id)
        {
            DCatalogs dc = new DCatalogs();
            dc.Delete(id);
        }
        //public static ECatalogs SelectByID(int id)
        //{
        //    DCatalogs dc = new DCatalogs();
        //    return dc.SelectByID(id);
        //}

        private static ECatalogs LstSelByID(int Id)
        {
            DCatalogs dc = new DCatalogs();
            string ch = "lstSelById" + Id;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, dc.SelectByID(Id), "SelectById");
            }
            return (ECatalogs)BServer.Get(ch);
        }

        public static ECatalogs SelectByID(int id)
        {
            ECatalogs tmp = new ECatalogs();
            tmp = LstSelByID(id);
            if (tmp == null || tmp.CatalogId == 0)
            {
                BServer.Remove("SelectById", true);
                tmp = LstSelByID(id);
            }
            return tmp;
        }


        //private static List<ECategories> LstCategories()
        //{
        //    DCategories p = new DCategories();
        //    string cache = "lstCategories";
        //    if (BServer.Get(cache) == null)
        //    {
        //        BServer.Insert(cache, p.LstCategories(), "Categories");
        //    }
        //    return (List<ECategories>)BServer.Get(cache);
        //}

        //public static List<ECategories> Categories()
        //{
        //    List<ECategories> tmp = new List<ECategories>();
        //    tmp = LstCategories();
        //    if (tmp == null || tmp.Count == 0)
        //    {
        //        BServer.Remove("Categories", true);
        //        tmp = LstCategories();
        //    }
        //    return tmp;
        //}




        public static DataTable SelectBySubId(int id)
        {
            DCatalogs dc = new DCatalogs();
            return dc.SelectListBySubID(id);
        }

    }
}
