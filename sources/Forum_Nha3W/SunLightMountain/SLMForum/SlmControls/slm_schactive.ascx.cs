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
using SLMF.Entity;
using SLMF.Business;

public partial class SlmControls_slm_schactive : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchOption();
            if (Request.Params["Search"] != null && Request.Params["Search"] != "")
            {
                ddlSearch.SelectedValue = Request.Params["Search"].ToString();
            }
            EnForum frm = new EnForum();
            string strLst = "Today";
            if (ddlSearch.SelectedValue.ToString() != "")
            {
                strLst = LoadLst(ddlSearch.SelectedValue);
            }
            //int intSumRows = BuForum.SelectLstCount(strLst);
            //int intMaxRecords = TMessage1.PageSize;
            //int intItems = 0;
            //if (intSumRows % intMaxRecords > 0)
            //{
            //    intItems = (intSumRows / intMaxRecords) + 1;
            //}
            //else
            //{
            //    intItems = (intSumRows / intMaxRecords);
            //}

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
            BindList(strLst, TMessage1.CurrentIndex);
            //if (intItems <= 1)
            //{
            //    TMessage1.Visible = false;
            //    TMessage2.Visible = false;
            //}
        }
        Page.Title = LoadSLMF("SLMF_Active", "NewTopic") + ". " + LoadSLMF("TitleOfPage", "F9Light");
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void SearchOption()
    {
        int i = 0;
        ddlSearch.Items.Add("Xem bài viết hôm nay");
        ddlSearch.Items[i].Value = "1";
        i++;
        ddlSearch.Items.Add("- - - 3 ngày trước đây");
        ddlSearch.Items[i].Value = "2";
        i++;
        ddlSearch.Items.Add("- - - 1 tuần trước đây");
        ddlSearch.Items[i].Value = "3";
        i++;
        ddlSearch.Items.Add("- - - 1 tháng trước đây");
        ddlSearch.Items[i].Value = "4";
        i++;
        ddlSearch.Items.Add("- - - 2 tháng trước đây");
        ddlSearch.Items[i].Value = "5";
    }

    private void BindList(string strList, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        SqlDataReader datrTopic = BuTopic.SelectList(strList, pager, mbr);
        rptForum.DataSource = datrTopic;
        rptForum.DataBind();
        if (datrTopic.IsClosed == false)
        {
            datrTopic.Close();
            datrTopic.Dispose();
        }
        int intCount = BuForum.SelectLstCount(strList, mbr);
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

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }


    protected void rptForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            bool i = bool.Parse(((DbDataRecord)e.Item.DataItem)[12].ToString());
            if (i == true)
            {
                HtmlImage iNew = new HtmlImage();
                iNew = (HtmlImage)e.Item.FindControl("imgActive");
                iNew.Src = "../SlmImages/topic_sticky.gif";
            }
        }
    }
    protected void TMessage1_Command(object sender, CommandEventArgs e)
    {
        int intIndex = Convert.ToInt32(e.CommandArgument);
        TMessage1.CurrentIndex = intIndex;
        TMessage2.CurrentIndex = intIndex;
        Response.Redirect("listactive.aspx?PageId=" + intIndex + "&search=" + ddlSearch.SelectedValue);
    }

    protected void TMessage2_Command(object sender, CommandEventArgs e)
    {
        int intIndex = Convert.ToInt32(e.CommandArgument);
        TMessage1.CurrentIndex = intIndex;
        TMessage2.CurrentIndex = intIndex;
        Response.Redirect("listactive.aspx?PageId=" + intIndex + "&search=" + ddlSearch.SelectedValue);
    }
    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList(LoadLst(ddlSearch.SelectedValue), 1);
        TMessage1.CurrentIndex = 1;
        TMessage2.CurrentIndex = 1;
    }

    private string LoadLst(string strLst)
    {
        string strSearch = "today";
        switch  (strLst)
        {
            case "2" : 
                {
                    strSearch = "3day";
                    break;
                }
            case "3":
                {
                    strSearch = "week";
                    break;
                }
            case "4":
                {
                    strSearch = "1month";
                    break;
                }
            case "5":
                {
                    strSearch = "2month";
                    break;
                }
        }
        return strSearch;
    }
}
