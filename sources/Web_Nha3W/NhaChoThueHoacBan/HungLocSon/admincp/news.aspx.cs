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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class admincp_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            griNT.DataSource = BCatalogs.SelectAll();
            griNT.DataBind();
            DropDownList rd = (DropDownList)cbNTC;
            LoadNTC(rd);
        }
    }

    private void LoadNTC(DropDownList cb)
    {
        DataTable c = BCatalogs.SelectAllParent();
        cb.Items.Clear();
        cb.Items.Add(new ListItem("Tất cả", "all"));
        cb.Items.Add(new ListItem("Không có", "0"));
        foreach (DataRow row in c.Rows)
        {
            cb.Items.Add(new ListItem(row["Name"].ToString(), row["CatalogId"].ToString()));
        }
        cb.SelectedIndex = 0;
    }
    protected void cbNTC_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGri();
    }
    private void LoadGri()
    {
        switch (cbNTC.SelectedValue)
        {
            case "all": griNT.DataSource = BCatalogs.SelectAll(); break;
            case "0": griNT.DataSource = BCatalogs.SelectAllParent(); break;
            default: griNT.DataSource = BCatalogs.SelectBySubId(int.Parse(cbNTC.SelectedValue.ToString())); break;
        }
        griNT.DataBind();
    }
    protected void btCNTT_Click(object sender, EventArgs e)
    {
        if (cbNTC.SelectedValue == "all") return;
        ECatalogs ec = new ECatalogs();
        ec.Name = txtNT1.Text;
        ec.SubId = int.Parse(cbNTC.SelectedValue.ToString());
        ec.OrderBy = short.Parse(txtVT.Value);
        ec.TopDefault = ckbNB.Checked;
        BCatalogs.Insert(ec);
        LoadGri();
        SetNull();
    }
    private void SetNull()
    {
        //cbNTC.SelectedIndex = 0;
        txtNT1.Text = txtVT.Value = "";
        ckbNB.Checked = false;
    }
    protected void griNT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            BCatalogs.Delete(int.Parse(e.CommandArgument.ToString()));
            LoadGri();
        }
    }
    protected void griNT_RowEditing(object sender, GridViewEditEventArgs e)
    {
        griNT.EditIndex = e.NewEditIndex;
        LoadGri();
    }
    protected void griNT_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        griNT.EditIndex = -1;
        LoadGri();
    }
    protected void griNT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList nt = (DropDownList)e.Row.FindControl("cbNTCa");
            if (nt != null)
            {
                LoadNTC(nt);
                nt.SelectedValue = griNT.DataKeys[e.Row.RowIndex].Values[1].ToString();
            }
        }
    }
    protected void griNT_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ECatalogs ec = new ECatalogs();
        ec.CatalogId = int.Parse(griNT.DataKeys[e.RowIndex].Values[0].ToString());
        ec.Name = (griNT.Rows[e.RowIndex].Cells[0].FindControl("txtNT2") as TextBox).Text;
        ec.SubId = int.Parse((griNT.Rows[e.RowIndex].Cells[1].FindControl("cbNTCa") as DropDownList).SelectedValue);
        ec.OrderBy = short.Parse((griNT.Rows[e.RowIndex].Cells[2].FindControl("Text1") as HtmlInputText).Value);
        ec.TopDefault = (griNT.Rows[e.RowIndex].Cells[3].FindControl("cbNBe") as CheckBox).Checked;
        BCatalogs.Update(ec);
        griNT.EditIndex = -1;
        LoadGri();
    }
}
