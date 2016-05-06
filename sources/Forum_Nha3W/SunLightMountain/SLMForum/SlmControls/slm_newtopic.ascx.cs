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

public partial class SlmControls_slm_newtopic : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool fa = false;
            if (Request.Params["forumid"] != null && Request.Params["TopicId"] == null && Request.Params["Post"] == "newtopic")
            {
                int intForumId = int.Parse(Request.Params["forumid"].ToString());
                LoadFirst(intForumId);
                Page.Title = lblForumTitle.Text + ". " + LoadText("TitleOfPage", "F9Light");
                string strUserName = LookCookie();
                Authorization(strUserName, intForumId, "Post", ref fa);
                btnPreview.Attributes.Add("onclick", "previewmessage();");
                lblNew.Text = LoadText("SLMF_Topic", "CreateNewTopic");
            }
            else if (Request.Params["ForumId"] != null && Request.Params["TopicId"] != null && Request.Params["Post"] == "newreply")
            {
                panelTitle.Visible = true;
                rowcreatepoll.Visible = false;
                rowpriority.Visible = false;
                int intForumId = int.Parse(Request.Params["forumid"].ToString());
                LoadFirst(intForumId);
                string strUserName = LookCookie();
                Authorization(strUserName, intForumId, "Reply", ref fa);
                btnPreview.Attributes.Add("onclick", "previewmessage();");
                int intTpcId = int.Parse(Request.Params["TopicId"].ToString());
                LoadSecond(intTpcId);
                lblNew.Text = LoadText("SLMF_Message", "CreateReplyMessage");
            }
            else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "newreply" && Request.Params["Quote"] == null)
            {
                panelTitle.Visible = true;
                rowcreatepoll.Visible = false;
                rowpriority.Visible = false;
                int intMsg = int.Parse(Request.Params["MessageId"].ToString());
                EnMessage msg = new EnMessage();
                msg.MessageId = intMsg;
                int intFrmId = BuMessage.SelectForumId(msg);
                LoadFirst(intFrmId);
                string strUserName = LookCookie();
                Authorization(strUserName, intFrmId, "Reply", ref fa);
                btnPreview.Attributes.Add("onclick", "previewmessage();");
                int intTpcId = BuMessage.SelectTopicId(msg);
                LoadSecond(intTpcId);
                lblNew.Text = LoadText("SLMF_Message", "CreateReplyMessage");
            }
            else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "editmessage")
            {
                panelTitle.Visible = true;
                rowpriority.Visible = false;
                int intMsg = int.Parse(Request.Params["MessageId"].ToString());
                EnMessage msg = new EnMessage();
                msg.MessageId = intMsg;
                int intFrmId = BuMessage.SelectForumId(msg);
                LoadFirst(intFrmId);
                string strUserName = LookCookie();
                Authorization(strUserName, intFrmId, "EditMsg", ref fa);
                btnPreview.Attributes.Add("onclick", "previewmessage();");
                int intTpcId = BuMessage.SelectTopicId(msg);
                LoadSecond(intTpcId);
                msg = BuMessage.SelectMessage(msg);
                FCKeditor1.Value = msg.Message;
                ckbAddSignature.Checked = msg.Signature;
                lblNew.Text = LoadText("SLMF_Message", "EditMessage");
            }
            else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "newreply" && Request.Params["Quote"] == "1")
            {
                panelTitle.Visible = true;
                rowpriority.Visible = false;
                int intMsg = int.Parse(Request.Params["MessageId"].ToString());
                EnMessage msg = new EnMessage();
                msg.MessageId = intMsg;
                int intFrmId = BuMessage.SelectForumId(msg);
                LoadFirst(intFrmId);
                string strUserName = LookCookie();
                Authorization(strUserName, intFrmId, "Quote", ref fa);
                btnPreview.Attributes.Add("onclick", "previewmessage();");
                int intTpcId = BuMessage.SelectTopicId(msg);
                LoadSecond(intTpcId);
                msg = BuMessage.SelectMessage(msg);
                FCKeditor1.Value = "[quote=" + msg.AuthorName + "]" + msg.Message + "[/quote]";
                ckbAddSignature.Checked = msg.Signature;
                lblNew.Text = LoadText("SLMF_Message", "CreateReplyMessage");
            }
            int a = 0;
            if (CanPostAgain(ref a))
            {
                btnSubmit.Attributes.Add("onclick", "alert('Vui lòng chờ thêm " + a + " giây nữa để gửi tiếp bài khác!');");
            }
        }
    }

    private void Authorization(string strUserName, int intForumId, string strCreate,ref bool fa)
    {
        fa = true;
        if ( strUserName == "")
        {
           strUserName = LoadText("SLMF_Reg", "UserGuest");
        }
        EnMember member = new EnMember();
        member.UserName = strUserName;
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;
        bool bolCreate = false;
        if (strCreate == "Post")
        {
            bolCreate = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Post").PostAuthor;
        }
        else if (strCreate == "Reply")
        {
            bolCreate = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Reply").ReplyAuthor;
        }
        else if (strCreate == "EditMsg")
        {
            bolCreate = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "EditMsg").EditMsgAuthor;
        }
        else if (strCreate == "Quote")
        {
            bolCreate = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Quote").QuoteMsgAuthor;
        }
        if (Moder() || IsSuperModer() || IsAdmin())
        {
            bolCreate = true;
        }
        if (!bolCreate)
        {
            fa = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">alert('" + LoadText("SLMF_Topic", "NotHaveSetCurrent") + "');window.location.href='../login.aspx'</script>");
        }
        bool bolPoll = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Poll").PollAuthor;
        bool bolPriority = BuModerator.SelectExistModer(forum, member, "Sticky").StickTopicAuthor;
        //bool bolSignature = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "AlSig").AlwaysSig;
        //check permission f\of signature
        if (bolPoll || IsSuperModer() || IsAdmin())
        {
            rowcreatepoll.Visible = true;
        }
        if (bolPriority || IsSuperModer() || IsAdmin())
        {
            rowpriority.Visible = true;
        }
        //if (bolSignature || IsSuperModer() || IsAdmin())
        //{
        //    ckbAddSignature.Checked = true;
        //check permission f\of signature
        //}
    }

    private bool Moder()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["forumid"] != null || Request.Params["topicid"] != null || 
            Request.Params["MessageId"] != null) && strMbr != "")
        {
            EnForum frm = new EnForum();
            EnMember mbr = new EnMember();
            if (Request.Params["forumid"] != null)
            {
                frm.ForumId = int.Parse(Request.Params["forumid"].ToString());
            }
            else
            {
                int intTopicId = RequestId();
                EnTopic topic = new EnTopic();
                topic.TopicId = intTopicId;
                frm = BuTopic.SelectForumId(topic);
            }
            mbr.UserName = strMbr;
            a = BuMember.IsModer2(mbr, frm);
        }
        return a;
    }

    public int RequestId()
    {
        int intTopicId = 0;
        if (Request.Params["TopicId"] != null)
        {
            intTopicId = int.Parse(Request.Params["TopicId"].ToString());
        }
        else if (Request.Params["MessageId"] != null)
        {
            int intMessageId = int.Parse(Request.Params["MessageId"].ToString());
            EnMessage n = new EnMessage();
            n.MessageId = intMessageId;
            intTopicId = BuMessage.SelectTopicId(n);
        }
        return intTopicId;
    }

    private bool IsSuperModer()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["forumid"] != null || Request.Params["topicid"] != null || 
            Request.Params["MessageId"] != null) && strMbr != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strMbr;
            a = BuMember.IsSuperModer(mbr);
        }
        return a;
    }

    private bool IsAdmin()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["forumid"] != null || Request.Params["topicid"] != null || 
            Request.Params["MessageId"] != null) && strMbr != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strMbr;
            a = BuMember.IsAdmin(mbr);
        }
        return a;
    }

    private bool InsertNewTopic(string strUserName, int intForumId, string strMsg)
    {
        bool intInsert = true;

        EnMember member = new EnMember();
        EnForum forum = new EnForum();
        member.UserName = strUserName;
        forum.ForumId = intForumId;
        
        EnTopic topic = new EnTopic();
        EnMessage message = new EnMessage();
        topic.IsApproved = BuMemberAuthorize.SelectMemberAuthorize(member, forum,"Approve").IsApproved;
        if (Moder() || IsSuperModer() || IsAdmin())
        {
            topic.IsApproved = true;
        }
        if (rdoNormal.Checked)
        {
            topic.IsPinned = false;
        }
        else if (rdoSticky.Checked)
        {
            topic.IsPinned = true;
        }
        message.Title = txtSubject.Text.ToString();
        message.Message = strMsg;
        message.IP = Request.ServerVariables["REMOTE_ADDR"];
        bool bolSignaure = false;
        if (ckbAddSignature.Checked)
        {
            bolSignaure = true;
        }
        message.Signature = bolSignaure;
        try
        {
            int a = BuTopic.InsertTopic(member, forum, topic, message);
            InsertPoll(a);
        }
        catch
        {
            intInsert = false;
        }
        return intInsert;
    }

    private void InsertPoll(int tpc)
    {
        if (txtQuestion.Text != "" && txtChoice1.Text != "" && txtChoice2.Text != "")
        {
            EnPoll poll = new EnPoll();
            EnTopic tpcnew = new EnTopic();
            tpcnew.TopicId = tpc;
            poll.Title = txtQuestion.Text.ToString();
            poll.NumberOfFinish = 0;
            poll.Repeat = false;
            if (txtPollDays.Text != "")
            {
                poll.NumberOfFinish = int.Parse(txtPollDays.Text.ToString());
            }
            else
            {
                poll.Repeat = true;
            }
            string str1 = "";
            str1 = txtChoice1.Text.ToString();
            string str2 = "";
            str2 = txtChoice2.Text.ToString();
            string str3 = "";
            str3 = txtChoice3.Text.ToString();
            string str4 = "";
            str4 = txtChoice4.Text.ToString();
            string str5 = "";
            str5 = txtChoice5.Text.ToString();
            string str6 = "";
            str6 = txtChoice6.Text.ToString();
            string str7 = "";
            str7 = txtChoice7.Text.ToString();
            string str8 = "";
            str8 = txtChoice8.Text.ToString();
            string str9 = "";
            str9 = txtChoice9.Text.ToString();
            BuPoll.InsertPoll(poll, tpcnew, str1, str2, str3, 
                                str4, str5, str6, str7, str8, str9);
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

            EnMemberProfile pro = new EnMemberProfile();
            BuMemberProfile.SelectAlSign(member, ref pro);
            ckbAddSignature.Checked = pro.AlwaysSig;
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
            if (Request.Params["Post"] == "editmessage")
            {
                txtSubject.Text = strTitle;
            }
            else
            {
                txtSubject.Text = LoadText("SLMF_Message", "ReplyTitle") + strTitle;
            }
        }
    }

    private void LoadFirst(int intForumId)
    {
        lbtCreatePoll.Text = LoadText("SLMF_Topic", "CreatePoll1");
        rdoNormal.Text = LoadText("SLMF_Topic", "PriNormal");
        rdoSticky.Text = LoadText("SLMF_Topic", "ProSticky");
        btnPreview.Text = LoadText("SLMF_Topic", "btnPreview");
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

    public string LoadText(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void lbtCreatePoll_Click(object sender, EventArgs e)
    {
        if (pnlPoll.Visible == false)
        {
            pnlPoll.Visible = true;
            lbtCreatePoll.Text = LoadText("SLMF_Topic", "CreatePoll2");
        }
        else
        {
            pnlPoll.Visible = false;
            lbtCreatePoll.Text = LoadText("SLMF_Topic", "CreatePoll1");
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        rowpreview.Visible = true;
        string strTemp = FCKeditor1.Value.ToString();
        strTemp = FormatContent(strTemp);
        string strValue = "<b>" + txtSubject.Text.ToString() + "</b><br/>" + strTemp;
        previewcell.InnerHtml = strValue;
        this.Page.MaintainScrollPositionOnPostBack = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        EnConfig cg = new EnConfig();
        BuConfiguration.SelectConfiguration(ref cg);
        string strMsg = FCKeditor1.Value.ToString().Trim();
        while (strMsg.Replace("&nbsp;", " ").Length > 6 && strMsg.Contains("&nbsp;"))
        {
            strMsg = strMsg.Replace("&nbsp;", " ").Trim();
            while (strMsg.Contains("  "))
            {
                strMsg = strMsg.Replace("  ", " ").Trim();
            }
        }
        if (strMsg != "" && strMsg.Length >= cg.MaxMsg)
        {
            if (Session["CanPostAgain"] != null && Session["CanPostAgain"].ToString() != ""
                && bool.Parse(Session["CanPostAgain"].ToString()) == false)
            {
                if (Request.Params["forumid"] != null && Request.Params["TopicId"] == null && Request.Params["Post"] == "newtopic")
                {
                    int intForumId = int.Parse(Request.Params["forumid"].ToString());
                    Response.Redirect("topicdisplay.aspx?forumid=" + intForumId);
                }
                else
                {
                    int intTopicId = RequestIdX();
                    EnTopic t = new EnTopic();
                    t.TopicId = intTopicId;
                    int intMessage = BuTopic.SelectLastMessage(t);
                    Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                }
            }
            else
            {
                bool fa = false;
                if (Request.Params["forumid"] != null && Request.Params["TopicId"] == null && Request.Params["Post"] == "newtopic")
                {
                    string strUserName = LookCookie();
                    if (strUserName == "")
                    {
                        strUserName = LoadText("SLMF_Reg", "UserGuest");
                    }
                    if (strUserName != "")
                    {
                        int intForumId = int.Parse(Request.Params["forumid"].ToString());
                        Authorization(strUserName, intForumId, "Post", ref fa);
                        if (fa)
                        {
                            bool bolResult = InsertNewTopic(strUserName, intForumId, strMsg);
                            if (bolResult)
                            {
                                EnTopic t = new EnTopic();
                                EnForum fn = new EnForum();
                                fn.ForumId = intForumId;
                                t.TopicId = BuForum.SelectTopicInF(fn);
                                int intMessage = BuTopic.SelectLastMessage(t);
                                FCKeditor1.Value = "";
                                txtSubject.Text = "";
                                Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                            }
                        }
                    }
                }
                else if (Request.Params["forumid"] != null && Request.Params["TopicId"] != null && Request.Params["Post"] == "newreply")
                {
                    string strUserName = LookCookie();
                    if (strUserName == "")
                    {
                        strUserName = LoadText("SLMF_Reg", "UserGuest");
                    }
                    if (strUserName != "")
                    {
                        int intTopicId = int.Parse(Request.Params["TopicId"].ToString());
                        int intForumId = int.Parse(Request.Params["ForumId"].ToString());
                        Authorization(strUserName, intForumId, "Reply", ref fa);
                        if (fa)
                        {
                            bool bolResult = InsertMessage(strUserName, intTopicId, intForumId, strMsg);
                            if (bolResult)
                            {
                                EnTopic t = new EnTopic();
                                t.TopicId = intTopicId;
                                int intMessage = BuTopic.SelectLastMessage(t);
                                FCKeditor1.Value = "";
                                Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                            }
                        }
                    }
                }
                else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "newreply" && Request.Params["Quote"] == null)
                {
                    string strUserName = LookCookie();
                    if (strUserName == "")
                    {
                        strUserName = LoadText("SLMF_Reg", "UserGuest");
                    }
                    if (strUserName != "")
                    {
                        int intMsgId = int.Parse(Request.Params["MessageId"].ToString());
                        EnMessage Msg = new EnMessage();
                        Msg.MessageId = intMsgId;
                        int intTpcId = BuMessage.SelectTopicId(Msg);
                        int intForumId = BuMessage.SelectForumId(Msg);
                        Authorization(strUserName, intForumId, "Reply", ref fa);
                        if (fa)
                        {
                            bool bolResult = InsertMessage(strUserName, intTpcId, intForumId, strMsg);
                            if (bolResult)
                            {
                                EnTopic t = new EnTopic();
                                t.TopicId = intTpcId;
                                int intMessage = BuTopic.SelectLastMessage(t);
                                FCKeditor1.Value = "";
                                Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                            }
                        }
                    }
                }
                else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "editmessage" && Request.Params["RowId"] != null)
                {
                    string strUserName = LookCookie();
                    if (strUserName == "")
                    {
                        strUserName = LoadText("SLMF_Reg", "UserGuest");
                    }
                    if (strUserName != "")
                    {
                        int intMsgId = int.Parse(Request.Params["MessageId"].ToString());
                        int intRowId = int.Parse(Request.Params["RowId"].ToString());
                        EnMessage msg = new EnMessage();
                        msg.MessageId = intMsgId;
                        int intFrmId = BuMessage.SelectForumId(msg);
                        Authorization(strUserName, intFrmId, "EditMsg", ref fa);
                        if (fa)
                        {
                            bool bolResult = UpdateMessage(strUserName, intMsgId, strMsg);
                            if (bolResult)
                            {
                                FCKeditor1.Value = "";
                                Response.Redirect("showtopic.aspx?RowId=" + intRowId + "&messageid=" + intMsgId + "#message" + intMsgId);
                            }
                        }
                    }
                }
                else if (Request.Params["MessageId"] != null && Request.Params["Post"] == "newreply" && Request.Params["Quote"] == "1")
                {
                    string strUserName = LookCookie();
                    if (strUserName == "")
                    {
                        strUserName = LoadText("SLMF_Reg", "UserGuest");
                    }
                    if (strUserName != "")
                    {
                        int intMsgId = int.Parse(Request.Params["MessageId"].ToString());
                        EnMessage Msg = new EnMessage();
                        Msg.MessageId = intMsgId;
                        int intTpcId = BuMessage.SelectTopicId(Msg);
                        int intForumId = BuMessage.SelectForumId(Msg);
                        Authorization(strUserName, intForumId, "Quote", ref fa);
                        if (fa)
                        {
                            bool bolResult = InsertMessage(strUserName, intTpcId, intForumId, strMsg);
                            if (bolResult)
                            {
                                EnTopic t = new EnTopic();
                                t.TopicId = intTpcId;
                                int intMessage = BuTopic.SelectLastMessage(t);
                                FCKeditor1.Value = "";
                                Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + string.Format(LoadText("SLMF_Message", "MaxMessage"), cg.MaxMsg).ToString() + "');</script>");
            //this.location.href='showtopic.aspx?topicid=" + intTopicId + "#quickrepl';
        }
    }

    private int RequestIdX()
    {
        int intTopicId = 0;
        if (Request.Params["TopicId"] != null)
        {
            intTopicId = int.Parse(Request.Params["TopicId"].ToString());
        }
        else if (Request.Params["MessageId"] != null)
        {
            int intMessageId = int.Parse(Request.Params["MessageId"].ToString());
            EnMessage n = new EnMessage();
            n.MessageId = intMessageId;
            intTopicId = BuMessage.SelectTopicId(n);
        }
        return intTopicId;
    }

    private string FormatContent(string strContent)
    {
        strContent = UtiString.FormatBody(strContent);
        return strContent;
    }

    private bool InsertMessage(string strUserName, int intTopicId, int intForumId, string strMsg)
    {
        bool intInsert = true;
        EnMember member = new EnMember();
        member.UserName = strUserName;
        EnMessage msg = new EnMessage();
        msg.TopicId = intTopicId;
        msg.Title = txtSubject.Text.ToString();
        msg.Message = strMsg;
        msg.Message = FormatContent(msg.Message);
        msg.IP = Request.ServerVariables["REMOTE_ADDR"];
        EnTopic t = new EnTopic();
        t.TopicId = intTopicId;
        EnForum f = new EnForum();
        if (intForumId != 0)
        {
            f.ForumId = intForumId;
        }
        else
        {
            f = BuTopic.SelectForumId(t);
        }
        msg.IsApproved = BuMemberAuthorize.SelectMemberAuthorize(member, f, "Approve").IsApproved;
        if (Moder() || IsSuperModer() || IsAdmin())
        {
            msg.IsApproved = true;
        }
        msg.Signature = ckbAddSignature.Checked;
        try
        {
            BuMessage.InsertMessage(msg, member);
        }
        catch
        {
            intInsert = false;
        }
        return intInsert;
    }

    private bool UpdateMessage(string strUserName, int intMessageId, string strMsg)
    {
        bool intInsert = true;
        EnMember member = new EnMember();
        member.UserName = strUserName;
        EnMessage msg = new EnMessage();
        msg.MessageId = intMessageId;
        msg.Title = txtSubject.Text.ToString();
        msg.Message = strMsg;
        msg.Signature = ckbAddSignature.Checked;
        try
        {
            BuMessage.UpdateMessage(msg, member);
        }
        catch
        {
            intInsert = false;
        }
        return intInsert;
    }

    private bool CanPostAgain(ref int a)
    {
        bool canpost = false;
        string strId = LookCookie();
        if (strId == "")
        {
            strId = LoadText("SLMF_Reg", "UserGuest");
        }
        if (strId != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strId;
            if (!BuModerator.SelectIsModer(mbr) && !IsSuperModer() && !IsAdmin() && BuConfiguration.SelectPostAgain() > 0)
            {
                EnMemberProfile pro = new EnMemberProfile();
                mbr = BuMember.SelectMemberIdFUser(mbr);
                BuMemberProfile.LastPosted(mbr, ref pro);
                if (pro.Posted > DateTime.Now.AddSeconds(-BuConfiguration.SelectPostAgain()))
                {
                    canpost = true;
                    Session["CanPostAgain"] = false;
                    a = (pro.Posted - DateTime.Now.AddSeconds(-BuConfiguration.SelectPostAgain())).Seconds;
                }
                else
                {
                    Session["CanPostAgain"] = true;
                }
            }
            else
            {
                Session["CanPostAgain"] = true;
            }
        }
        return canpost;
    }
}
