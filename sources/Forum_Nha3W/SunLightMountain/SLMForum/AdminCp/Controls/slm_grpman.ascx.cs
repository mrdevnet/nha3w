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

public partial class AdminCp_Controls_slm_grpman : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrvGroup();
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void LoadGrvGroup()
    {
        grvGroup.DataSource = BuGroup.SelectAllGroups2();
        grvGroup.DataBind();
    }
    protected void grvGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intGroupId = int.Parse(grvGroup.DataKeys[e.RowIndex].Value.ToString());
        EnGroup grp = new EnGroup();
        grp.GroupId = intGroupId;
        int intResult = BuGroup.DeleteGroup(grp);
        if (intResult == 1)
        {
            lblReport.Text = LoadSLMF("SLMF_GroupA", "NotDeleted");
            lblReport.Visible = true;
        }
        else
        {
            lblReport.Visible = false;
            LoadGrvGroup();
        }
    }
}
