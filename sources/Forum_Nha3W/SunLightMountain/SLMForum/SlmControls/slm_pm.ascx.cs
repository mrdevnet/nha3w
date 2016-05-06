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

public partial class SlmControls_slm_pm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grvPmMail.Attributes.Add("onclick", "GetSlmEnc();");
            grvPmMail2.Attributes.Add("onclick", "GetSlmEnc2();");
            btnSend.Attributes.Add("onclick", "GetSlmEnc3();");
            EnMember mbr = new EnMember();
            mbr = RealUser();
            if (mbr.MemberId > 0)
            {
                LoadPm(mbr);
                LoadPm2(mbr);
                int intId = mbr.MemberId;
                ProfileMember(intId);
                if (Request.Params["id"] != null && Request.Params["id"] != "")
                {
                    Int16 tabid = Int16.Parse(Request.Params["id"].ToString());
                    TabContainer2.ActiveTabIndex = tabid;
                }
                string strUserPm = UserPm();
                if (strUserPm != "")
                {
                    txtName.Text = strUserPm;
                }
                btnSend.Text = LoadSLMF("SLMF_Pm", "SendNew");
                btnFind.Text = LoadSLMF("SLMF_Pm", "Find");
                lblTitleSend.Text = LoadSLMF("SLMF_Pm", "Title");
                lblName.Text = LoadSLMF("SLMF_Pm", "Member");
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
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

    private void LoadPm(EnMember mbr)
    {
        DataTable dttp = new DataTable();
        dttp = BuPm.SelectPm(mbr);
        grvPmMail.DataSource = dttp;
        grvPmMail.DataBind();
    }

    public void LoadPmNew()
    {
        EnMember mbr = new EnMember();
        mbr = RealUser();
        DataTable dttp = new DataTable();
        dttp = BuPm.SelectPm(mbr);
        grvPmMail.DataSource = dttp;
        grvPmMail.DataBind();
    }

    private void LoadPm2(EnMember mbr)
    {
        DataTable dttp = new DataTable();
        dttp = BuPm.SelectPmFrMember(mbr);
        grvPmMail2.DataSource = dttp;
        grvPmMail2.DataBind();
    }

    public void LoadPm2New()
    {
        EnMember mbr = new EnMember();
        mbr = RealUser();
        DataTable dttp = new DataTable();
        dttp = BuPm.SelectPmFrMember(mbr);
        grvPmMail2.DataSource = dttp;
        grvPmMail2.DataBind();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
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
    protected void grvPmMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intId = int.Parse(grvPmMail.DataKeys[e.RowIndex].Value.ToString());
        BuPm.DeletePm(intId);
        EnMember mbr = new EnMember();
        mbr = RealUser();
        if (mbr.MemberId > 0)
        {
            LoadPm(mbr);
        }
        tdMessage.Visible = false;
        tdMessage2.Visible = false;
    }
    protected void grvPmMail_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvPmMail.SelectedRow;
        int intPm = int.Parse(grvPmMail.DataKeys[row.RowIndex].Value.ToString());
        tdMessage.Visible = true;
        tdMessage2.Visible = true;
        LoadPmMessage(intPm);
        BuPm.UpdatePmRead(intPm);
    }

    private void LoadPmMessage(int intId)
    {
        EnPm p = new EnPm();
        p = BuPm.SelectPmMessage(intId);
        lblTitle.Text = p.Title;
        lblTime.Text = "- [ " + AnnounceTime(p.Sent) + " ]";
        lblMessage.Text = p.Message;
    }

    private void LoadPmMessage2(int intId)
    {
        EnPm p = new EnPm();
        p = BuPm.SelectPmMessage(intId);
        lblTitle2.Text = p.Title;
        lblTime2.Text = "- [ " + AnnounceTime(p.Sent) + " ]";
        lblMessage2.Text = p.Message;
    }
    protected void grvPmMail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPmMail.PageIndex = e.NewPageIndex;
        EnMember mbr = new EnMember();
        mbr = RealUser();
        if (mbr.MemberId > 0)
        {
            LoadPm(mbr);
        }
        tdMessage.Visible = false;
        tdMessage2.Visible = false;
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    protected void grvPmMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate ||
                e.Row.RowState == DataControlRowState.Selected)
                    && (e.Row.RowType == DataControlRowType.DataRow))
        {
            bool n = bool.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[5].ToString());
            if (n==false)
            {
                HtmlImage imgNew = new HtmlImage();
                imgNew = (HtmlImage)e.Row.FindControl("imgPm");
                imgNew.Src = "../SlmImages/board_sn.gif";
            }
        }
    }

    protected void grvPmMail2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate ||
                e.Row.RowState == DataControlRowState.Selected)
                    && (e.Row.RowType == DataControlRowType.DataRow))
        {
            bool n = bool.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[5].ToString());
            if (n == false)
            {
                HtmlImage imgNew = new HtmlImage();
                imgNew = (HtmlImage)e.Row.FindControl("imgPm2");
                imgNew.Src = "../SlmImages/board_sn.gif";
            }
        }
    }
    protected void grvPmMail2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPmMail2.PageIndex = e.NewPageIndex;
        EnMember mbr = new EnMember();
        mbr = RealUser();
        if (mbr.MemberId > 0)
        {
            LoadPm2(mbr);
        }
        Tr1.Visible = false;
        Tr2.Visible = false;
    }
    protected void grvPmMail2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvPmMail2.SelectedRow;
        int intPm = int.Parse(grvPmMail2.DataKeys[row.RowIndex].Value.ToString());
        Tr2.Visible = true;
        Tr1.Visible = true;
        LoadPmMessage2(intPm);
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtTitleSend.Text != "" && txtReplyMsg.Text != "")
        {
            if (txtName.Text != "" && ddlName.Visible == false)
            {
                string strUser = txtName.Text.ToString().Trim();
                if (ExistMember(strUser))
                {
                    EnMember mbr1 = new EnMember();
                    EnMember mbr2 = new EnMember();
                    EnPm pmnew = new EnPm();
                    mbr1.UserName = LookCookie();
                    mbr2.UserName = strUser;
                    pmnew.Title = txtTitleSend.Text.ToString();
                    pmnew.Message = txtReplyMsg.Text.ToString();
                    BuPm.InsertPm(mbr1, mbr2, pmnew);
                    ResetControls();
                    lblSendaNew.Text = LoadSLMF("SLMF_Pm", "Successful");
                }
            }
            else if (ddlName.Visible == true)
            {
                string strUser = ddlName.SelectedValue.ToString();
                if (ExistMember(strUser))
                {
                    EnMember mbr1 = new EnMember();
                    EnMember mbr2 = new EnMember();
                    EnPm pmnew = new EnPm();
                    mbr1.UserName = LookCookie();
                    mbr2.UserName = strUser;
                    pmnew.Title = txtTitleSend.Text.ToString();
                    pmnew.Message = txtReplyMsg.Text.ToString();
                    BuPm.InsertPm(mbr1, mbr2, pmnew);
                    ResetControls();
                    lblSendaNew.Text = LoadSLMF("SLMF_Pm", "Successful");
                }
            }
        }
        else
        {
            lblSendaNew.Text = LoadSLMF("SLMF_Pm", "Require");
        }
    }

    private void ResetControls()
    {
        txtName.Text = "";
        txtTitleSend.Text = "";
        txtReplyMsg.Text = "";
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
