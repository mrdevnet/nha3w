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
using SLMF.Business;
using SLMF.Entity;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LogoutMember();
        }
    }

    private void LogoutMember()
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
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
}
