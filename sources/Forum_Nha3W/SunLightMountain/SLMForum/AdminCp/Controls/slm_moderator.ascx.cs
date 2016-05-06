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

public partial class AdminCp_Controls_slm_moderator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
            int intCateId = -1;
            intCateId = int.Parse(ddlCategories.SelectedValue.ToString());
            LoadGrvForums(intCateId);
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGrvForums(int intCateId)
    {
        EnForum frm = new EnForum();
        frm.CateId = intCateId;
        grvForums.DataSource = BuForum.SelectAllForums(frm);
        grvForums.DataBind();
    }

    private void LoadGrvGroups(int intForumId)
    {
        EnForum frm = new EnForum();
        frm.ForumId = intForumId;
        grvGroups.DataSource = BuForum.SelectAllGrpFrm(frm);
        grvGroups.DataBind();
        if (grvGroups.Rows.Count == 0)
        {
            pnlModerator.Visible = true;
        }
    }

    private void LoadCategories()
    {
        int i = 0;
        SqlDataReader rpt = BuCategory.SelectAllCategories();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlCategories.Items.Add(LoadSLMF("SLMF_ForumA", "SelectAllCateId"));
                ddlCategories.Items[i].Value = "-1";
                i++;
            }
            ddlCategories.Items.Add(rpt["CateName"].ToString());
            ddlCategories.Items[i].Value = rpt["CategoryId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
        grvForums.SelectedIndex = -1;
        grvGroups.SelectedIndex = -1;
        pnlGroups.Visible = false;
        pnlModerator.Visible = false;
        pnlGrpFrmUsers.Visible = false;
    }
    protected void grvForums_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlGroups.Visible = true;
        pnlModerator.Visible = false;
        grvGroups.SelectedIndex = -1;
        GridViewRow row = grvForums.SelectedRow;
        int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
        LoadGrvGroups(intFrmId);
        EnModerator moder = new EnModerator();
        moder.ForumId = intFrmId;
        LoadGrpFrmUsers(moder);
    }
    protected void grvGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlModerator.Visible = true;
        //GridViewRow row = grvGroups.SelectedRow;
        //int intGrpId = int.Parse(grvGroups.DataKeys[row.RowIndex].Value.ToString());
        //GridViewRow row2 = grvForums.SelectedRow;
        //int intFrmId = int.Parse(grvForums.DataKeys[row2.RowIndex].Value.ToString());
        btnSearch.Text = LoadSLMF("SLMF_UserA", "Find");
        grvUsers.SelectedIndex = -1;
        btnSetModer.Visible = false;
        trModerator.Visible = false;
        lblModer.Text = "";
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadUserGroup();
    }

    private void SearchUser(EnMember mbr)
    {
        grvUsers.DataSource = BuMember.SelectUserGroup(mbr);
        grvUsers.DataBind();
    }

    private void LoadUserGroup()
    {
        EnMember mbr = new EnMember();
        mbr.FullName = txtUserName.Text.ToString();
        SearchUser(mbr);
    }
    protected void grvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSetModer.Text = LoadSLMF("ModeratorA", "SetModer");
        SuperModer.Text = LoadSLMF("ModeratorA", "IsSuper2");
        btnSetModer.Visible = true;
        trModerator.Visible = true;
        lblModer.Text = "";
    }
    protected void btnSetModer_Click(object sender, EventArgs e)
    {
        if (grvForums.SelectedValue != null && grvGroups.SelectedValue != null && grvUsers.SelectedValue != null)
        {
            GridViewRow row = grvGroups.SelectedRow;
            int intGrpId = int.Parse(grvGroups.DataKeys[row.RowIndex].Value.ToString());
            GridViewRow row2 = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row2.RowIndex].Value.ToString());
            GridViewRow row3 = grvUsers.SelectedRow;
            int intUserId = int.Parse(grvUsers.DataKeys[row3.RowIndex].Value.ToString());
            EnModerator moder = new EnModerator();
            moder.GroupId = intGrpId;
            moder.ForumId = intFrmId;
            moder.MemberId = intUserId;
            moder.IsSuper = false;
            if (SuperModer.Checked)
            {
                moder.IsSuper = true;
            }
            int intResult = BuModerator.InsertModer(moder);
            if (intResult == 1)
            {
                lblModer.Text = LoadSLMF("ModeratorA", "InsertModerFailed");
            }
            else
            {
                LoadGrpFrmUsers(moder);
            }
        }
        else if (grvGroups.SelectedValue == null)
        {
            lblModer.Text = LoadSLMF("ModeratorA", "UnSelectedGroup");
        }
    }

    private void LoadGrpFrmUsers(EnModerator moder)
    {
        grvGrpFrmUsers.DataSource = BuModerator.SelectGrpFrmUsers(moder);
        grvGrpFrmUsers.DataBind();
        if (grvGrpFrmUsers.Rows.Count > 0)
        {
            pnlGrpFrmUsers.Visible = true;
        }
        else
        {
            pnlGrpFrmUsers.Visible = false;
        }
    }



    protected void grvForums_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvForums.PageIndex = e.NewPageIndex;
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
        grvForums.SelectedIndex = -1;
        grvGroups.SelectedIndex = -1;
        pnlGroups.Visible = false;
        pnlModerator.Visible = false;
        pnlGrpFrmUsers.Visible = false;
    }
    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsers.PageIndex = e.NewPageIndex;
        LoadUserGroup();
        grvUsers.SelectedIndex = -1;
        btnSetModer.Visible = false;
        trModerator.Visible = false;
    }
    protected void grvGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvForums.SelectedValue != null)
        {
            grvGroups.SelectedIndex = -1;
            grvUsers.SelectedIndex = -1;
            btnSetModer.Visible = false;
            trModerator.Visible = false;
            //pnlSetPermission.Visible = false;
            GridViewRow row = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
            int intGrpId = int.Parse(grvGroups.DataKeys[e.RowIndex]["GroupId"].ToString());
            int intFrmId2 = int.Parse(grvGroups.DataKeys[e.RowIndex]["ForumId"].ToString());
            EnMemberAuthorize mbr = new EnMemberAuthorize();
            mbr.GroupId = intGrpId;
            mbr.ForumId = intFrmId2;
            BuForum.DeleteGrpFrmAuthor(mbr);
            LoadGrvGroups(intFrmId);
            EnModerator moder = new EnModerator();
            moder.ForumId = intFrmId;
            LoadGrpFrmUsers(moder);
        }
    }
    protected void grvGrpFrmUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvForums.SelectedValue != null)
        {
            GridViewRow row = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
            int intGrpId = int.Parse(grvGrpFrmUsers.DataKeys[e.RowIndex]["GroupId"].ToString());
            int intFrmId2 = int.Parse(grvGrpFrmUsers.DataKeys[e.RowIndex]["ForumId"].ToString());
            int intMbrId = int.Parse(grvGrpFrmUsers.DataKeys[e.RowIndex]["MemberId"].ToString());
            EnModerator moder = new EnModerator();
            moder.GroupId = intGrpId;
            moder.ForumId = intFrmId2;
            moder.MemberId = intMbrId;
            BuModerator.DeleteModerator(moder);
            moder.ForumId = intFrmId;
            LoadGrpFrmUsers(moder);
        }
    }
}
