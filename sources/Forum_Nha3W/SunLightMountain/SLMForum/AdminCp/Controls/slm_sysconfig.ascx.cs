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
using SLMF.Entity;
using SLMF.Business;

public partial class AdminCp_Controls_slm_sysconfig : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "Submit");
            LoadConfig();
        }
    }

    private void LoadConfig()
    {
        EnConfig config = new EnConfig();
        BuConfiguration.SelectConfiguration(ref config);
        txtAdminEmail.Text = config.AdminEmail.ToString();
        if (config.AllowSignUp)
        {
            ckbAllowSignup.Checked = true;
        }
        if (config.AllowLogIn)
        {
            ckbAllowLogin.Checked = true;
        }
        txtMaxMsg.Text = config.MaxMsg.ToString();
        txtSessionTimeout.Text = config.SessionTimeOut.ToString();
        if (config.GuestSearch)
        {
            ckbGuestSearch.Checked = true;
        }
        if (config.GuestProfile)
        {
            ckbGuestProfile.Checked = true;
        }
        if (config.GuestMember)
        {
            ckbGuestMember.Checked = true;
        }
        if (config.HideRecyleForum)
        {
            ckbHideRecycleBin.Checked = true;
        }
        if (config.ActiveMember)
        {
            ckbActiveMember.Checked = true;
        }
        if (config.ReviewMember)
        {
            ckbReviewMember.Checked = true;
        }
        txtTimePostAgain.Text = config.TimePostAgain.ToString();
        txtMaxLogin.Text = config.Max.ToString();
        lblStarted.Text = config.AddSite.ToLongDateString();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EnConfig config = new EnConfig();
        config.AdminEmail = txtAdminEmail.Text.ToString();
        config.AllowSignUp = ckbAllowSignup.Checked;
        config.AllowLogIn = ckbAllowLogin.Checked;
        int intMaxMsg = 0;
        if (int.TryParse(txtMaxMsg.Text.ToString(), out intMaxMsg))
        {
            config.MaxMsg = intMaxMsg;
        }
        else
        {
            return;
        }
        int intTimeOut = 0;
        if (int.TryParse(txtSessionTimeout.Text.ToString(), out intTimeOut))
        {
            config.SessionTimeOut = intTimeOut;
        }
        else
        {
            return;
        }
        config.GuestSearch = ckbGuestSearch.Checked;
        config.GuestProfile = ckbGuestProfile.Checked;
        config.GuestMember = ckbGuestMember.Checked;
        config.HideRecyleForum = ckbHideRecycleBin.Checked;
        config.ActiveMember = ckbActiveMember.Checked;
        config.ReviewMember = ckbReviewMember.Checked;
        int intTimePostAgain = 0;
        if (int.TryParse(txtTimePostAgain.Text.ToString(), out intTimePostAgain))
        {
            config.TimePostAgain = intTimePostAgain;
        }
        else
        {
            return;
        }

        int intMax = 0;
        if (int.TryParse(txtMaxLogin.Text.ToString(), out intMax))
        {
            config.Max = intMax;
        }
        else
        {
            return;
        }
        BuConfiguration.UpdateConfiguration(config);
        lblReport.Text = LoadSLMF("SLMF_GeneralA", "SubmitSuccess");
        LoadConfig();
    }
}
