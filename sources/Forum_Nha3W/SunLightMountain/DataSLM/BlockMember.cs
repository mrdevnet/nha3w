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
    public class DaBlockMember
    {
        public DaBlockMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertBlock(EnBlockMember mbr)
        {
            string strCommandText = "insBlockMembers";
            SqlParameter[] paraLocal = new SqlParameter[6];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@Status", mbr.Status);
            paraLocal[2] = new SqlParameter("@Start", mbr.Start);
            paraLocal[3] = new SqlParameter("@Finish", mbr.Finish);
            paraLocal[4] = new SqlParameter("@Reason", mbr.Reason);
            paraLocal[5] = new SqlParameter("@Moderator", mbr.Moderator);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectBlockMembers(ref EnBlockMember mbr)
        {
            string strCommandText = "selBlockMembers";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            SqlDataReader datrBlock = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            mbr = CreateBlock(datrBlock);
            if (datrBlock.IsClosed == false)
            {
                datrBlock.Close();
                datrBlock.Dispose();
            }
        }

        private EnBlockMember CreateBlock(IDataReader datrMbr)
        {
            EnBlockMember blcMbr = new EnBlockMember();
            while (datrMbr.Read())
            {
                blcMbr.BlockId = int.Parse(datrMbr["BlockId"].ToString());
                blcMbr.Status = bool.Parse(datrMbr["Status"].ToString());
                blcMbr.Start = DateTime.Parse(datrMbr["Start"].ToString());
                blcMbr.Finish = DateTime.Parse(datrMbr["Finish"].ToString());
                blcMbr.Reason = datrMbr["Reason"].ToString();
                blcMbr.Moderator = int.Parse(datrMbr["Moderator"].ToString());
            }
            return blcMbr;
        }

        public DataTable SelectBlockMembers()
        {
            string strCommandText = "selAllBlockMembers";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void DeleteBlockMember(EnBlockMember blc)
        {
            string strCommandText = "delBlockMember";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", blc.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

    }
}