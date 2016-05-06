using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DNews
    {
        public DNews()
        {
        }
        public DataTable SelectAll()
        {
            DataTable n = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectAll", null);
            return n;
        }
        public DataTable SelectVip()
        {
            DataTable n = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectVip", null);
            return n;
        }
        public DataTable SelectTop()
        {
            DataTable n = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectTop", null);
            return n;
        }
        public DataTable SelectTopRating()
        {
            DataTable n = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectTopRating", null);
            return n;
        }
        public DataTable SelectTopView()
        {
            DataTable n = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectTopView", null);
            return n;
        }
        public void Insert(ENews n)
        {
            SqlParameter[] pr = new SqlParameter[11];
            pr[0] = new SqlParameter("@Title", n.Title);
            pr[1] = new SqlParameter("@Summary", n.Summary);
            pr[2] = new SqlParameter("@Contents", n.Contents);
            //pr[3] = new SqlParameter("@MemberId", n.MemberId);
            pr[3] = new SqlParameter("@User", n.User);
            pr[4] = new SqlParameter("@Tag", n.Tag);
            pr[5] = new SqlParameter("@IP", n.IP);
            pr[6] = new SqlParameter("@Vip", n.Vip);
            pr[7] = new SqlParameter("@CatalogId", n.CatalogId);
            pr[8] = new SqlParameter("@Images", n.Images);
            pr[9] = new SqlParameter("@Views", n.Views);
            pr[10] = new SqlParameter("@Rating", n.Rating);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_Insert", pr);
        }
        public void Update(ENews n)
        {
            SqlParameter[] pr = new SqlParameter[12];
            pr[0] = new SqlParameter("@Title", n.Title);
            pr[1] = new SqlParameter("@Summary", n.Summary);
            pr[2] = new SqlParameter("@Contents", n.Contents);
            //pr[3] = new SqlParameter("@MemberId", n.MemberId);
            pr[3] = new SqlParameter("@User", n.User);
            pr[4] = new SqlParameter("@Tag", n.Tag);
            pr[5] = new SqlParameter("@IP", n.IP);
            pr[6] = new SqlParameter("@Vip", n.Vip);
            pr[7] = new SqlParameter("@CatalogId", n.CatalogId);
            pr[8] = new SqlParameter("@NewsId", n.NewsId);
            pr[9] = new SqlParameter("@Images", n.Images);
            pr[10] = new SqlParameter("@Views", n.Views);
            pr[11] = new SqlParameter("@Rating", n.Rating);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_Update", pr);
        }
        public DateTime Delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"NewsId", id);
            pr[1] = new SqlParameter(@"Posted", SqlDbType.DateTime);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_Delete", pr);
            return Convert.ToDateTime(pr[1].Value);
        }
        public DataTable ListByCatalogId(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"CatalogId", id);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_ListByCatalog", pr);
        }
        public DataTable SelectByCatalogId(int CatalogId, int PageIndex, int Rows)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"CatalogId", CatalogId);
            pr[1] = new SqlParameter(@"PageIndex", PageIndex);
            pr[2] = new SqlParameter(@"Rows", Rows);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectPageCatalog", pr);
        }
        public int SelectByCatalogIdPage(int CatalogId)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"CatalogId", CatalogId);
            DataTable dt = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SelectPageC", pr);
            int max = (dt.Rows.Count > 0) ? int.Parse(dt.Rows[0]["MaxRow"].ToString()) : 0;
            return max;
        }
        private static ENews GetOneNewsRss(IDataReader idr)
        {
            ENews OHLS_News = new ENews();
            if (idr["NewsId"] != DBNull.Value)
                OHLS_News.NewsId = (int)idr["NewsId"];
            if (idr["Title"] != DBNull.Value)
                OHLS_News.Title = (string)idr["Title"];
            if (idr["Summary"] != DBNull.Value)
                OHLS_News.Summary = (string)idr["Summary"];
            if (idr["Posted"] != DBNull.Value)
                OHLS_News.Posted = (DateTime)idr["Posted"];
            if (idr["Images"] != DBNull.Value)
                OHLS_News.Images = (string)idr["Images"];
            return OHLS_News;
        }
        public List<ENews> ListTopRssByCatalog(int id)
        {
            List<ENews> list = new List<ENews>();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"CatalogId", id);
            IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_News_ListRssByCatalog", pr);
            while (idr.Read())
                list.Add(GetOneNewsRss(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
        public List<ENews> LstTp10Ns()
        {
            List<ENews> list = new List<ENews>();
            using (IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTwlls", null))
            {
                while (idr.Read()) list.Add(TpWl2(idr));
                if (idr.IsClosed == false)
                {
                    idr.Close();
                    idr.Dispose();
                }
                return list;
            }
        }
        private ENews TpWl2(IDataReader idr)
        {
            ENews OHLS_News = new ENews();
            if (idr["NewsId"] != DBNull.Value) OHLS_News.NewsId = (int)idr["NewsId"];
            if (idr["Title"] != DBNull.Value) OHLS_News.Title = (string)idr["Title"];
            if (idr["Images"] != DBNull.Value) OHLS_News.Images = (string)idr["Images"];
            return OHLS_News;
        }
        public DataTable Search(string news, int PageIndex, int Rows)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Search", news);
            pr[1] = new SqlParameter(@"PageIndex", PageIndex);
            pr[2] = new SqlParameter(@"Rows", Rows);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_Search", pr);
        }
        public int SearchPage(string news)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Search", news);
            DataTable dt = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_News_SearchPage", pr);
            int max = (dt.Rows.Count > 0) ? int.Parse(dt.Rows[0]["MaxRow"].ToString()) : 0;
            return max;
        }
        public void intViews(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NewsId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_Views", pr);
        }
        public void intRating(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NewsId", id);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_Rating", pr);
        }
        public string AutoID()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NewsId", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_News_AutoID", pr);
            return Convert.ToString(pr[0].Value);
        }
        public ENews SelectByID(int id)
        {
            ENews n = new ENews();
            SqlParameter[] pr = new SqlParameter[1]; ;
            pr[0] = new SqlParameter(@"NewsId", id);
            SqlDataReader ordHLS_News = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_News_SelectByID", pr);
            ordHLS_News.Read();
            if (ordHLS_News.HasRows)
            {
                if (ordHLS_News["NewsId"] != DBNull.Value)
                {
                    n.NewsId = Convert.ToInt16(ordHLS_News["NewsId"]);
                }
                if (ordHLS_News["Title"] != DBNull.Value)
                {
                    n.Title = Convert.ToString(ordHLS_News["Title"]);
                }
                if (ordHLS_News["Images"] != DBNull.Value)
                {
                    n.Images = Convert.ToString(ordHLS_News["Images"]);
                }
                if (ordHLS_News["Summary"] != DBNull.Value)
                {
                    n.Summary = Convert.ToString(ordHLS_News["Summary"]);
                }
                if (ordHLS_News["Contents"] != DBNull.Value)
                {
                    n.Contents = Convert.ToString(ordHLS_News["Contents"]);
                }
                if (ordHLS_News["Posted"] != DBNull.Value)
                {
                    n.Posted = Convert.ToDateTime(ordHLS_News["Posted"]);
                }
                if (ordHLS_News["MemberId"] != DBNull.Value)
                {
                    n.MemberId = Convert.ToInt16(ordHLS_News["MemberId"]);
                }
                if (ordHLS_News["Views"] != DBNull.Value)
                {
                    n.Views = Convert.ToInt16(ordHLS_News["Views"]);
                }
                if (ordHLS_News["Rating"] != DBNull.Value)
                {
                    n.Rating = Convert.ToInt16(ordHLS_News["Rating"]);
                }
                if (ordHLS_News["Tag"] != DBNull.Value)
                {
                    n.Tag = Convert.ToString(ordHLS_News["Tag"]);
                }
                if (ordHLS_News["IP"] != DBNull.Value)
                {
                    n.IP = Convert.ToString(ordHLS_News["IP"]);
                }
                if (ordHLS_News["Vip"] != DBNull.Value)
                {
                    n.Vip = Convert.ToBoolean(ordHLS_News["Vip"]);
                }
                if (ordHLS_News["CatalogId"] != DBNull.Value)
                {
                    n.CatalogId = Convert.ToInt16(ordHLS_News["CatalogId"]);
                    DCatalogs c = new DCatalogs();
                    n.Catalog = c.SelectByID(n.CatalogId);
                }
                if (ordHLS_News["UserName"] != DBNull.Value)
                {
                    n.User = Convert.ToString(ordHLS_News["UserName"]);
                }
            }
            if (!ordHLS_News.IsClosed)
            {
                ordHLS_News.Close();
                ordHLS_News.Dispose();
            }
            return n;
        }


    }
}
