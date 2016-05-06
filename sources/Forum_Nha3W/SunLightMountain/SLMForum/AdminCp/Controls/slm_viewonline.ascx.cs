using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Entity;
using SLMF.Utility;
using SLMF.Business;

public partial class AdminCp_Controls_slm_viewonline : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOnlines();
        }
    }

    private void LoadOnlines()
    {
        grvViewOnline.DataSource = BuInformation.SelectViewOnline();
        grvViewOnline.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void grvViewOnline_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strDetails = grvViewOnline.DataKeys[e.RowIndex].Value.ToString();
        EnInformation i = new EnInformation();
        i.DetailId = strDetails;
        BuInformation.DeleteInfor(i);
        LoadOnlines();
    }
    protected void grvViewOnline_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvViewOnline.PageIndex = e.NewPageIndex;
        LoadOnlines();
    }
}
