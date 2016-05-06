using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DTransIO
    {
        public DTransIO()
        {
        }

        public void ITransIn(ETransIn tr)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter("@TypeId", tr.TypeId);
            pr[1] = new SqlParameter("@Total", tr.Total);
            pr[2] = new SqlParameter("@MemberId", tr.MemberId);
            pr[3] = new SqlParameter("@IP", tr.IP);
            pr[4] = new SqlParameter("@ByMember", tr.ByMember);
            pr[5] = new SqlParameter("@Number", tr.NumberP);
            pr[6] = new SqlParameter("@Pid", tr.PostId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihWallets", pr);
        }

        public int MyWallet(string Uid)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", Uid);
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shWll3", pr);
            r.Read();
            int i = 0;
            if (r.HasRows) i = int.Parse(r["Total"].ToString());
            if (!r.IsClosed)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }

        public string ITransOut(ETransIn tr)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@TypeId", tr.TypeId);
            pr[1] = new SqlParameter("@Total", tr.Total);
            pr[2] = new SqlParameter("@IP", tr.IP);
            pr[3] = new SqlParameter("@ByMember", tr.ByMember);
            pr[4] = new SqlParameter("@Pid", tr.PostId);
            pr[5] = new SqlParameter("@Resp", SqlDbType.NVarChar,500);
            pr[5].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihWallets2", pr);
            return pr[5].Value.ToString();
        }

    }
}

