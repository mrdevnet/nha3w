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
using HungLocSon.EHLS;
using HungLocSon.BHLS;
using HungLocSon.Tools;

public partial class ctrls_resetpass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            err.Visible = false;
        }
        pnlcc.Visible = false;
    }

    private string LookCookie()
    {
        HttpCookie Cookie = new HttpCookie("hlscoc1");
        Cookie = Request.Cookies["hlscoc1"];
        string strUser = "";
        if (Cookie != null && Cookie.Value != "" && Cookie.Value != null)
        {
            strUser = Cookie.Value.ToString();
        } return strUser;
    }
    public string querys()
    {
        return LookCookie();
    }
    protected void lbtResetpass_Click(object sender, EventArgs e)
    {
        if (txtPass.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Vui lòng nhập mật khẩu mới";
            text_err.InnerHtml = "Hãy nhập mật khẩu trên 6 kí tự mà bạn cảm thấy an toàn";
            return;
        }
        if (txtPass.Text.Trim().Length < 6)
        {
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu phải có trên 6 ký tự";
            text_err.InnerHtml = "Hãy nhập mật khẩu trên 6 kí tự mà bạn cảm thấy an toàn có thể nhập ký tự và chữ số";
            return;
        }
        if (txtPass.Text.Trim() != txtPassR.Text.Trim())
        {
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu nhắc lại không trùng khớp !";
            text_err.InnerHtml = "Hãy kiểm tra mật khẩu bạn đang nhập (Chắc rằng bạn có đang sử dung CapsLock hoặc ký tự số).";
            return;
        }
        //Soạn thư
        err.Visible = false;
        //Soan thu
        EMember mb = BMember.Detail(BMember.ReturnId(Request["us"].ToString()));
        BMember.ChangePassword(BMember.ReturnId(Request["us"].ToString()), txtPass.Text.Trim(), mb.Salt);

        EnMember nwp = new EnMember();
        HungLocSon.UHLS.EncryptM md5c = new HungLocSon.UHLS.EncryptM();
        nwp.UserName = Request["us"].ToString();
        nwp.MemberId = BuMemberProfile.SelectMemberIdFUser(nwp);
        string npws = mb.Salt.Substring(0, 3);
        nwp.Password = md5c.Md5Encode(md5c.Md5Encode(txtPass.Text.Trim()) + npws); // br.Salt.Substring(0, 3);
        BuMemberProfile.UpdatePassword(nwp);

        EProfile pf = BMember.Details(BMember.ReturnId(Request["us"].ToString()));
        StreamReader sr = new StreamReader(Server.MapPath("~/ctrls/mails/lostpass.htm"));
        sr = File.OpenText(Server.MapPath("~/ctrls/mails/lostpass.htm"));
        string content = sr.ReadToEnd();
        content = content.Replace("[Sender]", "Email từ Ban quản trị Nha3W");
        content = content.Replace("[User]", pf.FullName);
        content = content.Replace("[Title]", "Bạn đã thay đổi mật khẩu thành công !");
        content = content.Replace("[DateTime]", DateTime.Now.ToString());
        content = content.Replace("[Content]", "Mật khẩu mới của bạn là :" + txtPass.Text.Trim());
        content = content.Replace("[Signature]", "Nha3W.com");
        SendMail.clies(HungLocSon.UHLS.EncryptM.ToOutput(pf.Email), "Thay đổi mật khẩu tài khoản tại website www.nha3w.com thành công", content);
        //SendMail.Sendmail("Nha3W.com", HungLocSon.UHLS.EncryptM.ToOutput(pf.Email), "Thay đổi mật khẩu thành công", content, true, true);
        or();
        Response.Redirect("signout.aspx?e=" + HungLocSon.UHLS.EncryptM.ToOutput(pf.Email) + "&r=" + Request["us"].ToString() + "&q=c");
    }

    //xoa cookie
    private void or()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            ck.Expires = new System.DateTime(2005, 1, 1);
            ck.Value = null;
            Response.Cookies.Add(ck);
        }
        FormsAuthentication.SignOut();
        //Response.Redirect("~/");
    }
}
