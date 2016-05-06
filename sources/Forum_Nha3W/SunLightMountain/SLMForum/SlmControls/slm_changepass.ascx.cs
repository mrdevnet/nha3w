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

public partial class SlmControls_slm_changepass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSend.Attributes.Add("onclick", "GetSlmEnc3();");
            EnMember mbr = new EnMember();
            mbr = RealUser();
            if (mbr.MemberId > 0)
            {
                int intId = mbr.MemberId;
                ProfileMember(intId);
                btnSend.Text = LoadSLMF("SLMF_Signature", "Update");
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
        }
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
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtNewPass.Text.Trim() != txtNewPassConfirm.Text.Trim())
        {
            lblSendaNew.Text = LoadSLMF("SLMF_ChangePassword", "ComparePass");
        }
        else if (txtNewPass.Text.Trim() == "" || txtNewPassConfirm.Text.Trim() == "")
        {
            lblSendaNew.Text = LoadSLMF("SLMF_ChangePassword", "Required");
        }
        else
        {
            MemberLoginTry();
        }
    }

    private void MemberLoginTry()
    {
        string strUserName = LookCookie();
        if (strUserName != "")
        {
            int intResult = 0;
            EnMember member = new EnMember();
            member.UserName = strUserName;
            intResult = BuMember.MemberLogin(member);
            if (intResult == -1)
            {
                lblSendaNew.Text = LoadSLMF("SLMF_Log", "UserNotExists");
            }
            else if (intResult == -2)
            {
                lblSendaNew.Text = LoadSLMF("SLMF_Log", "NotAllowLogin");
            }
            else if (intResult == -3)
            {
                lblSendaNew.Text = LoadSLMF("SLMF_Log", "Banned");
            }
            else if (intResult == -5)
            {
                lblSendaNew.Text = LoadSLMF("SLMF_Log", "IsActivated");
            }
            else if (intResult == -4)
            {
                lblSendaNew.Text = LoadSLMF("SLMF_Log", "EnableLogin");
            }
            else
            {
                string strPass = "", strSalt = "";
                strSalt = member.Salt;
                strPass = member.NewPassword;
                string strOldPass = txtOldPass.Text.ToString();
                UtiHashMd5 md5 = new UtiHashMd5();
                string strMd5Server = md5.Md5Encode(md5.Md5Encode(strOldPass) + strSalt);
                if (strMd5Server == strPass)
                {
                    member = RealUser();
                    string strNewPss = txtNewPass.Text.ToString();
                    member.Password = md5.Md5Encode(md5.Md5Encode(strNewPss) + strSalt);
                    BuMember.UpdatePass(member);
                    lblSendaNew.Text = LoadSLMF("SLMF_ChangePassword", "Successful");
                }
                else
                {
                    lblSendaNew.Text = LoadSLMF("SLMF_Log", "PassIncorrect");
                }
            }
        }
    }
}
