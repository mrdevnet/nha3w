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

public partial class ctrls_flowings : System.Web.UI.UserControl
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
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && 
                (Request.Params["v"].ToString() == "frs" || Request.Params["v"].ToString() == "flws"))
        {
            int i = int.Parse(Request.Params["m"].ToString());
            EProfile p = new EProfile();
            EMember m = new EMember();
            m.MemberId = i;
            p = BMember.PMemberI(m);
            ifname.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + i + "\" class=\"wls3hr\">";
            if (p.Logo != null && p.Logo.ToString() != "") ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/" + p.Logo + "\"/></a>";
            else ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/prof3w.png\"/></a>";
            if (Request.Params["v"].ToString() == "frs")
            {
                flwings.DataSource = BFlowing.LstFlwings(i);
                flwings.DataBind();
                ifname.InnerHtml += " <span class=\"ifwnimg2\">" + BMember.PMemberU(m) + " đang theo " + flwings.Items.Count + " người</span>";
            }
            else if (Request.Params["v"].ToString() == "flws")
            {
                flwings.DataSource = BFlowing.LstFlwings3(i);
                flwings.DataBind();
                ifname.InnerHtml += " <span class=\"ifwnimg2\">" + flwings.Items.Count + " người đang theo " + BMember.PMemberU(m) + "</span>";
            }
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
                int cid = (int)(((EFlowing)e.Item.DataItem).ToMember);
                string us = (string)(((EFlowing)e.Item.DataItem).UserName);
                string ful = (string)(((EFlowing)e.Item.DataItem).FullName);
                string ad = (string)(((EFlowing)e.Item.DataItem).Address);
                string clr = (string)(((EFlowing)e.Item.DataItem).Color);
                bool pri = (bool)(((EFlowing)e.Item.DataItem).Prive);
                DateTime fd = (DateTime)(((EFlowing)e.Item.DataItem).Fdate);
                if (!pri) del1.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + cid + "\" class=\"wls3hr\">" + us + "</a>" + "&nbsp;<img class=\"wlsimg\" src=\"images/serc3.png\"/>";
                else del1.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + cid + "\" class=\"wls3hr\">" + us + "</a>";
                if (ad != null && ad != "") del1.InnerHtml += "<br/>" + ful + " | " + ad + "<br/>";
                else del1.InnerHtml += "<br/>" + ful + "<br/>";
                del1.InnerHtml += clr + "<br/>";
                del1.InnerHtml += ltsDate(fd);

                System.Collections.Generic.List<ETracks> t4 = new System.Collections.Generic.List<ETracks>();
                ETracks t4u = new ETracks();
                t4u.MemberId = cid;
                t4u.IName = lk();
                t4 = BFlowing.LstTr4u(t4u);
                if (t4.Count > 0)
                {
                    del1.InnerHtml += "<br/><img src=\"images/grpo.png\" /> Nhóm của bạn: ";
                    for (int k1 = 0; k1 < t4.Count; k1++)
                    {
                        del1.InnerHtml += "<a href=\"profile.aspx?v=wall&m=" + BMember.ReturnId(lk()) + "&g=" + t4[k1].ListId + "\" class=\"wls4re\">" + t4[k1].LstName + "</a>";
                        if (k1 < t4.Count - 1) del1.InnerHtml += ", ";
                    }
                }

                System.Collections.Generic.List<ETracks> t41 = new System.Collections.Generic.List<ETracks>();
                t41 = BTracks.LstTracks(lk());
                HtmlGenericControl grpsn = new HtmlGenericControl();
                grpsn = (HtmlGenericControl)e.Item.FindControl("grps");
                if (t41.Count > 0)
                {
                    CheckBoxList cklg = new CheckBoxList();
                    cklg = (CheckBoxList)e.Item.FindControl("cblgrps");

                    int p4 = 0;
                    int p5 = 0;
                    for (p4 = 0; p4 < t41.Count; p4++)
                    {
                        ListItem li1 = new ListItem();
                        li1.Value = t41[p4].ListId.ToString();
                        li1.Text = t41[p4].LstName;
                        li1.Selected = false;
                        for (p5 = 0; p5 < t4.Count; p5++)
                        {
                            if (t4[p5].ListId == t41[p4].ListId) li1.Selected = true;
                        }
                        cklg.Items.Add(li1);
                    }

                    HtmlGenericControl vip2 = new HtmlGenericControl();
                    vip2 = (HtmlGenericControl)e.Item.FindControl("icolor2");
                    grpsn.Attributes.Add("onclick", "chbg4('" + vip2.ClientID + "');");
                }
                else grpsn.Visible = false;

                HtmlGenericControl ic2 = new HtmlGenericControl();
                ic2 = (HtmlGenericControl)e.Item.FindControl("icolor");
                ic2.Attributes.Add("onmouseover","chbg('" + ic2.ClientID + "');");
                ic2.Attributes.Add("onmouseout", "chbg2('" + ic2.ClientID + "');");

                EFlowing f = new EFlowing();
                int jk = BMember.ReturnId(lk());
                f.UserName = lk();
                f.ToMember = cid;
                f = BFlowing.SFlowing(f);

                HtmlGenericControl fl = new HtmlGenericControl();
                fl = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl fl2 = new HtmlGenericControl();
                fl2 = (HtmlGenericControl)e.Item.FindControl("unflw");
                HtmlGenericControl fl4 = new HtmlGenericControl();
                fl4 = (HtmlGenericControl)e.Item.FindControl("block");
                HtmlGenericControl fl5 = new HtmlGenericControl();
                fl5 = (HtmlGenericControl)e.Item.FindControl("spam");

                HtmlGenericControl fl3 = new HtmlGenericControl();
                fl3 = (HtmlGenericControl)e.Item.FindControl("dscmd");
                if (i != jk)
                {
                    fl3.InnerHtml = "<img class=\"wlsimg\" src=\"images/tick.png\"/>";
                    fl3.InnerHtml += "&nbsp;&nbsp;Đang theo";
                }
                else fl3.Visible = false;
                if (jk == cid)
                {
                    fl.Visible = false;
                    fl2.Visible = false;
                    fl4.Visible = false;
                    fl5.Visible = false;
                    grpsn.Visible = false;
                    fl3.InnerHtml = "<img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;&nbsp;Chính là bạn";
                    return;
                }

                ImageButton icrflwn = new ImageButton();
                icrflwn = (ImageButton)e.Item.FindControl("icrflw");
                icrflwn.Attributes.Add("onclick","return confirm('Bạn muốn theo đuôi thành viên " + us + " ?');");
                ImageButton icruflwn = new ImageButton();
                icruflwn = (ImageButton)e.Item.FindControl("icruflw");
                icruflwn.Attributes.Add("onclick", "return confirm('Bạn không muốn tiếp tục theo đuôi " + us + " ?');");
                ImageButton icrblkn = new ImageButton();
                icrblkn = (ImageButton)e.Item.FindControl("icrblk");
                icrblkn.Attributes.Add("onclick", "return confirm('Bạn muốn khoá kết nối đối với " + us + " ?');");
                ImageButton icrblk2n = new ImageButton();
                icrblk2n = (ImageButton)e.Item.FindControl("icrblk2");
                icrblk2n.Attributes.Add("onclick", "return confirm('Bỏ khoá đối với thành viên " + us + " ?');");
                ImageButton icrspmn = new ImageButton();
                icrspmn = (ImageButton)e.Item.FindControl("icrspm");
                icrspmn.Attributes.Add("onclick", "return confirm('Khoá và báo vi phạm spam đối với " + us + " ?');");

                if (f.BlockEd)
                {
                    fl.Visible = false;
                    fl2.Visible = false;
                    fl4.Visible = false;
                    fl5.Visible = false;
                    grpsn.Visible = false;
                    fl3.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                    fl3.InnerHtml += "&nbsp;&nbsp;Bạn đã bị khoá kết nối bởi thành viên này";
                    fl3.Visible = true;
                    return;
                }
                if (f.MemberId == -1)
                {
                    fl2.Visible = false;
                    fl3.Visible = false;
                }
                else if (!f.Flws && !f.Approves && !f.Blocks && !f.Removes)
                {
                    fl2.Visible = false;
                    fl3.Visible = false;
                }
                else if (!f.Flws && f.Approves && !f.Blocks && !f.Removes)
                {
                    fl2.Visible = false;
                    fl3.Visible = false;
                }
                else if (f.Removes && !f.Blocks)
                {
                    fl2.Visible = false;
                }
                else if (f.Flws && !f.Approves && !f.Blocks && !f.Removes)
                {
                    fl3.InnerHtml = "<img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;&nbsp;Chờ duyệt";
                    fl3.Visible = true;
                    fl.Visible = false;
                }
                else if (f.Blocks)
                {
                    fl.Visible = false;
                    fl2.Visible = false;
                    fl4.Visible = false;
                    fl5.Visible = false;
                    grpsn.Visible = false;
                    fl3.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                    fl3.InnerHtml += "&nbsp;&nbsp;Bạn đã khoá kết nối với thành viên này";
                    fl3.Visible = true;
                    return;
                }
                else if (f.Flws && f.Approves && !f.Blocks && !f.Removes)
                {
                    fl.Visible = false;
                }
            }
        }
    }

    protected void flwings_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null)
        {
            if (e.CommandName == "cmdflw")
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                f.Flws = true;
                f.Approves = false;
                f.Blocks = false;
                f.Spams = false;
                f.Removes = false;
                f.Type = 1;
                int i = BFlowing.IFlowing(f);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("dscmd");
                HtmlGenericControl flwi2 = new HtmlGenericControl();
                flwi2 = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl unflw2 = new HtmlGenericControl();
                unflw2 = (HtmlGenericControl)e.Item.FindControl("unflw");
                HtmlGenericControl block2 = new HtmlGenericControl();
                block2 = (HtmlGenericControl)e.Item.FindControl("block");
                HtmlGenericControl spam2 = new HtmlGenericControl();
                spam2 = (HtmlGenericControl)e.Item.FindControl("spam");
                HtmlGenericControl block2n = new HtmlGenericControl();
                block2n = (HtmlGenericControl)e.Item.FindControl("block2");
                if (i == 1)
                {
                    inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/tick.png\"/>";
                    inc.InnerHtml += "&nbsp;&nbsp;Đang theo";
                    inc.Visible = true;
                    flwi2.Visible = false;
                    unflw2.Visible = true;
                }
                else if (i==-4)
                {
                    inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                    inc.InnerHtml += "&nbsp;&nbsp;Bạn đã bị khoá kết nối bởi thành viên này";
                    HtmlGenericControl grpsn = new HtmlGenericControl();
                    grpsn = (HtmlGenericControl)e.Item.FindControl("grps");
                    grpsn.Visible = false;
                    inc.Visible = true;
                    flwi2.Visible = false;
                    unflw2.Visible = false;
                    block2.Visible = false;
                    spam2.Visible = false;
                    block2n.Visible = false;
                }
                else
                {
                    inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/aprv2.png\"/>";
                    inc.InnerHtml += "&nbsp;&nbsp;Chờ duyệt";
                    inc.Visible = true;
                    flwi2.Visible = false;
                    unflw2.Visible = true;
                }
            }
            else if (e.CommandName == "cmduflw")
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                f.Flws = false;
                f.Approves = false;
                f.Blocks = false;
                f.Spams = false;
                f.Removes = false;
                f.Type = 1;
                int i = BFlowing.IFlowing(f);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("dscmd");
                HtmlGenericControl flwi2 = new HtmlGenericControl();
                flwi2 = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl unflw2 = new HtmlGenericControl();
                unflw2 = (HtmlGenericControl)e.Item.FindControl("unflw");

                inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/tick2.png\"/>";
                inc.InnerHtml += "&nbsp;&nbsp;Không theo";
                inc.Visible = true;
                flwi2.Visible = true;
                unflw2.Visible = false;
            }
            else if (e.CommandName == "cmdblk")
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                f.Flws = false;
                f.Approves = false;
                f.Blocks = true;
                f.Spams = false;
                f.Removes = false;
                f.Type = 3;
                int i = BFlowing.IFlowing(f);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("dscmd");
                HtmlGenericControl flwi2 = new HtmlGenericControl();
                flwi2 = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl unflw2 = new HtmlGenericControl();
                unflw2 = (HtmlGenericControl)e.Item.FindControl("unflw");
                HtmlGenericControl block2 = new HtmlGenericControl();
                block2 = (HtmlGenericControl)e.Item.FindControl("block");
                HtmlGenericControl spam2 = new HtmlGenericControl();
                spam2 = (HtmlGenericControl)e.Item.FindControl("spam");
                HtmlGenericControl block2n = new HtmlGenericControl();
                block2n = (HtmlGenericControl)e.Item.FindControl("block2");

                inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                inc.InnerHtml += "&nbsp;&nbsp;Đã khoá";
                inc.Visible = true;
                flwi2.Visible = false;
                unflw2.Visible = false;
                block2.Visible = false;
                spam2.Visible = false;
                block2n.Visible = true;
            }
            else if (e.CommandName == "cmdblk2")
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                f.Flws = false;
                f.Approves = false;
                f.Blocks = false;
                f.Spams = false;
                f.Removes = false;
                f.Type = 3;
                int i = BFlowing.IFlowing(f);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("dscmd");
                HtmlGenericControl flwi2 = new HtmlGenericControl();
                flwi2 = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl unflw2 = new HtmlGenericControl();
                unflw2 = (HtmlGenericControl)e.Item.FindControl("unflw");
                HtmlGenericControl block2 = new HtmlGenericControl();
                block2 = (HtmlGenericControl)e.Item.FindControl("block");
                HtmlGenericControl spam2 = new HtmlGenericControl();
                spam2 = (HtmlGenericControl)e.Item.FindControl("spam");
                HtmlGenericControl block2n = new HtmlGenericControl();
                block2n = (HtmlGenericControl)e.Item.FindControl("block2");

                //inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                //inc.InnerHtml += "&nbsp;&nbsp;Đã khoá";
                inc.Visible = false;
                flwi2.Visible = true;
                unflw2.Visible = false;
                block2.Visible = true;
                spam2.Visible = true;
                block2n.Visible = false;
            }
            else if (e.CommandName == "cmdspam")
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                f.Flws = false;
                f.Approves = false;
                f.Blocks = true;
                f.Spams = true;
                f.Removes = false;
                f.Type = 4;
                int i = BFlowing.IFlowing(f);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("dscmd");
                HtmlGenericControl flwi2 = new HtmlGenericControl();
                flwi2 = (HtmlGenericControl)e.Item.FindControl("flwi");
                HtmlGenericControl unflw2 = new HtmlGenericControl();
                unflw2 = (HtmlGenericControl)e.Item.FindControl("unflw");
                HtmlGenericControl block2 = new HtmlGenericControl();
                block2 = (HtmlGenericControl)e.Item.FindControl("block");
                HtmlGenericControl spam2 = new HtmlGenericControl();
                spam2 = (HtmlGenericControl)e.Item.FindControl("spam");
                HtmlGenericControl block2n = new HtmlGenericControl();
                block2n = (HtmlGenericControl)e.Item.FindControl("block2");

                inc.InnerHtml = "<img class=\"wlsimg\" src=\"images/blk2.png\"/>";
                inc.InnerHtml += "&nbsp;&nbsp;Đã khoá & báo spam";
                inc.Visible = true;
                flwi2.Visible = false;
                unflw2.Visible = false;
                block2.Visible = false;
                spam2.Visible = false;
                block2n.Visible = true;
            }
            else if (e.CommandName == "cmdgrp")
            {
                CheckBoxList c = new CheckBoxList();
                c = (CheckBoxList)e.Item.FindControl("cblgrps");
                int jk = int.Parse(((Button)e.CommandSource).CommandArgument);
                ETracks ts = new ETracks();
                ts.MemberId = jk;
                foreach (ListItem li in c.Items)
                {
                    ts.ListId = int.Parse(li.Value);
                    if (li.Selected)
                    {
                        ts.CheckIn = true;
                        ts.CheckOut = false;
                    }
                    else
                    {
                        ts.CheckIn = false;
                        ts.CheckOut = true;
                    }
                    BFlowing.ITr4u(ts);
                }
                clrs();
            }
        }
    }

    private string ltsDate(DateTime a)
    {
        TimeSpan ts = DateTime.Now - a;
        if (ts.Days == 0 && ts.Hours > 0) return "khoảng " + ts.Hours + " tiếng trước";
        else if (ts.Days == 0 && ts.Minutes > 0 && ts.Hours == 0) return "khoảng " + ts.Minutes + " phút trước";
        else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds > 0) return "cách đây khoảng " + ts.Seconds + " giây";
        else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds == 0) return "mới tức thì đây";
        else if (ts.Days > 0 && ts.Days <= 3) return "cách đây " + ts.Days + " ngày";
        else return a.ToLongTimeString() + " " + a.Day.ToString() + "/" + a.Month.ToString() + "/" + a.Year.ToString();
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
    protected void cblgrps_SelectedIndexChanged(object sender, EventArgs e)
    {
        //RepeaterItem it = new RepeaterItem();
        CheckBoxList c = new CheckBoxList();
        foreach (RepeaterItem it in flwings.Items)
        {
            c = (CheckBoxList)it.FindControl("cblgrps");
            foreach (ListItem li in c.Items)
            {
                if (li.Selected)
                {
                    string i = li.Value;
                }
            }
        }
        //RepeaterItem it = flwings.Items[0].FindControl("
    }
}
