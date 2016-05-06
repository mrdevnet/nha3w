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
    public class BuInformation
    {
        public BuInformation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertMemberSession(EnInformation infor, EnMember mbr)
        {
            DaInformation i = new DaInformation();
            i.InsertMemberSession(infor, mbr);
        }

        public static void SelectMemberOnline(ref int f1, ref int f2, ref int f3, ref int f4, ref DateTime f5)
        {
            DaInformation i = new DaInformation();
            i.SelectMemberOnline(ref f1, ref f2, ref f3, ref f4, ref f5);
        }

        public static SqlDataReader SelectMemberDetails()
        {
            DaInformation i = new DaInformation();
            SqlDataReader r = i.SelectMemberDetails();
            return r;
        }

        public static string SelectMemberViews(EnForum frm, EnTopic tpc)
        {
            DaInformation i = new DaInformation();
            string strRes = i.SelectMemberViews(frm, tpc);
            return strRes;
        }

        public static SqlDataReader SelectMemberDatas(EnForum frm, EnTopic tpc)
        {
            DaInformation i = new DaInformation();
            SqlDataReader r = i.SelectMemberDatas(frm, tpc);
            return r;
        }

        public static int SelectForumVieing(EnForum frm)
        {
            DaInformation i = new DaInformation();
            int v = i.SelectForumViewing(frm);
            return v;
        }

        public static string SelectWOnline()
        {
            DaInformation i = new DaInformation();
            string strUsers = i.SelectTotalOnlines();
            return strUsers;
        }

        public static SqlDataReader SelectOnlineDatail()
        {
            DaInformation i = new DaInformation();
            SqlDataReader r = i.SelectOnlineDatail();
            return r;
        }

        public static bool SelectPairTime(int intType, string strView, DateTime timeSrv)
        {
            DaInformation i = new DaInformation();
            return i.PairNewMsg(intType, strView, timeSrv);
        }

        public static DataTable SelectViewOnline()
        {
            DaInformation i = new DaInformation();
            return i.SelectViewOnline();
        }

        public static void DeleteInfor(EnInformation i)
        {
            DaInformation dai = new DaInformation();
            dai.DeleteInfor(i);
        }
    }
}
