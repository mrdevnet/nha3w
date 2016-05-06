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

public partial class NewNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable n = BNews.SelectTop();
            int i = 0;
            string html = "";
			DateTime time;
            foreach (DataRow row in n.Rows)
            {
                string link = "../News/articles.aspx?i=" + row["NewsId"].ToString();
               	time = DateTime.Parse(row["Posted"].ToString());//edit
                switch (i)
                {
                    case 0:
                        {
                            tdNB0.InnerHtml = row["Title"].ToString();
                            tdNB0.HRef = link;
                            ndNB0.InnerHtml = WebTools.FormatDateTime(DateTime.Parse(row["Posted"].ToString()));
                            ttNB0.InnerHtml = row["Summary"].ToString();
                            imgTB0.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString());//edit
                            AimgNB0.HRef = link;
                        } break;
                    case 1:
                        {
                            tdNB1.InnerHtml = row["Title"].ToString();
                            tdNB1.HRef = link;
                            ndNB1.InnerHtml = WebTools.FormatDateTime(DateTime.Parse(row["Posted"].ToString()));
                            ttNB1.InnerHtml = row["Summary"].ToString();
                            imgTB1.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString());//edit
                            AimgNB1.HRef = link;
                        } break;
                    case 2:
                        {
                            tdNB2.InnerHtml = row["Title"].ToString();
                            tdNB2.HRef = link;
                            ndNB2.InnerHtml = WebTools.FormatDateTime(DateTime.Parse(row["Posted"].ToString()));
                            ttNB2.InnerHtml = row["Summary"].ToString();
                            imgTB2.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString());//edit

                            AimgNB2.HRef = link;
                        } break;
                    default:
                        {
                            string img = (WebTools.TestDateTime(DateTime.Parse(row["Posted"].ToString())) == true) ? " <img alt=\"\" src=\"" + ResolveUrl("~/Images/icon_new.jpg") + "\"/> " : "";

                            html += "\n<li><h2 style=\"font-size:12px; font-family: Tahoma;float:left; font-weight:bold; margin:2px;\"><a href=\"" + link + "\">" + row["Title"].ToString() + "</a></h2>&nbsp;" + img + "<span style=\"color:  #808080; font-size:11px;line-height:20px;\">" + WebTools.FormatDateTime(DateTime.Parse(row["Posted"].ToString())) + " </span></li>";
                       } break;
                    
                }
                i++;
                
            }
            TinNB.InnerHtml = html;

        }
    }
}
