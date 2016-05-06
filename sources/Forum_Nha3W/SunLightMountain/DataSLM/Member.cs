using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Entity;
/// <summary>
/// Summary description for Dat_Login
/// </summary>
/// 
namespace SLMF.DataAccess
{
    public class DaMember
    {
        public DaMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int CheckMemberExists(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selMembersCheckExists";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[1].Value.ToString());

            return intResult;
        }

        public int MemberLogin(EnMember member)
        {
            string strCommandText = "selMembersLogin";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Password", SqlDbType.VarChar, 32);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@Salt", SqlDbType.VarChar, 3);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            member.NewPassword = paraLocal[1].Value.ToString();
            member.Salt = paraLocal[2].Value.ToString();
            int intResult = int.Parse(paraLocal[3].Value.ToString());
            
            return intResult;
        }


        public EnMember SelectMemberIdFUser(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selMembersFUser";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            
            SqlDataReader datrMember = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            EnMember newAccount = new EnMember();
            newAccount = CreateMemberId(datrMember);

            if (datrMember.IsClosed == false)
            {
                datrMember.Close();
                datrMember.Dispose();
            }
            return newAccount;
        }

        public EProfile PMember(EnMember m)
        {
            SqlConnection a = new SqlConnection(SLMF.Utility.UtiGeneralClass.Connect2);
            SqlCommand c = new SqlCommand("shPro", a);
            c.CommandType = CommandType.StoredProcedure;
            if (a.State != ConnectionState.Open) a.Open();
            c.Parameters.AddWithValue("@user", m.UserName);
            using (IDataReader r = c.ExecuteReader())
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

        private EProfile Pro(IDataReader i)
        {
            EProfile p = new EProfile();
            p.FullName = (string)i["FullName"];
            if (i["Company"].ToString() != "") p.Company = (string)i["Company"];
            if (i["Address"].ToString() != "") p.Address = (string)i["Address"];
            if (i["Tel"].ToString() != "") p.Tel = (string)i["Tel"];
            if (i["Mobile"].ToString() != "") p.Mobile = (string)i["Mobile"];
            if (i["Email"].ToString() != "") p.Email = (string)i["Email"];
            if (i["TotalUp"].ToString() != "") p.TotalUp = (int)i["TotalUp"];

            if (i["Birthday"].ToString() != "") p.Birthday = (DateTime)i["Birthday"];
            if (i["Gender"].ToString() != "") p.Gender = (bool)i["Gender"];
            if (i["GetNews"].ToString() != "") p.GetNews = (bool)i["GetNews"];
            if (i["Yahoo"].ToString() != "") p.Yahoo = (string)i["Yahoo"];
            if (i["Skype"].ToString() != "") p.Skype = (string)i["Skype"];
            if (i["Website"].ToString() != "") p.Website = (string)i["Website"];
            if (i["Logo"].ToString() != "") p.Logo = (string)i["Logo"];
            if (i["HideIn"].ToString() != "") p.HideIn = (bool)i["HideIn"];
            return p;
        }

        private EnMember CreateMemberId(IDataReader reader)
        {
            EnMember newEnMember = new EnMember();
            if (reader.Read())
            {
                newEnMember.MemberId = int.Parse(reader["MemberId"].ToString());
                newEnMember.Email = reader["Email"].ToString();
                newEnMember.FullName = reader["FullName"].ToString();

                //newEnMember.IdentificationNumber = reader["identification_number"].ToString();
                //newEnMember.Gender = bool.Parse(reader["gender"].ToString());
                //newEnMember.DateOfBirth = DateTime.Parse(reader["date_of_birth"].ToString());

                //newEnMember.Address = reader["Address"].ToString();
                //newEnMember.City = reader["City"].ToString();
                //newEnMember.Country = reader["Country"].ToString();
                //newEnMember.Phone = reader["Phone"].ToString();
                //newEnMember.LastLogin = DateTime.Parse(reader["last_login"].ToString());
            }
            return newEnMember;
        }

        public bool SelectMemberGuest(EnMember mbr)
        {
            string strCommandText = "selMemberIsG";
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            bool res = CreateGuest(r, mbr);
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return res;
        }

        private bool CreateGuest(IDataReader r, EnMember mbr)
        {
            bool res = false;
            if (r.Read())
            {
                if (mbr.MemberId == int.Parse(r["MemberId"].ToString()))
                {
                    res = true;
                }
            }
            return res;
        }

        public void UpdateStatus(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selMemberCookies";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectMemberLst(EnPagerF pager)
        {
            string strCommandText = "selMemberLst";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[1] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int SelectMbrLstCount()
        {
            string strCommandText = "selMemberLstCount";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[0].Value.ToString());
            return intCount;
        }

        public SqlDataReader SelectMbrSearch(string strSearch, EnPagerF pager)
        {
            string strCommandText = "selMemberSearch";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@Search", strSearch);
            paraLocal[1] = new SqlParameter("@PageSize", pager.PageSize);
            paraLocal[2] = new SqlParameter("@CurrentPage", pager.CurrentPage);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public int SelectMbrSchCount(string strSearch)
        {
            string strCommandText = "selMbrSchCount";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@Search", strSearch);
            paraLocal[1] = new SqlParameter("@ItemCount", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intCount = int.Parse(paraLocal[1].Value.ToString());
            return intCount;
        }

        public void SelectMemberFromId(ref EnMember member)
        {
            string strCommandText = "selMemberFromId";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateFromId(datrTopic, ref member);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

        private void CreateFromId(IDataReader r, ref EnMember mbr)
        {
            if (r.Read())
            {
                mbr.UserName = r["UserName"].ToString();
            }
        }

        public void UpdatePassword(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "updChangePassword";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            paraLocal[1] = new SqlParameter("@NewPass", member.Password);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int SelectEmailLostPass(ref EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selEmailLostPass";
            SqlParameter[] paraLocal = new SqlParameter[6];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Email", member.Email);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;
            paraLocal[3] = new SqlParameter("@Salt", SqlDbType.VarChar);
            paraLocal[3].Size = 3;
            paraLocal[3].Direction = ParameterDirection.Output;
            paraLocal[4] = new SqlParameter("@Activate", SqlDbType.UniqueIdentifier);
            paraLocal[4].Direction = ParameterDirection.Output;
            paraLocal[5] = new SqlParameter("@MemberId", SqlDbType.Int);
            paraLocal[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[2].Value.ToString());
            if (intResult == 1)
            {
                member.Salt = paraLocal[3].Value.ToString();
                member.ActivateString = paraLocal[4].Value.ToString();
                member.MemberId = int.Parse(paraLocal[5].Value.ToString());
            }
            return intResult;
        }

        public int SelectResetPass(ref EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selResetPass";
            SqlParameter[] paraLocal = new SqlParameter[6];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            paraLocal[1] = new SqlParameter("@Salt", member.Salt);
            paraLocal[2] = new SqlParameter("@Activate", member.ActivateString);
            paraLocal[3] = new SqlParameter("@Password", member.Password);
            paraLocal[4] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[4].Direction = ParameterDirection.Output;
            paraLocal[5] = new SqlParameter("@UserName", SqlDbType.NVarChar);
            paraLocal[5].Size = 50;
            paraLocal[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[4].Value.ToString());
            if (intResult == 1)
            {
                member.UserName = paraLocal[5].Value.ToString();
            }
            return intResult;
        }

        public DataTable SelectSearchUser(EnMember mbr, EnGroup grp, int intTypeId)
        {
            string strCommandText = "selUserSearch";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@UserName", mbr.UserName);
            paraLocal[1] = new SqlParameter("@Email", mbr.Email);
            paraLocal[2] = new SqlParameter("@FullName", mbr.FullName);
            paraLocal[3] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[4] = new SqlParameter("@TypeId", intTypeId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteMember(EnMember mbr)
        {
            string strCommandText = "delMembers";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectUserGroup(EnMember mbr)
        {
            string strCommandText = "selUserGroup";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@UserName", mbr.FullName);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectGrpDetails(EnMember mbr)
        {
            string strCommandText = "selMbrsGrps";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAllAdmins()
        {
            string strCommandText = "selAllAdmins";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public bool IsModer(EnMember member, EnForum frm)
        {
            string strCommandText = "selIsMode";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            paraLocal[1] = new SqlParameter("@UserName", member.UserName);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[2].Value.ToString());
        }

        public bool IsSuperModer(EnMember member)
        {
            string strCommandText = "selIsSuperMode";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[1].Value.ToString());
        }

        public bool IsAdmin(EnMember member)
        {
            string strCommandText = "selIsAdmin";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return bool.Parse(paraLocal[1].Value.ToString());
        }
    }
}
