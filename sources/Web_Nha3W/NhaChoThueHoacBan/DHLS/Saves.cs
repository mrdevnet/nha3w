using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DSaves
    {
        public DSaves()
        {
        }

        public int ASaves(EMember r)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Mbr", r.UserName);
            SqlDataReader c = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shMSaves", pr);
            int a =0;
            if (c.Read()) a = int.Parse(c[0].ToString());
            if (!c.IsClosed)
            {
                c.Close();
                c.Dispose();
            }
            return a;
        }

    }
}

