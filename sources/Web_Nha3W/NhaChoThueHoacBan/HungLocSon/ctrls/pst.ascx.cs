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
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using HungLocSon.UHLS;

public partial class ctrls_pst : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["v"] == null || (Request.Params["m"] != null && Request.Params["m"].ToString() != "" 
            && Request.Params["v"] != null && Request.Params["v"].ToString() == "psts"))
        {
            signu.Attributes.Add("onclick", "find();");
            n3w4.Attributes.Add("onchange", "find();");
            n3w6.Attributes.Add("onchange", "find();");
            if (!IsPostBack)
            {
                if (Request.Params["v"] != null && Request.Params["v"].ToString() == "psts")
                {
                    stay.Visible = false;
                    n3wa.Visible = false;
                    iwllps.Visible = true;
                }
                EPager page = new EPager();
                if (Request.Params["sz"] != null && Request.Params["sz"].ToString() != "") page.PageSize = int.Parse(Request.Params["sz"].ToString());
                else page.PageSize = GUHLS.Size;
                Nwsr();
                bool fl = false;
                if (Request.Params["g"] == null)
                {
                    page.CurrentPage = 1;
                    if (Request.QueryString.Count == 0)
                    {
                        Posts2(page);
                        istar(true);
                        return;
                    }
                }
                else
                {
                    page.CurrentPage = int.Parse(Request.Params["g"].ToString());
                    if (Request.QueryString.Count == 1)
                    {
                        istar(true);
                        //fl = true;
                        if (page.CurrentPage == 1) Posts2(page);
                        else Posts(page);
                        return;
                    }
                }
                string urls = "";
                urls = "&sz=" + page.PageSize;
                if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    urls += "&c=" + c.CategoryId;
                    Posts(page, c, urls);
                }
                else if (Request.Params["c"] != null && Request.Params["y"] != null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    ECities y = new ECities(int.Parse(Request.Params["y"].ToString()));
                    urls += "&c=" + c.CategoryId + "&y=" + y.CityId;
                    Posts(page, c, y, urls);
                }
                else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    EDistricts d = new EDistricts(int.Parse(Request.Params["d"].ToString()));
                    urls += "&c=" + c.CategoryId + "&d=" + d.DistrictId;
                    Posts(page, c, d, urls);
                }
                else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] != null && Request.Params["t"] == null && Request.Params["a"] == null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    EDistricts d = new EDistricts(int.Parse(Request.Params["d"].ToString()));
                    EClasses l = new EClasses(int.Parse(Request.Params["l"].ToString()));
                    urls += "&c=" + c.CategoryId + "&d=" + d.DistrictId + "&l=" + l.ClassId;
                    Posts(page, c, d, l, urls);
                }
                else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] != null && Request.Params["a"] == null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    EDistricts d = new EDistricts(int.Parse(Request.Params["d"].ToString()));
                    EStreets t = new EStreets(int.Parse(Request.Params["t"].ToString()));
                    urls += "&c=" + c.CategoryId + "&d=" + d.DistrictId + "&t=" + t.StreetId;
                    Posts(page, c, d, t, urls);
                }
                else if (Request.Params["c"] != null && Request.Params["y"] == null && Request.Params["d"] != null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] != null)
                {
                    ECategories c = new ECategories(int.Parse(Request.Params["c"].ToString()));
                    EDistricts d = new EDistricts(int.Parse(Request.Params["d"].ToString()));
                    EWards a = new EWards(int.Parse(Request.Params["a"].ToString()));
                    urls += "&c=" + c.CategoryId + "&d=" + d.DistrictId + "&a=" + a.WardId;
                    Posts(page, c, d, a, urls);
                }
                else if (Request.Params["m"] != null && Request.Params["c"] == null && Request.Params["y"] == null && Request.Params["d"] == null && Request.Params["l"] == null && Request.Params["t"] == null && Request.Params["a"] == null)
                {
                    EMember m = new EMember(int.Parse(Request.Params["m"].ToString()));
                    urls += "&m=" + m.MemberId;
                    Posts(page, m, urls);
                    EProfile p = new EProfile();
                    p = BMember.PMemberI(m);
                    istar(true);
                    StringBuilder ly = new StringBuilder(100);
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?m=" + m.MemberId + "\">" + "Thành viên: " + p.FullName + "</a>");
                    stay.InnerHtml += ly.ToString();
                    return;
                }
                else
                {
                    Ifl2(page);
                    fl = true;
                }
                if (!fl) naly();
            }
        }
    }

    private void istar(bool fl)
    {
        StringBuilder ly = new StringBuilder(200);
        if (fl) ly.Append("&nbsp;&nbsp;<a class=\"agr1\" href=\"default.aspx\">N3W</a><a title=\"Mở rộng tìm kiếm\" onclick=\"javascript:shw1();\" href=\"#\" class=\"asr\" id=\"sta2\">[+]</a><a title=\"Đóng tìm kiếm\" onclick=\"javascript:shw();\" href=\"#\" class=\"asrh\" id=\"sta1\">[--]</a>");
        else ly.Append("&nbsp;&nbsp;<a class=\"agr1\" href=\"default.aspx\">N3W</a><a title=\"Mở rộng tìm kiếm\" onclick=\"javascript:shw1();\" href=\"#\" class=\"asrh\" id=\"sta2\">[+]</a><a title=\"Đóng tìm kiếm\" onclick=\"javascript:shw();\" href=\"#\" class=\"asr\" id=\"sta1\">[--]</a>");
        stay.InnerHtml = ly.ToString();
    }

    private void Ifl2(EPager pg)
    {
        istar(false);
        StringBuilder ly = new StringBuilder(1000);
        EAnas naly = new EAnas();
        string urls = "";
        if (Request.Params["c"] != null)
        {
            naly.CT = int.Parse(Request.Params["c"].ToString());
            List<ECategories> c = new List<ECategories>();
            c = BCategories.Categories();
            foreach(ECategories i in c)
                if (i.CategoryId == naly.CT)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + naly.CT + "\">" + i.CateName + "</a>");
                    urls = "&c=" + naly.CT;
                    break;
                }
        }
        if (Request.Params["l"] != null)
        {
            naly.CL = int.Parse(Request.Params["l"].ToString());
            List<EClasses> l = new List<EClasses>();
            l = BClasses.Classes();
            foreach (EClasses i in l)
                if (i.ClassId == naly.CL)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?l=" + naly.CL + "\">" + i.ClassName + "</a>");
                    urls += "&l=" + naly.CL;
                    break;
                }
        }

        if (Request.Params["fa"] != null && Request.Params["ta"] == null)
        {
            naly.FA = int.Parse(Request.Params["fa"].ToString());
            naly.TA = 0;
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fa=" + naly.FA + "\">" + naly.FA + " - ~ m2</a>");
            urls += "&fa=" + naly.FA;
        }
        if (Request.Params["ta"] != null && Request.Params["fa"] == null)
        {
            naly.TA = int.Parse(Request.Params["ta"].ToString());
            naly.FA = 0;
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?ta=" + naly.TA + "\">0 - " + naly.TA + " m2</a>");
            urls += "&ta=" + naly.TA;
        }
        else if (Request.Params["ta"] != null && Request.Params["fa"] != null)
        {
            naly.FA = int.Parse(Request.Params["fa"].ToString());
            naly.TA = int.Parse(Request.Params["ta"].ToString());
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fa=" + naly.FA + "&ta=" + naly.TA + "\">" + naly.FA + " - " + naly.TA + " m2</a>");
            urls += "&fa=" + naly.FA + "&ta=" + naly.TA;
        }

        if (Request.Params["fv"] != null && Request.Params["tv"] != null)
        {
            naly.FV = long.Parse(Request.Params["fv"].ToString());
            naly.TV = long.Parse(Request.Params["tv"].ToString());
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fv=" + naly.FV + "&tv=" + naly.TV + "\">" + naly.FV + " - " + naly.TV + "</a>");
            urls += "&fv=" + naly.FV + "&tv=" + naly.TV;
        }

        if (Request.Params["pt"] != null)
        {
            naly.PT = int.Parse(Request.Params["pt"].ToString());
            List<EProjects> y = new List<EProjects>();
            EProjects pr = new EProjects();
            pr.DistrictId = -1;
            y = BProjects.Projects(pr);
            foreach (EProjects i in y)
                if (i.ProjectId == naly.PT)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?pt=" + naly.PT + "\">" + i.ProjectName + "</a>");
                    urls += "&pt=" + naly.PT;
                    break;
                }
        }
        if (Request.Params["ltn"] != null)
        {
            naly.LT = int.Parse(Request.Params["ltn"].ToString());
            List<ELocations> lt = new List<ELocations>();
            lt = BLocations.Locations();
            foreach (ELocations i in lt)
                if (i.LocationId == naly.LT)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?ltn=" + naly.LT + "\">" + i.LocaName + "</a>");
                    urls += "&ltn=" + naly.LT;
                    break;
                }
        }

        if (Request.Params["t"] != null)
        {
            naly.SE = int.Parse(Request.Params["t"].ToString());
            List<EStreets> y = new List<EStreets>();
            EStreets t = new EStreets();
            t.DistrictId = -1;
            y = BStreets.Streets(t);
            foreach (EStreets i in y)
                if (i.StreetId == naly.SE)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?t=" + naly.SE + "\">" + i.Name + "</a>");
                    urls += "&t=" + naly.SE;
                    break;
                }
        }
        if (Request.Params["a"] != null)
        {
            naly.WA = int.Parse(Request.Params["a"].ToString());
            List<EWards> y = new List<EWards>();
            EWards w = new EWards();
            w.DistrictId = -1;
            y = BWards.Wards(w);
            foreach (EWards i in y)
                if (i.WardId == naly.WA)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?a=" + naly.WA + "\">" + i.WardName + "</a>");
                    urls += "&a=" + naly.WA;
                    break;
                }
        }
        if (Request.Params["d"] != null)
        {
            naly.DT = int.Parse(Request.Params["d"].ToString());
            List<EDistricts> y = new List<EDistricts>();
            EDistricts t = new EDistricts();
            t.CityId = -1;
            y = BDistricts.Districts(t);
            foreach (EDistricts i in y)
                if (i.DistrictId == naly.DT)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?d=" + naly.DT + "\">" + i.DistrictName + "</a>");
                    urls += "&d=" + naly.DT;
                    break;
                }
        }
        if (Request.Params["y"] != null)
        {
            naly.CY = int.Parse(Request.Params["y"].ToString());
            List<ECities> y = new List<ECities>();
            y = BCities.Cities();
            foreach (ECities i in y)
                if (i.CityId == naly.CY)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?y=" + naly.CY + "\">" + i.CityName + "</a>");
                    urls += "&y=" + naly.CY;
                    break;
                }
        }

        if (Request.Params["on"] != null)
        {
            naly.ON = int.Parse(Request.Params["on"].ToString());
            if (naly.ON == 1) ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Tin Môi giới" + "</a>");
            else if (naly.ON == 2) ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Tin Chính chủ" + "</a>");
            else ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + naly.ON + "\">" + "Môi giới/Chính chủ" + "</a>");
            urls += "&on=" + naly.ON;
        }

        if (Request.Params["st"] != null)
        {
            naly.ST = int.Parse(Request.Params["st"].ToString());
            List<ESets> st = new List<ESets>();
            st = BSets.Sets();
            foreach (ESets i in st)
                if (i.SetId == naly.ST)
                {
                    ly.Append(" » <a class=\"agr\" href=\"default.aspx?st=" + naly.ST + "\">" + i.SetName + "</a>");
                    urls += "&st=" + naly.ST;
                    break;
                }
        }
        urls += "&sz=" + pg.PageSize;
        naly.HI = 3;
        naly.OB = 3;
        naly.AD = true;

        stay.InnerHtml += ly.ToString();

        //EPager page = new EPager();
        //page.PageSize = GUHLS.Size;
        //page.CurrentPage = 1;
        Posts(pg, naly,urls);

        
        //if (n3w1.SelectedValue != "-1" && n3w1.SelectedValue != "0" && n3w1.SelectedValue != "")
        //{
        //    ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + n3w1.SelectedValue + "\">" + n3w1.SelectedItem.Text + "</a>");
        //    naly.CT = int.Parse(n3w1.SelectedValue);
        //}

        //if (n3w2.SelectedValue != "-1" && n3w2.SelectedValue != "0" && n3w2.SelectedValue != "")
        //{
        //    ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + n3w2.SelectedValue + "\">" + n3w2.SelectedItem.Text + "</a>");
        //    naly.CL = int.Parse(n3w2.SelectedValue);
        //}
    }

    private void Ifi(bool ip)
    {
        istar(false);
        StringBuilder ly = new StringBuilder(1000);
        EAnas naly = new EAnas();
        string urls = "";
        if (n3w1.SelectedValue != "-1" && n3w1.SelectedValue != "0" && n3w1.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + n3w1.SelectedValue + "\">" + n3w1.SelectedItem.Text + "</a>");
            naly.CT = int.Parse(n3w1.SelectedValue);
            urls = "&c=" + naly.CT;
        }

        if (n3w2.SelectedValue != "-1" && n3w2.SelectedValue != "0" && n3w2.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?l=" + n3w2.SelectedValue + "\">" + n3w2.SelectedItem.Text + "</a>");
            naly.CL = int.Parse(n3w2.SelectedValue);
            urls += "&l=" + naly.CL;
        }

        if ((fa.Value != "" && fa.Value != "Diện tích từ") && (ta.Value == "" || ta.Value == "đến (m2)"))
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fa=" + fa.Value + "\">" + fa.Value + " - ~ m2</a>");
            naly.FA = int.Parse(fa.Value);
            urls += "&fa=" + naly.FA;
        }
        else if ((fa.Value == "" || fa.Value == "Diện tích từ") && (ta.Value != "" && ta.Value != "đến (m2)"))
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?ta=" + ta.Value + "\">0 - " + ta.Value + " m2</a>");
            naly.TA = int.Parse(ta.Value);
            urls += "&ta=" + naly.TA;
        }
        else if (fa.Value != "" && fa.Value != "Diện tích từ" && ta.Value != "" && ta.Value != "đến (m2)")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fa=" + fa.Value + "&ta=" + ta.Value + "\">" + fa.Value + " - " + ta.Value + " m2</a>");
            naly.FA = int.Parse(fa.Value);
            naly.TA = int.Parse(ta.Value);
            urls += "&fa=" + naly.FA + "&ta=" + naly.TA;
        }
        if (n3w10.Value != "-1" && n3w10.Value != "0" && n3w10.Value != "")
        {
            switch (n3w10.Value)
            {
                case "1":
                    {
                        naly.FV = 0;
                        naly.TV = 2000000;
                        break;
                    }
                case "2":
                    {
                        naly.FV = 2000000;
                        naly.TV = 5000000;
                        break;
                    }
                case "3":
                    {
                        naly.FV = 5000000;
                        naly.TV = 10000000;
                        break;
                    }
                case "4":
                    {
                        naly.FV = 10000000;
                        naly.TV = 20000000;
                        break;
                    }
                case "5":
                    {
                        naly.FV = 20000000;
                        naly.TV = 50000000;
                        break;
                    }
                case "6":
                    {
                        naly.FV = 50000000;
                        naly.TV = 100000000;
                        break;
                    }
                case "7":
                    {
                        naly.FV = 100000000;
                        naly.TV = 250000000;
                        break;
                    }
                case "8":
                    {
                        naly.FV = 250000000;
                        naly.TV = 500000000;
                        break;
                    }
                case "9":
                    {
                        naly.FV = 500000000;
                        naly.TV = 1000000000;
                        break;
                    }
                case "10":
                    {
                        naly.FV = 1000000000;
                        naly.TV = 1500000000;
                        break;
                    }
                case "11":
                    {
                        naly.FV = 1500000000;
                        naly.TV = 2000000000;
                        break;
                    }
                case "12":
                    {
                        naly.FV = 2000000000;
                        naly.TV = 3000000000;
                        break;
                    }
                case "13":
                    {
                        naly.FV = 3000000000;
                        naly.TV = 5000000000;
                        break;
                    }
                case "14":
                    {
                        naly.FV = 5000000000;
                        naly.TV = 10000000000;
                        break;
                    }
                case "15":
                    {
                        naly.FV = 10000000000;
                        naly.TV = 0;
                        break;
                    }
            }
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?fv=" + naly.FV + "&tv=" + naly.TV + "\">" + n3w10.Items[n3w10.SelectedIndex].Text + "</a>");
            urls += "&fv=" + naly.FV + "&tv=" + naly.TV;
        }

        if (n3w9.SelectedValue != "-1" && n3w9.SelectedValue != "0" && n3w9.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?pt=" + n3w9.SelectedValue + "\">" + n3w9.SelectedItem.Text + "</a>");
            naly.PT = int.Parse(n3w9.SelectedValue);
            urls += "&pt=" + naly.PT;
        }
        if (n3w3.SelectedValue != "-1" && n3w3.SelectedValue != "0" && n3w3.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?ltn=" + n3w3.SelectedValue + "\">" + n3w3.SelectedItem.Text + "</a>");
            naly.LT = int.Parse(n3w3.SelectedValue);
            urls += "&ltn=" + naly.LT;
        }

        if (n3w8.SelectedValue != "-1" && n3w8.SelectedValue != "0" && n3w8.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?t=" + n3w8.SelectedValue + "\">" + n3w8.SelectedItem.Text + "</a>");
            naly.SE = int.Parse(n3w8.SelectedValue);
            urls += "&t=" + naly.SE;
        }
        if (n3w7.SelectedValue != "-1" && n3w7.SelectedValue != "0" && n3w7.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?a=" + n3w7.SelectedValue + "\">" + n3w7.SelectedItem.Text + "</a>");
            naly.WA = int.Parse(n3w7.SelectedValue);
            urls += "&a=" + naly.WA;
        }
        if (n3w6.SelectedValue != "-1" && n3w6.SelectedValue != "0" && n3w6.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?d=" + n3w6.SelectedValue + "\">" + n3w6.SelectedItem.Text + "</a>");
            naly.DT = int.Parse(n3w6.SelectedValue);
            urls += "&d=" + naly.DT;
        }
        if (n3w4.SelectedValue != "-1" && n3w4.SelectedValue != "0" && n3w4.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?y=" + n3w4.SelectedValue + "\">" + n3w4.SelectedItem.Text + "</a>");
            naly.CY = int.Parse(n3w4.SelectedValue);
            urls += "&y=" + naly.CY;
        }

        if (n3w5.Value != "-1" && n3w5.Value != "0" && n3w5.Value != "")
        {
            if (n3w5.Value == "2") naly.ON = 2;
            else naly.ON = 1;
        }
        else naly.ON = -1;
        ly.Append(" » <a class=\"agr\" href=\"default.aspx?on=" + n3w5.Value + "\">" + n3w5.Items[n3w5.SelectedIndex].Text + "</a>");
        urls += "&on=" + naly.ON;
        if (n3w11.SelectedValue != "-1" && n3w11.SelectedValue != "0" && n3w11.SelectedValue != "")
        {
            ly.Append(" » <a class=\"agr\" href=\"default.aspx?st=" + n3w11.SelectedValue + "\">" + n3w11.SelectedItem.Text + "</a>");
            naly.ST = int.Parse(n3w11.SelectedValue);
            urls += "&st=" + naly.ST;
        }

        if (keepps.Value != "-1" && keepps.Value != "0" && keepps.Value != "")
        {
            if (keepps.Value == "1") ly.Append(" » Có hình");
            else ly.Append(" » Không hình");
            naly.HI = int.Parse(keepps.Value);
        }
        else
            naly.HI = 3;

        if (n3w12.Value != "-1" && n3w12.Value != "0" && n3w12.Value != "")
        {
            ly.Append(" » " + n3w12.Items[n3w12.SelectedIndex].Text + " - " + n3w13.Items[n3w13.SelectedIndex].Text);
            naly.OB = int.Parse(n3w12.Value);
        }
        else naly.OB = 3;
        if (n3w13.Value == "1")
            naly.AD = true;
        else
            naly.AD = false;

        naly.UR = lk();
        naly.IP = HttpContext.Current.Request.UserHostAddress;
        naly.SD = HttpContext.Current.Session.SessionID;
        BAnas.IAnas(naly);
        
        stay.InnerHtml += ly.ToString();

        if (ip)
        {
            EPager page = new EPager();
            if (n9wi.Value.ToString() == "-1" || n9wi.Value.ToString() == "0") page.PageSize = GUHLS.Size;
            else page.PageSize = int.Parse(n9wi.Value.ToString());
            if (Request.Params["g"] != null) page.CurrentPage = int.Parse(Request.Params["g"].ToString());
            else page.CurrentPage = 1;
            urls += "&sz=" + page.PageSize;
            Posts(page, naly,urls);
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

    private void Nwsr()
    {
        int i = -1;
        int j = 0;
        List<ECategories> c = new List<ECategories>();
        c = BCategories.Categories();
        while (c.Count > 0 && j <c.Count)
        {
            if (i==-1)
            {
                n3w1.Items.Add("Loại tin đăng");
                n3w1.Items[i+1].Value = "-1";
                i++;
                n3w1.Items.Add("-------------");
                n3w1.Items[i+1].Value = "0";
                i+=2;
            }
            n3w1.Items.Add(c[j].CateName);
            n3w1.Items[i].Value = c[j].CategoryId.ToString();
            i++;
            j++;
        }

        List<EClasses> l = new List<EClasses>();
        l = BClasses.Classes();
        i = -1;
        j = 0;
        while (l.Count > 0 && j < l.Count)
        {
            if (i == -1)
            {
                n3w2.Items.Add("Danh mục địa ốc");
                n3w2.Items[i+1].Value = "-1";
                i++;
                n3w2.Items.Add("---------------");
                n3w2.Items[i+1].Value = "0";
                i+=2;
            }
            n3w2.Items.Add(l[j].ClassName);
            n3w2.Items[i].Value = l[j].ClassId.ToString();
            i++;
            j++;
        }

        List<ELocations> lt = new List<ELocations>();
        lt = BLocations.Locations();
        i = -1;
        j = 0;
        while (lt.Count > 0 && j < lt.Count)
        {
            if (i == -1)
            {
                n3w3.Items.Add("Vị trí địa ốc");
                n3w3.Items[i + 1].Value = "-1";
                i++;
                n3w3.Items.Add("---------------");
                n3w3.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w3.Items.Add(lt[j].LocaName);
            n3w3.Items[i].Value = lt[j].LocationId.ToString();
            i++;
            j++;
        }

        List<ECities> y = new List<ECities>();
        y = BCities.Cities();
        i = -1;
        j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w4.Items.Add("Tỉnh/Thành phố");
                n3w4.Items[i + 1].Value = "-1";
                i++;
                n3w4.Items.Add("---------------");
                n3w4.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w4.Items.Add(y[j].CityName);
            n3w4.Items[i].Value = y[j].CityId.ToString();
            i++;
            j++;
        }

        List<ESets> st = new List<ESets>();
        st = BSets.Sets();
        i = -1;
        j = 0;
        while (st.Count > 0 && j < st.Count)
        {
            if (i == -1)
            {
                n3w11.Items.Add("Hướng");
                n3w11.Items[i + 1].Value = "-1";
                i++;
                n3w11.Items.Add("---------------");
                n3w11.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w11.Items.Add(st[j].SetName);
            n3w11.Items[i].Value = st[j].SetId.ToString();
            i++;
            j++;
        }
    }

    private void Districts(EDistricts d)
    {
        List<EDistricts> y = new List<EDistricts>();
        y = BDistricts.Districts(d);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w6.Items.Add("Quận/Huyện");
                n3w6.Items[i + 1].Value = "-1";
                i++;
                n3w6.Items.Add("-----------");
                n3w6.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w6.Items.Add(y[j].DistrictName);
            n3w6.Items[i].Value = y[j].DistrictId.ToString();
            i++;
            j++;
        }
    }

    private void Wards(EWards w)
    {
        List<EWards> y = new List<EWards>();
        y = BWards.Wards(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w7.Items.Add("Phường/Xã");
                n3w7.Items[i + 1].Value = "-1";
                i++;
                n3w7.Items.Add("-----------");
                n3w7.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w7.Items.Add(y[j].WardName);
            n3w7.Items[i].Value = y[j].WardId.ToString();
            i++;
            j++;
        }
    }

    private void Streets(EStreets w)
    {
        List<EStreets> y = new List<EStreets>();
        if (w.DistrictId >0) y = BStreets.Streets(w);
        else if (w.WardId >0) y = BStreets.Streets2(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w8.Items.Add("Tên đường");
                n3w8.Items[i + 1].Value = "-1";
                i++;
                n3w8.Items.Add("-----------");
                n3w8.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w8.Items.Add(y[j].Name);
            n3w8.Items[i].Value = y[j].StreetId.ToString();
            i++;
            j++;
        }
    }

    private void Projects(EProjects w)
    {
        List<EProjects> y = new List<EProjects>();
        y = BProjects.Projects(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w9.Items.Add("Dự án địa ốc");
                n3w9.Items[i + 1].Value = "-1";
                i++;
                n3w9.Items.Add("-----------");
                n3w9.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w9.Items.Add(y[j].ProjectName);
            n3w9.Items[i].Value = y[j].ProjectId.ToString();
            i++;
            j++;
        }
    }

    private void naly()
    {
        EAnas an = new EAnas();
        an.SD = HttpContext.Current.Session.SessionID;
        an = BAnas.IAnas2(an);
        StringBuilder ly = new StringBuilder(1000);
        istar(true);
        if (an.CTN != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + an.CT + "\">" + an.CTN + "</a>");
        if (an.CLN != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?l=" + an.CL + "\">" + an.CLN + "</a>");
        if (an.SEA != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?t=" + an.SE + "\">" + an.SEA + "</a>");
        if (an.WAN != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?a=" + an.WA + "\">" + an.WAN + "</a>");
        if (an.DTN != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?d=" + an.DT + "\">" + an.DTN + "</a>");
        if (an.CYN != "") ly.Append(" » <a class=\"agr\" href=\"default.aspx?y=" + an.CY + "\">" + an.CYN + "</a>");
        stay.InnerHtml += ly.ToString();
    }

    private void Posts(EPager page)
    {
        rptPsts.DataSource = BPosts.Lists(page);
        rptPsts.DataBind();
        page.Rows = BPosts.Total();
        Pager(page,"");
    }

    private void Posts2(EPager page)
    {
        rptPsts.DataSource = BPosts.LstPosts(page);
        rptPsts.DataBind();
        page.Rows = BPosts.Total();
        Pager(page, "");
    }

    private void Posts(EPager page, ECategories c,string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c);
        Pager(page,r);
    }

    private void Posts(EPager page, EMember c, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c);
        Pager(page, r);
    }

    private void Posts(EPager page, EAnas c, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, GUHLS.SJC, GUHLS.USD);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, GUHLS.SJC, GUHLS.USD);
        Pager(page, r);
    }

    private void Posts(EPager page, ECategories c, ECities y, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, y);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, y);
        Pager(page, r);
    }

    private void Posts(EPager page, ECategories c, EDistricts d, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, d);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, d);
        Pager(page, r);
    }

    private void Posts(EPager page, ECategories c, EDistricts d, EClasses l, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, d, l);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, d, l);
        Pager(page, r);
    }

    private void Posts(EPager page, ECategories c, EDistricts d, EStreets t, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, d, t);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, d, t);
        Pager(page, r);
    }

    private void Posts(EPager page, ECategories c, EDistricts d, EWards a, string r)
    {
        rptPsts.DataSource = BPosts.Lists(page, c, d, a);
        rptPsts.DataBind();
        page.Rows = BPosts.Total(c, d, a);
        Pager(page, r);
    }

    protected void Pager(EPager page,string urls)
    {
        if (page.Total <= 1)
        {
            pg.Visible = false;
            return;
        }
        else pg.Visible = true;
        StringBuilder sb = new StringBuilder();
        int FirstPage = 1, LastPage;
        if (page.CurrentPage > 6) FirstPage = page.CurrentPage - 6;
        if (page.CurrentPage + 6 <= page.Total) LastPage = page.CurrentPage + 6;
        else LastPage = page.Total;
        //Add 1st page
        //sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=1'>&lt;&lt;</a>&nbsp;&nbsp;");

        sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=1" + urls.Trim() + "'>&lt;&lt;</a>&nbsp;&nbsp;");


        for (int i = FirstPage; i <= LastPage; i++)
        {
            sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=" + i.ToString() + urls.Trim() + "'>" +
                (page.CurrentPage == i ? "[" : "") + i.ToString() + (page.CurrentPage == i ? "]" : "") + "</a>&nbsp;");

            //sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=" + i.ToString() + "'>" +
            //    (page.CurrentPage == i ? "[" : "") + i.ToString() + (page.CurrentPage == i ? "]" : "") + "</a>&nbsp;");
        }
        //Add Last page
        sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=" + page.Total.ToString() + urls.Trim() + "'>&gt;&gt;</a>");

        //sb.Append("&nbsp;<a class=\"ListPage\" href='default.aspx?g=" + page.Total.ToString() + "'>&gt;&gt;</a>");
        pg.Text = "Trang: " + page.CurrentPage + "/" + page.Total + " " + sb.ToString() + "&nbsp;&nbsp;" + page.Rows + " : Kết quả";
    }

    protected void rptPsts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int cid = (int)(((EPosts)e.Item.DataItem).CategoryId);
            HtmlGenericControl catn = new HtmlGenericControl();
            catn = (HtmlGenericControl)e.Item.FindControl("cate");
            if (cid == 1)
            {
                catn.Attributes["class"] = "plc";
            }
            else if (cid == 2)
            {
                catn.Attributes["class"] = "plc_ct";
            }
            else if (cid == 3)
            {
                catn.Attributes["class"] = "plc_cm";
            }
            else if (cid == 4)
            {
                catn.Attributes["class"] = "plc_ct2";
            }
            else if (cid == 5)
            {
                catn.Attributes["class"] = "plc_cn";
            }
            bool bvip = (bool)(((EPosts)e.Item.DataItem).IsVip);
            HtmlImage v = new HtmlImage();
            v = (HtmlImage)e.Item.FindControl("vip");
            if (bvip)
            {
                v.Visible = true;
                v.Src = "~/images/diamond6.png";
                HtmlGenericControl bgpst1n = new HtmlGenericControl();
                bgpst1n = (HtmlGenericControl)e.Item.FindControl("bgpst1");
                bgpst1n.Attributes["class"] = "pstvp1";
            }
            else if ((bool)(((EPosts)e.Item.DataItem).Silver) && !bvip)
            {
                v.Visible = true;
                v.Src = "~/images/diamond2.png";
                HtmlGenericControl bgpst2n = new HtmlGenericControl();
                bgpst2n = (HtmlGenericControl)e.Item.FindControl("bgpst1");
                bgpst2n.Attributes["class"] = "pstvp2";
            }
            bool bimg = (bool)(((EPosts)e.Item.DataItem).HaveHouses);
            HtmlImage c = new HtmlImage();
            c = (HtmlImage)e.Item.FindControl("ca");
            if (bimg)
            {
                c.Visible = true;
                c.Src = "~/images/camera2.jpeg";
            }
            bool bw = (bool)(((EPosts)e.Item.DataItem).IsOwner);
            HtmlGenericControl owner = new HtmlGenericControl();
            owner = (HtmlGenericControl)e.Item.FindControl("owner");
            if (bw)
            {
                owner.InnerHtml = "C.C";
            }
            else
            {
                owner.InnerHtml = "M.G";
            }
            HtmlGenericControl ago = new HtmlGenericControl();
            ago = (HtmlGenericControl)e.Item.FindControl("ago");
            DateTime ag = (DateTime)(((EPosts)e.Item.DataItem).Updated);
            TimeSpan ts = DateTime.Now - ag;

            DateTime crn = (DateTime)(((EPosts)e.Item.DataItem).CreationDate);
            TimeSpan crt = DateTime.Now - crn;
            if (crt.Days <1)
            {
                if (crt.Hours <= 21 || crt.Minutes > 0 || crt.Seconds > 0)
                {
                    HtmlImage iw = new HtmlImage();
                    iw = (HtmlImage)e.Item.FindControl("inw");
                    iw.Src = "../images/inw.jpg";
                    iw.Visible = true;
                }
            }

            if (ts.Days > 0 && ts.Days <= 7)
            {
                ago.InnerHtml = ": " + ts.Days + " ngày";
            }
            else if (ts.Days == 0 && ts.Hours > 0)
            {
                ago.InnerHtml = ": " + ts.Hours + "h";
            }
            else if (ts.Days == 0 && ts.Minutes > 0 && ts.Hours == 0)
            {
                ago.InnerHtml = ": " + ts.Minutes + "'";
            }
            else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds > 0)
            {
                ago.InnerHtml = ": " + ts.Seconds + "''";
            }
            
            string w = (string)(((EPosts)e.Item.DataItem).Width);
            string l = (string)(((EPosts)e.Item.DataItem).Length);
            HtmlGenericControl aren = new HtmlGenericControl();
            aren = (HtmlGenericControl)e.Item.FindControl("are");
            if (w != "" && l != "")
            {
                aren.InnerText = w + " x " + l + " m";
            }
            else
            {
                float a = (float)(((EPosts)e.Item.DataItem).Area);
                aren.InnerText = a + " m2";
            }
            string sVals = "";
            string sAlt = "";
            float val = (float)(((EPosts)e.Item.DataItem).Values);
            float ialt=0;
            float ialt1 = 0;
            int cur = (int)(((EPosts)e.Item.DataItem).CurrencyId);
            HtmlAnchor hval = new HtmlAnchor();
            hval = (HtmlAnchor)e.Item.FindControl("vals");
            hval.HRef = "";
            HtmlAnchor hvalu = new HtmlAnchor();
            hvalu = (HtmlAnchor)e.Item.FindControl("valsu");
            hvalu.HRef = "";
            HtmlAnchor hvals = new HtmlAnchor();
            hvals = (HtmlAnchor)e.Item.FindControl("valss");
            hvals.HRef = "";
            HtmlAnchor hvalv = new HtmlAnchor();
            hvalv = (HtmlAnchor)e.Item.FindControl("valsv");
            hvalv.HRef = "";

            HtmlGenericControl v1 = new HtmlGenericControl();
            v1 = (HtmlGenericControl)e.Item.FindControl("v1");
            HtmlGenericControl v2 = new HtmlGenericControl();
            v2 = (HtmlGenericControl)e.Item.FindControl("v2");
            HtmlGenericControl v3 = new HtmlGenericControl();
            v3 = (HtmlGenericControl)e.Item.FindControl("v3");
            HtmlGenericControl v4 = new HtmlGenericControl();
            v4 = (HtmlGenericControl)e.Item.FindControl("v4");
            hval.Attributes.Add("onclick", "vchanges('" + v1.ClientID + "','" + v2.ClientID + "');");
            hvalu.Attributes.Add("onclick", "vchanges('" + v2.ClientID + "','" + v3.ClientID + "')");
            hvals.Attributes.Add("onclick", "vchanges('" + v3.ClientID + "','" + v4.ClientID + "')");
            hvalv.Attributes.Add("onclick", "vchanges('" + v4.ClientID + "','" + v2.ClientID + "')");
            //hrfMoveTopic1.Attributes.Add("onclick", "javascript:window.open('movetopic.aspx?topicid=" + intTopicId +
            //                        "','calwin','top=308,left=391,width=380,height=164,scrollbars=1')");


            if (val > 0)
            {
                if (cur == 1)
                {
                    //sAlt =  string.Format("{0:0,0}", ialt) + " sjc";
                    //sAlt = string.Format("{0:0.##}", ialt) + " sjc";
                    ialt = (float)(val / GUHLS.SJC);
                    ialt1 = (float)(val / GUHLS.USD);

                    //sAlt = string.Format("{0:0,0.0}", ialt) + " sjc" + " - " + string.Format("{0:0,0.0}", ialt1) + " usd";
                    sAlt = altt(ialt) + " sjc" + " - " + altt(ialt1) + " usd";
                    sVals = Changes(val);

                    hvalu.InnerHtml = "<b>" + altt(ialt1) + "</b> usd";
                    //hvalu.Title = string.Format("{0:0,0.0}", ialt) + " sjc" + " - " + Changes2(val);
                    hvalu.Title = altt(ialt) + " sjc" + " - " + Changes2(val);

                    //hvals.InnerHtml = "<b>" + string.Format("{0:0,0.0}", ialt) + "</b> sjc"; //"<b>" + sAlt + "</b>";
                    hvals.InnerHtml = "<b>" + altt(ialt) + "</b> sjc";
                    hvals.Title = Changes2(val) + " - " + altt(ialt1) + " usd";

                    hvalv.InnerHtml = Changes(val);
                    hvalv.Title = altt(ialt1) + " usd" + " - " + altt(ialt) + " sjc";

                }
                else if (cur == 2)
                {
                    ialt = (float)(GUHLS.USD * val);
                    ialt1 = (float)(ialt / GUHLS.SJC);
                    sAlt = Changes2(ialt) + " - " + altt(ialt1) + " sjc";
                    sVals = "<b>" + altt(val) + "</b> usd";
                    hvalu.InnerHtml = "<b>" + altt(val) + "</b> usd";
                    hvalu.Title = altt(ialt1) + " sjc" + " - " + Changes2(ialt);
                    hvals.InnerHtml = "<b>" + altt(ialt1) + "</b> sjc";
                    hvals.Title = Changes2(ialt) + " - " + altt(val) + " usd";
                    hvalv.InnerHtml = Changes(ialt);
                    hvalv.Title = altt(val) + " usd" + " - " + altt(ialt1) + " sjc";
                }
                else
                {
                    ialt = (float)(GUHLS.SJC * val);
                    ialt1 = (float)(ialt / GUHLS.USD);
                    sAlt = Changes2(ialt) + " - " + altt(ialt1) + " usd";
                    sVals = "<b>" + altt(val) + "</b> sjc";
                    hvalu.InnerHtml = "<b>" + altt(ialt1) + "</b> usd";
                    hvalu.Title = altt(val) + " sjc" + " - " + Changes2(ialt);
                    hvals.InnerHtml = "<b>" + altt(val) + "</b> sjc";
                    hvals.Title = Changes2(ialt) + " - " + altt(ialt1) + " usd";
                    hvalv.InnerHtml = Changes(ialt);
                    hvalv.Title = altt(ialt1) + " usd" + " - " + altt(val) + " sjc";
                }



                int uni = (int)(((EPosts)e.Item.DataItem).UnitId);
                if (uni == 2)
                {
                    sVals = sVals + "/m2";
                    hvalv.InnerHtml += "/m2";
                    hvals.InnerHtml += "/m2";
                    hvalu.InnerHtml += "/m2";
                }
                else if (uni == 3)
                {
                    sVals = sVals + "/tháng";
                    hvalv.InnerHtml += "/tháng";
                    hvals.InnerHtml += "/tháng";
                    hvalu.InnerHtml += "/tháng";
                }
                //if (sp > 0)
                //{
                //    sVals = sVals + " " + sp + " đồng";
                //}
                //if (sVals == "") hval.InnerText = "Thoả thuận";
                //else hval.InnerHtml = sVals;
                hval.InnerHtml = sVals;
                hval.Title = sAlt;
            }
            else hval.InnerText = "Thoả thuận";
        }
    }

    private string altt(float a)
    {
        //return String.Format("{0:0.##}", float.Parse(string.Format("{0:0,0.0}", a)));
        if (a>1) return String.Format("{0:0,0.##}",a);
        else return String.Format("{0:0.##}", a);
    }

    private string Changes(float val)
    {
        int mi = (int)(val / 1000000000);
        int bi = (int)((val % 1000000000) / 1000000);
        int th = (int)(((val % 1000000000) % 1000000) / 1000);
        int sp = (int)(((val % 1000000000) % 1000000) % 1000);
        string sVals = "";
        if (mi > 0)
        {
            sVals = "<b>" + mi + "</b> tỷ";
        }
        if (bi > 0)
        {
            sVals = sVals + " <b>" + bi + "</b> triệu";
        }
        if (th > 0 && mi <= 0)
        {
            sVals = sVals + " <b>" + th + "</b> ngàn";
        }
        return sVals;
    }

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
    protected void n3w4_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w4.SelectedValue);
        if (i > 0)
        {
            EDistricts dt = new EDistricts();
            dt.CityId = i;
            n3w6.Items.Clear();
            Districts(dt);
            n3wa.Attributes.Add("class", "nwsr");
            //istar(false);
            Ifi(false);
        }
    }

    protected void n3w1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w1.SelectedValue);
        if (i > 0)
        {
            n3wa.Attributes.Add("class", "nwsr");
            Ifi(false);
        }
    }

    protected void n3w6_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w6.SelectedValue);
        if (i > 0)
        {
            EWards w = new EWards();
            w.DistrictId = i;
            n3w7.Items.Clear();
            Wards(w);
            EStreets t = new EStreets();
            t.DistrictId = i;
            n3w8.Items.Clear();
            Streets(t);
            EProjects p = new EProjects();
            p.DistrictId = i;
            n3w9.Items.Clear();
            Projects(p);
            Ifi(false);
        }
    }
    protected void n3w7_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w7.SelectedValue);
        if (i > 0)
        {
            EStreets t = new EStreets();
            t.WardId = i;
            n3w8.Items.Clear();
            Streets(t);
            Ifi(false);
        }
    }
    protected void signu_Click(object sender, EventArgs e)
    {
        Ifi(true);
    }
}
