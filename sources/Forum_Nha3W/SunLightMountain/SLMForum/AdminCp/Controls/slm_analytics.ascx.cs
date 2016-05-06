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

public partial class AdminCp_Controls_slm_analytics : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCalendar.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                                DateTime.Now.Year.ToString();
            btnReload.Text = LoadSLMF("SLMF_Analytics", "Title");
            LoadAnalDetails(DateTime.Parse(DateTime.Now.ToShortDateString()));
        }
    }

    private void LoadAnalDetails(DateTime dateAnal)
    {
        EnAnalytics anal = new EnAnalytics();
        anal.Today = dateAnal;
        anal = BuAnalytics.SelectAnalytics(anal);
        lblMembers.Text = anal.Members.ToString();
        lblMessages.Text = anal.Messages.ToString();
        lblModerators.Text = anal.Moderators.ToString();
        lblTopics.Text = anal.Topics.ToString();
        lblNewestMemberId.Text = anal.NewestMemberId.ToString();
        lblRegisterCount.Text = anal.RegisterCount.ToString();
        lblLoginCount.Text = anal.LoginCount.ToString();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    protected void btnReload_Click(object sender, EventArgs e)
    {
        string strStart = txtCalendar.Text.ToString();
        strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
        LoadAnalDetails(DateTime.Parse(strStart));
    }
}
