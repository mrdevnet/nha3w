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
    public class BuBlockMember
    {
        public BuBlockMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertBlock(EnBlockMember mbr)
        {
            DaBlockMember dambr = new DaBlockMember();
            dambr.InsertBlock(mbr);
        }

        public static void SelectBlockMembers(ref EnBlockMember mbr)
        {
            DaBlockMember dambr = new DaBlockMember();
            dambr.SelectBlockMembers(ref mbr);
        }

        public static DataTable SelectBlockMembers()
        {
            DaBlockMember dambr = new DaBlockMember();
            return dambr.SelectBlockMembers();
        }

        public static void DeleteBlockMember(EnBlockMember blc)
        {
            DaBlockMember dablc = new DaBlockMember();
            dablc.DeleteBlockMember(blc);
        }
    }
}