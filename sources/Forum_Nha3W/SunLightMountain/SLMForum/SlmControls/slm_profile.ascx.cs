using System;
using System.Data;
using System.Data.SqlClient;
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

public partial class SlmControls_slm_profile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["MemberId"] != null)
            {
                int intMemberId = int.Parse(Request.Params["MemberId"].ToString());
                ProfileMember(intMemberId);
                LastTenPosts(intMemberId);
                Page.Title = LoadSLMF("SLMF_Profile", "Personal") + ". " + LoadSLMF("TitleOfPage", "F9Light");
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
            string strAva = "";
            strAva = pro.Avatar;
            int test = 0;
            if (strAva != "")
            {
                if (strAva.Length > 7)
                {
                    test = String.Compare(strAva.Substring(0, 7), "http://");
                }
                if (test == 0 && strAva.Length > 7)
                {
                    imgAvatar.Src = strAva;
                }
                else 
                {
                    imgAvatar.Src = "../slmuploads/avatar/" + strAva;
                }
            }
            imgRank.Src = "../SlmImages/" + grp.RankImage;
            imgRank.Alt = LoadSLMF("SLMF_Message", "Rank") + grp.GroupName;
            lblUserName.Text = mbr.UserName;
            lblUserName2.Text = mbr.UserName;
            lblAbout.Text = pro.AboutMe;
            lblFullName.Text = mbr.FullName;
            hrfPm.HRef = "../pm.aspx?id=2&memberid=" + intId.ToString();
            if (bool.Parse(pro.IsEmailPublished.ToString()) == true)
            {
                lblEmail.Text = mbr.Email;
            }
            //if (pro.CanSendE)
            //{
            //    hrfEmail.Title = LoadSLMF("SLMF_Profile", "EmailTo") + mbr.UserName;
            //    hrfEmail.HRef = "../em.aspx?memberid=" + intId.ToString();
            //}
            //else
            //{
            //    hrfEmail.Visible = false;
            //}
            if (pro.BirthDay.ToString() != "" && pro.BirthDay.ToShortDateString() != "1/1/0001")
            {
                lblBirthday.Text = pro.BirthDay.Day.ToString() + "/" +
                                    pro.BirthDay.Month.ToString() + "/" +
                                    pro.BirthDay.Year.ToString();
            }
            hrfBlog.HRef = pro.Blog;
            hrfBlog.InnerHtml = pro.Blog;
            hrfBlog.Target = "_blank";
            hrfHome.HRef = pro.HomePage;
            hrfHome.InnerHtml = pro.HomePage;
            hrfHome.Target = "_blank";
            hrfIcq.HRef = "http://www.icq.com/people/about_me.php?uin=" + pro.Icq;
            hrfIcq.InnerHtml = pro.Icq;
            hrfIcq.Target = "_blank";
            lblInterests.Text = pro.Interests;
            lblJob.Text = pro.Job;
            lblLocation.Text = pro.Location;
            lblYahoo.Text = pro.Yahoo;
            lblMsn.Text = pro.Msn;
            lblAim.Text = pro.Aim;
            lblSign.Text = pro.Signature;
            lblJoinUs.Text = mbr.DateCreation.Day.ToString() + "/" + 
                                mbr.DateCreation.Month.ToString() + "/" + 
                                mbr.DateCreation.Year.ToString() + " " + 
                                mbr.DateCreation.ToLongTimeString();
            hrefTotalPosts.HRef = "../searchpro.aspx?author=" + mbr.UserName;
            hrefTotalPosts.InnerHtml = "[" + pro.TotalPosts.ToString() + "]";
            if (bool.Parse(pro.UserStatus.ToString()) == true)
            {
                imgOnline.Src = "../SlmImages/online.gif";
                imgOnline.Alt = mbr.UserName + LoadSLMF("SLMF_Profile", "UserOnline") + " [" +
                    pro.LastBrowse.ToLongTimeString() + "]";
            }
            else
            {
                imgOnline.Alt = mbr.UserName + LoadSLMF("SLMF_Profile", "UserOffline");
            }
            if (pro.Gender == false)
            {
                imgGender.Src = "../SlmImages/female.gif";
            }
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

    private void LastTenPosts(int intMemberId)
    {
        EnMember mbr = new EnMember();
        mbr.MemberId = intMemberId;
        int intId = 0;
        EnMember mbr2 = new EnMember();
        mbr2.UserName = SentForCook();
        SqlDataReader posts = BuMemberProfile.SelectTenPosts(mbr, ref intId, mbr2);
        if (intId > 0)
        {
            rptMessages.DataSource = posts;
            rptMessages.DataBind();
        }
        if (posts.IsClosed == false)
        {
            posts.Close();
            posts.Dispose();
        }
    }

    private string SentForCook()
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
}
