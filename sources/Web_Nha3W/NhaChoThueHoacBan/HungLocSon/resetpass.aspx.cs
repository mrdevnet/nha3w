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

public partial class resetpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["w"] == null)
            {

                Response.Redirect("~/");
            }
            if (Request["w"].ToString() == "0")
            {
                hlslostpass.Visible = true;
                hlsresetpass.Visible = false;
            }
            else
            {
                if (Request["w"].ToString() == "1")
                {
                    if (Request["us"] == null || Request["em"] == null || Request["ac"] == null)
                    {
                        Response.Redirect("~/");
                    }
                    int us = BMember.ReturnId(Request["us"].ToString().Trim());
                    int em = BMember.ReturnId(HungLocSon.UHLS.EncryptM.ToInput(Request["em"].ToString().Trim()));
                    int ac = BMember.ReturnId(Request["ac"].ToString().Trim());
                    if (us == 0 || em == 0 || ac == 0)
                    {
                        Response.Redirect("~/");
                    }
                    if (us == em && us == ac)
                    {
                        hlslostpass.Visible = false;
                        hlsresetpass.Visible = true;
                    }
                }
            }
        }
    }
}
