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

public partial class AdminCp_Controls_slm_searchusers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlGroups.Attributes.Add("onchange","GetSlmEnc2()");
        if (!IsPostBack)
        {
            btnSave.Text = LoadSLMF("SLMF_UserA", "Find");
            rbtUserName.Text = LoadSLMF("SLMF_UserA", "SearchUser");
            rbtFullName.Text = LoadSLMF("SLMF_UserA", "SearchFull");
            rbtEmail.Text = LoadSLMF("SLMF_UserA", "SearchEmail");
            rbtIsActivated.Text = LoadSLMF("SLMF_UserA", "SearchActivated");
            rbtIsLogin.Text = LoadSLMF("SLMF_UserA", "SearchLogin");
            rbtIsBlock.Text = LoadSLMF("SLMF_UserA", "SearchBlock");
            LoadGroups();
            EnMember mbr = new EnMember();
            mbr.UserName = "";
            mbr.FullName = "";
            mbr.Email = "";
            EnGroup grp = new EnGroup();
            grp.GroupId = int.Parse(ddlGroups.SelectedValue.ToString());
            int intTypeId = 0;
            SearchUser(mbr, grp, intTypeId);
            Session["SearchUserType"] = "1";
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGroups()
    {
        int i = 0;
        SqlDataReader rpt = BuGroup.SelectAllGroups();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlGroups.Items.Add(LoadSLMF("SLMF_UserA", "AllGroups"));
                ddlGroups.Items[i].Value = "-1";
                i++;
            }
            ddlGroups.Items.Add(rpt["GroupName"].ToString());
            ddlGroups.Items[i].Value = rpt["GroupId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EnMember mbr = new EnMember();
        mbr.UserName = "";
        mbr.FullName = "";
        mbr.Email = "";
        EnGroup grp = new EnGroup();
        grp.GroupId = int.Parse(ddlGroups.SelectedValue.ToString());
        int intTypeId = 0;
        if (rbtUserName.Checked)
        {
            mbr.UserName = txtUserName.Text.ToString();
            intTypeId = 1;
        }
        else if (rbtFullName.Checked)
        {
            mbr.FullName = txtUserName.Text.ToString();
            intTypeId = 2;
        }
        else if (rbtEmail.Checked)
        {
            mbr.Email = txtUserName.Text.ToString();
            intTypeId = 3;
        }
        else if (rbtIsActivated.Checked)
        {
            intTypeId = 4;
        }
        else if (rbtIsLogin.Checked)
        {
            intTypeId = 5;
        }
        else
        {
            intTypeId = 6;
        }
        SearchUser(mbr, grp, intTypeId);
        Session["SearchUserType"] = "2";
    }

    private void SearchUser(EnMember mbr, EnGroup grp, int intTypeId)
    {
        grvUsers.DataSource = BuMember.SelectSearchUser(mbr, grp, intTypeId);
        grvUsers.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        EnMember mbr = new EnMember();
        mbr.UserName = "";
        mbr.FullName = "";
        mbr.Email = "";
        EnGroup grp = new EnGroup();
        grp.GroupId = int.Parse(ddlGroups.SelectedValue.ToString());
        int intTypeId = 0;
        if (grp.GroupId != -1)
        {
            intTypeId = 7;
        }
        SearchUser(mbr, grp, intTypeId);
        Session["SearchUserType"] = "3";
    }
    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["SearchUserType"] != null)
        {
            grvUsers.SelectedIndex = -1;
            grvUsers.PageIndex = e.NewPageIndex;
            LoadUserAgain();
        }
    }

    private void LoadUserAgain()
    {
        EnMember mbr = new EnMember();
        mbr.UserName = "";
        mbr.FullName = "";
        mbr.Email = "";
        EnGroup grp = new EnGroup();
        int intTypeId = 0;
        grp.GroupId = int.Parse(ddlGroups.SelectedValue.ToString());
        if (Session["SearchUserType"].ToString() == "2")
        {
            if (rbtUserName.Checked)
            {
                mbr.UserName = txtUserName.Text.ToString();
                intTypeId = 1;
            }
            else if (rbtFullName.Checked)
            {
                mbr.FullName = txtUserName.Text.ToString();
                intTypeId = 2;
            }
            else if (rbtEmail.Checked)
            {
                mbr.Email = txtUserName.Text.ToString();
                intTypeId = 3;
            }
            else if (rbtIsActivated.Checked)
            {
                intTypeId = 4;
            }
            else if (rbtIsLogin.Checked)
            {
                intTypeId = 5;
            }
            else
            {
                intTypeId = 6;
            }
        }
        else if (Session["SearchUserType"].ToString() == "3")
        {
            if (grp.GroupId != -1)
            {
                intTypeId = 7;
            }
        }
        SearchUser(mbr, grp, intTypeId);
    }
    protected void grvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intMemberId = int.Parse(grvUsers.DataKeys[e.RowIndex].Value.ToString());
        EnMember mbr = new EnMember();
        mbr.MemberId = intMemberId;
        BuMember.DeleteMember(mbr);
        LoadUserAgain();
    }
}
