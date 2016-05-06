using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuMemberAuthorize
    {
        public BuMemberAuthorize()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static EnMemberAuthorize SelectMemberAuthorize(EnMember member, EnForum forum,string atr)
        {
            DaMemberAuthorize author = new DaMemberAuthorize();
            EnMemberAuthorize newauthor = new EnMemberAuthorize();
            newauthor = author.SelectMemberAuthorize(member, forum, atr);
            return newauthor;
        }



    }
}
