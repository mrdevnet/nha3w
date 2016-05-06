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
    public class DaInformation
    {
        public DaInformation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertMemberSession(EnInformation infor, EnMember mbr)
        {
            string strCommandText = "selMembersLog";
            SqlParameter[] paraLocal = new SqlParameter[7];
            paraLocal[0] = new SqlParameter("@DetailId", infor.DetailId);
            paraLocal[1] = new SqlParameter("@ForumId", infor.ForumId);
            paraLocal[2] = new SqlParameter("@TopicId", infor.TopicId);
            paraLocal[3] = new SqlParameter("@MessageId", infor.MessageId);
            paraLocal[4] = new SqlParameter("@GroupId", infor.GroupId);
            paraLocal[5] = new SqlParameter("@Member", mbr.UserName);
            paraLocal[6] = new SqlParameter("@IP", infor.IP);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectMemberOnline(ref int f1, ref int f2, ref int f3, ref int f4, ref DateTime f5)
        {
            string strCommandText = "selMembersAnal";
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            CreateR(r, ref f1, ref f2, ref f3, ref f4, ref f5);
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
        }

        private void CreateR(IDataReader reader, ref int f1, ref int f2, ref int f3, ref int f4, ref DateTime f5)
        {
            if (reader.Read())
            {
                f1 = int.Parse(reader["TotalMembers"].ToString());
                f2 = int.Parse(reader["TotalViews"].ToString());
                f3 = int.Parse(reader["TotalActions"].ToString());
                if (reader["MaxSite"].ToString() == "")
                {
                    f4 = 1;
                    f5 = DateTime.Now;
                }
                else
                {
                    f4 = int.Parse(reader["MaxSite"].ToString());
                    f5 = DateTime.Parse(reader["AddView"].ToString());
                }
            }
        }

        public SqlDataReader SelectMemberDetails()
        {
            string strCommandText = "selMembersNet";
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            return r;
        }

        public string SelectMemberViews(EnForum frm, EnTopic tpc)
        {
            string strRes = "";
            string strCommandText = "selMembersView";
            SqlParameter[] paraLocal = new SqlParameter[2];
            if (frm == null)
            {
                paraLocal[0] = new SqlParameter("@ForumId", null);
            }
            else
            {
                paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            }
            if (tpc == null)
            {
                paraLocal[1] = new SqlParameter("@TopicId", null);
            }
            else
            {
                paraLocal[1] = new SqlParameter("@TopicId", tpc.TopicId);
            }
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            if (r.Read())
            {
                strRes = "Có " + r["TotalMembers"].ToString() + " người dùng đang xem (";
                if (int.Parse(r["TotalViews"].ToString()) > 0)
                {
                    strRes += r["TotalViews"].ToString() + " thành viên - ";
                    strRes += r["TotalActions"].ToString() + " khách) : ";
                }
                else
                {
                    strRes += r["TotalActions"].ToString() + " khách)";
                }
            }
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return strRes;
        }

        public SqlDataReader SelectMemberDatas(EnForum frm, EnTopic tpc)
        {
            string strCommandText = "selMembersDatas";
            SqlParameter[] paraLocal = new SqlParameter[2];
            if (frm == null)
            {
                paraLocal[0] = new SqlParameter("@ForumId", null);
            }
            else
            {
                paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            }
            if (tpc == null)
            {
                paraLocal[1] = new SqlParameter("@TopicId", null);
            }
            else
            {
                paraLocal[1] = new SqlParameter("@TopicId", tpc.TopicId);
            }
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return r;
        }

        public int SelectForumViewing(EnForum frm)
        {
            int i = 0, l = 0;
            string strCommandText = "selForumNet";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            i = CreateNet(r);
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }

            DaForum f = new DaForum();
            SqlDataReader r2 = f.SelectSub(frm, ref l);
            if (l > 0)
            {
                i += CreateNet2(r2);
            }
            if (r2.IsClosed == false)
            {
                r2.Close();
                r2.Dispose();
            }
            return i;
        }

        private int CreateNet(IDataReader reader)
        {
            int i = 0;
            if (reader.Read())
            {
                i = int.Parse(reader["Net"].ToString());
            }
            return i;
        }

        private int CreateNet2(IDataReader reader)
        {
            int i = 0;
            SqlDataReader r = null;
            while (reader.Read())
            {
                int l = 0;
                l = int.Parse(reader["ForumId"].ToString());

                string strCommandText = "selForumNet";
                SqlParameter[] paraLocal = new SqlParameter[1];
                paraLocal[0] = new SqlParameter("@ForumId", l);
                r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
                i += CreateNet(r);
            }
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return i;
        }

        public string SelectTotalOnlines()
        {
            string strCommandText = "selInforOnline";
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            string strUser = CreateTotals(r);
            if (r.IsClosed == false)
            {
                r.Close();
                r.Dispose();
            }
            return strUser;
        }

        private string CreateTotals(IDataReader reader)
        {
            string strUsers = "";
            int intTotal = 0;
            int intMembers = 0;
            int intGuests = 0;
            if (reader.Read())
            {
                intTotal = int.Parse(reader["Total"].ToString());
                intMembers = int.Parse(reader["MemberOnline"].ToString());
            }
            intGuests = intTotal - intMembers;
            if (intMembers > 0 && intGuests >0)
            {
                strUsers = "Hiện đang có " + intMembers.ToString() +
                            " thành viên và " + intGuests.ToString() +
                            " khách Online";
            }
            else if (intMembers > 0 && intGuests == 0)
            {
                strUsers = "Hiện đang có " + intMembers.ToString() +
                            " thành viên Online";
            }
            else
            {
                strUsers = "Hiện đang có " + intGuests.ToString() +
                            " khách Online";
            }
            return strUsers;
        }

        public SqlDataReader SelectOnlineDatail()
        {
            string strCommandText = "selInforReview";
            SqlDataReader r = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);
            return r;
        }


        public bool PairNewMsg(int intType, string strView, DateTime TimeSrv)
        {
            string strCommandText = "selPairTime";
            SqlParameter[] paraLocal = new SqlParameter[4];
            paraLocal[0] = new SqlParameter("@Type", intType);
            paraLocal[1] = new SqlParameter("@View", strView);
            paraLocal[2] = new SqlParameter("@TimeServ", TimeSrv);
            paraLocal[3] = new SqlParameter("@Result", SqlDbType.Bit);
            paraLocal[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            bool intResut = false;
            intResut = bool.Parse(paraLocal[3].Value.ToString());
            return intResut;
        }

        public DataTable SelectViewOnline()
        {
            string strCommandText = "selAllInforDetails";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void DeleteInfor(EnInformation i)
        {
            string strCommandText = "delInforView";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@DetailId", i.DetailId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }
    }
}
