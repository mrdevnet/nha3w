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

public partial class AdminCp_Controls_slm_allmoderators : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrpFrmUsers();
        }
    }
    protected void grvModerators_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intGrpId = int.Parse(grvModerators.DataKeys[e.RowIndex]["GroupId"].ToString());
        int intFrmId2 = int.Parse(grvModerators.DataKeys[e.RowIndex]["ForumId"].ToString());
        int intMbrId = int.Parse(grvModerators.DataKeys[e.RowIndex]["MemberId"].ToString());
        EnModerator moder = new EnModerator();
        moder.GroupId = intGrpId;
        moder.ForumId = intFrmId2;
        moder.MemberId = intMbrId;
        BuModerator.DeleteModerator(moder);
        LoadGrpFrmUsers();
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void LoadGrpFrmUsers()
    {
        grvModerators.DataSource = BuModerator.SelectAllModers();
        grvModerators.DataBind();
    }
}
