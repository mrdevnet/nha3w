using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DProjects
    {
        public DProjects()
        {
        }

        public List<EProjects> LstProjects(EProjects w)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@dt", w.DistrictId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPtn", pr))
            {
                List<EProjects> p = new List<EProjects>();
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

        private EProjects Ct(IDataReader i)
        {
            EProjects p = new EProjects();
            p.ProjectId = (int)i["ProjectId"];
            p.ProjectName = (string)i["ProjectName"];
            return p;
        }

        public DataTable AProjects(ECities c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@CityId", c.CityId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shProjects", pr);
        }

        public void IProjects(EProjects p)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@ProjectName", p.ProjectName);
            pr[1] = new SqlParameter("@DistrictId", p.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihProjects", pr);
        }

        public DataTable AProjects2(EProjects c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@DistrictId", c.DistrictId);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shProjects2", pr);
        }

        public void EProjects(EProjects c)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ProjectId", c.ProjectId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhProjects", pr);
        }

        public void UProjects(EProjects c)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@ProjectId", c.ProjectId);
            pr[1] = new SqlParameter("@ProjectName", c.ProjectName);
            pr[2] = new SqlParameter("@DistrictId", c.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhProjects", pr);
        }

    }
}