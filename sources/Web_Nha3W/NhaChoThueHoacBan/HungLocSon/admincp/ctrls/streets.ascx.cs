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

public partial class admincp_ctrls_streets : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cities();
            Streets();
        }
    }

    private void Streets()
    {
        ECities c = new ECities();
        c.CityId = int.Parse(ddlCities.SelectedValue.ToString());
        gCities.DataSource = BStreets.AStreets(c);
        gCities.DataBind();
    }

    private void Streets2(EStreets p)
    {
        gCities.DataSource = BStreets.AStreets2(p);
        gCities.DataBind();
    }

    private void Streets3(EStreets p)
    {
        gCities.DataSource = BStreets.AStreets3(p);
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

    private void Wards(EWards w)
    {
        ddlWards.Items.Clear();
        List<EWards> y = new List<EWards>();
        y = BWards.Wards(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                ddlWards.Items.Add("Phường/Xã");
                ddlWards.Items[i + 1].Value = "-1";
                i++;
                ddlWards.Items.Add("-----------");
                ddlWards.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlWards.Items.Add(y[j].WardName);
            ddlWards.Items[i].Value = y[j].WardId.ToString();
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
            Streets();
        }
        else
        {
            Streets();
            ddlDistricts.Items.Clear();
        }
        ddlWards.Items.Clear();
    }
    protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistricts.SelectedValue != null && ddlDistricts.SelectedValue != "")
        {
            int i = int.Parse(ddlDistricts.SelectedValue);
            if (i > 0)
            {
                EWards dt = new EWards();
                dt.DistrictId = i;
                Wards(dt);
                load2();
            }
            else
            {
                load2();
                ddlWards.Items.Clear();
            }
        }
    }

    private void load2()
    {
        if (ddlDistricts.SelectedValue != null && ddlDistricts.SelectedValue != "")
        {
            int i = int.Parse(ddlDistricts.SelectedValue);
            if (i > 0)
            {
                EStreets p = new EStreets();
                p.DistrictId = i;
                Streets2(p);
            }
            else
            {
                Streets();
            }
        }
    }

    private void load3()
    {
        int i = 0;
        if (ddlWards.SelectedValue != null && ddlWards.SelectedValue != "")
        {
            i = int.Parse(ddlWards.SelectedValue);
            if (i > 0)
            {
                EStreets p = new EStreets();
                p.WardId = i;
                Streets3(p);
            }
        }
        else if (ddlDistricts.SelectedValue != null && ddlDistricts.SelectedValue != "")
        {
            //i = int.Parse(ddlDistricts.SelectedValue);
            //EStreets p = new EStreets();
            //p.DistrictId = i;
            //Streets2(p);
            load2();
        }
    }

    protected void ddlWards_SelectedIndexChanged(object sender, EventArgs e)
    {
        load3();
        //int i = int.Parse(ddlWards.SelectedValue);
        //if (i > 0)
        //{
        //    load3();
        //}
        //else
        //{
        //    load3();
        //}
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0" && ddlDistricts.SelectedValue != "-1"
            && ddlDistricts.SelectedValue != "0" && ddlWards.SelectedValue != "-1" && ddlWards.SelectedValue != "0" 
            && txtStreetName.Value.ToString() != "")
        {
            EStreets p = new EStreets();
            p.Name = txtStreetName.Value.ToString().Trim();
            p.DistrictId = int.Parse(ddlDistricts.SelectedValue.ToString());
            p.WardId = int.Parse(ddlWards.SelectedValue.ToString());
            BStreets.IStreets(p);
            txtStreetName.Value = "";
            Streets3(p);
        }
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EStreets t = new EStreets();
        t.StreetId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BStreets.EStreets(t);
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load3();
        }
        else
        {
            Streets();
        }
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EStreets t = new EStreets();
        t.StreetId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox txtName = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtStreetName2");
        t.Name = txtName.Text.ToString();
        BStreets.UStreets(t);
        gCities.EditIndex = -1;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load3();
        }
        else
        {
            Streets();
        }
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load3();
        }
        else
        {
            Streets();
        }
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load3();
        }
        else
        {
            Streets();
        }
    }
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        if (ddlCities.SelectedValue != "-1" && ddlCities.SelectedValue != "0")
        {
            load3();
        }
        else
        {
            Streets();
        }
    }
}
