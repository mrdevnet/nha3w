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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class MapLink : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string url =ResolveUrl("~/News/rssfeeds.aspx?r=");
            ECatalogs ec = BCatalogs.SelectByID(_IDCatalog);
            if (ec.SubId == 0)
            {
                next.Visible = false;
                NTA.InnerText = ec.Name;
                NTA.HRef = ResolveUrl("~/News/categories.aspx?c=" + ec.CatalogId.ToString());
                //url += ec.CatalogId.ToString();
            }
            else
            {
                NTB.InnerText =ec.Name;
                NTB.HRef = ResolveUrl("~/News/categories.aspx?c=" + ec.CatalogId.ToString());
                ECatalogs ec1 = BCatalogs.SelectByID(ec.SubId);
                NTA.InnerText = ec1.Name;
                NTA.HRef = ResolveUrl("~/News/categories.aspx?c=" + ec1.CatalogId.ToString());
                //url += ec1.CatalogId.ToString();
            }
            aRss.HRef = ResolveUrl("~/News/rssfeeds.aspx?r=" + _IDCatalog.ToString());

        }
    }
    private int _IDCatalog;
    public int IDCatalog
    {
        get { return _IDCatalog; }
        set { _IDCatalog = value; }
    }
}
