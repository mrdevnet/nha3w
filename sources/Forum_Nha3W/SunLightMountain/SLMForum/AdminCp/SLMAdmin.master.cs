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


public partial class AdminCp_SLMAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EnMember mbr = new EnMember();
            EnAdminGroup admin = new EnAdminGroup();
            if (AuthenticateSession())
            {
                mbr.UserName = LookCookie().ToLower();
                admin = BuAdminGroup.SelectAdminDetails(mbr);
                if (admin.Sysc)
                {
                    sysc.Visible = true;
                }
                else
                {
                    sysc.Visible = false;
                }
                if (admin.Analytics)
                {
                    analytics.Visible = true;
                }
                else
                {
                    analytics.Visible = false;
                }
                if (admin.Blckuser)
                {
                    blckuser.Visible = true;
                }
                else
                {
                    blckuser.Visible = false;
                }
                if (admin.Addrpt)
                {
                    addrpt.Visible = true;
                }
                else
                {
                    addrpt.Visible = false;
                }
                if (admin.Updelrpt)
                {
                    updelrpt.Visible = true;
                }
                else
                {
                    updelrpt.Visible = false;
                }
                if (admin.Rptman)
                {
                    rptman.Visible = true;
                }
                else
                {
                    rptman.Visible = false;
                }
                if (admin.Addfrm)
                {
                    addfrm.Visible = true;
                }
                else
                {
                    addfrm.Visible = false;
                }
                if (admin.Updelfrm)
                {
                    updelfrm.Visible = true;
                }
                else
                {
                    updelfrm.Visible = false;
                }
                if (admin.Cateman)
                {
                    cateman.Visible = true;
                }
                else
                {
                    cateman.Visible = false;
                }
                if (admin.Privfrm)
                {
                    privfrm.Visible = true;
                }
                else
                {
                    privfrm.Visible = false;
                }
                if (admin.Userman)
                {
                    userman.Visible = true;
                }
                else
                {
                    userman.Visible = false;
                }
                if (admin.Addgrp)
                {
                    addgrp.Visible = true;
                }
                else
                {
                    addgrp.Visible = false;
                }
                if (admin.Grpman)
                {
                    grpman.Visible = true;
                }
                else
                {
                    grpman.Visible = false;
                }
                if (admin.Usrgrp)
                {
                    usrgrp.Visible = true;
                }
                else
                {
                    usrgrp.Visible = false;
                }
                if (admin.Grpfrm)
                {
                    grpfrm.Visible = true;
                }
                else
                {
                    grpfrm.Visible = false;
                }
                if (admin.Moder)
                {
                    moder.Visible = true;
                }
                else
                {
                    moder.Visible = false;
                }
                if (admin.Almdrs)
                {
                    almdrs.Visible = true;
                }
                else
                {
                    almdrs.Visible = false;
                }
                if (admin.Armman)
                {
                    armman.Visible = true;
                }
                else
                {
                    armman.Visible = false;
                }

                if (admin.Prioman)
                {
                    prioman.Visible = true;
                }
                else
                {
                    prioman.Visible = false;
                }
                if (admin.Addava)
                {
                    addava.Visible = true;
                }
                else
                {
                    addava.Visible = false;
                }
                if (admin.Vionline)
                {
                    vionline.Visible = true;
                }
                else
                {
                    vionline.Visible = false;
                }
                if (admin.Blcmbr)
                {
                    blcmbr.Visible = true;
                }
                else
                {
                    blcmbr.Visible = false;
                }
                if (admin.Blcip)
                {
                    blcip.Visible = true;
                }
                else
                {
                    blcip.Visible = false;
                }
                if (admin.Addbnr)
                {
                    addbnr.Visible = true;
                }
                else
                {
                    addbnr.Visible = false;
                }
                if (admin.Admman)
                {
                    admman.Visible = true;
                }
                else
                {
                    admman.Visible = false;
                }
                if (admin.Aladms)
                {
                    aladms.Visible = true;
                }
                else
                {
                    aladms.Visible = false;
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("../errorsreporter/errorsyes.aspx");
            }
            string strNew = Request.Path.ToString();
            int intLenght = strNew.Length;
            int intStart = strNew.LastIndexOf("/") + 1;
            strNew = strNew.Substring(intStart, intLenght - intStart);
            if (Request.Params["id"] != null)
            {
                string strUrl = Request.Params["id"].ToString();
                switch (strUrl)
                {
                    case "sysc":
                        {
                            MyAccordion.SelectedIndex = 0;
                            if (!admin.Sysc)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "blckuser":
                        {
                            MyAccordion.SelectedIndex = 0;
                            if (!admin.Blckuser)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "analytics":
                        {
                            MyAccordion.SelectedIndex = 0;
                            if (!admin.Analytics)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "addrpt":
                        {
                            MyAccordion.SelectedIndex = 1;
                            if (!admin.Addrpt)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "rptman":
                        {
                            MyAccordion.SelectedIndex = 1;
                            if (!admin.Rptman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "updelrpt":
                        {
                            MyAccordion.SelectedIndex = 1;
                            if (!admin.Updelrpt)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "addfrm":
                        {
                            MyAccordion.SelectedIndex = 2;
                            if (!admin.Addfrm)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "updelfrm":
                        {
                            MyAccordion.SelectedIndex = 2;
                            if (!admin.Updelfrm)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "updfrm":
                        {
                            MyAccordion.SelectedIndex = 2;
                            if (!admin.Updfrm)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "cateman":
                        {
                            MyAccordion.SelectedIndex = 2;
                            if (!admin.Cateman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "privfrm":
                        {
                            MyAccordion.SelectedIndex = 2;
                            if (!admin.Privfrm)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "userman":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Userman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "addgrp":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Addgrp)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "grpman":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Grpman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "usrgrp":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Usrgrp)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "grpfrm":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Grpfrm)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "memberpro":
                        {
                            MyAccordion.SelectedIndex = 3;
                            if (!admin.Memberpro)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "moder":
                        {
                            MyAccordion.SelectedIndex = 4;
                            if (!admin.Moder)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "almdrs":
                        {
                            MyAccordion.SelectedIndex = 4;
                            if (!admin.Almdrs)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "armman":
                        {
                            MyAccordion.SelectedIndex = 5;
                            if (!admin.Armman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "prioman":
                        {
                            MyAccordion.SelectedIndex = 5;
                            if (!admin.Prioman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "addava":
                        {
                            MyAccordion.SelectedIndex = 6;
                            if (!admin.Addava)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "vionline":
                        {
                            MyAccordion.SelectedIndex = 7;
                            if (!admin.Vionline)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "blcmbr":
                        {
                            MyAccordion.SelectedIndex = 7;
                            if (!admin.Blcmbr)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "blcip":
                        {
                            MyAccordion.SelectedIndex = 7;
                            if (!admin.Blcip)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "addbnr":
                        {
                            MyAccordion.SelectedIndex = 7;
                            if (!admin.Addbnr)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "admman":
                        {
                            MyAccordion.SelectedIndex = 8;
                            if (!admin.Admman)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    case "aladms":
                        {
                            MyAccordion.SelectedIndex = 8;
                            if (!admin.Aladms)
                            {
                                Response.Redirect("../errorsreporter/errorsyes.aspx");
                            }
                            break;
                        }
                    default:
                        {
                            Response.Redirect("../errorsreporter/errorsyes.aspx");
                            break;
                        }
                }
            }
            else if (Request.Params["id"] == null && strNew.ToLower() != "default.aspx")
            {
                Response.Redirect("../errorsreporter/errorsyes.aspx");
            }
            else if (Request.Params["id"] == null && strNew.ToLower() == "default.aspx" && !admin.Analytics)
            {
                Response.Redirect("../errorsreporter/errorsyes.aspx");
            }
        }
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
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
}
