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
using SLMF.Utility;

namespace SLMF.DataAccess
{
    public class DaPm
    {
        public DaPm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectPm(EnMember mbr)
        {
            DataTable dttp = new DataTable();
            string strCommandText = "selPmIsRead";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            dttp = SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
            return dttp;
        }

        public EnPm SelectPmMessage(int intId)
        {
            string strCommandText = "selPmMessage";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@PmId", intId);
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            EnPm pnew = new EnPm();
            pnew = CreateMemberId(r);
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return pnew;
        }

        private EnPm CreateMemberId(IDataReader reader)
        {
            EnPm pmnew = new EnPm();
            if (reader.Read())
            {
                pmnew.Message = reader["Message"].ToString();
                pmnew.Title = reader["Title"].ToString();
                pmnew.Sent = DateTime.Parse(reader["Sent"].ToString());
            }
            return pmnew;
        }

        public void UpdatePmRead(int intId)
        {
            string strCommandText = "updPmRead";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@PmId", intId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeletePm(int intId)
        {
            string strCommandText = "delPm";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@PmId", intId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectPmFrMember(EnMember mbr)
        {
            DataTable dttp = new DataTable();
            string strCommandText = "selPmFromMember";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            dttp = SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
            return dttp;
        }

        public SqlDataReader SelectFindPm(EnMember mbr)
        {
            string strCommandText = "selPmFind";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@Find", mbr.UserName);
            SqlDataReader t = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return t;
        }

        public void InsertPm(EnMember mbr1, EnMember mbr2, EnPm pm)
        {
            string strCommandText = "insPmNew";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@FromMember", mbr1.UserName);
            paraLocal[1] = new SqlParameter("@ToMember", mbr2.UserName);
            paraLocal[2] = new SqlParameter("@Title", pm.Title);
            paraLocal[3] = new SqlParameter("@Message", pm.Message);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public bool PmIsView(EnMember mbr, ref int pn)
        {
            string strCommandText = "selPmNIsView";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@User", mbr.UserName);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@IsNew", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            bool a = bool.Parse(paraLocal[1].Value.ToString());
            pn = int.Parse(paraLocal[2].Value.ToString());
            return a;
        }
    }
}
