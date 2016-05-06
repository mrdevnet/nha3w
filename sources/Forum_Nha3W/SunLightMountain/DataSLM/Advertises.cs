using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SLMF.Entity;


namespace SLMF.DataAccess
{
    public class DAdvertises
    {
        public DAdvertises()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private EAdvertises Advertises(IDataReader i)
        {
            EAdvertises pro = new EAdvertises();
            pro.AdvertiseId = (int)i["AdvertiseId"];
            pro.Title = (string)i["Title"];
            pro.BodyText = (string)i["BodyText"];
            pro.Url = (string)i["Url"];
            pro.Image = (string)i["Image"];
            return pro;
        }

        public List<EAdvertises> ListAdvertises()
        {
            SqlConnection a = new SqlConnection(SLMF.Utility.UtiGeneralClass.Connect2);
            SqlCommand c = new SqlCommand("shAds", a);
            c.CommandType = CommandType.StoredProcedure;
            if (a.State != ConnectionState.Open)
            {
                a.Open();
            }
            using (IDataReader r = c.ExecuteReader(CommandBehavior.CloseConnection))
            {
                List<EAdvertises> l = new List<EAdvertises>();
                while (r.Read())
                {
                    l.Add(Advertises(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return l;
            }
        }

        public List<EReports> LstReports()
        {
            SqlConnection a = new SqlConnection(SLMF.Utility.UtiGeneralClass.Connect2);
            SqlCommand c = new SqlCommand("shRpts", a);
            c.CommandType = CommandType.StoredProcedure;
            if (a.State != ConnectionState.Open)
            {
                a.Open();
            }
            using (IDataReader r = c.ExecuteReader(CommandBehavior.CloseConnection))
            {
                List<EReports> p = new List<EReports>();
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

        private EReports Ct(IDataReader i)
        {
            EReports p = new EReports();
            p.RptId = (int)i["RptId"];
            p.Title = (string)i["Title"];
            p.Url = (string)i["Url"];
            p.ByMember = (int)i["ByMember"];
            p.UserName = (string)i["UserName"];
            p.IsShow = (bool)i["IsShow"];
            p.Updated = (DateTime)i["Updated"];
            if (i["Total"] != null && i["Total"].ToString() != "")
                p.Total = (int)i["Total"];
            return p;
        }


        //public List<Banners> GetList()
        //{
        //    using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, 
        //        CommandType.StoredProcedure, "sproc_Banners_Get"))
        //    {
        //        List<Banners> list = new List<Banners>();
        //        while (reader.Read())
        //        {
        //            list.Add(Populate(reader));
        //        }
        //        return list;
        //    }
        //}
    }
}

