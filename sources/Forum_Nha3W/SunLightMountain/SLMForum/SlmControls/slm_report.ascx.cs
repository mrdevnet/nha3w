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

public partial class SlmControls_slm_report : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["announceid"] != null)
            {
                int intRpt = int.Parse(Request.Params["announceid"].ToString());
                BindReport(intRpt);
                PageLinks(intRpt);
                UpdateViews(intRpt);
            }
        }
    }

    private void BindReport(int intReportId)
    {
        //intTopicId = int.Parse(Request.Params["topicid"].ToString());
        EnReport rpt = new EnReport();
        rpt.ReportId = intReportId;
        SqlDataReader datrTpc = BuReport.ShowReport(rpt);
        rptMessage.DataSource = datrTpc;
        rptMessage.DataBind();
        if (datrTpc.IsClosed == false)
        {
            datrTpc.Close();
            datrTpc.Dispose();
        }
    }

    public string LoadText(string strA, string strB)
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

    public int RequestId()
    {
        int intRpt = 0;
        if (Request.Params["announceid"] != null)
        {
            intRpt = int.Parse(Request.Params["announceid"].ToString());
        }
        return intRpt;
    }

    private void UpdateViews(int intRptId)
    {
        EnReport rpt = new EnReport();
        rpt.ReportId = intRptId;
        BuReport.UpdateViews(rpt);
    }

    private void PageLinks(int intRptId)
    {
        hplCategory.InnerHtml = LoadText("SLMF_Topic", "IconAnnouncement");
        hplCategory.HRef = "../announcement.aspx?announceid=" + intRptId.ToString();
        hplCategory2.InnerHtml = LoadText("SLMF_Topic", "IconAnnouncement");
        hplCategory2.HRef = "../announcement.aspx?announceid=" + intRptId.ToString();
        EnReport rpt = new EnReport();
        rpt.ReportId = intRptId;
        SqlDataReader datr = BuReport.ShowReport(rpt);
        if (datr.Read())
        {
            string strRpt = datr["Title"].ToString();
            lblTopicTitle1.Text = strRpt;
            lblTopicTitle2.Text = strRpt;
            lblTopic2.Text = strRpt;
            Page.Title = strRpt + ". " + LoadText("TitleOfPage", "F9Light");
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
            string strAutName = ((DbDataRecord)e.Item.DataItem)[2].ToString();
            EnReport rptNew = new EnReport();
            rptNew.ReportId = intMessageId;
            EnMember mbr1 = new EnMember();
            EnMemberProfile mbrpro = new EnMemberProfile();
            EnGroup grp = new EnGroup();
            EnMessage msg = new EnMessage();
            string strDate = "";
            SqlDataReader datrMember = BuReport.ShowReport(rptNew);
            ProfileMbr(datrMember, ref mbr1, ref grp, ref mbrpro, ref strDate, ref msg);
            if (datrMember.IsClosed == false)
            {
                datrMember.Close();
                datrMember.Dispose();
            }
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
            System.Text.StringBuilder strOutput = new System.Text.StringBuilder(2000);
            System.Text.StringBuilder strUser = new System.Text.StringBuilder(400);
            strOutput.Append(msg.Message.ToString());
            strUser.Append("<div style=\"padding-top:3px;padding-bottom:2px;\">" + mbrpro.MemberTitle.ToString() + "</div>");
            if (mbrpro.Avatar != "")
            {
                strUser.Append("<img src=\"SlmUploads/avatar/" + mbrpro.Avatar.ToString() + "\"/><br/>");
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
            //strUser.Append(LoadText("SLMF_Message", "Posts") + mbrpro.TotalPosts.ToString() + "<br/>");
            if (mbrpro.Location != "")
            {
                strUser.Append(LoadText("SLMF_Message", "Location") + mbrpro.Location.ToString());
            }
            strUser.Append("<div style=\"padding-bottom:5px\"></div>");
            Label userbox = new Label();
            userbox = (Label)e.Item.FindControl("lblUserBox");
            userbox.Text = strUser.ToString();

            if (mbrpro.Signature.ToString() != "")
            {
                strOutput.Append("<br/>---------------------------------<br/>" + mbrpro.Signature.ToString());
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
            lblTimeFinish.Text = strDate;
        }
    }

    private void ProfileMbr(IDataReader reader, ref EnMember mbr, ref EnGroup grp, 
                                ref EnMemberProfile pro, ref string strDate, ref EnMessage msg)
    {
        if (reader.Read())
        {
            mbr.UserName = reader["UserName"].ToString();
            mbr.DateCreation = DateTime.Parse(reader["DateCreation"].ToString());
            pro.MemberTitle = reader["MemberTitle"].ToString();
            pro.Location = reader["Location"].ToString();
            pro.Yahoo = reader["Yahoo"].ToString();
            pro.Aim = reader["Aim"].ToString();
            pro.Icq = reader["Icq"].ToString();
            pro.Msn = reader["Msn"].ToString();
            pro.Blog = reader["Blog"].ToString();
            pro.HomePage = reader["HomePage"].ToString();
            pro.Avatar = reader["Avatar"].ToString();
            pro.Signature = reader["SignOfUser"].ToString();
            pro.TotalPosts = int.Parse(reader["TotalPosts"].ToString());
            pro.UserStatus = bool.Parse(reader["UserStatus"].ToString());
            grp.GroupName = reader["GroupName"].ToString();
            grp.RankImage = reader["RankImage"].ToString();
            strDate = LoadText("SLMF_Profile", "Started") + " " + 
                        DateTime.Parse(reader["CreationDate"].ToString()).Day.ToString() + "/" +
                        DateTime.Parse(reader["CreationDate"].ToString()).Month.ToString() + "/" +
                        DateTime.Parse(reader["CreationDate"].ToString()).Year.ToString() + " " + 
                        LoadText("SLMF_Profile", "Finished") + " " + 
                        DateTime.Parse(reader["FinishDate"].ToString()).Day.ToString() + "/" +
                        DateTime.Parse(reader["FinishDate"].ToString()).Month.ToString() + "/" +
                        DateTime.Parse(reader["FinishDate"].ToString()).Year.ToString();
            msg.Message = reader["Message"].ToString();
        }
    }
}
