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
using HungLocSon.BHLS;

public partial class ctrls_fpms : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtlPMS.DataSource = BPms.PMS_Outbox(BMember.ReturnId(lk()));
            dtlPMS.DataBind();
        }
    }

    protected void dtlPMS_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "btnasl":
                {
                    dtlPMS.DataSource = BPms.PMS_Outbox(BMember.ReturnId(lk()));
                    dtlPMS.DataBind();
                    break;
                }
            case "btnarsl":
                {
                    dtlPMS.DataSource = BPms.PMS_OutboxIs(BMember.ReturnId(lk()), true);
                    dtlPMS.DataBind();
                    break;
                }
            case "btnunread":
                {
                    dtlPMS.DataSource = BPms.PMS_OutboxIs(BMember.ReturnId(lk()), false);
                    dtlPMS.DataBind();
                    break;
                }
            //case "btndelpm":
            //    {
            //        LinkButton btn = (LinkButton)e.CommandSource;
            //        BPms.PMS_Delete(Convert.ToInt32(btn.CommandArgument));
            //        dtlPMS.DataSource = BPms.PMS_Outbox(BMember.ReturnId(lk()));
            //        dtlPMS.DataBind();

            //    }; break;
            //case "btndelsms":
            //    {
            //        BPms.PMS_DelOutbox(BMember.ReturnId(lk()));
            //        dtlPMS.DataSource = BPms.PMS_Outbox(BMember.ReturnId(lk()));
            //        dtlPMS.DataBind();

            //    }; break;
            //case "btntl":
            //    {
            //        LinkButton btn = (LinkButton)e.CommandSource;
            //        BPms.PMS_Read(Convert.ToInt32(btn.CommandArgument));
            //        (e.Item.FindControl("ckbpm") as CheckBox).Checked = true;
            //    }; break;
            //case "lblsms":
            //    {
            //        LinkButton btn = (LinkButton)e.CommandSource;
            //        BPms.PMS_Read(Convert.ToInt32(btn.CommandArgument));
            //    }; break;
        }
    }
    //lay cookie
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
