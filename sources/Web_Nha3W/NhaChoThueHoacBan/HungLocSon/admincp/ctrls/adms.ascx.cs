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
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using HungLocSon.UHLS;

public partial class admincp_ctrls_adms : System.Web.UI.UserControl
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
        SqlDataReader l = BModers.AAdmins();
        int i = -1;
        //j = 0;
        while (l.Read())
        {
            if (i == -1)
            {
                ddlModers.Items.Add("Tất cả chức năng");
                ddlModers.Items[i + 1].Value = "-1";
                i++;
                ddlModers.Items.Add("---------------");
                ddlModers.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlModers.Items.Add(l[2].ToString());
            ddlModers.Items[i].Value = l[0].ToString();
            i++;
        }
        if (l.IsClosed == false)
        {
            l.Close();
            l.Dispose();
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        Permiss(txtUserName.Value.ToString());
        gCities.SelectedIndex = -1;
        gCities2.Visible = false;
    }

    public string AnnounceTime(DateTime strInput)
    {
        GUHLS unew = new GUHLS();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        Permiss(txtUserName.Value.ToString());
    }

    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
        gCities2.Visible = true;
        EMember m = new EMember(i);
        gCities2.DataSource = BModers.AAdmins2(m);
        gCities2.DataBind();
    }

    protected void gCities2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        if (row != null)
        {
            int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
            int j = int.Parse(gCities2.DataKeys[e.RowIndex].Values[1].ToString());
            BModers.EAdmns(i,j);
            EMember m = new EMember(i);
            gCities2.DataSource = BModers.AAdmins2(m);
            gCities2.DataBind();
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int j = int.Parse(ddlModers.SelectedValue.ToString());
        if (row != null && j != 0)
        {
            int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
            BModers.IAdmns(i, j);
            EMember m = new EMember(i);
            gCities2.DataSource = BModers.AAdmins2(m);
            gCities2.DataBind();
        }
    }
}
