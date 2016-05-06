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

public partial class HLSNews : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ana();
            topR.Data = BNews.SelectTopRating();
            topView.Data = BNews.SelectTopView();
            topVip.Data = BNews.SelectVip();
            if (Request["S"] != null) txtS.Value = Request["S"].ToString();
            Advertises();
            if (lk() != "")
            {
                ImReals();
                pri.Visible = true;
                reg.Visible = false;
                lg.Visible = false;
                sg.Visible = true;
                Pm();
                //States();
            }
            Reports();
        }
    }

    private void ana()
    {
        EAnas a = new EAnas();
        EMember m = new EMember();
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

    private void Reports()
    {
        rpts.DataSource = BReports.Reports();
        rpts.DataBind();
    }

    private void Pm()
    {
        //lft.Visible = true;
        //scl.Attributes.Add("class", "ph3");
        EMember m = new EMember();
        m.UserName = lk();
        EProfile p = new EProfile();
        p = BMember.PMember(m);
        //StringBuilder s = new StringBuilder(1000);
        //s.Append("<span class=\"sbTex\">Họ và tên:<br><b>" + p.FullName + "</b>");
        //s.Append("<br>Công ty:<br><b>" + p.Company + "</b>");
        //s.Append("<br>Địa chỉ:<br><b>" + p.Address + "</b>");
        //s.Append("<br>Điện thoại/Di động:<br><b>" + p.Tel + " - " + p.Mobile + "</b>");
        //s.Append("<br>Email:<br><b>" + p.Email + "</b>");
        //s.Append("</span>");
        //if (p.Logo != "" && p.Logo != null) avas.Src = "avas/" + p.Logo;
        //else avas.Src = "images/procity.gif";
        full.InnerHtml = p.FullName;
        //pr.InnerHtml = s.ToString();
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

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
    }

    protected void btnS_ServerClick(object sender, ImageClickEventArgs e)
    {
        string sh = (txtS.Value.Trim() != "Tìm kiếm") ? txtS.Value : "";
        Response.Redirect("~/news/searchpro.aspx?s=" + sh);
    }
}
