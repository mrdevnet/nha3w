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
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;

public partial class SlmControls_slm_topannoun : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAnnounce();
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadAnnounce()
    {
        EnReport rpt = new EnReport();
        rpt = BuReport.SelectTopReport();
        if (rpt.ReportId > 0)
        {
            hrfAnnounce.InnerHtml = rpt.Title.ToString();
            hrfAnnounce.HRef = "../announcement.aspx?announceid=" + rpt.ReportId.ToString();
            hrfDetail.InnerHtml = LoadSLMF("SLMF_Announce", "Detail");
            hrfDetail.HRef = "../announcement.aspx?announceid=" + rpt.ReportId.ToString();
            string strTitle = rpt.Message.ToString();
            UtiGeneralClass clsNew = new UtiGeneralClass();
            UtiString utinew = new UtiString();
            int intLimit = int.Parse(clsNew.LoadLangs("SLMF_Announce", "NumberOfDetail").ToString());
            lblDescription.Text = utinew.ReleaseInput(strTitle, intLimit).Trim();
        }
        else
        {
            rptPanel.Visible = false;
        }
    }
}
