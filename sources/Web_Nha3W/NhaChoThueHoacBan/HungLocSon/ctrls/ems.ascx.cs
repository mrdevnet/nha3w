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
using System.IO;
using HungLocSon.BHLS;
using HungLocSon.Tools;
using HungLocSon.EHLS;

public partial class ctrls_ems : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            err.Visible = false;
        }
    }

    protected void btnSentMails_Click(object sender, EventArgs e)
    {
        if (txtTo.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Tên người nhận không đúng !";
            text_err.InnerHtml = "Vui lòng nhập username hoặc email mà bạn muốn gửi.";
            return;
        }
        if (txtMessage.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Nhập nội dung thư bạn !";
            text_err.InnerHtml = "Vui lòng nhập nội dung thư bạn muốn gửi ";
            return;
        }
        string tomb = txtTo.Text.Trim();
        string[] to = tomb.Split(',');
        foreach (String t in to)
        {
            if (BMember.ReturnId(t.Trim()) == 0)
            {
                err.Visible = true;
                header_err.InnerHtml = "Tên người nhận không đúng !";
                text_err.InnerHtml = "Hãy xem lại tên người dùng (hoặc email) này : " + t;
                return;
            }
            else
            {
                err.Visible = true;
            }
        }
        foreach (String tem in to)
        {
            EEmails em = new EEmails();
            EProfile pf = BMember.Details(BMember.ReturnId(lk()));
            EProfile pt = BMember.Details(BMember.ReturnId(tem.Trim()));
            em.FromMember = BMember.ReturnId(lk());
            em.ToMember = BMember.ReturnId(tem.Trim());
            em.Title = rplc(txtTitle.Text);
            em.Message = rplc(txtMessage.Text);
            BEmails.Emails_Insert(em);
            //Soan thu
            StreamReader sr = new StreamReader(Server.MapPath("~/ctrls/mails/lostpass.htm"));
            sr = File.OpenText(Server.MapPath("~/ctrls/mails/lostpass.htm"));
            string content = sr.ReadToEnd();
            content = content.Replace("[Sender]", pf.FullName);
            content = content.Replace("[User]", pt.FullName);
            content = content.Replace("[Title]", em.Title);
            content = content.Replace("[DateTime]", DateTime.Now.ToString());
            content = content.Replace("[Content]", em.Message);
            content = content.Replace("[Signature]", "Nha3W.com - Kết nối & Xanh & Hiện đại");
            SendMail.clies(HungLocSon.UHLS.EncryptM.ToOutput(pt.Email), em.Title, content);
            //SendMail.Sendmail("Nha3W.com - Kết nối & Xanh & Hiện đại", HungLocSon.UHLS.EncryptM.ToOutput(pt.Email), em.Title, content, true, true);
        }
        Response.Redirect("pm.aspx?em=o");
    }
    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
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
