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

public partial class SlmControls_slm_login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnLogIn.Attributes.Add("onclick", "GetSlmEnc();");
            LoadView();
            pnlError.Visible = false;
            pnlSecurity.Visible = false;
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadView()
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        ckbRemember.ToolTip = slmNew.LoadLangs("SLMF_Log", "AutoTool");
        btnLogIn.Text = slmNew.LoadLangs("SLMF_Log", "Login");
        btnLostPass.Text = slmNew.LoadLangs("SLMF_Log", "LostPassword");
        lblSecuText.Text = slmNew.GenerateRandomCode(7);
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        MemberLoginTry();
    }

    private void MemberLoginTry()
    {
        UtiGeneralClass error = new UtiGeneralClass();
        string strUserName = txtUserName.Text.ToString();
        string strPassword = txtPassword.Text.ToString();
        pnlError.Visible = true;
        if (strUserName == "" || strPassword == "")
        {
            lblError.Text = error.LoadLangs("SLMF_Log", "InforRequired");
        }
        else
        {
            int intResult = 0;
            EnMember member = new EnMember();
            member.UserName = strUserName;
            intResult = BuMember.MemberLogin(member);
            if (intResult == -1)
            {
                lblError.Text = error.LoadLangs("SLMF_Log", "UserNotExists");
            }
            else if (intResult == -2)
            {
                lblError.Text = error.LoadLangs("SLMF_Log", "NotAllowLogin");
            }
            else if (intResult == -3)
            {
                lblError.Text = error.LoadLangs("SLMF_Log", "Banned");
            }
            else if (intResult == -5)
            {
                lblError.Text = error.LoadLangs("SLMF_Log", "IsActivated");
            }
            else if (intResult == -4)
            {
                lblError.Text = error.LoadLangs("SLMF_Log", "EnableLogin");
            }
            else
            {
                string strPass = "", strSalt = "";
                strSalt = member.Salt;
                strPass = member.NewPassword;

                string strMd5Client = slmhas.Value.ToString();
                UtiHashMd5 md5 = new UtiHashMd5();
                string strMd5Server = md5.Md5Encode(strMd5Client + strSalt);

                if (strMd5Server == strPass)
                {
                    int intReport = 0;
                    EnMemberProfile memberprofile = new EnMemberProfile();
                    memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];
                    intReport = BuMemberProfile.LoginMemberSuccess(member, memberprofile);
                    if (intReport == 1)
                    {
                        lblError.Text = error.LoadLangs("SLMF_Log", "LoginSuccess");
                        member.Password = strMd5Server;
                        SetCookieMember(member);
                        Ckm2(member);
                        Response.Redirect("Default.aspx");
                        //if (Session["ReUrlForum"] != null)
                        //{
                        //    string strUrl = Session["ReUrlForum"].ToString();
                        //    if (!string.IsNullOrEmpty(strUrl) && Request.Params["returnurl"] == null)
                        //    {
                        //        Response.Redirect(strUrl);
                        //    }
                        //    else if (Request.Params["returnurl"] != null)
                        //    {
                        //        strUrl = Request.Params["returnurl"].ToString();
                        //        Response.Redirect(strUrl);
                        //    }
                        //}
                        //else
                        //{
                        //    Response.Redirect("Default.aspx");
                        //}
                    }
                }
                else
                {
                    lblError.Text = error.LoadLangs("SLMF_Log", "PassIncorrect");
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
        SlmMemberCookie.Expires = dateSLMF.AddDays(3);
        SlmSessionId.Value = member.Password;
        SlmSessionId.Expires = dateSLMF.AddDays(4);
        if (ckbRemember.Checked)
        {
            SlmMemberCookie.Expires = dateSLMF.AddDays(7);
            SlmSessionId.Expires = dateSLMF.AddDays(8);
        }
        Response.Cookies.Add(SlmMemberCookie);
        Response.Cookies.Add(SlmSessionId);
    }

    private void Ckm2(EnMember br)
    {
        HttpCookie hlsck = new HttpCookie("hlsbrlg");
        DateTime dth = DateTime.Now;
        hlsck.Value = br.UserName;
        if (ckbRemember.Checked)
            hlsck.Expires = dth.AddDays(7);
        else
            hlsck.Expires = dth.AddDays(4);
        Response.Cookies.Add(hlsck);
    }

    protected void btnLostPass_Click(object sender, EventArgs e)
    {
        Response.Redirect("lostpass.aspx");
    }
}
