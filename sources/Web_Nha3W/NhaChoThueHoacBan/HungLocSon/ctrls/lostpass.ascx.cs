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
using HungLocSon.EHLS;
using HungLocSon.Tools;

public partial class ctrls_lostpass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            or();
            err.Visible = false;
        }
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
    protected void lbtLostpass_Click(object sender, EventArgs e)
    {
        if (txtCode.Text.Trim() != LookCookie().ToLower().Trim())
        {
            err.Visible = true;
            header_err.InnerHtml = "Mã bảo mật không chính xác !";
            text_err.InnerHtml = "Hãy kiểm tra lại mã bảo mật hoặc nhấn nút bên cạnh để có mã bảo mật mới.";
            return;
        }
        else
        {
            if (txtUS.Text.Trim() == "")
            {
                err.Visible = true;
                header_err.InnerHtml = "Nhập tên tài khoản (username) của bạn";
                text_err.InnerHtml = "Vui lòng nhập tên tài khoản mà bạn đã đăng kí với chúng tôi.";
                return;
            }
            if (txtEM.Text.Trim() == "")
            {
                err.Visible = true;
                header_err.InnerHtml = "Nhập thông tin email hoặc số điện thoại di động mà bạn đăng kí với chúng tôi";
                text_err.InnerHtml = "Bạn có thể liên hệ trực tiếp chúng tôi để lấy lại mật khẩu";
                return;
            }
            if (BMember.ReturnId(HungLocSon.UHLS.EncryptM.ToInput(txtEM.Text.Trim())) == 0)
            {
                err.Visible = true;
                header_err.InnerHtml = "Email hoặc số điện thoại không đúng !";
                text_err.InnerHtml = "Hãy kiểm tra lại định dạng email của bạn hoặc email này không được đăng kí với chúng tôi.";
                return;
            }
            if (BMember.ReturnId(txtUS.Text.Trim()) == 0)
            {
                err.Visible = true;
                header_err.InnerHtml = "Tên đăng nhập không đúng !";
                text_err.InnerHtml = "Hãy kiểm tra lại tên tài khoản mà bạn đã đăng kí với chúng tôi.";
                return;
            }
            if (BMember.ReturnId(txtUS.Text.Trim()) != BMember.ReturnId(HungLocSon.UHLS.EncryptM.ToInput(txtEM.Text.Trim())))
            {
                err.Visible = true;
                header_err.InnerHtml = "Email và tên đăng nhập không trùng khớp";
                text_err.InnerHtml = "Hãy kiểm tra lại tên tài khoản và email mà bạn đã đăng kí với chúng tôi.";
                return;
            }
            else
            {
                //Soan thu
                EMember mb = BMember.Detail(BMember.ReturnId(HungLocSon.UHLS.EncryptM.ToInput(txtEM.Text.Trim())));
                EProfile pf = BMember.Details(BMember.ReturnId(HungLocSon.UHLS.EncryptM.ToInput(txtEM.Text.Trim())));
                StreamReader sr = new StreamReader(Server.MapPath("~/ctrls/mails/lostpass.htm"));
                sr = File.OpenText(Server.MapPath("~/ctrls/mails/lostpass.htm"));
                string content = sr.ReadToEnd();
                content = content.Replace("[Sender]", "Hệ Thống Email mạng xã hội Bất động sản Nha3W.Com");
                content = content.Replace("[User]", pf.FullName + "<br/>");
                string strConts = "Hướng dẫn cách lấy lại mật khẩu từ hệ thống mạng xã hội Bất động sản Nha3W.Com<br/><br/>";
                strConts += "Bạn (hoặc ai đó đã sử dụng tài khoản của bạn) vừa mới yêu cầu lấy lại mật khẩu từ hệ thống mạng xã hội Bất động sản Nha3W.Com.";
                strConts += "Nếu thông tin trên là đúng theo yêu cầu lấy lại mật khẩu từ bạn. Vui lòng thực hiện theo hướng dẫn bên dưới để tạo lại mật khẩu mới.";
                strConts += "<br/>(Mật khẩu mới nên chứa hơn 6 ký tự bao gồm cả ký tự số).<br/><br/>";
                strConts += "Click vào link bên dưới để tạo lại mật khẩu mới cho tài khoản : <b>" + mb.UserName.Trim() + "</b>";
                strConts += "<br/><br/><br/>";
                content = content.Replace("[Title]",strConts);
                content = content.Replace("[DateTime]", DateTime.Now.ToString());
                content = content.Replace("[Content]", "http://www.nha3w.com/resetpass.aspx?w=1" + "&us=" + mb.UserName.Trim() + "&em=" + HungLocSon.UHLS.EncryptM.ToOutput(pf.Email.Trim()) + "&ac=" + pf.Activation);
                content = content.Replace("[Signature]", "<br/>Hệ Thống Email mạng xã hội Bất động sản Nha3W.Com");
                SendMail.clies(HungLocSon.UHLS.EncryptM.ToOutput(pf.Email), "Email Thông báo lấy lại mật khẩu từ mạng xã hội Bất động sản Nha3W.Com", content);
                //SendMail.Sendmail("Hệ Thống Email Nha3W.Com", HungLocSon.UHLS.EncryptM.ToOutput(pf.Email), "Email Thông báo lấy lại mật khẩu từ mạng xã hội Bất động sản Nha3W.Com", content, true, true);
                Response.Redirect("signout.aspx?e=" + HungLocSon.UHLS.EncryptM.ToOutput(pf.Email) + "&r=" + txtUS.Text.Trim() + "&q=l");
                //Response.Redirect("~/");
            }
        }
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
