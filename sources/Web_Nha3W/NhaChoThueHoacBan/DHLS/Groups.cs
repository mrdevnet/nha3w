using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DGroups
    {
        public DGroups()
        {
        }

        public DataTable AGroups()
        {
            string strCommandText = "shGroups";
            return HLSPro.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void IGroups(EGroups c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@GroupName", c.GroupName);
            pr[1] = new SqlParameter("@Posts", c.Posts);
            pr[2] = new SqlParameter("@Rank", c.Rank);
            pr[3] = new SqlParameter("@Pm", c.Pm);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihGroups", pr);
        }

        public void EGroups(EGroups c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@GroupId", c.GroupId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhGroups", pr);
        }

        public void UGroups(EGroups c)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@GroupId", c.GroupId);
            pr[1] = new SqlParameter("@GroupName", c.GroupName);
            pr[2] = new SqlParameter("@Posts", c.Posts);
            pr[3] = new SqlParameter("@Pm", c.Pm);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhGroups", pr);
        }


    }
}