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

public partial class ctrls_login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            err.Visible = false;
            if (Request.Params["r"] != null && Request.Params["r"].ToString() != "")
            {
                txtUser.Text = Request.Params["r"].ToString();
            }
        }
        //Kiem tra xem da dang nhap chua
        if (lk() != "")
        {
            txtUser.Text = lk().ToLower().ToString();
            Response.Redirect("default.aspx");
        }
        //Khoi tao cookie dem so lan dang nhap
        if (Rhlslog() == -1)
        {
            Chlslog(0);
        }
        //Kiem tra da dang nhap bao nhiu lan de hien thi capchart
        if (Rhlslog() < 5)
        {
            pnlcc.Visible = false;
        }
        else
        {
            pnlcc.Visible = true;
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
    protected void lbtLogin_Click(object sender, EventArgs e)
    {
        if (Rhlslog() < 5)
        {
            pnlcc.Visible = false;
        }
        else
        {
            pnlcc.Visible = true;
        }
        if (txtUser.Text.Trim() == "")
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Vui lòng nhập tên đăng nhập của bạn !";
            text_err.InnerHtml = "Nếu bạn chưa có tài khoản hãy đăng ký.";
            return;
        }
        if (txtPassword.Text.Trim() == "")
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Vui lòng nhập mật khẩu của bạn !";
            text_err.InnerHtml = "Nếu bạn quên mật khẩu hãy liên hệ chúng tôi để lấy lại mật khẩu. Nếu bạn chưa có tài khoản hãy đăng ký ngay.";
            return;
        }
        int log = BMember.Login(BMember.ReturnId(txtUser.Text.Trim()), txtUser.Text.Trim(), txtPassword.Text.Trim());
        if (log == -1)
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Tài khoản của bạn không chính xác !";
            text_err.InnerHtml = "Nếu bạn quên mật khẩu hãy liên hệ chúng tôi để lấy lại mật khẩu. Nếu bạn chưa có tài khoản hãy đăng ký ngay.";

        }
        if (log == -2)
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Mật khẩu của bạn không chính xác !";
            text_err.InnerHtml = "Nếu bạn quên mật khẩu hãy liên hệ chúng tôi để lấy lại mật khẩu. Nếu bạn chưa có tài khoản hãy đăng ký ngay.";

        }
        if (log == -3)
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Tài khoản của bạn chưa được kích hoạt !";
            text_err.InnerHtml = "Hãy kiểm tra email đăng ký tài khoản để kích hoạt tài khoản. Email kích hoạt đã gửi đến địa chỉ email khi bạn đăng ký tài khoản tại nha3w.com.";// hoặc nhắn tin đến tổng đài 8703 để kích hoạt.";
        }
        if (log == -4)
        {
            Uhlslog();
            err.Visible = true;
            header_err.InnerHtml = "Tài khoản của bạn đã bị khóa !";
            text_err.InnerHtml = "Vì một lý do nào đó tài khoản của bạn đã bị khóa. Hãy liên hệ chúng tôi để được giải đáp.";
        }
        if (pnlcc.Visible == true)
        {
            if (Rhlslog() == 5)
            {
                err.Visible = false;
            }
            else
            {
                if (txtCode.Text.Trim() == "")
                {
                    Uhlslog();
                    err.Visible = true;
                    header_err.InnerHtml = "Vui lòng nhập mã bảo mật !";
                    text_err.InnerHtml = "Hãy kiểm tra mã bảo mật bạn nhập vào hoặc nhấn nút bên cạnh để tạo mã mới";
                    return;
                }
                if (txtCode.Text.Trim() != LookCookie().ToLower().ToString())
                {
                    Uhlslog();
                    err.Visible = true;
                    header_err.InnerHtml = "Mã bảo mật không chính xác !";
                    text_err.InnerHtml = "Hãy kiểm tra mã bảo mật bạn nhập vào hoặc nhấn nút bên cạnh để tạo mã mới";
                    return;
                }
            }
        }
        if (log == 0)
        {
            int intResult = 0;
            EnMember member = new EnMember();
            member.UserName = txtUser.Text.Trim();
            intResult = BuMemberProfile.MemberLogin(member);
            if (intResult == 1)
            {
                string strPass = "", strSalt = "";
                strSalt = member.Salt;
                strPass = member.NewPassword;
                HungLocSon.UHLS.EncryptM cr = new HungLocSon.UHLS.EncryptM();
                string strMd5Server = cr.Md5Encode(cr.Md5Encode(txtPassword.Text.Trim()) + strSalt);// md5.Md5Encode(strMd5Client + strSalt);
                if (strMd5Server == strPass)
                {
                    int intReport = 0;
                    EnMemberProfile memberprofile = new EnMemberProfile();
                    memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];
                    intReport = BuMemberProfile.LoginMemberSuccess(member, memberprofile);
                    if (intReport == 1)
                    {
                        //lblError.Text = error.LoadLangs("SLMF_Log", "LoginSuccess");
                        member.Password = strMd5Server;
                        EMember mb = BMember.Detail(BMember.ReturnId(txtUser.Text.Trim()));
                        mb.SessAuts = HttpContext.Current.Session.SessionID;
                        Ckm2(mb);
                        SetCookieMember(member);
                        Dhlslog();
                    }
                }
            }
        }
    }

    private void SetCookieMember(EnMember member)
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        HttpCookie SlmSessionId = new HttpCookie("SLMFSessionId");
        DateTime dateSLMF = DateTime.Now;
        SlmMemberCookie.Value = member.UserName;
        SlmMemberCookie.Expires = dateSLMF.AddDays(4);
        SlmSessionId.Value = member.Password;
        SlmSessionId.Expires = dateSLMF.AddDays(5);
        if (keepps.Checked)
        {
            SlmMemberCookie.Expires = dateSLMF.AddDays(7);
            SlmSessionId.Expires = dateSLMF.AddDays(8);
        }
        Response.Cookies.Add(SlmMemberCookie);
        Response.Cookies.Add(SlmSessionId);
    }

    //ghi cookie
    private void Ckm2(EMember br)
    {
        HttpCookie hlsck = new HttpCookie("hlsbrlg");
        HttpCookie hlsaut = new HttpCookie("hlsbraut");
        DateTime dth = DateTime.Now;
        hlsck.Value = br.UserName;
        HungLocSon.UHLS.EncryptM m5 = new HungLocSon.UHLS.EncryptM();
        hlsaut.Value = m5.Md5Encode(br.SessAuts);
        if (keepps.Checked)
        {
            hlsck.Expires = dth.AddDays(7);
            hlsaut.Expires = dth.AddDays(7);
        }
        else
        {
            hlsck.Expires = dth.AddDays(4);
            hlsaut.Expires = dth.AddDays(4);
        }
        Response.Cookies.Add(hlsck);
        Response.Cookies.Add(hlsaut);
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
    //tao cookie dem lan dang nhap
    private void Chlslog(int number)
    {
        string vl = number.ToString();
        HttpCookie ck = new HttpCookie("hlslog");
        ck.Expires.AddMinutes(30);
        ck.Value = vl;
        Response.Cookies.Add(ck);
    }
    //lay gia tri cookie dem lan dang nhap
    private int Rhlslog()
    {
        HttpCookie ck = new HttpCookie("hlslog");
        ck = Request.Cookies["hlslog"];
        int us = -1;
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            us = Convert.ToInt16(ck.Value);
        }
        return us;
    }
    //tang cookie dem lan dang nhap
    private void Uhlslog()
    {
        int number = Rhlslog() + 1;
        Chlslog(number);
    }
    //xoa cookie dem lan dang nhap khi dang nhap thanh cong
    private void Dhlslog()
    {
        HttpCookie ck = new HttpCookie("hlslog");
        ck = Request.Cookies["hlslog"];
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            ck.Expires = new System.DateTime(2005, 1, 1);
            ck.Value = null;
            Response.Cookies.Add(ck);
        }
        FormsAuthentication.SignOut();
        Response.Redirect("default.aspx");
    }
}
