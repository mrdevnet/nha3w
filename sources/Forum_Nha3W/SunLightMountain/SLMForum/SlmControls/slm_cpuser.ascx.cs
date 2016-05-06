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
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;

public partial class SlmControls_slm_cpuser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EnMember mbr = new EnMember();
            mbr = RealUser();
            if (mbr.MemberId > 0)
            {
                int intMemberId = mbr.MemberId;
                ProfileMember(intMemberId);
            }
            else
            {
                //Response.Redirect("login.aspx");
                Response.Redirect("../login.aspx");
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void ProfileMember(int intId)
    {
        if (intId > 0)
        {
            EnMember mbr = new EnMember();
            EnGroup grp = new EnGroup();
            EnMemberProfile pro = new EnMemberProfile();
            mbr.MemberId = intId;
            BuMemberProfile.SelectProfile(ref mbr, ref grp, ref pro);
            lblUserName.Text = mbr.UserName;
            Page.Title = LoadSLMF("SLMF_CPUser", "YourProfile") + ": " + mbr.UserName + ". " + 
                                LoadSLMF("TitleOfPage", "F9Light");
            //lblUserName2.Text = mbr.UserName;
            lblFullName.Text = mbr.FullName;
            lblEmail.Text = mbr.Email;
            lblSign.Text = pro.Signature;
            lblJoinUs.Text = mbr.DateCreation.Day.ToString() + "/" +
                                mbr.DateCreation.Month.ToString() + "/" +
                                mbr.DateCreation.Year.ToString() + " " +
                                mbr.DateCreation.ToLongTimeString();
            hrefTotalPosts.HRef = "../searchpro.aspx?author=" + mbr.UserName;
            hrefTotalPosts.InnerHtml = "[" + pro.TotalPosts.ToString() + "]";
            lblLastLogin.Text = pro.LastLogin.Day.ToString() + "/" +
                                pro.LastLogin.Month.ToString() + "/" +
                                pro.LastLogin.Year.ToString() + " " +
                                pro.LastLogin.ToLongTimeString();
            EnMemberProfile pro2 = new EnMemberProfile();
            int intCount = BuMemberProfile.LastPosted(mbr, ref pro2);
            if (intCount > 0)
            {
                lblLastPost.Text = pro2.Posted.Day.ToString() + "/" +
                                    pro2.Posted.Month.ToString() + "/" +
                                    pro2.Posted.Year.ToString() + " " +
                                    pro2.Posted.ToLongTimeString();
            }
            else
            {
                lblLastPost.Text = LoadSLMF("SLMF_Profile", "LastPosted");
            }
        }
    }

    private string LookCookie()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        string strUser = "";
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            strUser = SlmMemberCookie.Value.ToString();
        }
        return strUser;
    }

    private EnMember RealUser()
    {
        EnMember mbr = new EnMember();
        mbr.UserName = LookCookie();
        if (mbr.UserName != "")
        {
            mbr = BuMember.SelectMemberIdFUser(mbr);
        }
        return mbr;
    }
}
