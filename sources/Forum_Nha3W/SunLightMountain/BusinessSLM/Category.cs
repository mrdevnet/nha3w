using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuCategory
    {
        public BuCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectCategory()
        {
            DaCategory category = new DaCategory();
            SqlDataReader datrCate = category.SelectCategory();
            return datrCate;
        }

        private static List<EnCategory> LstSelCategory()
        {
            DaCategory c = new DaCategory();
            string ch = "LstSelCategories";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, c.SelectCategory2(), "SelectCategories");
            }
            return (List<EnCategory>)BServer.Get(ch);
        }

        public static List<EnCategory> SelectCategory2()
        {
            List<EnCategory> tmp = new List<EnCategory>();
            tmp = LstSelCategory();
            if (tmp == null || tmp.Count == 0) // || tmp.HasRows tmp //tmp.HasRows == false)
            {
                BServer.Remove("SelectCategories", true);
                tmp = LstSelCategory();
            }
            return tmp;
        }



        //public static SqlDataReader SelectCateFId(ref EnCategory category)
        //{
        //    DaCategory dacate = new DaCategory();
        //    SqlDataReader datrCate = dacate.SelectCateFId(ref category);
        //    return datrCate;
        //}

        private static List<EnCategory> LstSelCateFId(EnCategory category)
        {
            DaCategory c = new DaCategory();
            string ch = "LstSelCateFIds" + category.CategoryId;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, c.SelectCateFId(category), "SelectCateFIds");
            }
            return (List<EnCategory>)BServer.Get(ch);
        }

        public static List<EnCategory> SelectCateFId(EnCategory category)
        {
            List<EnCategory> tmp = new List<EnCategory>();
            tmp = LstSelCateFId(category);
            if (tmp == null || tmp.Count == 0)// || tmp.HasRows == false)
            {
                BServer.Remove("SelectCateFIds", true);
                tmp = LstSelCateFId(category);
            }
            return tmp;
        }



        public static string SelectCateName(EnCategory c)
        {
            DaCategory n = new DaCategory();
            string str = n.SelectCateName(c);
            return str;
        }

        public static SqlDataReader SelectAllCategories()
        {
            DaCategory daCate = new DaCategory();
            return daCate.SelectAllCategories();
        }

        public static DataTable SelectCateMan()
        {
            DaCategory daCate = new DaCategory();
            return daCate.SelectCateMan();
        }

        public static void InsertCategory(EnCategory cate)
        {
            DaCategory daCate = new DaCategory();
            daCate.InsertCategory(cate);
        }

        public static void DeleteCategory(EnCategory cate)
        {
            DaCategory daCate = new DaCategory();
            daCate.DeleteCategory(cate);
        }
    }
}
