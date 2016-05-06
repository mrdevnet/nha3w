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

public partial class ctrls_pm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (lk() != "")
            {
                int i = BMember.ReturnId(lk());
                EProfile pf = BMember.Details(i);
                Hplmb.Text = pf.FullName;
                Imgmb.ImageUrl = "~/avas/" + pf.Logo;
                Hplmb.NavigateUrl = "../default.aspx?m=" + i;
                Advertises();
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
            if (Request["pm"] != null)
            {
                //newsms.Visible = false;
                Temail.Visible = false;
                WEms.Visible = false;
                if (Request["pm"].ToString() == "i")
                {
                    TPms.Visible = true;
                    FPms.Visible = false;
                    WPms.Visible = false;
                }
                if (Request["pm"].ToString() == "o")
                {
                    TPms.Visible = false;
                    FPms.Visible = true;
                    WPms.Visible = false;
                }
                if (Request["pm"].ToString() == "w")
                {
                    TPms.Visible = false;
                    FPms.Visible = false;
                    WPms.Visible = true;
                }
            }
            if (Request["em"] != null)
            {
                //newsms.Visible = false;
                TPms.Visible = false;
                FPms.Visible = false;
                WPms.Visible = false;
                if (Request["em"].ToString() == "o")
                {

                    Temail.Visible = true;
                    WEms.Visible = false;
                }
                if (Request["em"].ToString() == "w")
                {
                    Temail.Visible = false;
                    WEms.Visible = true;
                }
            }
        }
        //newsms.InnerHtml = "Bạn có " + "<a href=\"pm.aspx?pm=i\">" + BPms.PMS_NewInbox(BMember.ReturnId(lk())) + " tin nhắn mới.</a>";
    }

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
    }

    protected void btnnewsms_Click(object sender, EventArgs e)
    {
        Response.Redirect("pm.aspx?pm=i");
    }
    protected void btntosms_Click(object sender, EventArgs e)
    {
        Response.Redirect("pm.aspx?pm=o");
    }
    protected void btnwsms_Click(object sender, EventArgs e)
    {
        Response.Redirect("pm.aspx?pm=w");
    }
    protected void lbtEm_Click(object sender, EventArgs e)
    {
        Response.Redirect("pm.aspx?em=w");
    }
    protected void lbtEMS_Click(object sender, EventArgs e)
    {
        Response.Redirect("pm.aspx?em=o");
    }
    //lay cookie
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
