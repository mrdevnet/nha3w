using System;
using System.Data;
using System.Data.SqlClient;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DProfile
    {
        public DProfile()
        {
        }

        public EProfile Detail(int id)
        {
            EProfile pf = new EProfile();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MemberId", id);
            SqlDataReader ordHLS_Profile = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Profile_Detail", pr);
            ordHLS_Profile.Read();
            if (ordHLS_Profile.HasRows)
            {
                if (ordHLS_Profile["MemberId"] != DBNull.Value)
                {
                    pf.MemberId = Convert.ToInt32(ordHLS_Profile["MemberId"]);
                }
                if (ordHLS_Profile["FullName"] != DBNull.Value)
                {
                    pf.FullName = Convert.ToString(ordHLS_Profile["FullName"]);
                }
                if (ordHLS_Profile["Company"] != DBNull.Value)
                {
                    pf.Company = Convert.ToString(ordHLS_Profile["Company"]);
                }
                if (ordHLS_Profile["Address"] != DBNull.Value)
                {
                    pf.Address = Convert.ToString(ordHLS_Profile["Address"]);
                }
                if (ordHLS_Profile["Tel"] != DBNull.Value)
                {
                    pf.Tel = Convert.ToString(ordHLS_Profile["Tel"]);
                }
                if (ordHLS_Profile["Mobile"] != DBNull.Value)
                {
                    pf.Mobile = Convert.ToString(ordHLS_Profile["Mobile"]);
                }
                if (ordHLS_Profile["Birthday"] != DBNull.Value)
                {
                    pf.Birthday = Convert.ToDateTime(ordHLS_Profile["Birthday"]);
                }
                if (ordHLS_Profile["Gender"] != DBNull.Value)
                {
                    pf.Gender = Convert.ToBoolean(ordHLS_Profile["Gender"]);
                }
                if (ordHLS_Profile["Email"] != DBNull.Value)
                {
                    pf.Email = Convert.ToString(ordHLS_Profile["Email"]);
                }
                if (ordHLS_Profile["GetNews"] != DBNull.Value)
                {
                    pf.GetNews = Convert.ToBoolean(ordHLS_Profile["GetNews"]);
                }
                if (ordHLS_Profile["Yahoo"] != DBNull.Value)
                {
                    pf.Yahoo = Convert.ToString(ordHLS_Profile["Yahoo"]);
                }
                if (ordHLS_Profile["Skype"] != DBNull.Value)
                {
                    pf.Skype = Convert.ToString(ordHLS_Profile["Skype"]);
                }
                if (ordHLS_Profile["Website"] != DBNull.Value)
                {
                    pf.Website = Convert.ToString(ordHLS_Profile["Website"]);
                }
                if (ordHLS_Profile["Logo"] != DBNull.Value)
                {
                    pf.Logo = Convert.ToString(ordHLS_Profile["Logo"]);
                }
                if (ordHLS_Profile["Activation"] != DBNull.Value)
                {
                    //pf.Activasion = Convert.ToString(ordHLS_Profile["Activation"]);
                    pf.Activation = (Guid)(ordHLS_Profile["Activation"]);
                }
                if (ordHLS_Profile["HideIn"] != DBNull.Value)
                {
                    pf.HideIn = Convert.ToBoolean(ordHLS_Profile["HideIn"]);
                }
                if (ordHLS_Profile["RegIP"] != DBNull.Value)
                {
                    pf.RegIP = Convert.ToString(ordHLS_Profile["RegIP"]);
                }
                if (ordHLS_Profile["LastIP"] != DBNull.Value)
                {
                    pf.LastIP = Convert.ToString(ordHLS_Profile["LastIP"]);
                }
                if (ordHLS_Profile["IsBlocked"] != DBNull.Value)
                {
                    pf.IsBlocked = Convert.ToBoolean(ordHLS_Profile["IsBlocked"]);
                }
                if (ordHLS_Profile["TotalUp"] != DBNull.Value)
                {
                    pf.TotalUp = Convert.ToInt32(ordHLS_Profile["TotalUp"]);
                }
                if (ordHLS_Profile["Up"] != DBNull.Value)
                {
                    pf.Up = Convert.ToBoolean(ordHLS_Profile["Up"]);
                }
                if (ordHLS_Profile["LastIn"] != DBNull.Value)
                {
                    pf.LastIn = Convert.ToDateTime(ordHLS_Profile["LastIn"]);
                }
                if (ordHLS_Profile["Private"] != DBNull.Value)
                {
                    pf.Private = Convert.ToBoolean(ordHLS_Profile["Private"]);
                }
            }
            if (!ordHLS_Profile.IsClosed)
            {
                ordHLS_Profile.Close();
                ordHLS_Profile.Dispose();
            }
            return pf;
        }

    }
}
