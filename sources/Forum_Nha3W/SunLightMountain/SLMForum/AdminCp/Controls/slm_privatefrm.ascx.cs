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

public partial class AdminCp_Controls_slm_privatefrm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrvForums();
            btnSearch.Text = LoadSLMF("SLMF_UserA", "Find");
            LoadUserGroup();
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void LoadGrvForums()
    {
        grvForums.DataSource = BuForum.SelectPrivFrms();
        grvForums.DataBind();
    }

    private void LoadUserGroup()
    {
        EnMember mbr = new EnMember();
        mbr.FullName = txtUserName.Text.ToString();
        SearchUser(mbr);
    }

    private void SearchUser(EnMember mbr)
    {
        grvUsers.DataSource = BuMember.SelectUserGroup(mbr);
        grvUsers.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadUserGroup();
    }

    private void PrivateUsersFrms(int intForumId)
    {
        EnForum frm = new EnForum();
        frm.ForumId = intForumId;
        grvPriUsersFrms.DataSource = BuForum.SelectPrivUserFrm(frm);
        grvPriUsersFrms.DataBind();
        if (grvPriUsersFrms.Rows.Count > 0)
        {
            pnlUsersFrms.Visible = true;
        }
        else
        {
            pnlUsersFrms.Visible = false;
        }
    }
    protected void grvForums_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvUsers.SelectedIndex = -1;
        btnSetModer.Visible = false;
        trModerator.Visible = false;
        lblModer.Text = "";
        GridViewRow row = grvForums.SelectedRow;
        int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
        PrivateUsersFrms(intFrmId);
    }
    protected void grvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSetModer.Text = LoadSLMF("SLMF_PrivForumA", "ChooseMemberBtn");
        btnSetModer.Visible = true;
        trModerator.Visible = true;
        lblModer.Text = "";
    }
    protected void btnSetModer_Click(object sender, EventArgs e)
    {
        if (grvForums.SelectedValue != null && grvUsers.SelectedValue != null)
        {
            GridViewRow row2 = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row2.RowIndex].Value.ToString());
            GridViewRow row3 = grvUsers.SelectedRow;
            int intUserId = int.Parse(grvUsers.DataKeys[row3.RowIndex].Value.ToString());
            EnForum frm = new EnForum();
            EnMember mbr = new EnMember();
            frm.ForumId = intFrmId;
            mbr.MemberId = intUserId;
            bool intResult = BuForum.InsertPrivUsersFrms(frm, mbr);
            if (!intResult)
            {
                lblModer.Text = LoadSLMF("SLMF_PrivForumA", "SelectedMember");
            }
            else
            {
                PrivateUsersFrms(intFrmId);
            }
        }
        else
        {
            lblModer.Text = LoadSLMF("SLMF_PrivForumA", "UnSelectedForum");
        }
    }
    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsers.PageIndex = e.NewPageIndex;
        LoadUserGroup();
        grvUsers.SelectedIndex = -1;
        btnSetModer.Visible = false;
        trModerator.Visible = false;
    }
    protected void grvPriUsersFrms_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvForums.SelectedValue != null)
        {
            GridViewRow row = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
            int intFrmId2 = int.Parse(grvPriUsersFrms.DataKeys[e.RowIndex]["ForumId"].ToString());
            int intMbrId = int.Parse(grvPriUsersFrms.DataKeys[e.RowIndex]["MemberId"].ToString());
            EnForum frm = new EnForum();
            EnMember mbr = new EnMember();
            frm.ForumId = intFrmId2;
            mbr.MemberId = intMbrId;
            BuForum.DeletePrivUsersFrms(frm, mbr);
            PrivateUsersFrms(intFrmId);
        }
    }
}
