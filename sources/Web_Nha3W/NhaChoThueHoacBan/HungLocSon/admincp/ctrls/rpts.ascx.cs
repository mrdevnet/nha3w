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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class admincp_ctrls_rpts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lds();
        }
    }

    private void lds()
    {
        BServer.Remove("Reports2", true);
        gReports.DataSource = BReports.Reports2();
        gReports.DataBind();
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        EReports p = new EReports();
        p.Title = txtTitle.Value.ToString();
        p.Url = txtUrl.Value.ToString();
        p.UserName = lk();
        if (rdShow.Checked) p.IsShow = true;
        else p.IsShow = false;
        BReports.IRpts(p);
        lds();
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    protected void gReports_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EReports t = new EReports();
        t.RptId = int.Parse(gReports.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox Title = (TextBox)gReports.Rows[e.RowIndex].FindControl("txtTitle");
        t.Title = Title.Text.ToString();
        TextBox Url = (TextBox)gReports.Rows[e.RowIndex].FindControl("txtUrl");
        t.Url = Url.Text.ToString();
        CheckBox Show = (CheckBox)gReports.Rows[e.RowIndex].FindControl("show");
        t.IsShow = Show.Checked;
        t.UserName = lk();
        BReports.URpts(t);
        gReports.EditIndex = -1;
        lds();
    }
    protected void gReports_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gReports.EditIndex = -1;
        lds();
    }
    protected void gReports_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gReports.EditIndex = e.NewEditIndex;
        lds();
    }
    

    protected void gReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gReports.SelectedIndex = -1;
        gReports.PageIndex = e.NewPageIndex;
        lds();
    }
}
