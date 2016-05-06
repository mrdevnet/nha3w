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

public partial class admincp_ctrls_wards : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cities();
            Wards();
        }
    }

    private void Wards()
    {
        ECities c = new ECities();
        c.CityId = int.Parse(ddlCities.SelectedValue.ToString());
        gCities.DataSource = BWards.AWards(c);
        gCities.DataBind();
    }

    private void Wards2(EWards p)
    {
        gCities.DataSource = BWards.AWards2(p);
        gCities.DataBind();
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
                ddlCities.Items.Add("Tỉnh/Thành phố");
                ddlCities.Items[i + 1].Value = "-1";
                i++;
                ddlCities.Items.Add("---------------");
                ddlCities.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlCities.Items.Add(y[j].CityName);
            ddlCities.Items[i].Value = y[j].CityId.ToString();
            i++;
            j++;
        }
    }

    private void districts(EDistricts d)
    {
        ddlDistricts.Items.Clear();
        List<EDistricts> y = new List<EDistricts>();
        y = BDistricts.Districts(d);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                ddlDistricts.Items.Add("Quận/Huyện");
                ddlDistricts.Items[i + 1].Value = "-1";
                i++;
                ddlDistricts.Items.Add("-----------");
                ddlDistricts.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlDistricts.Items.Add(y[j].DistrictName);
            ddlDistricts.Items[i].Value = y[j].DistrictId.ToString();
            i++;
            j++;
        }
    }
    protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(ddlCities.SelectedValue);
        if (i > 0)
        {
            EDistricts dt = new EDistricts();
            dt.CityId = i;
            districts(dt);
            Wards();
        }
        else
        {
            Wards();
            ddlDistricts.Items.Clear();
        }
    }
    protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
    {
        load2();
    }

    private void load2()
    {
        int i = int.Parse(ddlDistricts.SelectedValue);
        if (i > 0)
        {
            EWards p = new EWards();
            p.DistrictId = i;
            Wards2(p);
        }
        else
        {
            Wards();
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0" && ddlDistricts.SelectedValue != "-1"
            && ddlDistricts.SelectedValue != "0" && txtWardName.Value.ToString() != "")
        {
            EWards p = new EWards();
            p.WardName = txtWardName.Value.ToString().Trim();
            p.DistrictId = int.Parse(ddlDistricts.SelectedValue.ToString());
            BWards.IWards(p);
            txtWardName.Value = "";
            Wards2(p);
        }
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EWards t = new EWards();
        t.WardId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BWards.EWards(t);
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load2();
        }
        else
        {
            Wards();
        }
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load2();
        }
        else
        {
            Wards();
        }
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load2();
        }
        else
        {
            Wards();
        }
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EWards t = new EWards();
        t.WardId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox txtName = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtWardName2");
        t.WardName = txtName.Text.ToString();
        DropDownList ddlC = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlDistricts2");
        t.DistrictId = int.Parse(ddlC.SelectedValue);
        BWards.UWards(t);
        gCities.EditIndex = -1;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load2();
        }
        else
        {
            Wards();
        }
    }
    protected void gCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList district = (DropDownList)e.Row.FindControl("ddlDistricts2");
            if (district != null)
            {
                EDistricts t = new EDistricts();
                t.CityId = int.Parse(gCities.DataKeys[e.Row.RowIndex].Values[2].ToString());
                district.DataSource = BDistricts.ADistricts2(t);
                district.DataBind();
                district.SelectedValue = gCities.DataKeys[e.Row.RowIndex].Values[1].ToString();
            }
        }
    }
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load2();
        }
        else
        {
            Wards();
        }
    }
}
