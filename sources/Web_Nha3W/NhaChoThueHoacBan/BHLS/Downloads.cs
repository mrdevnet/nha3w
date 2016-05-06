using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BDownloads
    {
        //protected DAnas n;
        public BDownloads()
        {
        }

        public static DataTable SelectAll()
        {
            DDownloads dd = new DDownloads();
            return dd.SelectAll();
        }
        public static DataTable ListDownload(int page)
        {
            DDownloads dd = new DDownloads();
            return dd.ListDownload(page);
        }
        private static List<EDownloads> Top10Dls()
        {
            DDownloads n = new DDownloads();
            string ch = "lstTp10Dls";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, n.LstTop10Dls(), "selTp10Dls");
            }
            return (List<EDownloads>)BServer.Get(ch);
        }

        public static List<EDownloads> LstTop10Dls()
        {
            List<EDownloads> tmp = new List<EDownloads>();
            tmp = Top10Dls();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("selTp10Dls", true);
                tmp = Top10Dls();
            }
            return tmp;
        }
        public static int MaxRowList()
        {
            DDownloads dd = new DDownloads();
            return dd.MaxRowsListDownload();
        }
        public static void CountDownload(int ID)
        {
            DDownloads dd = new DDownloads();
            dd.CountDowload(ID);
        }
        public static void Insert(EDownloads ed)
        {
            DDownloads dd = new DDownloads();
            dd.Insert(ed);
        }
        public static void Update(EDownloads ed)
        {
            DDownloads dd = new DDownloads();
            dd.Update(ed);
        }
        public static string Delete(int ID)
        {
            DDownloads dd = new DDownloads();
            return dd.Delete(ID);
        }
        public static EDownloads SelectByID(int ID)
        {
            DDownloads dd = new DDownloads();
            return dd.SelectByID(ID);
        }
    }
}
