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
    public class DaAvatar
    {
        public DaAvatar()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectAvatars(int intCategory)
        {
            string strCommandText = "selAvatars";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", intCategory);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return datrTopic;
        }

        public SqlDataReader SelectDataList()
        {
            string strCommandText = "selCategAvatar";
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            return datrTopic;
        }

        public void UpdateAvatar(EnAvatar av,EnMember mbr)
        {
            string strCommandText = "updAvatarMember";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@MemberId", mbr.MemberId);
            paraLocal[1] = new SqlParameter("@Avatar", av.Avatar);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAllAvar(int intCategory)
        {
            string strCommandText = "selAvatars";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", intCategory);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void InsertCategory(string strDescriptions)
        {
            string strCommandText = "insAvatarGrp";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@Descriptions", strDescriptions);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteAvatar(EnAvatar av)
        {
            string strCommandText = "delAvatar";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@AvatarId", av.AvatarId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void InsertAvatars(EnAvatar av, int intGrpId)
        {
            string strCommandText = "insAvatars";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@Avatar", av.Avatar);
            paraLocal[1] = new SqlParameter("@GroupId", intGrpId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteAvarGrp(int intGrpId)
        {
            string strCommandText = "delAvarGroup";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@CategoryId", intGrpId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

    }
}
