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

public partial class modercp_ctrls_mng : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cities();
            mng();
            Permiss(txtUserName.Value.ToString());
        }
    }

    private void Permiss(string strFull)
    {
        grvMngs.DataSource = BMember.APermiss(strFull);
        grvMngs.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        GUHLS unew = new GUHLS();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    private void mng()
    {
        int i = 0, j = 0, k =0;
        if (ddlStaPts.SelectedValue != "") i = int.Parse(ddlStaPts.SelectedValue.ToString());
        if (ddlCities.SelectedValue != "") j = int.Parse(ddlCities.SelectedValue.ToString());
        if (ddlDistricts.SelectedValue != "" && ddlDistricts.SelectedValue != null) k = int.Parse(ddlDistricts.SelectedValue.ToString());
        int ur = 0;
        gCities.DataSource = BPosts.MrPst(i, j, k, ur);
        gCities.DataBind();
    }

    private void mng2()
    {
        int i = 0, j = 0, k = 0, z = 0;
        if (ddlStaPts.SelectedValue != "") i = int.Parse(ddlStaPts.SelectedValue.ToString());
        if (ddlCities.SelectedValue != "") j = int.Parse(ddlCities.SelectedValue.ToString());
        if (ddlDistricts.SelectedValue != "" && ddlDistricts.SelectedValue != null) k = int.Parse(ddlDistricts.SelectedValue.ToString());
        GridViewRow row = grvMngs.SelectedRow;
        if (row != null) z = int.Parse(grvMngs.DataKeys[row.RowIndex].Values[0].ToString());
        gCities.DataSource = BPosts.MrPst(i, j, k, z);
        gCities.DataBind();
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

    public string CountVip()
    {
        return "Vip (+2)";
    }
    protected void gCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //int i = int.Parse(e.CommandArgument.ToString());
            //GridViewRow r = gCities.Rows[i];
            //int j = int.Parse(gCities.DataKeys[r.RowIndex].Values[0].ToString());
            //Label lbl7New = (Label)gCities.Rows[e.Row.RowIndex].FindControl("lbl7");
            //if (lbl7New != null)
            //{
            //    if (j == 6) lbl7New.Text = "<span style=\"color:Red;font-weight:bold;font-style:italic\">Hết hạn</span>";
            //}

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

            DateTime exr = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[16].ToString());
            TimeSpan tsr = DateTime.Now - exr;

            Label approv = (Label)e.Row.FindControl("lblAppro");
            if (approv == null)
            {
                approv = (Label)e.Row.FindControl("lblApproE");
            }
            if (approv != null)
            {
                if (tsr.Days > 0)
                {
                    approv.Text = "<span style=\"color:#3b5998;font-style:italic\">Cách " + tsr.Days + " ngày</span>";
                }
                else if (tsr.Days == 0 && tsr.Hours > 0)
                {
                    approv.Text = "<span style=\"color:#3b5998;font-style:italic\">Cách " + tsr.Hours + "h</span>";
                }
                else if (tsr.Days == 0 && tsr.Minutes > 0 && tsr.Hours == 0)
                {
                    approv.Text = "<span style=\"color:#3b5998;font-style:italic\">Cách " + tsr.Minutes + "'</span>";
                }
                else if (tsr.Days == 0 && tsr.Minutes == 0 && tsr.Seconds > 0)
                {
                    approv.Text = "<span style=\"color:#3b5998;font-style:italic\">Cách " + tsr.Seconds + "''</span>";
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

            EModerAuthors aut = new EModerAuthors();
            EMember mr = new EMember();
            mr.UserName = lk();
            aut = BModerAuthors.ModerAuthors2(mr);

            DropDownList States = (DropDownList)e.Row.FindControl("ddlState");
            if (States != null)
            {
                int j = 0;
                bool ie = false;
                if (aut.Approve)
                {
                    States.Items.Clear();
                    States.Items.Add("Không chọn");
                    States.Items[0].Value = "-1";
                    States.Items.Add("Hiển thị");
                    States.Items[1].Value = "1";
                    States.Items.Add("Chờ duyệt");
                    States.Items[2].Value = "2";
                    States.Items.Add("Chưa hợp lệ");
                    States.Items[3].Value = "3";
                    States.Items.Add("Đang soạn");
                    States.Items[4].Value = "4";
                    //States.Items.Add("Ngừng đăng");
                    //States.Items[5].Value = "5";
                    //States.Items.Add("Hết hạn");
                    //States.Items[6].Value = "6";
                    //States.Items.Add("Gia hạn");
                    //States.Items[7].Value = "8";
                    j = 4;
                    ie = true;
                }
                if (aut.Renew)
                {
                    if (j == 0) j = -1;
                    States.Items.Add("Ngừng đăng");
                    States.Items[j+1].Value = "5";
                    j = j + 1;
                    States.Items.Add("Hết hạn");
                    States.Items[j + 1].Value = "6";
                    j = j + 1;
                    States.Items.Add("Gia hạn");
                    States.Items[j+1].Value = "8";
                    j = j + 1;
                    ie = true;
                }
                if (aut.Del)
                {
                    if (j == 0) j = -1;
                    States.Items.Add("Xoá");
                    States.Items[j+1].Value = "7";
                    ie = true;
                }
                if (!ie) gCities.Columns[9].Visible = false;
            }

            CheckBox Vip = (CheckBox)e.Row.FindControl("ckbVipE");
            if (Vip == null) Vip = (CheckBox)e.Row.FindControl("ckbVip");
            if (Vip != null)
            {
                if (!aut.Vip)
                {
                    Vip.Enabled = false;
                }
                if (Vip.Checked)
                {
                    if ((((DataRowView)e.Row.DataItem).Row.ItemArray[15].ToString()).ToString() != "")
                    {
                        DateTime ex3 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[15].ToString());
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
                if (!aut.Silver)
                {
                    silver.Enabled = false;
                }
                if (silver.Checked)
                {
                    if ((((DataRowView)e.Row.DataItem).Row.ItemArray[15].ToString()).ToString() != "")
                    {
                        DateTime ex3 = DateTime.Parse(((DataRowView)e.Row.DataItem).Row.ItemArray[15].ToString());
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

            if (!aut.Del)
            {
                gCities.Columns[11].Visible = false;
            }

            if (!aut.Ups)
            {
                gCities.Columns[10].Visible = false;
            }

            if (aut.Edit)
            {
                HtmlAnchor mdpst = (HtmlAnchor)e.Row.FindControl("modpst");
                if (mdpst != null) mdpst.Visible = true;
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
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
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
        BPosts.UStaPst2(p, lk(), a);
        gCities.EditIndex = -1;
        mng2();
        BServer.Remove("Posts", true);
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        mng2();
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        mng2();
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BPosts.EPosts(i);
        mng2();
        BServer.Remove("Posts", true);
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
    protected void ddlStaPts_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
    }
    protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
        EDistricts t= new EDistricts();
        if (ddlCities.SelectedValue != null && ddlCities.SelectedValue.ToString() != "" && int.Parse(ddlCities.SelectedValue) > 0)
        {
            t.CityId = int.Parse(ddlCities.SelectedValue.ToString());
            districts(t);
        }
        else ddlDistricts.Items.Clear();
    }
    protected void ddlDistricts_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        grvMngs.SelectedIndex = -1;
        Permiss(txtUserName.Value.ToString());
    }
    protected void grvMngs_SelectedIndexChanged(object sender, EventArgs e)
    {
        mng2();
    }
    protected void grvMngs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMngs.SelectedIndex = -1;
        grvMngs.PageIndex = e.NewPageIndex;
        Permiss(txtUserName.Value.ToString());
        mng2();
    }
}
