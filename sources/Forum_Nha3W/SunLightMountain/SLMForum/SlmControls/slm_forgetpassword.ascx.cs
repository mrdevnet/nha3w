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

public partial class SlmControls_slm_forgetpassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnLogIn.Text = LoadSLMF("SLMF_LostPass", "ResetPass");
            pnlError.Visible = false;
            Reload();
        }
    }

    private void Reload()
    {
        UtiGeneralClass secnew = new UtiGeneralClass();
        //SrcCode = secnew.RdnCode(6);
        Session["IdCodeSecur"] = secnew.RdnCode(6);
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        string strSecView = "";
        if (Session["IdCodeSecur"] != null)
        {
            strSecView = Session["IdCodeSecur"].ToString();
        }
        string strSecurity = txtSecurity.Text.ToString().ToUpper();
        pnlError.Visible = true;
        if (strSecurity != strSecView)
        {
            lblError.Text = LoadSLMF("SLMF_LostPass", "SecurityIsNotRight");
            txtSecurity.Text = "";
        }
        else
        {
            EnMember mbr = new EnMember();
            mbr.UserName = txtUserName.Text.ToString();
            mbr.Email = txtEmail.Text.ToString();
            CheckResult(mbr);
        }
    }

    private void CheckResult(EnMember mbr)
    {
        int intResult = BuMember.SelectEmailLostPass(ref mbr);
        if (intResult == -1)
        {
            lblError.Text = string.Format(LoadSLMF("SLMF_LostPass", "UserNameIsNotExists"), "<b>" + mbr.UserName + "</b>");
            txtSecurity.Text = "";
        }
        else if (intResult == -2)
        {
            lblError.Text = string.Format(LoadSLMF("SLMF_LostPass", "EmailIsNotRight"), "<b>" + mbr.UserName + "</b>");
            txtSecurity.Text = "";
        }
        else
        {
            lblError.Text = LoadSLMF("SLMF_LostPass", "SentEmail");
            SendEmail(mbr);
        }
    }

    private void SendEmail(EnMember mbr)
    {
        EnEm pmnew = new EnEm();
        string strFrom = ConfigurationManager.AppSettings["FromMail"];
        string strLink = LoadSLMF("SLMF_RssFeed", "LocationHost") + "/resetpass.aspx?memberid=" + mbr.MemberId + 
            "&actlink=" + mbr.ActivateString + "&pass=" + mbr.Salt;
        string[] a = new string[10];
        a[0] = mbr.UserName + ",<br></br>";
        a[1] = "<b>";
        a[2] = "</b>";
        a[3] = mbr.UserName;
        a[4] = LoadSLMF("SLMF_RssFeed", "LocationHost");
        a[5] = mbr.UserName;
        a[6] = "<br></br>";
        a[7] = mbr.UserName;
        a[8] = "<br></br>" + strLink + "<br></br>";
        a[9] = LoadSLMF("SLMF_RssFeed", "LocationHost") + "<br></br>";

        pmnew.Title = string.Format(LoadSLMF("SLMF_LostPass", "TitleOfEmail"), mbr.UserName);
        pmnew.Message = string.Format(LoadSLMF("SLMF_LostPass", "MessageOfEmail"), a[0].ToString(), a[1].ToString(),
            a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(),
            a[6].ToString(), a[7].ToString(), a[8].ToString(), a[9].ToString());
        //pmnew.Message = string.Format(LoadSLMF("SLMF_LostPass", "MessageOfEmail"), a[1]);
        UtiGeneralClass clsNew = new UtiGeneralClass();
        bool bolSend = clsNew.clies(mbr.Email, pmnew.Title, pmnew.Message);
        //bool bolSend = clsNew.SendMailSmtpClient(strFrom, mbr.Email, pmnew.Title, pmnew.Message);
        if (bolSend)
        {
            lblError.Text = LoadSLMF("SLMF_SendAEmail", "Successful");
        }
        else
        {
            lblError.Text = LoadSLMF("SLMF_SendAEmail", "NotSuccessful");
        }
    }
}
