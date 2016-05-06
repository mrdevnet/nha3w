using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
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

        //public static System.Collections.Generic.List<EnTopics> SelectTopicLive(EnMember mbr)
        //{
        //    DaMemberProfile a = new DaMemberProfile();
        //    return a.SelectTopicLive(mbr);
        //}

        private static List<EnTopics> LstSelLive(EnMember mbr)
        {
            DaMemberProfile tp = new DaMemberProfile();
            string ch = "LstSelectLives" + mbr.UserName;
            if (BServer.Get(ch) == null) BServer.Insert(ch, tp.SelectTopicLive(mbr), "SelectLives");
            return (List<EnTopics>)BServer.Get(ch);
        }

        public static List<EnTopics> SelectLive(EnMember mbr)
        {
            List<EnTopics> tmp = new List<EnTopics>();
            tmp = LstSelLive(mbr);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectLives", true);
                tmp = LstSelLive(mbr);
            }
            return tmp;
        }

        public static int LoginMemberSuccess(EnMember member, EnMemberProfile memberprofile)
        {
            DaMemberProfile loginmem = new DaMemberProfile();
            int intResult = 0;
            intResult = loginmem.LoginMemberSuccess(member, memberprofile);
            return intResult;
        }

        public static int MemberLogin(EnMember member)
        {
            DaMemberProfile loginmem = new DaMemberProfile();
            int intResult = 0;
            intResult = loginmem.MemberLogin(member);
            return intResult;
        }

        public static void LogoutMember(EnMember member, EnMemberProfile memberprofile)
        {
            DaMemberProfile logoutmem = new DaMemberProfile();
            logoutmem.LogoutMember(member, memberprofile);
        }

        public static void UpdatePassword(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            DaMemberProfile logoutmem = new DaMemberProfile();
            logoutmem.UpdatePassword(member);
        }

        public static int SelectMemberIdFUser(EnMember member) // ref string strPass, ref DateTime dateLastLogin
        {
            DaMemberProfile logoutmem = new DaMemberProfile();
            return logoutmem.SelectMemberIdFUser(member);
        }

        //public static void SelectProfile(ref EnMember member, ref EnGroup group, ref EnMemberProfile profile)
        //{
        //    DaMemberProfile pro = new DaMemberProfile();
        //    pro.SelectMemberProfile(ref member, ref group, ref profile);
        //}

        //public static void SelectAlSign(EnMember member, ref EnMemberProfile profile)
        //{
        //    DaMemberProfile pro = new DaMemberProfile();
        //    pro.SelectAlSign(member, ref profile);
        //}

        //public static int LastPosted(EnMember mbr, ref EnMemberProfile pro)
        //{
        //    DaMemberProfile loginmem = new DaMemberProfile();
        //    int intResult = 0;
        //    intResult = loginmem.SelectLastPost(mbr, ref pro);
        //    return intResult;
        //}

        //public static SqlDataReader SelectTenPosts(EnMember mbr, ref int intId, EnMember mbr2)
        //{
        //    DaMemberProfile pro = new DaMemberProfile();
        //    SqlDataReader posts = pro.SelectTenPosts(mbr, ref intId, mbr2);
        //    return posts;
        //}
        //public static void UpdateMember(EnMember mbr, EnMemberProfile pro)
        //{
        //    DaMemberProfile pr = new DaMemberProfile();
        //    pr.UpdateMember(mbr, pro);
        //}

        //public static void UpdateMemberAd(EnMember mbr, EnMemberProfile pro)
        //{
        //    DaMemberProfile pr = new DaMemberProfile();
        //    pr.UpdateMemberAd(mbr, pro);
        //}

        //public static void UpdateSignature(EnMember mbr, EnMemberProfile pro)
        //{
        //    DaMemberProfile pr = new DaMemberProfile();
        //    pr.UpdateSignature(mbr, pro);
        //}

        //public static void SelectCanSendE(ref EnMember member, ref EnMemberProfile profile)
        //{
        //    DaMemberProfile pro = new DaMemberProfile();
        //    pro.SelectCanSendE(ref member, ref profile);
        //}
    }
}

