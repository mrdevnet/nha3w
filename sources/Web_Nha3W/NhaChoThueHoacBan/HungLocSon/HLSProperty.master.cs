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
using System.Text;
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class HLSProperty : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ana();
            if (lk() != "")
            {
                ImReals();
                cmdtopfls.Visible = false;
                pri.Visible = true;
                reg.Visible = false;
                lg.Visible = false;
                sg.Visible = true;
                Pm();
                States();
                EPFiles fi = new EPFiles();
                fi.MemberId = BMember.ReturnId(lk());
                int vfs = fi.MemberId;
                fi = BFlowing.PFiles(fi);
                cflwings.InnerText = fi.FlCount.ToString();
                cflwrs.InnerText = fi.FrCount.ToString();
                clsted.InnerText = fi.LstRCount.ToString();
                EFlowing f = new EFlowing();
                f.UserName = lk();
                if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() != "")
                {
                    walls.Visible = true;
                    rtn2();
                    int ar = int.Parse(Request.Params["m"].ToString());
                    if (ar != vfs)
                    {
                        mv.Visible = false;
                    }
                    f.MemberId = ar;
                    Nets2a(f);
                    f.ToMember = ar;
                    fi.MemberId = f.ToMember;
                    fi = BFlowing.PFiles(fi);
                    cflwings.InnerText = fi.FlCount.ToString();
                    cflwrs.InnerText = fi.FrCount.ToString();
                    clsted.InnerText = fi.LstRCount.ToString();
                    f = BFlowing.SFlowing(f);
                    if (f.MemberId == -1) adfrs.Visible = true;
                    else if (f.BlockEd)
                    {
                        flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/blk2.png\"/>&nbsp;&nbsp;Đã bị khoá</span>";
                        adfrs.Visible = false;
                    }
                    else if (f.Flws && f.Approves)
                    {
                        flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo&nbsp;&nbsp;</span>";
                        ifrs.Visible = true;
                        adfrs.Visible = false;
                    }
                    else if (f.Flws && !f.Approves)
                    {
                        afrs.Visible = true;
                        adfrs.Visible = false;
                        flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang chờ duyệt&nbsp;&nbsp;</span>";
                    }
                    if (f.Blocks)
                    {
                        blki2.Visible = false;
                        blki3.Visible = true;
                        spmi.Visible = false;
                    }
                    //else if (!f.Flws && !f.Approves && !f.Blocks && !f.Removes && !f.Spams) adfrs.Visible = true;
                    //else if (f.Removes && !f.Blocks) adfrs.Visible = true;
                    //else if (f.Flws && !f.Approves && !f.Blocks && !f.Removes)
                    //{
                    //    afrs.Visible = true;
                    //    adfrs.Visible = false;
                    //    flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang chờ duyệt&nbsp;&nbsp;</span>";
                    //}
                    //else if (f.Blocks || f.Spams)
                    //{
                    //}
                    //else if (f.Flws && f.Approves && !f.Blocks && !f.Removes)
                    //{
                    //    flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo&nbsp;&nbsp;</span>";
                    //    ifrs.Visible = true;
                    //    adfrs.Visible = false;
                    //}
                }
                else
                {
                    Nets2(f);
                    walls.Visible = false;
                    eipr2.Visible = false;
                    blki.Visible = false;
                    spmi.Visible = false;
                }

                cntUsers();

                aprombrs();
            }
            else
            {
                walls.Visible = false;
                cmdfrls.Visible = false;
                Nets3();
            }
            Logs();
            Nets();
            LstLgs();
            Reports();
            BindList();
        }
    }

    private void BindList()
    {
        EnMember mbr = new EnMember();
        mbr.UserName = SentForCook();
        r4r.DataSource = BuMemberProfile.SelectLive(mbr);
        r4r.DataBind();
        r4n.DataSource = BNews.LstTp10Ns();
        r4n.DataBind();
        r4d.DataSource = BDownloads.LstTop10Dls();
        r4d.DataBind();
    }

    private string SentForCook()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = Request.Cookies["SLMFMembers"];
        string strUser = "";
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            strUser = SlmMemberCookie.Value.ToString();
        }
        return strUser;
    }

    private void cntUsers()
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.QueryString.Count == 1)
        {
            int ar = int.Parse(Request.Params["m"].ToString());
            int n = BMember.ReturnId(lk());
            if (ar != n)
            {
                EFlowing f = new EFlowing();
                f.UserName = lk();
                f.ToMember = ar;
                f = BFlowing.SFlowing(f);
                if (f.MemberId == -1) itfra.Visible = true;
                else if (f.BlockEd)
                {
                    spdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/blk2.png\"/>&nbsp;&nbsp;Đã bị khoá</span>";
                    itfra.Visible = false;
                }
                else if (f.Flws && f.Approves)
                {
                    spdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo&nbsp;&nbsp;</span>";
                    itfra.Visible = false;
                }
                else if (f.Flws && !f.Approves)
                {
                    itfrap.Visible = true;
                    itfra.Visible = false;
                    spdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang chờ duyệt</span>";
                }
                else if (!f.Flws)
                {
                    itfra.Visible = true;
                }
                //if (f.Blocks)
                //{
                //    blki2.Visible = false;
                //    blki3.Visible = true;
                //    spmi.Visible = false;
                //}
            }
            else itfra.Visible = false;
        }
    }

    private void aprombrs()
    {
        List<EFlowing> tr = BFlowing.LstAproMbrs(BMember.ReturnId(lk()));
        flwings.DataSource = tr;
        flwings.DataBind();
        grps.InnerHtml = "Có " + tr.Count + " thành viên chờ duyệt";
        if (tr.Count == 0) spprmr.Visible = false;
    }
    protected void flwings_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
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
            //System.Collections.Generic.List<ETracks> t4 = new System.Collections.Generic.List<ETracks>();
            //ETracks t4u = new ETracks();
            //t4u.MemberId = cid;
            //t4u.IName = lk();
            //t4 = BFlowing.LstTr4u(t4u);
            //if (t4.Count > 0)
            //{
            //    del1.InnerHtml += "<br/><img src=\"images/grpo.png\" /> Nhóm của bạn: ";
            //    for (int k1 = 0; k1 < t4.Count; k1++)
            //    {
            //        del1.InnerHtml += "<a href=\"profile.aspx?v=wall&m=" + BMember.ReturnId(lk()) + "&g=" + t4[k1].ListId + "\" class=\"wls4re\">" + t4[k1].LstName + "</a>";
            //        if (k1 < t4.Count - 1) del1.InnerHtml += ", ";
            //    }
            //}
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

    protected void flwings_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cmdflws")
        {
            EFlowing f = new EFlowing();
            f.MemberId = int.Parse(((Button)e.CommandSource).CommandArgument);
            f.UserName = lk();
            BFlowing.UFlws(f);
            aprombrs();
        }
    }

    private void Reports()
    {
        rpts.DataSource = BReports.Reports();
        rpts.DataBind();
    }

    public string CntPms()
    {
        string i= BPms.PMS_NewInbox(BMember.ReturnId(lk()));
        if (i == "0") return "";
        else return "( " + i + " )";
    }

    private void States()
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null)
        {
             //&& Request.Params["v"].ToString() == "wall"
            int i = int.Parse(Request.Params["m"].ToString());
            int j = BMember.ReturnId(lk());
            if (i != j)
            {
                cmdn3w.Visible = false;
                flwing.Visible = true;
                flwing2.Visible = true;
                eipr.Visible = false;
                pels.Visible = false;
                profs.Visible = false;
                eipr2.Visible = true;
                blki.Visible = true;
                spmi.Visible = true;
            }
            else
            {
                eipr2.Visible = false;
                blki.Visible = false;
                spmi.Visible = false;
                flwing.Visible = false;
                flwing2.Visible = false;
            }
        }
        else
        {
            flwing.Visible = false;
            flwing2.Visible = false;
            cmdn3w.Visible = true;
        }
        int a1 = 0, a2 = 0, a4 = 0, a3 = 0, a0 = 0, a5 = 0;
        BPosts.States(ref a1, ref a2, ref a4, ref a3, ref a0, lk());
        if (a1 > 0) sta1.InnerHtml = "Đang hiển thị (" + a1 + ")";
        if (a2 > 0) sta2.InnerHtml = "Đang chờ duyệt (" + a2 + ")";
        if (a4 > 0) sta4.InnerHtml = "Đang soạn (" + a4 + ")";
        if (a3 > 0) sta3.InnerHtml = "Chưa hợp lệ (" + a3 + ")";
        if (a0 > 0) sta0.InnerHtml = "Đăng tin mới (" + a0 + ")";
        EMember c = new EMember();
        c.UserName = lk();
        a5 = BSaves.ASaves(c);
        if (a5 > 0) stas.InnerHtml = "Tin đã lưu (" + a5 + ")";
    }

    public string Avw()
    {
        return BAnas.VwO();
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    public string lk3()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    private string jks()
    {
        HttpCookie ck = new HttpCookie("hlsbraut");
        ck = Request.Cookies["hlsbraut"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    private string pwc()
    {
        HttpCookie ck = new HttpCookie("hlsbrocr");
        ck = Request.Cookies["hlsbrocr"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }

    private void ImReals()
    {
        HungLocSon.UHLS.EncryptM m5 = new HungLocSon.UHLS.EncryptM();
        if (m5.Md5Encode(BMember.APwds(lk())) != pwc())
        {
            Response.Redirect("signout.aspx");
        }
    }

    private void Pm()
    {
        lft.Visible = true;
        scl.Attributes.Add("class", "ph3");
        EMember m = new EMember();
        EProfile p = new EProfile();
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null)
        {
             //&& Request.Params["v"].ToString() == "wall"
            m.MemberId = int.Parse(Request.Params["m"].ToString());
            p = BMember.PMemberI(m);
        }
        else
        {
            m.UserName = lk();
            p = BMember.PMember(m);
        }
        StringBuilder s = new StringBuilder(1000);
        s.Append("<span class=\"sbTex\">Họ và tên:<br><b>" + p.FullName + "</b>");
        if (p.Company != null && p.Company != "") s.Append("<br>Công ty:<br><b>" + p.Company + "</b>");
        if (p.Address != null && p.Address != "") s.Append("<br>Địa chỉ:<br><b>" + p.Address + "</b>");
        if ((p.Tel != null && p.Mobile != null) && (p.Tel != "" || p.Mobile != "")) s.Append("<br>Điện thoại/Di động:<br><b>" + HungLocSon.UHLS.EncryptM.ToOutput(p.Tel) + " - " + HungLocSon.UHLS.EncryptM.ToOutput(p.Mobile) + "</b>");
        string strMils = HungLocSon.UHLS.EncryptM.ToOutput(p.Email);
        string strMils1 = strMils.Substring(0, strMils.LastIndexOf("@"));
        strMils = strMils.Substring(strMils.LastIndexOf("@"), strMils.Length - strMils.LastIndexOf("@"));
        if (p.Email != null && p.Email != "") s.Append("<br>Email:<br><b>" + strMils1 + " " + strMils + "</b>");
        s.Append("</span>");
        if (p.Logo != "" && p.Logo != null)
        {
            avas.Src = "avas/" + p.Logo;

            //string n3wi = ihn(pf.FileName);
            //System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~\\" + "pros/tpls/" + pf.FileName));
            //Bitmap bmp = img as Bitmap;
            string iex = Server.MapPath("~\\" + "avas/" + p.Logo);
            if (System.IO.File.Exists(iex))
            {
                byte[] imgData = getData(iex);
                System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgData));
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(new System.Drawing.Bitmap(img));
                // remove at moment System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp); 
                System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(bmp);
                bmp.Dispose();
                img.Dispose();

                if (bmpNew.Height > 96) avas.Attributes.Add("class", "m2l2p");
                else avas.Attributes.Add("class", "m2l");

                //code to manipulate bmpNew goes here.
                //Bitmap log = new Bitmap(Server.MapPath("~/prom/nha3wlgo.png"));
                //bmpNew = EncryptM.CreateThumbnail(bmpNew, 152, 96);
                bmpNew.Dispose();
            }
        }

        //else avas.Src = "images/procity.gif";
        full.InnerHtml = p.FullName;
        pr.InnerHtml = s.ToString();
    }

    private byte[] getData(string filePath)
    {
        System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        byte[] data = br.ReadBytes((int)fs.Length);
        br.Close();
        fs.Close();
        return data;
    }

    public int rtnId()
    {
        //&& Request.Params["v"].ToString() == "wall" 
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null) 
            return int.Parse(Request.Params["m"].ToString());
        else return BMember.ReturnId(lk());
    }

    public string rtnId2()
    {
        string r = "";
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EMember m = new EMember(int.Parse(Request.Params["m"].ToString()));
            r = BMember.PMemberU(m);
        }
        return r;
    }

    public string foreverinlove()
    {
        string r = "";
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EMember m = new EMember();
            EProfile p = new EProfile();
            m.MemberId = int.Parse(Request.Params["m"].ToString());
            p = BMember.PMemberI(m);
            r = p.FullName;
        }
        return r;
    }

    private void rtn2()
    {
        string i = "";
        if (Request.Params["v"] != null && Request.Params["v"].ToString() != "")
        {
            i = Request.Params["v"].ToString();
        }
        switch (i)
        {
            case "wall":
                {
                    mw.Attributes.Add("class", "HeaderFr2");
                    //mf.Attributes.Add("class", "HeaderFr");
                    //mr.Attributes.Add("class", "HeaderFr");
                    //mg.Attributes.Add("class", "HeaderFr");
                    //mv.Attributes.Add("class", "HeaderFr");
                    //ms.Attributes.Add("class", "HeaderFr");
                    break;
                }
            case "frs":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    mf.Attributes.Add("class", "HeaderFr2");
                    break;
                }
            case "flws":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    mr.Attributes.Add("class", "HeaderFr2");
                    break;
                }
            case "grps":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    mg.Attributes.Add("class", "HeaderFr2");
                    break;
                }
            case "favs":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    mv.Attributes.Add("class", "HeaderFr2");
                    break;
                }
            case "schs":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    ms.Attributes.Add("class", "HeaderFr2");
                    break;
                }
            case "psts":
                {
                    mw.Attributes.Add("class", "HeaderFr");
                    mp.Attributes.Add("class", "HeaderFr2");
                    break;
                }
        }
        mw.HRef = "profile.aspx?v=wall&m=" + rtnId();
        mf.HRef = "profile.aspx?v=frs&m=" + rtnId();
        mr.HRef = "profile.aspx?v=flws&m=" + rtnId();
        mg.HRef = "profile.aspx?v=grps&m=" + rtnId();
        mv.HRef = "profile.aspx?v=favs&m=" + rtnId();
        ms.HRef = "profile.aspx?v=schs&m=" + rtnId();
        mp.HRef = "profile.aspx?v=psts&m=" + rtnId();
    }


    private void Logs()
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "")
        {
            ELogs lg = new ELogs();
            lg.PostId = int.Parse(Request.Params["p"].ToString());
            lg.SdId = HttpContext.Current.Session.SessionID;
            BLogs.ILogs(lg);
        }
    }

    private void Nets()
    {
        List<EAnas> ns = new List<EAnas>();
        ns = BAnas.LstNets();
        if (ns.Count > 0)
        {
            netv.DataSource = ns;
            netv.DataBind();
            if (lk() != "") ioli2.Attributes.Add("class", "ph3");
            else ioli2.Attributes.Add("class", "php");
            i9ns.Attributes.Add("class", "ph3");
        }
        else
        {
            cmdont.Visible = false;
            i9ns.Attributes.Add("class", "php");
        }
    }

    private void Nets2(EFlowing f)
    {
        List<EAnas> ns = new List<EAnas>();
        ns= BFlowing.LstMFrs(f);
        if (ns.Count > 0)
        {
            rfrs.DataSource = ns;
            rfrs.DataBind();
            cmdfrls.Visible = true;
        }
        else cmdfrls.Visible = false;
    }

    private void Nets2a(EFlowing f)
    {
        List<EAnas> ns = new List<EAnas>();
        ns = BFlowing.LstMFrs2(f);
        if (ns.Count > 0)
        {
            rfrs.DataSource = ns;
            rfrs.DataBind();
            cmdfrls.Visible = true;
        }
        else cmdfrls.Visible = false;
    }

    private void Nets3()
    {
        List<EAnas> ns = new List<EAnas>();
        ns = BFlowing.TopFlwrings2();
        topflws.DataSource = ns;
        topflws.DataBind();
    }


    private void LstLgs()
    {
        bool fl = false;
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() != "")
        {
            int i = int.Parse(Request.Params["m"].ToString());
            int j = BMember.ReturnId(lk());
            if (i != j) fl = true;
        }
        if (!fl)
        {
            ELogs lg = new ELogs();
            lg.SdId = HttpContext.Current.Session.SessionID;
            List<ELogs> lgs = new List<ELogs>();
            lgs = BLogs.Logs(lg);
            if (lgs.Count > 0)
            {
                rlgs.DataSource = lgs;
                rlgs.DataBind();
                cmdspt.Visible = true;
            }
            else cmdspt.Visible = false;
        }
        else cmdspt.Visible = false;
    }

    private void ana()
    {
        EAnas a = new EAnas();
        EMember m = new EMember();
        if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] != null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.CY = int.Parse(Request.Params["y"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] != null && Request.Params["t"] == null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.CL = int.Parse(Request.Params["l"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] != null && Request.Params["a"] == null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.SE = int.Parse(Request.Params["t"].ToString());
        }
        else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] != null)
        {
            a.CT = int.Parse(Request.Params["c"].ToString());
            a.DT = int.Parse(Request.Params["d"].ToString());
            a.WA = int.Parse(Request.Params["a"].ToString());
        }
        //else if (Request.Params["m"] != null && Request.Params["c"] == null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
        //{
        //    a.MI = int.Parse(Request.Params["m"].ToString());
        //}
        a.UR = lk();
        a.IP = HttpContext.Current.Request.UserHostAddress;
        a.SD = HttpContext.Current.Session.SessionID;
        BAnas.IAnas(a);
    }
    //protected void adfrs_Click(object sender, ImageClickEventArgs e)
    protected void adfrs_Click(object sender, EventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EFlowing f = new EFlowing();
            f.UserName = lk();
            f.ToMember = int.Parse(Request.Params["m"].ToString());
            f.Flws = true;
            f.Approves = false;
            f.Blocks = false;
            f.Spams = false;
            f.Removes = false;
            f.Type = 1;
            int i = BFlowing.IFlowing(f);
            EPFiles fi = new EPFiles();
            fi.MemberId = f.ToMember;
            fi = BFlowing.PFiles(fi);
            cflwrs.InnerText = fi.FrCount.ToString();
            if (i == 1)
            {
                adfrs.Visible = false;
                ifrs.Visible = true;
                flwdtls.Visible = true;
                flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang theo&nbsp;&nbsp;</span>";
            }
            else if (i==-3)
            {
                flwing2.Visible = false;
                flwing.Visible = false;
                flwdtls.Visible = false;
            }
            else
            {
                adfrs.Visible = false;
                afrs.Visible = true;
                flwdtls.Visible = true;
                flwdtls.InnerHtml = "<span class=\"spdscgr\"><img class=\"wlsimg\" src=\"images/tick.png\"/>&nbsp;Đang chờ duyệt&nbsp;&nbsp;</span>";
            }
            cntUsers();
            spdtls.Visible = true;
        }
    }

    protected void blki2_Click(object sender, EventArgs e)
    {
        EFlowing f = new EFlowing();
        f.UserName = lk();
        f.ToMember = int.Parse(Request.Params["m"].ToString());
        f.Flws = false;
        f.Approves = false;
        f.Blocks = true;
        f.Spams = false;
        f.Removes = false;
        f.Type = 3;
        int i = BFlowing.IFlowing(f);
        blki3.Visible = true;
        blki2.Visible = false;
        spmi.Visible = false;
    }

    protected void blki3_Click(object sender, EventArgs e)
    {
        EFlowing f = new EFlowing();
        f.UserName = lk();
        f.ToMember = int.Parse(Request.Params["m"].ToString());
        f.Flws = false;
        f.Approves = false;
        f.Blocks = false;
        f.Spams = false;
        f.Removes = false;
        f.Type = 3;
        int i = BFlowing.IFlowing(f);
        blki3.Visible = false;
        blki2.Visible = true;
        spmi.Visible = true;
    }

    protected void spmi2_Click(object sender, EventArgs e)
    {
        EFlowing f = new EFlowing();
        f.UserName = lk();
        f.ToMember = int.Parse(Request.Params["m"].ToString());
        f.Flws = false;
        f.Approves = false;
        f.Blocks = true;
        f.Spams = true;
        f.Removes = false;
        f.Type = 4;
        int i = BFlowing.IFlowing(f);
        blki3.Visible = true;
        blki2.Visible = false;
        spmi.Visible = false;
    }

    protected void ifrs_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EFlowing f = new EFlowing();
            f.UserName = lk();
            f.ToMember = int.Parse(Request.Params["m"].ToString());
            f.Flws = false;
            f.Approves = false;
            f.Blocks = false;
            f.Spams = false;
            f.Removes = false;
            f.Type = 1;
            BFlowing.IFlowing(f);
            EPFiles fi = new EPFiles();
            fi.MemberId = f.ToMember;
            fi = BFlowing.PFiles(fi);
            cflwrs.InnerText = fi.FrCount.ToString();
            adfrs.Visible = true;
            flwdtls.Visible = false;
            ifrs.Visible = false;
            afrs.Visible = false;
        }
    }
    protected void afrs_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
        {
            EFlowing f = new EFlowing();
            f.UserName = lk();
            f.ToMember = int.Parse(Request.Params["m"].ToString());
            f.Flws = false;
            f.Approves = false;
            f.Blocks = false;
            f.Spams = false;
            f.Removes = false;
            f.Type = 1;
            BFlowing.IFlowing(f);
            EPFiles fi = new EPFiles();
            fi.MemberId = f.ToMember;
            fi = BFlowing.PFiles(fi);
            cflwrs.InnerText = fi.FrCount.ToString();
            adfrs.Visible = true;
            flwdtls.Visible = false;
            ifrs.Visible = false;
            afrs.Visible = false;
            //cntUsers();
            spdtls.Visible = false;
            itfra.Visible = true;
            itfrap.Visible = false;
        }
    }
}
