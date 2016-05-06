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


namespace SLMF.DataAccess
{
    public class DaCategory
    {
        public DaCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectCategory()
        {
            string strCommandText = "selCategoryForum";
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            return datrCate;
        }

        public List<EnCategory> SelectCategory2()
        {
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selCategoryForum", null))
            {
                List<EnCategory> p = new List<EnCategory>();
                while (r.Read())
                {
                    p.Add(PstSelCategory(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EnCategory PstSelCategory(IDataReader i)
        {
            EnCategory p = new EnCategory();
            p.CategoryId = (int)i["CategoryId"];
            p.CateName = (string)i["CateName"];
            return p;
        }


        //public SqlDataReader SelectCateFId(ref EnCategory category)
        //{
        //    string strCommandText = "selCategoryFId";

        //    SqlParameter[] paraLocal = new SqlParameter[1];
        //    paraLocal[0] = new SqlParameter("@CategoryId", category.CategoryId);

        //    SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

        //    SqlDataReader datr1 = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    if (datr1.Read())
        //    {
        //        category.CateName = datr1["CateName"].ToString();
        //    }
        //    if (datr1.IsClosed == false)
        //    {
        //        datr1.Close();
        //        datr1.Dispose();
        //    }
        //    return datrCate;
        //}


        public List<EnCategory> SelectCateFId(EnCategory category)
        {
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", category.CategoryId);
            using (IDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selCategoryFId", paraLocal))
            {
                List<EnCategory> p = new List<EnCategory>();
                while (r.Read())
                {
                    p.Add(PstSelCategory(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }
        
        public string SelectCateName(EnCategory c)
        {
            string strRes = "";
            string strCommandText = "selCategoryFId";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", c.CategoryId);
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            if ( r.Read())
            {
                strRes = r["CateName"].ToString();
            }
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return strRes;
        }

        public SqlDataReader SelectAllCategories()
        {
            string strCommandText = "selAllCategories";
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectCateMan()
        {
            string strCommandText = "selAllCategories";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void InsertCategory(EnCategory cate)
        {
            string strCommandText = "insCategory";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@CateName", cate.CateName);
            paraLocal[1] = new SqlParameter("@OrderBy", cate.OrderBy);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteCategory(EnCategory cate)
        {
            string strCommandText = "delCategory";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", cate.CategoryId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        //public EnCategory SelectCateFId(EnCategory category)
        //{
        //    string strCommandText = "selCategoryFId";

        //    SqlParameter[] paraLocal = new SqlParameter[1];
        //    paraLocal[0] = new SqlParameter("@CategoryId", category.CategoryId);

        //    SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

        //    EnCategory newcate = new EnCategory();
        //    newcate = CreatFReader(datrCate);

        //    if (datrCate.IsClosed == false)
        //    {
        //        datrCate.Close();
        //        datrCate.Dispose();
        //    }
        //    return newcate;
        //}


        //private EnCategory CreatFReader(IDataReader reader)
        //{
        //    EnCategory newcate = new EnCategory();

        //    if (reader.Read())
        //    {
        //        newcate.CategoryId = int.Parse(reader["CategoryId"].ToString());
        //        newcate.CateName = reader["CateName"].ToString();
        //    }
        //    return newcate;
        //}


    }
}
