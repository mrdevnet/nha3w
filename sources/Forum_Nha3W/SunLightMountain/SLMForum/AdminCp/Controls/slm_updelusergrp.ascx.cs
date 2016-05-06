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

public partial class AdminCp_Controls_slm_updelusergrp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Text = LoadSLMF("SLMF_UserA", "Find");
            EnMember mbr = new EnMember();
            mbr.FullName = "";
            SearchUser(mbr);
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

    private void SearchUser(EnMember mbr)
    {
        grvUsers.DataSource = BuMember.SelectUserGroup(mbr);
        grvUsers.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        LoadUserGroup();
        pnlGroups.Visible = false;
    }

    private void LoadUserGroup()
    {
        EnMember mbr = new EnMember();
        mbr.FullName = txtUserName.Text.ToString();
        SearchUser(mbr);
    }

    private void LoadGroupDetails(int intId)
    {
        EnMember mbr = new EnMember();
        mbr.MemberId = intId;
        grvGroups.DataSource = BuMember.SelectGrpDetails(mbr);
        grvGroups.DataBind();
    }

    private void LoadDdlGroups()
    {
        SqlDataReader datrGroups = BuGroup.SelectAllGroups();
        int i = 0;
        while (datrGroups.Read())
        {
            if (i == 0)
            {
                ddlGroups.Items.Add(LoadSLMF("SLMF_GroupA","SelectAGroup"));
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

    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsers.SelectedIndex = -1;
        grvUsers.PageIndex = e.NewPageIndex;
        LoadUserGroup();
    }
    protected void grvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvUsers.SelectedRow;
        pnlGroups.Visible = true;
        int intMemberId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
        LoadGroupDetails(intMemberId);
    }
    protected void lbtExp2_Click(object sender, EventArgs e)
    {
        ddlGroups.Items.Clear();
        LoadDdlGroups();
        btnInsGroups.Text = LoadSLMF("SLMF_GroupA", "AddGrp4Mbr");
        trInsertFrmSpn.Visible = true;
        trInsertFrmSpn2.Visible = true;
        lbtClo2.Visible = true;
        lbtExp2.Visible = false;
    }
    protected void lbtClo2_Click(object sender, EventArgs e)
    {
        trInsertFrmSpn.Visible = false;
        trInsertFrmSpn2.Visible = false;
        lbtClo2.Visible = false;
        lbtExp2.Visible = true;
    }
    protected void btnInsGroups_Click(object sender, EventArgs e)
    {
        if (ddlGroups.SelectedValue.ToString() != "-1")
        {
            EnMember mbr = new EnMember();
            GridViewRow row = grvUsers.SelectedRow;
            int intMemberId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
            mbr.MemberId = intMemberId;
            EnGroup grp = new EnGroup();
            grp.GroupId = int.Parse(ddlGroups.SelectedValue.ToString());
            int intResult = BuGroup.InsertGroupsMembers(mbr, grp);
            if (intResult == 1)
            {
                lblReportFrmSpn.Text = LoadSLMF("SLMF_GroupA", "AddGrp4MbrFailed");
            }
            else
            {
                lblReportFrmSpn.Text = LoadSLMF("SLMF_GroupA", "AddGrp4MbrSuccess");
                LoadGroupDetails(intMemberId);
            }
        }
    }
    
    protected void grvGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvUsers.SelectedValue != null)
        {
            GridViewRow row = grvUsers.SelectedRow;
            int intMbrId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
            EnMember mbr = new EnMember();
            int intMbrId2 = int.Parse(grvGroups.DataKeys[e.RowIndex]["MemberId"].ToString());
            int intGrpId = int.Parse(grvGroups.DataKeys[e.RowIndex]["GroupId"].ToString());
            EnGroup grp = new EnGroup();
            grp.GroupId = intGrpId;
            mbr.MemberId = intMbrId2;
            BuGroup.DeleteMbrGrp(mbr, grp);
            LoadGroupDetails(intMbrId);
        }
    }
    protected void grvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intMemberId = int.Parse(grvUsers.DataKeys[e.RowIndex].Value.ToString());
        EnMember mbr = new EnMember();
        mbr.MemberId = intMemberId;
        BuMember.DeleteMember(mbr);
        LoadUserGroup();
        pnlGroups.Visible = false;
    }
}
