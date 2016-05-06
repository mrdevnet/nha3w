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
    public class BuSponsor
    {
        public BuSponsor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectSponsorId(EnTopic tpc)
        {
            DaSponsor sp = new DaSponsor();
            SqlDataReader r = sp.SelectSponsorId(tpc);
            return r;
        }

        public static int SelectRanId(EnTopic tpc)
        {
            DaSponsor sp = new DaSponsor();
            int intId = sp.SelectRandId(tpc);
            return intId;
        }

        public static void SelectScript(ref EnSponsor sp)
        {
            DaSponsor spn = new DaSponsor();
            spn.SelectScript(ref sp);
        }

        public static DataTable SelectAllSponsors()
        {
            DaSponsor spn = new DaSponsor();
            return spn.SelectAllSponsors();
        }

        public static DataTable SelectSpnFrm(EnSponsor sp)
        {
            DaSponsor spn = new DaSponsor();
            return spn.SelectSpnFrm(sp);
        }

        public static void UpdateScripts(EnSponsor spn)
        {
            DaSponsor daspn = new DaSponsor();
            daspn.UpdateScripts(spn);
        }

        public static void InsertScripts(EnSponsor spn, EnForum frm)
        {
            DaSponsor daspn = new DaSponsor();
            daspn.InsertScripts(spn,frm);
        }

        public static int InsertFrmSpn(EnSponsor spn, EnForum frm)
        {
            DaSponsor daspn = new DaSponsor();
            return daspn.InsertFrmSpn(spn, frm);
        }

        public static void DeleteSpn(EnSponsor spn)
        {
            DaSponsor daspn = new DaSponsor();
            daspn.DeleteSpn(spn);
        }

        public static void DeleteFrmSpn(EnSponsor spn, EnForum frm)
        {
            DaSponsor daspn = new DaSponsor();
            daspn.DeleteFrmSpn(spn, frm);
        }

    }
}
