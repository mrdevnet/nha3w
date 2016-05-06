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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class signout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        or();
    }

    private void or()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            //EnMember member = new EnMember();
            //member.UserName = SlmMemberCookie.Value.ToString();

            //EnMemberProfile memberprofile = new EnMemberProfile();
            //memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];

            //BuMemberProfile.LogoutMember(member, memberprofile);

            ck.Expires = new System.DateTime(2005, 1, 1);
            ck.Value = null;
            Response.Cookies.Add(ck);
        }
        of();
        FormsAuthentication.SignOut();
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["r"] != null && Request.Params["r"].ToString() != "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('Mật khẩu tài khoản " + Request.Params["r"].ToString() + " của bạn đã thay đổi thành công! Vui lòng đăng nhập lại bằng mật khẩu mới.');window.location.href='login.aspx';</script>");
        }
        else if (Request.Params["e"] != null && Request.Params["e"].ToString() != "" && Request.Params["r"] != null && Request.Params["r"].ToString() != "" && Request.Params["q"] != null && Request.Params["q"].ToString() == "l")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('Email yêu cầu thay đổi Mật khẩu của tài khoản " + Request.Params["r"].ToString() + " đã được gửi đến địa chỉ : " + Request.Params["e"].ToString() + " ! Vui lòng kiểm tra Email này và thực hiện theo hướng dẫn.');window.location.href='default.aspx';</script>");
        }
        else if (Request.Params["e"] != null && Request.Params["e"].ToString() != "" && Request.Params["r"] != null && Request.Params["r"].ToString() != "" && Request.Params["q"] != null && Request.Params["q"].ToString() == "c")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('Mật khẩu của tài khoản " + Request.Params["r"].ToString() + " đã được thay đổi thành công. Hệ thống đã gửi Email thông báo đến địa chỉ : " + Request.Params["e"].ToString() + " ! Vui lòng kiểm tra Email này để xác thực thông tin.');window.location.href='login.aspx';</script>");
        }
        else Response.Redirect("default.aspx");
    }

    private void of()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
                 SlmMemberCookie.Value != null)
        {
            EnMember member = new EnMember();
            member.UserName = SlmMemberCookie.Value.ToString();

            EnMemberProfile memberprofile = new EnMemberProfile();
            memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];

            BuMemberProfile.LogoutMember(member, memberprofile);

            SlmMemberCookie.Expires = new System.DateTime(2005, 1, 1);
            SlmMemberCookie.Value = null;
            Response.Cookies.Add(SlmMemberCookie);
        }
        //FormsAuthentication.SignOut();
        //Response.Redirect("Default.aspx");
    }
}
