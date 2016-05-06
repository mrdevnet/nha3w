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
using SLMF.Business;
using SLMF.Entity;
using System.IO;

public partial class AdminCp_Controls_slm_uploadgrp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (AuthenticateSession())
            {
                btnUpload.Text = LoadSLMF("SLMF_GroupA", "UploadFile");
                btnClose.Text = LoadSLMF("SLMF_GroupA", "CloseFile");
                if (Request.Params["typeid"].ToString() == "1")
                {
                    spnMost.InnerText = LoadSLMF("SLMF_GroupA", "UploadImgRank");
                }
                else
                {
                    spnMost.InnerText = LoadSLMF("SLMF_GroupA", "UploadAvatar");
                }
            }
            else Response.Redirect("~/errorsreporter/errorsyes.aspx");
        }
    }

    private bool AuthenticateSession()
    {
        HttpCookie SlmSessionId = new HttpCookie("SLMFSessionId");
        SlmSessionId = Request.Cookies["SLMFSessionId"];
        if (SlmSessionId != null && SlmSessionId.Value != "" &&
             SlmSessionId.Value != null)
        {
            string strSessionId = SlmSessionId.Value.ToString();
            EnMember member = new EnMember();
            member.UserName = LookCookie();
            BuMember.MemberLogin(member);
            if (member.NewPassword == strSessionId)
            {
                return true;
            }
        }
        return false;
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

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    private void UploadImg(ref string []Images, string strFolder)
    {
        string strPath = "";
        int i = 0;
        while (i < 3)
        {
            switch (i)
            {
                case 0:
                    {
                        strPath = fup1.PostedFile.FileName;
                        break;
                    }
                case 1:
                    {
                        strPath = fup2.PostedFile.FileName;
                        break;
                    }
                case 2:
                    {
                        strPath = fup3.PostedFile.FileName;
                        break;
                    }
            }
            if (strPath == "")
            {
                return;
            }
            int intStart = strPath.LastIndexOf("\\") + 1;
            int intStep = strPath.Length - intStart;
            Images[i] = strPath.Substring(intStart, intStep);
            //string strFolder = "..\\SlmImages\\";
            switch (i)
            {
                case 0:
                    {
                        fup1.PostedFile.SaveAs(Server.MapPath(strFolder) + Images[i]);
                        break;
                    }
                case 1:
                    {
                        fup2.PostedFile.SaveAs(Server.MapPath(strFolder) + Images[i]);
                        break;
                    }
                case 2:
                    {
                        fup3.PostedFile.SaveAs(Server.MapPath(strFolder) + Images[i]);
                        break;
                    }
            }
            i++;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string[] Images = new string[3];
        string strFolder = "";
        string strRequest = Request.Params["typeid"].ToString();
        int intGrpId = 0;
        intGrpId = int.Parse(Request.Params["grpid"].ToString());
        if (strRequest == "1")
        {
            strFolder = "..\\SlmImages\\";
        }
        else if (strRequest == "2" && intGrpId != 0)
        {
            strFolder = "..\\slmuploads\\avatar\\";
        }
        UploadImg(ref Images, strFolder);
        int i = 0;
        while (i < 3)
        {
            if (strRequest == "1")
            {
                EnGroup grp = new EnGroup();
                grp.RankImage = Images[i];
                if (grp.RankImage == null)
                {
                    return;
                }
                BuGroup.InsertRankImage(grp);
                lblReport.Text = LoadSLMF("SLMF_GroupA", "UploadSuccess");
                lblReport.Visible = true;
            }
            else if (strRequest == "2" && intGrpId != 0)
            {
                EnAvatar av = new EnAvatar();
                av.Avatar = Images[i];
                if (av.Avatar == null)
                {
                    return;
                }
                BuAvatar.InsertAvatars(av, intGrpId);
            }
            i++;
        }
    }
}
