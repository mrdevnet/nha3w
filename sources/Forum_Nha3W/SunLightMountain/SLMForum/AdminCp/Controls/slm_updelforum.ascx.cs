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

public partial class AdminCp_Controls_slm_updelforum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
            int intCateId = -1;
            intCateId = int.Parse(ddlCategories.SelectedValue.ToString());
            LoadGrvForums(intCateId);
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGrvForums(int intCateId)
    {
        EnForum frm = new EnForum();
        frm.CateId = intCateId;
        grvForums.DataSource = BuForum.SelectAllForums(frm);
        grvForums.DataBind();
    }

    private void LoadCategories()
    {
        int i = 0;
        SqlDataReader rpt = BuCategory.SelectAllCategories();
        while (rpt.Read())
        {
            if (i == 0)
            {
                ddlCategories.Items.Add(LoadSLMF("SLMF_ForumA", "SelectAllCateId"));
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

    protected void grvForums_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvForums.SelectedIndex = -1;
        grvForums.PageIndex = e.NewPageIndex;
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
    }
    protected void grvForums_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intForumId = int.Parse(grvForums.DataKeys[e.RowIndex].Value.ToString());
        EnForum frm = new EnForum();
        frm.ForumId = intForumId;
        BuForum.DeleteForum(frm);
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
    }
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrvForums(int.Parse(ddlCategories.SelectedValue.ToString()));
    }
}
