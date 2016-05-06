using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;

namespace SLMF.DataAccess
{
    public class DaPriority
    {
        public DaPriority()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectPriority()
        {
            string strCommandText = "selPriority";
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            return datrCate;
        }

        public DataTable SelectAllPrio()
        {
            string strCommandText = "selAllPriority";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }


    }

}
