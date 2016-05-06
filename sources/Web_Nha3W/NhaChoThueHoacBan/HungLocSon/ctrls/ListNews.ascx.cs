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

public partial class UserControl_ListNews : System.Web.UI.UserControl
{
    
    public object DaTa
    {
        get { return griTT.DataSource; }
        set { griTT.DataSource = value; }
    }
    //public int Row
    //{
    //    get { return griTT.PageSize; }
    //    set { griTT.PageSize = value; }
    //}
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}
    //protected void griTT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    griTT.PageIndex = e.NewPageIndex;
    //    griTT.DataBind();
    //}
}
