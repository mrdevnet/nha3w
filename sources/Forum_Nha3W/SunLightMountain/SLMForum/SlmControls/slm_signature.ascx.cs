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

public partial class SlmControls_slm_signature : System.Web.UI.UserControl
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
                ckbSignature.Text = LoadSLMF("SLMF_Signature", "AlwaysSig");
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
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
            txtReplyMsg.Value = pro.Signature;
            ckbSignature.Checked = pro.AlwaysSig;
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

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string strUserName = LookCookie();
        if (txtReplyMsg.Value != "" && strUserName != "")
        {
            string strSignature = txtReplyMsg.Value.ToString();
            int test = 0;
            if (strSignature.Length > 3)
            {
                test = String.Compare(strSignature.Substring(0, 3), "<p>");
            }
            if (test == 0 && strSignature.Length > 3)
            {
                strSignature = strSignature.Remove(0, 3);
            }
            bool bolSignature = ckbSignature.Checked;
            EnMember mbr = new EnMember();
            mbr.UserName = strUserName;
            EnMemberProfile pro = new EnMemberProfile();
            pro.Signature = strSignature;
            pro.AlwaysSig = bolSignature;
            BuMemberProfile.UpdateSignature(mbr, pro);
            lblSendaNew.Text = LoadSLMF("SLMF_Signature", "Updated");
        }
        else
        {
            lblSendaNew.Text = LoadSLMF("SLMF_Signature", "Required");
        }
    }
}
