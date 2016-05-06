using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.DataAccess;
using SLMF.Entity;

/// <summary>
/// Summary description for SLMGenClass
/// </summary>
public class SLMGenClass
{
    public SLMGenClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string GenCookies()
    {
        HttpCookie SlmMemberCookie = new HttpCookie("SLMFMembers");
        SlmMemberCookie = HttpContext.Current.Request.Cookies["SLMFMembers"];
        string strUser = "";
        if (SlmMemberCookie != null && SlmMemberCookie.Value != "" &&
             SlmMemberCookie.Value != null)
        {
            strUser = SlmMemberCookie.Value.ToString();
        }
        return strUser;
    }

    public void UpdateCookies()
    {
        if (GenCookies() != "")
        {
            DaMember mbr = new DaMember();
            EnMember nr = new EnMember();
            nr.UserName = GenCookies();
            mbr.UpdateStatus(nr);
        }
    }
}
