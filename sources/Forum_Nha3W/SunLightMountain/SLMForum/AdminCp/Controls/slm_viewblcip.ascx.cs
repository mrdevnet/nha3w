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
using SLMF.Entity;
using SLMF.Utility;
using SLMF.Business;

public partial class AdminCp_Controls_slm_viewblcip : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBlockIP();
            rbtLockIp.Text = LoadSLMF("SLMF_UserA", "YesBlock");
            rbtUnLockIp.Text = LoadSLMF("SLMF_UserA", "NoBlock");
            btnBlockIp.Text = LoadSLMF("SLMF_UserA", "Updated");
        }
    }

    private void LoadBlockIP()
    {
        grvBlockIP.DataSource = BuBlockIP.SelectBlockIP();
        grvBlockIP.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void grvBlockIP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strIP = grvBlockIP.DataKeys[e.RowIndex].Value.ToString();
        EnBlockIP ip = new EnBlockIP();
        ip.IP = strIP;
        BuBlockIP.DeleteBlockIP(ip);
        LoadBlockIP();
        pnlBlockIp.Visible = false;
    }
    protected void grvBlockIP_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvBlockIP.SelectedRow;
        pnlBlockIp.Visible = true;
        string strIP = grvBlockIP.DataKeys[row.RowIndex].Value.ToString();
        EnBlockIP ip = new EnBlockIP();
        ip.IP = strIP;
        BuBlockIP.SelectBlockIP(ref ip);
        if (ip.BlockId > 0)
        {
            txtIp2.Text = strIP;
            if (ip.Status)
            {
                rbtLockIp.Checked = true;
                rbtUnLockIp.Checked = false;
            }
            else
            {
                rbtLockIp.Checked = false;
                rbtUnLockIp.Checked = true;
            }
            txtBlockIpDate.Text = ip.DateBlock.Day + "/" + ip.DateBlock.Month + "/" + ip.DateBlock.Year;
            txtReasonIp.Text = ip.Reason.ToString();
            lblBlockIp.Visible = false;
        }
    }

    private string LookCookie()
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

    protected void grvBlockIP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBlockIP.PageIndex = e.NewPageIndex;
        LoadBlockIP();
        pnlBlockIp.Visible = false;
    }
    protected void btnBlockIp_Click(object sender, EventArgs e)
    {
        if (grvBlockIP.SelectedValue != null)
        {
            GridViewRow row = grvBlockIP.SelectedRow;
            string strIP = grvBlockIP.DataKeys[row.RowIndex].Value.ToString();
            string strIP2 = txtIp2.Text.ToString();
            EnBlockIP ip = new EnBlockIP();
            ip.IP = strIP;
            if (strIP != strIP2)
            {
                ip.IP = strIP2;
            }
            ip.Status = false;
            if (rbtLockIp.Checked)
            {
                ip.Status = true;
            }
            string strStart = txtBlockIpDate.Text.ToString();
            strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
            ip.DateBlock = DateTime.Parse(strStart.ToString());
            ip.Reason = txtReasonIp.Text.ToString();
            EnMember member = new EnMember();
            member.UserName = LookCookie();
            member = BuMember.SelectMemberIdFUser(member);
            ip.Moderator = member.MemberId;
            BuBlockIP.InsertBlockIP(ip);
            lblBlockIp.Text = LoadSLMF("SLMF_UserA", "SaveSuccess");
            lblBlockIp.Visible = true;
            LoadBlockIP();
        }
    }
}
