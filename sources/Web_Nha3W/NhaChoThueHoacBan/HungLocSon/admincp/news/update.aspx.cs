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
using HungLocSon.Tools;

public partial class admincp_news_update : System.Web.UI.Page
{
    //private static string stringPath="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            if (Session["FCKeditor:UserFilesPath"] == null)
                Session["FCKeditor:UserFilesPath"] = "";
            LoadCatalog();
            DateTime now;
            if (Request["Id"] == null)//nêu thêm mới
            {
                now = DateTime.Now;

                //WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString());//tạo thư mục năm
                //WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString());//tạo thư mục thang
                //WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() +"/"+ BNews.AutoID().Trim() + "/image/");//tao thu muc ID
                //stringPath = "~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim();
                //Session["FCKeditor:UserFilesPath"] = ResolveUrl(stringPath + "/");

                crtf(now,0);

                lbND.Text = "Hôm nay : " + Support.FormatDateTime(now);
                cbC.SelectedIndex = 0;
                txtRa.Value = txtView.Value = "0";
                //lbMB.Text = "Người đăng Lê Bảo Quốc - IP " + Request.UserHostAddress; //thông tin thanh viên vừa đăng nhập
                lbMB.Text = lk() + " - IP: " + Request.UserHostAddress;
            }
            else//nếu sửa
            {
                int idN = int.Parse(Request["ID"].ToString());
                ENews en = BNews.SelectByID(idN);
                now = en.Posted;
                txtT.Text = en.Title;
                txtS.Text = en.Summary;
                txtTa.Text = en.Tag;
                ckbT.Checked = en.Vip;
                txtView.Value = en.Views.ToString();
                txtRa.Value = en.Rating.ToString();
                lbND.Text = "Ngày đăng : " + Support.FormatDateTime(en.Posted);
                cbC.SelectedValue = en.CatalogId.ToString();
                //lbMB.Text = "Ngươi đăng Lê Bảo Quốc - IP 192.168.1.20"; //thông tin nhân viên viết bài ứng với en.MemberId
                lbMB.Text = en.User + " - IP: " + en.IP;
                fckC.Value = en.Contents;

                crtf(now,idN);

                string stringPath = "~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + idN.ToString();
                img.Src = ResolveUrl( stringPath + "/image/" + en.Images);
                //Session["FCKeditor:UserFilesPath"] = ResolveUrl(stringPath + "/");
            }
        }
    }

    private void crtf(DateTime now, int i)
    {
        //DateTime now;
        //now = DateTime.Now;
        if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString()))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString());//tạo thư mục năm
        if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString()))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString());//tạo thư mục thang
        if (i > 0)
        {
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString()))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString());//tao thu muc ID
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image");//tao thu muc ID
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image" + "/thumbs"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image" + "/thumbs");
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image" + "/thumbs2"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i.ToString() + "/image" + "/thumbs2");
            Session["FCKeditor:UserFilesPath"] = ResolveUrl("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + i + "/");
        }
        else
        {
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim()))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim());//tao thu muc ID
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image");//tao thu muc ID
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image" + "/thumbs"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image" + "/thumbs");
            if (!System.IO.File.Exists(Server.MapPath("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image" + "/thumbs2"))) WebTools.CreateFolder("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/image" + "/thumbs2");
            Session["FCKeditor:UserFilesPath"] = ResolveUrl("~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim() + "/");
        }
        //stringPath = "~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim();
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    protected void btok_Click(object sender, EventArgs e)
    {
        ENews en = new ENews();
        en.CatalogId = int.Parse(cbC.SelectedValue.ToString());
        en.Contents = fckC.Value;
        en.IP = Request.UserHostAddress;
        //en.MemberId = 1;//id của nhân viên đã dăng nhập 
        en.User = lk();
        en.Summary = txtS.Text;
        en.Tag = txtTa.Text;
        en.Title = txtT.Text;
        en.Vip = ckbT.Checked;
        en.Rating = int.Parse(txtRa.Value);
        en.Views = int.Parse(txtView.Value);
        string imgurl = "";
        string stringPath = "";
        if (Request["Id"] == null)
        {
            if (fulImage.HasFile)
            {
                crtf(DateTime.Now, 0);
                if (Session["FCKeditor:UserFilesPath"] != null && Session["FCKeditor:UserFilesPath"].ToString() != "")
                {
                    stringPath = Session["FCKeditor:UserFilesPath"].ToString();
                    //DateTime now = DateTime.Now;
                    imgurl = "N3W-" + Support.AutoID() + fulImage.FileName.Substring(fulImage.FileName.LastIndexOf("."));
                    //string path = "~/ImagesNews/" + now.Year.ToString() + "/" + now.Month.ToString() + "/" + BNews.AutoID().Trim();
                    fulImage.SaveAs(Server.MapPath(stringPath + "image/" + imgurl));
                    colo(stringPath, imgurl);
                }
            }
            en.Images = imgurl;
            BNews.Insert(en);
        }
        else
        {
            imgurl = img.Src.Substring(img.Src.LastIndexOf("/") + 1);
            if (fulImage.HasFile)
            {
                if (Session["FCKeditor:UserFilesPath"] != null && Session["FCKeditor:UserFilesPath"].ToString() != "")
                {
                    stringPath = Session["FCKeditor:UserFilesPath"].ToString();
                    imgurl = "N3W-" + Support.AutoID() + fulImage.FileName.Substring(fulImage.FileName.LastIndexOf("."));
                    string path = Server.MapPath(stringPath + "image/" + imgurl);
                    fulImage.SaveAs(path);
                    colo(stringPath, imgurl);
                }
            }
            en.NewsId = int.Parse(Request["Id"].ToString());
            en.Images = imgurl;
            BNews.Update(en);
        }
        Response.Redirect("~/Admincp/News/Default.aspx?idn=adrn&or=pstnws&id=" + cbC.SelectedValue.ToString());
    }

    private void colo(string stringPath, string imgur)
    {
        byte[] imgData = getData(Server.MapPath(stringPath + "image/" + imgur));
        System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgData));
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(new System.Drawing.Bitmap(img));
        System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(new System.Drawing.Bitmap(img));
        System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(bmp);
        System.Drawing.Bitmap bmpNew2 = new System.Drawing.Bitmap(bmp2);
        bmp.Dispose();
        bmp2.Dispose();
        img.Dispose();
        if (bmpNew.Width >= 100 && bmpNew.Height >= 100) bmpNew = HungLocSon.UHLS.EncryptM.CreateThumbnail(bmpNew, 81, 81);
        else bmpNew = HungLocSon.UHLS.EncryptM.CreateThumbnail(bmpNew, bmpNew.Width, bmpNew.Height);
        if (bmpNew.Width >= 60 && bmpNew.Height >= 35) bmpNew = cropImage(bmpNew, new System.Drawing.Rectangle(0, 0, 60, 35));
        else bmpNew = cropImage(bmpNew, new System.Drawing.Rectangle(0, 0, bmpNew.Width, bmpNew.Height));
        if (bmpNew2.Width >= 100 && bmpNew2.Height >= 100) bmpNew2 = HungLocSon.UHLS.EncryptM.CreateThumbnail(bmpNew2, 81, 81);
        else bmpNew2 = HungLocSon.UHLS.EncryptM.CreateThumbnail(bmpNew2, bmpNew2.Width, bmpNew2.Height);
        if (bmpNew2.Width >= 50 && bmpNew2.Height >= 35) bmpNew2 = cropImage(bmpNew2, new System.Drawing.Rectangle(0, 0, 50, 35));
        else bmpNew2 = cropImage(bmpNew2, new System.Drawing.Rectangle(0, 0, bmpNew2.Width, bmpNew2.Height));
        bmpNew.Save(Server.MapPath(stringPath + "image/thumbs/") + imgur);
        bmpNew2.Save(Server.MapPath(stringPath + "image/thumbs2/") + imgur);
        bmpNew.Dispose();
        bmpNew2.Dispose();
    }

    private System.Drawing.Bitmap cropImage(System.Drawing.Image img, System.Drawing.Rectangle cropArea)
    {
        System.Drawing.Bitmap bmpImage = new System.Drawing.Bitmap(img);
        System.Drawing.Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        return (System.Drawing.Bitmap)(bmpCrop);
    }

    private byte[] getData(string filePath)
    {
        System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        byte[] data = br.ReadBytes((int)fs.Length);
        br.Close();
        fs.Close();
        return data;
    }
    private void LoadCatalog()
    {
        DataTable sub = BCatalogs.SelectAllParent();
        cbC.Items.Clear();
        foreach (DataRow row in sub.Rows)
        {
            cbC.Items.Add(new ListItem(row["Name"].ToString(), row["CatalogId"].ToString()));
            foreach (DataRow Srow in BCatalogs.SelectBySubId(int.Parse(row["CatalogId"].ToString())).Rows)
                cbC.Items.Add(new ListItem(" -- " + Srow["Name"].ToString(), Srow["CatalogId"].ToString()));
        }
    }
}
