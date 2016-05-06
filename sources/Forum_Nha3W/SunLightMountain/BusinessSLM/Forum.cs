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
using System.Collections.Generic;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuForum
    {
        public BuForum()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public static SqlDataReader SelectForum(EnCategory category, EnMember mbr)
        //{
        //    DaForum forum = new DaForum();
        //    SqlDataReader datrCate = forum.SelectForum(category, mbr);
        //    return datrCate;
        //}

        private static List<EnForum> LstSelForum(EnCategory category, EnMember mbr)
        {
            DaForum forum = new DaForum();
            string ch = "LstSelForums" + category.CategoryId + mbr.UserName;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, forum.SelectForum(category, mbr), "SelectForums");
            }
            return (List<EnForum>)BServer.Get(ch);
        }

        public static List<EnForum> SelectForum(EnCategory category, EnMember mbr)
        {
            List<EnForum> tmp = new List<EnForum>();
            tmp = LstSelForum(category, mbr);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectForums", true);
                tmp = LstSelForum(category, mbr);
            }
            return tmp;
        }

        public static SqlDataReader SelectForumSubDesc(EnForum forum)
        {
            DaForum forumnew = new DaForum();
            SqlDataReader datrCate = forumnew.SelectForumSubDesc(forum);
            return datrCate;
        }

        public static void SelectForumInCate(ref EnForum forum, ref EnCategory category)
        {
            DaForum forumnew = new DaForum();
            forumnew.SelectForumInCate(ref forum, ref category);
        }

        public static EnForum SelectForumDetails(ref int intResult, EnForum forum, ref EnTopic topic,  
                                                    ref EnMessage message, ref EnMember member)
        {
            DaForum daforum = new DaForum();
            EnForum newforum = new EnForum();

            newforum = daforum.SelectForumDetails(ref intResult, forum, ref topic, ref message, ref member);
            return newforum;
        }

        //public static SqlDataReader SelectSub(EnForum forum, ref int intResult)
        //{
        //    DaForum daforum = new DaForum();
        //    SqlDataReader datrCate = daforum.SelectSub(forum, ref intResult);
        //    return datrCate;
        //}

        private static List<EnForum> LstSelSubs(EnForum forum, ref int intResult)
        {
            DaForum daforum = new DaForum();
            string ch = "LstSelSubs" + forum.ForumId;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, daforum.SelectSub2(forum, ref intResult), "SelectSubs");
            }
            return (List<EnForum>)BServer.Get(ch);
        }

        public static List<EnForum> SelectSub2(EnForum forum, ref int intResult)
        {
            List<EnForum> tmp = new List<EnForum>();
            tmp = LstSelSubs(forum, ref intResult);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectSubs", true);
                tmp = LstSelSubs(forum, ref intResult);
            }
            return tmp;
        }



        public static EnForum SelectSubInF(EnForum forum)
        {
            DaForum daforum = new DaForum();
            EnForum forumnew = new EnForum();
            forumnew = daforum.SelectSubInF(forum);
            return forumnew;
        }

        public static SqlDataReader SelectJump(EnCategory cate, EnMember mbr)
        {
            DaForum j = new DaForum();
            SqlDataReader datrj = j.SelectJumper(cate, mbr);
            return datrj;
        }

        public static SqlDataReader SelectJump2(EnForum frm, EnMember mbr)
        {
            DaForum j = new DaForum();
            SqlDataReader datrj = j.SelectJumper2(frm, mbr);
            return datrj;
        }

        public static bool SelectPafrm(ref EnForum frm)
        {
            bool reslt = false;
            DaForum f = new DaForum();
            reslt = f.SelectPaForum(ref frm);
            return reslt;
        }

        //public static SqlDataReader SelectForumAnalytics()
        //{
        //    DaForum f = new DaForum();
        //    SqlDataReader r = f.SelectForumAnalytics();
        //    return r;
        //}

        private static EnAnalytics LstSelFrmAnal()
        {
            DaForum f = new DaForum();
            string ch = "LstSelFrmAnals";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, f.SelectForumAnalytics(), "SelectFrmAnals");
            }
            return (EnAnalytics)BServer.Get(ch);
        }

        public static EnAnalytics SelectForumAnalytics()
        {
            EnAnalytics tmp = new EnAnalytics();
            tmp = LstSelFrmAnal();
            if (tmp == null || tmp.Members == 0)
            {
                BServer.Remove("SelectFrmAnals", true);
                tmp = LstSelFrmAnal();
            }
            return tmp;
        }




        public static int SelectItemCount(EnForum forum)
        {
            DaForum n = new DaForum();
            int intItems = n.SelectItemCount(forum);
            return intItems;
        }

        public static int SelectTopicInF(EnForum forum)
        {
            DaForum n = new DaForum();
            int intItems = n.SelectTopicInF(forum);
            return intItems;
        }

        public static int SelectLstCount(string strLst, EnMember mbr)
        {
            DaForum n = new DaForum();
            int intItems = n.SelectLstCount(strLst, mbr);
            return intItems;
        }

        public static int SelectItemCountSort(EnForum forum, int intSortId)
        {
            DaForum n = new DaForum();
            int intItems = n.SelectItemCountSort(forum, intSortId);
            return intItems;
        }

        public static SqlDataReader SelectAllForumType()
        {
            DaForum frm = new DaForum();
            return frm.SelectAllForumType();
        }

        public static void InsertForums(EnForum forum)
        {
            DaForum frm = new DaForum();
            frm.InsertForums(forum);
        }

        public static DataTable SelectAllForums(EnForum frm)
        {
            DaForum dafrm = new DaForum();
            return dafrm.SelectAllForums(frm);
        }

        public static void DeleteForum(EnForum frm)
        {
            DaForum dafrm = new DaForum();
            dafrm.DeleteForum(frm);
        }

        public static void SelectForumFrId(ref EnForum forum, ref EnForum frm2, ref EnForumType type, ref EnCategory cate)
        {
            DaForum dafrm = new DaForum();
            dafrm.SelectForumFrId(ref forum, ref frm2, ref type, ref cate);
        }

        public static void UpdateForums(EnForum forum)
        {
            DaForum daFrm = new DaForum();
            daFrm.UpdateForums(forum);
        }

        public static DataTable SelectAllGrpFrm(EnForum frm)
        {
            DaForum daFrm = new DaForum();
            return daFrm.SelectAllGrpFrm(frm);
        }

        public static EnMemberAuthorize SelectGrpFrmAuthor(EnGroup grp, EnForum frm)
        {
            DaForum daFrm = new DaForum();
            return daFrm.SelectGrpFrmAuthor(grp, frm);
        }

        public static int UpdateGrpFrmAuthor(EnMemberAuthorize frm, int intTypeId, int intDefault)
        {
            DaForum daFrm = new DaForum();
            return daFrm.UpdateGrpFrmAuthor(frm, intTypeId, intDefault);
        }

        public static void DeleteGrpFrmAuthor(EnMemberAuthorize mbr)
        {
            DaForum daFrm = new DaForum();
            daFrm.DeleteGrpFrmAuthor(mbr);
        }

        public static DataTable SelectPrivFrms()
        {
            DaForum dafrm = new DaForum();
            return dafrm.SelectPrivFrms();
        }

        public static DataTable SelectPrivUserFrm(EnForum frm)
        {
            DaForum daFrm = new DaForum();
            return daFrm.SelectPrivUserFrm(frm);
        }

        public static bool InsertPrivUsersFrms(EnForum forum, EnMember mbr)
        {
            DaForum daFrm = new DaForum();
            return daFrm.InsertPrivUsersFrms(forum, mbr);
        }

        public static void DeletePrivUsersFrms(EnForum forum, EnMember mbr)
        {
            DaForum daFrm = new DaForum();
            daFrm.DeletePrivUsersFrms(forum, mbr);
        }

    }
}
