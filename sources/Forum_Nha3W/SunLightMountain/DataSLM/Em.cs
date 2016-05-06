using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.Utility;

namespace SLMF.DataAccess
{
    public class DaEm
    {
        public DaEm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertEm(EnMember mbr1, EnMember mbr2, EnEm em)
        {
            string strCommandText = "insEmail";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@FromMember", mbr1.UserName);
            paraLocal[1] = new SqlParameter("@ToMember", mbr2.UserName);
            paraLocal[2] = new SqlParameter("@Title", em.Title);
            paraLocal[3] = new SqlParameter("@Message", em.Message);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }
    }
}
