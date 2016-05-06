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
using System.Collections.Generic;
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class news_rssfeeds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
            string Domail = Request.Url.ToString().Replace(Request.RawUrl, "");
            if (Request["r"] == null) return;
            ECatalogs ec = BCatalogs.SelectByID(int.Parse(Request["r"].ToString()));
            if (ec.Name == null) return;

            ERssNews rss = new ERssNews();
            ERssNews.RssChannel channel = new ERssNews.RssChannel();
            channel.Title = "Tin Tức : " + ec.Name;
            channel.Link = Domail + ResolveUrl("~/News/categories.aspx?c=" + ec.CatalogId);
            channel.Description = ec.Name + " : Nhà 3W - Kết nối & Xanh & Hiện đại ";
            channel.Copyright = "nha3w.com";
            channel.Language = "vi-vn";
            rss.AddRssChannel(channel);
            ERssNews.RssImage img = new ERssNews.RssImage();
            img.Link = "http://www.Nha3w.com";
            img.Title = "Nhà 3W -  Kết nối & Xanh & Hiện đại";
            img.Url = Domail + ResolveUrl("~/Images/nha3w.png");
            rss.AddRssImage(img);
            ERssNews.RssItem item = new ERssNews.RssItem();
            List<ENews> listN = BNews.ListTopRssByCatalog(int.Parse(Request["r"].ToString()));
			DateTime time;//edit
            for (int i = 0; i < listN.Count; i++)
            {
                item.Title = listN[i].Title;
                item.Link = Domail + ResolveUrl("~/News/articles.aspx?i=" + listN[i].NewsId.ToString());
                item.PubDate = listN[i].Posted.ToString("R");
            time = listN[i].Posted;
            item.Description = "<a href ='" + Domail + ResolveUrl("~/News/articles.aspx?i=" + listN[i].NewsId.ToString()) + 
                "'><img alt='' src='" + Domail + ResolveUrl("~/ImagesNews/"+time.Year.ToString()+"/"+ time.Month.ToString()+ "/" + listN[i].NewsId.ToString() + "/image/" + listN[i].Images) + "' hspace='5' vspace='5' width='70' align='left' border='0'  /></a>" + listN[i].Summary; //edit
            //item.Description = "<a href ='" + Domail + ResolveUrl("~/News/articles.aspx?i=" + listN[i].NewsId.ToString()) + 
            //        "'><img alt='' src='" + Domail + ResolveUrl("~/ImagesNews/" + listN[i].NewsId.ToString() + "/image/" + listN[i].Images) + "' hspace='5' vspace='5' width='70' align='left' border='0'  /></a>" + listN[i].Summary;
            rss.AddRssItem(item);
            }
            //Erss.ERssItems = listI;
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.Write(rss.RssDocument);
            Response.End();
        }
    }
}
