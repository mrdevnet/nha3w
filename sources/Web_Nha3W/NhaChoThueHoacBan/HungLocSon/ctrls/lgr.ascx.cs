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
using HungLocSon.UHLS;
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class ctrls_lgr : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        signu.Attributes.Add("onclick", "signu();");
        submit.Attributes.Add("onclick", "lgi();");
    }
   
    protected void signu_Click(object sender, EventArgs e)
    {
        GUHLS p = new GUHLS();
        pvlid.Visible = true;
        prom.Visible = false;
        if (user1.Value.Length < 3 || user1.Value.Length > 21 || user1.Value.Contains(" "))
        {
            pvlid.InnerHtml = "Tên đăng nhập từ 3 ký tự trở lên. Không dấu và Không có khoảng trắng.";
        }
        else if (pass1.Value.Length < 6 || pass1.Value.Length > 16 || pass1.Value.Contains(" "))
        {
            pvlid.InnerHtml = "Mật khẩu phải có ít nhất 6 ký tự. Không có khoảng trắng.";
        }
        else if (pass1.Value != pass2.Value)
        {
            pvlid.InnerHtml = "Mật khẩu nhập lại chưa trùng.";
        }
        else if (!p.ExEmail(email.Value))
        {
            pvlid.InnerHtml = "Email chưa chính xác.";
        }
        else if (security.Value.ToLower() != LookCookie().ToLower())
        {
            pvlid.InnerHtml = "Mã bảo mật chưa chính xác.";
        }
        else if(!agree.Checked)
        {
            pvlid.InnerHtml = "Để đăng ký thành viên, bạn cần đồng ý các điều khoản sử dụng.";
        }
        else
        {
            EMember br = new EMember();
            EnMember rf = new EnMember();
            EProfile pr = new EProfile();
            EnMemberProfile prf = new EnMemberProfile();
            EncryptM cr = new EncryptM();
            br.UserName = user1.Value;
            br.Salt = p.Codes2(6);
            br.Password = cr.Md5Encode(cr.Md5Encode(pass1.Value) + br.Salt);
            pr.FullName = fullname.Value;
            pr.Email = EncryptM.ToInput(email.Value);
            pr.RegIP = Request.ServerVariables["REMOTE_ADDR"]; //HttpContext.Current.Request.UserHostAddress;

            rf.UserName = user1.Value;
            rf.Salt = br.Salt.Substring(0, 3);
            rf.Password = cr.Md5Encode(cr.Md5Encode(pass1.Value) + rf.Salt);
            rf.FullName = fullname.Value;
            rf.Email = email.Value;
            prf.IP = Request.ServerVariables["REMOTE_ADDR"];
            prf.Location = "Thành phố...";
            prf.HomePage = "http://www.nha3w.com";
            prf.MemberTitle = "Thành viên mới";

            br.IsActivated = true;
            br.EnableLogin = true;
            if (BMember.IMember(br, pr) == 1)
            {
                pvlid.InnerHtml = "Tài khoản này đã tồn tại. Bạn hãy chọn Tên đăng nhập khác.";
                security.Value = "";
                return;
            }
            else if (BMember.IMember(br, pr) == 2)
            {
                pvlid.InnerHtml = "Email này đã được sử dụng. Bạn có thể Lấy lại mật khẩu hoặc dùng Email khác.";
                security.Value = "";
                return;
            }
            else
            {
                if (BuMemberProfile.InsertMembers(rf, prf) == 1)
                {
                    br.SessAuts = HttpContext.Current.Session.SessionID;
                    Ckm(br);
                    SetCookieMember(rf);
                    pvlid.InnerHtml = "Đăng ký thành công.";
                    Response.Redirect("default.aspx");
                }
                else
                {
                    pvlid.InnerHtml = "Đăng ký tài khoản forum chưa thành công.";
                    security.Value = "";
                }
            }
        }
    }

    private void Ckm(EMember br)
    {
        HttpCookie hlsck = new HttpCookie("hlsbrlg");
        HttpCookie hlsaut = new HttpCookie("hlsbraut");
        HttpCookie hlsocr = new HttpCookie("hlsbrocr");
        DateTime dth = DateTime.Now;
        hlsck.Value = br.UserName;
        EncryptM m5 = new EncryptM();
        hlsaut.Value = m5.Md5Encode(br.SessAuts);
        hlsocr.Value = m5.Md5Encode(br.Password);
        hlsck.Expires = dth.AddHours(3);
        hlsaut.Expires = dth.AddHours(3);
        hlsocr.Expires = dth.AddHours(3);
        Response.Cookies.Add(hlsck);
        Response.Cookies.Add(hlsaut);
        Response.Cookies.Add(hlsocr);
    }

    public string querys()
    {
        return LookCookie();
    }

    private string LookCookie()
    {
        HttpCookie Cookie = new HttpCookie("hlscoc1");
        Cookie = Request.Cookies["hlscoc1"];
        string strUser = "";
        if (Cookie != null && Cookie.Value != "" &&
             Cookie.Value != null)
        {
            strUser = Cookie.Value.ToString();
        }
        return strUser;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (user.Value != "" && pass.Value != "")
        {
            EMember m = new EMember();
            EProfile p = new EProfile();
            EncryptM cr = new EncryptM();
            m.UserName = user.Value;
            m.Password = pass.Value;
            p.LastIP = Request.ServerVariables["REMOTE_ADDR"];//HttpContext.Current.Request.UserHostAddress;
            m.Salt = BMember.SMember(m);
            m.Password = cr.Md5Encode(cr.Md5Encode(m.Password) + m.Salt);
            int i = BMember.LMember(m, p);
            if (i == 2)
            {
                int intResult = 0;
                EnMember member = new EnMember();
                member.UserName = user.Value;
                intResult = BuMemberProfile.MemberLogin(member);
                if (intResult == 1)
                {
                    string strPass = "", strSalt = "";
                    strSalt = member.Salt;
                    strPass = member.NewPassword;
                    string strMd5Server = cr.Md5Encode(cr.Md5Encode(pass.Value) + strSalt);// md5.Md5Encode(strMd5Client + strSalt);
                    if (strMd5Server == strPass)
                    {
                        int intReport = 0;
                        EnMemberProfile memberprofile = new EnMemberProfile();
                        memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];
                        intReport = BuMemberProfile.LoginMemberSuccess(member, memberprofile);
                        if (intReport == 1)
                        {
                            member.Password = strMd5Server;
                            SetCookieMember(member);
                            m.SessAuts = HttpContext.Current.Session.SessionID;
                            Ckm2(m);
                            Response.Redirect("profile.aspx?v=wall&m=" + BMember.ReturnId(m.UserName));
                        }
                    }
                }
            }
            Response.Redirect("signin.aspx?r=" + user.Value.ToString());
        }
    }

    private void Ckm2(EMember br)
    {
        HttpCookie hlsck = new HttpCookie("hlsbrlg");
        HttpCookie hlsaut = new HttpCookie("hlsbraut");
        HttpCookie hlsocr = new HttpCookie("hlsbrocr");
        DateTime dth = DateTime.Now;
        hlsck.Value = br.UserName;
        EncryptM m5 = new EncryptM();
        hlsaut.Value = m5.Md5Encode(br.SessAuts);
        hlsocr.Value = m5.Md5Encode(br.Password);
        if (keepps.Checked)
        {
            hlsck.Expires = dth.AddDays(7);
            hlsaut.Expires = dth.AddDays(7);
            hlsocr.Expires = dth.AddDays(7);
        }
        else
        {
            hlsck.Expires = dth.AddDays(4);
            hlsaut.Expires = dth.AddDays(4);
            hlsocr.Expires = dth.AddDays(4);
        }
        Response.Cookies.Add(hlsck);
        Response.Cookies.Add(hlsaut);
        Response.Cookies.Add(hlsocr);
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

}
