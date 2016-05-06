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

public partial class admincp_ctrls_cities : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            a();
        }
    }

    private void a()
    {
        gCities.DataSource = BCities.ACities();
        gCities.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (city.Value != "")
        {
            ECities t = new ECities();
            t.CityName = city.Value.ToString().Trim();
            BCities.ICities(t);
            a();
        }
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ECities t = new ECities();
        t.CityId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BCities.ECities(t);
        a();
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        a();
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        a();
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ECities t = new ECities();
        t.CityId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox txtName = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtCity");
        t.CityName = txtName.Text.ToString();
        BCities.UCities(t);
        gCities.EditIndex = -1;
        a();
    }
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        a();
    }
}
