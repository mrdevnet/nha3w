using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DAuthorizations
    {
        public DAuthorizations()
        {
        }

        public EAuthorizations Authors(EGroups m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@GroupId", m.GroupId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shAuthorizations", pr))
            {
                EAuthorizations pros = new EAuthorizations();
                if (r.Read())
                {
                    pros = Pro(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        public EAuthorizations Authors2(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UserName", m.UserName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shAuthorMbr", pr))
            {
                EAuthorizations pros = new EAuthorizations();
                if (r.Read())
                {
                    pros = Pro(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        private EAuthorizations Pro(IDataReader i)
        {
            EAuthorizations p = new EAuthorizations();
            p.Post = (bool)i["Post"];
            p.Edit = (bool)i["Edit"];
            p.Del = (bool)i["Del"];
            p.IsApproved = (bool)i["IsApproved"];
            p.Comment = (bool)i["Comment"];
            p.PM = (bool)i["PM"];
            p.Email = (bool)i["Email"];
            p.Alert = (bool)i["Alert"];
            p.Call = (bool)i["Call"];
            p.Save = (bool)i["Saves"];
            p.Vote = (bool)i["Vote"];
            p.Rate = (bool)i["Rate"];
            p.Upload = (bool)i["Upload"];
            p.Size = (int)i["Size"];
            p.Files = (int)i["Files"];
            p.ViewProfile = (bool)i["ViewProfile"];
            p.HideProfile = (bool)i["HideProfile"];
            p.Up = (bool)i["Up"];
            p.CountUp = (int)i["CountUp"];
            p.Vip = (bool)i["Vip"];
            p.IP = (bool)i["IP"];
            p.Download = (bool)i["Download"];
            p.Approve = (bool)i["Approve"];
            p.CVip = (int)i["CVip"];
            p.CIp = (int)i["CIp"];
            p.Renew = (bool)i["Renew"];
            return p;
        }

        public void UAuthors(EAuthorizations c)
        {
            SqlParameter[] pr = new SqlParameter[27];
            pr[0] = new SqlParameter("@GroupId", c.GroupId);
            pr[1] = new SqlParameter("@Post", c.Post);
            pr[2] = new SqlParameter("@Edit", c.Edit);
            pr[3] = new SqlParameter("@Del", c.Del);
            pr[4] = new SqlParameter("@IsApproved", c.IsApproved);
            pr[5] = new SqlParameter("@Comment", c.Comment);
            pr[6] = new SqlParameter("@PM", c.PM);
            pr[7] = new SqlParameter("@Email", c.Email);
            pr[8] = new SqlParameter("@Alert", c.Alert);
            pr[9] = new SqlParameter("@Call", c.Call);
            pr[10] = new SqlParameter("@Saves", c.Save);
            pr[11] = new SqlParameter("@Vote", c.Vote);
            pr[12] = new SqlParameter("@Rate", c.Rate);
            pr[13] = new SqlParameter("@Upload", c.Upload);
            pr[14] = new SqlParameter("@Size", c.Size);
            pr[15] = new SqlParameter("@Files", c.Files);
            pr[16] = new SqlParameter("@ViewProfile", c.ViewProfile);
            pr[17] = new SqlParameter("@HideProfile", c.HideProfile);
            pr[18] = new SqlParameter("@Up", c.Up);
            pr[19] = new SqlParameter("@CountUp", c.CountUp);
            pr[20] = new SqlParameter("@Vip", c.Vip);
            pr[21] = new SqlParameter("@IP", c.IP);
            pr[22] = new SqlParameter("@Download", c.Download);
            pr[23] = new SqlParameter("@Approve", c.Approve);
            pr[24] = new SqlParameter("@CVip", c.CVip);
            pr[25] = new SqlParameter("@CIp", c.CIp);
            pr[26] = new SqlParameter("@Renew", c.Renew);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhAuthorizations", pr);
        }



    }
}
