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

public partial class SlmControls_slm_resetpass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnLogIn.Attributes.Add("onclick", "GetSlmEnc();");
            pnlError.Visible = false;
            btnLogIn.Text = LoadSLMF("SLMF_ResetPass", "Submit");
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        if (Request.Params["MemberId"] != null && Request.Params["Actlink"] != null
                && Request.Params["Pass"] != null)
        {
            EnMember mbr = new EnMember();
            mbr.MemberId = int.Parse(Request.Params["MemberId"].ToString());
            mbr.ActivateString  = Request.Params["Actlink"].ToString();
            mbr.Salt = Request.Params["Pass"].ToString();
            UtiHashMd5 md5 = new UtiHashMd5();
            mbr.Password = md5.Md5Encode(slmhas.Value.ToString() + mbr.Salt);
            int intResult = BuMember.SelectResetPass(ref mbr);
            if (intResult == 1)
            {
                //btnLogIn.Enabled = false;
                //string strFinish = string.Format(LoadSLMF("SLMF_ResetPass", "ResetFinish"), mbr.UserName);
                Response.Redirect("javascript: GetLocation();");
            }
            else
            {
                lblError.Text = LoadSLMF("SLMF_ResetPass", "NotRight");
            }
        }
    }
}
