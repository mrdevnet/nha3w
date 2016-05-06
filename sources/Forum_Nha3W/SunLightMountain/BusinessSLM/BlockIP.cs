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
    public class BuBlockIP
    {
        public BuBlockIP()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertBlockIP(EnBlockIP ip)
        {
            DaBlockIP daip = new DaBlockIP();
            daip.InsertBlockIP(ip);
        }

        public static void SelectBlockIP(ref EnBlockIP ip)
        {
            DaBlockIP daip = new DaBlockIP();
            daip.SelectBlockIP(ref ip);
        }

        public static DataTable SelectBlockIP()
        {
            DaBlockIP daip = new DaBlockIP();
            return daip.SelectBlockIP();
        }

        public static void DeleteBlockIP(EnBlockIP ip)
        {
            DaBlockIP daip = new DaBlockIP();
            daip.DeleteBlockIP(ip);
        }

        public static bool IPIsBlock(EnBlockIP ip)
        {
            DaBlockIP daip = new DaBlockIP();
            return daip.IPIsBlock(ip);
        }
    }
}