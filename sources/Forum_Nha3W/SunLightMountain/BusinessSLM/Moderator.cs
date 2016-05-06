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
    public class BuModerator
    {
        public BuModerator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public static SqlDataReader SelectModerator(EnModerator moderator, ref int intResult)
        //{
        //    DaModerator damoder = new DaModerator();
        //    SqlDataReader datrCate = damoder.SelectModerator(moderator,  ref intResult);
        //    return datrCate;
        //}

        private static List<EnModerator> LstSelModerators(EnModerator moderator, ref int intResult)
        {
            DaModerator damoder = new DaModerator();
            string ch = "LstSelModerators" + moderator.ForumId;
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, damoder.SelectModerator(moderator, ref intResult), "SelectModerators");
            }
            return (List<EnModerator>)BServer.Get(ch);
        }

        public static List<EnModerator> SelectModerator(EnModerator moderator, ref int intResult)
        {
            List<EnModerator> tmp = new List<EnModerator>();
            tmp = LstSelModerators(moderator, ref intResult);
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("SelectModerators", true);
                tmp = LstSelModerators(moderator, ref intResult);
            }
            
            return tmp;
        }



        public static EnMemberAuthorize SelectExistModer(EnForum frm, EnMember mbr,string aut)
        {
            DaModerator moder = new DaModerator();
            EnMemberAuthorize atr = new EnMemberAuthorize();
            atr = moder.SelectExistModer(frm, mbr, aut);
            return atr;
        }

        public static bool SelectIsModer(EnMember mbr)
        {
            DaModerator damoder = new DaModerator();
            bool bolModer = damoder.SelectIsModer(mbr);
            return bolModer;
        }

        public static int InsertModer(EnModerator moderator)
        {
            DaModerator damoder = new DaModerator();
            return damoder.InsertModer(moderator);
        }

        public static DataTable SelectGrpFrmUsers(EnModerator moderator)
        {
            DaModerator damoder = new DaModerator();
            return damoder.SelectGrpFrmUsers(moderator);
        }

        public static DataTable SelectAllModers()
        {
            DaModerator damoder = new DaModerator();
            return damoder.SelectAllModers();
        }

        public static void DeleteModerator(EnModerator moderator)
        {
            DaModerator damoder = new DaModerator();
            damoder.DeleteModerator(moderator);
        }

    }
}
