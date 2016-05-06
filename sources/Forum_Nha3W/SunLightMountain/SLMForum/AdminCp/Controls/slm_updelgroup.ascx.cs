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

public partial class AdminCp_Controls_slm_updelgroup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            spnReport.InnerText = LoadSLMF("SLMF_GroupA", "Title");
            btnSave.Text = LoadSLMF("SLMF_GroupA", "AddGroup");
            hrfUpload.Title = LoadSLMF("SLMF_GroupA", "UploadImgRank");
            lbtBlockUser.ToolTip = LoadSLMF("SLMF_GroupA", "Refresh");
            LoadDdlRank();
            if (Request.Params["grpid"] != null)
            {
                int intGrpId = int.Parse(Request.Params["grpid"].ToString());
                btnSave.Text = LoadSLMF("SLMF_GroupA", "UpdateGroup");
                spnReport.InnerText = LoadSLMF("SLMF_GroupA", "UpdateGroupTitle");
                LoadGroupDetails(intGrpId);
            }
            hrfUpload.Attributes.Add("onclick", "javascript:window.open('uploadfile.aspx?typeid=1','calwin','top=228,left=421,width=520,height=216,scrollbars=1')");
        }
    }

    private void LoadGroupDetails(int intGroupId)
    {
        EnGroup grp = new EnGroup();
        grp.GroupId = intGroupId;
        BuGroup.SelectGroupDetails(ref grp);
        if (grp.GroupName != "")
        {
            txtGroupName.Value = grp.GroupName;
            txtGetPosts.Text = grp.GetPosts.ToString();
            txtPmLimit.Text = grp.PmLimit.ToString();
            imgRankImage.Src = "~/slmimages/" + grp.RankImage;
            imgRankImage.Visible = true;
            ddlRank.SelectedValue = grp.RankImage;
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadDdlRank()
    {
        SqlDataReader datrRank = BuGroup.SelectRankImage();
        int i = 0;
        while (datrRank.Read())
        {
            if (i == 0)
            {
                ddlRank.Items.Add(LoadSLMF("SLMF_GroupA","SelectRankImage2"));
                ddlRank.Items[i].Value = "-1";
            }
            i++;
            ddlRank.Items.Add(datrRank["RankImage"].ToString());
            ddlRank.Items[i].Value = datrRank["RankImage"].ToString();
        }
        if (datrRank.IsClosed == false)
        {
            datrRank.Close();
            datrRank.Dispose();
        }
    }
    protected void lbtBlockUser_Click(object sender, EventArgs e)
    {
        ddlRank.Items.Clear();
        LoadDdlRank();
    }
    protected void ddlRank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRank.SelectedValue.ToString() != "-1")
        {
            imgRankImage.Src = "~/slmimages/" + ddlRank.SelectedValue.ToString();
            imgRankImage.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtGroupName.Value != "" && txtGetPosts.Text != "" && txtPmLimit.Text != "" && 
                ddlRank.SelectedValue.ToString() != "-1")
        {
            if (Request.Params["grpid"] != null)
            {
                int intGrpId = int.Parse(Request.Params["grpid"].ToString());
                EnGroup grp = new EnGroup();
                grp.GroupId = intGrpId;
                grp.GroupName = txtGroupName.Value.ToString();
                grp.GetPosts = int.Parse(txtGetPosts.Text.ToString());
                grp.RankImage = ddlRank.SelectedValue.ToString();
                grp.PmLimit = int.Parse(txtPmLimit.Text.ToString());
                BuGroup.UpdateGroups(grp);
                lblReport.Text = LoadSLMF("SLMF_GroupA", "UpdateGroupSuccess");
            }
            else
            {
                EnGroup grp = new EnGroup();
                grp.GroupName = txtGroupName.Value.ToString();
                grp.GetPosts = int.Parse(txtGetPosts.Text.ToString());
                grp.RankImage = ddlRank.SelectedValue.ToString();
                grp.PmLimit = int.Parse(txtPmLimit.Text.ToString());
                BuGroup.InsertGroup(grp);
                lblReport.Text = LoadSLMF("SLMF_GroupA", "CreateSuccess");
            }
        }
    }
}
