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
using SLMF.Business;
using SLMF.Entity;

public partial class SlmControls_slm_cpeditpro : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Attributes.Add("onclick", "GetSlmEnc();");
            EnMember mbr = new EnMember();
            mbr = RealUser();
            if (mbr.MemberId > 0)
            {
                int intMemberId = mbr.MemberId;
                LoadMonthList();
                LoadDayList(1);
                LoadYearList();
                LoadDdlGender();
                ProfileMember(intMemberId);
                btnSave.Text = LoadSLMF("SLMF_EditPro", "Save");
            }
            else
            {
                //Response.Redirect("login.aspx");
                Response.Redirect("../login.aspx");
            }
        }
    }

    private void ProfileMember(int intId)
    {
        if (intId > 0)
        {
            EnMember mbr = new EnMember();
            EnGroup grp = new EnGroup();
            EnMemberProfile pro = new EnMemberProfile();
            mbr.MemberId = intId;
            BuMemberProfile.SelectProfile(ref mbr, ref grp, ref pro);
            lblUserName.Text = mbr.UserName;
            Page.Title = LoadSLMF("SLMF_CPUser", "YourProfile") + ": " + mbr.UserName + ". " +
                                LoadSLMF("TitleOfPage", "F9Light");
            lblUserName2.Text = mbr.UserName;
            txtAboutMe.Text = pro.AboutMe;
            txtFullName.Text = mbr.FullName;
            if (bool.Parse(pro.IsEmailPublished.ToString()) == true)
            {
                ckbEmail.Checked = true;
                ckbEmail.Text = LoadSLMF("SLMF_EditPro", "EmailIsPublished");
            }
            else
            {
                ckbEmail.Checked = false;
                ckbEmail.Text = LoadSLMF("SLMF_EditPro", "EmailIsNotPublished");
            }
            if (pro.CanSendE)
            {
                ckbCanSendE.Checked = true;
                ckbCanSendE.Text = LoadSLMF("SLMF_EditPro", "CanSendE1");
            }
            else
            {
                ckbCanSendE.Checked = false;
                ckbCanSendE.Text = LoadSLMF("SLMF_EditPro", "CanSendE0");
            }
            txtMemberTitle.Text = pro.MemberTitle;
            txtEmail.Text = mbr.Email;
            if (pro.BirthDay.ToString() != "" && pro.BirthDay.ToShortDateString() != "1/1/0001")
            {
                ddlDay.SelectedIndex = int.Parse(pro.BirthDay.Day.ToString());
                ddlMonth.SelectedIndex = int.Parse(pro.BirthDay.Month.ToString());
                ddlYear.SelectedValue = pro.BirthDay.Year.ToString();
            }
            string strBlog = pro.Blog;
            int test = 0;
            if (strBlog != "")
            {
                test = String.Compare(strBlog.Substring(0, 7), "http://");
                if (test == 1)
                {
                    strBlog = "http://" + pro.Blog;
                }
            }
            txtBlog.Text = strBlog;
            string strPage = pro.HomePage;
            if (strPage != "")
            {
                test = String.Compare(strPage.Substring(0, 7), "http://");
                if (test == 1)
                {
                    strPage = "http://" + pro.HomePage;
                }
            }
            txtWebsite.Text = strPage;
            txtIcq.Text = pro.Icq;
            txtInterests.Text = pro.Interests;
            txtJob.Text = pro.Job;
            txtLocation.Text = pro.Location;
            txtYahoo.Text = pro.Yahoo;
            txtMsn.Text = pro.Msn;
            txtAol.Text = pro.Aim;
            txtMyRss.Text = pro.MyRSS;
            if (pro.Gender == false)
            {
                ddlGender.SelectedIndex = 1;
            }
            else
            {
                ddlGender.SelectedIndex = 0;
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    private void LoadDdlGender()
    {
        int i = 0;
        while (i < 2)
        {
            if (i == 0)
            {
                ddlGender.Items.Add(LoadSLMF("SLMF_EditPro", "Male"));
                ddlGender.Items[i].Value = "1";
                i++;
            }
            else if (i == 1)
            {
                ddlGender.Items.Add(LoadSLMF("SLMF_EditPro", "Female"));
                ddlGender.Items[i].Value = "0";
                i++;
            }
        }
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

    private EnMember RealUser()
    {
        EnMember mbr = new EnMember();
        mbr.UserName = LookCookie();
        if (mbr.UserName != "")
        {
            mbr = BuMember.SelectMemberIdFUser(mbr);
        }
        return mbr;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EnMember mbr = new EnMember();
        mbr = RealUser();
        if (mbr.MemberId > 0)
        {
            int intMemberId = mbr.MemberId;
            UpdateMember(intMemberId);
            lblReport.Text = LoadSLMF("SLMF_EditPro", "ReSave");
        }
    }

    private void UpdateMember(int intMemberId)
    {
        EnMember mbr = new EnMember();
        EnMemberProfile pro = new EnMemberProfile();
        mbr.MemberId = intMemberId;
        mbr.FullName = txtFullName.Text.ToString();
        mbr.Email = txtEmail.Text.ToString();
        pro.AboutMe = txtAboutMe.Text.ToString();
        pro.Interests = txtInterests.Text.ToString();
        pro.Job = txtJob.Text.ToString();
        pro.Location = txtLocation.Text.ToString();
        pro.MyRSS = txtMyRss.Text.ToString();
        string strDate = "";
        if (ddlMonth.SelectedValue != "-1" && ddlDay.SelectedValue != "-1" && ddlYear.SelectedValue != "-1")
        {
            strDate = ddlMonth.SelectedValue.ToString() + "/" + ddlDay.SelectedValue.ToString() + "/" +
                ddlYear.SelectedValue.ToString();
        }
        else
        {
            strDate = "1/1/1987";
        }
        pro.BirthDay = DateTime.Parse(strDate);
        pro.Yahoo = txtYahoo.Text.ToString();
        pro.Aim = txtAol.Text.ToString();
        pro.Icq = txtIcq.Text.ToString();
        pro.Msn = txtMsn.Text.ToString();
        pro.Blog = txtBlog.Text.ToString();
        pro.HomePage = txtWebsite.Text.ToString();
        pro.MemberTitle = txtMemberTitle.Text.ToString();
        pro.IsEmailPublished = ckbEmail.Checked;
        if (ddlGender.SelectedValue == "1")
        {
            pro.Gender = true;
        }
        else
        {
            pro.Gender = false;
        }
        pro.CanSendE = ckbCanSendE.Checked;
        BuMemberProfile.UpdateMember(mbr, pro);
    }

    private void LoadYearList()
    {
        int i = 1920;
        int j = 0;
        while (i >= 1920 && i <= 2005)
        {
            if (j == 0)
            {
                ddlYear.Items.Add("- Năm -");
                ddlYear.Items[j].Value = "-1";
                j++;
            }
            ddlYear.Items.Add(i.ToString());
            ddlYear.Items[j].Value = i.ToString();
            j++;
            i++;
        }
    }

    private void LoadMonthList()
    {
        int i = 0;
        if (i == 0)
        {
            ddlMonth.Items.Add("-- Tháng --");
            ddlMonth.Items[i].Value = "-1";
            i++;
        }
        ddlMonth.Items.Add("01");
        ddlMonth.Items.Add("02");
        ddlMonth.Items.Add("03");
        ddlMonth.Items.Add("04");
        ddlMonth.Items.Add("05");
        ddlMonth.Items.Add("06");
        ddlMonth.Items.Add("07");
        ddlMonth.Items.Add("08");
        ddlMonth.Items.Add("09");
        ddlMonth.Items.Add("10");
        ddlMonth.Items.Add("11");
        ddlMonth.Items.Add("12");
    }

    private void LoadDayList(int intmax)
    {
        int i = 0;
        if (i == 0)
        {
            ddlDay.Items.Add("-- Ngày --");
            ddlDay.Items[i].Value = "-1";
            i++;
        }
        ddlDay.Items.Add("01");
        ddlDay.Items.Add("02");
        ddlDay.Items.Add("03");
        ddlDay.Items.Add("04");
        ddlDay.Items.Add("05");
        ddlDay.Items.Add("06");
        ddlDay.Items.Add("07");
        ddlDay.Items.Add("08");
        ddlDay.Items.Add("09");
        ddlDay.Items.Add("10");
        ddlDay.Items.Add("11");
        ddlDay.Items.Add("12");
        ddlDay.Items.Add("13");
        ddlDay.Items.Add("14");
        ddlDay.Items.Add("15");
        ddlDay.Items.Add("16");
        ddlDay.Items.Add("17");
        ddlDay.Items.Add("18");
        ddlDay.Items.Add("19");
        ddlDay.Items.Add("20");
        ddlDay.Items.Add("21");
        ddlDay.Items.Add("22");
        ddlDay.Items.Add("23");
        ddlDay.Items.Add("24");
        ddlDay.Items.Add("25");
        ddlDay.Items.Add("26");
        ddlDay.Items.Add("27");
        ddlDay.Items.Add("28");
        if (intmax == 3)
        {
            return;
        }
        ddlDay.Items.Add("29");
        if (intmax == 4)
        {
            return;
        }
        ddlDay.Items.Add("30");
        if (intmax == 2)
        {
            return;
        }
        ddlDay.Items.Add("31");
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedValue != "-1")
        {
            ddlDay.Items.Clear();
            int i = int.Parse(ddlMonth.SelectedItem.Text.ToString());
            int j = 0;
            if (ddlYear.SelectedValue != "-1")
            {
                j = int.Parse(ddlYear.SelectedItem.Text.ToString());
            }
            if (i % 2 == 0 && i != 2)
            {
                LoadDayList(2);
            }
            else if (i % 2 != 0)
            {
                LoadDayList(1);
            }
            else if (i == 2 && isReal(j) && j>0)
            {
                LoadDayList(4);
            }
            else if (i == 2)
            {
                LoadDayList(3);
            }
        }

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedValue != "-1")
        {
            int i = int.Parse(ddlYear.SelectedItem.Text.ToString());
            int j = 0;
            if (ddlMonth.SelectedValue != "-1")
            {
                j = int.Parse(ddlMonth.SelectedItem.Text.ToString());
            }
            if (isReal(i) && j == 2)
            {
                ddlDay.Items.Clear();
                LoadDayList(4);
            }
            else if (isReal(i) == false && j == 2)
            {
                ddlDay.Items.Clear();
                LoadDayList(3);
            }
        }
    }

    private bool isReal(int i)
    {
        if ((i % 4 == 0 && i % 100 != 0) || (i % 400 == 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
