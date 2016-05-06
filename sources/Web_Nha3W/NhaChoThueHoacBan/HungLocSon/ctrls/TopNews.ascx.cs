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
using HungLocSon.BHLS;

public partial class TopNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string html="";
            DateTime time;//edit
            DataTable tnb = _Data;
            foreach (DataRow row in tnb.Rows)
            {
                time = DateTime.Parse(row["Posted"].ToString());
                string link = "../News/articles.aspx?i=" + row["NewsId"].ToString();
                html += "\n<li>" +
                "\n<div style=\"width:100%;height:auto;margin-top:5px;\" >" +
                "\n<div class=\"it\"  style=\"width:180px; float:left;\">" +
                "\n<a href=\"" + link + "\">" + row["Title"].ToString() + "</a> " +
                "\n</div>";
                if (System.IO.File.Exists(Server.MapPath(ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" +
                    time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs2/" + row["Images"].ToString()))))
                    html += "\n<div style=\"width:50px;  float:left;\">" + "\n<a href=\"" + link + "\">" +
                        "\n<img  src=\"" + ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" +
                        time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs2/" +
                        row["Images"].ToString()) + "\" style=\"width:50px; height:35px;\" alt=\"\" />" + "\n</a>" + "\n</div>";
                html += "\n</div>" + "\n</li>";
            }
            TinNB.InnerHtml = html;
        }
    }
    protected DataTable _Data = BNews.SelectTop();
    public DataTable Data
    {
        get { return _Data; }
        set {
            if (_Data != null) _Data = value;
        }
    }
}
