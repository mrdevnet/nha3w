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

namespace SLMF.DataAccess
{
    public class DaReport
    {
        public DaReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectReport(EnForum forum)
        {
            string strCommandText = "selReportForum";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);

            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            return datrCate;
        }

        public SqlDataReader ShowReport(EnReport rpt)
        {
            string strCommandText = "selReportShow";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ReportId", rpt.ReportId);
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrCate;
        }

        public void ShowReport2(ref EnReport rpt)
        {
            string strCommandText = "selReportShow";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ReportId", rpt.ReportId);
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            rpt = CreateReport(datrCate);
            if (datrCate.IsClosed)
            {
                datrCate.Close();
                datrCate.Dispose();
            }
        }

        private EnReport CreateReport(IDataReader reader)
        {
            EnReport rpt = new EnReport();
            if (reader.Read())
            {
                //rpt.ReportId = int.Parse(reader["ReportId"].ToString());
                rpt.Title = reader["Title"].ToString();
                rpt.Message = reader["Message"].ToString();
                rpt.StartDate = DateTime.Parse(reader["CreationDate"].ToString());
                rpt.FinishDate = DateTime.Parse(reader["FinishDate"].ToString());
                rpt.ShowAll = bool.Parse(reader["ShowAll"].ToString());
                rpt.AllForum = bool.Parse(reader["AllForum"].ToString());
                rpt.IsTop = bool.Parse(reader["IsTop"].ToString());
                rpt.TotalViews = int.Parse(reader["TotalViews"].ToString());
            }
            return rpt;
        }

        public void UpdateViews(EnReport rpt) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "updReportShow";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ReportId", rpt.ReportId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public EnReport SelectTopReport()
        {
            string strCommandText = "selReportTop";
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            EnReport rpt = new EnReport();
            rpt.ReportId = 0;
            rpt = CreateTopReport(datrCate);
            if (datrCate.IsClosed == false)
            {
                datrCate.Close();
                datrCate.Dispose();
            }
            return rpt;
        }

        private EnReport CreateTopReport(IDataReader reader)
        {
            EnReport rpt = new EnReport();
            if (reader.Read())
            {
                rpt.ReportId = int.Parse(reader["ReportId"].ToString());
                rpt.Title = reader["Title"].ToString();
                rpt.Message = reader["Message"].ToString();
                rpt.StartDate = DateTime.Parse(reader["StartDate"].ToString());                
            }
            return rpt;
        }

        public void InsertReports(EnReport rpt) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "insReports";
            SqlParameter[] paraLocal = new SqlParameter[9];
            paraLocal[0] = new SqlParameter("@Title", rpt.Title);
            paraLocal[1] = new SqlParameter("@Message", rpt.Message);
            paraLocal[2] = new SqlParameter("@StartDate", rpt.StartDate);
            paraLocal[3] = new SqlParameter("@FinishDate", rpt.FinishDate);
            paraLocal[4] = new SqlParameter("@ShowAll", rpt.ShowAll);
            paraLocal[5] = new SqlParameter("@AllForum", rpt.AllForum);
            paraLocal[6] = new SqlParameter("@MemberId", rpt.MemberId);
            paraLocal[7] = new SqlParameter("@TotalViews", rpt.TotalViews);
            paraLocal[8] = new SqlParameter("@IsTop", rpt.IsTop);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectAllReport()
        {
            string strCommandText = "selReportAll";
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectAllReport2()
        {
            string strCommandText = "selReportAll";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectAllForumReport()
        {
            string strCommandText = "selForumReportAll";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public int InsertForumReport(EnReport rpt, EnForum forum) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "insForumReport";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", forum.ForumId);
            paraLocal[1] = new SqlParameter("@ReportId", rpt.ReportId);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[2].Value.ToString());
        }

        public void DeleteForumReport(EnReport rpt, EnForum frm)
        {
            string strCommandText = "delForumReport";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            paraLocal[1] = new SqlParameter("@ReportId", rpt.ReportId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteReport(EnReport rpt)
        {
            string strCommandText = "delReport";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ReportId", rpt.ReportId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateReport(EnReport rpt)
        {
            string strCommandText = "updReports";
            SqlParameter[] paraLocal = new SqlParameter[10];
            paraLocal[0] = new SqlParameter("@ReportId", rpt.ReportId);
            paraLocal[1] = new SqlParameter("@Title", rpt.Title);
            paraLocal[2] = new SqlParameter("@Message", rpt.Message);
            paraLocal[3] = new SqlParameter("@StartDate", rpt.StartDate);
            paraLocal[4] = new SqlParameter("@FinishDate", rpt.FinishDate);
            paraLocal[5] = new SqlParameter("@ShowAll", rpt.ShowAll);
            paraLocal[6] = new SqlParameter("@AllForum", rpt.AllForum);
            paraLocal[7] = new SqlParameter("@MemberId", rpt.MemberId);
            paraLocal[8] = new SqlParameter("@TotalViews", rpt.TotalViews);
            paraLocal[9] = new SqlParameter("@IsTop", rpt.IsTop);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }


    }
}
