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
using SLMF.Utility;
using System.Collections;

namespace SLMF.DataAccess
{
    public class DaSponsor
    {
        public DaSponsor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectSponsorId(EnTopic tpc)
        {
            string strCommandText = "selSponsorId";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            SqlDataReader t = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return t;
        }

        public int SelectRandId(EnTopic tpc)
        {
            ArrayList arrSp = new ArrayList();
            SqlDataReader datrId = SelectSponsorId(tpc);
            while (datrId.Read())
            {
                arrSp.Add(datrId["SponsorId"].ToString());
            }
            if (datrId.IsClosed == false)
            {
                datrId.Close();
                datrId.Dispose();
            }
            int NumberOfId = arrSp.Count; // 1,2,3,

            int intSp = 0;
            if (NumberOfId > 0)
            {
                while (intSp == 0)
                {
                    Random random = new Random((int)DateTime.Now.Ticks);
                    int idx = random.Next(0, NumberOfId);

                    intSp = int.Parse(arrSp[idx].ToString());
                }
            }
            return intSp;
        }

        public void SelectScript(ref EnSponsor sp)
        {
            string strCommandText = "selSponsorScript";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@SponsorId", sp.SponsorId);
            SqlDataReader t = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateScript(t, ref sp);
            if (t.IsClosed == false)
            {
                t.Close();
                t.Dispose();
            }
        }

        private void CreateScript(IDataReader r, ref EnSponsor sp)
        {
            if (r.Read())
            {
                sp.Scripts = r["Scripts"].ToString();
                sp.Description = r["Description"].ToString();
            }
        }

        public DataTable SelectAllSponsors()
        {
            string strCommandText = "selAllSponsors";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectSpnFrm(EnSponsor spn)
        {
            string strCommandText = "selSponsorDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@SponsorId", spn.SponsorId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void UpdateScripts(EnSponsor spn)
        {
            string strCommandText = "updSponsor";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@SponsorId", spn.SponsorId);
            paraLocal[1] = new SqlParameter("@Scripts", spn.Scripts);
            paraLocal[2] = new SqlParameter("@Description", spn.Description);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void InsertScripts(EnSponsor spn, EnForum frm)
        {
            string strCommandText = "insSponsor";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@Scripts", spn.Scripts);
            paraLocal[1] = new SqlParameter("@Description", spn.Description);
            paraLocal[2] = new SqlParameter("@ForumId", frm.ForumId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public int InsertFrmSpn(EnSponsor spn, EnForum frm)
        {
            string strCommandText = "insForumSponsor";
            SqlParameter[] paraLocal = new SqlParameter[3];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            paraLocal[1] = new SqlParameter("@SponsorId", spn.SponsorId);
            paraLocal[2] = new SqlParameter("@Result", SqlDbType.SmallInt);
            paraLocal[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            return int.Parse(paraLocal[2].Value.ToString());
        }

        public void DeleteSpn(EnSponsor spn)
        {
            string strCommandText = "delSponsor";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@SponsorId", spn.SponsorId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteFrmSpn(EnSponsor spn, EnForum frm)
        {
            string strCommandText = "delForumSponsor";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@SponsorId", spn.SponsorId);
            paraLocal[1] = new SqlParameter("@ForumId", frm.ForumId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        //public void SelectSpDetails(ref EnSponsor spn)
        //{
        //    string strCommandText = "selSponsorScript";
        //    SqlParameter[] paraLocal = new SqlParameter[1];
        //    paraLocal[0] = new SqlParameter("@SponsorId", spn.SponsorId);
        //    SqlDataReader datrBlock = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
        //    spn = CreateSpn(datrBlock);
        //    if (datrBlock.IsClosed == false)
        //    {
        //        datrBlock.Close();
        //        datrBlock.Dispose();
        //    }
        //}

        //private EnSponsor CreateSpn(IDataReader datrMbr)
        //{
        //    EnSponsor blcMbr = new EnSponsor();
        //    while (datrMbr.Read())
        //    {
        //        blcMbr.Scripts = int.Parse(datrMbr["BlockId"].ToString());
        //        blcMbr.Description = bool.Parse(datrMbr["Status"].ToString());
        //        blcMbr.Start = DateTime.Parse(datrMbr["Start"].ToString());
        //        blcMbr.Finish = DateTime.Parse(datrMbr["Finish"].ToString());
        //        blcMbr.Reason = datrMbr["Reason"].ToString();
        //        blcMbr.Moderator = int.Parse(datrMbr["Moderator"].ToString());
        //    }
        //    return blcMbr;
        //}

    }
}
