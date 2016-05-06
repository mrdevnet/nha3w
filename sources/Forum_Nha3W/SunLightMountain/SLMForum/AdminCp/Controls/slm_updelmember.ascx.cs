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
using SLMF.Utility;
using SLMF.Entity;
using SLMF.Business;

public partial class AdminCp_Controls_slm_updelmember : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rbtMale.Text = LoadSLMF("SLMF_UserA", "Male");
            rbtFemale.Text = LoadSLMF("SLMF_UserA", "FeMale");
            rbtOnline.Text = LoadSLMF("SLMF_UserA", "Online");
            rbtOffline.Text = LoadSLMF("SLMF_UserA", "Offline");
            rbtActivated.Text = LoadSLMF("SLMF_UserA", "Activated");
            rbtNotActivated.Text = LoadSLMF("SLMF_UserA", "NotActivated");
            rbtLogin.Text = LoadSLMF("SLMF_UserA", "CanLogin");
            rbtNotLogin.Text = LoadSLMF("SLMF_UserA", "NotCanLogin");
            rbtAlways.Text = LoadSLMF("SLMF_UserA", "YesAlwaysSig");
            rbtNotAlways.Text = LoadSLMF("SLMF_UserA", "NoAlwaysSig");
            rbtPublished.Text = LoadSLMF("SLMF_UserA", "YesPublished");
            rbtNotPublished.Text = LoadSLMF("SLMF_UserA", "NoPublished");
            rbtCanSend.Text = LoadSLMF("SLMF_UserA", "ReceiveMail");
            rbtNotCanSend.Text = LoadSLMF("SLMF_UserA", "NotReceiveMail");
            lbtBlockUser.ToolTip = LoadSLMF("SLMF_UserA", "BlockUser");
            lbtCloseBlock.ToolTip = LoadSLMF("SLMF_UserA", "CloseBlock");
            btnSave.Text = LoadSLMF("SLMF_UserA", "Updated");
            rbtBlock.Text = LoadSLMF("SLMF_UserA", "YesBlock");
            rbtUnBlock.Text = LoadSLMF("SLMF_UserA", "NoBlock");
            btnUpdateBlock.Text = LoadSLMF("SLMF_UserA", "Updated");
            lbtExpandIp.ToolTip = LoadSLMF("SLMF_UserA", "ExpandIp");
            lbtCloseIp.ToolTip = LoadSLMF("SLMF_UserA", "CloseIp");
            rbtLockIp.Text = LoadSLMF("SLMF_UserA", "YesBlock");
            rbtUnLockIp.Text = LoadSLMF("SLMF_UserA", "NoBlock");
            btnBlockIp.Text = LoadSLMF("SLMF_UserA", "Updated");
            txtStart.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            DateTime dateFisn = DateTime.Now.AddDays(7);
            txtFinish.Text = dateFisn.Day + "/" + dateFisn.Month + "/" + dateFisn.Year;
            //txtFinish.Text = DateTime.Now.Day + 7 + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            txtBlockIpDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (Request.Params["mbrid"] != null)
            {
                int intMemberId = int.Parse(Request.Params["mbrid"].ToString());
                LoadProfile(intMemberId);
            }
        }
    }

    private void LoadProfile(int intMemberId)
    {
        EnMember mbr = new EnMember();
        EnMemberProfile mbrpro = new EnMemberProfile();
        EnGroup grp = new EnGroup();
        mbr.MemberId = intMemberId;
        BuMemberProfile.SelectProfile(ref mbr, ref grp, ref mbrpro);
        txtUserName.Text = mbr.UserName;
        txtMemberTitle.Text = mbrpro.MemberTitle;
        imgAvatar.Src = "~/slmuploads/avatar/" + mbrpro.Avatar.ToString();
        txtEmail.Text = mbr.Email;
        txtFullName.Text = mbr.FullName;
        if (!mbrpro.Gender)
        {
            rbtFemale.Checked = true;
        }
        if (!mbrpro.UserStatus)
        {
            rbtOffline.Checked = true;
        }
        txtDateCreation.Text = mbr.DateCreation.Day + "/" + mbr.DateCreation.Month + "/" + mbr.DateCreation.Year;
        if (!mbr.IsActivated)
        {
            rbtNotActivated.Checked = true;
        }
        if (!mbr.EnableLogin)
        {
            rbtNotLogin.Checked = true;
        }
        txtAboutMe.Text = mbrpro.AboutMe;
        txtInterests.Text = mbrpro.Interests;
        txtJob.Text = mbrpro.Job;
        txtLocation.Text = mbrpro.Location;
        if (mbrpro.BirthDay.ToShortDateString() == "1/1/0001")
        {
            txtBirthday.Text = "21/02/1987";
        }
        else
        {
            txtBirthday.Text = mbrpro.BirthDay.Day + "/" + mbrpro.BirthDay.Month + "/" + mbrpro.BirthDay.Year;
        }
        txtYahoo.Text = mbrpro.Yahoo;
        txtAim.Text = mbrpro.Aim;
        txtIcq.Text = mbrpro.Icq;
        txtMsn.Text = mbrpro.Msn;
        txtBlog.Text = mbrpro.Blog;
        txtHomePage.Text = mbrpro.HomePage;
        txtSignature.Text = mbrpro.Signature;
        if (!mbrpro.AlwaysSig)
        {
            rbtNotAlways.Checked = true;
        }
        txtIp.Text = mbrpro.IP;
        txtIp2.Text = mbrpro.IP;
        if (!mbrpro.IsEmailPublished)
        {
            rbtNotPublished.Checked = true;
        }
        if (!mbrpro.CanSendE)
        {
            rbtNotCanSend.Checked = true;
        }
        txtTotalPosts.Text = mbrpro.TotalPosts.ToString();
        txtCountLostPass.Text = mbrpro.CountLostPass.ToString();
        lblLastLogin.Text = mbrpro.LastLogin.Day + "/" + mbrpro.LastLogin.Month + "/" + mbrpro.LastLogin.Year + " " +
            mbrpro.LastLogin.ToLongTimeString();
        lblLastBrowse.Text = mbrpro.LastBrowse.Day + "/" + mbrpro.LastBrowse.Month + "/" + mbrpro.LastBrowse.Year + " " +
            mbrpro.LastBrowse.ToLongTimeString();
        if (mbrpro.Posted.ToShortDateString() == "1/1/0001")
        {
            lblPosted.Text = LoadSLMF("SLMF_Forum", "NotHaveForum");
        }
        else
        {
            lblPosted.Text = mbrpro.Posted.Day + "/" + mbrpro.Posted.Month + "/" + mbrpro.Posted.Year + " " +
                mbrpro.Posted.ToLongTimeString();
        }
    }

    private void UpdateMember(int intMemberId)
    {
        EnMember mbr = new EnMember();
        EnMemberProfile pro = new EnMemberProfile();
        mbr.MemberId = intMemberId;
        mbr.UserName = txtUserName.Text.ToString();
        mbr.FullName = txtFullName.Text.ToString();
        mbr.Email = txtEmail.Text.ToString();
        pro.AboutMe = txtAboutMe.Text.ToString();
        pro.Interests = txtInterests.Text.ToString();
        pro.Job = txtJob.Text.ToString();
        pro.Location = txtLocation.Text.ToString();
        pro.UserStatus = false;
        if (rbtOnline.Checked)
        {
            pro.UserStatus = true;
        }
        string strDateCreation = "21/02/1987";
        strDateCreation = txtDateCreation.Text.ToString();
        strDateCreation = strDateCreation.Substring(3, 2) + "/" + strDateCreation.Substring(0, 2) + "/" + strDateCreation.Substring(6, 4);
        mbr.DateCreation = DateTime.Parse(strDateCreation.ToString());
        mbr.IsActivated = false;
        if (rbtActivated.Checked)
        {
            mbr.IsActivated = true;
        }
        mbr.EnableLogin = false;
        if (rbtLogin.Checked)
        {
            mbr.EnableLogin = true;
        }
        pro.Signature = txtSignature.Text.ToString();
        pro.AlwaysSig = false;
        if (rbtAlways.Checked)
        {
            pro.AlwaysSig = true;
        }
        pro.TotalPosts = int.Parse(txtTotalPosts.Text.ToString());
        pro.CountLostPass = int.Parse(txtCountLostPass.Text.ToString());
        string strBirthday = "21/02/1987";
        strBirthday = txtBirthday.Text.ToString();
        strBirthday = strBirthday.Substring(3, 2) + "/" + strBirthday.Substring(0, 2) + "/" + strBirthday.Substring(6, 4);
        pro.BirthDay = DateTime.Parse(strBirthday.ToString());
        pro.Yahoo = txtYahoo.Text.ToString();
        pro.Aim = txtAim.Text.ToString();
        pro.Icq = txtIcq.Text.ToString();
        pro.Msn = txtMsn.Text.ToString();
        pro.Blog = txtBlog.Text.ToString();
        pro.HomePage = txtHomePage.Text.ToString();
        pro.MemberTitle = txtMemberTitle.Text.ToString();
        pro.IsEmailPublished = false;
        pro.IP = txtIp.Text.ToString();
        if (rbtPublished.Checked)
        {
            pro.IsEmailPublished = true;
        }
        pro.Gender = false;
        if (rbtMale.Checked)
        {
            pro.Gender = true;
        }
        pro.CanSendE = false;
        if (rbtCanSend.Checked)
        {
            pro.CanSendE = true;
        }
        BuMemberProfile.UpdateMemberAd(mbr, pro);
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
    protected void lbtBlockUser_Click(object sender, EventArgs e)
    {
        pnlBlockUser.Visible = true;
        lbtCloseBlock.Visible = true;
        lbtBlockUser.Visible = false;
        SelectBlockMember();
    }

    private void SelectBlockMember()
    {
        if (Request.Params["mbrid"] != null)
        {
            int intMemberId = int.Parse(Request.Params["mbrid"].ToString());
            EnBlockMember blcMbr = new EnBlockMember();
            blcMbr.MemberId = intMemberId;
            BuBlockMember.SelectBlockMembers(ref blcMbr);
            if (blcMbr.BlockId > 0)
            {
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
            }
        }
    }
         
    protected void lbtCloseBlock_Click(object sender, EventArgs e)
    {
        pnlBlockUser.Visible = false;
        lbtCloseBlock.Visible = false;
        lbtBlockUser.Visible = true;
    }
    protected void lbtExpandIp_Click(object sender, EventArgs e)
    {
        pnlBlockIp.Visible = true;
        lbtCloseIp.Visible = true;
        lbtExpandIp.Visible = false;
        SelectBlockIp();
    }

    private void SelectBlockIp()
    {
        if (Request.Params["mbrid"] != null)
        {
            EnBlockIP ip = new EnBlockIP();
            ip.IP = txtIp.Text.ToString();
            BuBlockIP.SelectBlockIP(ref ip);
            if (ip.BlockId > 0)
            {
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
            }
        }
    }
    protected void lbtCloseIp_Click(object sender, EventArgs e)
    {
        pnlBlockIp.Visible = false;
        lbtCloseIp.Visible = false;
        lbtExpandIp.Visible = true;
    }
    protected void btnUpdateBlock_Click(object sender, EventArgs e)
    {
        if (Request.Params["mbrid"] != null)
        {
            EnBlockMember mbr = new EnBlockMember();
            mbr.MemberId = int.Parse(Request.Params["mbrid"].ToString());
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
            //hrfMember.InnerHtml = strUser;
            //EnMember member = new EnMember();
            //member.UserName = strUser;
            //member = BuMember.SelectMemberIdFUser(member);
            //hrfMember.HRef = "../showprofile.aspx?memberid=" + member.MemberId;
        }
        return strUser;
    }
    protected void btnBlockIp_Click(object sender, EventArgs e)
    {
        if (Request.Params["mbrid"] != null)
        {
            EnBlockIP ip = new EnBlockIP();
            ip.IP = txtIp2.Text.ToString();
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
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.Params["mbrid"] != null)
        {
            int intMemberId = int.Parse(Request.Params["mbrid"].ToString());
            UpdateMember(intMemberId);
        }
    }
}
