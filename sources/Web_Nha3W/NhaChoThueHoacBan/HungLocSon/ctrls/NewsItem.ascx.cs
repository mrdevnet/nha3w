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
using HungLocSon.Tools;


public partial class NewsItem : System.Web.UI.UserControl
{
        protected DataTable _Data;
        protected string id, title, summary, image, list, show, Posted;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) add();
        }

        public NewsItem()
        {
            id = "NewsId";
            title = "Title";
            summary = "Summary";
            image = "Images";
            Posted = "Posted";
        }
       
       
        public DataTable Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public void add()
        {
            int i = 0;
            //DataRow row0 = _Data.Rows[0];
            //aRss.HRef = ResolveUrl("~/News/rssfeeds.aspx?r=" + row0["CatalogId"].ToString());
			DateTime time;//edit
            foreach (DataRow row in _Data.Rows)
            {

                string link = "../News/articles.aspx?i=" + row[id].ToString();
				time = DateTime.Parse(row["Posted"].ToString());//edit
                switch (i)
                {
                    case 0:
                        {
                            TieuDeNB.InnerHtml = row[title].ToString();
                            TieuDeNB.HRef = link;
                            NgayDang.InnerHtml = WebTools.FormatDateTime(DateTime.Parse(row[Posted].ToString())); 
                            TomtacNB.InnerHtml = row[summary].ToString();
                            if (!System.IO.File.Exists(Server.MapPath(
                                ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" +
                                time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString())))) AnhNB.Visible = false;
                            else AnhNB.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/" + row["Images"].ToString());//edit
                            LinkImage.HRef = link;
                            new0.Visible = WebTools.TestDateTime(DateTime.Parse(row[Posted].ToString()));
                            
                        } break;
                    case 1:
                        {
                            show1.Visible = true;
                            TD1.InnerHtml = row[title].ToString();
                            TD1.HRef = a1.HRef= link;
                            if (!System.IO.File.Exists(Server.MapPath(ResolveUrl("~/ImagesNews/" +
                                time.Year.ToString() + "/" + time.Month.ToString() + "/" +
                                row["NewsId"] + "/image/thumbs/" + row["Images"].ToString())))) img1.Visible = false;
                            else img1.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs/" + row["Images"].ToString());//edit
                            ND1.InnerHtml = "&nbsp;" + WebTools.FormatDateTime(DateTime.Parse(row[Posted].ToString()));
                            new1.Visible = WebTools.TestDateTime(DateTime.Parse(row[Posted].ToString()));
                        } break;
                    case 2:
                        {
                            show2.Visible = true;
                            TD2.InnerHtml = row[title].ToString();
                            TD2.HRef = a2.HRef = link;
                            if (!System.IO.File.Exists(Server.MapPath(ResolveUrl("~/ImagesNews/" +
                                time.Year.ToString() + "/" + time.Month.ToString() + "/" +
                                row["NewsId"] + "/image/thumbs/" + row["Images"].ToString())))) img2.Visible = false;
                            else img2.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs/" + row["Images"].ToString());//edit
                            ND2.InnerHtml = "&nbsp;" + WebTools.FormatDateTime(DateTime.Parse(row[Posted].ToString()));
                            new2.Visible = WebTools.TestDateTime(DateTime.Parse(row[Posted].ToString()));

                        } break;
                    case 3:
                        {
                            show3.Visible = true;
                            TD3.InnerHtml = row[title].ToString();
                            TD3.HRef = a3.HRef= link;
                            if (!System.IO.File.Exists(Server.MapPath(ResolveUrl("~/ImagesNews/" +
                                time.Year.ToString() + "/" + time.Month.ToString() + "/" +
                                row["NewsId"] + "/image/thumbs/" + row["Images"].ToString())))) img3.Visible = false;
                            else img3.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs/" + row["Images"].ToString());//edit
                            ND3.InnerHtml = "&nbsp;" + WebTools.FormatDateTime(DateTime.Parse(row[Posted].ToString()));
                            new3.Visible = WebTools.TestDateTime(DateTime.Parse(row[Posted].ToString()));
                        } break;
                    case 4:
                        {
                            show4.Visible = true;
                            TD4.InnerHtml = row[title].ToString();
                            TD4.HRef = a4.HRef= link;
                            if (!System.IO.File.Exists(Server.MapPath(ResolveUrl("~/ImagesNews/" +
                                time.Year.ToString() + "/" + time.Month.ToString() + "/" +
                                row["NewsId"] + "/image/thumbs/" + row["Images"].ToString())))) img4.Visible = false;
                            else img4.Src = ResolveUrl("~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/" + row["NewsId"] + "/image/thumbs/" + row["Images"].ToString());//edit
                            ND4.InnerHtml = "&nbsp;" + WebTools.FormatDateTime(DateTime.Parse(row[Posted].ToString()));
                            new4.Visible = WebTools.TestDateTime(DateTime.Parse(row[Posted].ToString()));
                        } break;
                    
                }
                i++;
                if (i == 5) break;
            }
        }

}
