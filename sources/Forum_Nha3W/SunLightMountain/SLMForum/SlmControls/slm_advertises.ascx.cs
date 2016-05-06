using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Business;

public partial class SlmControls_slm_advertises : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Advertises();
        }
    }

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
    }
}
