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

public partial class AdminCp_Controls_slm_viewblcmember : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBlockMembers();
            rbtBlock.Text = LoadSLMF("SLMF_UserA", "YesBlock");
            rbtUnBlock.Text = LoadSLMF("SLMF_UserA", "NoBlock");
            btnUpdateBlock.Text = LoadSLMF("SLMF_UserA", "Updated");
        }
    }

    private void LoadBlockMembers()
    {
        grvViewBlcMember.DataSource = BuBlockMember.SelectBlockMembers();
        grvViewBlcMember.DataBind();
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
    protected void grvViewBlcMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvViewBlcMember.SelectedRow;
        pnlBlockUser.Visible = true;
        int intMemberId = int.Parse(grvViewBlcMember.DataKeys[row.RowIndex].Value.ToString());
        EnBlockMember blcMbr = new EnBlockMember();
        blcMbr.MemberId = intMemberId;
        BuBlockMember.SelectBlockMembers(ref blcMbr);
        if (blcMbr.Status)
        {
            rbtBlock.Checked = true;
            rbtUnBlock.Checked = false;
        }
        else
        {
            rbtBlock.Checked = false;
            rbtUnBlock.Checked = true;
        }
        txtStart.Text = blcMbr.Start.Day + "/" + blcMbr.Start.Month + "/" + blcMbr.Start.Year;
        txtFinish.Text = blcMbr.Finish.Day + "/" + blcMbr.Finish.Month + "/" + blcMbr.Finish.Year;
        txtReason.Text = blcMbr.Reason;
        lblBlockUser.Visible = false;
        //int intAlarmId = int.Parse(grvAlarm.DataKeys[row.RowIndex].Value.ToString());
        //LoadAlarmDetails(intAlarmId);
    }
    protected void btnUpdateBlock_Click(object sender, EventArgs e)
    {
        if (grvViewBlcMember.SelectedValue != null)
        {
            GridViewRow row = grvViewBlcMember.SelectedRow;
            int intMemberId = int.Parse(grvViewBlcMember.DataKeys[row.RowIndex].Value.ToString());
            EnBlockMember mbr = new EnBlockMember();
            mbr.MemberId = intMemberId;
            mbr.Status = false;
            if (rbtBlock.Checked)
            {
                mbr.Status = true;
            }
            string strStart = txtStart.Text.ToString();
            strStart = strStart.Substring(3, 2) + "/" + strStart.Substring(0, 2) + "/" + strStart.Substring(6, 4);
            mbr.Start = DateTime.Parse(strStart.ToString());
            string strFinish = txtFinish.Text.ToString();
            strFinish = strFinish.Substring(3, 2) + "/" + strFinish.Substring(0, 2) + "/" + strFinish.Substring(6, 4);
            mbr.Finish = DateTime.Parse(strFinish.ToString());
            mbr.Reason = txtReason.Text.ToString();
            EnMember member = new EnMember();
            member.UserName = LookCookie();
            member = BuMember.SelectMemberIdFUser(member);
            mbr.Moderator = member.MemberId;
            BuBlockMember.InsertBlock(mbr);
            lblBlockUser.Text = LoadSLMF("SLMF_UserA", "SaveSuccess");
            lblBlockUser.Visible = true;
            LoadBlockMembers();
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
    protected void grvViewBlcMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvViewBlcMember.PageIndex = e.NewPageIndex;
        LoadBlockMembers();
        pnlBlockUser.Visible = false;
    }
    protected void grvViewBlcMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intMemberId = int.Parse(grvViewBlcMember.DataKeys[e.RowIndex].Value.ToString());
        EnBlockMember blc = new EnBlockMember();
        blc.MemberId = intMemberId;
        BuBlockMember.DeleteBlockMember(blc);
        LoadBlockMembers();
        pnlBlockUser.Visible = false;
    }
}
