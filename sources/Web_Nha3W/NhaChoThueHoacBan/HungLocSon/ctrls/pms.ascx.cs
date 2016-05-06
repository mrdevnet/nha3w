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

public partial class ctrls_pms : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            err.Visible = false;
            if (Request.Params["m"] != null && Request.Params["m"].ToString() != "")
            {
                EMember m = new EMember(int.Parse(Request.Params["m"].ToString()));
                txtTo.Text = BMember.PMemberU(m);
            }
        }
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        if (txtTo.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Tên người nhận không đúng !";
            text_err.InnerHtml = "Vui lòng nhập username người dùng bạn muốn gửi tin nhắn";
            return;
        }
        if (txtMessage.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Nhập nội dung tin nhắn !";
            text_err.InnerHtml = "Vui lòng nhập nội dung tin nhắn bạn muốn gửi ";
            return;
        }
        string tomb = txtTo.Text.Trim();
        string[] to = tomb.Split(',');
        foreach (String t in to)
        {
            if (BMember.ReturnId(t.Trim()) == 0)
            {
                err.Visible = true;
                header_err.InnerHtml = "Tên người nhận không đúng !";
                text_err.InnerHtml = "Hãy xem lại tên người dùng này : " + t;
                return;
            }
            else
            {
                err.Visible = true;
            }
        }
        foreach (String tmb in to)
        {
            EPms pm = new EPms();
            pm.FromMember = BMember.ReturnId(lk());
            pm.ToMemberId = BMember.ReturnId(tmb.Trim());
            pm.Title = rplc(txtTitle.Text);
            pm.Message = rplc(txtMessage.Text);
            BPms.PMS_InSert(pm);
        }
        Response.Redirect("pm.aspx?pm=o");
    }

    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
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
    
    protected void btnFMbrs_Click(object sender, EventArgs e)
    {
        if (txtFriends.Text.Trim() == "")
        {
            err.Visible = true;
            header_err.InnerHtml = "Vui lòng nhập thông tin cần tìm kiếm ";
            text_err.InnerHtml = "Hãy nhập username, tên người dùng hoặc tên công ty mà bạn muốn tìm kiếm";
            return;
        }
        if (BMember.Search(txtFriends.Text.Trim()).Rows.Count == 0)
        {
            err.Visible = true;
            header_err.InnerHtml = "Không tìm thấy thông tin người này vui lòng nhập lại";
            text_err.InnerHtml = "Hãy nhập username, tên người dùng hoặc tên công ty mà bạn muốn tìm kiếm";
            return;
        }
        else
        {
            err.Visible = false;
            value_frm.Visible = true;
            info_frm.Visible = false;
            cboFriends.DataSource = BMember.Search(txtFriends.Text.Trim());
            cboFriends.DataTextField = "FullName";
            cboFriends.DataValueField = "UserName";
            cboFriends.DataBind();
        }
    }
    protected void btnChoose_Click(object sender, EventArgs e)
    {
        if (txtTo.Text.Trim() == "") txtTo.Text = txtTo.Text + cboFriends.SelectedValue.ToString();
        else txtTo.Text = txtTo.Text + "," + cboFriends.SelectedValue.ToString();
    }
    protected void btnReFind_Click(object sender, EventArgs e)
    {
        value_frm.Visible = false;
        info_frm.Visible = true;
        txtFriends.Text = "";
    }
}
