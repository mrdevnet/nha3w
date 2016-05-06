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
using System.IO;

public partial class news_downloads : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            if (Request["i"] != null)
            {
                EDownloads ed = BDownloads.SelectByID(int.Parse(Request["i"].ToString()));
                TD.InnerText = ed.Title;
                TT.InnerText = ed.Descs;
                DL.InnerText = ed.Download.ToString();

            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            EDownloads ed = BDownloads.SelectByID(int.Parse(Request["i"].ToString()));
            try
            {
                if (ed.Files == "")
                {
                    Response.Redirect(ed.URL);
                }
                else
                {
                    FileStream fs = null;
                    object strPath = Server.MapPath("~/downloadfiles/");
                    string strFileName = ed.Files;

                    fs = File.Open(strPath + strFileName, FileMode.Open);

                    byte[] bytBytes = new byte[fs.Length + 1];

                    fs.Read(bytBytes, 0, (int)fs.Length);
                    fs.Close();
                    Response.AddHeader("Content-disposition", "attachment; filename=" + strFileName);
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(bytBytes);
                    Response.End();
                }
            }
            catch
            {
            }
            finally
            {
                BDownloads.CountDownload(int.Parse(Request["i"].ToString()));
            }
        }

    }
}
