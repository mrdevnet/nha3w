using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DAnas
    {
        public DAnas()
        {
        }

        public void IAnas(EAnas a)
        {
            SqlParameter[] pr = new SqlParameter[21];
            pr[0] = new SqlParameter("@sd", a.SD);
            pr[1] = new SqlParameter("@ct", a.CT);
            pr[2] = new SqlParameter("@cy", a.CY);
            pr[3] = new SqlParameter("@dt", a.DT);
            pr[4] = new SqlParameter("@cl", a.CL);
            pr[5] = new SqlParameter("@se", a.SE);
            pr[6] = new SqlParameter("@wa", a.WA);
            pr[7] = new SqlParameter("@ur", a.UR);
            pr[8] = new SqlParameter("@ip", a.IP);
            pr[9] = new SqlParameter("@fv", a.FV);
            pr[10] = new SqlParameter("@tv", a.TV);
            pr[11] = new SqlParameter("@fa", a.FA);
            pr[12] = new SqlParameter("@ta", a.TA);
            pr[13] = new SqlParameter("@pt", a.PT);
            pr[14] = new SqlParameter("@lt", a.LT);
            pr[15] = new SqlParameter("@st", a.ST);
            pr[16] = new SqlParameter("@pi", a.PI);
            pr[17] = new SqlParameter("@on", a.ON);
            pr[18] = new SqlParameter("@hi", a.HI);
            pr[19] = new SqlParameter("@ob", a.OB);
            pr[20] = new SqlParameter("@ad",a.AD);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihSdi", pr);
        }

        public EAnas IAnas2(EAnas a)
        {
            SqlParameter[] pr = new SqlParameter[13];
            pr[0] = new SqlParameter("@sd", a.SD);
            pr[1] = new SqlParameter("@ct", SqlDbType.Int);
            pr[1].Direction = ParameterDirection.Output;
            pr[2] = new SqlParameter("@cy", SqlDbType.Int);
            pr[2].Direction = ParameterDirection.Output;
            pr[3] = new SqlParameter("@dt", SqlDbType.Int);
            pr[3].Direction = ParameterDirection.Output;
            pr[4] = new SqlParameter("@cl", SqlDbType.Int);
            pr[4].Direction = ParameterDirection.Output;
            pr[5] = new SqlParameter("@sr", SqlDbType.Int);
            pr[5].Direction = ParameterDirection.Output;
            pr[6] = new SqlParameter("@wa", SqlDbType.Int);
            pr[6].Direction = ParameterDirection.Output;
            pr[7] = new SqlParameter("@ctn", SqlDbType.NVarChar,100);
            pr[7].Direction = ParameterDirection.Output;
            pr[8] = new SqlParameter("@cyn", SqlDbType.NVarChar, 100);
            pr[8].Direction = ParameterDirection.Output;
            pr[9] = new SqlParameter("@dtn", SqlDbType.NVarChar, 200);
            pr[9].Direction = ParameterDirection.Output;
            pr[10] = new SqlParameter("@cln", SqlDbType.NVarChar, 100);
            pr[10].Direction = ParameterDirection.Output;
            pr[11] = new SqlParameter("@srn", SqlDbType.NVarChar, 200);
            pr[11].Direction = ParameterDirection.Output;
            pr[12] = new SqlParameter("@wan", SqlDbType.NVarChar, 200);
            pr[12].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shSdt", pr);
            if (pr[1].Value.ToString() != "") a.CT = (int)(pr[1].Value);
            if (pr[2].Value.ToString() != "") a.CY = (int)(pr[2].Value);
            if (pr[3].Value.ToString() != "") a.DT = (int)(pr[3].Value);
            if (pr[4].Value.ToString() != "") a.CL = (int)(pr[4].Value);
            if (pr[5].Value.ToString() != "") a.SE = (int)(pr[5].Value);
            if (pr[6].Value.ToString() != "") a.WA = (int)(pr[6].Value);
            a.CTN = pr[7].Value.ToString();
            a.CYN = pr[8].Value.ToString();
            a.DTN = pr[9].Value.ToString();
            a.CLN = pr[10].Value.ToString();
            a.SEA = pr[11].Value.ToString();
            a.WAN = pr[12].Value.ToString();
            return a;
        }

        public string VwO()
        {
            string v = "";
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@on", SqlDbType.Int);
            pr[0].Direction = ParameterDirection.Output;
            pr[1] = new SqlParameter("@off", SqlDbType.Int);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shCntO", pr);
            if (int.Parse(pr[1].Value.ToString()) > 0) v = ": " + pr[1].Value.ToString() + " user";
            int w = (int.Parse(pr[1].Value.ToString()) - int.Parse(pr[0].Value.ToString()));
            if (w > 0) v = ": " + pr[1].Value.ToString() + " - " + w + " khách";
            return v;
        }

        public List<EAnas> LstNets()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shMrNtO", null))
            {
                List<EAnas> p = new List<EAnas>();
                while (r.Read())
                {
                    p.Add(Nets2(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EAnas Nets2(IDataReader i)
        {
            EAnas p = new EAnas();
            p.MI = (int)i["MemberId"];
            p.UR = (string)i["UserName"];
            p.IP = (string)i["Ip"];
            p.BE = (DateTime)i["Be"];
            p.LA = (DateTime)i["La"];
            p.NT = (int)i["nt"];
            p.LS = (int)i["ls"];
            if (i["Logo"] != null && i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            return p;
        }

        //private EAnas Posts(IDataReader i)
        //{
        //    EAnas p = new EAnas();
        //    //p.PostId = (int)i["PostId"];
        //    p.Title = (string)i["Title"];
        //    p.CategoryId = (int)i["CategoryId"];
        //    p.CateName = (string)i["CateName"];
        //    p.IsOwner = (bool)i["IsOwner"];
        //    p.ClassId = (int)i["ClassId"];
        //    p.ClassName = (string)i["ClassName"];
        //    p.LocationId = (int)i["LocationId"];
        //    p.LocaName = (string)i["LocaName"];
        //    p.CountryId = (int)i["CountryId"];
        //    p.CityId = (int)i["CityId"];
        //    p.CityName = (string)i["CityName"];
        //    p.DistrictId = (int)i["DistrictId"];
        //    p.DistrictName = (string)i["DistrictName"];
        //    p.WardId = (int)i["WardId"];
        //    if (i["StreetId"].ToString() != "") p.StreetId = (int)i["StreetId"];
        //    if (i["StreetName"].ToString() != "") p.StreetName = (string)i["StreetName"];
        //    if (i["StrName"].ToString() != "") p.StrName = (string)i["StrName"];
        //    p.LotNumber = (string)i["LotNumber"];
        //    p.HideNumber = (bool)i["HideNumber"];
        //    if (i["ProjectId"].ToString() != "") p.ProjectId = (int)i["ProjectId"];
        //    if (i["ProjectName"].ToString() != "") p.ProjectName = (string)i["ProjectName"];
        //    if (i["ProName"].ToString() != "") p.ProName = (string)i["ProName"];
        //    p.Values = float.Parse(i["Value"].ToString());
        //    p.CurrencyId = (int)i["CurrencyId"];
        //    p.CurrencyName = (string)i["CurrencyName"];
        //    p.UnitId = (int)i["UnitId"];
        //    p.UnitName = (string)i["UnitName"];
        //    p.Percents = (int)i["Percents"];
        //    p.Area = float.Parse(i["Area"].ToString());
        //    p.Width = (string)i["Width"];
        //    p.Length = (string)i["Length"];
        //    p.Description = (string)i["Description"];
        //    p.HaveHouses = (bool)i["HaveHouses"];
        //    //p.MapId = (int)i["MapId"];
        //    p.MemberId = (int)i["MemberId"];
        //    p.UserName = (string)i["UserName"];
        //    //p.VideoId = (int)i["VideoId"];
        //    p.IsVip = (bool)i["IsVip"];
        //    p.ContactId = (int)i["ContactId"];
        //    p.ContactName = (string)i["ContactName"];
        //    p.Tel = (string)i["Tel"];
        //    p.Mobile = (string)i["Mobile"];
        //    p.Address = (string)i["Address"];
        //    p.Notes = (string)i["Notes"];
        //    p.CreationDate = (DateTime)i["CreationDate"];
        //    p.Updated = (DateTime)i["Updated"];
        //    p.Expiration = (DateTime)i["Expiration"];
        //    p.Views = int.Parse(i["Views"].ToString());
        //    p.IP = (string)i["IP"];
        //    p.DateApproved = (DateTime)i["DateApproved"];
        //    p.ByMember = (int)i["ByMember"];
        //    p.ByAuthor = (string)i["ByAuthor"];
        //    p.StateId = (int)i["StateId"];
        //    p.StateName = (string)i["StateName"];
        //    p.Silver = (bool)i["Silver"];
        //    return p;
        //}


    }
}
