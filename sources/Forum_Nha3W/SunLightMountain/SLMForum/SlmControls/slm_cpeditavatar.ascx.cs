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

public partial class SlmControls_slm_cpeditavatar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Attributes.Add("onclick", "GetSlmEnc();");
            ddlAvatars.Attributes.Add("onchange", "GetSlmEnc2();");
            EnMember mbr = new EnMember();
            mbr = RealUser();
            if (mbr.MemberId > 0)
            {
                LoadList();
                ddlAvatars.SelectedIndex = 0;
                LoadAvatars();
                btnSave.Text = LoadSLMF("SLMF_Avatar", "Update");
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
            lblUserName2.Text = mbr.UserName;
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
            else
            {
                imgAvatar.Src = "../SlmImages/vCard.png";
                
            }
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

    private void LoadAvatars()
    {
        int intCategory = int.Parse(ddlAvatars.SelectedValue.ToString());
        SqlDataReader v = BuAvatar.SelectAvatars(intCategory);
        dtlAvatars.DataSource = v;
        dtlAvatars.DataBind();
        if (v.IsClosed == false)
        {
            v.Close();
            v.Dispose();
        }
    }

    private void LoadList()
    {
        SqlDataReader v = BuAvatar.SelectDataList();
        ddlAvatars.DataSource = v;
        ddlAvatars.DataBind();
        if (v.IsClosed == false)
        {
            v.Close();
            v.Dispose();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EnMember mbr = new EnMember();
        EnAvatar av = new EnAvatar();
        mbr = RealUser();
        if (mbr.MemberId > 0)
        {
            if (txtUrl.Text != "")
            {
                string strUrl = txtUrl.Text.ToString().Trim();
                int test = 0;
                test = String.Compare(strUrl.Substring(0, 7), "http://");
                if (test == 1)
                {
                    strUrl = "http://" + strUrl;
                }
                av.Avatar = strUrl;
                BuAvatar.UpdateAvatar(av, mbr);
                imgAvatar.Src = strUrl;
            }
            else
            {
                string strImage = hddAva.Value;
                if (strImage != "")
                {
                    av.Avatar = strImage;
                    BuAvatar.UpdateAvatar(av, mbr);
                    imgAvatar.Src = "../slmuploads/avatar/" + strImage;
                }
            }
            lblReport.Text = LoadSLMF("SLMF_EditPro", "ReSave");
        }
    }
    protected void ddlAvatars_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAvatars();
    }
}
