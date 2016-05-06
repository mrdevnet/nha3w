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
using SLMF.Entity;
using SLMF.Business;

public partial class AdminCp_Controls_slm_addreports : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "Submit");
            if (Request.Params["rptid"] != null)
            {
                int intRptId = int.Parse(Request.Params["rptid"].ToString());
                LoadReport(intRptId);
                btnSave.Text = LoadSLMF("SLMF_ReportA", "UpdateReport");
                spnReport.InnerText = LoadSLMF("SLMF_ReportA", "UpdateReport2");
            }
            else
            {
                spnReport.InnerText = LoadSLMF("SLMF_ReportA", "Add");
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadReport(int intRptId)
    {
        EnReport rpt = new EnReport();
        rpt.ReportId = intRptId;
        BuReport.ShowReport2(ref rpt);
        txtTitle.Text = rpt.Title;
        txtContent.Value = rpt.Message;
        txtStartDate.Text = rpt.StartDate.Day + "/" + rpt.StartDate.Month + "/" + rpt.StartDate.Year;
        txtFinishDate.Text = rpt.FinishDate.Day + "/" + rpt.FinishDate.Month + "/" + rpt.FinishDate.Year;
        ckbShowAll.Checked = bool.Parse(rpt.ShowAll.ToString());
        ckbAllForum.Checked = bool.Parse(rpt.AllForum.ToString());
        ckbIsTop.Checked = bool.Parse(rpt.IsTop.ToString());
        txtTotalView.Text = rpt.TotalViews.ToString();
    }

    private void InserReport()
    {
        EnReport rpt = new EnReport();
        rpt.Title = txtTitle.Text.ToString();
        rpt.Message = txtContent.Value.ToString();
        string strStart = txtStartDate.Text.ToString();
        strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
        rpt.StartDate = DateTime.Parse(strStart);
        string strFinish = txtFinishDate.Text.ToString();
        strFinish = strFinish.Substring(3, 2) + "/" + strFinish.Substring(0, 2) + "/" + strFinish.Substring(6, 4);
        rpt.FinishDate = DateTime.Parse(strFinish);
        bool bolShowAll = false;
        if (ckbShowAll.Checked)
            bolShowAll = true;
        rpt.ShowAll = bolShowAll;
        bool bolAllForum = false;
        if (ckbAllForum.Checked)
            bolAllForum = true;
        rpt.AllForum = bolAllForum;
        bool bolIsTop = false;
        if (ckbIsTop.Checked)
            bolIsTop = true;
        rpt.IsTop = bolIsTop;
        EnMember member = new EnMember();
        member.UserName = LookCookie();
        member = BuMember.SelectMemberIdFUser(member);
        rpt.MemberId = member.MemberId;
        int intTotal = 0;
        if (int.TryParse(txtTotalView.Text.ToString(), out intTotal))
            intTotal = int.Parse(txtTotalView.Text.ToString());
        rpt.TotalViews = intTotal;
        BuReport.InsertReports(rpt);
        lblReport.Text = LoadSLMF("SLMF_GeneralA", "SubmitSuccess");
    }

    private void UpdateReport(int intReportId)
    {
        EnReport rpt = new EnReport();
        rpt.ReportId = intReportId;
        rpt.Title = txtTitle.Text.ToString();
        rpt.Message = txtContent.Value.ToString();
        string strStart = txtStartDate.Text.ToString();
        strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
        rpt.StartDate = DateTime.Parse(strStart);
        string strFinish = txtFinishDate.Text.ToString();
        strFinish = strFinish.Substring(3, 2) + "/" + strFinish.Substring(0, 2) + "/" + strFinish.Substring(6, 4);
        rpt.FinishDate = DateTime.Parse(strFinish);
        bool bolShowAll = false;
        if (ckbShowAll.Checked)
            bolShowAll = true;
        rpt.ShowAll = bolShowAll;
        bool bolAllForum = false;
        if (ckbAllForum.Checked)
            bolAllForum = true;
        rpt.AllForum = bolAllForum;
        bool bolIsTop = false;
        if (ckbIsTop.Checked)
            bolIsTop = true;
        rpt.IsTop = bolIsTop;
        EnMember member = new EnMember();
        member.UserName = LookCookie();
        member = BuMember.SelectMemberIdFUser(member);
        rpt.MemberId = member.MemberId;
        int intTotal = 0;
        if (int.TryParse(txtTotalView.Text.ToString(), out intTotal))
            intTotal = int.Parse(txtTotalView.Text.ToString());
        rpt.TotalViews = intTotal;
        BuReport.UpdateReport(rpt);
        lblReport.Text = LoadSLMF("SLMF_ReportA", "UpdateSuccessful");
    }

    private string LookCookie()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        string strUser = "";
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            strUser = SlmMemberCookie.Value.ToString();
            //hrfMember.InnerHtml = strUser;
            //EnMember member = new EnMember();
            //member.UserName = strUser;
            //member = BuMember.SelectMemberIdFUser(member);
            //hrfMember.HRef = "../showprofile.aspx?memberid=" + member.MemberId;
        }
        return strUser;
    }

    private void ResetControls()
    {
        txtTitle.Text = "";
        txtContent.Value = "";
        txtStartDate.Text = "";
        txtFinishDate.Text = "";
        ckbAllForum.Checked = false;
        ckbShowAll.Checked = false;
        ckbIsTop.Checked = false;
        txtTotalView.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.Params["rptid"] != null)
        {
            int intRptId = int.Parse(Request.Params["rptid"].ToString());
            UpdateReport(intRptId);
        }
        else
        {
            if (txtTitle.Text.ToString() != "" && txtContent.Value.ToString() != "")
            {
                InserReport();
            }
        }
        ResetControls();
    }
}
