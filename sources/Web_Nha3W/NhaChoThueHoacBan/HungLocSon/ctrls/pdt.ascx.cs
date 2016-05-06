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
using System.IO;
using HungLocSon.EHLS;
using HungLocSon.BHLS;
using HungLocSon.UHLS;
using HungLocSon.Tools;

public partial class ctrls_pdt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnpm.Attributes.Add("onclick", "find();");
        btnem.Attributes.Add("onclick", "find2();");
        btnvio.Attributes.Add("onclick", "find3();");
        if (!IsPostBack)
        {
            if (Request.Params["p"] != null)
            {
                int id = int.Parse(Request.Params["p"].ToString());
                Pdts(id,lk());
                EMember r = new EMember();
                r.UserName = lk();
                if (BSets.ASaved(r, id)) pn.Text = "Lưu tin";
                else pn.Text = "<span style=\"color:#A5A5A5\">Đã lưu</span>";
                if (lk() == "")
                {
                    n3wsave.Visible = false;
                    n3wpm2.Visible = false;
                    n3wem2.Visible = false;
                    n3wfns.Visible = false;
                    n3wcals.Visible = false;
                }
            }
        }
    }

    private void Saved()
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "")
        {
            EMember r = new EMember();
            r.UserName = lk();
            BSets.ISaved(r, int.Parse(Request.Params["p"].ToString()));
            if (pn.Text == "Lưu tin") pn.Text = "<span style=\"color:#A5A5A5\">Đã lưu</span>";
            else pn.Text = "Lưu tin";
        }
    }

    private void Called()
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "")
        {
            EMember r = new EMember();
            ECalls l = new ECalls();
            l.PostId = int.Parse(Request.Params["p"].ToString());
            l.IP = HttpContext.Current.Request.UserHostAddress;
            r.UserName = lk();
            BCalls.ICalls(l, r);
            if (ps.Text == "Báo đã bán") ps.Text = "<span style=\"color:#A5A5A5\">Đã thông báo</span>";
        }
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

    //public int Curr()
    //{
    //    int i = 0;
    //    if (Request.Params["pid"] != null)
    //    {
    //        i = int.Parse(Request.Params["pid"].ToString());
    //        BPosts p = new BPosts();
    //        EPosts e = new EPosts(i);
    //        i= p.Pdt(e).CurrencyId;
    //    }
    //    return i;
    //}

    private void Pdts(int id,string ura)
    {
        EPosts p = new EPosts(id);
        p.UserName = ura;
        p = BPosts.Pdt(p);

        StringBuilder ly = new StringBuilder(1000);
        ly.Append("<a class=\"agr1\" href=\"default.aspx\">N3W</a>");
        string strMap = "";
        //src="http://maps.google.com/maps/api/staticmap?center=Tran Hung Dao, Quan 1, Ho Chi Minh&zoom=14&size=379x300&markers=color:blue|label:N|Tran Hung Dao, Quan 1, Ho Chi Minh&sensor=true&format=png" 
        map.Src = "http://maps.google.com/maps/api/staticmap?center=";
        //Tran Hung Dao, Quan 1, Ho Chi Minh + "&zoom=14&size=379x300&markers=color:blue|label:N|" + Tran Hung Dao, Quan 1, Ho Chi Minh + "&sensor=true&format=png";

        if (p.CateName != "" && p.CateName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.CategoryId + "\">" + p.CateName + "</a>");
        if (p.ClassName != "" && p.ClassName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?l=" + p.ClassId + "\">" + p.ClassName + "</a>");
        if (p.ProName != "" && p.ProName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?pt=" + p.ProjectId + "\">" + p.ProName + "</a>");
        if (p.LocaName != "" && p.LocaName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?ltn=" + p.LocationId + "\">" + p.LocaName + "</a>");
        if (p.StrName != "" && p.StrName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?t=" + p.StreetId + "\">" + p.StrName + "</a>");
        strMap = p.StrName + ",";
        if (p.WardName != "" && p.WardName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?a=" + p.WardId + "\">" + p.WardName + "</a>");
        strMap += p.WardName + ",";
        if (p.DistrictName != "" && p.DistrictName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?d=" + p.DistrictId + "\">" + p.DistrictName + "</a>");
        strMap += p.DistrictName + ",";
        if (p.CityName != "" && p.CityName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?y=" + p.CityId + "\">" + p.CityName + "</a>");
        strMap += p.CityName + ",Việt Nam";
        maph1.Value = "http://maps.google.com/maps/api/staticmap?center=" + strMap;
        maph2.Value = "&size=379x300&markers=color:blue|label:N|" + strMap + "&sensor=true&format=png";
        map.Src += strMap + "&zoom=14&size=379x300&markers=color:blue|label:N|" + strMap + "&sensor=true&format=png";
        if (p.IsOwner) ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + 2 + "\">" + "Tin Chính chủ" + "</a>");
        else ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + 1 + "\">" + "Tin Môi giới" + "</a>");

        //if (naly.ON == 1) ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Tin Môi giới" + "</a>");
        //else if (naly.ON == 2) ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Tin Chính chủ" + "</a>");
        //else ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Môi giới/Chính chủ" + "</a>");

        hls1.InnerHtml = p.Title;
        //hls5.InnerHtml = p.Title;
        string tit2 = p.CateName + " " + p.ClassName.ToLower() + " - " + p.LocaName + ", ";
        if (p.ProName != "" && p.ProName != null) tit2 += "Thuộc Dự án: " + p.ProName + ", ";
        if (p.LotNumber != "" && p.LotNumber != null) tit2 += "Số nhà: " + p.LotNumber + ", ";
        if (p.StrName != "" && p.StrName != null) tit2 += "Đường " + p.StrName + ", ";
        if (p.WardName != "" && p.WardName != null) tit2 += p.WardName + ", ";
        if (p.DistrictName != "" && p.DistrictName != null) tit2 += p.DistrictName + ", ";
        if (p.CityName != "" && p.CityName != null) tit2 += p.CityName;
        if (p.IsOwner) tit2 += " (Tin chính chủ).";
        else tit2 += " (Tin môi giới).";
        hls5.InnerText = tit2.ToString();
        this.Page.Title = "Nhà 3W - " + tit2.ToString() + " - Kết nối & Xanh & Hiện đại";
        if (p.IsVip)
        {
            hls2.Visible = true;
        }
        else if (p.Silver && !p.IsVip)
        {
            hls2s.Visible = true;
        }
        if (p.HaveHouses)
        {
            ihs.Src = "../pros/" + p.CreationDate.Year.ToString() + "/" + p.CreationDate.Month.ToString() + "/" + id.ToString() + "/" + p.Images;
            ctlis.Value = "pros/" + p.CreationDate.Year.ToString() + "/" + p.CreationDate.Month.ToString() + "/" + id.ToString();
            EHouses eh = new EHouses();
            eh.PostId = id;
            List<EHouses> lh = new List<EHouses>();
            lh = BHouses.utis2(eh);
            rhs.DataSource = lh;
            rhs.DataBind();
        }
        else
        {
            ihs.Src = "../pros/villav.jpg";
        }


        switch (p.CategoryId)
        {
            case 2:
                {
                    hls3.Src = "../images/ico_chothue.gif";
                    hls3.Alt = "Cho thuê";
                    break;
                }
            case 3:
                {
                    hls3.Src = "../images/ico_canmua.gif";
                    hls3.Alt = "Cần mua";
                    break;
                }
            case 4:
                {
                    hls3.Src = "../images/ico_canthue.gif";
                    hls3.Alt = "Cần thuê";
                    break;
                }
            case 5:
                {
                    hls3.Src = "../images/ico_canban.gif";
                    hls3.Alt = "Chuyển nhượng";
                    break;
                }
            default:
                {
                    hls3.Src = "../images/ico_canban.gif";
                    hls3.Alt = "Cần bán";
                    break;
                }
        }
        if (p.IsOwner)
        {
            hls4.InnerHtml = id + " - CC";
        }
        else
        {
            hls4.InnerHtml = id + " - MG";
        }

        DateTime ag = p.Updated;
        TimeSpan ts = DateTime.Now - ag;
        if (ts.Days > 0 && ts.Days <= 7)
        {
            hls4.InnerHtml += " : " + ts.Days + " ngày";
        }
        else if (ts.Days == 0 && ts.Hours > 0)
        {
            hls4.InnerHtml += " : " + ts.Hours + "h";
        }
        else if (ts.Minutes > 0 && ts.Hours == 0)
        {
            hls4.InnerHtml += " : " + ts.Minutes + "'";
        }
        else if (ts.Minutes == 0 && ts.Seconds > 0)
        {
            hls4.InnerHtml += " : " + ts.Seconds + "''";
        }

        if (p.Values > 0)
        {
            if (p.CurrencyId == 1)
            {
                hls6.InnerHtml = Changes2(p.Values);
                hls7.InnerHtml = altt((float)(p.Values / GUHLS.SJC)) + " lượng";
                hls8.InnerHtml = altt((float)(p.Values / GUHLS.USD)) + " usd";
                vnd.Attributes["class"] = "vdt";
                v1.Attributes["class"] = "vss";
            }
            else if (p.CurrencyId == 2)
            {
                float v = (float)(GUHLS.USD * p.Values);
                hls6.InnerHtml = Changes2(v);
                hls7.InnerHtml = altt((float)(v / GUHLS.SJC)) + " lượng";
                hls8.InnerHtml = altt(p.Values) + " usd";
                usd.Attributes["class"] = "vdt";
                u1.Attributes["class"] = "vss";
            }
            else
            {
                float s = (float)(GUHLS.SJC * p.Values);
                hls6.InnerHtml = Changes2(s);
                hls7.InnerHtml = altt(p.Values) + " lượng";
                hls8.InnerHtml = altt((float)(s / GUHLS.USD)) + " usd";
                sjc.Attributes["class"] = "vdt";
                s1.Attributes["class"] = "vss";
            }

            if (p.UnitId == 2)
            {
                hls6.InnerHtml += "/m2";
                hls7.InnerHtml += "/m2";
                hls8.InnerHtml += "/m2";
            }
            else if (p.UnitId == 3)
            {
                hls6.InnerHtml += "/tháng";
                hls7.InnerHtml += "/tháng";
                hls8.InnerHtml += "/tháng";
            }
        }
        else
        {
            hls6.InnerHtml = "Thoả thuận";
            hls7.InnerHtml = "Thoả thuận";
            hls8.InnerHtml = "Thoả thuận";
            vnd.Attributes["class"] = "vdt";
            v1.Attributes["class"] = "vss";
        }

        EProperties pro = new EProperties(id);
        pro = BProperties.pro(pro);
        if (pro.SittingRoom != 0) stt.InnerHtml = pro.SittingRoom.ToString();
        if (pro.BedRoom != 0) bed.InnerHtml = pro.BedRoom.ToString();
        if (pro.BathRoom != 0) bat.InnerHtml = pro.BathRoom.ToString();
        if (pro.Other != 0) oth.InnerHtml = pro.Other.ToString();

        wi.InnerHtml = p.Width + " m x " + p.Length + " m";
        are.InnerHtml = p.Area + " m";

        cname.InnerHtml = p.ContactName;
        if (p.Tel != "")
        {
            cph.InnerHtml = EncryptM.ToOutput(p.Tel);
            iphonew.Visible = true;
        }
        else iphonew.Visible = false;
        if (p.Mobile != "")
        {
            cmb.InnerHtml = EncryptM.ToOutput(p.Mobile);
            imobilew.Visible = true;
        }
        else imobilew.Visible = false;
        if (p.Address != "")
        {
            ca.InnerHtml = p.Address;
            iaddw.Visible = true;
        }
        else iaddw.Visible = false;
        if (p.Notes != "")
        {
            cnt.InnerHtml = p.Notes;
            inotew.Visible = true;
        }
        else inotew.Visible = false;

        hls9.InnerHtml = p.Description;
        are2.InnerHtml = p.Area.ToString();
        wi2.InnerHtml = p.Width;
        le2.InnerHtml = p.Length;

        hls10.InnerHtml = p.ClassName;
        hls11.InnerHtml = pro.DocName;
        hls12.InnerHtml = pro.SetName;
        if (pro.SetName != "" && pro.SetName != null) ly.Append(" » <a class=\"agr\" href=\"default.aspx?st=" + pro.SetId + "\"> Hướng " + pro.SetName + "</a>");
        if (pro.SizeOfLane > 0) hls13.InnerHtml = pro.SizeOfLane.ToString();
        else hls13.InnerHtml = "_";
        hls14.InnerHtml = p.LocaName;

        if (pro.Floor > 0) hls15.InnerHtml = pro.Floor.ToString();
        else hls15.InnerHtml = "_";
        if (pro.SittingRoom > 0) hls16.InnerHtml = pro.SittingRoom.ToString();
        else hls16.InnerHtml = "_";
        if (pro.BedRoom> 0) hls17.InnerHtml = pro.BedRoom.ToString();
        else hls17.InnerHtml = "_";
        if (pro.BathRoom > 0) hls18.InnerHtml = pro.BathRoom.ToString();
        else hls18.InnerHtml = "_";
        if (pro.Other > 0) hls19.InnerHtml = pro.Other.ToString();
        else hls19.InnerHtml = "_";

        List<EUtilities> eu = new List<EUtilities>();
        pro.PostId = id;
        eu = BUtilities.utis(pro);
        foreach (EUtilities j in eu)
        {
            if (j.UtilityId ==1)
            {
                hls20.Visible = true;
            }
            else if (j.UtilityId == 2)
            {
                hls21.Visible = true;
            }
            else if (j.UtilityId == 3)
            {
                hls22.Visible = true;
            }
            else if (j.UtilityId == 4)
            {
                hls23.Visible = true;
            }
            else if (j.UtilityId == 5)
            {
                hls24.Visible = true;
            }
            else if (j.UtilityId == 6)
            {
                hls25.Visible = true;
            }
            else if (j.UtilityId == 7)
            {
                hls26.Visible = true;
            }
            else if (j.UtilityId == 8)
            {
                hls27.Visible = true;
            }
            else if (j.UtilityId == 9)
            {
                hls28.Visible = true;
            }
        }

        int iw = p.MemberId;//BMember.ReturnId(lk());
        EProfile pfw = BMember.Details(iw);
        if (pfw.Logo != null && pfw.Logo != "") iwnlg.Src = "~/avas/" + pfw.Logo;
        hls29.InnerHtml = "<a class=\"rads3\" href=\"default.aspx?m=" + iw + "\">" + pfw.FullName + "</a>";// p.UserName;
        hls30.InnerHtml = pfw.Company;
        hlsadr.InnerHtml = pfw.Address;
        hls31.InnerHtml = EncryptM.ToOutput(pfw.Tel) + " - " + EncryptM.ToOutput(pfw.Mobile);
        stay.InnerHtml += ly.ToString();
    }

    private string altt(float a)
    {
        if (a > 1) return String.Format("{0:0,0.##}", a);
        else return String.Format("{0:0.##}", a);
    }

    //private string Changes2(int val)
    //{
    //    int mi = (int)(val / 1000000000);
    //    int bi = (int)((val % 1000000000) / 1000000);
    //    int th = (int)(((val % 1000000000) % 1000000) / 1000);
    //    int sp = (int)(((val % 1000000000) % 1000000) % 1000);
    //    string sVals = "";
    //    if (mi > 0)
    //    {
    //        sVals = mi + " tỷ";
    //    }
    //    if (bi > 0)
    //    {
    //        sVals = sVals + " " + bi + " triệu";
    //    }
    //    if (th > 0 && mi <= 0)
    //    {
    //        sVals = sVals + " " + th + " ngàn";
    //    }
    //    return sVals;
    //}

    private string Changes2(float val)
    {
        int mi = (int)(val / 1000000000);
        int bi = (int)((val % 1000000000) / 1000000);
        int th = (int)(((val % 1000000000) % 1000000) / 1000);
        int sp = (int)(((val % 1000000000) % 1000000) % 1000);
        string sVals = "";
        if (mi > 0)
        {
            sVals = mi + " tỷ";
        }
        if (bi > 0)
        {
            sVals = sVals + " " + bi + " triệu";
        }
        if (th > 0 && mi <= 0)
        {
            sVals = sVals + " " + th + " ngàn";
        }
        return sVals;
    }
    protected void pn_Click(object sender, EventArgs e)
    {
        Saved();
    }
    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
    }
    protected void btnpm_Click(object sender, EventArgs e)
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "" && titlepm.Value != "" && msgpm.Value != "")
        {
            EPms pm = new EPms();
            EMember c = new EMember();
            c.UserName = lk();
            pm.ToMemberId = int.Parse(Request.Params["p"].ToString());
            pm.Title = rplc(titlepm.Value.ToString());
            pm.Message = rplc(msgpm.Value.ToString());
            BPms.PMS_Insert2(pm, c);
            titlepm.Value = "";
            msgpm.Value = "";
            respm.Text = "Tin nhắn đã gửi thành công.";
        }
        else respm.Text = "Thông tin chưa đầy đủ.";
    }
    protected void btnem_Click(object sender, EventArgs e)
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "" && titleem.Value != "" && msgem.Value != "")
        {
            EEmails pm = new EEmails();
            EMember c = new EMember();
            c.UserName = lk();
            pm.ToMember = int.Parse(Request.Params["p"].ToString());
            pm.Title = rplc(titleem.Value.ToString());
            pm.Message = rplc(msgem.Value.ToString());
            BEmails.Emails_Insert2(pm, c);
            EProfile pf = BMember.Details(BMember.ReturnId(lk()));
            EProfile pt = BMember.Details(BPosts.APstR(int.Parse(Request.Params["p"].ToString())));
            StreamReader sr = new StreamReader(Server.MapPath("~/ctrls/mails/lostpass.htm"));
            sr = File.OpenText(Server.MapPath("~/ctrls/mails/lostpass.htm"));
            string content = sr.ReadToEnd();
            content = content.Replace("[Sender]", pf.FullName);
            content = content.Replace("[User]", pt.FullName);
            content = content.Replace("[Title]", pm.Title);
            content = content.Replace("[DateTime]", DateTime.Now.ToString());
            content = content.Replace("[Content]", pm.Message);
            content = content.Replace("[Signature]", "Nha3W.com - Kết nối & Xanh & Hiện đại");
            SendMail.clies(HungLocSon.UHLS.EncryptM.ToOutput(pt.Email), pm.Title, content);
            //SendMail.Sendmail("Nha3W.com - Kết nối & Xanh & Hiện đại", HungLocSon.UHLS.EncryptM.ToOutput(pt.Email), pm.Title, content, true, true);
            titleem.Value = "";
            msgem.Value = "";
            resem.Text = "Email đã gửi thành công.";
        }
        else resem.Text = "Thông tin chưa đầy đủ.";
    }

    protected void btnvio_Click(object sender, EventArgs e)
    {
        if (Request.Params["p"] != null && Request.Params["p"].ToString() != "" && msgvio.Value != "")
        {
            EViolations pm = new EViolations();
            EMember c = new EMember();
            c.UserName = lk();
            pm.PostId = int.Parse(Request.Params["p"].ToString());
            pm.Message = rplc(msgvio.Value.ToString());
            pm.IP = HttpContext.Current.Request.UserHostAddress;
            BViolations.IVios(pm, c);
            msgvio.Value = "";
            resvio.Text = "Thông báo của bạn đã gửi thành công. Xin cảm ơn!";
        }
        else resvio.Text = "Thông tin chưa đầy đủ.";
    }

    protected void ps_Click(object sender, EventArgs e)
    {
        Called();
    }
}
