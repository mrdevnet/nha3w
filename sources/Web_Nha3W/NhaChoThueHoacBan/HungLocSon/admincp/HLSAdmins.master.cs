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

public partial class admincp_HLSAdmins : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImReals();
            EMember c = new EMember();
            c.UserName = lk();
            if (BModers.IsAdns(c) <= 0) Response.Redirect("../default.aspx");
            else if (BModers.IsAdns(c) > 0 && Request.QueryString.Count > 0)
            {
                if (Request.Params["idn"] != null && Request.Params["idn"].ToString() != "")
                {
                    if (BModers.IsAuAdns(c, Request.Params["idn"].ToString()) <= 0) Response.Redirect("../default.aspx");
                }
                else Response.Redirect("../default.aspx");
            }
            else Response.Redirect("../default.aspx");
        }
    }

    private string jks()
    {
        HttpCookie ck = new HttpCookie("hlsbraut");
        ck = Request.Cookies["hlsbraut"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    private void ImReals()
    {
        HungLocSon.UHLS.EncryptM m5 = new HungLocSon.UHLS.EncryptM();
        if (m5.Md5Encode(BMember.ShwSeid(lk())) != jks())
        {
            Response.Redirect("../signout.aspx");
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
}
