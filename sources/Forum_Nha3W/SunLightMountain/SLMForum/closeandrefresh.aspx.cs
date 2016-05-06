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

public partial class closeandrefresh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["report"] != null)
            {
                string strReport = Request.Params["report"].ToString();
                if (strReport == "updated")
                {
                    lblReport.Text = LoadSLMF("SLMF_Topic", "MoveUpdated");
                    href1.Visible = false;
                }
                else if (strReport == "forumid")
                {
                    lblReport.Text = LoadSLMF("SLMF_Topic", "MoveForum");
                    href2.Visible = false;
                }
                else
                {
                    lblReport.Text = LoadSLMF("SLMF_Topic", "MoveForum");
                    href2.Visible = false;
                }
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
}
