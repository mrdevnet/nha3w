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

public partial class editpro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && lk() != "") Pm();
        Advertises();
    }

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
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
        fullname.InnerHtml = "Thông tin cá nhân : " + m.UserName + " (" + p.FullName + ")";
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
}
