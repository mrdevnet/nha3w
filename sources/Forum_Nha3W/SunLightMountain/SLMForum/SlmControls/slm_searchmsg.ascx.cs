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

public partial class SlmControls_slm_searchmsg : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadJumper();
            if (Session["IndexId"] != null && Session["IndexId"].ToString() != "")
            {
                ddlForum.SelectedIndex = int.Parse(Session["IndexId"].ToString());
            }
            else if (Request.Params["forumid"] != null)
            {
                ddlForum.SelectedValue = "topicdisplay.aspx?forumid=" + int.Parse(Request.Params["forumid"].ToString());
            }
            Page.Title = LoadSLMF("SLMF_SearchPro", "Result") + ". " + LoadSLMF("TitleOfPage", "F9Light");
            btnSearch.Text = LoadSLMF("SLMF_Members", "Search");
            if (Request.Params["author"] != null && Request.Params["author"] != "")
            {
                string strUser = Request.Params["author"].ToString();
                txtSearch.Text = strUser;
                /*int intSumRows = BuMessage.SelectMsgSearchCount("UserName", strUser);
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
                if (ddlForum.SelectedValue.ToString() == "-1")
                {
                    BindMsg("UserName", strUser, TMessage1.CurrentIndex);
                }
                else
                {
                    int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                    //int intId = int.Parse(Request.Params["IndexId"].ToString());
                    BindMsg2(intId, strUser, TMessage1.CurrentIndex);
                }
                /*if (intItems <= 1)
                {
                    TMessage1.Visible = false;
                    TMessage2.Visible = false;
                }*/
            }
            else if (Request.Params["phrase"] != null && Request.Params["phrase"] != "" && Request.Params["forumid"] != null)
            {
                string strUser = Request.Params["phrase"].ToString();
                txtSearch.Text = strUser;
                int intForumId = int.Parse(Request.Params["ForumId"].ToString());
                /*int intSumRows = BuMessage.SelectTpcSchCount(intForumId, strUser);
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
                if (ddlForum.SelectedValue.ToString() == "-1")
                {
                    BindMsg4(strUser, TMessage1.CurrentIndex);
                }
                else
                {
                    //int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                    //int intId = int.Parse(Request.Params["IndexId"].ToString());
                    BindMsg3(intForumId, strUser, TMessage1.CurrentIndex);
                }
                /*if (intItems <= 1)
                {
                    TMessage1.Visible = false;
                    TMessage2.Visible = false;
                }*/
            }
        }
    }

    private void BindMsg(string strTake, string strView, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        SqlDataReader datrTopic = BuMessage.SelectMsgSearch(strTake, strView, pager, mbr);
        rptForum.DataSource = datrTopic;
        rptForum.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuMessage.SelectMsgSearchCount(strTake, strView, mbr);
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

    private void BindMsg2(int intForum, string strView, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        SqlDataReader datrTopic = BuMessage.SelectMsgForum(intForum, strView, pager, mbr);
        rptForum.DataSource = datrTopic;
        rptForum.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuMessage.SelectMsgForCount(intForum, strView, mbr);
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

    private void BindMsg3(int intForum, string strView, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        SqlDataReader datrTopic = BuMessage.SelectTpcSchForum(intForum, strView, pager, mbr);
        rptForum.DataSource = datrTopic;
        rptForum.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuMessage.SelectTpcSchCount(intForum, strView, mbr);
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

    private void BindMsg4(string strView, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        SqlDataReader datrTopic = BuMessage.SelectTpcSchForumA(strView, pager, mbr);
        rptForum.DataSource = datrTopic;
        rptForum.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuMessage.SelectTpcSchCountA(strView, mbr);
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

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void LoadJumper()
    {
        int i = 0, k = 0, l = 0;
        SqlDataReader jcate = BuCategory.SelectCategory();
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        while (jcate.Read())
        {
            if (i == 0)
            {
                ddlForum.Items.Add(LoadSLMF("SLMF_SearchPro", "Forum"));
                ddlForum.Items[i].Value = "-1";
                i++;
            }
            ddlForum.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            ddlForum.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            i++;
            EnCategory cate = new EnCategory();
            cate.CategoryId = k;
            SqlDataReader datrj = BuForum.SelectJump(cate, mbr);
            if (datrj.HasRows)
            {
                while (datrj.Read())
                {
                    ddlForum.Items.Add("- - " + datrj["Name"].ToString());
                    l = int.Parse(datrj["ForumId"].ToString());
                    ddlForum.Items[i].Value = "topicdisplay.aspx?forumid=" + l.ToString();
                    i++;
                    EnForum frm = new EnForum();
                    frm.ForumId = l;
                    SqlDataReader j2 = BuForum.SelectJump2(frm, mbr);
                    if (j2.HasRows)
                    {
                        while (j2.Read())
                        {
                            ddlForum.Items.Add("- - - - " + j2["Name"].ToString());
                            ddlForum.Items[i].Value = "topicdisplay.aspx?forumid=" + j2["ForumId"].ToString();
                            i++;
                        }
                    }
                    if (j2.IsClosed == false)
                    {
                        j2.Close();
                        j2.Dispose();
                    }
                }
            }
            if (datrj.IsClosed == false)
            {
                datrj.Close();
                datrj.Dispose();
            }
        }
        if (jcate.IsClosed == false)
        {
            jcate.Close();
            jcate.Dispose();
        }
    }


    protected void TMessage1_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["author"] != null)
        {
            if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() == "-1")
            {
                Session["IndexId"] = "-1";
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?author=" + i + "&PageId=" + intIndex);
            }
            else if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                Session["IndexId"] = ddlForum.SelectedIndex.ToString();
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?author=" + i + "&PageId=" + intIndex + "&IndexId=" + intId);
            }
        }
        else if (Request.Params["phrase"] != null && Request.Params["forumid"] != null)
        {
            if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() == "-1")
            {
                Session["IndexId"] = "-1";
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?phrase=" + i + "&PageId=" + intIndex + "&forumid=" + "-1");
            }
            else if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                Session["IndexId"] = ddlForum.SelectedIndex.ToString();
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?phrase=" + i + "&PageId=" + intIndex + "&forumid=" + intId);
            }
        }
    }
    protected void TMessage2_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["author"] != null)
        {
            if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() == "-1")
            {
                Session["IndexId"] = "-1";
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?author=" + i + "&PageId=" + intIndex);
            }
            else if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                Session["IndexId"] = ddlForum.SelectedIndex.ToString();
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?author=" + i + "&PageId=" + intIndex + "&IndexId=" + intId);
            }
        }
        else if (Request.Params["phrase"] != null && Request.Params["forumid"] != null)
        {
            if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() == "-1")
            {
                Session["IndexId"] = "-1";
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?phrase=" + i + "&PageId=" + intIndex + "&forumid=" + "-1");
            }
            else if (txtSearch.Text != "" && ddlForum.SelectedValue.ToString() != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                Session["IndexId"] = ddlForum.SelectedIndex.ToString();
                string i = txtSearch.Text.ToString().Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("searchpro.aspx?phrase=" + i + "&PageId=" + intIndex + "&forumid=" + intId);
            }
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

    protected void rptForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            bool i = bool.Parse(((DbDataRecord)e.Item.DataItem)[13].ToString());
            if (i == true)
            {
                HtmlImage iNew = new HtmlImage();
                iNew = (HtmlImage)e.Item.FindControl("imgActive");
                iNew.Src = "../SlmImages/topic_sticky.gif";
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "" && Request.Params["author"] != null)
        {
            string strView = txtSearch.Text.ToString().Trim();
            if (ddlForum.SelectedValue != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                BindMsg2(intId, strView, 1);
            }
            else
            {
                BindMsg("UserName", strView, 1);
            }
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
        else if (txtSearch.Text != "" && Request.Params["phrase"] != null)
        {
            string strView = txtSearch.Text.ToString().Trim();
            if (ddlForum.SelectedValue != "-1")
            {
                int intId = int.Parse(FindString(ddlForum.SelectedValue.ToString()));
                BindMsg3(intId, strView, 1);
            }
            else
            {
                BindMsg4(strView, 1);
            }
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
    }

    private string FindString(string strView)
    {
        return strView.Substring(26);
    }
}
