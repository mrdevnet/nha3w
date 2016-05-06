using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DColors
    {
        public DColors()
        {
        }

        public void IColors(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@Colors", m.Colors);
            pr[1] = new SqlParameter("@MemberId", m.MemberId);
            pr[2] = new SqlParameter("@Author", m.AutName);
            pr[3] = new SqlParameter("@Via", m.Via);
            pr[4] = new SqlParameter("@Hash", m.Hash);
            pr[5] = new SqlParameter("@IP", m.IP);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihClrs", pr);
        }

        public void IColors2(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@ColorId", m.ColorId);
            pr[1] = new SqlParameter("@Title", m.Colors);
            pr[2] = new SqlParameter("@MemberId", m.AutName);
            pr[3] = new SqlParameter("@IP", m.IP);
            pr[4] = new SqlParameter("@Via", m.Via);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihColorCmts", pr);
        }

        public List<EColors> LstColors(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            pr[1] = new SqlParameter("@To", m.AutName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shColrsFr", pr))
            {
                List<EColors> p = new List<EColors>();
                while (r.Read())
                {
                    p.Add(Ctc(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EColors> LstColors4(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", m.ListId);
            pr[1] = new SqlParameter("@To", m.IName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shColrsFr4", pr))
            {
                List<EColors> p = new List<EColors>();
                while (r.Read())
                {
                    p.Add(Ctc(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EColors> LstClrFavs(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MemberId", m.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shClrFv1", pr))
            {
                List<EColors> p = new List<EColors>();
                while (r.Read())
                {
                    p.Add(Ctc(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EColors Ctc(IDataReader i)
        {
            EColors p = new EColors();
            p.ColorId = (int)i["MsgId"];
            p.Colors = (string)i["Colors"];
            p.Author = (int)i["Author"];
            p.AutName = (string)i["UserName"];
            p.CrDate = (DateTime)i["CrDate"];
            p.Via = (string)i["Via"];
            p.Hash = (string)i["Hash"];
            if (i["Logo"] != null && i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            p.N3w = int.Parse(i["n3w"].ToString());
            p.MemberId = (int)i["MemberId"];
            //if (i["ColorDate"] != null && i["ColorDate"].ToString() != "") p.ColorDate = (DateTime)i["ColorDate"];
            return p;
        }

        public List<EColorMbrs> LstClrMrs(EColorMbrs m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.ColorId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shClrMrs", pr))
            {
                List<EColorMbrs> p = new List<EColorMbrs>();
                while (r.Read())
                {
                    p.Add(Ctc2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EColorMbrs Ctc2(IDataReader i)
        {
            EColorMbrs p = new EColorMbrs();
            p.UserName = (string)i["UserName"];
            p.MemberId = (int)i["MemberId"];
            p.ColorDate = (DateTime)i["ColorDate"];
            return p;
        }

        public void FColors(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.ColorId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhClrs", pr);
        }

        public void UColors(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@clrId", m.ColorId);
            pr[1] = new SqlParameter("@user", m.AutName);
            pr[2] = new SqlParameter("@IP", m.IP);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihClrMbrs", pr);
        }

        public void IFavs(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@clrId", m.ColorId);
            pr[1] = new SqlParameter("@user", m.AutName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihFavs", pr);
        }

        public List<EColorMbrs> LstClrFavs(EColorMbrs m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.ColorId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shClrFva", pr))
            {
                List<EColorMbrs> p = new List<EColorMbrs>();
                while (r.Read())
                {
                    p.Add(Ctc3(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EColorMbrs Ctc3(IDataReader i)
        {
            EColorMbrs p = new EColorMbrs();
            p.UserName = (string)i["UserName"];
            p.MemberId = (int)i["MemberId"];
            p.ColorDate = (DateTime)i["CrtDate"];
            return p;
        }

        public List<EColors> LstClrCmts(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.ColorId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shClrCmts", pr))
            {
                List<EColors> p = new List<EColors>();
                while (r.Read())
                {
                    p.Add(Ctc4(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EColors> LstClrCmts3(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.ColorId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shClrCmts3", pr))
            {
                List<EColors> p = new List<EColors>();
                while (r.Read())
                {
                    p.Add(Ctc4(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EColors Ctc4(IDataReader i)
        {
            EColors p = new EColors();
            p.CommentId = (int)i["CmtId"];
            p.ColorId = (int)i["ColorId"];
            p.Colors = (string)i["Title"];
            p.CrDate = (DateTime)i["CrtDate"];
            p.Author = (int)i["MemberId"];
            p.IP = (string)i["IP"];
            p.Via = (string)i["Via"];
            p.AutName = (string)i["UserName"];
            if (i["Logo"] != null && i["Logo"].ToString() !="") p.Logo = (string)i["Logo"];
            p.MemberId = (int)i["WId"];
            p.Author2 = (int)i["Author"];
            return p;
        }

        public void FColors2(EColors m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@urid", m.AutName);
            pr[1] = new SqlParameter("@clrid", m.CommentId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhClrCmts", pr);
        }

        public int F2c(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@clrid", i);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shCmtsCnts", pr))
            {
                if (r.Read())
                {
                    i = int.Parse(r[0].ToString());
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return i;
            }
        }

        public void ItrIFlw(ETracks m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@LstId", m.ListId);
            pr[1] = new SqlParameter("@Mbr", m.IName);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihTrcksi4u", pr);
        }


    }
}
