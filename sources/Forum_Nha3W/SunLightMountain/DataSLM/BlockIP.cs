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
    public class DaBlockIP
    {
        public DaBlockIP()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertBlockIP(EnBlockIP ip)
        {
            string strCommandText = "insBlockIP";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@IP", ip.IP);
            paraLocal[1] = new SqlParameter("@Status", ip.Status);
            paraLocal[2] = new SqlParameter("@DateBlock", ip.DateBlock);
            paraLocal[3] = new SqlParameter("@Reason", ip.Reason);
            paraLocal[4] = new SqlParameter("@Moderator", ip.Moderator);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectBlockIP(ref EnBlockIP ip)
        {
            string strCommandText = "selBlockIP";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@IP", ip.IP);
            SqlDataReader datrBlock = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            ip = CreateBlock(datrBlock);
            if (datrBlock.IsClosed == false)
            {
                datrBlock.Close();
                datrBlock.Dispose();
            }
        }

        private EnBlockIP CreateBlock(IDataReader datrMbr)
        {
            EnBlockIP ip = new EnBlockIP();
            while (datrMbr.Read())
            {
                ip.BlockId = int.Parse(datrMbr["BlockId"].ToString());
                ip.Status = bool.Parse(datrMbr["Status"].ToString());
                ip.DateBlock = DateTime.Parse(datrMbr["DateBlock"].ToString());
                ip.Reason = datrMbr["Reason"].ToString();
                ip.Moderator = int.Parse(datrMbr["Moderator"].ToString());
            }
            return ip;
        }

        public DataTable SelectBlockIP()
        {
            string strCommandText = "selAllBlockIP";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void DeleteBlockIP(EnBlockIP ip)
        {
            string strCommandText = "delBlockIP";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@IP", ip.IP);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public bool IPIsBlock(EnBlockIP ip)
        {
            string strCommandText = "selIpIsLocked";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@IP", ip.IP);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[1].Value.ToString());
        }



    }
}