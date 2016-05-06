using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HungLocSon.EHLS;
using HungLocSon.BHLS;
using HungLocSon.Tools;


public partial class NewsView : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["i"] != null)
            {
                ENews en = BNews.SelectByID(int.Parse(Request["i"].ToString()));
                if (en.Title == null) return;
                //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";//+ en.Title;
                this.Page.Title = "Nhà 3W - " + en.Title + " - Kết nối & Xanh & Hiện đại";
                ECatalogs dc = en.Catalog;
                lm.IDCatalog = en.CatalogId;
                lbTD.Text = en.Title;
                DateTime time = en.Posted;//edit
                lbND.Text = en.Posted.ToString("hh:mm:ss tt dd/MM/yyyy");
                imgMH.ImageUrl = "~/ImagesNews/"+ time.Year.ToString() + "/"+ time.Month.ToString()+ "/" + en.NewsId + "/image/" + en.Images;//edit
                lbTT.Text = en.Summary;
                tags.InnerText = en.Tag;
                tags.HRef = ResolveUrl("~/News/searchpro.aspx?s=" + en.Tag);
                NoiDung.InnerHtml = en.Contents;
                if (en.Rating == 0) lbRating.Text = "Chưa có ai đánh giá!";
                else lbRating.Text = en.Rating.ToString();

                DataTable tlq = dc.NewsByCatalog;
                string list = "";
                linkIn.HRef = "javascript: showPrint('print.aspx?i=" + Request["i"].ToString() + "')";
                int leng = (tlq.Rows.Count <= 15) ? tlq.Rows.Count : 15;
                for (int i = 0; i < leng; i++)
                {
                    DataRow row = tlq.Rows[i];
                    if (row["Newsid"].ToString() != Request["i"].ToString())
                    {
                        string img = (WebTools.TestDateTime(DateTime.Parse(row["Posted"].ToString())) == true) ? "<img alt=\"\" src=\"" + ResolveUrl("~/Images/icon_new.jpg") + "\"/>" : "";
                        string link = "../News/articles.aspx?i=" + row["Newsid"].ToString();
                        list += "\n<li><a href=\"" + link + "\">" + row["Title"].ToString() + "</a>&nbsp;" + img + " <span  style=\"color:  #808080; font-size:11px\"> " + DateTime.Parse(row["Posted"].ToString()).ToString("dd/MM/yyy") + "</span></li>";
                    }
                }
                TinLQ.InnerHtml = list;
                BNews.intViews(int.Parse(Request["i"].ToString()));
            }
            else return;
        }
    }
    protected void btBinhChon_Click(object sender, ImageClickEventArgs e)
    {
        if (lbRating.Text == "Chưa có ai đánh giá!")
            lbRating.Text = "1";
        else
        {
            int dem = int.Parse(lbRating.Text) + 1;
            lbRating.Text = dem.ToString();
        }
        btBinhChon.ImageUrl = "~/Images/rangD.gif";
        btBinhChon.Enabled = false;
        BNews.intRating(int.Parse(Request["i"].ToString()));
    }
}
