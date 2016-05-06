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

public partial class SlmControls_slm_memberlist : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intSumRows = BuMember.SelectMbrCount();
            int intMaxRecords = TMessage1.PageSize;
            int intItems = 0;
            if (intSumRows % intMaxRecords > 0)
            {
                intItems = (intSumRows / intMaxRecords) + 1;
            }
            else
            {
                intItems = (intSumRows / intMaxRecords);
            }

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
            BindList(TMessage1.CurrentIndex);
            if (intItems <= 1)
            {
                TMessage1.Visible = false;
                TMessage2.Visible = false;
            }
            btnSearch.Text = LoadSLMF("SLMF_Members", "Search");
        }
        Page.Title = LoadSLMF("SLMF_Members", "ListMembers") + ". " + LoadSLMF("TitleOfPage", "F9Light");
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void BindList(int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        SqlDataReader datrMember = BuMember.SelectMemberLst(pager);
        rptForum.DataSource = datrMember;
        rptForum.DataBind();
        if (datrMember.IsClosed == false)
        {
            datrMember.Close();
            datrMember.Dispose();
        }
        int intCount = BuMember.SelectMbrCount();
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

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }
    protected void TMessage1_Command(object sender, CommandEventArgs e)
    {
        int intIndex = Convert.ToInt32(e.CommandArgument);
        TMessage1.CurrentIndex = intIndex;
        TMessage2.CurrentIndex = intIndex;
        Response.Redirect("memberlist.aspx?PageId=" + intIndex);
    }
    protected void TMessage2_Command(object sender, CommandEventArgs e)
    {
        int intIndex = Convert.ToInt32(e.CommandArgument);
        TMessage1.CurrentIndex = intIndex;
        TMessage2.CurrentIndex = intIndex;
        Response.Redirect("memberlist.aspx?PageId=" + intIndex);
    }
    protected void rptForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            EnMember mbr = new EnMember();
            mbr.MemberId = i;
            EnGroup grp = new EnGroup();
            EnMemberProfile pro = new EnMemberProfile();
            BuMemberProfile.SelectProfile(ref mbr, ref grp, ref pro);
            HtmlImage iNew = new HtmlImage();
            iNew = (HtmlImage)e.Item.FindControl("imgRank");
            iNew.Src = "../SlmImages/" + grp.RankImage;
            if (!pro.CanSendE)
            {
                HtmlAnchor hrfENew = new HtmlAnchor();
                hrfENew = (HtmlAnchor)e.Item.FindControl("hrfEmail");
                hrfENew.Visible = false;
            }
            Label Gn = new Label();
            Gn = (Label)e.Item.FindControl("lblGroup");
            Gn.Text = grp.GroupName;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            string strSearch = txtSearch.Text.ToString().Trim();
            BindSearch(strSearch, 1);
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
        else
        {
            BindList(1);
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
    }

    public void KeyPress()
    {
        if (txtSearch.Text != "")
        {
            string strSearch = txtSearch.Text.ToString().Trim();
            BindSearch(strSearch, 1);
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
        else
        {
            BindList(1);
            TMessage1.CurrentIndex = 1;
            TMessage2.CurrentIndex = 1;
        }
    }

    private void BindSearch(string strSearch, int intCurrentId)
    {
        EnPagerF pager = new EnPagerF();
        pager.CurrentPage = intCurrentId;
        pager.PageSize = TMessage1.PageSize;
        SqlDataReader datrMember = BuMember.SelectMbrSch(strSearch, pager);
        rptForum.DataSource = datrMember;
        rptForum.DataBind();
        if (datrMember.IsClosed == false)
        {
            datrMember.Close();
            datrMember.Dispose();
        }
        int intCount = BuMember.SelectMbrSchCount(strSearch);
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
}
