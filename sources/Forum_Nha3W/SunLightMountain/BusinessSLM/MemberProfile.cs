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
    public class BuMemberProfile
    {
        public BuMemberProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertMembers(EnMember member, EnMemberProfile memberprofile)
        {
            DaMemberProfile insmember = new DaMemberProfile();
            int intResult = 0;
            intResult = insmember.InsertMembers(member, memberprofile);
            return intResult;
        }

        public static int LoginMemberSuccess(EnMember member, EnMemberProfile memberprofile)
        {
            DaMemberProfile loginmem = new DaMemberProfile();
            int intResult = 0;
            intResult = loginmem.LoginMemberSuccess(member, memberprofile);
            return intResult;
        }

        public static void LogoutMember(EnMember member, EnMemberProfile memberprofile)
        {
            DaMemberProfile logoutmem = new DaMemberProfile();
            logoutmem.LogoutMember(member, memberprofile);            
        }

        public static void SelectProfile(ref EnMember member, ref EnGroup group, ref EnMemberProfile profile)
        {
            DaMemberProfile pro = new DaMemberProfile();
            pro.SelectMemberProfile(ref member, ref group, ref profile);
        }

        public static void SelectAlSign(EnMember member, ref EnMemberProfile profile)
        {
            DaMemberProfile pro = new DaMemberProfile();
            pro.SelectAlSign(member, ref profile);
        }

        public static int LastPosted(EnMember mbr, ref EnMemberProfile pro)
        {
            DaMemberProfile loginmem = new DaMemberProfile();
            int intResult = 0;
            intResult = loginmem.SelectLastPost(mbr, ref pro);
            return intResult;
        }

        public static SqlDataReader SelectTenPosts(EnMember mbr, ref int intId, EnMember mbr2)
        {
            DaMemberProfile pro = new DaMemberProfile();
            SqlDataReader posts = pro.SelectTenPosts(mbr, ref intId, mbr2);
            return posts;
        }
        public static void UpdateMember(EnMember mbr, EnMemberProfile pro)
        {
            DaMemberProfile pr = new DaMemberProfile();
            pr.UpdateMember(mbr, pro);
        }

        public static void UpdateMemberAd(EnMember mbr, EnMemberProfile pro)
        {
            DaMemberProfile pr = new DaMemberProfile();
            pr.UpdateMemberAd(mbr, pro);
        }

        public static void UpdateSignature(EnMember mbr, EnMemberProfile pro)
        {
            DaMemberProfile pr = new DaMemberProfile();
            pr.UpdateSignature(mbr, pro);
        }

        public static void SelectCanSendE(ref EnMember member, ref EnMemberProfile profile)
        {
            DaMemberProfile pro = new DaMemberProfile();
            pro.SelectCanSendE(ref member, ref profile);
        }
    }
}
