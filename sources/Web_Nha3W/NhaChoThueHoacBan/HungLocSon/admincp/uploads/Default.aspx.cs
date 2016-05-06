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
using System.IO;

public partial class admincp_uploads_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            SetNull();
            griDL.DataSource = BDownloads.SelectAll();
            griDL.DataBind();
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

    protected void btok_Click(object sender, EventArgs e)
    {
        EDownloads ed = new EDownloads();
        ed.CatalogId = int.Parse(cbC.SelectedValue.ToString());
        ed.Descs = txtD.Text;
        ed.IP = Request.UserHostAddress.ToString();
        //ed.MemberId = 1; //id thanh viên đăng nhập
        ed.User = lk();
        ed.Title = txtT.Text;
        ed.Visible = ckbV.Checked;
        string url = txtUrl.Text.Trim();
        if (lbID.Text == "")//thêm
        {
            if ((url == "") && (!ful.HasFile)) return;//nêu không chọn url và upfile dừng lại
            if (ful.HasFile)
            {
                string file = ful.FileName.Replace(" ", "_");
                if (File.Exists(Server.MapPath("~/downloadfiles/" + file)))
                    file = "v2" + file;
                ful.SaveAs(Server.MapPath("~/downloadfiles/Nha3W-" + file));
                ed.Files = url = "Nha3W-" + file;
                //url = ResolveUrl("~/Download/Nha3W-" + file);

            }
            else ed.Files = "";
            ed.URL = url;
            BDownloads.Insert(ed);
        }//sửa
        else
        {
            ed.DownloadId = int.Parse(lbID.Text);
            BDownloads.Update(ed);
        }
        SetNull();
        Show.Visible = false;
        griDL.DataSource = BDownloads.SelectAll();
        griDL.DataBind();
    }
    protected void griDL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cbedit")
        {

            EDownloads ed = BDownloads.SelectByID(int.Parse(e.CommandArgument.ToString()));
            txtD.Text = ed.Descs;
            txtT.Text = ed.Title;
            txtUrl.Text = ed.URL;
            txtUrl.Enabled = false;
            ful.Enabled = false;
            Show.Visible = true;
            lbID.Text = ed.DownloadId.ToString();
            cbC.SelectedValue = ed.CatalogId.ToString();
            ckbV.Checked = ed.Visible;
        }
        else
            if (e.CommandName == "cbdel")
            {
                string file = BDownloads.Delete(int.Parse(e.CommandArgument.ToString()));
                if (file != "")
                {
                    File.Delete(Server.MapPath("~/downloadfiles/") + file);
                }
                SetNull();
            }
        griDL.DataSource = BDownloads.SelectAll();
        griDL.DataBind();
    }
    private void SetNull()
    {
        txtD.Text = txtT.Text = txtUrl.Text = "";
        LoadCatalog();
        cbC.SelectedIndex = 0;
        ckbV.Checked = false;
        lbID.Text = "";
        ful.Enabled = txtUrl.Enabled = true;

    }
    private void LoadCatalog()
    {
        DataTable sub = BCatalogs.SelectAllParent();
        cbC.Items.Clear();
        foreach (DataRow row in sub.Rows)
        {
            cbC.Items.Add(new ListItem(row["Name"].ToString(), row["CatalogId"].ToString()));
            foreach (DataRow Srow in BCatalogs.SelectBySubId(int.Parse(row["CatalogId"].ToString())).Rows)
                cbC.Items.Add(new ListItem(" -- " + Srow["Name"].ToString(), Srow["CatalogId"].ToString()));
        }
    }
    protected void lbNew_Click(object sender, EventArgs e)
    {
        SetNull();
        Show.Visible = true;

    }
    protected void griDL_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griDL.PageIndex = e.NewPageIndex;
        griDL.DataSource = BDownloads.SelectAll();
        griDL.DataBind();
    }
    protected void btC_Click(object sender, EventArgs e)
    {
        Show.Visible = false;
        SetNull();
    }
}
