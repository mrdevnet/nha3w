using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;

namespace SLMF.DataAccess
{
    public class DaAnalytics
    {
        public DaAnalytics()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public EnAnalytics SelectAnalytics(EnAnalytics analday)
        {
            EnAnalytics anal = new EnAnalytics();
            string strCommandText = "selAnalytics";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@DateAnaly", analday.Today);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            anal = CreateAnal(datrTopic);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
            return anal;
        }

        private EnAnalytics CreateAnal(IDataReader datrAnal)
        {
            EnAnalytics anal = new EnAnalytics();
            while (datrAnal.Read())
            {
                anal.Members = int.Parse(datrAnal["Members"].ToString());
                anal.Messages = int.Parse(datrAnal["Messages"].ToString());
                anal.Moderators = int.Parse(datrAnal["Moderators"].ToString());
                anal.Topics = int.Parse(datrAnal["Topics"].ToString());
                anal.NewestMemberId = int.Parse(datrAnal["NewestMemberId"].ToString());
                anal.RegisterCount = int.Parse(datrAnal["RegisterCount"].ToString());
                anal.LoginCount = int.Parse(datrAnal["LoginCount"].ToString());
            }
            return anal;
        }


    }
}