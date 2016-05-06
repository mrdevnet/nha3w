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

public partial class SlmControls_slm_rating : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["rateid"] != null)
            {
                int intMemberId = int.Parse(Request.Params["rateid"].ToString());
                LoadRating(intMemberId);
                LoadListRating();
                btnRating.Text = LoadSLMF("SLMF_Rating", "Vote");
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadRating(int intMemberId)
    {
        EnMember mbr = new EnMember();
        mbr.MemberId = intMemberId;
        SqlDataReader datrRating = BuRating.SelectMemberRating(mbr);
        rptRating.DataSource = datrRating;
        rptRating.DataBind();
        if (datrRating.IsClosed == false)
        {
            datrRating.Close();
            datrRating.Dispose();
        }
    }

    private void LoadListRating()
    {
        int i = 0;
        while (i <= 10)
        {
            if (i == 0)
            {
                ddlRating.Items.Add("0");
                ddlRating.Items[i].Value = "-1";
                i++;
            }
            ddlRating.Items.Add(i.ToString());
            ddlRating.Items[i].Value = Convert.ToString(i + 1);
            i++;
        }
    }
    protected void btnRating_Click(object sender, EventArgs e)
    {
        if (ddlRating.SelectedValue != "-1" && Request.Params["rateid"] != null && Request.Params["from"] != null && 
                Request.Params["messageid"] != null && Request.Params["rowid"] != null)
        {
            if (Atr("Rate").RatingAuthor || Moder() || IsSuperModer() || IsAdmin())
            {
                EnRating rating = new EnRating();
                rating.TypeId = int.Parse(ddlRating.SelectedValue.ToString());
                rating.From = Request.Params["from"].ToString();
                rating.ToMember = int.Parse(Request.Params["rateid"].ToString());
                BuRating.InsertRating(rating);
                LoadRating(rating.ToMember);
                string strUrl = "showtopic.aspx?rowid=" + Request.Params["rowid"].ToString() + "&messageid=" +
                    Request.Params["messageid"].ToString() + "#message" + Request.Params["messageid"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>opener.location.href='" + strUrl + "'</script>");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>opener.location.reload()</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>alert('" + LoadSLMF("SLMF_Rating","NotPermission") + "');this.close();</script>");
            }
        }
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

    private EnMemberAuthorize Atr(string strAtr)
    {
        EnMemberAuthorize author = new EnMemberAuthorize();
        string strUserName = LookCookie().ToLower();
        if (strUserName == "")
        {
            strUserName = LoadSLMF("SLMF_Reg", "UserGuest");
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

    private int RequestId()
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

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
}
