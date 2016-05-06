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

public partial class admincp_ctrls_adwlls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Wallets();
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Wallets();
        gCities.SelectedIndex = -1;
    }
    protected void Cost_Click(object sender, EventArgs e)
    {
        string[] submessage = txtWallet.Value.ToString().Split(' ');
        if (submessage[1] != null && submessage[1].ToString() != "" && submessage[0] != null && submessage[0].ToString() != "")
        {
            ETransIn tr = new ETransIn();
            tr.Total = int.Parse(submessage[1].ToString());
            tr.MemberId = submessage[0].ToString();
            tr.IP = HttpContext.Current.Request.UserHostAddress;
            tr.ByMember = lk();
            tr.NumberP = "0903010101";
            tr.TypeId = 1;
            tr.PostId = 0;
            BTransIO.ITransIn(tr);
            Wallets();
        }
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
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        Wallets();
    }

    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtWallet.Visible = true;
        Cost.Visible = true;
        GridViewRow row = gCities.SelectedRow;
        string i = gCities.DataKeys[row.RowIndex].Values[1].ToString();
        txtWallet.Value = i.ToString();
    }
    private void Wallets()
    {
        gCities.DataSource = BMember.AWallets(txtUserName.Value.ToString());
        gCities.DataBind();
    }
    public string AnnounceTime(DateTime strInput)
    {
        GUHLS unew = new GUHLS();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
}
