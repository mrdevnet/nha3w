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

public partial class DownloadCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadList(1);
        }
       
    }
    private void LoadList(int page)
    {
        string html = "";
        int p = page;
        int maxr = BDownloads.MaxRowList();
        int maxP = (maxr % 10 == 0) ? (maxr / 10) : (maxr / 10 + 1);
        lT.Visible = lS.Visible = true;
        //lbS.Visible = lbT.Visible = false;
        if (p <= 1)
        {
            lT.Visible = false;
            //lbT.Visible = true;
        }
        if (p >= maxP)
        {
            lS.Visible = false;
            //lbS.Visible = true;
        }
        lbP.Text = p.ToString() + "/" + maxP.ToString() + " trang";
        lbKQ.Text ="Tổng : "+ maxr + " file";
        DataTable tnb = BDownloads.ListDownload(p);
        foreach (DataRow row in tnb.Rows)
        {
            html += "\n<li><a style=\"font-size:11px;font-family:Tahoma\" href=\"javascript:showDownload('downloads.aspx?i=" + row["DownloadId"].ToString() + "')\">" + row["Title"].ToString() + "</a> (<span style=\"color: #6EA954\">" + row["Download"].ToString() + "</span>)</li>";
        }
        TinNB.InnerHtml = html;
    }

    protected void lS_Click(object sender, EventArgs e)
    {
        LoadList(Fpage() +1);
    }
    private int Fpage()
    {
        string p = lbP.Text;
        string[] pr = p.Split('/');
        return int.Parse(pr[0].ToString());
    }
    protected void lT_Click(object sender, EventArgs e)
    {
        LoadList(Fpage() - 1);
    }
}
