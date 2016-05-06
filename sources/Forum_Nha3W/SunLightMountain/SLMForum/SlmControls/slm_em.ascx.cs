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

public partial class SlmControls_slm_em : System.Web.UI.UserControl
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
                string strUserPm = UserPm();
                if (strUserPm != "")
                {
                    txtName.Text = strUserPm;
                }
                btnSend.Text = LoadSLMF("SLMF_CPUser", "EmailNew");
                btnFind.Text = LoadSLMF("SLMF_Pm", "Find");
                lblTitleSend.Text = LoadSLMF("SLMF_Pm", "Title");
                lblName.Text = LoadSLMF("SLMF_Pm", "Member");
            }
            else
            {
                //Response.Redirect("login.aspx");
                Response.Redirect("../login.aspx");
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

    private string UserPm()
    {
        EnMember mbr = new EnMember();
        if (Request.Params["MemberId"] != null)
        {
            int intId = int.Parse(Request.Params["MemberId"].ToString());
            mbr.MemberId = intId;
            BuMember.SelectMemberFromId(ref mbr);
        }
        return mbr.UserName;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtTitleSend.Text != "" && txtReplyMsg.Text != "")
        {
            string strFrom = ConfigurationManager.AppSettings["FromMail"];
            if (txtName.Text != "" && ddlName.Visible == false)
            {
                string strUser = txtName.Text.ToString().Trim();
                if (ExistMember(strUser))
                {
                    EnMember mbr1 = new EnMember();
                    EnMember mbr2 = new EnMember();
                    EnEm pmnew = new EnEm();
                    mbr1.UserName = LookCookie();
                    mbr2.UserName = strUser;
                    pmnew.Title = txtTitleSend.Text.ToString();
                    pmnew.Message = txtReplyMsg.Text.ToString();
                    BuEm.InsertEm(mbr1, mbr2, pmnew);
                    EnMemberProfile pro = new EnMemberProfile();
                    BuMemberProfile.SelectCanSendE(ref mbr2, ref pro);
                    if (pro.CanSendE)
                    {
                        UtiGeneralClass clsNew = new UtiGeneralClass();
                        bool bolSend = clsNew.clies(mbr2.Email, pmnew.Title, pmnew.Message);
                        //bool bolSend = clsNew.SendMailSmtpClient(strFrom, mbr2.Email, pmnew.Title, pmnew.Message);
                        if (bolSend)
                        {
                            lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "Successful");
                        }
                        else
                        {
                            lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "NotSuccessful");
                        }
                    }
                    else
                    {
                        lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "NotReceiveEmail");
                    }
                    ResetControls();
                    return;
                }
            }
            else if (ddlName.Visible == true)
            {
                string strUser = ddlName.SelectedValue.ToString();
                if (ExistMember(strUser))
                {
                    EnMember mbr1 = new EnMember();
                    EnMember mbr2 = new EnMember();
                    EnEm pmnew = new EnEm();
                    mbr1.UserName = LookCookie();
                    mbr2.UserName = strUser;
                    pmnew.Title = txtTitleSend.Text.ToString();
                    pmnew.Message = txtReplyMsg.Text.ToString();
                    BuEm.InsertEm(mbr1, mbr2, pmnew);
                    EnMemberProfile pro = new EnMemberProfile();
                    BuMemberProfile.SelectCanSendE(ref mbr2, ref pro);
                    if (pro.CanSendE)
                    {
                        UtiGeneralClass clsNew = new UtiGeneralClass();
                        bool bolSend = clsNew.clies(mbr2.Email, pmnew.Title, pmnew.Message);
                        //bool bolSend = clsNew.SendMailSmtpClient(strFrom, mbr2.Email, pmnew.Title, pmnew.Message);
                        if (bolSend)
                        {
                            lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "Successful");
                        }
                        else
                        {
                            lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "NotSuccessful");
                        }
                    }
                    else
                    {
                        lblSendaNew.Text = LoadSLMF("SLMF_SendAEmail", "NotReceiveEmail");
                    }
                    ResetControls();
                    return;
                }
            }
        }
        else
        {
            lblSendaNew.Text = LoadSLMF("SLMF_Pm", "Require");
        }
    }

    private bool ExistMember(string strUser)
    {
        int intResult = 0;
        bool send = false;
        UtiGeneralClass error = new UtiGeneralClass();
        EnMember member = new EnMember();
        member.UserName = strUser;
        intResult = BuMember.MemberLogin(member);
        if (intResult == -1)
        {
            lblSendaNew.Text = error.LoadLangs("SLMF_Pm", "NotExistMember");
        }
        else if (intResult == -2)
        {
            lblSendaNew.Text = error.LoadLangs("SLMF_Pm", "NotAllowLogin");
        }
        else if (intResult == -3)
        {
            lblSendaNew.Text = error.LoadLangs("SLMF_Pm", "NotAllowLogin");
        }
        else if (intResult == -5)
        {
            lblSendaNew.Text = error.LoadLangs("SLMF_Pm", "NotAllowLogin");
        }
        else if (intResult == -4)
        {
            lblSendaNew.Text = error.LoadLangs("SLMF_Pm", "NotAllowLogin");
        }
        else
        {
            send = true;
        }
        return send;
    }

    private void ResetControls()
    {
        txtName.Text = "";
        txtTitleSend.Text = "";
        txtReplyMsg.Text = "";
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (ddlName.Visible == false)
        {
            if (txtName.Text != "")
            {
                bool find = FindMember(txtName.Text.ToString().Trim());
                if (find)
                {
                    ddlName.Visible = true;
                    txtName.Visible = false;
                    btnFind.Text = LoadSLMF("SLMF_Pm", "Clear");
                }
            }
        }
        else
        {
            btnFind.Text = LoadSLMF("SLMF_Pm", "Find");
            txtName.Visible = true;
            ddlName.Visible = false;
            ddlName.Items.Clear();
        }
    }

    private bool FindMember(string UserName)
    {
        bool find = false;
        EnMember mbr = new EnMember();
        mbr.UserName = UserName;
        SqlDataReader r = BuPm.SelectFindMember(mbr);
        if (r.HasRows)
        {
            find = true;
            ddlName.DataSource = r;
            ddlName.DataBind();
        }
        if (r.IsClosed == false)
        {
            r.Close();
            r.Dispose();
        }
        return find;
    }
}
