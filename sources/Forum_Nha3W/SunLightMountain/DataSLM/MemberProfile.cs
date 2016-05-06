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

namespace SLMF.DataAccess
{
    public class DaMemberProfile
    {
        public DaMemberProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertMembers(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "insMembersInsertAccount";
            SqlParameter[] paraLocal = new SqlParameter[10];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Password", member.Password);
            paraLocal[2] = new SqlParameter("@Salt", member.Salt);
            paraLocal[3] = new SqlParameter("@Email", member.Email);
            paraLocal[4] = new SqlParameter("@FullName", member.FullName);
            paraLocal[5] = new SqlParameter("@Location", memberprofile.Location);
            paraLocal[6] = new SqlParameter("@HomePage", memberprofile.HomePage);
            paraLocal[7] = new SqlParameter("@MemberTitle", memberprofile.MemberTitle);
            paraLocal[8] = new SqlParameter("@IP", memberprofile.IP);
            paraLocal[9] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[9].Direction = ParameterDirection.Output;
            
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResut = int.Parse(paraLocal[9].Value.ToString());
            return intResut;
        }

        public int LoginMemberSuccess(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "insLoginMemberSuccess";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@IP", memberprofile.IP);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResut = int.Parse(paraLocal[2].Value.ToString());
            return intResut;
        }

        public void LogoutMember(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "updMembersLogout";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@IP", memberprofile.IP);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectMemberProfile(ref EnMember member, ref EnGroup group, ref EnMemberProfile profile)
        {
            string strCommandText = "selMemberPro";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);

            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);

            CreateProfile(datrTopic, ref member, ref group, ref profile);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

        private void CreateProfile(IDataReader reader, ref EnMember mbr, ref EnGroup grp, ref EnMemberProfile pro )
        {
            if (reader.Read())
            {
                mbr.UserName = reader["UserName"].ToString();
                mbr.Email = reader["Email"].ToString();
                mbr.FullName = reader["FullName"].ToString();
                mbr.DateCreation = DateTime.Parse(reader["DateCreation"].ToString());
                pro.AboutMe = reader["AboutMe"].ToString();
                pro.Interests = reader["Interests"].ToString();
                pro.Job = reader["Job"].ToString();
                pro.Location = reader["Location"].ToString();
                if (reader["Birthday"].ToString() != "")
                {
                    pro.BirthDay = DateTime.Parse(reader["Birthday"].ToString());
                }
                pro.Yahoo = reader["Yahoo"].ToString();
                pro.Aim = reader["Aim"].ToString();
                pro.Icq = reader["Icq"].ToString();
                pro.Msn = reader["Msn"].ToString();
                pro.Blog = reader["Blog"].ToString();
                pro.HomePage = reader["HomePage"].ToString();
                pro.Avatar = reader["Avatar"].ToString();
                pro.Signature = reader["Signature"].ToString();
                pro.AlwaysSig = bool.Parse(reader["AlwaysSig"].ToString());
                pro.IsEmailPublished = bool.Parse(reader["IsEmailPublished"].ToString());
                pro.TotalPosts = int.Parse(reader["TotalPosts"].ToString());
                pro.LastLogin = DateTime.Parse(reader["LastLogin"].ToString());
                pro.UserStatus = bool.Parse(reader["UserStatus"].ToString());
                pro.Gender = bool.Parse(reader["Gender"].ToString());
                pro.LastBrowse = DateTime.Parse(reader["LastBrowse"].ToString());
                pro.MemberTitle = reader["MemberTitle"].ToString();
                pro.CanSendE = bool.Parse(reader["CanSendE"].ToString());
                grp.GroupName = reader["GroupName"].ToString();
                grp.RankImage = reader["RankImage"].ToString();
                mbr.IsActivated = bool.Parse(reader["IsActivated"].ToString());
                mbr.EnableLogin = bool.Parse(reader["EnableLogin"].ToString());
                pro.IP = reader["IP"].ToString();
                pro.CountLostPass = int.Parse(reader["CountLostPass"].ToString());
                pro.MyRSS = reader["MyRss"].ToString();
                if (reader["Posted"].ToString() != "")
                {
                    pro.Posted = DateTime.Parse(reader["Posted"].ToString());
                }
            }
        }

        public int SelectLastPost(EnMember mbr, ref EnMemberProfile pro)
        {
            string strCommandText = "selMemberLstPost";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@Post", SqlDbType.DateTime);
            paraLocal[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResut = int.Parse(paraLocal[1].Value.ToString());
            if (intResut > 0)
            {
                pro.Posted = DateTime.Parse(paraLocal[2].Value.ToString());
            }
            return intResut;
        }

        public SqlDataReader SelectTenPosts(EnMember mbr, ref int intId, EnMember mbr2)
        {
            string strCommandText = "selMemberTenPosts";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[1].Direction = ParameterDirection.Output;
            paraLocal[2] = new SqlParameter("@UserName", mbr2.UserName);
            SqlDataReader datrCate = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            intId = int.Parse(paraLocal[1].Value.ToString());
            return datrCate;
        }

        public void UpdateMember(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "updMemberPro";
            SqlParameter[] paraLocal = new SqlParameter[19];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            paraLocal[1] = new SqlParameter("@Email", member.Email);
            paraLocal[2] = new SqlParameter("@FullName", member.FullName);
            paraLocal[3] = new SqlParameter("@AboutMe", memberprofile.AboutMe);
            paraLocal[4] = new SqlParameter("@Interests", memberprofile.Interests);
            paraLocal[5] = new SqlParameter("@Job", memberprofile.Job);
            paraLocal[6] = new SqlParameter("@Location", memberprofile.Location);
            paraLocal[7] = new SqlParameter("@BirthDay", memberprofile.BirthDay);
            paraLocal[8] = new SqlParameter("@Yahoo", memberprofile.Yahoo);
            paraLocal[9] = new SqlParameter("@Aim", memberprofile.Aim);
            paraLocal[10] = new SqlParameter("@Icq", memberprofile.Icq);
            paraLocal[11] = new SqlParameter("@Msn", memberprofile.Msn);
            paraLocal[12] = new SqlParameter("@Blog", memberprofile.Blog);
            paraLocal[13] = new SqlParameter("@HomePage", memberprofile.HomePage);
            paraLocal[14] = new SqlParameter("@MemberTitle", memberprofile.MemberTitle);
            paraLocal[15] = new SqlParameter("@IsEmailPublished", memberprofile.IsEmailPublished);
            paraLocal[16] = new SqlParameter("@Gender", memberprofile.Gender);
            paraLocal[17] = new SqlParameter("@CanSendE", memberprofile.CanSendE);
            paraLocal[18] = new SqlParameter("@MyRss", memberprofile.MyRSS);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateMemberAd(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "updMemberProAd";
            SqlParameter[] paraLocal = new SqlParameter[28];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            paraLocal[1] = new SqlParameter("@Email", member.Email);
            paraLocal[2] = new SqlParameter("@FullName", member.FullName);
            paraLocal[3] = new SqlParameter("@AboutMe", memberprofile.AboutMe);
            paraLocal[4] = new SqlParameter("@Interests", memberprofile.Interests);
            paraLocal[5] = new SqlParameter("@Job", memberprofile.Job);
            paraLocal[6] = new SqlParameter("@Location", memberprofile.Location);
            paraLocal[7] = new SqlParameter("@BirthDay", memberprofile.BirthDay);
            paraLocal[8] = new SqlParameter("@Yahoo", memberprofile.Yahoo);
            paraLocal[9] = new SqlParameter("@Aim", memberprofile.Aim);
            paraLocal[10] = new SqlParameter("@Icq", memberprofile.Icq);
            paraLocal[11] = new SqlParameter("@Msn", memberprofile.Msn);
            paraLocal[12] = new SqlParameter("@Blog", memberprofile.Blog);
            paraLocal[13] = new SqlParameter("@HomePage", memberprofile.HomePage);
            paraLocal[14] = new SqlParameter("@MemberTitle", memberprofile.MemberTitle);
            paraLocal[15] = new SqlParameter("@IsEmailPublished", memberprofile.IsEmailPublished);
            paraLocal[16] = new SqlParameter("@Gender", memberprofile.Gender);
            paraLocal[17] = new SqlParameter("@CanSendE", memberprofile.CanSendE);
            paraLocal[18] = new SqlParameter("@UserName", member.UserName);
            paraLocal[19] = new SqlParameter("@UserStatus", memberprofile.UserStatus);
            paraLocal[20] = new SqlParameter("@DateCreation", member.DateCreation);
            paraLocal[21] = new SqlParameter("@IsActivated", member.IsActivated);
            paraLocal[22] = new SqlParameter("@EnableLogin", member.EnableLogin);
            paraLocal[23] = new SqlParameter("@Signature", memberprofile.Signature);
            paraLocal[24] = new SqlParameter("@AlwaysSig", memberprofile.AlwaysSig);
            paraLocal[25] = new SqlParameter("@IP", memberprofile.IP);
            paraLocal[26] = new SqlParameter("@TotalPosts", memberprofile.TotalPosts);
            paraLocal[27] = new SqlParameter("@CountLostPass", memberprofile.CountLostPass);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateSignature(EnMember member, EnMemberProfile memberprofile)
        {
            string strCommandText = "updSignature";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@UserName", member.UserName);
            paraLocal[1] = new SqlParameter("@Signature", memberprofile.Signature);
            paraLocal[2] = new SqlParameter("@AlwaysSig", memberprofile.AlwaysSig);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectCanSendE(ref EnMember member, ref EnMemberProfile profile)
        {
            string strCommandText = "selCanSendE";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ToMember", member.UserName);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CrtCanSendE(datrTopic, ref member, ref profile);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

        private void CrtCanSendE(IDataReader reader, ref EnMember mbr, ref EnMemberProfile pro)
        {
            if (reader.Read())
            {
                mbr.Email = reader["Email"].ToString();
                pro.CanSendE = bool.Parse(reader["CanSendE"].ToString());
            }
        }

        public void SelectAlSign(EnMember member, ref EnMemberProfile profile)
        {
            string strCommandText = "selMemberPro";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@MemberId", member.MemberId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            if (datrTopic.Read())
            {
                profile.AlwaysSig = bool.Parse(datrTopic["AlwaysSig"].ToString());
            }
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
        }

    }
}
