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

public partial class admincp_ctrls_moders : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Moders();
        }
    }

    private void Moders()
    {
        gCities.DataSource = BModers.AModers();
        gCities.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        EModers g = new EModers();
        g.ModerName = txtModerName.Value.ToString();
        BModers.IModer(g);
        Moders();
    }


    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        Moders();
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EModers t = new EModers();
        t.ModerId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox grpname = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtEModerName");
        t.ModerName = grpname.Text.ToString();
        BModers.UModers(t);
        gCities.EditIndex = -1;
        Moders();
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EModers t = new EModers();
        t.ModerId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BModers.EGroups(t);
        Moders();
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        Moders();
    }
    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Value.ToString());
        EModers t = new EModers(i);
        EModerAuthors a = new EModerAuthors();
        a = BModerAuthors.ModerAuthors(t);
        if (a.Edit) { rbt1edity.Checked = true; rbt1editn.Checked = false; }
        else { rbt1edity.Checked = false; rbt1editn.Checked = true; }
        if (a.Del) { rbt2dely.Checked = true; rbt2deln.Checked = false; }
        else { rbt2dely.Checked = false; rbt2deln.Checked = true; }
        if (a.Approve) { rbt3Approy.Checked = true; rbt3Appron.Checked = false; }
        else { rbt3Approy.Checked = false; rbt3Appron.Checked = true; }
        if (a.Vip) { rbt5Vipy.Checked = true; rbt5Vipn.Checked = false; }
        else { rbt5Vipy.Checked = false; rbt5Vipn.Checked = true; }
        if (a.Silver) { rbt6Silvery.Checked = true; rbt6Silvern.Checked = false; }
        else { rbt6Silvery.Checked = false; rbt6Silvern.Checked = true; }
        if (a.Renew) { rbt7Renewy.Checked = true; rbt7Renewn.Checked = false; }
        else { rbt7Renewy.Checked = false; rbt7Renewn.Checked = true; }
        if (a.Ups) { rbt8Upsy.Checked = true; rbt8Upsn.Checked = false; }
        else { rbt8Upsy.Checked = false; rbt8Upsn.Checked = true; }

    }
    protected void Update_Click(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Value.ToString());
        EModerAuthors a = new EModerAuthors();
        a.ModerId = i;
        if (rbt1edity.Checked) a.Edit = true;
        else a.Edit = false;
        if (rbt2dely.Checked) a.Del = true;
        else a.Del = false;
        if (rbt3Approy.Checked) a.Approve = true;
        else a.Approve = false;
        if (rbt5Vipy.Checked) a.Vip = true;
        else a.Vip = false;
        if (rbt6Silvery.Checked) a.Silver = true;
        else a.Silver = false;
        if (rbt7Renewy.Checked) a.Renew = true;
        else a.Renew = false;
        if (rbt8Upsy.Checked) a.Ups = true;
        else a.Ups = false;
        BModerAuthors.UModerAuthors(a);
    }
}
