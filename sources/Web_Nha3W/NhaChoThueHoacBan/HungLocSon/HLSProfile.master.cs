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

public partial class HLSProfile : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ana();
            if (lk() == "")
            {
                Response.Redirect("login.aspx");
            }
            ImReals();
            if (Request.Params["pm"] != null && Request.Params["pm"].ToString() != "")
            {
                bgpm.Attributes.Add("class", "mnuicl");
                bgpr.Attributes.Add("class", "mnuis");
            }
            else if (Request.Params["em"] != null && Request.Params["em"].ToString() != "")
            {
                bgem.Attributes.Add("class", "mnuicl");
                bgpr.Attributes.Add("class", "mnuis");
            }
            else bgpr.Attributes.Add("class", "mnuicl");
        }
    }

    private void ana()
    {
        HungLocSon.EHLS.EAnas a = new HungLocSon.EHLS.EAnas();
        HungLocSon.EHLS.EMember m = new HungLocSon.EHLS.EMember();
        if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] != null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.CY = int.Parse(Request.Params["y"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] != null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.CL = int.Parse(Request.Params["l"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] != null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.SE = int.Parse(Request.Params["t"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] != null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.WA = int.Parse(Request.Params["a"].ToString());
        }
        //else if (Request.Params["m"] != null && Request.Params["c"] == null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        //{
        //    a.MI = int.Parse(Request.Params["m"].ToString());
        //}
        a.UR = lk();
        a.IP = HttpContext.Current.Request.UserHostAddress;
        a.SD = HttpContext.Current.Session.SessionID;
        BAnas.IAnas(a);
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

    private string pwc()
    {
        HttpCookie ck = new HttpCookie("hlsbrocr");
        ck = Request.Cookies["hlsbrocr"];
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
        if (m5.Md5Encode(BMember.APwds(lk())) != pwc())
        {
            Response.Redirect("signout.aspx");
        }
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }
}
