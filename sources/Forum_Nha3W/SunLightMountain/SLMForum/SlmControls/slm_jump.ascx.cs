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

public partial class SlmControls_slm_jump : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadJumper();
            if (Request.Params["GroupId"] != null)
            {
                int i = int.Parse(Request.Params["GroupId"].ToString());
                ddlJumper.SelectedValue = "forumdisplay.aspx?groupid=" + i;
                ddlJumper.Items[ddlJumper.SelectedIndex].Selected = true;
            }
            else if (Request.Params["ForumId"] != null)
            {
                int k = int.Parse(Request.Params["ForumId"].ToString());
                ddlJumper.SelectedValue = "topicdisplay.aspx?forumid=" + k;
                ddlJumper.Items[ddlJumper.SelectedIndex].Selected = true;
            }
            else if (Request.Params["TopicId"] != null && Request.Params["MessageId"] == null)
            {
                int l = int.Parse(Request.Params["TopicId"].ToString());
                EnTopic t = new EnTopic();
                t.TopicId = l;
                EnForum frm = new EnForum();
                frm = BuTopic.SelectForumId(t);
                ddlJumper.SelectedValue = "topicdisplay.aspx?forumid=" + frm.ForumId.ToString();
                ddlJumper.Items[ddlJumper.SelectedIndex].Selected = true;
            }
            else if (Request.Params["MessageId"] != null && Request.Params["TopicId"] == null)
            {
                int l = int.Parse(Request.Params["MessageId"].ToString());
                EnMessage n = new EnMessage();
                n.MessageId = l;
                EnTopic t = new EnTopic();
                t.TopicId = BuMessage.SelectTopicId(n);
                EnForum frm = new EnForum();
                frm = BuTopic.SelectForumId(t);
                ddlJumper.SelectedValue = "topicdisplay.aspx?forumid=" + frm.ForumId.ToString();
                ddlJumper.Items[ddlJumper.SelectedIndex].Selected = true;
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
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
                ddlJumper.Items.Add(LoadSLMF("SLMF_Forum", "SelectForum"));
                ddlJumper.Items[i].Value = "-1";
                i++;
            }
            if (i == 1)
            {
                ddlJumper.Items.Add(LoadSLMF("SLMF_Forum", "VLF"));
                ddlJumper.Items[i].Value = "Default.aspx";
                i++;
            }
            ddlJumper.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            ddlJumper.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            i++;
            EnCategory cate = new EnCategory();
            cate.CategoryId = k;
            SqlDataReader datrj = BuForum.SelectJump(cate, mbr);
            if (datrj.HasRows)
            {
                while (datrj.Read())
                {
                    ddlJumper.Items.Add("- - " + datrj["Name"].ToString());
                    l = int.Parse(datrj["ForumId"].ToString());
                    ddlJumper.Items[i].Value = "topicdisplay.aspx?forumid=" + l.ToString();
                    i++;
                    EnForum frm = new EnForum();
                    frm.ForumId = l;
                    SqlDataReader j2 = BuForum.SelectJump2(frm, mbr);
                    if (j2.HasRows)
                    {
                        while (j2.Read())
                        {
                            ddlJumper.Items.Add("- - - - " + j2["Name"].ToString());
                            ddlJumper.Items[i].Value = "topicdisplay.aspx?forumid=" + j2["ForumId"].ToString();
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
    protected void ddlJumper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJumper.SelectedValue != "-1")
        {
            Response.Redirect(ddlJumper.SelectedValue.ToString());
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
}
