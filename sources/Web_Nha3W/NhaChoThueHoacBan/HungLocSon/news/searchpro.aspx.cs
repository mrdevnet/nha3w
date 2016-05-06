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

public partial class news_searchpro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string SS = "";
            if (Request["s"] == null) return;
            if (Request["s"].ToString().Trim().Length < 2)
            {
                lt.Text = "Chuỗi tìm kiếm phải lớn hơn 2 ký tự.";
                return;
            }
            else
                SS = Request["s"].ToString().Trim();
            int CurPage = 1;
            if (Request.QueryString["Page"] != null)
                try
                {
                    CurPage = Convert.ToInt32(Request.QueryString["Page"]);
                }
                catch { }
            else CurPage = 1;
            griTT.DataSource = BNews.Search(SS, CurPage, 20);
            griTT.DataBind();
            lt.Text = WebTools.Paging(BNews.SearchPage(SS), CurPage, 10, 20, "S=" + SS);
        }
    }
}
