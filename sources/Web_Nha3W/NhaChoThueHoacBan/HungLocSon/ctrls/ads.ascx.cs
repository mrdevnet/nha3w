using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.BHLS;

public partial class ctrls_ads : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Advertises();
        }
    }

    //private void LoadAds()
    //{
    //    SqlDataReader r = BAdvertises.sads();
    //    rptAds.DataSource = r;
    //    rptAds.DataBind();
    //    if (r.IsClosed == false)
    //    {
    //        r.Close();
    //        r.Dispose();
    //    }
    //}

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
    }

    

    
}
