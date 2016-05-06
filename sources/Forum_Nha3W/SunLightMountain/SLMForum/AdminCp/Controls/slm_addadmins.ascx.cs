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

public partial class AdminCp_Controls_slm_addadmins : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSearch.Text = LoadSLMF("SLMF_UserA", "Find");
            btnSet.Text = LoadSLMF("SLMF_Admins", "btnSet");
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

    private void SearchUser(EnMember mbr)
    {
        grvUsers.DataSource = BuMember.SelectUserGroup(mbr);
        grvUsers.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadUserGroup();
        pnlAdmins.Visible = false;
        trAddMenu.Visible = false;
        grvUsers.SelectedIndex = -1;
        pnlAdminGroups.Visible = false;
    }

    private void LoadDataAdmin()
    {
        grvAdmins.DataSource = BuAdminGroup.SelectAdminGroup();
        grvAdmins.DataBind();
    }

    private void LoadGrvUserAdmins(EnAdmin admin)
    {
        grvAdminGrps.DataSource = BuAdminGroup.SelectUserGrps(admin);
        grvAdminGrps.DataBind();
    }

    private void LoadUserGroup()
    {
        EnMember mbr = new EnMember();
        mbr.FullName = txtUserName.Text.ToString();
        SearchUser(mbr);
    }
    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsers.SelectedIndex = -1;
        grvUsers.PageIndex = e.NewPageIndex;
        LoadUserGroup();
        pnlAdmins.Visible = false;
        grvAdmins.SelectedIndex = -1;
        trAddMenu.Visible = false;
        pnlAdminGroups.Visible = false;
    }
    protected void grvAdmins_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (trAddMenu.Visible == false)
        {
            trAddMenu.Visible = true;
        }
    }
    protected void grvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pnlAdmins.Visible == false)
        {
            pnlAdmins.Visible = true;
            LoadDataAdmin();
        }
        grvAdmins.SelectedIndex = -1;
        trAddMenu.Visible = false;
        if (grvUsers.SelectedValue != null)
        {
            GridViewRow row = grvUsers.SelectedRow;
            int intAdminId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
            EnAdmin admin = new EnAdmin();
            admin.AdminId = intAdminId;
            LoadGrvUserAdmins(admin);
            if (pnlAdminGroups.Visible == false && grvAdminGrps.Rows.Count > 0)
            {
                pnlAdminGroups.Visible = true;
            }
            else if (grvAdminGrps.Rows.Count == 0)
            {
                pnlAdminGroups.Visible = false;
            }
        }
    }
    protected void grvAdmins_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdmins.SelectedIndex = -1;
        grvAdmins.PageIndex = e.NewPageIndex;
        LoadDataAdmin();
        trAddMenu.Visible = false;
    }
    protected void grvAdminGrps_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (grvUsers.SelectedValue != null)
        {
            GridViewRow row = grvUsers.SelectedRow;
            int intUserId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
            int intAdminId = int.Parse(grvAdminGrps.DataKeys[e.RowIndex]["AdminId"].ToString());
            int intGroupId = int.Parse(grvAdminGrps.DataKeys[e.RowIndex]["GroupId"].ToString());
            EnAdmin admin = new EnAdmin();
            admin.AdminId = intAdminId;
            admin.GroupId = intGroupId;
            BuAdminGroup.DeleteAdminGrps(admin);
            admin.AdminId = intUserId;
            LoadGrvUserAdmins(admin);
            if (grvAdminGrps.Rows.Count == 0)
            {
                pnlAdminGroups.Visible = false;
            }
        }
    }
    
    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (grvUsers.SelectedValue != null && grvAdmins.SelectedValue != null)
        {
            GridViewRow row = grvUsers.SelectedRow;
            int intUserId = int.Parse(grvUsers.DataKeys[row.RowIndex].Value.ToString());
            GridViewRow row2 = grvAdmins.SelectedRow;
            int intGrpId = int.Parse(grvAdmins.DataKeys[row2.RowIndex].Value.ToString());
            EnAdmin admin = new EnAdmin();
            admin.AdminId = intUserId;
            admin.GroupId = intGrpId;
            BuAdminGroup.InsertAdminGrps(admin);
            LoadGrvUserAdmins(admin);
            if (pnlAdminGroups.Visible == false && grvAdminGrps.Rows.Count > 0)
            {
                pnlAdminGroups.Visible = true;
            }
            else if (grvAdminGrps.Rows.Count ==0)
            {
                pnlAdminGroups.Visible = false;
            }
        }
    }
}
