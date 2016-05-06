using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DViolations
    {
        public DViolations()
        {
        }

        public void IVios(EViolations c, EMember r)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@PostId", c.PostId);
            pr[1] = new SqlParameter("@MemberId", r.UserName);
            pr[2] = new SqlParameter("@Message", c.Message);
            pr[3] = new SqlParameter("@IP", c.IP);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihVios", pr);
        }


    }
}

