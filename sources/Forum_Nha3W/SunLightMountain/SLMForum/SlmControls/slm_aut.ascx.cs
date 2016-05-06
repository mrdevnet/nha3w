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

public partial class SlmControls_slm_aut : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["TopicId"] != null)
            {
                tblAccess.Visible = false;
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
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

    private EnMemberAuthorize Atr(string strAtr)
    {
        EnMemberAuthorize author = new EnMemberAuthorize();
        string strUserName = LookCookie().ToLower();
        if (strUserName == "")
        {
            strUserName = LoadSLMF("SLMF_Reg", "UserGuest");
        }
        if (Request.Params["messageid"] != null && strUserName != "")
        {
            EnMessage msgn = new EnMessage();
            msgn.MessageId = int.Parse(Request.Params["messageid"].ToString());
            int intTopicId = BuMessage.SelectTopicId(msgn);
            EnTopic topic = new EnTopic();
            topic.TopicId = intTopicId;
            EnForum forum = new EnForum();
            forum = BuTopic.SelectForumId(topic);
            EnMember member = new EnMember();
            member.UserName = strUserName;
            author = BuMemberAuthorize.SelectMemberAuthorize(member, forum, strAtr);
        }
        else if (Request.Params["topicid"] != null && strUserName != "")
        {
            int intTopicId = int.Parse(Request.Params["topicid"].ToString());
            EnTopic topic = new EnTopic();
            topic.TopicId = intTopicId;
            EnForum forum = new EnForum();
            forum = BuTopic.SelectForumId(topic);
            EnMember member = new EnMember();
            member.UserName = strUserName;
            author = BuMemberAuthorize.SelectMemberAuthorize(member, forum, strAtr);
        }
        else if (Request.Params["ForumId"] != null && strUserName != "")
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            EnForum forum = new EnForum();
            forum.ForumId = intForumId;
            EnMember member = new EnMember();
            member.UserName = strUserName;
            author = BuMemberAuthorize.SelectMemberAuthorize(member, forum, strAtr);
        }
        return author;
    }

    private string FormatCode(string c, string a, string b)
    {
        return String.Format(c, a, b);
    }

    public string AccessForum()
    {
        EnMemberAuthorize access = new EnMemberAuthorize();
        access = Atr("Post");
        System.Text.StringBuilder acs = new System.Text.StringBuilder(360);
        if (access.PostAuthor)
        {
            acs.Append(FormatCode(LoadSLMF("SLMF_Topic", "CanPost"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append(FormatCode(LoadSLMF("SLMF_Topic", "CanNotPost"), "<strong>", "</strong>"));
        }
        access = Atr("Reply");
        if (access.ReplyAuthor)
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanReply"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanNotReply"), "<strong>", "</strong>"));
        }

        access = Atr("DeleteMsg");
        if (access.DeleteMsgAuthor)
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanDelete"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanNotDelete"), "<strong>", "</strong>"));
        }

        access = Atr("EditMsg");
        if (access.EditMsgAuthor)
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanEdit"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanNotEdit"), "<strong>", "</strong>"));
        }

        access = Atr("Poll");
        if (access.PollAuthor)
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanPoll"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanNotPoll"), "<strong>", "</strong>"));
        }

        access = Atr("Vote");
        if (access.VoteAuthor)
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanVote"), "<strong>", "</strong>"));
        }
        else
        {
            acs.Append("<br/>" + FormatCode(LoadSLMF("SLMF_Topic", "CanNotVote"), "<strong>", "</strong>"));
        }
        DateTime now = DateTime.Now;
        acs.Append("<br/>" + LoadSLMF("SLMF_Topic", "TimeNow") + "<b>" + now.ToShortTimeString() + " - " + 
                        LoadSLMF("SLMF_Forum", "TimeZone") + "</b>");
        return acs.ToString();
    }
}
