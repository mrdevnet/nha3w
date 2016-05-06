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

public partial class ctrls_mng : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mng(-1, -1);
            cities();
            if (Request.Params["sa"] != null && Request.Params["sa"] != "")
            {
                int i = int.Parse(Request.Params["sa"].ToString());
                switch (i)
                {
                    case 1:
                        {
                            hls1.InnerText = "Đang hiển thị";
                            break;
                        }
                    case 2:
                        {
                            hls1.InnerText = "Đang chờ duyệt";
                            break;
                        }
                    case 4:
                        {
                            hls1.InnerText = "Đang soạn";
                            break;
                        }
                    case 3:
                        {
                            hls1.InnerText = "Chưa hợp lệ";
                            break;
                        }
                    case 5:
                        {
                            hls1.InnerText = "Tin đã lưu";
                            break;
                        }
                }
            }
        }
    }

    private void cities()
    {
        List<ECities> y = new List<ECities>();
        y = BCities.Cities();
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                ddlCities.Items.Add("Tỉnh/Thành phố");
                ddlCities.Items[i + 1].Value = "-1";
                i++;
                ddlCities.Items.Add("---------------");
                ddlCities.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlCities.Items.Add(y[j].CityName);
            ddlCities.Items[i].Value = y[j].CityId.ToString();
            i++;
            j++;
        }
    }

    private void districts(EDistricts d)
    {
        ddlDistricts.Items.Clear();
        List<EDistricts> y = new List<EDistricts>();
        y = BDistricts.Districts(d);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                ddlDistricts.Items.Add("Quận/Huyện");
                ddlDistricts.Items[i + 1].Value = "-1";
                i++;
                ddlDistricts.Items.Add("-----------");
                ddlDistricts.Items[i + 1].Value = "0";
                i += 2;
            }
            ddlDistricts.Items.Add(y[j].DistrictName);
            ddlDistricts.Items[i].Value = y[j].DistrictId.ToString();
            i++;
            j++;
        }
    }

    private void mng(int ct, int dt)
    {
        int i = int.Parse(Request.Params["sa"].ToString());
        if (Request.Params["sa"] != null && Request.Params["sa"] != "" && Request.Params["sa"] != "5")
        {
            if (i == 1)
            {
                gCities.DataSource = BPosts.MngPst(-1, ct, dt, lk());
                gCities.DataBind();
            }
            else
            {
                ddlStaPts.SelectedValue = i.ToString();
                gCities.DataSource = BPosts.MngPst(i, ct, dt, lk());
                gCities.DataBind();
            }
            g3.Visible = false;
        }
        else
        {
            gCities.Visible = false;
            ddlStaPts.Visible = false;
            g3.DataSource = BPosts.MngSvs(ct, dt, lk());
            g3.DataBind();
        }
    }

    private void mng2()
    {
        if (Request.Params["sa"] != null && Request.Params["sa"] != "" && Request.Params["sa"] != "5")
        {
            if (ddlDistricts.SelectedValue == "")
            {
                gCities.DataSource = BPosts.MngPst(int.Parse(ddlStaPts.SelectedValue), int.Parse(ddlCities.SelectedValue), -1, lk());
                gCities.DataBind();
            }
            else
            {
                gCities.DataSource = BPosts.MngPst(int.Parse(ddlStaPts.SelectedValue), int.Parse(ddlCities.SelectedValue), int.Parse(ddlDistricts.SelectedValue), lk());
                gCities.DataBind();
            }
        }
        else
        {
            if (ddlDistricts.SelectedValue == "")
            {
                g3.DataSource = BPosts.MngSvs(int.Parse(ddlCities.SelectedValue), -1, lk());
                g3.DataBind();
            }
            else
            {
                g3.DataSource = BPosts.MngSvs(int.Parse(ddlCities.SelectedValue), int.Parse(ddlDistricts.SelectedValue), lk());
                g3.DataBind();
            }
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

    public int mwl()
    {
        return BTransIO.MyWallet(lk());
    }

    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        a11.Visible = true;
        a12.Visible = true;
        rdtl2.Visible = false;
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
        rdetails.InnerHtml = "Thiết lập Tính năng cho tin đăng mã số: <span style=\"font-weight:bold;color:#73AC59\">" + i + "</span>";
        int j = int.Parse(gCities.DataKeys[row.RowIndex].Values[1].ToString());
        if (j== 1) rdisp.Visible = false;
        else if (j == 2)
        {
            rdisp.Visible = true;
            rdetails.InnerHtml += "</br><span style=\"color:red\">Tin đăng này chưa được kích hoạt. Bạn cần kích hoạt để tin đăng này được <b>Hiển thị</b>.</span>";
            rdetails.InnerHtml += "</br><span style=\"color:#73AC59\">Để kích hoạt tin đăng bạn cần có ít nhất <b>12 xu</b> trong tài khoản. Nạp xu vào tài khoản bằng tin nhắn SMS qua điện thoại.";
        }
    }
    
    protected void gCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int jst = int.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[9].ToString());
            Label lbl7New = (Label)e.Row.FindControl("lbl7");
            if (lbl7New != null)
            {
                if (jst == 6) lbl7New.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
            }

            DateTime ex = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[5].ToString());
            TimeSpan ts = ex - DateTime.Now;

            Label exp = (Label)e.Row.FindControl("lbl4");
            if (exp == null)
            {
                exp = (Label)e.Row.FindControl("lbl3");
            }
            if (exp != null)
            {
                if (ts.Days > 0)
                {
                    exp.Text = "Còn " + ts.Days + " ngày";
                }
                else if (ts.Days == 0 && ts.Hours > 0)
                {
                    exp.Text = "Còn " + ts.Hours + "h";
                }
                else if (ts.Days == 0 && ts.Minutes > 0 && ts.Hours == 0)
                {
                    exp.Text = "Còn " + ts.Minutes + "'";
                }
                else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds > 0)
                {
                    exp.Text = "Còn " + ts.Seconds + "''";
                }
                else
                {
                    exp.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
                }
            }

            DateTime ex2 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[6].ToString());
            TimeSpan ts2 = DateTime.Now - ex2;
            Label exp2 = (Label)e.Row.FindControl("lbl6");
            if (exp2 == null)
            {
                exp2 = (Label)e.Row.FindControl("lbl5");
            }

            if (exp2 != null)
            {
                if (ts2.Days > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Days + " ngày";
                }
                else if (ts2.Days == 0 && ts2.Hours > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Hours + "h";
                }
                else if (ts2.Days == 0 && ts2.Minutes > 0 && ts2.Hours == 0)
                {
                    exp2.Text = "Cách đây " + ts2.Minutes + "'";
                }
                else if (ts2.Days == 0 && ts2.Minutes == 0 && ts2.Seconds > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Seconds + "''";
                }
            }

            EAuthorizations aut = new EAuthorizations();
            EMember mr = new EMember();
            mr.UserName = lk();
            aut = BAuthorizations.Authors2(mr);

            DropDownList States = (DropDownList)e.Row.FindControl("ddlState");
            if (States != null)
            {
                int j = 0;
                bool ie = false;
                if (aut.Post)
                {
                    States.Items.Clear();
                    States.Items.Add("Không chọn");
                    States.Items[0].Value = "-1";
                    //States.Items.Add("Hiển thị");
                    //States.Items[1].Value = "1";
                    //States.Items.Add("Chờ duyệt");
                    //States.Items[2].Value = "2";
                    //States.Items.Add("Chưa hợp lệ");
                    //States.Items[3].Value = "3";
                    States.Items.Add("Đang soạn");
                    States.Items[1].Value = "4";
                    States.Items.Add("Ngừng đăng");
                    States.Items[2].Value = "5";
                    //States.Items.Add("Hết hạn");
                    //States.Items[6].Value = "6";
                    //States.Items.Add("Gia hạn");
                    //States.Items[7].Value = "8";
                    j = 2;
                    ie = true;
                }

                if (aut.Approve)
                {
                    //States.Items.Clear();
                    //States.Items.Add("Không chọn");
                    //States.Items[0].Value = "-1";
                    if (j == 0) j = -1;
                    States.Items.Add("Hiển thị");
                    States.Items[j + 1].Value = "1";
                    j = j + 1;
                    //States.Items.Add("Chờ duyệt");
                    //States.Items[2].Value = "2";
                    States.Items.Add("Chưa hợp lệ");
                    States.Items[j + 1].Value = "3";
                    j = j + 1;
                    //States.Items.Add("Đang soạn");
                    //States.Items[2].Value = "4";
                    //States.Items.Add("Ngừng đăng");
                    //States.Items[5].Value = "5";
                    //States.Items.Add("Hết hạn");
                    //States.Items[6].Value = "6";
                    //States.Items.Add("Gia hạn");
                    //States.Items[7].Value = "8";
                    ie = true;
                }
                //if (aut.IsApproved)
                //{
                //    States.Items.Clear();
                //    States.Items.Add("Đang soạn");
                //    States.Items[0].Value = "4";
                //    //States.Items.Add("Gia hạn");
                //    //States.Items[1].Value = "8";
                //    States.Items.Add("Ngừng đăng");
                //    States.Items[2].Value = "5";
                //}
                if (aut.Renew)
                {
                    if (j == 0) j = -1;
                    //States.Items.Add("Ngừng đăng");
                    //States.Items[j + 1].Value = "5";
                    //j = j + 1;
                    //States.Items.Add("Hết hạn");
                    //States.Items[j + 1].Value = "6";
                    //j = j + 1;
                    States.Items.Add("Gia hạn");
                    States.Items[j + 1].Value = "8";
                    j = j + 1;
                    ie = true;
                }
                if (aut.Del)
                {
                    if (j == 0) j = -1;
                    States.Items.Add("Xoá");
                    States.Items[j + 1].Value = "7";
                    ie = true;
                }
                if (!ie)
                {
                    gCities.Columns[7].Visible = false;
                    States.Visible = false;
                }
            }

            CheckBox Vip = (CheckBox)e.Row.FindControl("ckbVipE");
            if (Vip == null) Vip = (CheckBox)e.Row.FindControl("ckbVip");
            if (Vip != null)
            {
                if (!aut.Vip)
                {
                    Vip.Enabled = false;
                    DropDownList monv = (DropDownList)e.Row.FindControl("ddlMonV");
                    if (monv != null) monv.Visible = false;
                }
                if (Vip.Checked)
                {
                    if ((((DataRowView)e.Row.DataItem).Row.ItemArray[11].ToString()).ToString() != "")
                    {
                        DateTime ex3 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[11].ToString());
                        TimeSpan ts3 = ex3 - DateTime.Now;
                        Label exp3 = (Label)e.Row.FindControl("lblExpVip");
                        if (exp3 == null)
                        {
                            exp3 = (Label)e.Row.FindControl("lblExpVipE");
                        }

                        if (exp3 != null)
                        {
                            if (ts3.Days > 0)
                            {
                                exp3.Text = ts3.Days + " ngày";
                            }
                            else if (ts3.Days == 0 && ts3.Hours > 0)
                            {
                                exp3.Text = ts3.Hours + "h";
                            }
                            else if (ts3.Days == 0 && ts3.Minutes > 0 && ts3.Hours == 0)
                            {
                                exp3.Text = ts3.Minutes + "'";
                            }
                            else if (ts3.Days == 0 && ts3.Minutes == 0 && ts3.Seconds > 0)
                            {
                                exp3.Text = ts3.Seconds + "''";
                            }
                            else
                            {
                                exp3.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
                            }
                        }
                    }
                }
            }

            CheckBox silver = (CheckBox)e.Row.FindControl("ckbSilverE");
            if (silver == null) silver = (CheckBox)e.Row.FindControl("ckbSilver");
            if (silver != null)
            {
                if (!aut.IP)
                {
                    silver.Enabled = false;
                    DropDownList mons = (DropDownList)e.Row.FindControl("ddlMonS");
                    if (mons != null) mons.Visible = false;
                }
                if (silver.Checked)
                {
                    if ((((DataRowView)e.Row.DataItem).Row.ItemArray[11].ToString()).ToString() != "")
                    {
                        DateTime ex3 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[11].ToString());
                        TimeSpan ts3 = ex3 - DateTime.Now;
                        Label exp3 = (Label)e.Row.FindControl("lblExpSil");
                        if (exp3 == null)
                        {
                            exp3 = (Label)e.Row.FindControl("lblExpSilE");
                        }

                        if (exp3 != null)
                        {
                            if (ts3.Days > 0)
                            {
                                exp3.Text = ts3.Days + " ngày";
                            }
                            else if (ts3.Days == 0 && ts3.Hours > 0)
                            {
                                exp3.Text = ts3.Hours + "h";
                            }
                            else if (ts3.Days == 0 && ts3.Minutes > 0 && ts3.Hours == 0)
                            {
                                exp3.Text = ts3.Minutes + "'";
                            }
                            else if (ts3.Days == 0 && ts3.Minutes == 0 && ts3.Seconds > 0)
                            {
                                exp3.Text = ts3.Seconds + "''";
                            }
                            else
                            {
                                exp3.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
                            }
                        }
                    }
                }
            }

            //if (!aut.Del)
            //{
            //    gCities.Columns[11].Visible = false;
            //}

            if (!aut.Up)
            {
                gCities.Columns[8].Visible = false;
            }

            if (aut.Edit)
            {
                HtmlAnchor mdpst = (HtmlAnchor)e.Row.FindControl("mngpst");
                if (mdpst != null) mdpst.Visible = true;
            }

        }
    }

    protected void g3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime ex = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[4].ToString());
            TimeSpan ts = ex - DateTime.Now;

            Label exp = (Label)e.Row.FindControl("lbl4");
            if (exp != null)
            {
                if (ts.Days > 0)
                {
                    exp.Text = "Còn " + ts.Days + " ngày";
                }
                else if (ts.Days == 0 && ts.Hours > 0)
                {
                    exp.Text = "Còn " + ts.Hours + "h";
                }
                else if (ts.Days == 0 && ts.Minutes > 0 && ts.Hours == 0)
                {
                    exp.Text = "Còn " + ts.Minutes + "'";
                }
                else if (ts.Days == 0 && ts.Minutes == 0 && ts.Seconds > 0)
                {
                    exp.Text = "Còn " + ts.Seconds + "''";
                }
                else
                {
                    exp.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
                }
            }

            DateTime ex2 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[5].ToString());
            TimeSpan ts2 = DateTime.Now - ex2;
            Label exp2 = (Label)e.Row.FindControl("lbl6");

            if (exp2 != null)
            {
                if (ts2.Days > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Days + " ngày";
                }
                else if (ts2.Days == 0 && ts2.Hours > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Hours + "h";
                }
                else if (ts2.Days == 0 && ts2.Minutes > 0 && ts2.Hours == 0)
                {
                    exp2.Text = "Cách đây " + ts2.Minutes + "'";
                }
                else if (ts2.Days == 0 && ts2.Minutes == 0 && ts2.Seconds > 0)
                {
                    exp2.Text = "Cách đây " + ts2.Seconds + "''";
                }
            }
        }
    }

    public string CountVip()
    {
        return "Vip (+2)";
    }

    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //EPosts p = new EPosts();
        //p.PostId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());

        ////int sid = int.Parse(gCities.DataKeys[e.RowIndex].Values[1].ToString());
        //DropDownList ddlC = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlState");

        //p.StateId = int.Parse(ddlC.SelectedValue);

        //CheckBox Vip = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbVipE");
        //CheckBox Ip = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbSilverE");
        //if (Vip.Enabled)
        //{
        //    if (Vip.Checked) p.IsVip = true;
        //    else p.IsVip = false;
        //}
        //if (Ip.Enabled)
        //{
        //    if (Ip.Checked) p.Silver = true;
        //    else p.Silver = false;
        //}
        //BPosts.UStaPst(p);
        //gCities.EditIndex = -1;
        //mng2();
        //BServer.Remove("Posts", true);

        EPosts p = new EPosts();
        p.PostId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());

        //int sid = int.Parse(gCities.DataKeys[e.RowIndex].Values[1].ToString());
        DropDownList ddlC = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlState");

        p.StateId = int.Parse(ddlC.SelectedValue);

        CheckBox Vip = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbVipE");
        CheckBox Ip = (CheckBox)gCities.Rows[e.RowIndex].FindControl("ckbSilverE");
        if (Vip.Enabled)
        {
            if (Vip.Checked) p.IsVip = true;
            else p.IsVip = false;
        }
        else p.IsVip = Vip.Checked;
        if (Ip.Enabled)
        {
            if (Ip.Checked) p.Silver = true;
            else p.Silver = false;
        }
        else p.Silver = Ip.Checked;

        DropDownList ddlVip = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlMonV");
        DropDownList ddlSil = (DropDownList)gCities.Rows[e.RowIndex].FindControl("ddlMonS");

        int a = 1;
        if (ddlVip.SelectedValue != "-1")
        {
            a = int.Parse(ddlVip.SelectedValue.ToString());
        }
        else if (ddlSil.SelectedValue != "-1")
        {
            a = int.Parse(ddlSil.SelectedValue.ToString());
        }
        BPosts.UStaPst(p, lk(), a);
        gCities.EditIndex = -1;
        mng2();
        BServer.Remove("Posts", true);
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        mng2();
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        mng2();
    }
    protected void ddlStaPts_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
        if (ddlStaPts.SelectedValue != "")
        {
            int i = int.Parse(ddlStaPts.SelectedValue.ToString());
            switch (i)
            {
                case 1:
                    {
                        hls1.InnerText = "Đang hiển thị";
                        break;
                    }
                case 2:
                    {
                        hls1.InnerText = "Đang chờ duyệt";
                        break;
                    }
                case 4:
                    {
                        hls1.InnerText = "Tin đang soạn";
                        break;
                    }
                case 3:
                    {
                        hls1.InnerText = "Chưa hợp lệ";
                        break;
                    }
                case 5:
                    {
                        hls1.InnerText = "Tin ngừng đăng";
                        break;
                    }
                case 6:
                    {
                        hls1.InnerText = "Tin hết hạn";
                        break;
                    }
                case 8:
                    {
                        hls1.InnerText = "Tin Vip/Silver";
                        break;
                    }
                default:
                    {
                        hls1.InnerText = "Tất cả tin đăng";
                        break;
                    }
            }
        }
    }
    
    protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(ddlCities.SelectedValue);
        if (i > 0)
        {
            EDistricts dt = new EDistricts();
            dt.CityId = i;
            districts(dt);
        }
        else ddlDistricts.Items.Clear();
        mng2();
    }
    protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
    }
    protected void gCities_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UpPosts")
        {
            int i = int.Parse(e.CommandArgument.ToString());
            GridViewRow r = gCities.Rows[i];
            int j = int.Parse(gCities.DataKeys[r.RowIndex].Values[0].ToString());
            BPosts.UPosts(j);
            mng2();
            BServer.Remove("Posts", true);
        }
    }
    protected void gCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gCities.SelectedIndex = -1;
        gCities.PageIndex = e.NewPageIndex;
        mng2();
    }

    protected void g3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EMember t = new EMember();
        t.UserName = lk();
        int pid = int.Parse(g3.DataKeys[e.RowIndex].Values[0].ToString());
        BSets.ISaved(t, pid);
        mng2();
    }
    protected void rdisp_CheckedChanged(object sender, EventArgs e)
    {
        a14.Visible = true;
        a13.Visible = false;
        rsubmit.Attributes.Add("onclick", "fndht('sgnpg');return confirm('Bạn muốn kích hoạt tin đăng đã chọn phải không?');");
        rdtl2.Visible = false;
    }

    protected void rtop_CheckedChanged(object sender, EventArgs e)
    {
        a14.Visible = true;
        a13.Visible = false;
        rsubmit.Attributes.Add("onclick", "fndht('sgnpg');return confirm('Bạn muốn Up Top tin đăng đã chọn phải không?');");
        rdtl2.Visible = false;
    }
    protected void rvip_CheckedChanged(object sender, EventArgs e)
    {
        a13.Visible = true;
        ddlrtype.Items.Clear();
        ListItem i2 = new ListItem();
        i2.Value = "1";
        i2.Text = "Ngày";
        ddlrtype.Items.Add(i2);
        ListItem i3 = new ListItem();
        i3.Value = "2";
        i3.Text = "Tuần";
        ddlrtype.Items.Add(i3);
        ListItem i = new ListItem();
        i.Value = "3";
        i.Text = "Tháng";
        ddlrtype.Items.Add(i);
        a14.Visible = true;
        rsubmit.Attributes.Add("onclick", "fndht('sgnpg');return confirm('Bạn muốn Up tin đăng đã chọn thành tin Vip phải không?');");
        rdtl2.Visible = false;
    }
    protected void rip_CheckedChanged(object sender, EventArgs e)
    {
        a13.Visible = true;
        ddlrtype.Items.Clear();
        ListItem i2 = new ListItem();
        i2.Value = "1";
        i2.Text = "Ngày";
        ddlrtype.Items.Add(i2);
        ListItem i3 = new ListItem();
        i3.Value = "2";
        i3.Text = "Tuần";
        ddlrtype.Items.Add(i3);
        ListItem i = new ListItem();
        i.Value = "3";
        i.Text = "Tháng";
        ddlrtype.Items.Add(i);
        a14.Visible = true;
        rsubmit.Attributes.Add("onclick", "fndht('sgnpg');return confirm('Bạn muốn Up tin đăng đã chọn thành tin IP phải không?');");
        rdtl2.Visible = false;
    }
    protected void rnew_CheckedChanged(object sender, EventArgs e)
    {
        a13.Visible = true;
        ddlrtype.Items.Clear();
        ListItem i = new ListItem();
        i.Value = "3";
        i.Text= "Tháng";
        ddlrtype.Items.Add(i);
        a14.Visible = true;
        rsubmit.Attributes.Add("onclick", "fndht('sgnpg');return confirm('Bạn muốn gia hạn tin đăng đã chọn phải không?');");
        rdtl2.Visible = false;
    }
    protected void rsubmit_Click(object sender, EventArgs e)
    {
        ETransIn tr = new ETransIn();
        tr.IP = HttpContext.Current.Request.UserHostAddress;
        tr.ByMember = lk();
        GridViewRow row = gCities.SelectedRow;
        tr.PostId = int.Parse(gCities.DataKeys[row.RowIndex].Values[0].ToString());
        rdtl2.Visible = true;
        if (rdisp.Checked)
        {
            if (mwl() >= 12)
            {
                tr.TypeId = 9;
                tr.Total = 1;
                rdtl2.InnerHtml = BTransIO.ITransOut(tr) + " Bạn vừa thực hiện giao dịch trên hết <b>12</b> xu.";
            }
            else rdtl2.InnerText = "Tài khoản của bạn không đủ để Kích hoạt tin đăng này. Bạn cần nạp thêm xu vào tài khoản.";
        }
        else if (rtop.Checked)
        {
            if (mwl() >= 6)
            {
                tr.TypeId = 6;
                tr.Total = 1;
                rdtl2.InnerHtml = BTransIO.ITransOut(tr) + " Bạn vừa thực hiện giao dịch trên hết <b>6</b> xu.";
            }
            else rdtl2.InnerText = "Tài khoản của bạn không đủ để Up Top tin đăng này. Bạn cần nạp thêm xu vào tài khoản.";
        }
        else if (rvip.Checked)
        {
            tr.TypeId = 7;
            int ds = 0;
            if (int.TryParse(rtime.Value.ToString(), out ds))
            {
                if (ds > 0)
                {
                    if (ddlrtype.SelectedValue == "1") tr.Total = ds;
                    else if (ddlrtype.SelectedValue == "2") tr.Total = ds * 7;
                    else if (ddlrtype.SelectedValue == "3") tr.Total = ds * 30;
                    if (mwl() >= 4 * tr.Total) rdtl2.InnerHtml = BTransIO.ITransOut(tr) + " Bạn vừa thực hiện giao dịch trên hết <b>" + (4 * tr.Total) + "</b> xu.";
                    else rdtl2.InnerHtml = "Bạn cần: <b>" + 4 * tr.Total + "</b> xu để thực hiện yêu cầu trên. Tài khoản của bạn không đủ để Up VIP tin đăng này." +
                        " Bạn cần nạp thêm xu vào tài khoản. Hoặc giảm thời gian hiệu lực ít hơn.";
                }
            }
            else rdtl2.InnerHtml = "Bạn cần nhập thời gian hiệu lực khi cài đặt tính năng của tính đăng trên.";
        }
        else if (rip.Checked)
        {
            tr.TypeId = 8;
            int ds = 0;
            if (int.TryParse(rtime.Value.ToString(), out ds))
            {
                if (ds > 0)
                {
                    if (ddlrtype.SelectedValue == "1") tr.Total = ds;
                    else if (ddlrtype.SelectedValue == "2") tr.Total = ds * 7;
                    else if (ddlrtype.SelectedValue == "3") tr.Total = ds * 30;
                    if (mwl() >= 3 * tr.Total) rdtl2.InnerHtml = BTransIO.ITransOut(tr) + " Bạn vừa thực hiện giao dịch trên hết <b>" + (3 * tr.Total) + "</b> xu.";
                    else rdtl2.InnerHtml = "Bạn cần: <b>" + 3 * tr.Total + "</b> xu để thực hiện yêu cầu trên." +
                        " Tài khoản của bạn không đủ để Up IP tin đăng này. Bạn cần nạp thêm xu vào tài khoản. Hoặc giảm thời gian hiệu lực ít hơn.";
                }
            }
            else rdtl2.InnerHtml = "Bạn cần nhập thời gian hiệu lực khi cài đặt tính năng của tính đăng trên.";
        }
        else if (rnew.Checked)
        {
            tr.TypeId = 12;
            int ds = 0;
            if (int.TryParse(rtime.Value.ToString(), out ds))
            {
                if (ds > 0)
                {
                    if (ddlrtype.SelectedValue == "3") tr.Total = ds;
                    if (mwl() >= 18 * tr.Total) rdtl2.InnerHtml = BTransIO.ITransOut(tr) + " Bạn vừa thực hiện giao dịch trên hết <b>" + (18 * tr.Total) + "</b> xu.";
                    else rdtl2.InnerHtml = "Bạn cần: <b>" + 18 * tr.Total + "</b> xu để thực hiện yêu cầu trên." +
                        " Tài khoản của bạn không đủ để Gia hạn tin đăng này. Bạn cần nạp thêm xu vào tài khoản. Hoặc giảm thời gian hiệu lực ít hơn.";
                }
            }
            else rdtl2.InnerHtml = "Bạn cần nhập thời gian hiệu lực khi cài đặt tính năng của tính đăng trên.";
        }
        
    }
}
