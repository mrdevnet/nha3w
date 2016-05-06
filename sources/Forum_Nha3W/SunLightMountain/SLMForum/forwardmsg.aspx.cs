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

public partial class forwardmsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtForward.Text = "www.code2coder.com/forum/showtopic.aspx?rowid=" + Request.Params["RowId"].ToString() + "&messageid=" + Request.Params["MessageId"].ToString() +
                            "#message" + Request.Params["MessageId"].ToString();
        }
    }
}
