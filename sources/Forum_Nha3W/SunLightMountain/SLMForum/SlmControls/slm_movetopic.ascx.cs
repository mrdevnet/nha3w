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

public partial class SlmControls_slm_movetopic : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["topicid"] != null)
            {
                LoadJumper();
                rbtOldLink.Text = LoadSLMF("SLMF_Topic", "MoveRelation");
                rbtNotOldLink.Text = LoadSLMF("SLMF_Topic", "NotMoveRelation");
                btnMoveTopic.Text = LoadSLMF("SLMF_Topic", "MoveAgree");
                btnClose.Text = LoadSLMF("SLMF_Topic", "MoveClose");
                int intTopicId = int.Parse(Request.Params["topicid"].ToString());
                
                EnTopic t = new EnTopic();
                t.TopicId = intTopicId;
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
    protected void btnMoveTopic_Click(object sender, EventArgs e)
    {
        if (ddlJumper.SelectedValue != "-1" && Request.Params["TopicId"].ToString() != null)
        {
            int intTpcId = int.Parse(Request.Params["TopicId"].ToString());
            EnTopic t = new EnTopic();
            t.TopicId = intTpcId;
            EnForum frm = new EnForum();
            frm = BuTopic.SelectForumId(t);
            string strSub = ddlJumper.SelectedValue.Substring(18, 7);
            int intForumId = int.Parse(FindString(ddlJumper.SelectedValue.ToString()));
            if (strSub != "groupid" && frm.ForumId != intForumId)
            {
                EnTopic tpc = new EnTopic();
                tpc.MoveTo = intForumId;
                tpc.TopicId = intTpcId;
                if (rbtOldLink.Checked)
                {
                    BuTopic.UpdateMoveTo(tpc, true);
                }
                else
                    BuTopic.UpdateMoveTo(tpc, false);
                Response.Redirect("closeandrefresh.aspx?report=updated");
            }
            else if (frm.ForumId == intForumId)
            {
                Response.Redirect("closeandrefresh.aspx?report=forumid");
            }
            else
            {
                Response.Redirect("closeandrefresh.aspx?report=groupid");
            }
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
