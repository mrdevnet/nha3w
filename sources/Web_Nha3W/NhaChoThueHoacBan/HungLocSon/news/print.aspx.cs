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

public partial class news_print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["i"] != null)
            {
                ENews en = BNews.SelectByID(int.Parse(Request["i"].ToString()));
                Page.Title = "Nhà 3W - " + en.Title + " - Kết nối & Xanh & Hiện đại";
                lbTD.Text = en.Title;
                lbND.Text = en.Posted.ToString("hh:mm:ss tt dd/MM/yyyy");
                imgMH.ImageUrl = "~/ImagesNews/" + en.Posted.Year + "/" + en.Posted.Month + "/" + en.NewsId + "/image/" + en.Images;
                lbTT.Text = en.Summary;
                NoiDung.InnerHtml = en.Contents;
            }
        }
    }
}
