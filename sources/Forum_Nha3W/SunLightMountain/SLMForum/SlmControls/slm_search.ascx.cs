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

public partial class SlmControls_slm_search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadJumper();
            rbtTitle.Text = LoadSLMF("SLMF_SearchAdv", "FollowTitle");
            rbtMsg.Text = LoadSLMF("SLMF_SearchAdv", "FollowMsg");
            rbtAsc.Text = LoadSLMF("SLMF_SearchAdv", "OrderAsc");
            rbtDesc.Text = LoadSLMF("SLMF_SearchAdv", "OrderDesc");
            Reload();
            lstForum.SelectedValue = "-1";
            btnSearch.Text = LoadSLMF("SLMF_SearchAdv", "SearchButton");
            Page.Title = LoadSLMF("SLMF_SearchAdv", "Title") + ". " + LoadSLMF("TitleOfPage", "F9Light");
        }
    }

    private void Reload()
    {
        UtiGeneralClass secnew = new UtiGeneralClass();
        //SlmControls_slm_register.SrcCode = secnew.RdnCode(6);
        Session["IdCodeSecur"] = secnew.RdnCode(6);
    }

    private int CheckAvailable()
    {
        string strSecView = "";
        if (Session["IdCodeSecur"] != null)
        {
            strSecView = Session["IdCodeSecur"].ToString().ToUpper();
        }
        //string strSecView = SlmControls_slm_register.SrcCode.ToString();
        string strSecurity = txtSecurity.Text.ToString().ToUpper();
        int intResult = 0;
        if (strSecurity != strSecView)
        {
            intResult = -1;
            txtSecurity.Text = "";
        }
        return intResult;
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
                lstForum.Items.Add(LoadSLMF("SLMF_SearchPro", "Forum"));
                lstForum.Items[i].Value = "-1";
                i++;
            }
            lstForum.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            lstForum.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            i++;
            EnCategory cate = new EnCategory();
            cate.CategoryId = k;
            SqlDataReader datrj = BuForum.SelectJump(cate, mbr);
            if (datrj.HasRows)
            {
                while (datrj.Read())
                {
                    lstForum.Items.Add("- - " + datrj["Name"].ToString());
                    l = int.Parse(datrj["ForumId"].ToString());
                    lstForum.Items[i].Value = "topicdisplay.aspx?forumid=" + l.ToString();
                    i++;
                    EnForum frm = new EnForum();
                    frm.ForumId = l;
                    SqlDataReader j2 = BuForum.SelectJump2(frm, mbr);
                    if (j2.HasRows)
                    {
                        while (j2.Read())
                        {
                            lstForum.Items.Add("- - - - " + j2["Name"].ToString());
                            lstForum.Items[i].Value = "topicdisplay.aspx?forumid=" + j2["ForumId"].ToString();
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

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intReport = CheckAvailable();
        //pnlError.Visible = true;
        //UtiGeneralClass error = new UtiGeneralClass();
        if (intReport == -1)
        {
            //lblError.Text = error.LoadLangs("SLMF_Reg", "SecurityNull");
            Reload();
        }
        else
        {
            string strKeyword = txtKeyword.Text.ToString();
            bool bolTitleOrMsg = false;
            if (rbtMsg.Checked)
            {
                bolTitleOrMsg = true;
            }
            string strAuthor = txtAuthor.Text.ToString();
            int intForumId = 0;
            if (lstForum.SelectedValue == "-1")
            {
                intForumId = -1;
            }
            else
            {
                intForumId = int.Parse(FindString(lstForum.SelectedValue.ToString()));
            }
            bool bolAscOrDesc = false;
            if (rbtDesc.Checked)
            {
                bolAscOrDesc = true;
            }
            Response.Redirect("searchres.aspx?forumid=" + intForumId + "&phrase=" + strKeyword.ToString() +
                        "&type=" + bolTitleOrMsg + "&author=" + strAuthor.ToString() +
                        "&order=" + bolAscOrDesc);
        }
    }

    private string FindString(string strView)
    {
        return strView.Substring(26);
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
}
