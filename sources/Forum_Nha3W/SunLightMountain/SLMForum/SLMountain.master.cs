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

public partial class SLMountain : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Advertises();
            if (lk() != "")
            {
                pri.Visible = true;
                reg.Visible = false;
                lg.Visible = false;
                sg.Visible = true;
                Pm();
                //States();
            }
            EnBlockIP i = new EnBlockIP();
            i.IP = HttpContext.Current.Request.UserHostAddress;
            if (BuBlockIP.IPIsBlock(i))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + GetText("SLMF_Log", "IPIsLocked") + "');this.close();</script>");
            }

            ////lblWelcome.Text = GetText("WelHeader", "WelcomeGuest"); //module new

            ReviewCookieMember();
            Guests();

            ////hplLogout.Attributes.Add("onclick", "return logoutforum()");

            int pn = 0;
            if (IsPmNew(ref pn))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>if (confirm('" + GetText("SLMF_Pm", "PmIsView") + "')) { this.location.href='pm.aspx?id=0'; }</script>");
            }
            if (pn > 0)
            {
                hrfPm.InnerText = GetText("WelHeader", "PmNew") + " [ " + pn + " ] |";
            }
            else
            {
                hrfPm.InnerText = GetText("WelHeader", "Pm");
            }
            //string strUrl = "";
            //try
            //{
            //    strUrl = Request.UrlReferrer.ToString();
            //}
            //catch
            //{
            //    strUrl = "default.aspx";
            //}
            //Session["ReUrlForum"] = strUrl;
        }
    }

    private void Pm()
    {
        EnMember m = new EnMember();
        m.UserName = lk();
        EProfile p = new EProfile();
        p = BuMember.PMember(m);
        full.InnerHtml = p.FullName;
    }

    private void Advertises()
    {
        BAdvertises a = new BAdvertises();
        rptAds.DataSource = a.RndAds();
        rptAds.DataBind();
        rpts.DataSource = BAdvertises.Reports();
        rpts.DataBind();
    }

    private void Guests()
    {
        EnMember mbr = new EnMember();
        EnInformation i = new EnInformation();
        if (HttpContext.Current.Request.QueryString["ForumId"] != null)
        {
            i.ForumId = int.Parse(HttpContext.Current.Request.QueryString["ForumId"]);
        }
        else if (HttpContext.Current.Request.QueryString["TopicId"] != null)
        {
            i.TopicId = int.Parse(HttpContext.Current.Request.QueryString["TopicId"]);
        }
        else if (HttpContext.Current.Request.QueryString["GroupId"] != null)
        {
            i.GroupId = int.Parse(HttpContext.Current.Request.QueryString["GroupId"]);
        }
        else if (HttpContext.Current.Request.QueryString["MessageId"] != null)
        {
            i.MessageId = int.Parse(HttpContext.Current.Request.QueryString["MessageId"]);
        }
        i.IP = HttpContext.Current.Request.UserHostAddress;
        i.DetailId = HttpContext.Current.Session.SessionID;
        if (!ReviewCookieMember())
        {
            EnMemberProfile mbrpro = new EnMemberProfile();
            EnGroup grp = new EnGroup();
            grp.GroupName = GetText("SLMF_Reg", "GroupGuest");
            mbr.UserName = GetText("SLMF_Reg", "UserGuest");

            UtiGeneralClass chars = new UtiGeneralClass();
            string strSalt = chars.GenerateRandomCode(3);
            mbr.Salt = strSalt;

            UtiHashMd5 md5 = new UtiHashMd5();
            string strMd5Server = md5.Md5Encode(strSalt);
            //string strMd5Server = md5.Md5Encode(md5.Md5Encode(strSalt) + strSalt);

            mbr.Password = strMd5Server;
            mbr.FullName = GetText("SLMF_Reg", "FullNameGuest");
            mbrpro.Location = GetText("SLMF_Reg", "LocationGuest");
            mbrpro.MemberTitle = GetText("SLMF_Reg", "GuestTitle");
            mbrpro.IP = HttpContext.Current.Request.UserHostAddress;

            BuGroup.InsertGuestGroup(mbr, mbrpro, grp);
            mbr.UserName = "";
            BuInformation.InsertMemberSession(i, mbr);
        }
        else
        {
            if (AuthenticateSession())
            {
                mbr.UserName = LookCookie().ToLower();
                BuInformation.InsertMemberSession(i, mbr);
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("errorsreporter/errorsyes.aspx");
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

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    private bool IsPmNew(ref int pn)
    {
        EnMember mbr = new EnMember();
        mbr.UserName = LookCookie();
        return BuPm.PmIsView(mbr, ref pn);
    }

    public string GetText(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private bool ReviewCookieMember()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        bool flag = false;
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            string strUser = SlmMemberCookie.Value.ToString();

            ////lblWelcome.Text = GetText("WelHeader", "WelcomeGuest") + ", " + strUser;
            //hplLogin.Visible = false;
            ///hplRegister.Visible = false;
            //hplLogout.Visible = true;

            hrfProfile.Visible = true;
            hrfPm.Visible = true;
            flag = true;
        }
        else
        {
            ////hplLogin.Visible = true;
            hrfProfile.Visible = false;
            //hplRegister.Visible = true;
            //hplLogout.Visible = false;

            hrfPm.Visible = false;
        }
        return flag;
    }

    private bool AuthenticateSession()
    {
        HttpCookie SlmSessionId = new HttpCookie("SLMFSessionId");
        SlmSessionId = Request.Cookies["SLMFSessionId"];
        if (SlmSessionId != null && SlmSessionId.Value != "" &&
             SlmSessionId.Value != null)
        {
            string strSessionId = SlmSessionId.Value.ToString();
            EnMember member = new EnMember();
            member.UserName = LookCookie();
            BuMember.MemberLogin(member);
            if (member.NewPassword == strSessionId)
            {
                return true;
            }
        }
        return false;
    }
}
