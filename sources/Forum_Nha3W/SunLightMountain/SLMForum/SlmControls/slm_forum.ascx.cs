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
using System.Collections.Generic;
using SLMF.Utility;
using SLMF.Business;
using SLMF.Entity;

public partial class SlmControls_slm_forum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["groupid"] != null)
            {
                int intCateId = int.Parse(Request.Params["groupid"].ToString());
                BindCateId(intCateId);
            }
            else
            {
                BindCategory();
                lblGroupName.Visible = false;
                lblSpace.Visible = false;
            }
            MembersOnline();
            LoadOnlineDetails();
            LoadAnalytics();
            //FastLogin();
            //btnLogin.Attributes.Add("onclick", "GetSlmEnc();");
            //ReviewCookieMember();
        }
    }

    //private void FastLogin()
    //{
    //    txtUser.ToolTip = LoadSLMF("SLMF_FastLog", "User");
    //    txtPass.ToolTip = LoadSLMF("SLMF_FastLog", "Pass");
    //    ckbRemember.ToolTip = LoadSLMF("SLMF_FastLog", "SavePass");
    //    btnLogin.Text = LoadSLMF("SLMF_FastLog", "Login");
    //    rfv1.ToolTip = LoadSLMF("SLMF_FastLog", "Rfv1");
    //    rfv2.ToolTip = LoadSLMF("SLMF_FastLog", "Rfv2");
    //}

    private void MembersOnline()
    {
        int f1 = 0;
        int f2 = 0;
        int f3 = 0;
        int f4 = 0;
        DateTime f5 = new DateTime();
        BuInformation.SelectMemberOnline(ref f1, ref f2, ref f3, ref f4, ref f5);
        activeuser.Text = "Kỷ lục: " + f4.ToString() + " người dùng online vào ngày " + 
            f5.Day.ToString() + "/" + f5.Month.ToString() + "/" + f5.Year.ToString() + 
            " lúc " + f5.ToShortTimeString() + ".<br/>" + 
            "<a href=\"onlineuser.aspx\" class=\"TopicLink\" >" + LoadSLMF("SLMF_Forum", "TotalOnlines") + "</a> " +
            f1.ToString() + " - " + LoadSLMF("SLMF_Forum", "TotalGuests") + f3.ToString()  + ", " +
            LoadSLMF("SLMF_Forum", "TotalMembers") + f2.ToString();
    }

    private void LoadOnlineDetails()
    {
        SqlDataReader r = BuInformation.SelectMemberDetails();
        listuser.DataSource = r;
        listuser.DataBind();
        if (r.IsClosed == false)
        {
            r.Close();
            r.Dispose();
        }
    }

    private void LoadAnalytics()
    {
        EnAnalytics r = BuForum.SelectForumAnalytics();
        System.Text.StringBuilder anal = new System.Text.StringBuilder(450);

        anal.Append("Có tất cả: <b>" + r.Members + "</b> thành viên đã gửi: <b>" + //r["Members"].ToString()
                        r.Messages + "</b> bài viết trong tổng số: <b>" + //r["Messages"].ToString() 
                        r.Forums + "</b> diễn đàn. "); //r["Forums"].ToString() 
        anal.Append("Hiện tại có: <b>" + r.Topics + "</b> chủ đề.<br/>"); // r["Topics"].ToString() 
        anal.Append("Hân hạnh chào đón thành viên mới nhất: <b>" +
                        "<a class=\"TopicLink\" href=\"showprofile.aspx?memberid=" + r.MemberId + // r["MemberId"].ToString() 
                        "\">" + r.UserName + "</a></b><br/>"); // r["UserName"].ToString() 
        if (r.NewPost.ToString() != "")
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(r.NewPost.ToString()); // r["NewPost"].ToString()
            anal.Append("Bài viết mới nhất gửi bởi: <b>" +
                             "<a class=\"TopicLink\" href=\"showprofile.aspx?memberid=" + r.NewestMemberId + // r["NewMemberId"].ToString() 
                            "\">" + r.NewMember + "</a></b> " + // r["NewMember"].ToString()
                            "vào lúc: <b>" + dt.Day.ToString() + "/" + dt.Month.ToString() + "/" +
                            dt.Year.ToString() + " " + dt.ToShortTimeString() + "</b><br/>");
        }
        anal.Append("Bạn có thể vào đây để xem: " +
                         "<img align=\"absmiddle\" src=\"slmimages/pr7.gif\"/> <b><a class=\"TopicLink\" href=\"listactive.aspx" + "\">" + 
                         "Xem bài viết hôm nay" + "</a></b> | " +
                         "<img align=\"absmiddle\" src=\"slmimages/pr8.gif\"/> <b><a class=\"TopicLink\" href=\"listactive.aspx?search=3" + "\">" +
                         "Xem bài viết trong tuần" + "</a></b> | " +
                         "<img align=\"absmiddle\" src=\"slmimages/pr9.gif\"/> <b><a class=\"TopicLink\" href=\"listactive.aspx?search=4" + "\">" +
                         "Xem bài viết trong tháng" + "</a></b>");
        stats.Text = anal.ToString();
    }

    private void BindCateId(int intCategoryId)
    {
        EnCategory cate = new EnCategory();
        cate.CategoryId = intCategoryId;
        List<EnCategory> r = BuCategory.SelectCateFId(cate);
        rptCategory.DataSource = r;
        rptCategory.DataBind();
        lblGroupName.Text = r[0].CateName;
        lblGroupName.Visible = true;
        Page.Title = cate.CateName + ". " + LoadSLMF("TitleOfPage", "F9Light");
    }

    private void BindCategory()
    {
        rptCategory.DataSource = BuCategory.SelectCategory2();
        rptCategory.DataBind();
    }

    private List<EnForum> BindForum(int intCategoryId)
    {
        EnCategory category = new EnCategory();
        category.CategoryId = intCategoryId;
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        List<EnForum> datrForum = BuForum.SelectForum(category, mbr);
        return datrForum;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //int i = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());

            //int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            int i = (int)(((EnCategory)e.Item.DataItem).CategoryId);
            Repeater rptForumNew = new Repeater();
            rptForumNew = (Repeater)e.Item.FindControl("rptForum");
            rptForumNew.DataSource = BindForum(i);
            rptForumNew.DataBind();
        }
    }
    protected void rptForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //int i = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
            //int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            //int t = int.Parse(((DbDataRecord)e.Item.DataItem)[3].ToString());

            //int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());

            int i = (int)(((EnForum)e.Item.DataItem).ForumId);

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
            Repeater rptSubNew = new Repeater();
            rptSubNew = (Repeater)e.Item.FindControl("rptSubForum");
            int k = 0;
            List<EnForum> datrSub = BuForum.SelectSub2(forum, ref k);
            if (k == 1)
            {
                rptSubNew.DataSource = datrSub;
                rptSubNew.DataBind();
            }
            int viewing = BuInformation.SelectForumVieing(forum);
            if (viewing > 0)
            {
                Label lblVNew = new Label();
                lblVNew = (Label)e.Item.FindControl("lblViewing");
                lblVNew.Text = "[" + viewing.ToString() + " đang xem]";
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
                    iconNew = (HtmlImage)e.Item.FindControl("ifrm");
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
                hrfnewmNew.HRef = "../showtopic.aspx?messageid=" + newmessage.MessageId.ToString() + "#message" + newmessage.MessageId.ToString();
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

    //public SqlDataReader SelectModerator(int intforumid)
    //{
    //    SqlConnection connSach = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMFConnection"].ToString());
    //    SqlCommand commGoodIdear = new SqlCommand("getModerator", connSach);
    //    commGoodIdear.CommandType = CommandType.StoredProcedure;
    //    commGoodIdear.Parameters.AddWithValue("@ForumId", intforumid);
    //    commGoodIdear.Parameters.Add("@Result", SqlDbType.SmallInt);
    //    commGoodIdear.Parameters["@Result"].Direction = ParameterDirection.Output;
    //    commGoodIdear.Connection.Open();
    //    SqlDataReader datrIdeas = commGoodIdear.ExecuteReader(CommandBehavior.CloseConnection);
    //    return datrIdeas;
    //}

    //protected void rptSubForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //}

    public string GetTextTotal(string strInput)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = "";
        if (strInput == "TotalTocpicSub")
        {
            strOutput = slmNew.LoadLangs("SLMF_Forum", "TotalTocpicSub");
        }
        else if (strInput == "TotalMessSub")
        {
            strOutput = slmNew.LoadLangs("SLMF_Forum", "TotalMessSub");
        }
        return strOutput;
    }
    protected void listuser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            EnMember mbr = new EnMember();
            mbr.MemberId = i;
            if (!BuMember.SelectMemberGuest(mbr))
            {
                listuser.Visible = true;
                HtmlAnchor n = new HtmlAnchor();
                n = (HtmlAnchor)e.Item.FindControl("hrfUserOnline");
                n.HRef = "../showprofile.aspx?memberid=" + i;
                n.InnerHtml = ((DbDataRecord)e.Item.DataItem)[1].ToString();
                if (((DbDataRecord)e.Item.DataItem)[4].ToString() == "" && ((DbDataRecord)e.Item.DataItem)[5].ToString() == "")
                {
                    if (Request.Params["GroupId"] == null)
                    {
                        n.Title = "Đang ở Trang chủ Diễn đàn";
                        n.Title += " - Online: " + ((DbDataRecord)e.Item.DataItem)[10] + " phút";
                    }
                    else
                    {
                        EnCategory c = new EnCategory();
                        c.CategoryId = int.Parse(Request.QueryString["GroupId"].ToString());
                        string strCateName = BuCategory.SelectCateName(c);
                        n.Title = "Đang xem Nhóm Diễn đàn: [" + strCateName;
                        n.Title += "] - Online: " + ((DbDataRecord)e.Item.DataItem)[10] + " phút";
                    }
                }
                else if (((DbDataRecord)e.Item.DataItem)[4].ToString() == "" && ((DbDataRecord)e.Item.DataItem)[5].ToString() != "")
                {
                    n.Title = "Đang ở Diễn đàn: " + ((DbDataRecord)e.Item.DataItem)[6];
                    n.Title += " - Online: " + ((DbDataRecord)e.Item.DataItem)[10] + " phút";
                }
                else if (((DbDataRecord)e.Item.DataItem)[4].ToString() != "" && ((DbDataRecord)e.Item.DataItem)[5].ToString() != "")
                {
                    n.Title = "Đang xem Chủ đề: " + ((DbDataRecord)e.Item.DataItem)[7] + 
                                " tại Diễn đàn: " + ((DbDataRecord)e.Item.DataItem)[6];
                    n.Title += " - Online: " + ((DbDataRecord)e.Item.DataItem)[10] + " phút";
                }
            }
        }
    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    MemberLoginTry();
    //}

    //private void MemberLoginTry()
    //{
    //    UtiGeneralClass error = new UtiGeneralClass();
    //    string strUserName = txtUser.Text.ToString();
    //    string strPassword = txtPass.Text.ToString();
    //    //pnlError.Visible = true;
    //    if (strUserName == "" || strPassword == "")
    //    {
    //        //lblError.Text = error.LoadLangs("SLMF_Log", "InforRequired");
    //    }
    //    else
    //    {
    //        int intResult = 0;
    //        EnMember member = new EnMember();
    //        member.UserName = strUserName;
    //        intResult = BuMember.MemberLogin(member);
    //        if (intResult == -1)
    //        {
    //            //lblError.Text = error.LoadLangs("SLMF_Log", "UserNotExists");
    //        }
    //        else if (intResult == -2)
    //        {
    //            //lblError.Text = error.LoadLangs("SLMF_Log", "NotAllowLogin");
    //        }
    //        else if (intResult == -3)
    //        {
    //            //lblError.Text = error.LoadLangs("SLMF_Log", "Banned");
    //        }
    //        else if (intResult == -5)
    //        {
    //            //lblError.Text = error.LoadLangs("SLMF_Log", "IsActivated");
    //        }
    //        else if (intResult == -4)
    //        {
    //            //lblError.Text = error.LoadLangs("SLMF_Log", "EnableLogin");
    //        }
    //        else
    //        {
    //            string strPass = "", strSalt = "";
    //            strSalt = member.Salt;
    //            strPass = member.NewPassword;

    //            string strMd5Client = slmhas.Value.ToString();
    //            UtiHashMd5 md5 = new UtiHashMd5();
    //            string strMd5Server = md5.Md5Encode(strMd5Client + strSalt);

    //            if (strMd5Server == strPass)
    //            {
    //                int intReport = 0;
    //                EnMemberProfile memberprofile = new EnMemberProfile();
    //                memberprofile.IP = Request.ServerVariables["REMOTE_ADDR"];
    //                intReport = BuMemberProfile.LoginMemberSuccess(member, memberprofile);
    //                if (intReport == 1)
    //                {
    //                    //lblError.Text = error.LoadLangs("SLMF_Log", "LoginSuccess");
    //                    member.Password = strMd5Server;
    //                    SetCookieMember(member);
    //                    Response.Redirect("Default.aspx");
    //                }
    //            }
    //            else
    //            {
    //                //lblError.Text = error.LoadLangs("SLMF_Log", "PassIncorrect");
    //            }
    //        }
    //    }
    //}

    //private void SetCookieMember(EnMember member)
    //{
    //    HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
    //    HttpCookie SlmSessionId = new HttpCookie("SLMFSessionId");
    //    DateTime dateSLMF = DateTime.Now;
    //    SlmMemberCookie.Value = member.UserName;
    //    SlmMemberCookie.Expires = dateSLMF.AddDays(3);
    //    SlmSessionId.Value = member.Password;
    //    SlmSessionId.Expires = dateSLMF.AddDays(4);
    //    if (ckbRemember.Checked)
    //    {
    //        SlmMemberCookie.Expires = dateSLMF.AddDays(7);
    //        SlmSessionId.Expires = dateSLMF.AddDays(8);
    //    }
    //    Response.Cookies.Add(SlmMemberCookie);
    //    Response.Cookies.Add(SlmSessionId);
    //}


    //private void ReviewCookieMember()
    //{
    //    HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
    //    SlmMemberCookie = Request.Cookies["SLMFMembers"];
    //    if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
    //         SlmMemberCookie.Value != null)
    //    {
    //        pnlFastLog.Visible = false;
    //    }
    //    else
    //    {
    //        pnlFastLog.Visible = true;
    //    }
    //}
}