using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DDownloads
    {
        public DDownloads()
        {
        }

        public DataTable SelectAll()
        {
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Downloads_SelectAll", null);
        }
        public DataTable ListDownload(int page)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@PageIndex", page);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Downloads_List", pr);
        }
        public int MaxRowsListDownload()
        {
            DataTable dl = HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Downloads_ListPage", null);
            int r = (dl.Rows.Count > 0) ? (Convert.ToInt32(dl.Rows[0]["MaxRow"].ToString())) : 0;
            return r;
        }
        public void CountDowload(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"DownloadId", ID);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Downloads_Count", pr);
        }
        //-----------------------------------------------------------//
        public void Insert(EDownloads OjDownloads)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter(@"Title", OjDownloads.Title);
            pr[1] = new SqlParameter(@"Descs", OjDownloads.Descs);
            pr[2] = new SqlParameter(@"Files", OjDownloads.Files);
            pr[3] = new SqlParameter(@"URL", OjDownloads.URL);
            pr[4] = new SqlParameter(@"IP", OjDownloads.IP);
            pr[5] = new SqlParameter(@"Visible", OjDownloads.Visible);
            pr[6] = new SqlParameter(@"CatalogId", OjDownloads.CatalogId);
            //pr[7] = new SqlParameter(@"MemberId", OjDownloads.MemberId);
            pr[7] = new SqlParameter(@"User", OjDownloads.User);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Downloads_Insert", pr);
        }
        public List<EDownloads> LstTop10Dls()
        {
            List<EDownloads> list = new List<EDownloads>();
            using (IDataReader idr = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTp10Dls", null))
            {
                while (idr.Read()) list.Add(TpDls(idr));
                if (idr.IsClosed == false)
                {
                    idr.Close();
                    idr.Dispose();
                }
                return list;
            }
        }
        private EDownloads TpDls(IDataReader idr)
        {
            EDownloads OHLS_News = new EDownloads();
            if (idr["DownloadId"] != DBNull.Value) OHLS_News.DownloadId = (int)idr["DownloadId"];
            if (idr["Title"] != DBNull.Value) OHLS_News.Title = (string)idr["Title"];
            if (idr["Download"] != DBNull.Value) OHLS_News.Download = (int)idr["Download"];
            return OHLS_News;
        }
        //-----------------------------------------------------------//
        public void Update(EDownloads OjDownloads)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter(@"DownloadId", OjDownloads.DownloadId);
            pr[1] = new SqlParameter(@"Title", OjDownloads.Title);
            pr[2] = new SqlParameter(@"Descs", OjDownloads.Descs);
            pr[3] = new SqlParameter(@"IP", OjDownloads.IP);
            pr[4] = new SqlParameter(@"Visible", OjDownloads.Visible);
            pr[5] = new SqlParameter(@"CatalogId", OjDownloads.CatalogId);
            //pr[6] = new SqlParameter(@"MemberId", OjDownloads.MemberId);
            pr[6] = new SqlParameter(@"User", OjDownloads.User);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Downloads_Update", pr);
        }
        //-----------------------------------------------------------//
        public string Delete(int DownloadId)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"DownloadId", DownloadId);
            pr[1] = new SqlParameter(@"Files", SqlDbType.VarChar, 200);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Downloads_Delete", pr);
            return Convert.ToString(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public EDownloads SelectByID(int DownloadId)
        {
            EDownloads objDownloads_Info = new EDownloads();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"DownloadId", DownloadId);
            SqlDataReader ordDownloads = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Downloads_SelectByID", pr);
            ordDownloads.Read();
            if (ordDownloads.HasRows)
            {
                if (ordDownloads["DownloadId"] != DBNull.Value)
                {
                    objDownloads_Info.DownloadId = Convert.ToInt16(ordDownloads["DownloadId"]);
                }
                if (ordDownloads["Title"] != DBNull.Value)
                {
                    objDownloads_Info.Title = Convert.ToString(ordDownloads["Title"]);
                }
                if (ordDownloads["Descs"] != DBNull.Value)
                {
                    objDownloads_Info.Descs = Convert.ToString(ordDownloads["Descs"]);
                }
                if (ordDownloads["Upload"] != DBNull.Value)
                {
                    objDownloads_Info.Upload = Convert.ToDateTime(ordDownloads["Upload"]);
                }
                if (ordDownloads["Files"] != DBNull.Value)
                {
                    objDownloads_Info.Files = Convert.ToString(ordDownloads["Files"]);
                }
                if (ordDownloads["URL"] != DBNull.Value)
                {
                    objDownloads_Info.URL = Convert.ToString(ordDownloads["URL"]);
                }
                if (ordDownloads["IP"] != DBNull.Value)
                {
                    objDownloads_Info.IP = Convert.ToString(ordDownloads["IP"]);
                }
                if (ordDownloads["Visible"] != DBNull.Value)
                {
                    objDownloads_Info.Visible = Convert.ToBoolean(ordDownloads["Visible"]);
                }
                if (ordDownloads["Download"] != DBNull.Value)
                {
                    objDownloads_Info.Download = Convert.ToInt16(ordDownloads["Download"]);
                }
                if (ordDownloads["CatalogId"] != DBNull.Value)
                {
                    objDownloads_Info.CatalogId = Convert.ToInt16(ordDownloads["CatalogId"]);
                }
                if (ordDownloads["MemberId"] != DBNull.Value)
                {
                    objDownloads_Info.MemberId = Convert.ToInt16(ordDownloads["MemberId"]);
                }
            }
            if (!ordDownloads.IsClosed)
            {
                ordDownloads.Close();
                ordDownloads.Dispose();
            }
            return objDownloads_Info;
        }


    }
}