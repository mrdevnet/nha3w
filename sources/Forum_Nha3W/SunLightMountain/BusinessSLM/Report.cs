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
using SLMF.Entity;
using SLMF.DataAccess;


namespace SLMF.Business
{
    public class BuReport
    {
        public BuReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectReport(EnForum forum)
        {
            DaReport report = new DaReport();
            SqlDataReader datrReport = report.SelectReport(forum);
            return datrReport;
        }

        public static SqlDataReader ShowReport(EnReport rpt)
        {
            DaReport report = new DaReport();
            SqlDataReader datrReport = report.ShowReport(rpt);
            return datrReport;
        }

        public static void ShowReport2(ref EnReport rpt)
        {
            DaReport darpt = new DaReport();
            darpt.ShowReport2(ref rpt);
        }

        public static void UpdateViews(EnReport rpt)
        {
            DaReport report = new DaReport();
            report.UpdateViews(rpt);
        }

        //public static EnReport SelectTopReport()
        //{
        //    DaReport rpt = new DaReport();
        //    EnReport r = new EnReport();
        //    r = rpt.SelectTopReport();
        //    return r;
        //}


        private static EnReport LstSelTopReport()
        {
            DaReport rpt = new DaReport();
            string ch = "LstSelTopRpts";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, rpt.SelectTopReport(), "SelTopRpts");
            }
            return (EnReport)BServer.Get(ch);
        }

        public static EnReport SelectTopReport()
        {
            EnReport tmp = new EnReport();
            tmp = LstSelTopReport();
            if (tmp == null || tmp.ReportId == 0)
            {
                BServer.Remove("SelTopRpts", true);
                tmp = LstSelTopReport();
            }
            return tmp;
        }





        public static void InsertReports(EnReport rpt)
        {
            DaReport darpt = new DaReport();
            darpt.InsertReports(rpt);
        }

        public static SqlDataReader SelectAllReport()
        {
            DaReport rpt = new DaReport();
            return rpt.SelectAllReport();
        }

        public static DataTable SelectAllReport2()
        {
            DaReport rpt = new DaReport();
            return rpt.SelectAllReport2();
        }

        public static DataTable SelectAllForumReport()
        {
            DaReport rpt = new DaReport();
            return rpt.SelectAllForumReport();
        }

        public static int InsertForumReport(EnReport rpt, EnForum forum)
        {
            DaReport daRpt = new DaReport();
            return daRpt.InsertForumReport(rpt, forum);
        }

        public static void DeleteForumReport(EnReport rpt, EnForum frm)
        {
            DaReport daRpt = new DaReport();
            daRpt.DeleteForumReport(rpt, frm);
        }

        public static void DeleteReport(EnReport rpt)
        {
            DaReport daRpt = new DaReport();
            daRpt.DeleteReport(rpt);
        }

        public static void UpdateReport(EnReport rpt)
        {
            DaReport darpt = new DaReport();
            darpt.UpdateReport(rpt);
        }



    }
}
