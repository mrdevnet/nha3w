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
    public class DaGroup
    {
        public DaGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertGuestGroup(EnMember mbr, EnMemberProfile mbrpro, EnGroup grp)
        {
            string strCommandText = "insRecGroup";
            SqlParameter[] paraLocal = new SqlParameter[8];
            paraLocal[0] = new SqlParameter("@Name", grp.GroupName);
            paraLocal[1] = new SqlParameter("@User", mbr.UserName);
            paraLocal[2] = new SqlParameter("@Password", mbr.Password);
            paraLocal[3] = new SqlParameter("@Salt", mbr.Salt);
            paraLocal[4] = new SqlParameter("@FullName", mbr.FullName);
            paraLocal[5] = new SqlParameter("@Location", mbrpro.Location);
            paraLocal[6] = new SqlParameter("@MemberTitle", mbrpro.MemberTitle);
            paraLocal[7] = new SqlParameter("@IP", mbrpro.IP);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectAllGroups()
        {
            string strCommandText = "selGroupsAll";
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectAllGroups2()
        {
            string strCommandText = "selGroupsAll";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public int DeleteGroup(EnGroup grp)
        {
            string strCommandText = "delGroup";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[1] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[1].Value.ToString());
        }

        public void SelectGroupDetails(ref EnGroup grp) // ref string strPass, ref DateTime dateLastLogin
        {
            string strCommandText = "selGroupDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@GroupId", grp.GroupId);
            SqlDataReader datrGrp = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateGroup(datrGrp, ref grp);
            if (datrGrp.IsClosed == false)
            {
                datrGrp.Close();
                datrGrp.Dispose();
            }
        }

        private void CreateGroup(IDataReader reader, ref EnGroup grp)
        {
            if (reader.Read())
            {
                grp.GroupName = reader["GroupName"].ToString();
                grp.GetPosts = int.Parse(reader["GetPosts"].ToString());
                grp.RankImage = reader["RankImage"].ToString();
                grp.PmLimit = int.Parse(reader["PmLimit"].ToString());
            }
        }

        public void InsertRankImage(EnGroup grp)
        {
            string strCommandText = "insRankImage";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@RankImage", grp.RankImage);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public SqlDataReader SelectRankImage()
        {
            string strCommandText = "selRankImage";
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
        }

        public void InsertGroup(EnGroup grp)
        {
            string strCommandText = "insGroups";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@GroupName", grp.GroupName);
            paraLocal[1] = new SqlParameter("@GetPosts", grp.GetPosts);
            paraLocal[2] = new SqlParameter("@RankImage", grp.RankImage);
            paraLocal[3] = new SqlParameter("@PmLimit", grp.PmLimit);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateGroups(EnGroup grp)
        {
            string strCommandText = "updGroups";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[1] = new SqlParameter("@GroupName", grp.GroupName);
            paraLocal[2] = new SqlParameter("@GetPosts", grp.GetPosts);
            paraLocal[3] = new SqlParameter("@RankImage", grp.RankImage);
            paraLocal[4] = new SqlParameter("@PmLimit", grp.PmLimit);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int InsertGroupsMembers(EnMember mbr, EnGroup grp)
        {
            string strCommandText = "insMbrsGrps";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[2].Value.ToString());
        }

        public void DeleteMbrGrp(EnMember mbr, EnGroup grp)
        {
            string strCommandText = "delMembersGroups";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@GroupId", grp.GroupId);
            paraLocal[1] = new SqlParameter("@MemberId", mbr.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }



    }
}
