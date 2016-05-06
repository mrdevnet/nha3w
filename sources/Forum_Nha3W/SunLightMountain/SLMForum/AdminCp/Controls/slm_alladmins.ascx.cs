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

public partial class AdminCp_Controls_slm_alladmins : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AllAdmins();
        }
    }

    private void AllAdmins()
    {
        grvUsers.DataSource = BuMember.SelectAllAdmins();
        grvUsers.DataBind();
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
    protected void grvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intAdminId = int.Parse(grvUsers.DataKeys[e.RowIndex]["AdminId"].ToString());
        EnAdmin admin = new EnAdmin();
        admin.AdminId = intAdminId;
        BuAdminGroup.DeleteAdmins(admin);
        AllAdmins();
    }
}
