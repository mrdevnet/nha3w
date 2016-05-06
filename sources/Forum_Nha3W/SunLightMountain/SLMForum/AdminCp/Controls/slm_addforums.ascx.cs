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
using SLMF.Entity;
using SLMF.Business;

public partial class AdminCp_Controls_slm_addforums : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadJumper();
            LoadForumType();
            LoadCategories();
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "Submit");
            if (Request.Params["frmid"] != null)
            {
                int intFrmId = int.Parse(Request.Params["frmid"].ToString());
                LoadForumDetails(intFrmId);
                btnSave.Text = LoadSLMF("SLMF_ForumA", "btnUpdated");
                spnReport.InnerText = LoadSLMF("SLMF_ForumA", "Updated");
            }
            else
            {
                txtTotalTopics.Text = "0";
                txtTotalTopics.Enabled = false;
                txtTotalMessages.Text = "0";
                txtTotalMessages.Enabled = false;
                spnReport.InnerText = LoadSLMF("SLMF_ForumA", "AddNew");
            }
        }
    }

    private void LoadForumDetails(int intFrmId)
    {
        EnForum frm = new EnForum();
        frm.ForumId = intFrmId;
        EnForum frm2 = new EnForum();
        EnForumType type = new EnForumType();
        EnCategory cate = new EnCategory();
        BuForum.SelectForumFrId(ref frm, ref frm2, ref type, ref cate);
        txtName.Text = frm.Name;
        txtContent.Value = frm.Description;
        if (frm.SubForumId > 0)
        {
            ddlJumper.SelectedValue = "topicdisplay.aspx?forumid=" + frm.SubForumId.ToString();
        }
        else
        {
            ddlJumper.SelectedValue = "0";
        }
        ddlTypeForum.SelectedValue = type.TypeId.ToString();
        txtTotalTopics.Text = frm.TotalTopics.ToString();
        txtTotalMessages.Text = frm.TotalMessages.ToString();
        if (frm.SubForumId <= 0)
        {
            ddlCategories.SelectedValue = cate.CategoryId.ToString();
        }
        else
        {
            ddlCategories.SelectedValue = "-1";
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private string FindString(string strView)
    {
        return strView.Substring(26);
    }

    private void InsertForum()
    {
        if ((ddlTypeForum.SelectedValue.ToString() != "-1" && txtName.Text != "") &&
            (ddlJumper.SelectedValue.ToString() != "0" || ddlCategories.SelectedValue.ToString() != "-1"))
        {
            string strSub = ddlJumper.SelectedValue.ToString();
            int intForumId = 0;
            if (strSub != "0")
            {
                strSub = ddlJumper.SelectedValue.Substring(18, 7);
                intForumId = int.Parse(FindString(ddlJumper.SelectedValue.ToString()));
            }
            if (strSub != "groupid")
            {
                EnForum frm = new EnForum();
                frm.Name = txtName.Text.ToString();
                frm.Description = txtContent.Value.ToString();
                frm.SubForumId = intForumId;
                frm.TypeId = int.Parse(ddlTypeForum.SelectedValue.ToString());
                frm.TotalTopics = 0;
                frm.TotalMessages = 0;
                if (intForumId != 0)
                {
                    EnCategory catenew = new EnCategory();
                    EnForum frmnew = new EnForum();
                    frmnew.ForumId = intForumId;
                    BuForum.SelectForumInCate(ref frmnew, ref catenew);
                    frm.CateId = catenew.CategoryId;
                }
                else
                {
                    frm.CateId = int.Parse(ddlCategories.SelectedValue.ToString());
                }
                BuForum.InsertForums(frm);
                lblReport.Text = LoadSLMF("SLMF_ForumA", "SubmitSuccess");
                ResetControls();
            }
            else
            {
                lblReport.Text = LoadSLMF("SLMF_ForumA", "UnSelectSubForum");
            }
        }
        else
        {
            lblReport.Text = LoadSLMF("SLMF_ForumA", "UnableInfor");
        }
    }

    private void UpdateForums(int intFrmId)
    {
        if ((ddlTypeForum.SelectedValue.ToString() != "-1" && txtName.Text != "") && 
            (ddlJumper.SelectedValue.ToString() != "0" || ddlCategories.SelectedValue.ToString() != "-1"))
        {
            string strSub = ddlJumper.SelectedValue.ToString();
            int intForumId = 0;
            if (strSub != "0")
            {
                strSub = ddlJumper.SelectedValue.Substring(18, 7);
                intForumId = int.Parse(FindString(ddlJumper.SelectedValue.ToString()));
            }
            if (strSub != "groupid")
            {
                EnForum frm = new EnForum();
                frm.ForumId = intFrmId;
                frm.Name = txtName.Text.ToString();
                frm.Description = txtContent.Value.ToString();
                frm.SubForumId = intForumId;
                frm.TypeId = int.Parse(ddlTypeForum.SelectedValue.ToString());
                frm.TotalTopics = int.Parse(txtTotalTopics.Text.ToString());
                frm.TotalMessages = int.Parse(txtTotalMessages.Text.ToString());
                if (intForumId != 0)
                {
                    EnCategory catenew = new EnCategory();
                    EnForum frmnew = new EnForum();
                    frmnew.ForumId = intForumId;
                    BuForum.SelectForumInCate(ref frmnew, ref catenew);
                    frm.CateId = catenew.CategoryId;
                }
                else
                {
                    frm.CateId = int.Parse(ddlCategories.SelectedValue.ToString());
                }
                BuForum.UpdateForums(frm);
                lblReport.Text = LoadSLMF("SLMF_ForumA", "btnUpdatedSuccess");
                ResetControls();
            }
            else
            {
                lblReport.Text = LoadSLMF("SLMF_ForumA", "UnSelectSubForum");
            }
        }
        else
        {
            lblReport.Text = LoadSLMF("SLMF_ForumA", "UnableInfor");
        }
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
                ddlJumper.Items.Add(LoadSLMF("SLMF_ForumA", "SelectParForum"));
                ddlJumper.Items[i].Value = "0";
                i++;
            }
            //if (i == 1)
            //{
            //    ddlJumper.Items.Add(LoadSLMF("SLMF_Forum", "VLF"));
            //    ddlJumper.Items[i].Value = "Default.aspx";
            //    i++;
            //}
            ddlJumper.Items.Add(" [" + jcate["CateName"].ToString() + "] ");
            k = int.Parse(jcate["CategoryId"].ToString());
            ddlJumper.Items[i].Value = "forumdisplay.aspx?groupid=" + k.ToString();
            //ddlParForum.Items[i].Enabled = false;
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

    private void LoadForumType()
    {
        int i = 0;
        SqlDataReader rpt = BuForum.SelectAllForumType();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlTypeForum.Items.Add(LoadSLMF("SLMF_ForumA", "SelectTypeForum"));
                ddlTypeForum.Items[i].Value = "-1";
                i++;
            }
            ddlTypeForum.Items.Add(rpt["Description"].ToString());
            ddlTypeForum.Items[i].Value = rpt["TypeId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }

    private void LoadCategories()
    {
        int i = 0;
        SqlDataReader rpt = BuCategory.SelectAllCategories();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlCategories.Items.Add(LoadSLMF("SLMF_ForumA", "SelectCateId"));
                ddlCategories.Items[i].Value = "-1";
                i++;
            }
            ddlCategories.Items.Add(rpt["CateName"].ToString());
            ddlCategories.Items[i].Value = rpt["CategoryId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.Params["frmid"] != null)
        {
            int intFrmId = int.Parse(Request.Params["frmid"].ToString());
            UpdateForums(intFrmId);
        }
        else
        {
            InsertForum();
        }
    }

    private void ResetControls()
    {
        txtName.Text = "";
        txtContent.Value = "";
        txtTotalTopics.Text = "";
        txtTotalMessages.Text = "";
        ddlJumper.SelectedValue = "0";
        ddlTypeForum.SelectedValue = "-1";
        ddlCategories.SelectedValue = "-1";
    }

    protected void ddlJumper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJumper.SelectedValue.ToString() != "0")
        {
            ddlCategories.Enabled = false;
        }
        else
        {
            ddlCategories.Enabled = true;
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
