using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;

public partial class AdminCp_Controls_slm_updelreports : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrvReport();
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGrvReport()
    {
        grvReports.DataSource = BuReport.SelectAllReport2();
        grvReports.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    
    protected void grvReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvReports.SelectedIndex = -1;
        grvReports.PageIndex = e.NewPageIndex;
        LoadGrvReport();
    }
    protected void grvReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intReportId = int.Parse(grvReports.DataKeys[e.RowIndex].Value.ToString());
        EnReport rpt = new EnReport();
        rpt.ReportId = intReportId;
        BuReport.DeleteReport(rpt);
        LoadGrvReport();
    }
}
