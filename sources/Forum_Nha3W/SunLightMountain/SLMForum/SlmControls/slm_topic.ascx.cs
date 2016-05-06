using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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

public partial class SlmControls_slm_topic : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["forumid"] != null)
            {
                int intForumId = int.Parse(Request.Params["forumid"].ToString());
                BindSubForum(intForumId);
                BindAnnouncement(intForumId);
                EnForum frm = new EnForum();
                frm.ForumId = intForumId;
                //int intSumRows = 0;
                int intSortId = 0;
                if (Request.Params["SortId"] != null)
                {
                    intSortId = int.Parse(Request.Params["SortId"].ToString());
                    /*int intCount = ListFromCount(intSortId.ToString());
                    if (intCount > 0)
                    {
                        intSumRows = BuForum.SelectItemCountSort(frm, intCount);
                    }
                    else
                    {
                        intSumRows = BuForum.SelectItemCount(frm);
                    }*/
                }
                /*else
                {
                    intSumRows = BuForum.SelectItemCount(frm);
                }
                int intMaxRecords = TMessage1.PageSize;
                int intItems = 0;
                if (intSumRows % intMaxRecords > 0)
                {
                    intItems = (intSumRows / intMaxRecords) + 1;
                }
                else
                {
                    intItems = (intSumRows / intMaxRecords);
                }*/

                if (Request.Params["PageId"] == null)
                {
                    TMessage1.CurrentIndex = 1;
                    TMessage2.CurrentIndex = 1;
                }
                else if (Request.Params["PageId"] != null)
                {
                    TMessage1.CurrentIndex = int.Parse(Request.Params["PageId"].ToString());
                    TMessage2.CurrentIndex = int.Parse(Request.Params["PageId"].ToString());
                }
                SortOrder();
                if (intSortId > 0)
                {
                    ListFromSelected(intSortId.ToString(), intForumId, TMessage1.CurrentIndex);
                    if (Session["intSortId"] != null && Session["intSortId"].ToString() != "")
                    {
                        listfrom.SelectedIndex = int.Parse(Session["intSortId"].ToString());
                    }
                }
                else
                {
                    BindTopic(intForumId, TMessage1.CurrentIndex);
                }
                /*if (intItems <= 1)
                {
                    TMessage1.Visible = false;
                    TMessage2.Visible = false;
                }*/
                EnTopic tpc = new EnTopic();
                tpc = null;
                LoadDatas(frm, tpc);
                btnSearch.Text = LoadSLMF("SLMF_Members", "Search");
            }
        }
    }

    public string MemberViews()
    {
        string strRes = "";
        if (Request.Params["forumid"] != null)
        {
            int intfrm = int.Parse(Request.Params["forumid"].ToString());
            EnForum frm = new EnForum();
            frm.ForumId = intfrm;
            EnTopic tpc = new EnTopic();
            tpc = null;
            strRes = BuInformation.SelectMemberViews(frm, tpc);
        }
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

    private void SortOrder()
    {
        int i=0;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort0"));
        listfrom.Items[i].Value = "-1";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort1"));
        listfrom.Items[i].Value = "1";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort2"));
        listfrom.Items[i].Value = "2";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort3"));
        listfrom.Items[i].Value = "3";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort4"));
        listfrom.Items[i].Value = "4";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort5"));
        listfrom.Items[i].Value = "5";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort6"));
        listfrom.Items[i].Value = "6";
        i++;
        listfrom.Items.Add(LoadSLMF("SLMF_Topic", "Sort7"));
        listfrom.Items[i].Value = "7";
    }

    public string RequestParas()
    {
        string strParas = "";
        if (Request.Params["forumid"] != null)
        {
            strParas = Request.Params["forumid"].ToString();
        }
        return strParas;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void BindSubForum(int intForumId)
    {
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;
        int k = 0;
        List<EnForum> datrSub = BuForum.SelectSub2(forum, ref k);
        if (k == 1)
        {
            rptForumParent.DataSource = datrSub;
            rptForumParent.DataBind();
            pnlHeight1.Visible = true;
        }
        EnCategory cate = new EnCategory();
        BuForum.SelectForumInCate(ref forum, ref cate);
        hplCategory.InnerHtml = cate.CateName;
        hplCategory.HRef = "../forumdisplay.aspx?groupid=" + cate.CategoryId;
        hplCategory3.InnerHtml = cate.CateName;
        hplCategory3.HRef = "../forumdisplay.aspx?groupid=" + cate.CategoryId;
        EnForum parf = new EnForum();
        parf.ForumId = intForumId;
        if (BuForum.SelectPafrm(ref parf))
        {
            hplCategory2.InnerHtml = parf.Name;
            hplCategory2.HRef = "../topicdisplay.aspx?forumid=" + parf.ForumId;
            hplCategory4.InnerHtml = parf.Name;
            hplCategory4.HRef = "../topicdisplay.aspx?forumid=" + parf.ForumId;
            parf1.Visible = true;
            parf2.Visible = true;
        }
        lblGroup2.Text = forum.Name;
        lblGroup2.Visible = true;
        lblGroupName.Text = forum.Name;
        lblGroupName.Visible = true;
        lblAnnountCate.Text = forum.Name;
        Page.Title = forum.Name + ". " + LoadSLMF("TitleOfPage", "F9Light");
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void BindAnnouncement(int intForumId)
    {
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;
        SqlDataReader datrAnnounce = BuReport.SelectReport(forum);
        if (datrAnnounce.HasRows)
        {
            pnlAnnounce.Visible = true;
            pnlHeight2.Visible = true;
            rptAnnouncement.DataSource = datrAnnounce;
            rptAnnouncement.DataBind();
        }
        else
        {
            pnlAnnounce.Visible = false;
        }
        if (datrAnnounce.IsClosed == false)
        {
            datrAnnounce.Close();
            datrAnnounce.Dispose();
        }
    }

    public string IconAnnounce(DateTime dtServ)
    {
        string ck = "";
        bool bolIcon = false;
        string strImg = "SlmImages/topic_announce.gif";
        ck = SentForCook();
        if (ck != "")
        {
            bolIcon = BuInformation.SelectPairTime(2, ck, dtServ);
        }
        else
        {
            string strCur = HttpContext.Current.Session.SessionID;
            bolIcon = BuInformation.SelectPairTime(1, strCur, dtServ);
        }
        if (bolIcon)
        {
            strImg = "SlmImages/topic_announce_new.png";
        }
        return strImg;
    }

    private void BindTopic(int intForumId, int intCurrentId)
    {
        EnForum forumvn = new EnForum();
        forumvn.ForumId = intForumId;
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        SqlDataReader datrTopic = BuTopic.SelectTopic(forumvn, pager);
        rptTopic.DataSource = datrTopic;
        rptTopic.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuForum.SelectItemCount(forumvn);
        TMessage1.ItemCount = intCount;
        TMessage2.ItemCount = intCount;
        if (intCount > TMessage1.PageSize)
        {
            TMessage1.Visible = true;
            TMessage2.Visible = true;
        }
        else
        {
            TMessage1.Visible = false;
            TMessage2.Visible = false;
        }
    }

    private void BindTopicSort(int intForumId, int intCurrentId, int SortId)
    {
        EnForum forumvn = new EnForum();
        forumvn.ForumId = intForumId;
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        SqlDataReader datrTopic = BuTopic.SelectTopicSort(forumvn, pager, SortId);
        rptTopic.DataSource = datrTopic;
        rptTopic.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuForum.SelectItemCountSort(forumvn, SortId);
        TMessage1.ItemCount = intCount;
        TMessage2.ItemCount = intCount;
        if (intCount > TMessage1.PageSize)
        {
            TMessage1.Visible = true;
            TMessage2.Visible = true;
        }
        else
        {
            TMessage1.Visible = false;
            TMessage2.Visible = false;
        }
    }

    public string GotoPage(int intTopicId)
    {
        string strReturn = "";
        int CountPages = 6;
        EnTopic n = new EnTopic();
        n.TopicId = intTopicId;
        int intSumRows = BuTopic.SelectItemCount(n);
        int intMaxRecords = 20;
        int intItems = 0;
        if (intSumRows % intMaxRecords > 0)
        {
            intItems = (intSumRows / intMaxRecords) + 1;
        }
        else
        {
            intItems = (intSumRows / intMaxRecords);
        }
        if (intItems > 1)
        {
            if (intItems > CountPages)
            {
                strReturn += "(<img src=\"SlmImages/multipage.gif\" alt=\"Đến trang\" /> ";
                strReturn += PagerLink("1", "showtopic.aspx?topicid=" + intTopicId + "&pageid=" + 1);
                strReturn += ", ";
                strReturn += PagerLink("2", "showtopic.aspx?topicid=" + intTopicId + "&pageid=" + 2);
                strReturn += ", ";
                strReturn += PagerLink("3", "showtopic.aspx?topicid=" + intTopicId + "&pageid=" + 3);
                strReturn += " ... ";
                bool bFirst = true;
                for (int i = (intItems - (CountPages - 3)); i < intItems; i++)
                {
                    int iPost = i + 1;
                    if (bFirst) bFirst = false;
                    else strReturn += ", ";
                    strReturn += PagerLink(iPost.ToString(), "showtopic.aspx?topicid=" + intTopicId + "&pageid=" + iPost);
                }
            }
            else
            {
                strReturn += "(<img src=\"SlmImages/multipage.gif\" alt=\"Đến trang\" /> ";
                bool bFirst = true;
                for (int i = 0; i < intItems; i++)
                {
                    int iPost = i + 1;
                    if (bFirst) bFirst = false;
                    else strReturn += ", ";
                    strReturn += PagerLink(iPost.ToString(), "showtopic.aspx?topicid=" + intTopicId + "&pageid=" + iPost);
                }
            }
            strReturn += ")";
        }
        return strReturn;
    }

    private string PagerLink(string strText, string strLink)
    {
        return String.Format("<a class=\"TopicLink\" href=\"{0}\">{1}</a>", strLink, strText);
    }


    public string GetSpace()
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strSpace = slmNew.LoadLangs("SLMF_Forum", "Space");
        return strSpace;
    }

    private SqlDataReader BindForumSubDesc(int intForumId)
    {
        EnForum forum = new EnForum();
        forum.ForumId = intForumId;
        SqlDataReader datrForum = BuForum.SelectForumSubDesc(forum);
        return datrForum;
    }

    protected void rptForumParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            int i = (int)((EnForum)e.Item.DataItem).ForumId;
            Repeater rptSubNew = new Repeater();
            rptSubNew = (Repeater)e.Item.FindControl("rptForumSub");
            SqlDataReader datrSub = BindForumSubDesc(i);
            rptSubNew.DataSource = datrSub;
            rptSubNew.DataBind();
            if (datrSub.IsClosed == false)
            {
                datrSub.Close();
                datrSub.Dispose();
            }
        }
    }
    protected void rptForumSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //int i = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
            int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            EnForum forum = new EnForum();
            forum.ForumId = i;
            EnForum newforum = new EnForum();
            EnTopic topic = new EnTopic();
            EnMessage newmessage = new EnMessage();
            EnMember newmember = new EnMember();
            int intResult = 0;
            newforum = BuForum.SelectForumDetails(ref intResult, forum, ref topic, ref newmessage, ref newmember);
            Repeater rptModNew = new Repeater();
            rptModNew = (Repeater)e.Item.FindControl("rptModerator");
            int j = 0;
            EnModerator moderator = new EnModerator();
            moderator.ForumId = i;
            List<EnModerator> datrModer = BuModerator.SelectModerator(moderator, ref j);
            if (j == 1)
            {
                rptModNew.DataSource = datrModer;
                rptModNew.DataBind();
            }
            UtiGeneralClass slmNew = new UtiGeneralClass();
            if (intResult == 1)
            {
                Label lbl1new = new Label();
                lbl1new = (Label)e.Item.FindControl("lblTotalTopics");
                lbl1new.Text = newforum.TotalTopics.ToString();
                Label lbl2new = new Label();
                lbl2new = (Label)e.Item.FindControl("lblTotalMessages");
                lbl2new.Text = newforum.TotalMessages.ToString();
                HtmlAnchor hrfMsgNew = new HtmlAnchor();
                hrfMsgNew = (HtmlAnchor)e.Item.FindControl("hrfMessage");
                string strTitle = newmessage.Title.ToString();
                UtiString utinew = new UtiString();
                int intLimit = int.Parse(slmNew.LoadLangs("SLMF_Forum", "LenghtString").ToString());
                strTitle = utinew.ReleaseInput(strTitle, intLimit).Trim();
                hrfMsgNew.InnerText = strTitle;
                hrfMsgNew.Title = newmessage.Title.ToString();
                hrfMsgNew.HRef = "../showtopic.aspx?goto=newmessage&topicid=" + topic.TopicId.ToString();
                Label lbl3new = new Label();
                lbl3new = (Label)e.Item.FindControl("lblTime");
                string strTime = utinew.TimeServer(newmessage.CreationDate);
                lbl3new.Text = "<br/>" + strTime + "<br/>";
                string ck = "";
                bool bolIcon = false;
                ck = SentForCook();
                if (ck != "")
                {
                    bolIcon = BuInformation.SelectPairTime(2, ck, newmessage.CreationDate);
                }
                else
                {
                    string strCur = HttpContext.Current.Session.SessionID;
                    bolIcon = BuInformation.SelectPairTime(1, strCur, newmessage.CreationDate);
                }
                if (bolIcon)
                {
                    HtmlImage iconNew = new HtmlImage();
                    iconNew = (HtmlImage)e.Item.FindControl("iconSub");
                    iconNew.Src = "../SlmImages/topic_new.png";
                }
                HtmlAnchor hrfMemberNew = new HtmlAnchor();
                hrfMemberNew = (HtmlAnchor)e.Item.FindControl("hrfMember");
                hrfMemberNew.InnerText = newmember.UserName.ToString();
                hrfMemberNew.HRef = "../showprofile.aspx?memberid=" + newmember.MemberId.ToString();
                HtmlAnchor hrfnewmNew = new HtmlAnchor();
                hrfnewmNew = (HtmlAnchor)e.Item.FindControl("hrfnewm");
                hrfnewmNew.Visible = true;
                hrfnewmNew.Title = LoadSLMF("SLMF_Forum", "GoToNewPost");
                hrfnewmNew.HRef = "../showtopic.aspx?messageid=" + newmessage.MessageId.ToString() + 
                                    "#message" + newmessage.MessageId.ToString();
            }
            else
            {
                Label lbl1new = new Label();
                lbl1new = (Label)e.Item.FindControl("lblTotalTopics");
                lbl1new.Text = newforum.TotalTopics.ToString();
                Label lbl2new = new Label();
                lbl2new = (Label)e.Item.FindControl("lblTotalMessages");
                lbl2new.Text = newforum.TotalMessages.ToString();
                Label lbl3new = new Label();
                lbl3new = (Label)e.Item.FindControl("lblTime");
                lbl3new.Text = slmNew.LoadLangs("SLMF_Forum", "NotHaveForum");
                HtmlAnchor hrfnewmNew = new HtmlAnchor();
                hrfnewmNew = (HtmlAnchor)e.Item.FindControl("hrfnewm");
                hrfnewmNew.Visible = false;
            }
        }
    }
    private string SentForCook()
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
    //protected void rptModerator_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //}
    protected void rptTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            int iforum = 0;
            if (((DbDataRecord)e.Item.DataItem)["ForumId"].ToString() != "")
            {
                iforum = int.Parse(((DbDataRecord)e.Item.DataItem)["ForumId"].ToString());
            }
            int ismoved = 0;
            if (((DbDataRecord)e.Item.DataItem)["MoveTo"].ToString() != "")
            {
                ismoved = int.Parse(((DbDataRecord)e.Item.DataItem)["MoveTo"].ToString());
            }
            EnTopic topicnew = new EnTopic();
            topicnew.TopicId = i;
            EnMember member1 = new EnMember();
            EnMember member2 = new EnMember();
            EnMessage message = new EnMessage();
            BuTopic.SelectTopicDetails(ref topicnew, ref member1, ref member2, ref message);
            HtmlAnchor hrfTitle = new HtmlAnchor();
            hrfTitle = (HtmlAnchor)e.Item.FindControl("hrfTopicName");
            hrfTitle.InnerText = message.Title;
            hrfTitle.HRef = "../showtopic.aspx?topicid=" + i.ToString();
            HtmlAnchor hrfStarterNew = new HtmlAnchor();
            hrfStarterNew = (HtmlAnchor)e.Item.FindControl("hrfStarter");
            hrfStarterNew.InnerText = member1.UserName;
            hrfStarterNew.HRef = "../showprofile.aspx?memberid=" + member1.MemberId.ToString();
            Label lblTime = new Label();
            lblTime = (Label)e.Item.FindControl("lblLastMsg");
            UtiString utinew = new UtiString();
            string strTime = utinew.TimeServer(message.CreationDate);
            lblTime.Text = strTime;
            if (topicnew.IsPinned)
            {
                UtiGeneralClass slmNew = new UtiGeneralClass();
                HtmlImage imgTopicNew = new HtmlImage();
                imgTopicNew = (HtmlImage)e.Item.FindControl("imgTopic");
                imgTopicNew.Src = "../SlmImages/topic_sticky.gif";
                imgTopicNew.Alt = slmNew.LoadLangs("SLMF_Topic", "AltSticky2");

                Label lblAlt = new Label();
                lblAlt = (Label)e.Item.FindControl("lblAltTopic");
                lblAlt.Visible = true;
            }
            else
            {
                string ck = "";
                bool bolIcon = false;
                ck = SentForCook();
                if (ck != "")
                {
                    bolIcon = BuInformation.SelectPairTime(2, ck, message.CreationDate);
                }
                else
                {
                    string strCur = HttpContext.Current.Session.SessionID;
                    bolIcon = BuInformation.SelectPairTime(1, strCur, message.CreationDate);
                }
                if (bolIcon)
                {
                    HtmlImage iconNew = new HtmlImage();
                    iconNew = (HtmlImage)e.Item.FindControl("imgTopic");
                    iconNew.Src = "../SlmImages/topic_new.png";
                    if (BuPoll.SelectIsPoll(topicnew))
                    {
                        HtmlImage ignew = new HtmlImage();
                        ignew = (HtmlImage)e.Item.FindControl("imgTopic");
                        ignew.Src = "../SlmImages/topic_poll_new.gif";
                    }
                    if (topicnew.IsLocked)
                    {
                        UtiGeneralClass slmNew = new UtiGeneralClass();
                        HtmlImage imgTopicNew = new HtmlImage();
                        imgTopicNew = (HtmlImage)e.Item.FindControl("imgTopic");
                        imgTopicNew.Src = "../SlmImages/topic_lock_new.gif";
                        imgTopicNew.Alt = slmNew.LoadLangs("SLMF_Message", "TopicClosed");
                    }
                }
                else
                {
                    if (BuPoll.SelectIsPoll(topicnew))
                    {
                        HtmlImage iconNew = new HtmlImage();
                        iconNew = (HtmlImage)e.Item.FindControl("imgTopic");
                        iconNew.Src = "../SlmImages/topic_poll.gif";
                    }
                    if (topicnew.IsLocked)
                    {
                        UtiGeneralClass slmNew = new UtiGeneralClass();
                        HtmlImage imgTopicNew = new HtmlImage();
                        imgTopicNew = (HtmlImage)e.Item.FindControl("imgTopic");
                        imgTopicNew.Src = "../SlmImages/topic_lock.gif";
                        imgTopicNew.Alt = slmNew.LoadLangs("SLMF_Message", "TopicClosed");
                    }
                }
                if (ismoved > 0 && iforum > 0 && iforum != ismoved && int.Parse(Request.Params["ForumId"].ToString()) != iforum)
                {
                    UtiGeneralClass slmNew = new UtiGeneralClass();
                    HtmlImage imgTopicNew = new HtmlImage();
                    imgTopicNew = (HtmlImage)e.Item.FindControl("imgTopic");
                    imgTopicNew.Src = "../SlmImages/topic_moved.gif";
                    imgTopicNew.Alt = slmNew.LoadLangs("SLMF_Topic", "TopicMoved");

                    Label lblAlt = new Label();
                    lblAlt = (Label)e.Item.FindControl("lblAltTopic");
                    lblAlt.Text = slmNew.LoadLangs("SLMF_Topic", "TopicMoved");
                    lblAlt.Visible = true;
                }
            }            
            HtmlAnchor hrfLstPosNew = new HtmlAnchor();
            hrfLstPosNew = (HtmlAnchor)e.Item.FindControl("hrfLastPoster");
            hrfLstPosNew.InnerText = member2.UserName;
            hrfLstPosNew.HRef = "../showprofile.aspx?memberid=" + member2.MemberId.ToString();
            HtmlAnchor hrfGoLast = new HtmlAnchor();
            hrfGoLast = (HtmlAnchor)e.Item.FindControl("hrfGoLastMsg");
            hrfGoLast.Title = LoadSLMF("SLMF_Forum", "GoToNewPost");
            hrfGoLast.HRef = "../showtopic.aspx?messageid=" + message.MessageId.ToString() + "#message" + message.MessageId.ToString();
        }
    }
    protected void TMessage1_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            int intIndex = Convert.ToInt32(e.CommandArgument);
            TMessage1.CurrentIndex = intIndex;
            TMessage2.CurrentIndex = intIndex;
            if (Request.Params["SortId"] != null)
            {
                int intSortId = int.Parse(Request.Params["SortId"].ToString());
                Response.Redirect("topicdisplay.aspx?forumid=" + intForumId + "&PageId=" + intIndex + 
                        "&SortId=" + intSortId);
            }
            else
            {
                Response.Redirect("topicdisplay.aspx?forumid=" + intForumId + "&PageId=" + intIndex);
            }
        }
    }
    protected void TMessage2_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            int intIndex = Convert.ToInt32(e.CommandArgument);
            TMessage1.CurrentIndex = intIndex;
            TMessage2.CurrentIndex = intIndex;
            if (Request.Params["SortId"] != null)
            {
                int intSortId = int.Parse(Request.Params["SortId"].ToString());
                Response.Redirect("topicdisplay.aspx?forumid=" + intForumId + "&PageId=" + intIndex +
                        "&SortId=" + intSortId);
            }
            else
            {
                Response.Redirect("topicdisplay.aspx?forumid=" + intForumId + "&PageId=" + intIndex);
            }
        }
    }
    protected void listfrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listfrom.SelectedValue != "-1" && Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            Session["intSortId"] = listfrom.SelectedIndex;
            Response.Redirect("topicdisplay.aspx?forumid=" + intForumId + 
                    "&SortId=" + listfrom.SelectedValue.ToString());
        }
        else if (listfrom.SelectedValue == "-1" && Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            Session["intSortId"] = listfrom.SelectedIndex;
            Response.Redirect("topicdisplay.aspx?forumid=" + intForumId +
                    "&SortId=" + 7);
        }
    }

    private void ListFromSelected(string SortId, int intForumId, int intCurrentId)
    {
        switch (SortId)
        {
            case "1":
                {
                    BindTopicSort(intForumId, intCurrentId , 2);
                    break;
                }
            case "2":
                {
                    BindTopicSort(intForumId, intCurrentId, 7);
                    break;
                }
            case "3":
                {
                    BindTopicSort(intForumId, intCurrentId, 31);
                    break;
                }
            case "4":
                {
                    BindTopicSort(intForumId, intCurrentId, 93);
                    break;
                }
            case "5":
                {
                    BindTopicSort(intForumId, intCurrentId, 186);
                    break;
                }
            case "6":
                {
                    BindTopicSort(intForumId, intCurrentId, 365);
                    break;
                }
            case "7":
                {
                    BindTopic(intForumId, intCurrentId);
                    break;
                }
        }
    }

    private int ListFromCount(string SortId)
    {
        int intCount = 0;
        switch (SortId)
        {
            case "1":
                {
                    intCount = 2;
                    break;
                }
            case "2":
                {
                    intCount = 7;
                    break;
                }
            case "3":
                {
                    intCount = 31;
                    break;
                }
            case "4":
                {
                    intCount = 93;
                    break;
                }
            case "5":
                {
                    intCount = 186;
                    break;
                }
            case "6":
                {
                    intCount = 365;
                    break;
                }
            case "7":
                {
                    intCount = -1;
                    break;
                }
        }
        return intCount;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strPhar = txtSearch.Text.ToString();
        if (strPhar != "" && Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            Response.Redirect("searchpro.aspx?forumid=" + intForumId + "&phrase=" + strPhar);
        }
    }
}