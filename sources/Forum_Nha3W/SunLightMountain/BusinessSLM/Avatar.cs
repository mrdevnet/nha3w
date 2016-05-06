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
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuAvatar
    {
        public BuAvatar()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectAvatars(int intCategory)
        {
            DaAvatar v = new DaAvatar();
            SqlDataReader datrTopic = v.SelectAvatars(intCategory);
            return datrTopic;
        }

        public static SqlDataReader SelectDataList()
        {
            DaAvatar v = new DaAvatar();
            SqlDataReader datrTopic = v.SelectDataList();
            return datrTopic;
        }

        public static void UpdateAvatar(EnAvatar av, EnMember mbr)
        {
            DaAvatar v = new DaAvatar();
            v.UpdateAvatar(av, mbr);
        }

        public static DataTable SelectAllAvar(int intCategory)
        {
            DaAvatar v = new DaAvatar();
            return v.SelectAllAvar(intCategory);
        }

        public static void InsertCategory(string strDescriptions)
        {
            DaAvatar v = new DaAvatar();
            v.InsertCategory(strDescriptions);
        }

        public static void DeleteAvatar(EnAvatar av)
        {
            DaAvatar v = new DaAvatar();
            v.DeleteAvatar(av);
        }

        public static void InsertAvatars(EnAvatar av, int intGrpId)
        {
            DaAvatar v = new DaAvatar();
            v.InsertAvatars(av, intGrpId);
        }

        public static void DeleteAvarGrp(int intGrpId)
        {
            DaAvatar v = new DaAvatar();
            v.DeleteAvarGrp(intGrpId);
        }
    }
}
