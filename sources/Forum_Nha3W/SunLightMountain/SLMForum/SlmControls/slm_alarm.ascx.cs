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

public partial class SlmControls_slm_alarm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["MessageId"] != null && Request.Params["RowId"] != null)
            {
                int intMsg = int.Parse(Request.Params["MessageId"].ToString());
                EnMessage msg = new EnMessage();
                msg.MessageId = intMsg;
                int intFrmId = BuMessage.SelectForumId(msg);
                LoadFirst(intFrmId);
                string strUserName = LookCookie();
                Authorization(strUserName, intFrmId);
                int intTpcId = BuMessage.SelectTopicId(msg);
                LoadSecond(intTpcId);
            }
            LoadDdlPrio();
        }
        btnSubmit.Attributes.Add("onclick", "return submitvalidate();");
    }

    private void LoadFirst(int intForumId)
    {
        btnSubmit.Text = LoadText("SLMF_Topic", "btnSubmit");
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;
        EnCategory cate = new EnCategory();
        BuForum.SelectForumInCate(ref forum, ref cate);
        hplCategory.InnerHtml = cate.CateName;
        hplCategory.HRef = "../forumdisplay.aspx?groupid=" + cate.CategoryId;
        hplForum.InnerHtml = forum.Name;
        hplForum.HRef = "../topicdisplay.aspx?forumid=" + forum.ForumId;

        EnForum frm1 = new EnForum();
        frm1.ForumId = intForumId;
        if (BuForum.SelectPafrm(ref frm1))
        {
            parf1.InnerHtml = frm1.Name;
            parf1.HRef = "../topicdisplay.aspx?forumid=" + frm1.ForumId;
            //parf2.InnerHtml = frm1.Name;
            //parf2.HRef = "../topicdisplay.aspx?forumid=" + frm1.ForumId;
            panelparf1.Visible = true;
            //panelparf2.Visible = true;
        }
        lblForumTitle.Text = forum.Name;
    }

    private void LoadSecond(int intTopicId)
    {
        EnTopic topic = new EnTopic();
        topic.TopicId = intTopicId;
        SqlDataReader datr = BuTopic.SelectTopicLinks(topic);
        CreateDatr(datr);
        if (datr.IsClosed == false)
        {
            datr.Close();
            datr.Dispose();
        }
    }

    private void CreateDatr(IDataReader reader)
    {
        if (reader.Read())
        {
            string strTitle = reader["Title"].ToString();
            lblForumTitle.Text = strTitle;
            lblTopicTitle1.Text = strTitle;
            Page.Title = strTitle + ". " + LoadText("TitleOfPage", "F9Light");
        }
    }

    private void Authorization(string strUserName, int intForumId)
    {
        if (strUserName == "")
        {
            strUserName = LoadText("SLMF_Reg", "UserGuest");
        }
        EnMember member = new EnMember();
        member.UserName = strUserName;
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;

        bool bolCreate = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Report").ReportAuthor;
        if (!bolCreate)
        {
            //Response.Redirect("login.aspx");
            Response.Redirect("../login.aspx");
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

            hrfMember.InnerHtml = strUser;
            EnMember member = new EnMember();
            member.UserName = strUser;
            member = BuMember.SelectMemberIdFUser(member);
            hrfMember.HRef = "../showprofile.aspx?memberid=" + member.MemberId;
        }
        else
        {
            strUser = LoadText("SLMF_Reg", "UserGuest");
            hrfMember.InnerHtml = strUser;
            EnMember member = new EnMember();
            member.UserName = strUser;
            member = BuMember.SelectMemberIdFUser(member);
            hrfMember.HRef = "../showprofile.aspx?memberid=" + member.MemberId;
        }
        return strUser;
    }

    public string LoadText(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadDdlPrio()
    {
        SqlDataReader dtr = BuPriority.SelectPriority();
        ddlPriority.DataSource = dtr;
        ddlPriority.DataBind();
        if (dtr.IsClosed == false)
        {
            dtr.Close();
            dtr.Dispose();
        }
        ddlPriority.SelectedIndex = 0;
    }

    private void InsertAlarms()
    {
        if (Request.Params["MessageId"] != null && Request.Params["RowId"] != null &&
                        txtSubject.Text != "" && FCKeditor1.Value != "")
        {
            int intMsg = int.Parse(Request.Params["MessageId"].ToString());
            int intRowId = int.Parse(Request.Params["RowId"].ToString());
            EnAlarm alarm = new EnAlarm();
            alarm.Title = txtSubject.Text.ToString();
            alarm.Report = FCKeditor1.Value.ToString();
            alarm.Priority = int.Parse(ddlPriority.SelectedValue.ToString());
            alarm.MessageId = intMsg;
            EnMember mbr = new EnMember();
            mbr.UserName = hrfMember.InnerText.ToString();
            mbr = BuMember.SelectMemberIdFUser(mbr);
            alarm.MemberId = mbr.MemberId;
            BuAlarm.InsertAlarm(alarm);
            ResetControls();
            string strCode = LoadText("SLMF_Report", "Sent");
            string strPage = "showtopic.aspx?RowId=" + intRowId + "&messageid=" + intMsg + "#message" + intMsg;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + strCode + "');window.location.href='" + strPage + "';</script>");
            //Response.Redirect("showtopic.aspx?RowId=" + intRowId + "&messageid=" + intMsg + "#message" + intMsg);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + LoadText("SLMF_Report", "Form2Validate") + "')</script>");
        }
    }

    private void ResetControls()
    {
        txtSubject.Text = "";
        FCKeditor1.Value = "";
        LoadDdlPrio();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertAlarms();
    }
}
