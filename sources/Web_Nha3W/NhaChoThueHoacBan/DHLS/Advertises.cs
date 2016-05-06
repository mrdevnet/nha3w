using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using SLMF.Entity;
/// <summary>
/// Summary description for Dat_Login
/// </summary>
/// 
namespace HungLocSon.DHLS
{
    public class DAdvertises
    {
        public DAdvertises()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public int CheckMemberExists(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        //{
        //    string strCommandText = "selMembersCheckExists";
        //    SqlParameter[] paraLocal = new SqlParameter[2];
        //    paraLocal[0] = new SqlParameter("@UserName", member.UserName);
        //    paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
        //    paraLocal[1].Direction = ParameterDirection.Output;

        //    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    int intResult = int.Parse(paraLocal[1].Value.ToString());

        //    return intResult;
        //}

        //public Banners Populate(IDataReader myReader)
        //{
        //    Banners obj = new Banners();
        //    obj.BannerId = (int)myReader["BannerId"];
        //    obj.Name = (string)myReader["Name"];
        //    obj.Descs = (string)myReader["Descs"];
        //    obj.Link = (string)myReader["Link"];
        //    return obj;
        //}

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
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shAds", null))
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

        public SqlDataReader sads()
        {
            string c = "shAds";
            SqlDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, c, null);
            return r;
        }
    }
}
