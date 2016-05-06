using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;

public partial class SlmControls_slm_register : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbtCheck.Attributes.Add("onclick", "Spinner();");
            //lbtRefresh.Attributes.Add("onclick", "Spinner1();");
            lbtRefresh.Attributes.Add("onclick", "reloadscr();");
            btnRegister.Attributes.Add("onclick", "GetSlmEnc();");
            LoadSLMF();
            pnlError.Visible = false;
            Reload();
        }
    }

    //public static string SrcCode = "";
    private void Reload()
    {
        UtiGeneralClass secnew = new UtiGeneralClass();
        //SrcCode = secnew.RdnCode(6);
        Session["IdCodeSecur"] = secnew.RdnCode(6);
    }

    public string LoadTitle(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadSLMF()
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        lbtCheck.Text = slmNew.LoadLangs("SLMF_Reg", "CheckExist");
        //lbtRefresh.Text = slmNew.LoadLangs("SLMF_Reg", "Refresh");
        btnRegister.Text = slmNew.LoadLangs("SLMF_Reg", "Register");
        btnCancel.Text = slmNew.LoadLangs("SLMF_Reg", "Cancel");
    }

    private int CheckAvailable()
    {
        string strSecView = "";
        if (Session["IdCodeSecur"] != null)
        {
            strSecView = Session["IdCodeSecur"].ToString().ToUpper();
        }
        string strSecurity = txtSecurity.Text.ToString().ToUpper();
        string strUserName = txtUserName.Text.ToString();
        string strPassword = txtPassword.Text.ToString();
        string strPassword2 = txtPassword2.Text.ToString();
        string strEmail = txtEmail.Text.ToString();
        int intResult = 0;
        if (strSecurity == "")
        {
            intResult = -2;
        }
        else if (strSecurity != strSecView)
        {
            intResult = -1;
        }
        else if (strUserName == "" || strPassword == "" || strPassword2 == "" || strEmail == "")
        {
            intResult = -3;
        }
        else if (strPassword != strPassword2)
        {
            intResult = -4;
        }
        else if ((strPassword.Length < 6) || (strPassword.Length > 12))
        {
            intResult = -5;
        }
        else
        {
            UtiRegEmail email = new UtiRegEmail();
            bool bolEmail = email.RegExEmail(strEmail);
            if (!bolEmail)
            {
                intResult = -6;
            }
        }
        return intResult;
    }

    //protected void lbtRefresh_Click(object sender, EventArgs e)
    //{
    //    //Reload();OnClick="lbtRefresh_Click"
    //    //Response.Redirect("register.aspx");
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    private bool CheckUserExists()
    {
        string strUserName = txtUserName.Text.ToString();
        bool bolExist = false;
        if (strUserName != "")
        {
            EnMember member = new EnMember();
            member.UserName = strUserName;
            int intResult = BuMember.CheckMemberExists(member);
            UtiGeneralClass lang = new UtiGeneralClass();
            if (intResult == -2)
            {
                lblUserExist.Text = lang.LoadLangs("SLMF_Reg", "DisallowName");
                lblError.Text = lang.LoadLangs("SLMF_Reg", "DisallowName");
                bolExist = false;
            }
            else if (intResult == -1)
            {
                lblUserExist.Text = lang.LoadLangs("SLMF_Reg", "UserNameExists");
                lblError.Text = lang.LoadLangs("SLMF_Reg", "UserNameExists");
                bolExist = false;
            }
            else
            {
                lblUserExist.Text = lang.LoadLangs("SLMF_Reg", "UserFull");
                lblError.Text = lang.LoadLangs("SLMF_Reg", "UserFull");
                bolExist = true;
            }
        }
        return bolExist;
    }
    protected void lbtCheck_Click(object sender, EventArgs e)
    {
        CheckUserExists();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int intReport = CheckAvailable();
        pnlError.Visible = true;
        UtiGeneralClass error = new UtiGeneralClass();
        if (intReport == -2)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "SecurityNull");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else if (intReport == -1)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "SecurityIncorrect");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else if (intReport == -3)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "InforRequired");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else if (intReport == -4)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "PasswordNotSame");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else if (intReport == -5)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "PasswordLength");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else if (intReport == -6)
        {
            lblError.Text = error.LoadLangs("SLMF_Reg", "EmailIncorrect");
            Reload();
            //Response.Redirect("register.aspx");
        }
        else
        {
            if (CheckUserExists())
            {
                InsertMembers();
            }
        }
    }

    private void InsertMembers()
    {
        EnMember member = new EnMember();
        EnMemberProfile memberprofile = new EnMemberProfile();
        member.UserName = txtUserName.Text.ToString();
        UtiGeneralClass chars = new UtiGeneralClass();
        string strSalt = chars.GenerateRandomCode(3);
        member.Salt = strSalt;
        string strMd5Client = slmhas.Value.ToString();
        UtiHashMd5 md5 = new UtiHashMd5();
        string strMd5Server = md5.Md5Encode(strMd5Client + strSalt);
        UtiGeneralClass report = new UtiGeneralClass();
        member.Password = strMd5Server;
        member.Email = txtEmail.Text.ToString();
        member.FullName = txtFullName.Text.ToString();
        memberprofile.Location = txtLocation.Text.ToString();
        memberprofile.HomePage = txtWebsite.Text.ToString();
        memberprofile.MemberTitle = report.LoadLangs("SLMF_Reg", "MemberTitle");
        memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];
        int intResult = BuMemberProfile.InsertMembers(member, memberprofile);
        if (intResult == 1)
        {
            //lblError.Text = report.LoadLangs("SLMF_Reg", "RegisterSuccessful");
            //ResetControls();
            string strReport = string.Format(report.LoadLangs("SLMF_Reg", "MemberCreated"), member.UserName);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + strReport + "');window.location.href='../login.aspx';</script>");
            //Response.Redirect("login.aspx");
            //Response.Redirect("javascript: alert('Đăng ký thành công. Bây giờ, bạn có thể đăng nhập!');");
        }
        else if (intResult == -2)
        {
            lblError.Text = report.LoadLangs("SLMF_Reg", "EmailExists");
        }
        else
        {
            lblError.Text = report.LoadLangs("SLMF_Reg", "AllowSingup");
        }
    }

    private void ResetControls()
    {
        txtUserName.Text = "";
        txtFullName.Text = "";
        txtEmail.Text = "";
        txtLocation.Text = "";
        txtWebsite.Text = "";
    }
}
