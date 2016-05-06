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

public partial class AdminCp_Controls_slm_searchme : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.Text = LoadSLMF("SLMF_GeneralA", "AddUserName");
            LoadSearchMe();
        }
    }

    private void LoadSearchMe()
    {
        DataTable dttUserName = BuConfiguration.SelectSearchUser();
        grvUserName.DataSource = dttUserName;
        grvUserName.DataBind();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void InsertMember()
    {
        string strUser = txtSearchMe.Text.ToString();
        if (strUser != "")
        {
            BuConfiguration.InsertUpdateSearchMe(strUser, 1);
            txtSearchMe.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertMember();
        LoadSearchMe();
    }
    protected void grvUserName_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strUser = grvUserName.DataKeys[e.RowIndex].Value.ToString();
        BuConfiguration.InsertUpdateSearchMe(strUser, 2);
        LoadSearchMe();
    }
    protected void grvUserName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUserName.SelectedIndex = -1;
        grvUserName.PageIndex = e.NewPageIndex;
        LoadSearchMe();
    }
}
