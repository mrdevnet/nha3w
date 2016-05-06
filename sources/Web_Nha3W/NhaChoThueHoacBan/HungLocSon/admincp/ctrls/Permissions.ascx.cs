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
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using HungLocSon.UHLS;

public partial class admincp_ctrls_Permissions : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Permiss(txtUserName.Value.ToString());
            Moders();
        }
    }

    private void Permiss(string strFull)
    {
        gCities.DataSource = BMember.APermiss(strFull);
        gCities.DataBind();
    }

    private void Moders()
    {
        ddlModers.DataSource = BModers.AModers();
        ddlModers.DataBind();
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        Permiss(txtUserName.Value.ToString());
    }

    public string AnnounceTime(DateTime strInput)
    {
        GUHLS unew = new GUHLS();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        Permiss(txtUserName.Value.ToString());
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        Permiss(txtUserName.Value.ToString());
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EMember t = new EMember();
        EProfile p = new EProfile();
        DropDownList ddlC = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlGroup");
        t.GroupId = int.Parse(ddlC.SelectedValue);
        CheckBox active = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbActiveE");
        t.IsActivated = active.Checked;
        CheckBox login = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbLoginE");
        t.EnableLogin = login.Checked;
        CheckBox block = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbBlockE");
        p.IsBlocked = block.Checked;
        t.MemberId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BMember.UMbrPrs(t, p);
        gCities.EditIndex = -1;
        Permiss(txtUserName.Value.ToString());
    }
    protected void gCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList district = (DropDownList)e.Row.FindControl("ddlGroup");
            if (district != null)
            {
                district.DataSource = BGroups.AGroups();
                district.DataBind();
                district.SelectedValue = gCities.DataKeys[e.Row.RowIndex].Values[1].ToString();
            }
        }
    }
    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
        EMember m = new EMember(i);
        gCities2.DataSource = BModers.AModers2(m);
        gCities2.DataBind();
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        if (row != null)
        {
            int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
            int j = int.Parse(ddlModers.SelectedValue.ToString());
            BModers.UModers2(i, j);
            EMember m = new EMember(i);
            gCities2.DataSource = BModers.AModers2(m);
            gCities2.DataBind();
        }
    }
    protected void gCities2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        if (row != null)
        {
            int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
            BModers.EModers2(i);
            EMember m = new EMember(i);
            gCities2.DataSource = BModers.AModers2(m);
            gCities2.DataBind();
        }
    }
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        Permiss(txtUserName.Value.ToString());
    }
}
