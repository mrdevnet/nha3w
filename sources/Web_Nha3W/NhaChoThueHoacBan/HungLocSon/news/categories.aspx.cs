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
using HungLocSon.Tools;

public partial class news_categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || IsCallback)
        {
            if (Request["c"] != null)
            {
                int id = int.Parse(Request["c"].ToString());
                ECatalogs ec = BCatalogs.SelectByID(id);
                if (ec.Name == null)
                {
                    view.Visible = false;
                    Page.Title = "No Data";
                    return;
                }
                int CurPage = 1;
                if (Request.QueryString["Page"] != null)
                    try
                    {
                        CurPage = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                    catch { }
                else CurPage = 1;
                DataTable tb = BNews.SelectByCatalogId(id, CurPage, 20);
                Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";// +ec.Name;
                if (tb.Rows.Count > 0)
                {
                    DataRow row = tb.Rows[0];
                    DateTime time = DateTime.Parse(row["Posted"].ToString());//edit
                    tdNB0.InnerHtml = row["Title"].ToString();
                    tdNB0.HRef = ResolveUrl("~/News/articles.aspx?i=" + row["NewsId"].ToString());
                    ndNB0.InnerHtml = WebTools.FormatDateTime(DateTime.Parse(row["Posted"].ToString()));
                    ttNB0.InnerHtml = row["Summary"].ToString();
                    imgTB0.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString());//edit
                    AimgNB0.HRef = ResolveUrl("~/News/articles.aspx?i=" + row["NewsId"].ToString());
                    tb.Rows[0].Delete();
                    griTT.DataSource = tb;
                    griTT.DataBind();
                    lt.Text = WebTools.Paging(BNews.SelectByCatalogIdPage(id), CurPage, 10, 20, "c=" + id.ToString());
                }
                lm.IDCatalog = int.Parse(id.ToString());
            }
            else
            {
                view.Visible = false;
                Page.Title = "No Data - Nhà 3W - Kết nối & Xanh & Hiện đại";
            }
        }
    }
}
