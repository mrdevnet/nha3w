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
using SLMF.Entity;
using SLMF.Business;

public partial class AdminCp_Controls_slm_bannerads : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSponsors();
            btnInsert.Text = LoadSLMF("SLMF_AddBanners", "Insert");
            btnUpdate.Text = LoadSLMF("SLMF_AddBanners", "Updated");
            lbtExpandIp.ToolTip = LoadSLMF("SLMF_AddBanners", "LbtExpand");
            lbtCloseIp.ToolTip = LoadSLMF("SLMF_AddBanners", "LbtClose");
            btnInsertFrmSpn.Text = LoadSLMF("SLMF_AddBanners", "Insert");
            lbtExp2.ToolTip = LoadSLMF("SLMF_AddBanners", "LbtExpand");
            lbtClo2.ToolTip = LoadSLMF("SLMF_AddBanners", "LbtClose");
        }
    }

    private void LoadSponsors()
    {
        grvSponsors.DataSource = BuSponsor.SelectAllSponsors();
        grvSponsors.DataBind();
        if (grvSponsors.Rows.Count == 0)
        {
            pnlBanners.Visible = true;
            trInsert.Visible = true;
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            LoadJumper();
            lbtExpandIp.Visible = false;
            lbtCloseIp.Visible = false;
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void grvSponsors_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvSponsors.SelectedRow;
        pnlBanners.Visible = true;
        int intSponsorId = int.Parse(grvSponsors.DataKeys[row.RowIndex].Value.ToString());
        LoadSelectedSponsor(intSponsorId);
    }

    private void LoadSelectedSponsor(int intSpnId)
    {
        EnSponsor spn = new EnSponsor();
        spn.SponsorId = intSpnId;
        BuSponsor.SelectScript(ref spn);
        txtScripts.Value = spn.Scripts;
        txtDescription.Text = spn.Description;
        lblReports.Visible = false;
        pnlForums.Visible = true;
        LoadSponsorsForums(spn);
        btnInsert.Visible = false;
        btnUpdate.Visible = true;
        lbtExpandIp.Visible = true;
        lbtCloseIp.Visible = false;
        trInsert.Visible = false;
    }

    private void LoadSponsorsForums(EnSponsor spn)
    {
        grvForums.DataSource = BuSponsor.SelectSpnFrm(spn);
        grvForums.DataBind();
        //lbtClo2.Visible = false;
    }
    protected void lbtExpandIp_Click(object sender, EventArgs e)
    {
        trInsert.Visible = true;
        lbtCloseIp.Visible = true;
        lbtExpandIp.Visible = false;
        btnInsert.Visible = true;
        btnUpdate.Visible = false;
        LoadJumper();
        lblReports.Visible = false;
    }
    protected void lbtCloseIp_Click(object sender, EventArgs e)
    {
        trInsert.Visible = false;
        lbtCloseIp.Visible = false;
        lbtExpandIp.Visible = true;
        btnInsert.Visible = false;
        btnUpdate.Visible = true;
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
                ddlJumper.Items.Add(LoadSLMF("SLMF_AddBanners", "ChooseForumDDl"));
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

    private void LoadJumper2()
    {
        int i = 0, k = 0, l = 0;
        SqlDataReader jcate = BuCategory.SelectCategory();
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        while (jcate.Read())
        {
            if (i == 0)
            {
                ddlJumper2.Items.Add(LoadSLMF("SLMF_AddBanners", "ChooseForumDDl"));
                ddlJumper2.Items[i].Value = "-1";
                i++;
            }
            ddlJumper2.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            ddlJumper2.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            i++;
            EnCategory cate = new EnCategory();
            cate.CategoryId = k;
            SqlDataReader datrj = BuForum.SelectJump(cate, mbr);
            if (datrj.HasRows)
            {
                while (datrj.Read())
                {
                    ddlJumper2.Items.Add("- - " + datrj["Name"].ToString());
                    l = int.Parse(datrj["ForumId"].ToString());
                    ddlJumper2.Items[i].Value = "topicdisplay.aspx?forumid=" + l.ToString();
                    i++;
                    EnForum frm = new EnForum();
                    frm.ForumId = l;
                    SqlDataReader j2 = BuForum.SelectJump2(frm, mbr);
                    if (j2.HasRows)
                    {
                        while (j2.Read())
                        {
                            ddlJumper2.Items.Add("- - - - " + j2["Name"].ToString());
                            ddlJumper2.Items[i].Value = "topicdisplay.aspx?forumid=" + j2["ForumId"].ToString();
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtScripts.Value.ToString() != "")
        {
            UpdateScripts();
        }
    }

    private void UpdateScripts()
    {
        if (grvSponsors.SelectedValue != null)
        {
            GridViewRow row = grvSponsors.SelectedRow;
            int intSponsorId = int.Parse(grvSponsors.DataKeys[row.RowIndex].Value.ToString());
            EnSponsor spn = new EnSponsor();
            spn.SponsorId = intSponsorId;
            spn.Scripts = txtScripts.Value.ToString();
            spn.Description = txtDescription.Text.ToString();
            BuSponsor.UpdateScripts(spn);
            LoadSelectedSponsor(intSponsorId);
            LoadSponsors();
            grvSponsors.SelectedIndex = row.RowIndex;
            lblReports.Text = LoadSLMF("SLMF_AddBanners", "UpdatedSuccess");
            lblReports.Visible = true;
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (txtScripts.Value.ToString() != "")
        {
            InsertScripts();
            pnlBanners.Visible = false;
            pnlForums.Visible = false;
            grvSponsors.SelectedIndex = -1;
        }
    }

    private void InsertScripts()
    {
        if (ddlJumper.SelectedValue != "-1")
        {
            string strSub = ddlJumper.SelectedValue.Substring(18, 7);
            int intForumId = int.Parse(FindString(ddlJumper.SelectedValue.ToString()));
            if (strSub != "groupid")
            {
                EnForum frm = new EnForum();
                frm.ForumId = intForumId;
                EnSponsor spn = new EnSponsor();
                spn.Scripts = txtScripts.Value.ToString();
                spn.Description = txtDescription.Text.ToString();
                BuSponsor.InsertScripts(spn, frm);
                LoadSponsors();
            }
        }
    }

    private string FindString(string strView)
    {
        return strView.Substring(26);
    }
    protected void lbtExp2_Click(object sender, EventArgs e)
    {
        trInsertFrmSpn.Visible = true;
        trInsertFrmSpn2.Visible = true;
        lbtClo2.Visible = true;
        lbtExp2.Visible = false;
        LoadJumper2();
    }
    protected void lbtClo2_Click(object sender, EventArgs e)
    {
        trInsertFrmSpn.Visible = false;
        trInsertFrmSpn2.Visible = false;
        lbtClo2.Visible = false;
        lbtExp2.Visible = true;
    }
    protected void btnInsertFrmSpn_Click(object sender, EventArgs e)
    {
        InsertForumSponsor();
    }

    private void InsertForumSponsor()
    {
        if (ddlJumper2.SelectedValue != "-1" && grvSponsors.SelectedValue != null)
        {
            string strSub = ddlJumper2.SelectedValue.Substring(18, 7);
            int intForumId = int.Parse(FindString(ddlJumper2.SelectedValue.ToString()));
            if (strSub != "groupid")
            {
                GridViewRow row = grvSponsors.SelectedRow;
                int intSponsorId = int.Parse(grvSponsors.DataKeys[row.RowIndex].Value.ToString());
                EnSponsor spn = new EnSponsor();
                spn.SponsorId = intSponsorId;
                EnForum frm = new EnForum();
                frm.ForumId = intForumId;
                int intResult = BuSponsor.InsertFrmSpn(spn, frm);
                if (intResult == 1)
                {
                    lblReportFrmSpn.Text = LoadSLMF("SLMF_AddBanners", "ExistsForumSponsor");
                }
                else
                {
                    lblReportFrmSpn.Text = LoadSLMF("SLMF_AddBanners", "InsertFrmSpnSuccess");
                }
                LoadSponsorsForums(spn);
            }
            else
            {
                lblReportFrmSpn.Text = LoadSLMF("SLMF_AddBanners", "SelectedGroup");
            }
        }
    }
    protected void grvSponsors_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intSpnId = int.Parse(grvSponsors.DataKeys[e.RowIndex].Value.ToString());
        EnSponsor spn = new EnSponsor();
        spn.SponsorId = intSpnId;
        BuSponsor.DeleteSpn(spn);
        LoadSponsors();
        grvSponsors.SelectedIndex = -1;
        pnlBanners.Visible = false;
        pnlForums.Visible = false;
    }
    protected void grvForums_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (grvSponsors.SelectedValue != null)
        {
            GridViewRow row = grvSponsors.SelectedRow;
            int intSponsorId = int.Parse(grvSponsors.DataKeys[row.RowIndex].Value.ToString());
            EnSponsor spn = new EnSponsor();
            spn.SponsorId = intSponsorId;
            grvForums.SelectedIndex = -1;
            grvForums.PageIndex = e.NewPageIndex;
            LoadSponsorsForums(spn);
        }
    }
    protected void grvForums_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvSponsors.SelectedValue != null)
        {
            GridViewRow row = grvSponsors.SelectedRow;
            int intSponsorId = int.Parse(grvSponsors.DataKeys[row.RowIndex].Value.ToString());
            EnSponsor spnMain = new EnSponsor();
            spnMain.SponsorId = intSponsorId;
            int intSpnId = int.Parse(grvForums.DataKeys[e.RowIndex]["SponsorId"].ToString());
            int intFrmId = int.Parse(grvForums.DataKeys[e.RowIndex]["ForumId"].ToString());
            EnSponsor spn = new EnSponsor();
            spn.SponsorId = intSpnId;
            EnForum frm = new EnForum();
            frm.ForumId = intFrmId;
            BuSponsor.DeleteFrmSpn(spn, frm);
            LoadSponsorsForums(spnMain);
        }
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
