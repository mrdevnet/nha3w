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
using HungLocSon.Tools;

public partial class admincp_news_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            LoadGri();
        }
    }

    private void LoadGri()
    {
        if (Request["Id"] == null)
        {
            griNews.DataSource = BNews.SelectAll();
        }
        else
        {
            griNews.DataSource = BNews.ListCatalogId(int.Parse(Request["ID"].ToString()));
        }

        griNews.DataBind();
    }
    protected void griNews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            string id = e.CommandArgument.ToString();
            DateTime time = BNews.Delete(int.Parse(id));//edit
            if (System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + id.ToString()))) WebTools.DeleteFolder("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + id + "/");//edit
            //WebTools.DeleteFolder("~/ImagesNews/" + id + "/");
            //BNews.Delete(int.Parse(id));
            LoadGri();
        }
    }
    protected void griNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griNews.PageIndex = e.NewPageIndex;
        LoadGri();
    }
}
