using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using HungLocSon.UHLS;

public partial class ctrls_nwall : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sta();
            clrs();
        }
        signu.Attributes.Add("onclick", "return find2();");
    }

    private void sta()
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            if (lk() != "")
            {
                EPFiles fi = new EPFiles();
                int i = int.Parse(Request.Params["m"].ToString());
                if (Request.Params["g"] != null && Request.Params["g"].ToString() != "")
                {
                    EProfile p = new EProfile();
                    EMember m = new EMember();
                    m.MemberId = i;
                    p = BMember.PMemberI(m);
                    string namef = BMember.PMemberU(m);
                    ifname.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + i + "\" class=\"wls3hr\" title=\"Nhóm này được tạo bởi " + namef + "\">";
                    if (p.Logo != null && p.Logo.ToString() != "") ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/" + p.Logo + "\"/></a>";
                    else ifname.InnerHtml += "<img class=\"ifwnimg\" src=\"avas/thumbs/prof3w.png\"/></a>";
                    ETracks tr = new ETracks();
                    tr.ListId = int.Parse(Request.Params["g"].ToString());
                    tr.IName = lk();
                    BTracks.GrpDtls(ref tr);
                    ifname.InnerHtml += " <span class=\"ifwnimg2\">" + tr.LstName;
                    if (tr.LstDesc != "") ifname.InnerHtml += "<span class=\"spdscgr\">(" + tr.LstDesc + ")";
                    else ifname.InnerHtml += "<span class=\"spdscgr\">";
                    if (tr.MemberId != BMember.ReturnId(lk()))
                    {
                        if (tr.IsList > 0)
                        {
                            ifname.InnerHtml += "&nbsp;&nbsp;<img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo</span></span>";
                            iflwt.Text = "Không theo";
                            iflwt.Attributes.Add("onclick", "javascript:return confirm('Bạn không muốn tiếp tục theo đuôi nhóm này?');");
                        }
                        else
                        {
                            iflwt.Attributes.Add("onclick", "javascript:return confirm('Bạn muốn theo đuôi nhóm này?');");
                            ifname.InnerHtml += "</span></span>";
                        }
                        tgo.Visible = false;
                    }
                    else
                    {
                        tgo.Visible = false;
                        tgo2.Visible = false;
                    }
                }
                else
                {
                    ifname.Visible = false;
                    tgo2.Visible = false;
                }
                fi.MemberId = i;
                fi = BFlowing.PFiles(fi);
                if (fi.Talk == null || fi.Talk == "") return;
                staid.InnerHtml = "<a class=\"nwaut\" href=\"profile.aspx?v=wall&m=" + fi.AutId + "\">" + fi.AutName + "</a> ";
                staid.InnerHtml += HungLocSon.Tools.Support.ReleaseInput(fi.Talk.Replace("<br/>", ""), 166);
                GUHLS a = new GUHLS();
                staid.InnerHtml += " <span class=\"nwsta2\">" + a.TimeServer(fi.TalkDate).ToLower() + " qua ";
                staid.InnerHtml += fi.Via.ToLower() + "</span>";
            }
            else Response.Redirect("default.aspx?m=" + int.Parse(Request.Params["m"].ToString()));
        }
    }

    private void clrs()
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "wall" && Request.Params["g"] == null)
        {
            EColors cl = new EColors();
            cl.MemberId = int.Parse(Request.Params["m"].ToString());
            cl.AutName = lk();
            rptClrs.DataSource = MooreFds(BColors.Colors(cl));
            rptClrs.DataBind();
        }
        else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "wall" && Request.Params["g"] != null && Request.Params["g"].ToString() != "")
        {
            ETracks cl = new ETracks();
            cl.ListId = int.Parse(Request.Params["g"].ToString());
            cl.IName = lk();
            rptClrs.DataSource = MooreFds(BColors.LstColors4(cl));
            rptClrs.DataBind();
        }
        else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "favs")
        {
            EMember cl = new EMember();
            cl.MemberId = int.Parse(Request.Params["m"].ToString());
            rptClrs.DataSource = MooreFds(BColors.LstClrFavsA(cl));
            rptClrs.DataBind();
        }
    }

    private List<EColors> MooreFds(List<EColors> tmp)
    {
        List<EColors> tmpn = new List<EColors>();
        int av = int.Parse(cntfm.Value.ToString())*20;
        if (tmp.Count > av) pgdv.Visible = true;
        else pgdv.Visible = false;
        for (int i = 0; i < av; i++)
        {
            if (i >= tmp.Count) break;
            tmpn.Add(tmp[i]);
        }
        return tmpn;
    }

    protected void rpticmnts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null 
                && (Request.Params["v"].ToString() == "wall" || Request.Params["v"].ToString() == "favs"))
            {
                HtmlGenericControl del1 = new HtmlGenericControl();
                del1 = (HtmlGenericControl)e.Item.FindControl("icmnts");
                int cid = (int)(((EColors)e.Item.DataItem).ColorId);
                int mi = int.Parse(Request.Params["m"].ToString());
                int cmd = (int)(((EColors)e.Item.DataItem).CommentId);
                int aj = (int)(((EColors)e.Item.DataItem).Author);
                int mj = (int)(((EColors)e.Item.DataItem).MemberId);
                int aj2 = (int)(((EColors)e.Item.DataItem).Author2);
                int i = BMember.ReturnId(lk());
                ImageButton dp = new ImageButton();
                dp = (ImageButton)e.Item.FindControl("icrdpc2");
                if (i == aj || i == mj || i == aj2)
                {
                    HtmlGenericControl del = new HtmlGenericControl();
                    del = (HtmlGenericControl)e.Item.FindControl("iclrr3");
                    del1.Attributes.Add("onmouseover", "ovclr2('" + del.ClientID + "');");
                    del1.Attributes.Add("onmouseout", "osclr2('" + del.ClientID + "');");
                    dp.Attributes.Add("onclick", "return confirm('Bạn muốn xoá bình luận này phải không?');");
                }
                else dp.Visible = false;
            }
        }
    }
    protected void rptClrs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null
                && (Request.Params["v"].ToString() == "wall" || Request.Params["v"].ToString() == "favs"))
            {
                int mi = int.Parse(Request.Params["m"].ToString());
                int cid = (int)(((EColors)e.Item.DataItem).ColorId);
                int aj = (int)(((EColors)e.Item.DataItem).Author);
                int rt = (int)(((EColors)e.Item.DataItem).N3w);
                int mj = (int)(((EColors)e.Item.DataItem).MemberId);
                

                int i = BMember.ReturnId(lk());
                HtmlImage rtn = new HtmlImage();
                rtn = (HtmlImage)e.Item.FindControl("irt");
                if (i == mi)
                {
                    if (rt == 1)
                    {
                        EFlowing f = new EFlowing();
                        f.ToMember = aj;
                        EMember x = new EMember();
                        x.MemberId = mi;
                        f.UserName = BMember.PMemberU(x);
                        f = BFlowing.SFlowing(f);
                        if (f.MemberId == -1) rtn.Visible = true;
                        else if (f.Flws && f.Approves && !f.Blocks && !f.Removes) rtn.Visible = false;
                        if (mi == aj)
                        {
                            rtn.Visible = false;
                        }
                    }
                    else rtn.Visible = false;
                }
                else
                {
                    if (rt == 1) rtn.Visible = true;
                    else rtn.Visible = false;
                }
                EColorMbrs cl = new EColorMbrs();
                cl.ColorId = cid;
                List<EColorMbrs> clr = new List<EColorMbrs>();
                clr = BColors.LstClrMrs(cl);
                bool fl = false;
                if (clr.Count > 0)
                {
                    HtmlGenericControl rtw = new HtmlGenericControl();
                    rtw = (HtmlGenericControl)e.Item.FindControl("nw3wll");
                    HtmlGenericControl rtw2 = new HtmlGenericControl();
                    rtw2 = (HtmlGenericControl)e.Item.FindControl("wclrr");
                    for (int a = 0;a<clr.Count;a++)
                    {
                        if (rtw2.InnerHtml != "") rtw2.InnerHtml += ", ";
                        else rtw2.InnerHtml = "Đăng lại bởi ";
                        if (clr[a].MemberId == i) fl = true;
                        rtw2.InnerHtml += "<a href=\"profile.aspx?v=wall&m=" + clr[a].MemberId + "\"  title=\"" + ltsDate(clr[a].ColorDate) + "\" class=\"wls4re\">" + clr[a].UserName + "</a>";
                        if (rtn.Visible) rtw.Visible = true;
                        else if (!rtn.Visible && fl) rtw.Visible = true;
                        else if (!fl && i == aj) rtw.Visible = true;
                    }
                }
                clr = BColors.LstClrFavs(cl);
                HtmlGenericControl topbgwn = new HtmlGenericControl();
                topbgwn = (HtmlGenericControl)e.Item.FindControl("topbgw");
                if (clr.Count > 0)
                {
                    HtmlGenericControl rtf = new HtmlGenericControl();
                    rtf = (HtmlGenericControl)e.Item.FindControl("n3wwf");
                    HtmlGenericControl rtf2 = new HtmlGenericControl();
                    rtf2 = (HtmlGenericControl)e.Item.FindControl("wclfp");
                    if (clr.Count >= 2) rtf2.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + clr[0].MemberId + "\"  title=\"" + ltsDate(clr[0].ColorDate) + "\" class=\"wls4re\">" + clr[0].UserName + "</a> và " + (clr.Count -1) + " người khác thích bài này.";
                    else rtf2.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + clr[0].MemberId + "\"  title=\"" + ltsDate(clr[0].ColorDate) + "\" class=\"wls4re\">" + clr[0].UserName + "</a> thích bài viết này.";
                    rtf.Visible = true;
                    topbgwn.Attributes.Add("class", "wls4fr");
                    LinkButton cf = new LinkButton();
                    cf = (LinkButton)e.Item.FindControl("icrfp");
                    for (int a = 0; a < clr.Count; a++)
                    {
                        if (clr[a].MemberId == i) cf.Text = "Bỏ thích";
                        break;
                    }
                }
                LinkButton cr = new LinkButton();
                cr = (LinkButton)e.Item.FindControl("icrsp");
                if (aj != i && !fl) cr.Attributes.Add("onclick", "return confirm('Bạn muốn đăng lại bài viết này?');");
                else if (aj == i) cr.Visible = false;
                else if (aj != i && fl) cr.Text = "Bỏ chia sẻ";
                ImageButton dp = new ImageButton();
                dp = (ImageButton)e.Item.FindControl("icrdp");
                if (aj == i || mj == i)
                {
                    HtmlGenericControl del1 = new HtmlGenericControl();
                    del1 = (HtmlGenericControl)e.Item.FindControl("icolor");
                    HtmlGenericControl del = new HtmlGenericControl();
                    del = (HtmlGenericControl)e.Item.FindControl("iclrr");
                    del1.Attributes.Add("onmouseover","ovclr('" + del.ClientID + "');");
                    del1.Attributes.Add("onmouseout", "osclr('" + del.ClientID + "');");
                    dp.Attributes.Add("onclick", "return confirm('Bạn muốn xoá bài viết này phải không?');");
                }
                else dp.Visible = false;
                Button icmtsn = new Button();
                icmtsn = (Button)e.Item.FindControl("icmts");
                icmtsn.CommandName = "crip";
                icmtsn.CommandArgument = cid.ToString();
                HtmlImage sign2n = new HtmlImage();
                sign2n = (HtmlImage)e.Item.FindControl("sign2");
                HtmlTextArea artc = new HtmlTextArea();
                artc = (HtmlTextArea)e.Item.FindControl("clrcmt");
                HtmlGenericControl cmtbtns1 = new HtmlGenericControl();
                cmtbtns1 = (HtmlGenericControl)e.Item.FindControl("cmtbtns");
                HtmlGenericControl signpnn = new HtmlGenericControl();
                signpnn = (HtmlGenericControl)e.Item.FindControl("signpn");
                artc.Attributes.Add("onfocus", "chart('" + artc.ClientID + "','" + cmtbtns1.ClientID + "');if (this.value=='Viết bình luận...') this.value='';");
                artc.Attributes.Add("onblur", "chart2('" + artc.ClientID + "','" + cmtbtns1.ClientID + "');if (this.value=='') this.value='Viết bình luận...';");
                HtmlAnchor shwcmtn = new HtmlAnchor();
                shwcmtn = (HtmlAnchor)e.Item.FindControl("swcmt");
                HtmlGenericControl n3wcmtn = new HtmlGenericControl();
                n3wcmtn = (HtmlGenericControl)e.Item.FindControl("n3wcmt");
                shwcmtn.Attributes.Add("onclick", "shwcmt('" + n3wcmtn.ClientID + "','" + topbgwn.ClientID + "');return false;");
                icmtsn.Attributes.Add("onclick", "find3('" + sign2n.ClientID + "','" + artc.ClientID + "','" + signpnn.ClientID + "','" + n3wcmtn.ClientID + "');");
                List<EColors> rct = new List<EColors>();
                EColors r1c = new EColors(cid);
                rct = BColors.LstClrCmts3(r1c);
                Repeater r2c = new Repeater();
                r2c = (Repeater)e.Item.FindControl("rpticmnts");
                if (rct.Count > 0)
                {
                    r2c.DataSource = rct;
                    r2c.DataBind();
                    topbgwn.Attributes.Add("class", "wls4fr");
                    if (BColors.F2c(cid) > rct.Count)
                    {
                        HtmlGenericControl cmtaln = new HtmlGenericControl();
                        cmtaln = (HtmlGenericControl)e.Item.FindControl("cmtal");
                        cmtaln.Visible = true;
                        LinkButton alcwal = new LinkButton();
                        alcwal = (LinkButton)e.Item.FindControl("swallid");
                        HtmlImage ca = new HtmlImage();
                        ca = (HtmlImage)e.Item.FindControl("sign");
                        alcwal.Attributes.Add("onclick", "salcs('" + ca.ClientID + "');");
                        alcwal.Visible = true;
                    }
                }
                else r2c.Visible = false;
            }
        }
    }

    protected void rpticmnts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null
            && (Request.Params["v"].ToString() == "wall" || Request.Params["v"].ToString() == "favs"))
        {
            if (e.CommandName == "crdpc")
            {
                EColors c = new EColors();
                c.CommentId = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                c.AutName = lk();
                BColors.FColors2(c);
                HtmlGenericControl inc = new HtmlGenericControl();
                inc = (HtmlGenericControl)e.Item.FindControl("icmnts");
                inc.Visible = false;
            }
        }
    }

    protected void rptClrs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null
            && (Request.Params["v"].ToString() == "wall" || Request.Params["v"].ToString() == "favs"))
        {
            int i = int.Parse(Request.Params["m"].ToString());
            int j = BMember.ReturnId(lk());
            string cmd = e.CommandName.ToString();
            switch (cmd)
            {
                case "crdp":
                    {
                        EColors c = new EColors();
                        c.ColorId = int.Parse(((ImageButton)e.CommandSource).CommandArgument);
                        BColors.FColors(c);
                        if (i != j) BServer.Remove("Colorsw" + i, true);
                        else BServer.Remove("Colors" + i, true);
                        clrs();
                        break;
                    }
                case "crsp":
                    {
                        EColors c = new EColors();
                        c.ColorId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
                        c.AutName = lk();
                        c.IP = HttpContext.Current.Request.UserHostAddress;
                        BColors.UColors(c);
                        if (i != j) BServer.Remove("Colorsw" + i, true);
                        else BServer.Remove("Colors" + i, true);
                        clrs();
                        break;
                    }
                case "crfp":
                    {
                        EColors c = new EColors();
                        c.ColorId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
                        c.AutName = lk();
                        BColors.IFavs(c);
                        if (i != j) BServer.Remove("Colorsw" + i, true);
                        else BServer.Remove("Colors" + i, true);
                        clrs();
                        break;
                    }
                case "crip":
                    {
                        EColors c = new EColors();
                        c.ColorId = int.Parse(((Button)e.CommandSource).CommandArgument);
                        HtmlTextArea artc = new HtmlTextArea();
                        artc = (HtmlTextArea)e.Item.FindControl("clrcmt");
                        c.Colors = rplc(HungLocSon.Tools.Support.ReleaseInput(artc.Value, 420));
                        c.AutName = lk();
                        c.IP = HttpContext.Current.Request.UserHostAddress;
                        string vi = "";
                        if (EncryptM.isMobileBrowser(ref vi)) c.Via = vi;
                        else c.Via = "Web";
                        BColors.IColors2(c);
                        if (i != j) BServer.Remove("Colorsw" + i, true);
                        else BServer.Remove("Colors" + i, true);
                        HtmlGenericControl n3wcmtn = new HtmlGenericControl();
                        n3wcmtn = (HtmlGenericControl)e.Item.FindControl("n3wcmt");
                        n3wcmtn.Attributes.Remove("class");
                        n3wcmtn.Attributes.Add("class", "wls7");
                        artc.Value = "Viết bình luận...";
                        List<EColors> rct = new List<EColors>();
                        HtmlInputHidden hashsn = new HtmlInputHidden();
                        hashsn = (HtmlInputHidden)e.Item.FindControl("hashs");
                        if (hashsn.Value == "-1") rct = BColors.LstClrCmts3(c);
                        else rct = BColors.LstClrCmts(c);
                        Repeater r2c = new Repeater();
                        r2c = (Repeater)e.Item.FindControl("rpticmnts");
                        if (rct.Count > 0)
                        {
                            r2c.DataSource = rct;
                            r2c.DataBind();
                            r2c.Visible = true;
                        }
                        else r2c.Visible = false;
                        break;
                    }
                case "swall":
                    {
                        EColors c = new EColors();
                        c.ColorId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
                        List<EColors> rct = new List<EColors>();
                        rct = BColors.LstClrCmts(c);
                        Repeater r2c = new Repeater();
                        r2c = (Repeater)e.Item.FindControl("rpticmnts");
                        if (rct.Count > 0)
                        {
                            r2c.DataSource = rct;
                            r2c.DataBind();
                        }
                        LinkButton alcwal = new LinkButton();
                        alcwal = (LinkButton)e.Item.FindControl("swallid");
                        alcwal.Visible = false;
                        HtmlGenericControl cmtaln = new HtmlGenericControl();
                        cmtaln = (HtmlGenericControl)e.Item.FindControl("cmtal");
                        cmtaln.Visible = false;
                        HtmlInputHidden hashsn = new HtmlInputHidden();
                        hashsn = (HtmlInputHidden)e.Item.FindControl("hashs");
                        hashsn.Value = "0";
                        break;
                    }
            }
        }
    }
    public string ltsDate(DateTime a)
    {
        TimeSpan ts = DateTime.Now - a;
        if (ts.Days == 0 && ts.Hours > 0) return "khoảng " + ts.Hours + " tiếng trước";
        else if (ts.Days == 0 && ts.Minutes > 0 && ts.Hours == 0) return "khoảng " + ts.Minutes + " phút trước";
        else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds > 0) return "cách đây khoảng " + ts.Seconds + " giây";
        else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds == 0) return "mới tức thì đây";
        else if (ts.Days > 0 && ts.Days <=  3) return "cách đây " + ts.Days + " ngày";
        else return a.ToLongTimeString() + " " + a.Day.ToString() + "/" + a.Month.ToString() + "/" + a.Year.ToString();
    }

    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
    }

    protected void iflwt_Click(object sender, EventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["g"] != null && Request.Params["g"].ToString() != "")
        {
            ETracks tr = new ETracks();
            tr.ListId = int.Parse(Request.Params["g"].ToString());
            tr.IName = lk();
            BColors.ItrIFlw(tr);
            BTracks.GrpDtls(ref tr);
            int i = int.Parse(Request.Params["m"].ToString());

            EProfile p = new EProfile();
            EMember m = new EMember();
            m.MemberId = i;
            p = BMember.PMemberI(m);
            string namef = BMember.PMemberU(m);
            ifname.InnerHtml = "<a href=\"profile.aspx?v=wall&m=" + i + "\" class=\"wls3hr\" title=\"Nhóm này được tạo bởi " + namef + "\"><img class=\"ifwnimg\" src=\"avas/thumbs/" + p.Logo + "\"/></a>";
            ifname.InnerHtml += " <span class=\"ifwnimg2\">" + tr.LstName;
            if (tr.LstDesc != "") ifname.InnerHtml += "<span class=\"spdscgr\">(" + tr.LstDesc + ")";
            else ifname.InnerHtml += "<span class=\"spdscgr\">";
            if (tr.IsList > 0)
            {
                ifname.InnerHtml += "&nbsp;&nbsp;<img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo</span></span>";
                iflwt.Text = "Không theo";
                iflwt.Attributes.Add("onclick", "javascript:return confirm('Bạn không muốn tiếp tục theo đuôi nhóm này?');");
            }
            else
            {
                iflwt.Attributes.Add("onclick", "javascript:return confirm('Bạn muốn theo đuôi nhóm này?');");
                ifname.InnerHtml += "</span></span>";
                iflwt.Text = "Theo nhóm này";
            }
        }
    }

    protected void signu_Click(object sender, EventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EColors cl = new EColors();
            System.Text.StringBuilder wll = new System.Text.StringBuilder(435);
            wll.Append(HungLocSon.Tools.Support.ReleaseInput(nwall.Value,420));
            cl.Colors = rplc(wll.ToString());
            cl.MemberId = int.Parse(Request.Params["m"].ToString());
            cl.AutName = lk();
            string vi = "";
            if (EncryptM.isMobileBrowser(ref vi)) cl.Via = vi;
            else cl.Via = "Web Desktop";
            cl.Hash = lk();
            cl.IP = HttpContext.Current.Request.UserHostAddress;
            BColors.IColors(cl);
            nwall.Value = "Hôm nay, Bạn có gì mới ?";
            sta();
            int i = BMember.ReturnId(cl.AutName);
            if (i != cl.MemberId) BServer.Remove("Colorsw" + cl.MemberId, true);
            else BServer.Remove("Colors" + cl.MemberId, true);
            clrs();
            nwall.Attributes.Add("class","nwtxtr");
        }
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" && ck.Value != null) us = ck.Value.ToString();
        return us;
    }
    protected void pg_Click(object sender, EventArgs e)
    {
        cntfm.Value = Convert.ToString(int.Parse(cntfm.Value.ToString()) + 1);
        clrs();
    }
}
