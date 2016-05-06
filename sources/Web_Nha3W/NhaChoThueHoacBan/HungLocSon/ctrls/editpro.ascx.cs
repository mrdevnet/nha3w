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
using System.Text.RegularExpressions;
using System.IO;
using HungLocSon.EHLS;
using HungLocSon.BHLS;
using HungLocSon.UHLS;
using Subgurim.Controles;
using HungLocSon.Tools;
using System.Drawing;
using System.Drawing.Imaging;

public partial class ctrls_editpro : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (fp1.IsPosting) this.managePost1();
        if (!IsPostBack)
        {
            Loads();
            err.Visible = false;
        }
    }

    private void Loads()
    {

        if (lk() != "")
        {
            //err.Visible = false;
            //EMember mb = BMember.Detail(BMember.ReturnId(lk()));
            EProfile pf = BMember.Details(BMember.ReturnId(lk()));
            if (pf.Gender)
            {
                cobGender.SelectedIndex = 1;
            }
            else
            {
                cobGender.SelectedIndex = 0;
            }
            lblFName.Text = pf.FullName;
            txtFName.Text = pf.FullName;
            lblEM.Text = HungLocSon.UHLS.EncryptM.ToOutput(pf.Email);
            txtCompany.Text = pf.Company;
            txtMobile.Text = HungLocSon.UHLS.EncryptM.ToOutput(pf.Mobile);
            txtTel.Text = HungLocSon.UHLS.EncryptM.ToOutput(pf.Tel);
            txtAddress.Text = pf.Address;
            if (pf.Birthday.ToString() == "") txtbirthday.Text = DateTime.Now.ToShortDateString();//txtbirthday.Text = DateTime.Parse(pf.Birthday.ToString()).ToShortDateString();
            else txtbirthday.Text = pf.Birthday.Day + "/" + pf.Birthday.Month + "/" + pf.Birthday.Year; //pf.Birthday.ToShortDateString();
            txtEM2.Text = HungLocSon.UHLS.EncryptM.ToOutput(pf.Email);
            txtEM2.ReadOnly = true;
            txtWebsite.Text = pf.Website;
            txtYahoo.Text = pf.Yahoo;
            txtSkype.Text = pf.Skype;
            if (pf.Private) priy.Checked = true;
            else prin.Checked = true;
            imglogo.ImageUrl = "~/avas/" + pf.Logo;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnprofile_Click(object sender, EventArgs e)
    {
        string mobi = HungLocSon.UHLS.EncryptM.ToInput(txtMobile.Text);
        string tel = HungLocSon.UHLS.EncryptM.ToInput(txtTel.Text);
        bool gender = false;
        if (cobGender.SelectedIndex == 1)
            gender = true;
        else
            gender = false;
        DateTime a = new DateTime();
        //a = Convert.ToDateTime(txtbirthday.Text.ToString());
        string strStart = txtbirthday.Text.ToString();
        strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
        a = DateTime.Parse(strStart);
        BMember.ChangeProfile(BMember.ReturnId(lk()), txtFName.Text, txtCompany.Text, txtAddress.Text, tel, mobi, a, gender);
        err.Visible = false;
        Loads();
        return;
    }

    protected void btnPrive_Click(object sender, EventArgs e)
    {
        EMember r = new EMember();
        r.UserName = lk();
        EPFiles f = new EPFiles();
        if (priy.Checked) f.Prive = true;
        else if (prin.Checked) f.Prive = false;
        BMember.UFlPri(r, f);
        err.Visible = false;
    }

    protected void btnemail_Click(object sender, EventArgs e)
    {
        if (txtemail.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Nhập email bạn muốn thay đổi.";
            text_err.InnerHtml = "Hãy nhập đúng địa chỉ email thực. Điều này đảm bảo bạn có thể lấy lại các thông tin tài khoản khi bạn quên mật khẩu.";
            Loads();
            return;
        }
        else
        {
            if (!Email(txtemail.Text.Trim()))
            {
                err.Visible = true;
                header_err.InnerHtml = "Email không đúng định dạng.";
                text_err.InnerHtml = "Hãy nhập đúng địa chỉ email thực. Điều này đảm bảo bạn có thể lấy lại các thông tin tài khoản khi bạn quên mật khẩu.";
                Loads();
                return;
            }
            else
            {
                err.Visible = false;
            }
        }
        string eml = HungLocSon.UHLS.EncryptM.ToInput(txtemail.Text.Trim());
        BMember.ChangeEmail(BMember.ReturnId(lk()), eml);
        err.Visible = false;
        txtemail.Text = "";
        Loads();
        return;

    }
    public bool Email(string myEmail)
    {
        return Regex.IsMatch(myEmail, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
    }
    protected void btnpass_Click(object sender, EventArgs e)
    {
        if (txtoldpass.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Hãy nhập mật khẩu của bạn.";
            text_err.InnerHtml = "Nếu bạn muốn thay đổi mật khẩu . Hãy nhập mật khẩu cũ để chúng tôi xác minh.";
            Loads();
            return;
        }
        if (txtnewpass.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Hãy nhập mật khẩu mới của bạn.";
            text_err.InnerHtml = "Nếu bạn muốn thay đổi mật khẩu . Hãy nhập mật khẩu mới";
            Loads();
            return;
        }
        if (txtrespeakpass.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Hãy nhập lại mật khẩu mới.";
            text_err.InnerHtml = "Nếu bạn muốn thay đổi mật khẩu. Hãy nhập lại mật khẩu mới hai lần";
            Loads();
            return;
        }
        if (txtrespeakpass.Text.Trim().Length < 6)
        {
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu mới phải có ít nhất 6 ký tự";
            text_err.InnerHtml = "Nếu bạn muốn thay đổi mật khẩu. Hãy nhập lại mật khẩu mới hai lần";
            Loads();
            return;
        }
        if (txtrespeakpass.Text.Trim() != txtnewpass.Text.Trim())
        {
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu mới và mật khẩu nhắc lại chưa trùng!";
            text_err.InnerHtml = "Nếu bạn muốn thay đổi mật khẩu. Hãy nhập lại mật khẩu mới hai lần trùng nhau.";
            Loads();
            return;
        }
        EMember mb = BMember.Detail(BMember.ReturnId(lk()));
        HungLocSon.UHLS.EncryptM md5c = new HungLocSon.UHLS.EncryptM();
        if (mb.Password != md5c.Md5Encode(md5c.Md5Encode(txtoldpass.Text.Trim()) + mb.Salt))
        {
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu cũ không đúng!";
            text_err.InnerHtml = "Hãy nhập đúng mật khẩu cũ nếu bạn muốn thay đổi mật khẩu.";
            Loads();
            return;
        }
        else
        {
            EnMember nwp = new EnMember();
            nwp.UserName = lk();
            nwp.MemberId = BuMemberProfile.SelectMemberIdFUser(nwp);
            string npws = mb.Salt.Substring(0, 3);
            nwp.Password = md5c.Md5Encode(md5c.Md5Encode(txtnewpass.Text.Trim()) + npws); // br.Salt.Substring(0, 3);
            BuMemberProfile.UpdatePassword(nwp);
            err.Visible = false;
            BMember.ChangePassword(mb.MemberId, txtnewpass.Text.Trim(), mb.Salt);
            Response.Redirect("signout.aspx?m=" + mb.MemberId + "&r=" + nwp.UserName);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('Mật khẩu tài khoản " + nwp.UserName + " của bạn đã thay đổi thành công! Vui lòng đăng nhập lại bằng mật khẩu mới.');window.location.href='signout.aspx';</script>");
            //Loads();
            //return;
        }

    }
    protected void btnconnect_Click(object sender, EventArgs e)
    {
        BMember.ChangePublic(BMember.ReturnId(lk()), txtYahoo.Text.Trim(), txtSkype.Text.Trim(), txtWebsite.Text.Trim());
        Loads();
        err.Visible = false;
        return;
    }
    protected void btnlogo_Click(object sender, EventArgs e)
    {
        //string fname = imglogo.ImageUrl.Substring(imglogo.ImageUrl.LastIndexOf("/") + 1);
        //if (fullogo.HasFile)
        //{
        //    if (System.IO.File.Exists(Server.MapPath("~/avas/" + fname)))
        //        File.Delete(Server.MapPath("~/avas/") + fname);
        //    fname = fullogo.FileName.Replace(" ", "_");
        //    fullogo.SaveAs(Server.MapPath("~/avas/" + fname));
        //    BMember.ChangeLogo(BMember.ReturnId(lk()), fname);
        //    imglogo.ImageUrl = "~/avas/" + fname;
        //    err.Visible = false;
        //    Loads();
        //    return;
        //}
        //else
        //{
        //    err.Visible = true;
        //    header_err.InnerHtml = "Chọn ảnh bạn muốn làm logo";
        //    text_err.InnerHtml = "Ảnh đưa vào không được quá dung lượng và kích thước quy định";
        //    Loads();
        //    return;
        //}
        Loads();
        err.Visible = false;
        return;
    }

    private string ihn(string i)
    {
        int a = 0;
        if (i.Contains(".jpg")) a = 1;
        else if (i.Contains(".JPG")) a = 2;
        else if (i.Contains(".gif")) a = 3;
        else if (i.Contains(".GIF")) a = 4;
        else if (i.Contains(".png")) a = 5;
        else if (i.Contains(".PNG")) a = 6;

        switch (a)
        {
            case 1:
                {
                    i = i.Replace(".jpg", "");
                    i = i + GUHLS.NetId() + ".jpg";
                    break;
                }
            case 2:
                {
                    i = i.Replace(".JPG", "");
                    i = i + GUHLS.NetId() + ".jpg";
                    break;
                }
            case 3:
                {
                    i = i.Replace(".gif", "");
                    i = i + GUHLS.NetId() + ".gif";
                    break;
                }
            case 4:
                {
                    i = i.Replace(".GIF", "");
                    i = i + GUHLS.NetId() + ".gif";
                    break;
                }
            case 5:
                {
                    i = i.Replace(".png", "");
                    i = i + GUHLS.NetId() + ".png";
                    break;
                }
            case 6:
                {
                    i = i.Replace(".PNG", "");
                    i = i + GUHLS.NetId() + ".png";
                    break;
                }
        }
        return i;
    }

    private void colo(HttpPostedFileAJAX pf)
    {
        string n3wi = ihn(pf.FileName);
        byte[] imgData = getData(Server.MapPath("~\\" + "avas/tpls/" + pf.FileName));
        System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgData));
        Bitmap bmp = new Bitmap(new Bitmap(img));
        Bitmap bmp2 = new Bitmap(new Bitmap(img));
        Bitmap bmpNew = new Bitmap(bmp);
        Bitmap bmpNew2 = new Bitmap(bmp2);
        bmp.Dispose();
        bmp2.Dispose();
        img.Dispose();
        if (bmpNew.Width>=152 && bmpNew.Height>=96) bmpNew = EncryptM.CreateThumbnail(bmpNew, 152, 96);
        else bmpNew = EncryptM.CreateThumbnail(bmpNew, bmpNew.Width, bmpNew.Height);
        if (bmpNew2.Width >= 100 && bmpNew2.Height >= 100) bmpNew2 = EncryptM.CreateThumbnail(bmpNew2, 100, 100);
        else bmpNew2 = EncryptM.CreateThumbnail(bmpNew2, bmpNew2.Width, bmpNew2.Height);
        if (bmpNew2.Width >=60 && bmpNew2.Height >= 60) bmpNew2 = cropImage(bmpNew2, new Rectangle(10, 10, 50, 50));
        else if (bmpNew2.Width >= 60 && bmpNew2.Height >= 50 && bmpNew2.Height < 60) bmpNew2 = cropImage(bmpNew2, new Rectangle(10, 0, 50, 50));
        else if (bmpNew2.Width >= 50 && bmpNew2.Width < 60 && bmpNew2.Height >= 60) bmpNew2 = cropImage(bmpNew2, new Rectangle(0, 10, 50, 50));
        else bmpNew2 = cropImage(bmpNew2, new Rectangle(0, 0, bmpNew2.Width, bmpNew2.Height));
        bmpNew.Save(Server.MapPath("~/avas/") + n3wi);
        bmpNew2.Save(Server.MapPath("~/avas/thumbs/") + n3wi);
        bmpNew.Dispose();
        bmpNew2.Dispose();
        BMember.ChangeLogo(BMember.ReturnId(lk()), n3wi);
        imglogo.ImageUrl = Server.MapPath("avas/") + n3wi;
        err.Visible = false;
    }

    private System.Drawing.Bitmap cropImage(System.Drawing.Image img, Rectangle cropArea)
    {
        Bitmap bmpImage = new Bitmap(img);
        Bitmap bmpCrop = bmpImage.Clone(cropArea,bmpImage.PixelFormat);
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

    private void managePost1()
    {
        HttpPostedFileAJAX pf = fp1.PostedFile;
        if ((pf.Type == HttpPostedFileAJAX.fileType.image) && (pf.ContentLength <= 5 * 1024 * 1024))
        {
            fp1.SaveAs("avas/tpls", pf.FileName);
            colo(pf);
        }
        fp1.PostedFile.responseMessage_Uploaded_NotSaved = "<span style=\"font-family: Tahoma; font-size: 11px;\">File không hợp lệ.</span>";
    }

    protected void btnfullname_Click(object sender, EventArgs e)
    {
        if (txtfullname.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Vui lòng nhập tên mới.";
            text_err.InnerHtml = "Hãy nhập tên thật của bạn vì tên của bạn sẽ được hiển thị trên website.";
            Loads();
            return;
        }
        err.Visible = false;
        BMember.ChangeFullName(BMember.ReturnId(lk()), txtfullname.Text.Trim());
        txtfullname.Text = "";
        Loads();
        return;

    }
    //lay cookie
    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }  
}
