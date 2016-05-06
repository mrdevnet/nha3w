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

public partial class SlmControls_slm_searchres : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = LoadSLMF("SLMF_SearchPro", "Result") + ". " + LoadSLMF("TitleOfPage", "F9Light");
            if (Request.Params["author"] != null && Request.Params["forumid"] != null
                    && Request.Params["forumid"] != "" && Request.Params["phrase"] != null &&
                    Request.Params["type"] != null && Request.Params["order"] != null)
            {
                EnMember mbr = new EnMember();
                mbr.UserName = Request.Params["author"].ToString();
                int forumid = int.Parse(Request.Params["forumid"].ToString());
                string strView = Request.Params["phrase"].ToString();
                bool bolTilte = bool.Parse(Request.Params["type"].ToString());
                bool bolOrder = bool.Parse(Request.Params["order"].ToString());
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
                BindMsg(forumid, strView, bolTilte, bolOrder, mbr, TMessage1.CurrentIndex);
            }
        }
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

    private void BindMsg(int intForum, string strView, bool bolTitle, bool bolOrder, EnMember mbr, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr2 = new EnMember();
        mbr2.UserName = SentForCook();
        SqlDataReader dtrAdv = BuMessage.SearchAdv(intForum, strView, bolTitle, mbr, bolOrder, pager, mbr2);
        rptForum.DataSource = dtrAdv;
        rptForum.DataBind();
        if (dtrAdv.IsClosed == false)
        {
            dtrAdv.Close();
            dtrAdv.Dispose();
        }
        int intCount = BuMessage.SearchAdvCount(intForum, strView, bolTitle, mbr, mbr2);
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

    protected void TMessage1_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["author"] != null && Request.Params["forumid"] != null
                    && Request.Params["forumid"] != "" && Request.Params["phrase"] != null &&
                    Request.Params["type"] != null && Request.Params["order"] != null)
        {
            string strUser = Request.Params["author"].ToString();
            int forumid = int.Parse(Request.Params["forumid"].ToString());
            string strView = Request.Params["phrase"].ToString();
            bool bolTilte = bool.Parse(Request.Params["type"].ToString());
            bool bolOrder = bool.Parse(Request.Params["order"].ToString());
            int intIndex = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("searchres.aspx?forumid=" + forumid + "&phrase=" + strView.ToString() +
                        "&type=" + bolTilte + "&author=" + strUser.ToString() +
                        "&order=" + bolOrder + "&pageid=" + intIndex);
        }
    }
    protected void TMessage2_Command(object sender, CommandEventArgs e)
    {
        if (Request.Params["author"] != null && Request.Params["forumid"] != null
                    && Request.Params["forumid"] != "" && Request.Params["phrase"] != null &&
                    Request.Params["type"] != null && Request.Params["order"] != null)
        {
            string strUser = Request.Params["author"].ToString();
            int forumid = int.Parse(Request.Params["forumid"].ToString());
            string strView = Request.Params["phrase"].ToString();
            bool bolTilte = bool.Parse(Request.Params["type"].ToString());
            bool bolOrder = bool.Parse(Request.Params["order"].ToString());
            int intIndex = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("searchres.aspx?forumid=" + forumid + "&phrase=" + strView.ToString() +
                        "&type=" + bolTilte + "&author=" + strUser.ToString() +
                        "&order=" + bolOrder + "&pageid=" + intIndex);
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
}
