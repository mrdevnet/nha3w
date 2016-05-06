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

public partial class SubMenu : System.Web.UI.UserControl
{
    private DataTable data;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadMenu();
    }
    public DataTable DaTaMenu
    {
        get { return data; }
        set { data = value; }
    }

    private void LoadMenu()
    {
        string html = "";
        html = "<ul class=\"SulMn\">";
        if (data.Rows.Count <= 0) return;
	    foreach (System.Data.DataRow row in data.Rows)
        {
            if(row == data.Rows[0])
			html += "<li class=\"top\">";
            else
            html += "<li class=\"Stop\">";             
             html+=       "<a href=\"categories.aspx?c="+ row["CatalogId"] +"\" class=\"Stop_link\">"+
                    "<span>"+ row["Name"] +"</span>"+
                    "</a>"+                
                    "</li>";      
        }
        html += "</ul>";
        divHtml.InnerHtml = html;
        aRss.HRef = ResolveUrl("~/News/rssfeeds.aspx?r=" + data.Rows[0]["CatalogId"].ToString());
   }

}
