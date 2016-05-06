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

public partial class AdminCp_Controls_slm_reportman : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadJumper();
            LoadReport();
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "Submit");
            LoadGrvRptMan();
        }
    }

    private void LoadGrvRptMan()
    {
        DataTable dttRptMan = BuReport.SelectAllForumReport();
        grvReportMan.DataSource = dttRptMan;
        grvReportMan.DataBind();
    }

    private void InsertForumReport()
    {
        if (ddlReports.SelectedValue.ToString() != "-1" && ddlJumper.SelectedValue != "-1")
        {
            string strSub = ddlJumper.SelectedValue.Substring(18, 7);
            int intForumId = int.Parse(FindString(ddlJumper.SelectedValue.ToString()));
            if (strSub != "groupid")
            {
                EnReport rpt = new EnReport();
                rpt.ReportId = int.Parse(ddlReports.SelectedValue.ToString());
                EnForum frm = new EnForum();
                frm.ForumId = intForumId;
                int intResult = BuReport.InsertForumReport(rpt, frm);
                if (intResult == -1)
                {
                    lblReport.Text = LoadSLMF("SLMF_ReportA", "CreateFailed");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + LoadSLMF("SLMF_ReportA", "CreateFailed") + "')</script>");
                }
                else
                {
                    lblReport.Text = LoadSLMF("SLMF_GeneralA", "SubmitSuccess");
                    LoadGrvRptMan();
                }
            }
            else
            {
                lblReport.Text = LoadSLMF("SLMF_ReportA", "UnSelected");
            }
        }
        else
        {
            lblReport.Text = LoadSLMF("SLMF_ReportA", "UnSelected");
        }
    }

    private string FindString(string strView)
    {
        return strView.Substring(26);
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    private void LoadJumper()
    {
        int i = 0, k = 0, l = 0;
        SqlDataReader jcate = BuCategory.SelectCategory();
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        while (jcate.Read())
        {
            if (i == 0)
            {
                ddlJumper.Items.Add(LoadSLMF("SLMF_ReportA", "SelectForumId"));
                ddlJumper.Items[i].Value = "-1";
                i++;
            }
            //if (i == 1)
            //{
            //    ddlJumper.Items.Add(LoadSLMF("SLMF_Forum", "VLF"));
            //    ddlJumper.Items[i].Value = "Default.aspx";
            //    i++;
            //}
            ddlJumper.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            ddlJumper.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            i++;
            EnCategory cate = new EnCategory();
            cate.CategoryId = k;
            SqlDataReader datrj = BuForum.SelectJump(cate, mbr);
            if (datrj.HasRows)
            {
                while (datrj.Read())
                {
                    ddlJumper.Items.Add("- - " + datrj["Name"].ToString());
                    l = int.Parse(datrj["ForumId"].ToString());
                    ddlJumper.Items[i].Value = "topicdisplay.aspx?forumid=" + l.ToString();
                    i++;
                    EnForum frm = new EnForum();
                    frm.ForumId = l;
                    SqlDataReader j2 = BuForum.SelectJump2(frm, mbr);
                    if (j2.HasRows)
                    {
                        while (j2.Read())
                        {
                            ddlJumper.Items.Add("- - - - " + j2["Name"].ToString());
                            ddlJumper.Items[i].Value = "topicdisplay.aspx?forumid=" + j2["ForumId"].ToString();
                            i++;
                        }
                    }
                    if (j2.IsClosed == false)
                    {
                        j2.Close();
                        j2.Dispose();
                    }
                }
            }
            if (datrj.IsClosed == false)
            {
                datrj.Close();
                datrj.Dispose();
            }
        }
        if (jcate.IsClosed == false)
        {
            jcate.Close();
            jcate.Dispose();
        }
    }

    private void LoadReport()
    {
        int i = 0;
        SqlDataReader rpt = BuReport.SelectAllReport();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlReports.Items.Add(LoadSLMF("SLMF_ReportA", "SelectReportId"));
                ddlReports.Items[i].Value = "-1";
                i++;
            }
            ddlReports.Items.Add(rpt["Title"].ToString());
            ddlReports.Items[i].Value = rpt["ReportId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }
    protected void grvReportMan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvReportMan.SelectedIndex = -1;
        grvReportMan.PageIndex = e.NewPageIndex;
        LoadGrvRptMan();
    }
    protected void grvReportMan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intReportId = int.Parse(grvReportMan.DataKeys[e.RowIndex]["ReportId"].ToString());
        int intForumId = int.Parse(grvReportMan.DataKeys[e.RowIndex]["ForumId"].ToString());
        EnReport rpt = new EnReport();
        rpt.ReportId = intReportId;
        EnForum frm = new EnForum();
        frm.ForumId = intForumId;
        BuReport.DeleteForumReport(rpt, frm);
        LoadGrvRptMan();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertForumReport();
    }

    private string SentForCook()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        string strUser = "";
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            strUser = SlmMemberCookie.Value.ToString();
        }
        return strUser;
    }
}
