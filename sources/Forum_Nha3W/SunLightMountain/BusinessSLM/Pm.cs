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
    public class BuPm
    {
        public BuPm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable SelectPm(EnMember mbr)
        {
            DaPm pm = new DaPm();
            DataTable dttp = new DataTable();
            dttp = pm.SelectPm(mbr);
            return dttp;
        }

        public static EnPm SelectPmMessage(int intPm)
        {
            DaPm p = new DaPm();
            EnPm pm = new EnPm();
            pm = p.SelectPmMessage(intPm);
            return pm;
        }

        public static void UpdatePmRead(int intId)
        {
            DaPm pm = new DaPm();
            pm.UpdatePmRead(intId);
        }

        public static void DeletePm(int intId)
        {
            DaPm pm = new DaPm();
            pm.DeletePm(intId);
        }

        public static DataTable SelectPmFrMember(EnMember mbr)
        {
            DaPm pm = new DaPm();
            DataTable dttp = new DataTable();
            dttp = pm.SelectPmFrMember(mbr);
            return dttp;
        }

        public static SqlDataReader SelectFindMember(EnMember mbr)
        {
            DaPm pm = new DaPm();
            SqlDataReader r = pm.SelectFindPm(mbr);
            return r;
        }

        public static void InsertPm(EnMember mbr1, EnMember mbr2, EnPm pm)
        {
            DaPm pmn = new DaPm();
            pmn.InsertPm(mbr1, mbr2, pm);
        }

        public static bool PmIsView(EnMember mbr, ref int pn)
        {
            DaPm pmn = new DaPm();
            return pmn.PmIsView(mbr, ref pn);
        }
    }
}
