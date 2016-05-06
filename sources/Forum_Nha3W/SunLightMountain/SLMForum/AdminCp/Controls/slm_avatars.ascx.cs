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

public partial class AdminCp_Controls_slm_avatars : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
            LoadGrvAvatars();
            btnSave.Text = LoadSLMF("SLMF_AvatarA", "btnCreateNewGrp");
            btnDelete.Text = LoadSLMF("SLMF_AvatarA", "DeleteCate");
            btnReload.Text = LoadSLMF("SLMF_AvatarA", "ReloadGrv");
        }
        hrfUpload.Attributes.Add("onclick", "javascript:window.open('uploadfile.aspx?typeid=2&grpid=" + ddlCategories.SelectedValue.ToString() + "','calwin','top=228,left=421,width=520,height=216,scrollbars=1')");
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGrvAvatars()
    {
        grvAvatars.DataSource = BuAvatar.SelectAllAvar(int.Parse(ddlCategories.SelectedValue.ToString()));
        grvAvatars.DataBind();
    }

    private void LoadCategories()
    {
        int i = 0;
        SqlDataReader rpt = BuAvatar.SelectDataList();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlCategories.Items.Add(LoadSLMF("SLMF_AvatarA", "DdlCategories"));
                ddlCategories.Items[i].Value = "-1";
                i++;
            }
            ddlCategories.Items.Add(rpt["Descriptions"].ToString());
            ddlCategories.Items[i].Value = rpt["CategoryId"].ToString();
            i++;
        }
        if (rpt.IsClosed == false)
        {
            rpt.Close();
            rpt.Dispose();
        }
    }
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrvAvatars();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.ToString() != "")
        {
            BuAvatar.InsertCategory(txtTitle.Text.ToString().Trim());
            ddlCategories.Items.Clear();
            txtTitle.Text = "";
            LoadCategories();
        }
    }
    protected void grvAvatars_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intAvarId = int.Parse(grvAvatars.DataKeys[e.RowIndex].Value.ToString());
        EnAvatar av = new EnAvatar();
        av.AvatarId = intAvarId;
        BuAvatar.DeleteAvatar(av);
        LoadGrvAvatars();
    }
    protected void grvAvatars_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAvatars.SelectedIndex = -1;
        grvAvatars.PageIndex = e.NewPageIndex;
        LoadGrvAvatars();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ddlCategories.SelectedValue.ToString() != "-1")
        {
            BuAvatar.DeleteAvarGrp(int.Parse(ddlCategories.SelectedValue.ToString()));
            ddlCategories.Items.Clear();
            LoadCategories();
            LoadGrvAvatars();
        }
    }
    protected void btnReload_Click(object sender, EventArgs e)
    {
        LoadGrvAvatars();
    }
}
