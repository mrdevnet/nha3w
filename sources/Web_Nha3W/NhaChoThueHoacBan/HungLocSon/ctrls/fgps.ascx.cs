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
using HungLocSon.EHLS;
using HungLocSon.UHLS;

public partial class ctrls_fgps : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clrs();
        }
    }
    private void clrs()
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null)
        {
            int i = int.Parse(Request.Params["m"].ToString());
            EProfile p = new EProfile();
            EMember m = new EMember();
            m.MemberId = i;
            p = BMember.PMemberI(m);
            string namef = BMember.PMemberU(m);
            ifname.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + i + "\" class=\"wls3hr\">";
            if (p.Logo != null && p.Logo.ToString() != "") ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/" + p.Logo + "\"/></a>";
            else ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/prof3w.png\"/></a>";
            ifname.InnerHtml += " <span class=\"ifwnimg2\"> Nhóm của " + namef + "</span>";
            lstgrps.DataSource = BTracks.LstTracks(lk());
            lstgrps.DataBind();
            ETracks t = new ETracks();
            t.MemberId = i;

            tb1.HRef = "../profile.aspx?v=grps&m=" + i + "&tb=1";
            tb2.HRef = "../profile.aspx?v=grps&m=" + i + "&tb=2";
            System.Collections.Generic.List<ETracks> a = new System.Collections.Generic.List<ETracks>();
            a = BFlowing.LstTr4u4(t);
            System.Collections.Generic.List<ETracks> b = new System.Collections.Generic.List<ETracks>();
            t.IName = lk();
            b = BFlowing.LstTr4u3(t);
            if ((Request.Params["tb"] != null && Request.Params["tb"].ToString() == "1") || (Request.Params["tb"] == null))
            {
                flwings.DataSource = a;
                flwings.DataBind();
                tb2.Attributes.Add("onmouseout", "chbgb3('ctl00_cphc_Fgps1_tab2');");
                tb2.Attributes.Add("onmouseover", "chbgb3ov('ctl00_cphc_Fgps1_tab2');");
                tab1.Attributes.Add("class", "wlstb1");
                tab2.Attributes.Add("class", "wlstb2");
            }
            else
            {
                flwings.DataSource = b;
                flwings.DataBind();
                tb1.Attributes.Add("onmouseout", "chbgb3('ctl00_cphc_Fgps1_tab1');");
                tb1.Attributes.Add("onmouseover", "chbgb3ov('ctl00_cphc_Fgps1_tab1');");
                tab1.Attributes.Add("class", "wlstb2");
                tab2.Attributes.Add("class", "wlstb1");
            }
            tab1.InnerHtml = "Nhóm đang theo " + namef + " (" + a.Count + ")";
            tab2.InnerHtml = "Nhóm " + namef + " đang theo (" + b.Count + ")";
        }
    }

    protected void lstgrps_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = lstgrps.SelectedRow;
        int i = int.Parse(lstgrps.DataKeys[row.RowIndex].Value.ToString());
        ETracks t = BTracks.LstTracks1(i);
        name.Value = t.LstName;
        desc.Value = t.LstDesc;
        if (t.Prive)
        {
            pb.Checked = true;
            pr.Checked = false;
        }
        else
        {
            pr.Checked = true;
            pb.Checked = false;
        }
        submit.Value = "Thay đổi";
        grpv.Attributes.Add("class", "wls8cal");
    }

    protected void submit_ServerClick(object sender, EventArgs e)
    {
        ETracks t = new ETracks();
        t.LstName = HungLocSon.Tools.Support.ReleaseInput(name.Value, 100);
        t.LstDesc = HungLocSon.Tools.Support.ReleaseInput(desc.Value, 200);
        if (pr.Checked) t.Prive = false;
        else if (pb.Checked) t.Prive = true;
        GridViewRow r = lstgrps.SelectedRow;
        if (r != null)
        {
            t.ListId = int.Parse(lstgrps.DataKeys[r.RowIndex].Value.ToString());
            BTracks.UCalls(t);
        }
        else
        {
            t.IName = lk();
            BTracks.ICalls(t);
        }
        lstgrps.DataSource = BTracks.LstTracks(lk());
        lstgrps.DataBind();
        name.Value = "";
        desc.Value = "";
        pb.Checked = true;
        pr.Checked = false;
        grpv.Attributes.Add("class", "wls8cal");
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
    protected void lstgrps_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delgs")
        {
            BTracks.DCalls(int.Parse(((ImageButton)e.CommandSource).CommandArgument));
            lstgrps.DataSource = BTracks.LstTracks(lk());
            lstgrps.DataBind();
            lstgrps.SelectedIndex = -1;
            submit.Value = "Tạo nhóm";
            grpv.Attributes.Add("class", "wls8cal");
        }
    }

    protected void flwings_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null)
            {
                int i = int.Parse(Request.Params["m"].ToString());
                HtmlGenericControl del1 = new HtmlGenericControl();
                del1 = (HtmlGenericControl)e.Item.FindControl("cntflw");
                int cid = (int)(((ETracks)e.Item.DataItem).MemberId);
                string us = (string)(((ETracks)e.Item.DataItem).IName);
                int id = (int)(((ETracks)e.Item.DataItem).ListId);
                string na = (string)(((ETracks)e.Item.DataItem).LstName);
                string ids = (string)(((ETracks)e.Item.DataItem).LstDesc);
                int flw = (int)(((ETracks)e.Item.DataItem).Flwc);
                int flr = (int)(((ETracks)e.Item.DataItem).Flrc);
                string log = (string)(((ETracks)e.Item.DataItem).Logo);
                if (i != cid) del1.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + cid + "&g=" + id + "\" class=\"wls3hra\">" + "@" + us + "/<b>" + na + "</b></a>";
                else del1.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + cid + "&g=" + id + "\" class=\"wls3hra\">" + na + "</a>";
                del1.InnerHtml += "<br/>" + ids;
                HtmlGenericControl del2 = new HtmlGenericControl();
                del2 = (HtmlGenericControl)e.Item.FindControl("cntflw2");
                del2.InnerHtml = "Đang theo: " + flw;
                del2.InnerHtml += "<br/>Người theo: " + flr;

                HtmlGenericControl ic2 = new HtmlGenericControl();
                ic2 = (HtmlGenericControl)e.Item.FindControl("icolor");
                ic2.Attributes.Add("onmouseover", "chbg('" + ic2.ClientID + "');");
                ic2.Attributes.Add("onmouseout", "chbg2('" + ic2.ClientID + "');");
            }
        }
    }
}
