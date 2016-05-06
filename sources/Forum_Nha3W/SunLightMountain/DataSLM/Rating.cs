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

namespace SLMF.DataAccess
{
    public class DaRating
    {
        public DaRating()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int SelectRating(EnMember mbr)
        {
            int intRating = 0;
            string strCommandText = "selRatePoint";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@Point", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            if (paraLocal[1].Value != null && paraLocal[1].Value.ToString() != "")
            {
                intRating = int.Parse(paraLocal[1].Value.ToString());
            }
            return intRating;
        }

        public SqlDataReader SelectMemberRating(EnMember mbr)
        {
            string strCommandText = "selRatingMember";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public void InsertRating(EnRating rating)
        {
            string strCommandText = "insRating";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@TypeId", rating.TypeId);
            paraLocal[1] = new SqlParameter("@FromMember", rating.From);
            paraLocal[2] = new SqlParameter("@ToMember", rating.ToMember);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }
    }
}
