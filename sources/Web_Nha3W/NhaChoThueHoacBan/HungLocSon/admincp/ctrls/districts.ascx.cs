using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.BHLS;
using HungLocSon.EHLS;

public partial class admincp_ctrls_districts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cities();
            Districts();
        }
    }

    private void cities()
    {
        List<ECities> y = new List<ECities>();
        y = BCities.Cities();
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w4.Items.Add("Tỉnh/Thành phố");
                n3w4.Items[i + 1].Value = "-1";
                i++;
                n3w4.Items.Add("---------------");
                n3w4.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w4.Items.Add(y[j].CityName);
            n3w4.Items[i].Value = y[j].CityId.ToString();
            i++;
            j++;
        }
    }

    private void Districts()
    {
        gCities.DataSource = BDistricts.ADistricts();
        gCities.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (n3w4.SelectedValue != "-1" && n3w4.SelectedValue != "0")
        {
            EDistricts t = new EDistricts();
            t.CityId = int.Parse(n3w4.SelectedValue.ToString());
            t.DistrictName = city.Value.ToString().Trim();
            BDistricts.IDistricts(t);
            Changes();
        }
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EDistricts t = new EDistricts();
        t.DistrictId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BDistricts.EDistricts(t);
        Changes();
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        Changes();
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        Changes();
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EDistricts t = new EDistricts();
        t.DistrictId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        DropDownList ddlC = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlcity");
        t.CityId = int.Parse(ddlC.SelectedValue);
        TextBox txtName = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtDistrictName");
        t.DistrictName = txtName.Text.ToString();
        BDistricts.UDistricts(t);
        gCities.EditIndex = -1;
        Changes();
    }
    protected void gCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList district = (DropDownList)e.Row.FindControl("ddlcity");
            if (district != null)
            {
                district.DataSource = BCities.ACities();
                district.DataBind();
                district.SelectedValue = gCities.DataKeys[e.Row.RowIndex].Values[1].ToString();
            }
        }
    }
    protected void n3w4_SelectedIndexChanged(object sender, EventArgs e)
    {
        Changes();
    }

    private void Changes()
    {
        if (int.Parse(n3w4.SelectedValue) > 0 && n3w4.SelectedValue.ToString() != "" && n3w4.SelectedValue != null)
        {
            EDistricts t = new EDistricts();
            t.CityId = int.Parse(n3w4.SelectedValue.ToString());
            gCities.DataSource = BDistricts.ADistricts2(t);
            gCities.DataBind();
        }
        else
        {
            Districts();
        }
    }

    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        Changes();
    }
}
