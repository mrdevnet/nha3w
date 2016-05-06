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
    public class BuRating
    {
        public BuRating()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int SelectRatingPoint(EnMember mbr)
        {
            DaRating p = new DaRating();
            return p.SelectRating(mbr);
        }

        public static SqlDataReader SelectMemberRating(EnMember mbr)
        {
            DaRating p = new DaRating();
            SqlDataReader datrTopic = p.SelectMemberRating(mbr);
            return datrTopic;
        }

        public static void InsertRating(EnRating rating)
        {
            DaRating r = new DaRating();
            r.InsertRating(rating);
        }
    }
}
