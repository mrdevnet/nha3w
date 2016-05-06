using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DSets
    {
        public DSets()
        {
        }

        public List<ESets> LstSets()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shStn", null))
            {
                List<ESets> p = new List<ESets>();
                while (r.Read())
                {
                    p.Add(Ct(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private ESets Ct(IDataReader i)
        {
            ESets p = new ESets();
            p.SetId = (int)i["SetId"];
            p.SetName = (string)i["SetName"];
            return p;
        }

        public void ISaved(EMember c,int PostId)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", c.UserName);
            pr[1] = new SqlParameter("@PostId", PostId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihSaved", pr);
        }

        public bool ASaved(EMember c, int PostId)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@MemberId", c.UserName);
            pr[1] = new SqlParameter("@PostId", PostId);
            pr[2] = new SqlParameter("@Result", SqlDbType.SmallInt);
            pr[2].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shSaved", pr);
            if (int.Parse(pr[2].Value.ToString()) == 1) return true;
            return false;
        }


    }
}

