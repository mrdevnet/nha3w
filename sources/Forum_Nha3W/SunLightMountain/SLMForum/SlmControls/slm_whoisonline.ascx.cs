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
using System.Data.Common;
using SLMF.Utility;
using SLMF.Business;

public partial class SlmControls_slm_whoisonline : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOnline();
            Page.Title = LoadSLMF("SLMF_Online", "WhoisOnline") + ". " + LoadSLMF("TitleOfPage", "F9Light");
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public string Details()
    {
        string strN = BuInformation.SelectWOnline();
        return strN;
    }

    private void LoadOnline()
    {
        SqlDataReader r = BuInformation.SelectOnlineDatail();
        rptForum.DataSource = r;
        rptForum.DataBind();
        if (r.IsClosed == false)
        {
            r.Close();
            r.Dispose();
        }
    }


    protected void rptForum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //int i = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
            int i = int.Parse(((DbDataRecord)e.Item.DataItem)[0].ToString());
            string strForum = ((DbDataRecord)e.Item.DataItem)[5].ToString();
            string strTopic = ((DbDataRecord)e.Item.DataItem)[6].ToString();
            int intForum = 0;
            int intTopic = 0;
            Label lblActNew = new Label();
            lblActNew = (Label)e.Item.FindControl("lblAction");
            if (strForum == "" && strTopic == "")
            {
                lblActNew.Text = LoadSLMF("SLMF_Online", "Unknow");
            }
            else if (strForum != "" && strTopic == "")
            {
                intForum = int.Parse(((DbDataRecord)e.Item.DataItem)[3].ToString());
                HtmlAnchor hrfActNew = new HtmlAnchor();
                hrfActNew = (HtmlAnchor)e.Item.FindControl("hrfAction");
                hrfActNew.HRef = "../topicdisplay.aspx?forumid=" + intForum;
                hrfActNew.InnerHtml = strForum;
                lblActNew.Text = LoadSLMF("SLMF_Online", "ForumView");
            }
            else
            {
                intTopic = int.Parse(((DbDataRecord)e.Item.DataItem)[4].ToString());
                HtmlAnchor hrfActNew = new HtmlAnchor();
                hrfActNew = (HtmlAnchor)e.Item.FindControl("hrfAction");
                hrfActNew.HRef = "../showtopic.aspx?topicid=" + intTopic;
                hrfActNew.InnerHtml = strTopic;
                lblActNew.Text = LoadSLMF("SLMF_Online", "TopicView");
            }
        }
    }
}
