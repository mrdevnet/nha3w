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

/// <summary>
/// Summary description for Bus_IdType
/// </summary>
/// 
namespace SLMF.Business
{
    public class BuMember
    {
        public BuMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int CheckMemberExists(EnMember member)
        {
            DaMember MemExists = new DaMember();
            int intResult = 0;
            intResult = MemExists.CheckMemberExists(member);
            return intResult;
        }

        public static int MemberLogin(EnMember member)
        {
            DaMember MemberLogin = new DaMember();
            int intResult = 0;
            intResult = MemberLogin.MemberLogin(member);
            return intResult;
        }

        public static EnMember SelectMemberIdFUser(EnMember account)
        {
            DaMember DaMember = new DaMember();
            EnMember newAccount = new EnMember();
            newAccount = DaMember.SelectMemberIdFUser(account);
            return newAccount;
        }

        public static EProfile PMember(EnMember m)
        {
            DaMember mr = new DaMember();
            return mr.PMember(m);
        }

        public static bool SelectMemberGuest(EnMember mbr)
        {
            bool res = false;
            DaMember r = new DaMember();
            res = r.SelectMemberGuest(mbr);
            return res;
        }

        public static SqlDataReader SelectMemberLst(EnPagerF pager)
        {
            DaMember topic = new DaMember();
            SqlDataReader datrTopic = topic.SelectMemberLst(pager);
            return datrTopic;
        }

        public static int SelectMbrCount()
        {
            DaMember n = new DaMember();
            int intItems = n.SelectMbrLstCount();
            return intItems;
        }

        public static SqlDataReader SelectMbrSch(string strSearch, EnPagerF pager)
        {
            DaMember topic = new DaMember();
            SqlDataReader datrTopic = topic.SelectMbrSearch(strSearch, pager);
            return datrTopic;
        }

        public static int SelectMbrSchCount(string strSearch)
        {
            DaMember n = new DaMember();
            int intItems = n.SelectMbrSchCount(strSearch);
            return intItems;
        }

        public static void SelectMemberFromId(ref EnMember mbr)
        {
            DaMember da = new DaMember();
            da.SelectMemberFromId(ref mbr);
        }

        public static void UpdatePass(EnMember mbr)
        {
            DaMember da = new DaMember();
            da.UpdatePassword(mbr);
        }

        public static int SelectEmailLostPass(ref EnMember member)
        {
            DaMember MemExists = new DaMember();
            int intResult = 0;
            intResult = MemExists.SelectEmailLostPass(ref member);
            return intResult;
        }

        public static int SelectResetPass(ref EnMember member)
        {
            DaMember MemExists = new DaMember();
            int intResult = 0;
            intResult = MemExists.SelectResetPass(ref member);
            return intResult;
        }

        public static DataTable SelectSearchUser(EnMember mbr, EnGroup grp, int intTypeId)
        {
            DaMember daMbr = new DaMember();
            return daMbr.SelectSearchUser(mbr, grp, intTypeId);
        }

        public static void DeleteMember(EnMember mbr)
        {
            DaMember daMbr = new DaMember();
            daMbr.DeleteMember(mbr);
        }

        public static DataTable SelectUserGroup(EnMember mbr)
        {
            DaMember daMbr = new DaMember();
            return daMbr.SelectUserGroup(mbr);
        }

        public static DataTable SelectGrpDetails(EnMember mbr)
        {
            DaMember daMbr = new DaMember();
            return daMbr.SelectGrpDetails(mbr);
        }

        public static DataTable SelectAllAdmins()
        {
            DaMember daMbr = new DaMember();
            return daMbr.SelectAllAdmins();
        }

        public static bool IsModer2(EnMember member, EnForum frm)
        {
            DaMember daMbr = new DaMember();
            return daMbr.IsModer(member, frm);
        }

        public static bool IsModer(EnMember mbr)
        {
            DaModerator damoder = new DaModerator();
            return damoder.SelectIsModer(mbr);
        }

        public static bool IsSuperModer(EnMember member)
        {
            DaMember daMbr = new DaMember();
            return daMbr.IsSuperModer(member);
        }

        public static bool IsAdmin(EnMember member)
        {
            DaMember daMbr = new DaMember();
            return daMbr.IsAdmin(member);
        }
    }
}
