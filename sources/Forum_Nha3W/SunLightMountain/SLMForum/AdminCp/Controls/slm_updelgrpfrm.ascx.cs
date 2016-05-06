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

public partial class AdminCp_Controls_slm_updelgrpfrm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
            int intCateId = -1;
            intCateId = int.Parse(ddlCategories.SelectedValue.ToString());
            LoadGrvForums(intCateId);
            rbtApproAuthorY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtApproAuthorN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtApproveY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtApproveN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtDelMsgY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtDelMsgN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtDelTopicY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtDelTopicN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtEditY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtEditN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtEmY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtEmN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtForwardY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtForwardN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtLockY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtLockN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtMoveY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtMoveN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtPmY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtPmN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtPollY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtPollN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtPostY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtPostN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtQuoteY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtQuoteN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtRateY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtRateN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtReplyY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtReplyN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtRptAuthorY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtRptAuthorN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtStickyY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtStickyN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtUnLockY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtUnLockN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtUploadY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtUploadN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtViewIpY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtViewIpN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtViewProY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtViewProN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtVoteY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtVoteN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            rbtThankY.Text = LoadSLMF("PermissionGrpFrmA", "Yes");
            rbtThankN.Text = LoadSLMF("PermissionGrpFrmA", "No");
            Default4All.Text = LoadSLMF("PermissionGrpFrmA", "Default4All2");
            btnInsGroups.Text = LoadSLMF("PermissionGrpFrmA", "Insert");
            btnUpdateSet.Text = LoadSLMF("PermissionGrpFrmA", "Update");
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
            pnlSetPermission.Visible = true;
            pnlInsert.Visible = true;
            tblInsert.Visible = false;
            lbtExp2.Visible = false;
            lbtClo2.Visible = false;
            LoadDdlGroups();
        }
        else
        {
            pnlInsert.Visible = false;
            tblInsert.Visible = true;
            lbtExp2.Visible = true;
        }
    }

    private void LoadDdlGroups()
    {
        ddlGroups.Items.Clear();
        SqlDataReader datrGroups = BuGroup.SelectAllGroups();
        int i = 0;
        while (datrGroups.Read())
        {
            if (i == 0)
            {
                ddlGroups.Items.Add(LoadSLMF("SLMF_GroupA", "SelectAGroup"));
                ddlGroups.Items[i].Value = "-1";
            }
            i++;
            ddlGroups.Items.Add(datrGroups["GroupName"].ToString());
            ddlGroups.Items[i].Value = datrGroups["GroupId"].ToString();
        }
        if (datrGroups.IsClosed == false)
        {
            datrGroups.Close();
            datrGroups.Dispose();
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
        pnlSetPermission.Visible = false;
    }
    protected void grvForums_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvForums.SelectedIndex = -1;
        grvGroups.SelectedIndex = -1;
        grvForums.PageIndex = e.NewPageIndex;
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
        pnlSetPermission.Visible = false;
        pnlGroups.Visible = false;
    }
    protected void grvForums_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlGroups.Visible = true;
        pnlSetPermission.Visible = false;
        grvGroups.SelectedIndex = -1;
        GridViewRow row = grvForums.SelectedRow;
        int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
        LoadGrvGroups(intFrmId);
    }
    protected void grvGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSetPermission.Visible = true;
        GridViewRow row = grvGroups.SelectedRow;
        int intGrpId = int.Parse(grvGroups.DataKeys[row.RowIndex].Value.ToString());
        GridViewRow row2 = grvForums.SelectedRow;
        int intFrmId = int.Parse(grvForums.DataKeys[row2.RowIndex].Value.ToString());
        EnGroup grp = new EnGroup();
        EnForum frm = new EnForum();
        grp.GroupId = intGrpId;
        frm.ForumId = intFrmId;
        LoadDetailAuthor(grp, frm);
    }

    private int UpdateGrpFrmAuthor(int intTypeId, int intDefault)
    {
        EnMemberAuthorize mbr = new EnMemberAuthorize();
        int intGrpId = 0;
        if (intTypeId == 1)
        {
            GridViewRow row = grvGroups.SelectedRow;
            intGrpId = int.Parse(grvGroups.DataKeys[row.RowIndex].Value.ToString());
        }
        else if (ddlGroups.SelectedValue.ToString() != "-1")
        {
            intGrpId = int.Parse(ddlGroups.SelectedValue.ToString());
        }
        GridViewRow row2 = grvForums.SelectedRow;
        int intFrmId = int.Parse(grvForums.DataKeys[row2.RowIndex].Value.ToString());
        mbr.GroupId = intGrpId;
        mbr.ForumId = intFrmId;
        mbr.ApproveMsg = false;
        if (rbtApproAuthorY.Checked)
        {
            mbr.ApproveMsg = true;
        }
        mbr.IsApproved = false;
        if (rbtApproveN.Checked)
        {
            mbr.IsApproved = true;
        }
        mbr.DeleteMsgAuthor = false;
        if (rbtDelMsgY.Checked)
        {
            mbr.DeleteMsgAuthor = true;
        }
        mbr.DeleteTopicAuthor = false;
        if (rbtDelTopicY.Checked)
        {
            mbr.DeleteTopicAuthor = true;
        }
        mbr.EditMsgAuthor = false;
        if (rbtEditY.Checked)
        {
            mbr.EditMsgAuthor = true;
        }
        mbr.SendEm = false;
        if (rbtEmY.Checked)
        {
            mbr.SendEm = true;
        }
        mbr.ForwardMsgAuthor = false;
        if (rbtForwardY.Checked)
        {
            mbr.ForwardMsgAuthor = true;
        }
        mbr.LockTopicAuthor = false;
        if (rbtLockY.Checked)
        {
            mbr.LockTopicAuthor = true;
        }
        mbr.MoveTopicAuthor = false;
        if (rbtMoveY.Checked)
        {
            mbr.MoveTopicAuthor = true;
        }
        mbr.SendPm = false;
        if (rbtPmY.Checked)
        {
            mbr.SendPm = true;
        }
        mbr.PollAuthor = false;
        if (rbtPollY.Checked)
        {
            mbr.PollAuthor = true;
        }
        mbr.PostAuthor = false;
        if (rbtPostY.Checked)
        {
            mbr.PostAuthor = true;
        }
        mbr.QuoteMsgAuthor = false;
        if (rbtQuoteY.Checked)
        {
            mbr.QuoteMsgAuthor = true;
        }
        mbr.RatingAuthor = false;
        if (rbtRateY.Checked)
        {
            mbr.RatingAuthor = true;
        }
        mbr.ReplyAuthor = false;
        if (rbtReplyY.Checked)
        {
            mbr.ReplyAuthor = true;
        }
        mbr.ReportAuthor = false;
        if (rbtRptAuthorY.Checked)
        {
            mbr.ReportAuthor = true;
        }
        mbr.StickTopicAuthor = false;
        if (rbtStickyY.Checked)
        {
            mbr.StickTopicAuthor = true;
        }
        mbr.UnLockTopic = false;
        if (rbtUnLockY.Checked)
        {
            mbr.UnLockTopic = true;
        }
        mbr.UploadAuthor = false;
        if (rbtUploadY.Checked)
        {
            mbr.UploadAuthor = true;
        }
        mbr.ViewIp = false;
        if (rbtViewIpY.Checked)
        {
            mbr.ViewIp = true;
        }
        mbr.ViewProfile = false;
        if (rbtViewProY.Checked)
        {
            mbr.ViewProfile = true;
        }
        mbr.VoteAuthor = false;
        if (rbtVoteY.Checked)
        {
            mbr.VoteAuthor = true;
        }
        mbr.ThankAuthor = false;
        if (rbtThankY.Checked)
        {
            mbr.ThankAuthor = true;
        }
        mbr.SizeAuthor = 0;
        if (txtSizeUpload.Text != "")
        {
            mbr.SizeAuthor = int.Parse(txtSizeUpload.Text.ToString());
        }
        return BuForum.UpdateGrpFrmAuthor(mbr, intTypeId, intDefault);
    }

    private void LoadDetailAuthor(EnGroup grp, EnForum frm)
    {
        EnMemberAuthorize mbr = new EnMemberAuthorize();
        mbr = BuForum.SelectGrpFrmAuthor(grp, frm);
        if (mbr.ApproveMsg)
        {
            rbtApproAuthorY.Checked = true;
            rbtApproAuthorN.Checked = false;
        }
        else
        {
            rbtApproAuthorN.Checked = true;
            rbtApproAuthorY.Checked = false;
        }
        if (mbr.IsApproved)
        {
            rbtApproveN.Checked = true;
            rbtApproveY.Checked = false;
        }
        else
        {
            rbtApproveY.Checked = true;
            rbtApproveN.Checked = false;
        }
        if (mbr.DeleteMsgAuthor)
        {
            rbtDelMsgY.Checked = true;
            rbtDelMsgN.Checked = false;
        }
        else
        {
            rbtDelMsgN.Checked = true;
            rbtDelMsgY.Checked = false;
        }
        if (mbr.DeleteTopicAuthor)
        {
            rbtDelTopicY.Checked = true;
            rbtDelTopicN.Checked = false;
        }
        else
        {
            rbtDelTopicN.Checked = true;
            rbtDelTopicY.Checked = false;
        }
        if (mbr.EditMsgAuthor)
        {
            rbtEditY.Checked = true;
            rbtEditN.Checked = false;
        }
        else
        {
            rbtEditN.Checked = true;
            rbtEditY.Checked = false;
        }
        if (mbr.SendEm)
        {
            rbtEmY.Checked = true;
            rbtEmN.Checked = false;
        }
        else
        {
            rbtEmN.Checked = true;
            rbtEmY.Checked = false;
        }
        if (mbr.ForwardMsgAuthor)
        {
            rbtForwardY.Checked = true;
            rbtForwardN.Checked = false;
        }
        else
        {
            rbtForwardN.Checked = true;
            rbtForwardY.Checked = false;
        }
        if (mbr.LockTopicAuthor)
        {
            rbtLockY.Checked = true;
            rbtLockN.Checked = false;
        }
        else
        {
            rbtLockN.Checked = true;
            rbtLockY.Checked = false;
        }
        if (mbr.MoveTopicAuthor)
        {
            rbtMoveY.Checked = true;
            rbtMoveN.Checked = false;
        }
        else
        {
            rbtMoveN.Checked = true;
            rbtMoveY.Checked = false;
        }
        if (mbr.SendPm)
        {
            rbtPmY.Checked = true;
            rbtPmN.Checked = false;
        }
        else
        {
            rbtPmN.Checked = true;
            rbtPmY.Checked = false;
        }
        if (mbr.PollAuthor)
        {
            rbtPollY.Checked = true;
            rbtPollN.Checked = false;
        }
        else
        {
            rbtPollN.Checked = true;
            rbtPollY.Checked = false;
        }
        if (mbr.PostAuthor)
        {
            rbtPostY.Checked = true;
            rbtPostN.Checked = false;
        }
        else
        {
            rbtPostN.Checked = true;
            rbtPostY.Checked = false;
        }
        if (mbr.QuoteMsgAuthor)
        {
            rbtQuoteY.Checked = true;
            rbtQuoteN.Checked = false;
        }
        else
        {
            rbtQuoteN.Checked = true;
            rbtQuoteY.Checked = false;
        }
        if (mbr.RatingAuthor)
        {
            rbtRateY.Checked = true;
            rbtRateN.Checked = false;
        }
        else
        {
            rbtRateN.Checked = true;
            rbtRateY.Checked = false;
        }
        if (mbr.ReplyAuthor)
        {
            rbtReplyY.Checked = true;
            rbtReplyN.Checked = false;
        }
        else
        {
            rbtReplyN.Checked = true;
            rbtReplyY.Checked = false;
        }
        if (mbr.ReportAuthor)
        {
            rbtRptAuthorY.Checked = true;
            rbtRptAuthorN.Checked = false;
        }
        else
        {
            rbtRptAuthorN.Checked = true;
            rbtRptAuthorY.Checked = false;
        }
        if (mbr.StickTopicAuthor)
        {
            rbtStickyY.Checked = true;
            rbtStickyN.Checked = false;
        }
        else
        {
            rbtStickyN.Checked = true;
            rbtStickyY.Checked = false;
        }
        if (mbr.UnLockTopic)
        {
            rbtUnLockY.Checked = true;
            rbtUnLockN.Checked = false;
        }
        else
        {
            rbtUnLockN.Checked = true;
            rbtUnLockY.Checked = false;
        }
        if (mbr.UploadAuthor)
        {
            rbtUploadY.Checked = true;
            rbtUploadN.Checked = false;
        }
        else
        {
            rbtUploadN.Checked = true;
            rbtUploadY.Checked = false;
        }
        if (mbr.ViewIp)
        {
            rbtViewIpY.Checked = true;
            rbtViewIpN.Checked = false;
        }
        else
        {
            rbtViewIpN.Checked = true;
            rbtViewIpY.Checked = false;
        }
        if (mbr.ViewProfile)
        {
            rbtViewProY.Checked = true;
            rbtViewProN.Checked = false;
        }
        else
        {
            rbtViewProN.Checked = true;
            rbtViewProY.Checked = false;
        }
        if (mbr.VoteAuthor)
        {
            rbtVoteY.Checked = true;
            rbtVoteN.Checked = false;
        }
        else
        {
            rbtVoteN.Checked = true;
            rbtVoteY.Checked = false;
        }
        if (mbr.ThankAuthor)
        {
            rbtThankY.Checked = true;
            rbtThankN.Checked = false;
        }
        else
        {
            rbtThankN.Checked = true;
            rbtThankY.Checked = false;
        }
        txtSizeUpload.Text = mbr.SizeAuthor.ToString();
    }

    protected void lbtExp2_Click(object sender, EventArgs e)
    {
        pnlInsert.Visible = true;
        lbtClo2.Visible = true;
        lbtExp2.Visible = false;
        tblInsert.Visible = false;
        lblReportFrmSpn.Text = "";
        LoadDdlGroups();
    }
    protected void lbtClo2_Click(object sender, EventArgs e)
    {
        pnlInsert.Visible = false;
        lbtClo2.Visible = false;
        lbtExp2.Visible = true;
        tblInsert.Visible = true;
    }
    protected void btnUpdateSet_Click(object sender, EventArgs e)
    {
        UpdateGrpFrmAuthor(1,0);
        lblPermission.Text = LoadSLMF("PermissionGrpFrmA", "UpdatePermissionSuccess");
    }
    protected void btnInsGroups_Click(object sender, EventArgs e)
    {
        int intId = 0;
        if (Default4All.Checked)
        {
            intId = UpdateGrpFrmAuthor(2,1);
        }
        else
        {
            intId = UpdateGrpFrmAuthor(2,0);
        }
        if (intId == -1)
        {
            lblReportFrmSpn.Text = LoadSLMF("PermissionGrpFrmA", "InsertPermissionFailed");
        }
        else
        {
            //lblReportFrmSpn.Text = LoadSLMF("PermissionGrpFrmA", "InsertPermissionSuccess");
            grvGroups.SelectedIndex = -1;
            pnlSetPermission.Visible = false;
            GridViewRow row = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
            LoadGrvGroups(intFrmId);
        }
    }
    protected void grvGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvForums.SelectedValue != null)
        {
            grvGroups.SelectedIndex = -1;
            pnlSetPermission.Visible = false;
            GridViewRow row = grvForums.SelectedRow;
            int intFrmId = int.Parse(grvForums.DataKeys[row.RowIndex].Value.ToString());
            int intGrpId = int.Parse(grvGroups.DataKeys[e.RowIndex]["GroupId"].ToString());
            int intFrmId2 = int.Parse(grvGroups.DataKeys[e.RowIndex]["ForumId"].ToString());
            EnMemberAuthorize mbr = new EnMemberAuthorize();
            mbr.GroupId = intGrpId;
            mbr.ForumId = intFrmId2;
            BuForum.DeleteGrpFrmAuthor(mbr);
            LoadGrvGroups(intFrmId);
        }
    }
}
