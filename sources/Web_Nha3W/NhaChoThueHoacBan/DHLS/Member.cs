using System;
using System.Data;
using System.Data.SqlClient;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DMember
    {
        public DMember()
        {
        }

        public int IMember(EMember m, EProfile p)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter("@UserName", m.UserName);
            pr[1] = new SqlParameter("@Password", m.Password);
            pr[2] = new SqlParameter("@Salt", m.Salt);
            pr[3] = new SqlParameter("@IsActivated", m.IsActivated);
            pr[4] = new SqlParameter("@EnableLogin", m.EnableLogin);
            //pr[5] = new SqlParameter("@GroupId", m.GroupId);
            pr[5] = new SqlParameter("@FullName", p.FullName);
            pr[6] = new SqlParameter("@Email", p.Email);
            pr[7] = new SqlParameter("@RegIP", p.RegIP);
            pr[8] = new SqlParameter("@Ex", SqlDbType.TinyInt);
            pr[8].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "ihMbr", pr);
            return int.Parse(pr[8].Value.ToString());
        }

        public DataTable AWallets(string a)
        {
            string strCommandText = "shallWlls";
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@User", a);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, strCommandText, pr);
        }

        public string APwds(string a)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@User", a);
            pr[1] = new SqlParameter("@Pwds", SqlDbType.VarChar,32);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure,"shpwus", pr);
            return pr[1].Value.ToString();
        }

        public int LMember(EMember m, EProfile p)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@user", m.UserName);
            pr[1] = new SqlParameter("@pass", m.Password);
            pr[2] = new SqlParameter("@ip", p.LastIP);
            pr[3] = new SqlParameter("@res", SqlDbType.TinyInt);
            pr[3].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shlg", pr);
            return int.Parse(pr[3].Value.ToString());
        }

        public string ShwSeid(string aui)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@User", aui);
            pr[1] = new SqlParameter("@Res", SqlDbType.NVarChar,24);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shShwSeid", pr);
            return pr[1].Value.ToString();
        }

        public string SaMember(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@user", m.UserName);
            pr[1] = new SqlParameter("@res", SqlDbType.VarChar, 6);
            pr[1].Direction = ParameterDirection.Output;
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "shSal", pr);
            return pr[1].Value.ToString();
        }

        public EProfile PMember(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@user", m.UserName);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shPro", pr))
            {
                EProfile pros = new EProfile();
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

        public EProfile PMemberI(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@ir", m.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shProI", pr))
            {
                EProfile pros = new EProfile();
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

        public string PMemberU(EMember m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m.MemberId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shUfi", pr))
            {
                string pros = "";
                if (r.Read())
                {
                    pros = ufi(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        public string PMemberU(int m)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@urid", m);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shUfi", pr))
            {
                string pros = "";
                if (r.Read())
                {
                    pros = ufi(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return pros;
            }
        }

        private string ufi(IDataReader i)
        {
            string p = "";
            if (i["UserName"] != null && i["UserName"].ToString() != "") p = (string)i["UserName"];
            return p;
        }

        private EProfile Pro(IDataReader i)
        {
            EProfile p = new EProfile();
            p.FullName = (string)i["FullName"];
            p.UserName = (string)i["UserName"];
            if (i["Company"].ToString() != "") p.Company = (string)i["Company"];
            if (i["Address"].ToString() != "") p.Address = (string)i["Address"];
            if (i["Tel"].ToString() != "") p.Tel = (string)i["Tel"];
            if (i["Mobile"].ToString() != "") p.Mobile = (string)i["Mobile"];
            if (i["Email"].ToString() != "") p.Email = (string)i["Email"];
            if (i["TotalUp"].ToString() != "") p.TotalUp = (int)i["TotalUp"];
            if (i["Birthday"].ToString() != "") p.Birthday = (DateTime)i["Birthday"];
            if (i["Gender"].ToString() != "") p.Gender = (bool)i["Gender"];
            if (i["GetNews"].ToString() != "") p.GetNews = (bool)i["GetNews"];
            if (i["Yahoo"].ToString() != "") p.Yahoo= (string)i["Yahoo"];
            if (i["Skype"].ToString() != "") p.Skype= (string)i["Skype"];
            if (i["Website"].ToString() != "") p.Website= (string)i["Website"];
            if (i["Logo"].ToString() != "") p.Logo= (string)i["Logo"];
            if (i["HideIn"].ToString() != "") p.HideIn= (bool)i["HideIn"];
            return p;
        }

        public DataTable APermiss(string strUserFull)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@UserFull", strUserFull);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "shPermissions", pr);
        }

        public void UMbrPrs(EMember c, EProfile p)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("@IsActivated", c.IsActivated);
            pr[1] = new SqlParameter("@EnableLogin", c.EnableLogin);
            pr[2] = new SqlParameter("@IsBlocked", p.IsBlocked);
            pr[3] = new SqlParameter("@GroupId", c.GroupId);
            pr[4] = new SqlParameter("@MemberId", c.MemberId);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhMbrPer", pr);
        }

        public int Login(int id, string user, string pass)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MemberId", id);
            SqlDataReader ordHLS_Members = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Members_Detail", pr);
            ordHLS_Members.Read();
            if (ordHLS_Members.HasRows)
            {
                //Sai tai khoan
                if (ordHLS_Members["UserName"] != DBNull.Value)
                {
                    string UserName = Convert.ToString(ordHLS_Members["UserName"]);
                    if (UserName != user) return -1;
                }
                //Sai mat khau
                if (ordHLS_Members["Password"] != DBNull.Value)
                {
                    string PassWord = Convert.ToString(ordHLS_Members["Password"]);
                    string Salt = Convert.ToString(ordHLS_Members["Salt"]);
                    HungLocSon.UHLS.EncryptM a = new HungLocSon.UHLS.EncryptM();
                    if (PassWord != a.Md5Encode(a.Md5Encode(pass) + Salt)) return -2;
                }
                //Tai khoan chua kich hoat
                if (ordHLS_Members["IsActivated"] != DBNull.Value)
                {
                    bool IsActivated = Convert.ToBoolean(ordHLS_Members["IsActivated"]);
                    if (!IsActivated) return -3;
                }
                //Tai khoan bị block
                if (ordHLS_Members["EnableLogin"] != DBNull.Value)
                {
                    bool EnableLogin = Convert.ToBoolean(ordHLS_Members["EnableLogin"]);
                    if (!EnableLogin) return -4;
                }
                if (!ordHLS_Members.IsClosed)
                {
                    ordHLS_Members.Close();
                    ordHLS_Members.Dispose();
                }
                //Đăng nhập thành công 
                return 0;
            }
            else
            {
                if (!ordHLS_Members.IsClosed)
                {
                    ordHLS_Members.Close();
                    ordHLS_Members.Dispose();
                }
                return -1;
            }
        }
        public bool Activated(string user, string email, string acti)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Email", email);
            SqlDataReader ordHLS_Members = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Members_ResetPassword", pr);
            ordHLS_Members.Read();
            if (ordHLS_Members.HasRows)
            {
                string us = Convert.ToString(ordHLS_Members["UserName"]).Trim();
                string at = Convert.ToString(ordHLS_Members["Activation"]).Trim();
                if (!ordHLS_Members.IsClosed)
                {
                    ordHLS_Members.Close();
                    ordHLS_Members.Dispose();
                }
                if (us != user) return false;
                if (at != acti) return false;
                return true;
            }
            else
            {
                if (!ordHLS_Members.IsClosed)
                {
                    ordHLS_Members.Close();
                    ordHLS_Members.Dispose();
                }
                return false;
            }
        }

        public EMember Detail(int id)
        {
            EMember mb = new EMember();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MemberId", id);
            SqlDataReader ordHLS_Members = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Members_Detail", pr);
            ordHLS_Members.Read();
            if (ordHLS_Members.HasRows)
            {
                //Members
                if (ordHLS_Members["MemberId"] != DBNull.Value)
                {
                    mb.MemberId = Convert.ToInt32(ordHLS_Members["MemberId"]);
                }
                if (ordHLS_Members["UserName"] != DBNull.Value)
                {
                    mb.UserName = Convert.ToString(ordHLS_Members["UserName"]);
                }
                if (ordHLS_Members["Password"] != DBNull.Value)
                {
                    mb.Password = Convert.ToString(ordHLS_Members["Password"]);
                }
                if (ordHLS_Members["Salt"] != DBNull.Value)
                {
                    mb.Salt = Convert.ToString(ordHLS_Members["Salt"]);
                }
                if (ordHLS_Members["MemberId"] != DBNull.Value)
                {
                    mb.MemberId = Convert.ToInt32(ordHLS_Members["MemberId"]);
                }
                if (ordHLS_Members["IsActivated"] != DBNull.Value)
                {
                    mb.IsActivated = Convert.ToBoolean(ordHLS_Members["IsActivated"]);
                }
                if (ordHLS_Members["EnableLogin"] != DBNull.Value)
                {
                    mb.EnableLogin = Convert.ToBoolean(ordHLS_Members["EnableLogin"]);
                }
                if (ordHLS_Members["LastLogin"] != DBNull.Value)
                {
                    mb.LastLogin = Convert.ToDateTime(ordHLS_Members["LastLogin"]);
                }
                if (ordHLS_Members["DateActivation"] != DBNull.Value)
                {
                    mb.DateActivation = Convert.ToDateTime(ordHLS_Members["DateActivation"]);
                }
                if (ordHLS_Members["GroupId"] != DBNull.Value)
                {
                    mb.GroupId = Convert.ToInt32(ordHLS_Members["GroupId"]);
                }
                if (ordHLS_Members["ModerId"] != DBNull.Value)
                {
                    mb.ModerId = Convert.ToInt32(ordHLS_Members["ModerId"]);
                }
            }
            if (!ordHLS_Members.IsClosed)
            {
                ordHLS_Members.Close();
                ordHLS_Members.Dispose();
            }
            return mb;
        }
        public DataTable Search(string Info)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Info", Info);
            return HLSPro.ExecuteData(CommandType.StoredProcedure, "HLS_Members_Search", pr);
        }
        public int ReturnId(string something)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Something", something);
            SqlDataReader ordHLS_Members = HLSPro.ExecuteReader(CommandType.StoredProcedure, "HLS_Members_ReturnId", pr);
            ordHLS_Members.Read();
            int i = 0;
            if (ordHLS_Members.HasRows)
            {
                i= Convert.ToInt32(ordHLS_Members["MemberId"]);
            }
            if (!ordHLS_Members.IsClosed)
            {
                ordHLS_Members.Close();
                ordHLS_Members.Dispose();
            }
            return i;
        }
        public void ChangePassword(int id, string pw, string sl)
        {
            HungLocSon.UHLS.EncryptM a = new HungLocSon.UHLS.EncryptM();
            string p = a.Md5Encode(a.Md5Encode(pw) + sl);
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@Password", p);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangePassword", pr);
        }
        public void ChangeEmail(int id, string email)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@Email", email);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangeEmail", pr);
        }
        public void ChangePublic(int id, string yh, string sp, string ws)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@Yahoo", yh);
            pr[2] = new SqlParameter("@Skype", sp);
            pr[3] = new SqlParameter("@Website", ws);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangePublic", pr);
        }
        public void ChangeProfile(int id, string fn, string cpn, string ad, string tel, string mb, DateTime bir, bool gd)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@FullName", fn);
            pr[2] = new SqlParameter("@Company", cpn);
            pr[3] = new SqlParameter("@Address", ad);
            pr[4] = new SqlParameter("@Tel", tel);
            pr[5] = new SqlParameter("@Mobile", mb);
            pr[6] = new SqlParameter("@Birthday", bir);
            pr[7] = new SqlParameter("@Gender", gd);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangeProfile", pr);
        }
        public void ChangeFullName(int id, string fn)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@FullName", fn);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangeFullName", pr);
        }
        public void ChangeLogo(int id, string lg)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", id);
            pr[1] = new SqlParameter("@Logo", lg);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "HLS_Members_ChangeLogo", pr);
        }

        public void UFlPri(EMember c, EPFiles p)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MemberId", c.UserName);
            pr[1] = new SqlParameter("@Pri", p.Prive);
            HLSPro.ExecuteNonQuery(CommandType.StoredProcedure, "uhFlwPr", pr);
        }

    }
}
