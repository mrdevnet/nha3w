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

public partial class admincp_HLSNwAdmins : System.Web.UI.MasterPage
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
                if (Request.Params["or"] != null && Request.Params["or"].ToString() != "")
                {
                    if (BModers.IsAuAdns(c, Request.Params["or"].ToString()) <= 0) Response.Redirect("../default.aspx");
                }
                else Response.Redirect("../default.aspx");
            }
            else Response.Redirect("../default.aspx");
            LoadMN();
            proi();
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

    private void LoadMN()
    {
        DataTable nt = BCatalogs.SelectAllParent();
        string mu = "\n<li><a style=\"font-weight:bold\" href=\"" + ResolveUrl("~/Admincp/news.aspx?idn=adrn&or=mnggrp") + "\">Nhóm Tin </a></li>" +
                    "\n<li><a style=\"font-weight:bold\" href=\"" + ResolveUrl("~/Admincp/News/Update.aspx?idn=adrn&or=pstnws") + "\">Đăng Tin </a></li>";
        foreach (DataRow row in nt.Rows)
        {
            string link = ResolveUrl("~/Admincp/News/Default.aspx?idn=adrn&or=pstnws&id=" + row["CatalogID"].ToString());
            mu += "\n<li><a style=\"font-weight:bold\" href=\"" + link + "\">" + row["Name"].ToString() + " (" + row["News"].ToString() + ")" + "</a></li>";
            foreach (DataRow rowC in BCatalogs.SelectBySubId(int.Parse(row["CatalogID"].ToString())).Rows)
            {
                link = ResolveUrl("~/Admincp/News/Default.aspx?idn=adrn&or=pstnws&id=" + rowC["CatalogID"].ToString());
                mu += "\n<li>&nbsp;&nbsp;&nbsp;<a href=\"" + link + "\">" + rowC["Name"].ToString() + " (" + rowC["News"].ToString() + ")" + "</a></li>";
            }
        }
        TT.InnerHtml = mu;
    }

    private void proi()
    {
        HungLocSon.EHLS.EMember r = new EMember();
        r.UserName = lk();
        uri.InnerHtml = lk();
        HungLocSon.EHLS.EProfile p = HungLocSon.BHLS.BMember.PMember(r);
        uri.InnerHtml += " - " + p.FullName + " - IP: " + Request.UserHostAddress;
        if (Request.Params["id"] != null && Request.Params["id"].ToString() != "")
        {
            ECatalogs a = BCatalogs.SelectByID(int.Parse(Request.Params["Id"].ToString()));
            if (a.Name != null) uri.InnerHtml += " &nbsp;&nbsp;&nbsp;&nbsp;Danh mục: { " + a.Name.ToString() + " }";
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
