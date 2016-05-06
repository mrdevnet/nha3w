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

public partial class ctrls_temails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtlPMS.DataSource = BEmails.Emails_Outbox(BMember.ReturnId(lk()));
            dtlPMS.DataBind();
        }
    }

    protected void dtlPMS_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "btndelem":
                {
                    BEmails.Emails_Del(Convert.ToInt32(e.CommandArgument));
                    dtlPMS.DataSource = BEmails.Emails_Outbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                }
            case "btndelems":
                {
                    BEmails.Emails_DelOutbox(BMember.ReturnId(lk()));
                    dtlPMS.DataSource = BEmails.Emails_Outbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                }
            case "btnwem":
                {
                    Response.Redirect("pm.aspx?em=w");
                    break;
                }
        }
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
