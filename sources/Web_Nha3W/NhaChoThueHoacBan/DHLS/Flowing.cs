using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DFlowing
    {
        public DFlowing()
        {
        }

        public int IFlowing(EFlowing m)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter("@MemberId", m.UserName);
            pr[1] = new SqlParameter("@ToMember", m.ToMember);
            pr[2] = new SqlParameter("@Flws", m.Flws);
            pr[3] = new SqlParameter("@Approves", m.Approves);
            pr[4] = new SqlParameter("@Blocks", m.Blocks);
            pr[5] = new SqlParameter("@Spams", m.Spams);
            pr[6] = new SqlParameter("@Removes", m.Removes);
            pr[7] = new SqlParameter("@Type", m.Type);
            pr[8] = new SqlParameter("@Result", SqlDbType.SmallInt);
            pr[8].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihFrds", pr);
            return int.Parse(pr[8].Value.ToString());
        }

        public void UFlws(EFlowing m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@Id", m.MemberId);
            pr[1] = new SqlParameter("@User", m.UserName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhAproMbrs", pr);
        }

        public void ITr4u(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@LstId", m.ListId);
            pr[1] = new SqlParameter("@MemberId", m.MemberId);
            pr[2] = new SqlParameter("@CheckIn", m.CheckIn);
            pr[3] = new SqlParameter("@CheckOut", m.CheckOut);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihTrcks4u", pr);
        }

        public EFlowing SFlowing(EFlowing m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", m.UserName);
            pr[1] = new SqlParameter("@ToMember", m.ToMember);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shFlSta", pr))
            {
                if (r.Read())
                {
                    m = Pro(r);
                }
                else m.MemberId = -1;
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return m;
            }
        }

        public List<ETracks> LstTr4u(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            pr[1] = new SqlParameter("@User", m.IName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLstTckFlws3", pr))
            {
                List<ETracks> p = new List<ETracks>();
                while (r.Read())
                {
                    p.Add(Tr4u(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<ETracks> LstTr4u3(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            pr[1] = new SqlParameter("@User", m.IName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLstTckFlws", pr))
            {
                List<ETracks> p = new List<ETracks>();
                while (r.Read())
                {
                    p.Add(Tr4u3(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<ETracks> LstTr4u4(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLstTckFlws2", pr))
            {
                List<ETracks> p = new List<ETracks>();
                while (r.Read())
                {
                    p.Add(Tr4u3(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private ETracks Tr4u3(IDataReader i)
        {
            ETracks p = new ETracks();
            p.ListId = (int)i["lstid"];
            p.LstName = (string)i["LstName"];
            p.LstDesc = (string)i["LstDesc"];
            p.Prive = (bool)i["Prive"];
            if (i["Flwc"] != null && i["Flwc"].ToString() !="") p.Flwc = (int)i["Flwc"];
            if (i["Flrc"] != null && i["Flrc"].ToString() != "") p.Flrc = (int)i["Flrc"];
            p.MemberId = (int)i["MemberId"];
            p.IName = (string)i["UserName"];
            p.Logo = (string)i["Logo"];
            return p;
        }

        private ETracks Tr4u(IDataReader i)
        {
            ETracks p = new ETracks();
            p.ListId = (int)i["lstid"];
            p.LstName = (string)i["LstName"];
            p.LstDesc = (string)i["LstDesc"];
            return p;
        }

        private EFlowing Pro(IDataReader i)
        {
            EFlowing p = new EFlowing();
            if (i["Flws"] != null && i["Flws"].ToString() != "") p.Flws = (bool)i["Flws"];
            if (i["Approves"] != null && i["Approves"].ToString() != "") p.Approves = (bool)i["Approves"];
            if (i["Blocks"] != null && i["Blocks"].ToString() != "") p.Blocks = (bool)i["Blocks"];
            if (i["Blcked"] != null && i["Blcked"].ToString() != "") p.BlockEd = (bool)i["Blcked"];
            if (i["Spams"] != null && i["Spams"].ToString() != "") p.Spams = (bool)i["Spams"];
            if (i["Removes"] != null && i["Removes"].ToString() != "") p.Removes = (bool)i["Removes"];
            if (i["FlAt"] != null && i["FlAt"].ToString() != "") p.FlAt = (DateTime)i["FlAt"];
            if (i["BLockAt"] != null && i["BLockAt"].ToString() != "") p.BLockAt = (DateTime)i["BLockAt"];
            if (i["SpamAt"] != null && i["SpamAt"].ToString() != "") p.SpamAt = (DateTime)i["SpamAt"];
            if (i["AproAt"] != null && i["AproAt"].ToString() != "") p.AproAt = (DateTime)i["AproAt"];
            if (i["RevAt"] != null && i["RevAt"].ToString() != "") p.RevAt = (DateTime)i["RevAt"];
            return p;
        }

        public List<EAnas> LstMFrs(EFlowing f)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@User", f.UserName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsMFrs", pr))
            {
                List<EAnas> p = new List<EAnas>();
                while (r.Read())
                {
                    p.Add(Frs(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EAnas> LstMFrs2(EFlowing f)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@User", f.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsMFrs2", pr))
            {
                List<EAnas> p = new List<EAnas>();
                while (r.Read())
                {
                    p.Add(Frs(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EAnas Frs(IDataReader i)
        {
            EAnas p = new EAnas();
            p.MI = (int)i["ToMember"];
            p.UR = (string)i["UserName"];
            if (i["Logo"] != null && i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            return p;
        }

        public EPFiles PFiles(EPFiles m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shFiles", pr))
            {
                if (r.Read())
                {
                    m = Pfs(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return m;
            }
        }

        private EPFiles Pfs(IDataReader i)
        {
            EPFiles p = new EPFiles();
            if (i["FlCount"] != null) p.FlCount = (int)i["FlCount"];
            if (i["FrCount"] != null) p.FrCount= (int)i["FrCount"];
            if (i["LstRCount"] != null) p.LstRCount = (int)i["LstRCount"];
            if (i["LstFCount"] != null) p.LstFCount = (int)i["LstFCount"];
            if (i["MsgCount"] != null) p.MsgCount = (int)i["MsgCount"];
            if (i["Prive"] != null) p.Prive = (bool)i["Prive"];
            if (i["Status"] != null && i["Status"].ToString() != "") p.Status = (int)i["Status"];
            if (i["Talk"] != null && i["Talk"].ToString() != "") p.Talk = (string)i["Talk"];
            if (i["TalkDate"] != null && i["TalkDate"].ToString() != "") p.TalkDate = (DateTime)i["TalkDate"];
            if (i["Aur"] != null && i["Aur"].ToString() != "") p.AutId = (int)i["Aur"];
            if (i["UserName"] != null && i["UserName"].ToString() != "") p.AutName = (string)i["UserName"];
            if (i["Via"] != null && i["Via"].ToString() != "") p.Via = (string)i["Via"];
            return p;
        }

        public List<EAnas> LstTpMrs()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsTpMrs", null))
            {
                List<EAnas> p = new List<EAnas>();
                while (r.Read())
                {
                    p.Add(TpMrs(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EAnas TpMrs(IDataReader i)
        {
            EAnas p = new EAnas();
            p.MI = (int)i["MemberId"];
            p.UR = (string)i["UserName"];
            if (i["Logo"] != null && i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            return p;
        }

        public List<EFlowing> LstFlwings(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Id", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsMFrsal", pr))
            {
                List<EFlowing> p = new List<EFlowing>();
                while (r.Read())
                {
                    p.Add(Flwis(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EFlowing> LstFlwings3(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Id", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsMFrsal3", pr))
            {
                List<EFlowing> p = new List<EFlowing>();
                while (r.Read())
                {
                    p.Add(Flwis(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EFlowing> LstAproMbrs(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Id", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shIsMFrsal6", pr))
            {
                List<EFlowing> p = new List<EFlowing>();
                while (r.Read())
                {
                    p.Add(Flwis(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EFlowing Flwis(IDataReader i)
        {
            EFlowing p = new EFlowing();
            p.ToMember = (int)i["ToMember"];
            p.UserName = (string)i["UserName"];
            if (i["FullName"] != null && i["FullName"].ToString() != "") p.FullName = (string)i["FullName"];
            if (i["Address"] != null && i["Address"].ToString() != "") p.Address = (string)i["Address"];
            p.Flws = (bool)i["flws"];
            p.Approves = (bool)i["approves"];
            if (i["colors"] != null && i["colors"].ToString() != "") p.Color = (string)i["colors"];
            if (i["fdate"] != null && i["fdate"].ToString() != "") p.Fdate = (DateTime)i["fdate"];
            if (i["Logo"] != null && i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            p.Prive = (bool)i["prive"];
            return p;
        }


    }
}

