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

public partial class AdminCp_Controls_slm_cateman : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCateMan();
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "Submit");
        }
    }

    private void LoadCateMan()
    {
        grvCategory.DataSource = BuCategory.SelectCateMan();
        grvCategory.DataBind();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void grvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intCateId = int.Parse(grvCategory.DataKeys[e.RowIndex].Value.ToString());
        EnCategory cate = new EnCategory();
        cate.CategoryId = intCateId;
        BuCategory.DeleteCategory(cate);
        LoadCateMan();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" && txtOrderBy.Text != "")
        {
            InsertCategory();
        }
    }

    private void InsertCategory()
    {
        EnCategory cate = new EnCategory();
        cate.CateName = txtName.Text.ToString();
        cate.OrderBy = int.Parse(txtOrderBy.Text.ToString());
        BuCategory.InsertCategory(cate);
        LoadCateMan();
        ResetControls();
    }

    private void ResetControls()
    {
        txtName.Text = "";
        txtOrderBy.Text = "";
    }

}
