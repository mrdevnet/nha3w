using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DPosts
    {
        public DPosts()
        {
        }

        private EPosts Posts(IDataReader i)
        {
            EPosts p = new EPosts();
            //p.PostId = (int)i["PostId"];
            p.Title = (string)i["Title"];
            p.CategoryId = (int)i["CategoryId"];
            p.CateName = (string)i["CateName"];
            p.IsOwner = (bool)i["IsOwner"];
            p.ClassId = (int)i["ClassId"];
            p.ClassName = (string)i["ClassName"];
            p.LocationId = (int)i["LocationId"];
            p.LocaName = (string)i["LocaName"];
            p.CountryId = (int)i["CountryId"];
            p.CityId = (int)i["CityId"];
            p.CityName = (string)i["CityName"];
            p.DistrictId = (int)i["DistrictId"];
            p.DistrictName = (string)i["DistrictName"];
            p.WardId = (int)i["WardId"];
            if (i["WardName"].ToString() != "") p.WardName = (string)i["WardName"];
            if (i["StreetId"].ToString() != "") p.StreetId = (int)i["StreetId"];
            if (i["StreetName"].ToString() != "") p.StreetName = (string)i["StreetName"];
            if (i["StrName"].ToString() != "") p.StrName = (string)i["StrName"];
            p.LotNumber = (string)i["LotNumber"];
            p.HideNumber = (bool)i["HideNumber"];
            if (i["ProjectId"].ToString() != "") p.ProjectId = (int)i["ProjectId"];
            if (i["ProjectName"].ToString() != "") p.ProjectName = (string)i["ProjectName"];
            if (i["ProName"].ToString() != "") p.ProName = (string)i["ProName"];
            p.Values = float.Parse(i["Value"].ToString());
            p.CurrencyId = (int)i["CurrencyId"];
            p.CurrencyName = (string)i["CurrencyName"];
            p.UnitId = (int)i["UnitId"];
            p.UnitName = (string)i["UnitName"];
            p.Percents = (int)i["Percents"];
            p.Area = float.Parse(i["Area"].ToString());
            p.Width = (string)i["Width"];
            p.Length = (string)i["Length"];
            p.Description = (string)i["Description"];
            p.HaveHouses = (bool)i["HaveHouses"];
            if (i["Houses"].ToString() != "") p.Images = (string)i["Houses"];
            //p.MapId = (int)i["MapId"];
            p.MemberId = (int)i["MemberId"];
            p.UserName = (string)i["UserName"];
            //p.VideoId = (int)i["VideoId"];
            p.IsVip = (bool)i["IsVip"];
            p.ContactId = (int)i["ContactId"];
            p.ContactName = (string)i["ContactName"];
            p.Tel = (string)i["Tel"];
            p.Mobile = (string)i["Mobile"];
            p.Address = (string)i["Address"];
            p.Notes = (string)i["Notes"];
            p.CreationDate = (DateTime)i["CreationDate"];
            p.Updated = (DateTime)i["Updated"];
            p.Expiration = (DateTime)i["Expiration"];
            if (p.Views>0) p.Views = int.Parse(i["Views"].ToString());
            p.IP = (string)i["IP"];
            p.DateApproved = (DateTime)i["DateApproved"];
            if (p.ByMember.ToString() != "" && p.ByMember >0) p.ByMember = (int)i["ByMember"];
            if (p.ByAuthor != null) p.ByAuthor = (string)i["ByAuthor"];
            p.StateId = (int)i["StateId"];
            p.StateName = (string)i["StateName"];
            p.Silver = (bool)i["Silver"];
            return p;
        }

        private EPosts Posts2(IDataReader i)
        {
            EPosts p = new EPosts();
            p.PostId = (int)i["PostId"];
            p.Title = (string)i["Title"];
            p.CategoryId = (int)i["CategoryId"];
            p.CateName = (string)i["CateName"];
            p.IsOwner = (bool)i["IsOwner"];
            p.ClassId = (int)i["ClassId"];
            p.ClassName = (string)i["ClassName"];
            //p.LocationId = (int)i["LocationId"];
            //p.CountryId = (int)i["CountryId"];
            p.CityId = (int)i["CityId"];
            p.CityName = (string)i["CityName"];
            p.DistrictId = (int)i["DistrictId"];
            p.DistrictName = (string)i["DistrictName"];
            p.WardId = (int)i["WardId"];
            if (i["WardName"].ToString() != "") p.WardName = (string)i["WardName"];
            p.StreetId = (int)i["StreetId"];
            if (i["Name"].ToString() != "") p.StreetName = (string)i["Name"];
            p.LotNumber = (string)i["LotNumber"];
            p.HideNumber = (bool)i["HideNumber"];
            //p.ProjectId = (int)i["ProjectId"];
            //p.ProjectName = (string)i["ProjectName"];
            p.Values = float.Parse(i["Value"].ToString());
            p.CurrencyId = (int)i["CurrencyId"];
            p.UnitId = (int)i["UnitId"];
            //p.Percents = (int)i["Percents"];
            p.Area = float.Parse(i["Area"].ToString());
            p.Width = (string)i["Width"];
            p.Length = (string)i["Length"];
            //p.Description = (string)i["Description"];
            p.HaveHouses = (bool)i["HaveHouses"];
            //p.MapId = (int)i["MapId"];
            //p.MemberId = (int)i["MemberId"];
            //p.VideoId = (int)i["VideoId"];
            p.IsVip = (bool)i["IsVip"];
            //p.ContactId = (int)i["ContactId"];
            p.CreationDate = (DateTime)i["CreationDate"];
            p.Updated = (DateTime)i["Updated"];
            p.Silver = (bool)i["Silver"];
            //p.Expiration = (DateTime)i["Expiration"];
            //p.Views = (int)i["Views"];
            //p.IP = (string)i["IP"];
            //p.DateApproved = (DateTime)i["DateApproved"];
            //p.ByMember = (int)i["ByMember"];
            //p.StateId = (int)i["StateId"];
            return p;
        }

        public int IPost(EPosts ps,EProperties pro)
        {
            SqlParameter[] pr = new SqlParameter[42];
            pr[0] = new SqlParameter("@Title", ps.Title);
            pr[1] = new SqlParameter("@CategoryId", ps.CategoryId);
            pr[2] = new SqlParameter("@IsOwner", ps.IsOwner);
            pr[3] = new SqlParameter("@ClassId", ps.ClassId);
            pr[4] = new SqlParameter("@LocationId", ps.LocationId);
            pr[5] = new SqlParameter("@CountryId", ps.CountryId);
            pr[6] = new SqlParameter("@CityId", ps.CityId);
            pr[7] = new SqlParameter("@DistrictId", ps.DistrictId);
            pr[8] = new SqlParameter("@WardId", ps.WardId);
            pr[9] = new SqlParameter("@StreetId", ps.StreetId);
            pr[10] = new SqlParameter("@LotNumber", ps.LotNumber);
            if (ps.ProjectId != 0) pr[11] = new SqlParameter("@ProjectId", ps.ProjectId);
            else pr[11] = new SqlParameter("@ProjectId", null);
            pr[12] = new SqlParameter("@Value", ps.Values);
            pr[13] = new SqlParameter("@CurrencyId", ps.CurrencyId);
            pr[14] = new SqlParameter("@UnitId", ps.UnitId);
            pr[15] = new SqlParameter("@Percents", ps.Percents);
            pr[16] = new SqlParameter("@Area", ps.Area);
            pr[17] = new SqlParameter("@Width", ps.Width);
            pr[18] = new SqlParameter("@Length", ps.Length);
            pr[19] = new SqlParameter("@Description", ps.Description);
            pr[20] = new SqlParameter("@HaveHouses", ps.HaveHouses);
            pr[21] = new SqlParameter("@UserName", ps.UserName);
            pr[22] = new SqlParameter("@IsVip", ps.IsVip);
            pr[23] = new SqlParameter("@Expiration", ps.Expiration);
            pr[24] = new SqlParameter("@IP", ps.IP);
            pr[25] = new SqlParameter("@ByUser", ps.ByUser);
            pr[26] = new SqlParameter("@StateId", ps.StateId);
            pr[27] = new SqlParameter("@Silver", ps.Silver);
            pr[28] = new SqlParameter("@ContactName", ps.ContactName);
            pr[29] = new SqlParameter("@Tel", ps.Tel);
            pr[30] = new SqlParameter("@Mobile", ps.Mobile);
            pr[31] = new SqlParameter("@Address", ps.Address);
            pr[32] = new SqlParameter("@Notes", ps.Notes);
            if (pro.DocId != 0) pr[33] = new SqlParameter("@DocId", pro.DocId);
            else pr[33] = new SqlParameter("@DocId", null);
            pr[34] = new SqlParameter("@Floor", pro.Floor);
            pr[35] = new SqlParameter("@SittingRoom", pro.SittingRoom);
            pr[36] = new SqlParameter("@BedRoom", pro.BedRoom);
            pr[37] = new SqlParameter("@BathRoom", pro.BathRoom);
            if (pro.SetId != 0) pr[38] = new SqlParameter("@SetId", pro.SetId);
            else pr[38] = new SqlParameter("@SetId", null);
            pr[39] = new SqlParameter("@SizeOfLane", pro.SizeOfLane);
            pr[40] = new SqlParameter("@Othr", pro.Other);
            pr[41] = new SqlParameter("@PId", SqlDbType.Int);
            pr[41].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihPts", pr);
            return int.Parse(pr[41].Value.ToString());
        }

        public void UPost(EPosts ps, EProperties pro)
        {
            SqlParameter[] pr = new SqlParameter[42];
            pr[0] = new SqlParameter("@Title", ps.Title);
            pr[1] = new SqlParameter("@CategoryId", ps.CategoryId);
            pr[2] = new SqlParameter("@IsOwner", ps.IsOwner);
            pr[3] = new SqlParameter("@ClassId", ps.ClassId);
            pr[4] = new SqlParameter("@LocationId", ps.LocationId);
            pr[5] = new SqlParameter("@CountryId", ps.CountryId);
            pr[6] = new SqlParameter("@CityId", ps.CityId);
            pr[7] = new SqlParameter("@DistrictId", ps.DistrictId);
            pr[8] = new SqlParameter("@WardId", ps.WardId);
            pr[9] = new SqlParameter("@StreetId", ps.StreetId);
            pr[10] = new SqlParameter("@LotNumber", ps.LotNumber);
            if (ps.ProjectId != 0) pr[11] = new SqlParameter("@ProjectId", ps.ProjectId);
            else pr[11] = new SqlParameter("@ProjectId", null);
            pr[12] = new SqlParameter("@Value", ps.Values);
            pr[13] = new SqlParameter("@CurrencyId", ps.CurrencyId);
            pr[14] = new SqlParameter("@UnitId", ps.UnitId);
            pr[15] = new SqlParameter("@Percents", ps.Percents);
            pr[16] = new SqlParameter("@Area", ps.Area);
            pr[17] = new SqlParameter("@Width", ps.Width);
            pr[18] = new SqlParameter("@Length", ps.Length);
            pr[19] = new SqlParameter("@Description", ps.Description);
            pr[20] = new SqlParameter("@HaveHouses", ps.HaveHouses);
            pr[21] = new SqlParameter("@UserName", ps.UserName);
            pr[22] = new SqlParameter("@IsVip", ps.IsVip);
            pr[23] = new SqlParameter("@Expiration", ps.Expiration);
            pr[24] = new SqlParameter("@IP", ps.IP);
            pr[25] = new SqlParameter("@ByUser", ps.ByUser);
            pr[26] = new SqlParameter("@StateId", ps.StateId);
            pr[27] = new SqlParameter("@Silver", ps.Silver);
            pr[28] = new SqlParameter("@ContactName", ps.ContactName);
            pr[29] = new SqlParameter("@Tel", ps.Tel);
            pr[30] = new SqlParameter("@Mobile", ps.Mobile);
            pr[31] = new SqlParameter("@Address", ps.Address);
            pr[32] = new SqlParameter("@Notes", ps.Notes);
            if (pro.DocId != 0) pr[33] = new SqlParameter("@DocId", pro.DocId);
            else pr[33] = new SqlParameter("@DocId", null);
            pr[34] = new SqlParameter("@Floor", pro.Floor);
            pr[35] = new SqlParameter("@SittingRoom", pro.SittingRoom);
            pr[36] = new SqlParameter("@BedRoom", pro.BedRoom);
            pr[37] = new SqlParameter("@BathRoom", pro.BathRoom);
            if (pro.SetId != 0) pr[38] = new SqlParameter("@SetId", pro.SetId);
            else pr[38] = new SqlParameter("@SetId", null);
            pr[39] = new SqlParameter("@SizeOfLane", pro.SizeOfLane);
            pr[40] = new SqlParameter("@Othr", pro.Other);
            pr[41] = new SqlParameter("@PId", ps.PostId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhPts", pr);
        }

        public List<EPosts> LstPosts(EPager page)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPst", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while(r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page,ECategories c)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPct", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, EMember c)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@mi", c.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPmr", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, ECategories c, ECities y)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            pr[3] = new SqlParameter("@y", y.CityId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPyt", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, ECategories c, EDistricts d)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            pr[3] = new SqlParameter("@d", d.DistrictId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shDyt", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, ECategories c, EDistricts d, EClasses l)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            pr[3] = new SqlParameter("@d", d.DistrictId);
            pr[4] = new SqlParameter("@l", l.ClassId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shLyt", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, ECategories c, EDistricts d, EStreets t)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            pr[3] = new SqlParameter("@d", d.DistrictId);
            pr[4] = new SqlParameter("@ts", t.StreetId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shTyt", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public List<EPosts> LstPosts(EPager page, ECategories c, EDistricts d, EWards a)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CategoryId);
            pr[3] = new SqlParameter("@d", d.DistrictId);
            pr[4] = new SqlParameter("@a", a.WardId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shAyt", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public EPosts Post(EPosts p)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@pid", p.PostId);
            pr[1] = new SqlParameter("@user", p.UserName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPdt", pr))
            {
                EPosts e = new EPosts();
                if (r.Read())
                {
                    e = Posts(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return e;
            }
        }

        public void States(ref int sta1, ref int sta2, ref int sta4, ref int sta3, ref int sta0, string strUser)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@UserName", strUser);
            pr[1] = new SqlParameter("@state1", SqlDbType.Int);
            pr[1].Direction = ParameterDirection.Output;
            pr[2] = new SqlParameter("@state2", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            pr[3] = new SqlParameter("@state4", SqlDbType.Int);
            pr[3].Direction = ParameterDirection.Output;
            pr[4] = new SqlParameter("@state3", SqlDbType.Int);
            pr[4].Direction = ParameterDirection.Output;
            pr[5] = new SqlParameter("@state0", SqlDbType.Int);
            pr[5].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shStaPst", pr);
            sta1 = int.Parse(pr[1].Value.ToString());
            sta2 = int.Parse(pr[2].Value.ToString());
            sta4 = int.Parse(pr[3].Value.ToString());
            sta3 = int.Parse(pr[4].Value.ToString());
            sta0 = int.Parse(pr[5].Value.ToString());
        }

        public int Total()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcPst", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(ECategories c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcPct", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(EMember c)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@mi", c.MemberId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcPmr", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(EAnas c,int sj, int us)
        {
            SqlParameter[] pr = new SqlParameter[18];
            pr[0] = new SqlParameter("@ct", c.CT);
            pr[1] = new SqlParameter("@cy", c.CY);
            pr[2] = new SqlParameter("@dt", c.DT);
            pr[3] = new SqlParameter("@cl", c.CL);
            pr[4] = new SqlParameter("@se", c.SE);
            pr[5] = new SqlParameter("@wa", c.WA);
            pr[6] = new SqlParameter("@fv", c.FV);
            pr[7] = new SqlParameter("@tv", c.TV);
            pr[8] = new SqlParameter("@fa", c.FA);
            pr[9] = new SqlParameter("@ta", c.TA);
            pr[10] = new SqlParameter("@pt", c.PT);
            pr[11] = new SqlParameter("@lt", c.LT);
            pr[12] = new SqlParameter("@st", c.ST);
            pr[13] = new SqlParameter("@pi", c.PI);
            pr[14] = new SqlParameter("@on", c.ON);
            pr[15] = new SqlParameter("@hi", c.HI);
            pr[16] = new SqlParameter("@sj", sj);
            pr[17] = new SqlParameter("@us", us);
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shcQry", pr);
            int i = 0;
            if (r.Read())
            {
                i = int.Parse(r["CountTotal"].ToString());
            }
            if (!r.IsClosed)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }

        public int Total(ECategories c, ECities y)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            pr[2] = new SqlParameter("@y", y.CityId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcPyt", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(ECategories c, EDistricts d)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            pr[2] = new SqlParameter("@d", d.DistrictId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcDyt", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(ECategories c, EDistricts d, EClasses l)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            pr[2] = new SqlParameter("@d", d.DistrictId);
            pr[3] = new SqlParameter("@l", l.ClassId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcLyt", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(ECategories c, EDistricts d, EStreets t)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            pr[2] = new SqlParameter("@d", d.DistrictId);
            pr[3] = new SqlParameter("@t", t.StreetId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcTyt", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public int Total(ECategories c, EDistricts d, EWards a)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@c", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@ct", c.CategoryId);
            pr[2] = new SqlParameter("@d", d.DistrictId);
            pr[3] = new SqlParameter("@a", a.WardId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcAyt", pr);
            return int.Parse(pr[0].Value.ToString());
        }

        public List<EPosts> LstPosts(EPager page, EAnas c, int sj, int us)
        {
            SqlParameter[] pr = new SqlParameter[22];
            pr[0] = new SqlParameter("@p", page.PageSize);
            pr[1] = new SqlParameter("@c", page.CurrentPage);
            pr[2] = new SqlParameter("@ct", c.CT);
            pr[3] = new SqlParameter("@cy", c.CY);
            pr[4] = new SqlParameter("@dt", c.DT);
            pr[5] = new SqlParameter("@cl", c.CL);
            pr[6] = new SqlParameter("@se", c.SE);
            pr[7] = new SqlParameter("@wa", c.WA);
            pr[8] = new SqlParameter("@fv", c.FV);
            pr[9] = new SqlParameter("@tv", c.TV);
            pr[10] = new SqlParameter("@fa", c.FA);
            pr[11] = new SqlParameter("@ta", c.TA);
            pr[12] = new SqlParameter("@pt", c.PT);
            pr[13] = new SqlParameter("@lt", c.LT);
            pr[14] = new SqlParameter("@st", c.ST);
            pr[15] = new SqlParameter("@pi", c.PI);
            pr[16] = new SqlParameter("@on", c.ON);
            pr[17] = new SqlParameter("@hi", c.HI);
            pr[18] = new SqlParameter("@ob", c.OB);
            pr[19] = new SqlParameter("@ad", c.AD);
            pr[20] = new SqlParameter("@sj", sj);
            pr[21] = new SqlParameter("@us", us);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shQry", pr))
            {
                List<EPosts> p = new List<EPosts>();
                while (r.Read())
                {
                    p.Add(Posts2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        public DataTable MngPst(int st, int ct, int dt,string ur)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@state", st);
            pr[1] = new SqlParameter("@city", ct);
            pr[2] = new SqlParameter("@district", dt);
            pr[3] = new SqlParameter("@user", ur);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shMngPts", pr);
        }

        public void UStaPst(EPosts c, string s, int a)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@PostId", c.PostId);
            pr[1] = new SqlParameter("@StateId", c.StateId);
            pr[2] = new SqlParameter("@Vip", c.IsVip);
            pr[3] = new SqlParameter("@Silver", c.Silver);
            pr[4] = new SqlParameter("@User", s);
            pr[5] = new SqlParameter("@Date", a);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhStaPts", pr);
        }

        public DataTable MrPst(int st, int ct, int dt, int ur)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@state", st);
            pr[1] = new SqlParameter("@city", ct);
            pr[2] = new SqlParameter("@district", dt);
            pr[3] = new SqlParameter("@MemberId", ur);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shMdrPst", pr);
        }

        public void UStaPst2(EPosts c, string s, int a)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@PostId", c.PostId);
            pr[1] = new SqlParameter("@StateId", c.StateId);
            pr[2] = new SqlParameter("@Vip", c.IsVip);
            pr[3] = new SqlParameter("@Silver", c.Silver);
            pr[4] = new SqlParameter("@User", s);
            pr[5] = new SqlParameter("@Date", a);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhStaPts2", pr);
        }

        public void EPosts(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@PostId", i);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "dhPosts", pr);
        }

        public void UPosts(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@PostId", i);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhPosts", pr);
        }

        public void solos(ref int a,ref int c,ref int d)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@ip", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@niv", SqlDbType.DateTime);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shcolos", pr);
            a = int.Parse(pr[0].Value.ToString());
            c = DateTime.Parse(pr[1].Value.ToString()).Month;
            d = DateTime.Parse(pr[1].Value.ToString()).Year;
        }

        public int APstR(int i)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@Pst", i);
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPstr", pr);
            int a = 0;
            if (r.Read()) a = int.Parse(r[0].ToString());
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return a;
        }

        public DataTable MngSvs(int ct, int dt, string ur)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@Mbr", ur);
            pr[1] = new SqlParameter("@city", ct);
            pr[2] = new SqlParameter("@district", dt);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shMSaves2", pr);
        }
    }
}
