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

public partial class UserControl_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMN();
        }
    }
    private void LoadMN()
    {
        string html = "";
        html = "<ul class=\"ulMn\">"+
	    "<li class=\"top\">"+
	    "<a href=\"Default.aspx\" class=\"top_link\">"+
	    "<span>Trang Chủ</span>"+
	    "</a>"+
	    "</li>";

        System.Data.DataTable nt = HungLocSon.BHLS.BCatalogs.SelectAll();
        foreach (System.Data.DataRow row in nt.Rows)
        {
            if (row["SubId"].ToString() == "0")
            { 
                html+="<li class=\"top\">"+
                    "<a href=\"categories.aspx?c="+ row["CatalogId"]+ "\" class=\"top_link\">"+
                    "<span>"+ row["Name"]+"</span>"+
                    "</a>";

                System.Data.DataTable sub = HungLocSon.BHLS.BCatalogs.SelectListById(int.Parse(row["CatalogId"].ToString()));
            if (sub.Rows.Count > 1)
            {
                          html+= "<ul class=\"sub\">";
                               
                        for (int i = 1; i < sub.Rows.Count; i++)
                        {
                            System.Data.DataRow rowS = sub.Rows[i];
                            html+="<li><a href=\"categories.aspx?c="+ rowS["CatalogId"] +"\">"+ rowS["Name"]+"</a></li>";
                        }
                        html+=" </ul>";
                         
            }
            html+=" </li>";
                   
            }
        }	 
        html+="</ul>";
        MN.InnerHtml = html;
    }
}
