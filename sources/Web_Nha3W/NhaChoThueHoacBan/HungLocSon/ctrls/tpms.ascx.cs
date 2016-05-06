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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class ctrls_tpms : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtlPMS.DataSource = BPms.PMS_Inbox(BMember.ReturnId(lk()));
            dtlPMS.DataBind();
        }
    }

    protected void dtlPMS_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "btnasl":
                {
                    dtlPMS.DataSource = BPms.PMS_Inbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                } 
            case "btnarsl":
                {
                    dtlPMS.DataSource = BPms.PMS_InboxIs(BMember.ReturnId(lk()), true);
                    dtlPMS.DataBind();
                    break;
                }
            case "btndelpm":
                {
                    LinkButton btn = (LinkButton)e.CommandSource;
                    BPms.PMS_Delete(Convert.ToInt32(btn.CommandArgument));
                    dtlPMS.DataSource = BPms.PMS_Inbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                }
            case "btnunread":
                {
                    dtlPMS.DataSource = BPms.PMS_InboxIs(BMember.ReturnId(lk()), false);
                    dtlPMS.DataBind();
                    break;
                }
            case "btndelsms":
                {
                    BPms.PMS_DelInbox(BMember.ReturnId(lk()));
                    dtlPMS.DataSource = BPms.PMS_Inbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                }
            case "btntl":
                {
                    LinkButton btn = (LinkButton)e.CommandSource;
                    BPms.PMS_Read(Convert.ToInt32(btn.CommandArgument));
                    (e.Item.FindControl("ckbpm") as CheckBox).Checked = true;
                    break;
                }
            case "lblsms":
                {
                    LinkButton btn = (LinkButton)e.CommandSource;
                    BPms.PMS_Read(Convert.ToInt32(btn.CommandArgument));
                    break;
                }
            case "btnReply":
                {
                    if ((e.Item.FindControl("txtTitle") as TextBox).Text != "" || (e.Item.FindControl("txtMessage") as TextBox).Text != "")
                    {
                        LinkButton btn = (LinkButton)e.CommandSource;
                        EPms pm = new EPms();
                        pm.FromMember = BMember.ReturnId(lk());
                        pm.ToMemberId = Convert.ToInt32(e.CommandArgument);
                        pm.Title = rplc((e.Item.FindControl("txtTitle") as TextBox).Text);
                        pm.Message = rplc((e.Item.FindControl("txtMessage") as TextBox).Text);
                        BPms.PMS_InSert(pm);
                        dtlPMS.DataSource = BPms.PMS_Inbox(BMember.ReturnId(lk()));
                        dtlPMS.DataBind();
                    }
                    break;
                }
        }
    }

    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" && ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }
}
