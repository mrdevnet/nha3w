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

public partial class news_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            listC.DataSource = BCatalogs.SelectAllParent();
            listC.DataBind();
        }
    }

    protected void listC_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lb = (Label)e.Item.FindControl("key");
        if (lb.Text == "") return;
        int id = int.Parse(lb.Text);
        ECatalogs ec = BCatalogs.SelectByID(id);
        (e.Item.FindControl("mn") as SubMenu).DaTaMenu = BCatalogs.SelectListById(id);
        (e.Item.FindControl("ni") as NewsItem).Data = ec.NewsByCatalog;
        //(e.Item.FindControl("aRss") as HtmlAnchor).HRef = ResolveUrl("~/News/rssfeeds.aspx?r=" + lb.Text);
    }
}
