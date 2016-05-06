using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DCatalogs
    {
        public DCatalogs()
        {
        }

        //public List<ECatalogs> SelectAll()
        //{
        //    using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Catalogs_SelectAll", null))
        //    {
        //        List<ECatalogs> p = new List<ECatalogs>();
        //        while (r.Read())
        //        {
        //            p.Add(Ct(r));
        //        }
        //        if (r.IsClosed == false)
        //        {
        //            r.Close();
        //            r.Dispose();
        //        }
        //        return p;
        //    }
        //}

        public DataTable SelectAll()
        {
            DataTable c = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectAll", null);
            return c;
        }

        public DataTable SelectAllParent()
        {
            DataTable c = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectAllParent", null);
            return c;
        }

        //public List<ECatalogs> SelectListByID(int ID)
        //{
        //    SqlParameter[] pr = new SqlParameter[1];
        //    pr[0] = new SqlParameter(@"CatalogId", ID);
        //    using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Catalogs_SelectListByID", pr))
        //    {
        //        List<ECatalogs> p = new List<ECatalogs>();
        //        while (r.Read())
        //        {
        //            p.Add(Ct(r));
        //        }
        //        if (r.IsClosed == false)
        //        {
        //            r.Close();
        //            r.Dispose();
        //        }
        //        return p;
        //    }
        //}

        public DataTable SelectListByID(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"CatalogId", ID);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectListByID", pr);
        }

        //public List<ECatalogs> SelectListBySubID(int ID)
        //{
        //    SqlParameter[] pr = new SqlParameter[1];
        //    pr[0] = new SqlParameter(@"SubId", ID);
        //    using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Catalogs_SelectBySubID", pr))
        //    {
        //        List<ECatalogs> p = new List<ECatalogs>();
        //        while (r.Read())
        //        {
        //            p.Add(Ct(r));
        //        }
        //        if (r.IsClosed == false)
        //        {
        //            r.Close();
        //            r.Dispose();
        //        }
        //        return p;
        //    }
        //}

        public DataTable SelectListBySubID(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"SubId", ID);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectBySubID", pr);
        }

        private ECatalogs Ct(IDataReader i)
        {
            ECatalogs p = new ECatalogs();
            p.CatalogId = (int)i["CatalogId"];
            p.Name = (string)i["Name"];
            p.SubId = (int)i["SubId"];
            p.SubName = (string)i["Sub"];
            p.OrderBy = (short)i["OrderBy"];
            p.TopDefault = (bool)i["TopDefault"];
            if (i["News"] != null) p.CntNews = (int)i["News"];
            return p;
        }
        
        public DataTable SelectAllTT()
        {
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectAllTT", null);
        }
        
        public DataTable SelectAllDL()
        {
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Catalogs_SelectAllDL", null);
        }
        public void Insert(ECatalogs c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"Name", c.Name);
            pr[1] = new SqlParameter(@"SubId", c.SubId);
            pr[2] = new SqlParameter(@"OrderBy", c.OrderBy);
            pr[3] = new SqlParameter(@"TopDefault", c.TopDefault);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Catalogs_Insert", pr);
        }
        public void Update(ECatalogs c)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"CatalogId", c.CatalogId);
            pr[1] = new SqlParameter(@"Name", c.Name);
            pr[2] = new SqlParameter(@"SubId", c.SubId);
            pr[3] = new SqlParameter(@"OrderBy", c.OrderBy);
            pr[4] = new SqlParameter(@"TopDefault", c.TopDefault);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Catalogs_Update", pr);
        }
        public void Delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"CatalogId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Catalogs_Delete", pr);
        }
        public ECatalogs SelectByID(int id)
        {
            ECatalogs c = new ECatalogs();
            SqlParameter[] pr = new SqlParameter[1]; ;
            pr[0] = new SqlParameter(@"CatalogId", id);
            SqlDataReader ordHLS_Catalogs = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Catalogs_SelectByID", pr);
            ordHLS_Catalogs.Read();
            if (ordHLS_Catalogs.HasRows)
            {

                if (ordHLS_Catalogs["CatalogId"] != DBNull.Value)
                {
                    c.CatalogId = Convert.ToInt16(ordHLS_Catalogs["CatalogId"]);
                }
                if (ordHLS_Catalogs["Name"] != DBNull.Value)
                {
                    c.Name = Convert.ToString(ordHLS_Catalogs["Name"]);
                }
                if (ordHLS_Catalogs["SubId"] != DBNull.Value)
                {
                    c.SubId = Convert.ToInt16(ordHLS_Catalogs["SubId"]);
                }
                if (ordHLS_Catalogs["OrderBy"] != DBNull.Value)
                {
                    c.OrderBy = Convert.ToInt16(ordHLS_Catalogs["OrderBy"]);
                }
                if (ordHLS_Catalogs["TopDefault"] != DBNull.Value)
                {
                    c.TopDefault = Convert.ToBoolean(ordHLS_Catalogs["TopDefault"]);
                }
                c.NewsByCatalog = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectByCatalog", pr);
            }
            if (!ordHLS_Catalogs.IsClosed)
            {
                ordHLS_Catalogs.Close();
                ordHLS_Catalogs.Dispose();
            }
            return c;
        }


    }
}


