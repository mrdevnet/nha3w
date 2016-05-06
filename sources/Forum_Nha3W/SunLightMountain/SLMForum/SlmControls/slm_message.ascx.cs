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
using System.Data.Common;
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;
using System.Xml;
using System.IO;
using System.Net;

public partial class SlmControls_slm_message : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["Goto"] != null && Request.Params["TopicId"] != null)
            {
                int tpcid = int.Parse(Request.Params["TopicId"].ToString());
                EnTopic tpc = new EnTopic();
                tpc.TopicId = tpcid;
                int intMessage = BuTopic.SelectLastMessage(tpc);
                Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                return;
            }
            else if (Request.Params["topicid"] != null || Request.Params["MessageId"] != null)
            {
                int intTopicId = RequestId();
                EnTopic tpcn = new EnTopic();
                tpcn.TopicId = intTopicId;
                if (Request.Params["PageId"] == null)
                {
                    BuTopic.UpdateViews(tpcn);
                }
                int intSumRows = BuTopic.SelectItemCount(tpcn);
                int intMaxRecords = PMessage1.PageSize;
                int intItems = 0;
                if (intSumRows % intMaxRecords > 0)
                {
                    intItems = (intSumRows / intMaxRecords) + 1;
                }
                else
                {
                    intItems = (intSumRows / intMaxRecords);
                }

                if (Request.Params["TopicId"] != null && Request.Params["PageId"] == null)
                {
                    PMessage1.CurrentIndex = 1;
                    PMessage2.CurrentIndex = 1;
                }
                else if (Request.Params["TopicId"] != null && Request.Params["MessageId"] == null &&
                            Request.Params["PageId"] != null)
                {
                    PMessage1.CurrentIndex = int.Parse(Request.Params["PageId"].ToString());
                    PMessage2.CurrentIndex = int.Parse(Request.Params["PageId"].ToString());
                }
                else if (Request.Params["MessageId"] != null && Request.Params["TopicId"] == null &&
                            Request.Params["RowId"] == null)
                {
                    PMessage1.CurrentIndex = intItems;
                    PMessage2.CurrentIndex = intItems;
                }
                else if (Request.Params["MessageId"] != null && Request.Params["TopicId"] == null &&
                       Request.Params["RowId"] != null)
                {
                    int intRowId = int.Parse(Request.Params["RowId"].ToString());
                    int intIndexId = (intRowId % intMaxRecords);
                    if (intIndexId != 0)
                    {
                        intIndexId = (intRowId / intMaxRecords) + 1;
                    }
                    else
                    {
                        intIndexId = (intRowId / intMaxRecords);
                    }
                    PMessage1.CurrentIndex = intIndexId;
                    PMessage2.CurrentIndex = intIndexId;
                }

                if (Moder("LckTopic").LockTopicAuthor || IsSuperModer() || IsAdmin())
                {
                    LockTopic1.Visible = true;
                    LockTopic2.Visible = true;
                }
                if (Moder("UnLck").UnLockTopic || IsSuperModer() || IsAdmin())
                {
                    UnLockTopic1.Visible = true;
                    UnLockTopic2.Visible = true;
                }
                if (Atr("Reply").ReplyAuthor || 
                    (Atr("Reply").ReplyAuthor && Moder()) || 
                    IsAdmin() || IsSuperModer())
                {
                    rowQuick.Visible = true;
                    rowTitleQuick.Visible = true;
                }
                hrfNewMsg1.HRef = "../newmessage.aspx?post=newreply&topicid=" + RequestId() + "&forumid=" + RequestForum();
                hrfNewTpc1.HRef = "../newtopic.aspx?post=newtopic&forumid=" + RequestForum();
                hrfNewMsg2.HRef = "../newmessage.aspx?post=newreply&topicid=" + RequestId() + "&forumid=" + RequestForum();
                hrfNewTpc2.HRef = "../newtopic.aspx?post=newtopic&forumid=" + RequestForum();
                BindMessage(intTopicId, PMessage1.CurrentIndex);
                TopicLinks(intTopicId);
                if (Moder("Move").MoveTopicAuthor || IsSuperModer() || IsAdmin())
                {
                    hrfMoveTopic1.Visible = true;
                    hrfMoveTopic1.Attributes.Add("onclick", "javascript:window.open('movetopic.aspx?topicid=" + intTopicId +
                                    "','calwin','top=308,left=391,width=380,height=164,scrollbars=1')");

                    hrfMoveTopic2.Visible = true;
                    hrfMoveTopic2.Attributes.Add("onclick", "javascript:window.open('movetopic.aspx?topicid=" + intTopicId +
                                    "','calwin','top=308,left=391,width=380,height=164,scrollbars=1')");
                }
                if ((Atr("DelTopic").DeleteTopicAuthor && Moder()) || IsSuperModer() || IsAdmin())
                {
                    DeleteTopic1.Visible = true;
                    DeleteTopic2.Visible = true;
                }
                if (Atr("Vote").VoteAuthor || 
                    (Atr("Vote").VoteAuthor && Moder()) || 
                    IsSuperModer() || IsAdmin())
                {
                    bool v = VoteRes(intTopicId,true);
                    bool p = PollResult(intTopicId, v);
                    if (p)
                    {
                        rowPoll.Visible = true;
                        rowPoll2.Visible = true;
                        btnSubmit.Text = LoadText("SLMF_Poll", "Vote");
                    }
                }
                else if (Atr("Vote").VoteAuthor == false)
                {
                    bool v = VoteRes(intTopicId,false);
                    bool p = PollResult(intTopicId, v);
                    if (p)
                    {
                        rowPoll.Visible = true;
                        rowPoll2.Visible = true;
                        btnSubmit.Text = LoadText("SLMF_Poll", "Vote");
                    }
                }
                EnForum frm = new EnForum();
                frm = null;
                EnTopic tpc = new EnTopic();
                tpc.TopicId = intTopicId;
                LoadDatas(frm, tpc);
            }
            PreSender();
            HasMsgNex();
            HasMsgPre();
            int a=0;
            if (CanPostAgain(ref a))
            {
                QuickReply.Attributes.Add("onclick", "alert('Vui lòng chờ thêm " + a + " giây nữa để gửi tiếp bài khác!');");
            }
        }
        DeleteTopic1.Attributes.Add("onclick", "return confirmdeltpc();");
        DeleteTopic2.Attributes.Add("onclick", "return confirmdeltpc();");
        LockTopic1.Attributes.Add("onclick", "return confirmlcktpc();");
        LockTopic2.Attributes.Add("onclick", "return confirmlcktpc();");
        UnLockTopic1.Attributes.Add("onclick", "return confirmunlcktpc();");
        UnLockTopic2.Attributes.Add("onclick", "return confirmunlcktpc();");
    }

    private bool PollResult(int intTopic, bool v)
    {
        bool bolRus = false;
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopic;
        EnPoll poll = new EnPoll();
        SqlDataReader r = BuPoll.SelectPollRus(tpc, ref bolRus, ref poll);
        if (bolRus && v == false)
        {
            rlPoll.DataSource = r;
            rlPoll.DataBind();
            lblTitlePoll.Text = poll.Title;
            lblTitlePoll2.Text = poll.Title;
            lblTotalPoll.Text = "[" + poll.Total + "]";
            //hrfResPoll.HRef = "../poll.aspx?post=showresults&topicid=" + intTopic;
        }
        if (r != null && r.IsClosed == false)
        {
            r.Close();
            r.Dispose();
        }
        return bolRus;
    }

    private bool VoteRes(int intTopic, bool permission)
    {
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopic;
        int max = 0;
        bool v = false;
        string strId = LookCookie();
        if (strId == "")
        {
            strId = LoadText("SLMF_Reg", "UserGuest");
        }
        if (strId != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strId;
            int countsum = 0;
            EnPoll poll = new EnPoll();
            SqlDataReader r = BuPoll.SelectVoteRes(tpc, ref max, mbr, ref countsum, ref poll);
            lblTitlePoll.Text = poll.Title;
            if (max == -2)
            {
                dv1.Visible = false;
                lblPermission.Text = LoadText("SLMF_Poll", "Voted");
                v = true;
            }
            else if (max == -1)
            {
                dv1.Visible = false;
                lblPermission.Text = LoadText("SLMF_Poll", "Finished");
                v = true;
            }
            else if (permission == false)
            {
                dv1.Visible = false;
                v = true;
            }
            else
            {
                dv2.Visible = false;
            }
            if (v == true)
            {
                rptVote.DataSource = r;
                rptVote.DataBind();
                if (permission == false)
                {
                    lblPermission.Text = LoadText("SLMF_Poll", "Sum") + "<b>" + countsum + "</b>" + ". " + LoadText("SLMF_Poll", "NotVote");
                }
                else
                {
                    lblPermission.Text += LoadText("SLMF_Poll", "Sum") + "<b>" + countsum + "</b>";
                }
                lblCount.Text = "[" + countsum + "]";
                if (r != null && r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
            }
        }
        return v;
    }

    public string MemberViews()
    {
        string strRes = "";
        int intTpcId = RequestId();
        EnForum frm = new EnForum();
        frm = null;
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTpcId;
        strRes = BuInformation.SelectMemberViews(frm, tpc);
        return strRes;
    }

    private void LoadDatas(EnForum frm, EnTopic tpc)
    {
        SqlDataReader r = BuInformation.SelectMemberDatas(frm, tpc);
        listuser.DataSource = r;
        listuser.DataBind();
        if (r.IsClosed == false)
        {
            r.Close();
            r.Dispose();
        }
    }

    private EnMemberAuthorize Atr(string strAtr)
    {
        EnMemberAuthorize author = new EnMemberAuthorize();
        string strUserName = LookCookie().ToLower();
        if (strUserName == "")
        {
            strUserName = LoadText("SLMF_Reg", "UserGuest");
        }
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strUserName != "")
        {
            int intTopicId = RequestId();
            EnTopic topic = new EnTopic();
            topic.TopicId = intTopicId;
            EnForum forum = new EnForum();
            forum = BuTopic.SelectForumId(topic);
            EnMember member = new EnMember();
            member.UserName = strUserName;
            author = BuMemberAuthorize.SelectMemberAuthorize(member, forum, strAtr);
        }
        return author;
    }

    private EnMemberAuthorize Moder(string strModer)
    {
        EnMemberAuthorize atrmoder = new EnMemberAuthorize();
        string strMbr = LookCookie().ToLower();
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strMbr != "")
        {
            int intTopicId = RequestId();
            EnTopic topic = new EnTopic();
            EnForum frm = new EnForum();
            EnMember mbr = new EnMember();
            topic.TopicId = intTopicId;
            frm = BuTopic.SelectForumId(topic);
            mbr.UserName = strMbr;
            atrmoder = BuModerator.SelectExistModer(frm, mbr, strModer);
        }
        return atrmoder;
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

    public string LoadText(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public string RequestParas()
    {
        string strParas = "";
        if (Request.Params["topicid"] != null)
        {
            strParas = Request.Params["topicid"].ToString();
        }
        return strParas;
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

    private void MessageNex()
    {
        int intTopicId = RequestId();
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopicId;
        int intId = BuMessage.SelectMessageNex(tpc);
        if (intId > 0)
        {
            Response.Redirect("showtopic.aspx?topicid=" + intId);
        }
    }

    private void MessagePre()
    {
        int intTopicId = RequestId();
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopicId;
        int intId = BuMessage.SelectMessagePre(tpc);
        if (intId > 0)
        {
            Response.Redirect("showtopic.aspx?topicid=" + intId);
        }
    }

    private void HasMsgNex()
    {
        int intTopicId = RequestId();
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopicId;
        int intId = BuMessage.SelectMessageNex(tpc);
        if (intId == 0)
        {
            NextTopic.Visible = false;
        }
    }

    private void HasMsgPre()
    {
        int intTopicId = RequestId();
        EnTopic tpc = new EnTopic();
        tpc.TopicId = intTopicId;
        int intId = BuMessage.SelectMessagePre(tpc);
        if (intId == 0)
        {
            PrevTopic.Visible = false;
        }
    }

    public int RequestForum()
    {
        int inttpc = RequestId();
        EnTopic tpc = new EnTopic();
        tpc.TopicId = inttpc;
        EnForum frm = new EnForum();
        frm = BuTopic.SelectForumId(tpc);
        int intfrm = frm.ForumId;
        return intfrm;
    }

    private void BindMessage(int intTopicId, int intPageIndex)
    {
        //intTopicId = int.Parse(Request.Params["topicid"].ToString());
        EnTopic topic = new EnTopic();
        topic.TopicId = intTopicId;
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intPageIndex;
        pager.PageSize = PMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = LookCookie();
        int intType = 0;
        bool bolAccess = BuTopic.SelectTypeTopic(topic, mbr, ref intType);
        if ((intType == 2) || (mbr.UserName != "" && bolAccess))
        {
            SqlDataReader datrTpc = BuTopic.SelectShowTopic(topic, pager);
            rptMessage.DataSource = datrTpc;
            rptMessage.DataBind();
            if (datrTpc.IsClosed == false)
            {
                datrTpc.Close();
                datrTpc.Dispose();
            }
            int intCount = BuTopic.SelectItemCount(topic);
            PMessage1.ItemCount = intCount;
            PMessage2.ItemCount = intCount;
            if (intCount > PMessage1.PageSize)
            {
                PMessage1.Visible = true;
                PMessage2.Visible = true;
            }
            else
            {
                PMessage1.Visible = false;
                PMessage2.Visible = false;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">alert('" + LoadText("SLMF_Forum", "LoginToView") + "');window.location.href='../login.aspx'</script>");
        }
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void PreSender()
    {
        PrevTopic.Text = LoadText("SLMF_Topic", "PrevTopic");
        NextTopic.Text = LoadText("SLMF_Topic", "NextTopic");
    }

    private void TopicLinks(int intTopicId)
    {
        EnTopic topic = new EnTopic();
        topic.TopicId = intTopicId;
        SqlDataReader datr = BuTopic.SelectTopicLinks(topic);
        if (datr.Read())
        {
            hplCategory.InnerHtml = datr["CateName"].ToString();
            hplCategory.HRef = "../forumdisplay.aspx?groupid=" + datr["CategoryId"].ToString();
            EnForum frm1 = new EnForum();
            frm1.ForumId = int.Parse(datr["ForumId"].ToString());
            if (BuForum.SelectPafrm(ref frm1))
            {
                parf1.InnerHtml = frm1.Name;
                parf1.HRef = "../topicdisplay.aspx?forumid=" + frm1.ForumId;
                parf2.InnerHtml = frm1.Name;
                parf2.HRef = "../topicdisplay.aspx?forumid=" + frm1.ForumId;
                panelparf1.Visible = true;
                panelparf2.Visible = true;
            }
            string strForumName = datr["Name"].ToString();
            hplForum.InnerHtml = strForumName;
            hplForum.HRef = "../topicdisplay.aspx?forumid=" + datr["ForumId"].ToString();
            string strTopicName = datr["Title"].ToString();
            lblTopicTitle1.Text = strTopicName;
            lblTopicTitle2.Text = strTopicName;
            hplCategory2.InnerHtml = datr["CateName"].ToString();
            hplCategory2.HRef = "../forumdisplay.aspx?groupid=" + datr["CategoryId"].ToString();
            hplForum2.InnerHtml = strForumName;
            hplForum2.HRef = "../topicdisplay.aspx?forumid=" + datr["ForumId"].ToString();
            lblTopic2.Text = strTopicName;
            Page.Title = strTopicName + ". " + LoadText("TitleOfPage", "F9Light");
        }
        if (datr.IsClosed == false)
        {
            datr.Close();
            datr.Dispose();
        }
    }

    protected void rptMessage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int intMessageId = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            int intMemberId = int.Parse(((DbDataRecord)e.Item.DataItem)[1].ToString());
            int intRowIndex = int.Parse(((DbDataRecord)e.Item.DataItem)["RecordId"].ToString());
            bool bolIsLocked = bool.Parse(((DbDataRecord)e.Item.DataItem)["IsLocked"].ToString());
            string strAutName = ((DbDataRecord)e.Item.DataItem)[2].ToString();
            EnMessage.msgcount = intRowIndex;
            EnMember mbr1 = new EnMember();
            EnMember mbr2 = new EnMember();
            EnMemberProfile mbrpro = new EnMemberProfile();
            EnGroup grp = new EnGroup();
            EnMessage msg = new EnMessage();
            msg.MessageId = intMessageId;
            BuMessage.SelectMsgDetails(ref msg, ref mbr1, ref mbrpro, ref mbr2, ref grp);
            HtmlAnchor hrfnewmNew = new HtmlAnchor();
            hrfnewmNew = (HtmlAnchor)e.Item.FindControl("hrfnewm");
            hrfnewmNew.InnerHtml = "#" + intRowIndex;
            hrfnewmNew.HRef = "../showtopic.aspx?rowid=" + intRowIndex + "&messageid=" + msg.MessageId.ToString() + "#message" + msg.MessageId.ToString();
            HtmlAnchor hrfReportN = new HtmlAnchor();
            hrfReportN = (HtmlAnchor)e.Item.FindControl("hrfReport");
            hrfReportN.HRef = "../report.aspx?RowId=" + intRowIndex + "&messageid=" + msg.MessageId.ToString();
            if (mbrpro.HomePage != "")
            {
                HyperLink www = new HyperLink();
                www = (HyperLink)e.Item.FindControl("Home");
                www.NavigateUrl = mbrpro.HomePage.ToString();
                www.ToolTip = LoadText("SLMF_Message", "HomePage");
                www.Target = "_blank";
                www.Visible = true;
            }
            if (mbrpro.Blog != "")
            {
                HyperLink blg = new HyperLink();
                blg = (HyperLink)e.Item.FindControl("Blog");
                blg.NavigateUrl = mbrpro.Blog.ToString();
                blg.ToolTip = LoadText("SLMF_Message", "Blog");
                blg.Target = "_blank";
                blg.Visible = true;
            }
            if (mbrpro.Yahoo != "")
            {
                HyperLink yahoo = new HyperLink();
                yahoo = (HyperLink)e.Item.FindControl("Yim");
                yahoo.NavigateUrl = "http://edit.yahoo.com/config/send_webmesg?.target=" + mbrpro.Yahoo.ToString() + "&amp;.src=pg";
                yahoo.ToolTip = LoadText("SLMF_Message", "Yahoo");
                yahoo.Target = "_blank";
                yahoo.Visible = true;
            }
            //if ((mbr1.Email != "" && mbrpro.CanSendE && Atr("Em").SendEm) || (IsModer() || IsSuperModer() || IsAdmin()))
            //{
            //    HyperLink eml = new HyperLink();
            //    eml = (HyperLink)e.Item.FindControl("Email");
            //    eml.NavigateUrl = "../em.aspx?memberid=" + intMemberId.ToString(); // + mbr1.Email.ToString();
            //    eml.ToolTip = LoadText("SLMF_Message", "Email");
            //    eml.Visible = true;
            //}
            if (Atr("PM").SendPm || IsModer() || IsSuperModer() || IsAdmin())
            {
                HyperLink pmn = new HyperLink();
                pmn = (HyperLink)e.Item.FindControl("Pm");
                pmn.Visible = true;
            }
            if (Moder("IP").ViewIp || IsSuperModer() || IsAdmin())
            {
                Label ip = new Label();
                ip = (Label)e.Item.FindControl("lblIP");
                ip.Visible = true;
            }
            if (mbrpro.Icq != "")
            {
                HyperLink ic = new HyperLink();
                ic = (HyperLink)e.Item.FindControl("Icq");
                ic.NavigateUrl = "http://www.icq.com/people/about_me.php?uin=" + mbrpro.Icq.ToString();
                //ic.ImageUrl = "http://status.icq.com/online.gif?icq=" + mbrpro.Icq.ToString() + "&img=21";
                ic.ToolTip = LoadText("SLMF_Message", "ICQ");
                ic.Target = "_blank";
                ic.Visible = true;
            }
            if (mbrpro.Msn != "")
            {
                HyperLink msnnew = new HyperLink();
                msnnew = (HyperLink)e.Item.FindControl("Msn");
                msnnew.NavigateUrl = "http://login.live.com/login.srf?lc=1033&id=45940&ru=" + 
                                        "http://webmessenger.msn.com/default.aspx?pop=true&tw=20&fs=1&kv=9&ct=1209887207&ems=1&kpp=3&ver=2.1.6000.1&rn=GDRoojvF&tpf=faddeabbf0f7f320585069718225a9bd";
                msnnew.ToolTip = LoadText("SLMF_Message", "MSN") + mbrpro.Msn.ToString();
                msnnew.Target = "_blank";
                msnnew.Visible = true;
            }
            if (mbrpro.Aim != "")
            {
                HyperLink aimn = new HyperLink();
                aimn = (HyperLink)e.Item.FindControl("Aim");
                aimn.NavigateUrl = "http://www.aim.com/aimexpress.adp";
                aimn.ToolTip = LoadText("SLMF_Message", "AIM") + mbrpro.Aim.ToString();
                aimn.Target = "_blank";
                aimn.Visible = true;
            }
            if (Atr("Report").ReportAuthor)
            {
                HtmlAnchor report = new HtmlAnchor();
                report = (HtmlAnchor)e.Item.FindControl("hrfReport");
                report.Visible = true;
            }
            if (((Atr("Thank").ThankAuthor) || Moder() || IsSuperModer() || IsAdmin()) && (LookCookie() != ""))
            {
                LinkButton thanks = new LinkButton();
                thanks = (LinkButton)e.Item.FindControl("TknsPost");
                thanks.Visible = true;
            }
            SqlDataReader datrThanks = BuMessage.SelectThanks(msg);
            if (datrThanks.HasRows)
            {
                Panel pnlTks = new Panel();
                pnlTks = (Panel)e.Item.FindControl("pnlThanks");
                pnlTks.Visible = true;
                Repeater rptTks = new Repeater();
                rptTks = (Repeater)e.Item.FindControl("rptThanks");
                rptTks.DataSource = datrThanks;
                rptTks.DataBind();
                Label lblTksNew = new Label();
                lblTksNew = (Label)e.Item.FindControl("lblTksTitle");
                lblTksNew.Text = String.Format(LoadText("SLMF_Message", "UsersThank"), strAutName);
            }
            if (datrThanks.IsClosed == false)
            {
                datrThanks.Close();
                datrThanks.Dispose();
            }
            if (msg.IsApproved == false && (Moder("AprMsg").ApproveMsg || IsSuperModer() || IsAdmin()))
            {
                LinkButton appro = new LinkButton();
                appro = (LinkButton)e.Item.FindControl("AppMessage");
                appro.Visible = true;
            }
            else if (msg.IsApproved && (Moder("AprMsg").ApproveMsg || IsSuperModer() || IsAdmin()))
            {
                LinkButton appro = new LinkButton();
                appro = (LinkButton)e.Item.FindControl("IsAppMessage");
                appro.Visible = true;
            }
            string strUserName = LookCookie().ToLower();
            if (strUserName == "")
            {
                strUserName = LoadText("SLMF_Reg", "UserGuest").ToLower();
            }
            if (EnMessage.msgcount == ((PMessage1.CurrentIndex - 1)* PMessage1.PageSize + 1))
            {
                int intTpcId = RequestId();
                EnTopic tpcn = new EnTopic();
                tpcn.TopicId = intTpcId;
                int intRanId = BuSponsor.SelectRanId(tpcn);
                if (intRanId > 0)
                {
                    EnSponsor spn = new EnSponsor();
                    spn.SponsorId = intRanId;
                    BuSponsor.SelectScript(ref spn);
                    Panel pnlSpNew = new Panel();
                    pnlSpNew = (Panel)e.Item.FindControl("pnlSponsor");
                    pnlSpNew.Visible = true;
                    System.Text.StringBuilder strSponsor = new System.Text.StringBuilder(4000);
                    strSponsor.Append(spn.Scripts);
                    //strSponsor.Append("<img src=\"slmimages/banner.gif\" />");
                    Label lblSponsorNew = new Label();
                    lblSponsorNew = (Label)e.Item.FindControl("lblMessageSponsor");
                    lblSponsorNew.Text = strSponsor.ToString();
                }
            }
            if (EnMessage.msgcount == 1)
            {
                if ((Atr("DelTopic").DeleteTopicAuthor && 
                    strUserName == mbr1.UserName.ToLower() && 
                    bolIsLocked == false) || 
                    (Atr("DelTopic").DeleteTopicAuthor && Moder()) || 
                    (IsSuperModer() || IsAdmin()))
                {
                    LinkButton delmsg = new LinkButton();
                    delmsg = (LinkButton)e.Item.FindControl("DeleteMsg");
                    delmsg.CommandName = "deletetopic";
                    delmsg.CommandArgument = msg.TopicId.ToString();
                    delmsg.Attributes.Add("onclick", "return confirm('" + LoadText("SLMF_Message", "DeleteTopic") + "');");
                    delmsg.Visible = true;
                }
            }
            else
            {
                if ((Atr("DeleteMsg").DeleteMsgAuthor && 
                    strUserName == mbr1.UserName.ToLower() && 
                    bolIsLocked == false) || 
                    (Atr("DeleteMsg").DeleteMsgAuthor && Moder()) || 
                    (IsSuperModer() || IsAdmin()))
                {
                    LinkButton delmsg = new LinkButton();
                    delmsg = (LinkButton)e.Item.FindControl("DeleteMsg");
                    delmsg.Attributes.Add("onclick", "return confirm('" + LoadText("SLMF_Message", "DeletePost") + "');");
                    delmsg.Visible = true;
                }
            }
            if ((Atr("Reply").ReplyAuthor && bolIsLocked == false) ||
                (Atr("Reply").ReplyAuthor && Moder()) || 
                (IsSuperModer() || IsAdmin()))
            {
                HtmlAnchor reply = new HtmlAnchor();
                reply = (HtmlAnchor)e.Item.FindControl("ReplyMessage");
                reply.HRef = "../newmessage.aspx?post=newreply&messageid=" + intMessageId.ToString();
                reply.Visible = true;
            }
            else
            {
                rowQuick.Visible = false;
                rowTitleQuick.Visible = false;
            }
            if ((Atr("Quote").QuoteMsgAuthor && bolIsLocked == false) || 
                (Atr("Quote").QuoteMsgAuthor && Moder()) || 
                (IsSuperModer() || IsAdmin()))
            {
                HtmlAnchor quote = new HtmlAnchor();
                quote = (HtmlAnchor)e.Item.FindControl("QuoteMessage");
                quote.HRef = "../newmessage.aspx?post=newreply&messageid=" + intMessageId.ToString() + "&quote=1";
                quote.Visible = true;
            }
            if ((Atr("EditMsg").EditMsgAuthor && 
                strUserName == mbr1.UserName.ToLower() && 
                bolIsLocked == false) || 
                (Atr("EditMsg").EditMsgAuthor && Moder()) || 
                (IsSuperModer() || IsAdmin()))
            {
                HtmlAnchor edit = new HtmlAnchor();
                edit = (HtmlAnchor)e.Item.FindControl("EditMessage");
                edit.HRef = "../editmessage.aspx?post=editmessage&messageid=" + intMessageId.ToString() + "&RowId=" + intRowIndex;
                edit.Visible = true;
            }
            if ((Atr("Forward").ForwardMsgAuthor && bolIsLocked == false) || 
                (Atr("Forward").ForwardMsgAuthor && Moder()) ||
                (IsSuperModer() || IsAdmin()))
            {
                HtmlAnchor fwrd = new HtmlAnchor();
                fwrd = (HtmlAnchor)e.Item.FindControl("ForwardMessage");
                fwrd.Attributes.Add("onclick", "javascript:window.open('forwardmsg.aspx?rowid=" + intRowIndex + "&messageid=" + intMessageId + "#message" + intMessageId + 
                                    "','calwin','top=372,left=432,width=320,height=100,scrollbars=1')");
                fwrd.Visible = true;
            }
            if (bolIsLocked && EnMessage.msgcount == 1 && (Moder() || IsSuperModer() || IsAdmin()))
            {
                hrfNewMsg1.Visible = true;
                hrfNewMsg2.Visible = true;
                hrfNewTpc1.Visible = true;
                hrfNewTpc2.Visible = true;
            }
            else if (bolIsLocked && EnMessage.msgcount == 1 && (!Moder() || !IsSuperModer() || !IsAdmin()))
            {
                hrfNewMsg1.Visible = false;
                hrfNewMsg2.Visible = false;
                hrfNewTpc1.Visible = false;
                hrfNewTpc2.Visible = false;
                imgLock1.Visible = true;
                imgLock1.Alt = LoadText("SLMF_Message", "TopicClosed");
                imgLock2.Visible = true;
                imgLock2.Alt = LoadText("SLMF_Message", "TopicClosed");
            }
            else if (!bolIsLocked && EnMessage.msgcount == 1)
            {
                hrfNewMsg1.Visible = true;
                hrfNewMsg2.Visible = true;
                hrfNewTpc1.Visible = true;
                hrfNewTpc2.Visible = true;
                imgLock1.Visible = false;
                imgLock2.Visible = false;
            }
            if (bolIsLocked && EnMessage.msgcount == 1 && (Moder("UnLck").UnLockTopic || IsSuperModer() || IsAdmin()))
            {
                UnLockTopic1.Visible = true;
                UnLockTopic2.Visible = true;
                LockTopic1.Visible = false;
                LockTopic2.Visible = false;
            }
            else if (!bolIsLocked && EnMessage.msgcount == 1 && (Moder("LckTopic").LockTopicAuthor || IsSuperModer() || IsAdmin()))
            {
                UnLockTopic1.Visible = false;
                UnLockTopic2.Visible = false;
                LockTopic1.Visible = true;
                LockTopic2.Visible = true;
            }
            else if (EnMessage.msgcount == 1)
            {
                UnLockTopic1.Visible = false;
                UnLockTopic2.Visible = false;
                LockTopic1.Visible = false;
                LockTopic2.Visible = false;
            }
            System.Text.StringBuilder strOutput = new System.Text.StringBuilder(2000);
            System.Text.StringBuilder strUser = new System.Text.StringBuilder(400);
            strOutput.Append(msg.Message.ToString());
            strUser.Append("<div style=\"padding-top:3px;padding-bottom:2px;\">" + mbrpro.MemberTitle.ToString() + "</div>");
            string strAva = "";
            strAva = mbrpro.Avatar;
            int test = 0;
            if (strAva != "")
            {
                if (strAva.Length > 7)
                {
                    test = String.Compare(strAva.Substring(0, 7), "http://");
                }
                if (test == 0 && strAva.Length > 7)
                {
                    strUser.Append("<img src=\"" + strAva + "\"/><br/>");
                }
                else
                {
                    strUser.Append("<img src=\"SlmUploads/avatar/" + strAva + "\"/><br/>");
                }
            }
            if (grp.RankImage != "")
            {
                strUser.Append("<img style=\"padding-left:9px;padding-top:5px;padding-bottom:3px;\" src=\"SlmImages/" + grp.RankImage.ToString() + "\"/><br/>");
            }
            if (grp.GroupName != "")
            {
                strUser.Append(LoadText("SLMF_Message", "Rank") + grp.GroupName.ToString() + "<br/><br/>");
            }
            strUser.Append(LoadText("SLMF_Message", "Joined") + mbr1.DateCreation.Day.ToString() + "/" +
                                mbr1.DateCreation.Month.ToString() + "/" +
                                mbr1.DateCreation.Year.ToString() + "<br/>");
            strUser.Append(LoadText("SLMF_Message", "Posts") +
                "<a class=\"FLk21\" href=\"searchpro.aspx?author=" + 
                strAutName.ToString() + "\">" + mbrpro.TotalPosts.ToString() + "</a><br/>");
            if (mbrpro.Location != "")
            {
                strUser.Append(LoadText("SLMF_Message", "Location") + mbrpro.Location.ToString() + "<br/><br/>");
            }
            EnMember mrnew = new EnMember();
            mrnew.MemberId = intMemberId;
            strUser.Append(LoadText("SLMF_Rating", "Rating") + "" + BuRating.SelectRatingPoint(mrnew) + "+");
            if (Atr("Rate").RatingAuthor || IsModer() || IsSuperModer() || IsAdmin())
            {
                strUser.Append("<br/><a class=\"RatePoints\" onclick=\"javascript:window.open('rating.aspx?rateid=" +
                    intMemberId + "&from=" + strUserName + "&messageid=" + intMessageId + "&rowid=" + intRowIndex + "','calwin','top=149,left=214,width=346,height=275,resizable=yes,scrollbars=1')\"" +
                    " style=\"cursor: pointer;color: #3068bb;" + "\">" + 
                    LoadText("SLMF_Rating", "RatePoint") + "</a>");
            }
            if (mbrpro.Thank > 0)
            {
                strUser.Append("<br/><br/>" + String.Format(LoadText("SLMF_Message", "CountThank"), mbrpro.Thank.ToString()));
            }
            if (mbrpro.Thanked > 0)
            {
                strUser.Append("<br/>" + String.Format(LoadText("SLMF_Message", "CountThanked"), mbrpro.Thanked.ToString()));
            }
            string rssURL = mbrpro.MyRSS;
            if (rssURL != "")
            {
                HtmlTable tblRssNew = new HtmlTable();
                tblRssNew = (HtmlTable)e.Item.FindControl("tblNews");
                try
                {
                    ProcessRSSItem(rssURL, tblRssNew);
                    HtmlTable tblRssNew2 = new HtmlTable();
                    tblRssNew2 = (HtmlTable)e.Item.FindControl("tblNews2");
                    tblRssNew2.Visible = true;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            //strUser.Append("<table cellpadding="0" cellspacing="0"><tr><td><table class="NormalText" runat="server" id="tblNews" cellpadding="0" cellspacing="0"></table></td></tr></table>");
            strUser.Append("<div style=\"padding-bottom:5px\"></div>");
            Label userbox = new Label();
            userbox = (Label)e.Item.FindControl("lblUserBox");
            userbox.Text = strUser.ToString();
            if (msg.Edited != msg.CreationDate)
            {
                strOutput.Append("<br/><br/><span style=\"font:arial;font-size:11px\"><< " + LoadText("SLMF_Message", "Edited") + " <b>" + mbr2.UserName.ToString() +
                    "</b> -- " + AnnounceTime(msg.Edited).ToString() + " >></span>");
            }
            if (msg.Signature == true && mbrpro.Signature.ToString() != "")
            {
                strOutput.Append("<br/>---------------------------------<br/>" + mbrpro.Signature.ToString());
            }
            if (msg.IsApproved == false)
            {
                strOutput.Replace(strOutput.ToString(), "");
                strOutput.Append("<br/><span style=\"color:red;font:arial;font-size:11px\"><< " + LoadText("SLMF_Message", "IsHided") + " >></span>");
            }
            Label MsgNew = new Label();
            MsgNew = (Label)e.Item.FindControl("lblMessage");
            MsgNew.Text = strOutput.ToString();
            if (mbrpro.UserStatus == true)
            {
                HtmlImage on = new HtmlImage();
                on = (HtmlImage)e.Item.FindControl("online");
                on.Visible = true;
                on.Alt = mbr1.UserName + " " + LoadText("SLMF_Message", "Online");
            }
            else
            {
                HtmlImage off = new HtmlImage();
                off = (HtmlImage)e.Item.FindControl("offline");
                off.Visible = true;
                off.Alt = mbr1.UserName + " " + LoadText("SLMF_Message", "Offline");
            }
        }
    }
    protected void QuickReply_Click(object sender, EventArgs e)
    {
        if (Session["CanPostAgain"] != null && Session["CanPostAgain"].ToString() != ""
            && bool.Parse(Session["CanPostAgain"].ToString()) == false)
        {
            int intTopicId = RequestId();
            EnTopic t = new EnTopic();
            t.TopicId = intTopicId;
            int intMessage = BuTopic.SelectLastMessage(t);
            Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
        }
        else
        {
            string strUserName = LookCookie();
            EnConfig cg = new EnConfig();
            BuConfiguration.SelectConfiguration(ref cg);
            if (strUserName == "")
            {
                strUserName = LoadText("SLMF_Reg", "UserGuest");
            }
            string strMsg = txtReplyMsg.Value.ToString().Trim();
            while (strMsg.Replace("&nbsp;", " ").Length > 6 && strMsg.Contains("&nbsp;"))
            {
                strMsg = strMsg.Replace("&nbsp;", " ").Trim();
                while (strMsg.Contains("  "))
                {
                    strMsg = strMsg.Replace("  ", " ").Trim();
                }
            }
            if (strUserName != "" && strMsg != "" && strMsg.Length >= cg.MaxMsg)
            {
                int intTopicId = RequestId();
                EnTopic t = new EnTopic();
                t.TopicId = intTopicId;
                EnForum f = new EnForum();
                f = BuTopic.SelectForumId(t);
                bool fa = false;
                Authorization(strUserName, f.ForumId, "Reply", ref fa);
                if (fa)
                {
                    bool bolResult = InsertMessage(strUserName, intTopicId, strMsg);
                    if (bolResult)
                    {
                        int intMessage = BuTopic.SelectLastMessage(t);
                        txtReplyMsg.Value = "";
                        //Session["CanPostAgain"] = true;
                        Response.Redirect("showtopic.aspx?messageid=" + intMessage + "#message" + intMessage);
                    }
                }
            }
            else
            {
                int intTopicId = RequestId();
                EnTopic topic = new EnTopic();
                topic.TopicId = intTopicId;
                txtReplyMsg.Value = "";
                int intCount = BuTopic.SelectItemCount(topic);
                PMessage1.ItemCount = intCount;
                PMessage2.ItemCount = intCount;
                if (intCount > PMessage1.PageSize)
                {
                    PMessage1.Visible = true;
                    PMessage2.Visible = true;
                }
                else
                {
                    PMessage1.Visible = false;
                    PMessage2.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + string.Format(LoadText("SLMF_Message", "MaxMessage"), cg.MaxMsg).ToString() + "');this.location.href='showtopic.aspx?topicid=" + intTopicId + "#quickrepl';</script>");
            }
        }
    }

    private bool InsertMessage(string strUserName, int intTopicId, string strMsg)
    {
        bool intInsert = true;
        EnMember member = new EnMember();
        member.UserName = strUserName;
        EnMessage msg = new EnMessage();
        msg.TopicId = intTopicId;
        msg.Title = LoadText("SLMF_Message", "ReplyTitle") + lblTopicTitle2.Text.ToString();
        msg.Message = strMsg;
        msg.IP = Request.ServerVariables["REMOTE_ADDR"];
        EnTopic t = new EnTopic();
        t.TopicId = intTopicId;
        EnForum f = new EnForum();
        f = BuTopic.SelectForumId(t);
        if (Moder() || IsSuperModer() || IsAdmin())
        {
            msg.IsApproved = true;
        }
        else
        {
            msg.IsApproved = BuMemberAuthorize.SelectMemberAuthorize(member, f, "Approve").IsApproved;
        }
        EnMemberProfile pro = new EnMemberProfile();
        EnMember mbr2 = new EnMember();
        mbr2 = BuMember.SelectMemberIdFUser(member);
        BuMemberProfile.SelectAlSign(mbr2, ref pro);
        msg.Signature = pro.AlwaysSig;
        //msg.Signature = BuMemberAuthorize.SelectMemberAuthorize(member, f, "AlSig").AlwaysSig;
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
    protected void rptMessage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletepost")
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            int intTpcId = BuMessage.SelectTopicId(msg);
            int intPageId = 0;
            bool flag = false;
            if (Request.Params["TopicId"] != null && Request.Params["PageId"] != null)
            {
                intPageId = int.Parse(Request.Params["PageId"].ToString());
                EnTopic tn = new EnTopic();
                tn.TopicId = intTpcId;
                int intLastMsg = BuTopic.SelectLastMessage(tn);
                EnPagerF pager = new EnPagerF();
                pager.CurrentPage = intPageId;
                pager.PageSize = PMessage1.PageSize;
                int intRowId = BuTopic.SelectRowId(tn, pager, msg);
                if (( intLastMsg == msg.MessageId) && ((intRowId % pager.PageSize) == 1))
                {
                    intPageId = intPageId - 1;
                    flag = true;
                }
            }
            BuMessage.DeleteMessage(msg);
            if (Request.Params["TopicId"] == null)
            {
                Response.Redirect("showtopic.aspx?topicid=" + intTpcId);
            }
            else if (Request.Params["TopicId"] != null && Request.Params["PageId"] == null)
            {
                Server.Transfer("showtopic.aspx?topicid=" + intTpcId);
            }
            else if (Request.Params["TopicId"] != null && Request.Params["PageId"] != null)
            {
                if (flag)
                {
                    Response.Redirect("showtopic.aspx?topicid=" + intTpcId + "&pageid=" + intPageId);
                }
                Server.Transfer("showtopic.aspx?topicid=" + intTpcId + "&pageid=" + Request.Params["PageId"]);
            }
        }
        else if (e.CommandName == "deletetopic")
        {
            EnTopic t = new EnTopic();
            t.TopicId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            EnForum f = new EnForum();
            f = BuTopic.SelectForumId(t);
            BuTopic.DeleteTopic(t);
            Response.Redirect("topicdisplay.aspx?forumid=" + f.ForumId.ToString());
        }
        else if (e.CommandName == "IsApproveMsg")
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            BuMessage.UpdateMsgApproved(msg, false);
            int intTpcId = BuMessage.SelectTopicId(msg);
            EnTopic tn = new EnTopic();
            tn.TopicId = intTpcId;
            int intPageId = 1;
            int intRowId = 1;
            if (Request.Params["PageId"] != null)
            {
                intPageId = int.Parse(Request.Params["PageId"].ToString());
                EnPagerF pager = new EnPagerF();
                pager.CurrentPage = intPageId;
                pager.PageSize = PMessage1.PageSize;
                intRowId = BuTopic.SelectRowId(tn, pager, msg);
            }
            else
            {
                intRowId = BuTopic.SelectRecordId(tn, msg);
            }
            string strChange = "showtopic.aspx?rowid=" + intRowId + "&messageid=" + msg.MessageId + "#message" + msg.MessageId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">window.location.href='" + strChange + "'</script>");
        }
        else if (e.CommandName == "ApproveMsg")
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            BuMessage.UpdateMsgApproved(msg, true);
            int intTpcId = BuMessage.SelectTopicId(msg);
            EnTopic tn = new EnTopic();
            tn.TopicId = intTpcId;
            int intPageId = 1;
            int intRowId = 1;
            if (Request.Params["PageId"] != null)
            {
                intPageId = int.Parse(Request.Params["PageId"].ToString());
                EnPagerF pager = new EnPagerF();
                pager.CurrentPage = intPageId;
                pager.PageSize = PMessage1.PageSize;
                intRowId = BuTopic.SelectRowId(tn, pager, msg);
            }
            else
            {
                intRowId = BuTopic.SelectRecordId(tn, msg);
            }
            string strChange = "showtopic.aspx?rowid=" + intRowId + "&messageid=" + msg.MessageId + "#message" + msg.MessageId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">window.location.href='" + strChange + "'</script>");
        }
        else if (e.CommandName == "tnkpost")
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            string strUserName = LookCookie();
            EnMember mbr = new EnMember();
            mbr.UserName = strUserName;
            BuMessage.InsertThanks(msg, mbr);
            int intTpcId = BuMessage.SelectTopicId(msg);
            EnTopic tn = new EnTopic();
            tn.TopicId = intTpcId;
            int intPageId = 1;
            int intRowId = 1;
            if (Request.Params["PageId"] != null)
            {
                intPageId = int.Parse(Request.Params["PageId"].ToString());
                EnPagerF pager = new EnPagerF();
                pager.CurrentPage = intPageId;
                pager.PageSize = PMessage1.PageSize;
                intRowId = BuTopic.SelectRowId(tn, pager, msg);
            }
            else
            {
                intRowId = BuTopic.SelectRecordId(tn, msg);
            }
            string strChange = "showtopic.aspx?rowid=" + intRowId + "&messageid=" + msg.MessageId + "#message" + msg.MessageId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">window.location.href='" + strChange + "'</script>");
        }
    }

    public int RowId(int intMsgId)
    {
        EnMessage msg = new EnMessage();
        msg.MessageId = intMsgId;
        int intTpcId = BuMessage.SelectTopicId(msg);
        EnTopic tn = new EnTopic();
        tn.TopicId = intTpcId;
        return BuTopic.SelectRecordId(tn, msg);
    }

    protected void PMessage1_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["topicid"] != null || Request.Params["MessageId"] != null)
        {
            int intTopicId = RequestId();
            int intIndex = Convert.ToInt32(e.CommandArgument);
            PMessage1.CurrentIndex = intIndex;
            PMessage2.CurrentIndex = intIndex;
            Response.Redirect("showtopic.aspx?topicid=" + intTopicId + "&pageid=" + intIndex);
        }
    }

    protected void PMessage2_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["topicid"] != null || Request.Params["MessageId"] != null)
        {
            int intTopicId = RequestId();
            int intIndex = Convert.ToInt32(e.CommandArgument);
            PMessage1.CurrentIndex = intIndex;
            PMessage2.CurrentIndex = intIndex;
            Response.Redirect("showtopic.aspx?topicid=" + intTopicId + "&pageid=" + intIndex);
        }
    }
    protected void PostAgain_Click(object sender, EventArgs e)
    {
        if (Request.Params["topicid"] != null)
        {
            int intTopicId = int.Parse(Request.Params["topicid"].ToString());
            EnTopic n = new EnTopic();
            n.TopicId = intTopicId;
            EnForum fn = new EnForum();
            fn = BuTopic.SelectForumId(n);
            int intForumId = fn.ForumId;
            txtReplyMsg.Value = "";
            Response.Redirect("newmessage.aspx?post=newreply&topicid=" + Request.Params["TopicId"].ToString() + 
                                "&forumid=" + intForumId);
        }
        else if (Request.Params["MessageId"] != null)
        {
            txtReplyMsg.Value = "";
            Response.Redirect("newmessage.aspx?post=newreply&messageid=" + Request.Params["MessageId"].ToString());
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rlPoll.SelectedValue != "")
        {
            string strId = LookCookie();
            if (strId == "")
            {
                strId = LoadText("SLMF_Reg", "UserGuest");
            }
            if (strId != "")
            {
                int intTopicId = RequestId();
                EnVote vote = new EnVote();
                EnResult res = new EnResult();
                EnMember mbr = new EnMember();
                mbr.UserName = strId;
                vote.IP = Request.ServerVariables["REMOTE_ADDR"];
                res.ResultId = int.Parse(rlPoll.SelectedValue.ToString());
                BuPoll.InsertVote(res, vote, mbr);
                Response.Redirect("showtopic.aspx?topicid=" + intTopicId);
            }
        }
    }

    private bool IsModer()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strMbr != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strMbr;
            a = BuMember.IsModer(mbr);
        }
        return a;
    }

    private bool Moder()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strMbr != "")
        {
            int intTopicId = RequestId();
            EnTopic topic = new EnTopic();
            EnForum frm = new EnForum();
            EnMember mbr = new EnMember();
            topic.TopicId = intTopicId;
            frm = BuTopic.SelectForumId(topic);
            mbr.UserName = strMbr;
            a = BuMember.IsModer2(mbr, frm);
        }
        return a;
    }

    private bool IsSuperModer()
    {
        string strMbr = LookCookie().ToLower();
        bool a = false;
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strMbr != "")
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
        if ((Request.Params["topicid"] != null || Request.Params["MessageId"] != null) && strMbr != "")
        {
            EnMember mbr = new EnMember();
            mbr.UserName = strMbr;
            a = BuMember.IsAdmin(mbr);
        }
        return a;
    }

    public decimal PercentImage(decimal a)
    {
        return Math.Round(a, 2);
    }
    protected void NextTopic_Click(object sender, EventArgs e)
    {
        MessageNex();
    }
    protected void PrevTopic_Click(object sender, EventArgs e)
    {
        MessagePre();
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
            if (Session["CanPostAgain"] == null)
            {
                Session["CanPostAgain"] = false;
            }
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
    protected void DeleteTopic1_Click(object sender, EventArgs e)
    {
        DeleteTopicMsg();
    }
    protected void DeleteTopic2_Click(object sender, EventArgs e)
    {
        DeleteTopicMsg();
    }

    private void DeleteTopicMsg()
    {
        EnTopic t = new EnTopic();
        if (Request.Params["TopicId"] != null)
        {
            t.TopicId = int.Parse(Request.Params["TopicId"].ToString());
        }
        else if (Request.Params["MessageId"] != null)
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(Request.Params["MessageId"].ToString());
            t.TopicId = BuMessage.SelectTopicId(msg);
        }
        EnForum f = new EnForum();
        f = BuTopic.SelectForumId(t);
        BuTopic.DeleteTopic(t);
        Response.Redirect("topicdisplay.aspx?forumid=" + f.ForumId.ToString());
    }

    private void LockTopicMsg(bool bolIsLock)
    {
        EnTopic t = new EnTopic();
        if (Request.Params["TopicId"] != null)
        {
            t.TopicId = int.Parse(Request.Params["TopicId"].ToString());
        }
        else if (Request.Params["MessageId"] != null)
        {
            EnMessage msg = new EnMessage();
            msg.MessageId = int.Parse(Request.Params["MessageId"].ToString());
            t.TopicId = BuMessage.SelectTopicId(msg);
        }
        EnForum f = new EnForum();
        f = BuTopic.SelectForumId(t);
        BuTopic.LockTopic(t,bolIsLock);
        Response.Redirect("topicdisplay.aspx?forumid=" + f.ForumId.ToString());
    }

    protected void LockTopic1_Click(object sender, EventArgs e)
    {
        LockTopicMsg(true);
    }
    protected void LockTopic2_Click(object sender, EventArgs e)
    {
        LockTopicMsg(true);
    }
    protected void UnLockTopic1_Click(object sender, EventArgs e)
    {
        LockTopicMsg(false);
    }
    protected void UnLockTopic2_Click(object sender, EventArgs e)
    {
        LockTopicMsg(false);
    }

    private void Authorization(string strUserName, int intForumId, string strCreate, ref bool fa)
    {
        fa = true;
        if (strUserName == "")
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
        //bool bolPoll = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "Poll").PollAuthor;
        //bool bolPriority = BuModerator.SelectExistModer(forum, member, "Sticky").StickTopicAuthor;
        //bool bolSignature = BuMemberAuthorize.SelectMemberAuthorize(member, forum, "AlSig").AlwaysSig;
        //check permission f\of signature
        //if (bolPoll || IsSuperModer() || IsAdmin())
        //{
        //    rowcreatepoll.Visible = true;
        //}
        //if (bolPriority || IsSuperModer() || IsAdmin())
        //{
        //    rowpriority.Visible = true;
        //}
        //if (bolSignature || IsSuperModer() || IsAdmin())
        //{
        //    ckbAddSignature.Checked = true;
        //check permission f\of signature
        //}
    }

    public void ProcessRSSItem(string rssURL, HtmlTable tblRss)
    {
        // Read the RSS feed
        WebRequest myRequest = WebRequest.Create(rssURL);
        WebResponse myResponse = myRequest.GetResponse();

        Stream rssStream = myResponse.GetResponseStream();

        // Load a XML Document
        XmlDocument rssDoc = new XmlDocument();
        rssDoc.Load(rssStream);

        XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

        string title = "";
        string link = "";
        string description = "";
        UtiString utinew = new UtiString();
        UtiGeneralClass slmNew = new UtiGeneralClass();
        int intLimit = int.Parse(slmNew.LoadLangs("SLMF_Forum", "LenghtString").ToString());
        //strTitle = utinew.ReleaseInput(strTitle, intLimit).Trim();
        // Loop through RSS Feed items
        string title2 = "";
        for (int i = 0; i < rssItems.Count; i++)
        {
            XmlNode rssDetail;
            title2 = "";
            rssDetail = rssItems.Item(i).SelectSingleNode("title");
            if (rssDetail != null)
            {
                title2 = rssDetail.InnerText;
                title = utinew.ReleaseInput(rssDetail.InnerText, 32).Trim(); 
            }
            else
            {
                title = "";
            }

            rssDetail = rssItems.Item(i).SelectSingleNode("link");
            if (rssDetail != null)
            {
                link = rssDetail.InnerText;
            }
            else
            {
                link = "";
            }
            rssDetail = rssItems.Item(i).SelectSingleNode("description");
            if (rssDetail != null)
            {
                description = utinew.ReleaseInput(rssDetail.InnerText, intLimit).Trim();
            }
            else
            {
                description = "";
            }

            // Populate the HTML table rows and cells
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.InnerHtml = "<a class=\"FLk21\" href='" + link + "' target='new' title='" + title2 + "'>" + title + "</a></br>";
            HtmlTableRow tr1 = new HtmlTableRow();
            tr1.Cells.Add(cell1);
            tblRss.Rows.Add(tr1);
            HtmlTableCell cell2 = new HtmlTableCell();
            if (description.Contains("<p>"))
            {
                description.Replace("<p>", "");
            }
            if (description.Contains("</p>"))
            {
                description.Replace("</p>", "");
            }
            if (description.Contains("<br>"))
            {
                description.Replace("<br>", "");
            }
            if (description.Contains("</br>"))
            {
                description.Replace("</br>", "");
            }
            cell2.InnerHtml = description + "</br>";
            HtmlTableRow tr2 = new HtmlTableRow();
            tr2.Cells.Add(cell2);
            tblRss.Rows.Add(tr2);
        }
    }
}