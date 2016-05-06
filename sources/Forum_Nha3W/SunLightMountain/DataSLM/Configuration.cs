using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;

namespace SLMF.DataAccess
{
    public class DaConfiguration
    {
        public DaConfiguration()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int SelectPostAgain()
        {
            string strCommandText = "selConfigPostAgain";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@Result", SqlDbType.Int);
            paraLocal[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
            int intResult = int.Parse(paraLocal[0].Value.ToString());
            return intResult;
        }

        public void SelectConfiguration(ref EnConfig config)
        {
            string strCommandText = "selConfiguration";
            SqlDataReader dtrConfig = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, null);

            CreateDtrConfig(dtrConfig, ref config);
            if (dtrConfig.IsClosed == false)
            {
                dtrConfig.Close();
                dtrConfig.Dispose();
            }
        }

        private void CreateDtrConfig(IDataReader reader, ref EnConfig config)
        {
            if (reader.Read())
            {
                config.AdminEmail = reader["AdminEmail"].ToString();
                config.AllowSignUp = bool.Parse(reader["AllowSignUp"].ToString());
                config.AllowLogIn = bool.Parse(reader["AllowLogIn"].ToString());
                config.MaxMsg = int.Parse(reader["MaxMsg"].ToString());
                config.SessionTimeOut = int.Parse(reader["SessionTimeOut"].ToString());
                config.GuestSearch = bool.Parse(reader["GuestSearch"].ToString());
                config.GuestProfile = bool.Parse(reader["GuestProfile"].ToString());
                config.GuestMember = bool.Parse(reader["GuestMember"].ToString());
                config.HideRecyleForum = bool.Parse(reader["HideRecyleForum"].ToString());
                config.ActiveMember = bool.Parse(reader["ActiveMember"].ToString());
                config.ReviewMember = bool.Parse(reader["ReviewMember"].ToString());
                config.TimePostAgain = int.Parse(reader["TimePostAgain"].ToString());
                config.Max = int.Parse(reader["Max"].ToString());
                config.AddSite = DateTime.Parse(reader["AddSite"].ToString());
            }
        }

        public void UpdateConfiguration(EnConfig config)
        {
            string strCommandText = "updConfiguration";
            SqlParameter[] paraLocal = new SqlParameter[13];
            paraLocal[0] = new SqlParameter("@AdminEmail", config.AdminEmail);
            paraLocal[1] = new SqlParameter("@AllowSignUp", config.AllowSignUp);
            paraLocal[2] = new SqlParameter("@AllowLogIn", config.AllowLogIn);
            paraLocal[3] = new SqlParameter("@MaxMsg", config.MaxMsg);
            paraLocal[4] = new SqlParameter("@SessionTimeOut", config.SessionTimeOut);
            paraLocal[5] = new SqlParameter("@GuestSearch", config.GuestSearch);
            paraLocal[6] = new SqlParameter("@GuestProfile", config.GuestProfile);
            paraLocal[7] = new SqlParameter("@GuestMember", config.GuestMember);
            paraLocal[8] = new SqlParameter("@HideRecyleForum", config.HideRecyleForum);
            paraLocal[9] = new SqlParameter("@ActiveMember", config.ActiveMember);
            paraLocal[10] = new SqlParameter("@ReviewMember", config.ReviewMember);
            paraLocal[11] = new SqlParameter("@TimePostAgain", config.TimePostAgain);
            paraLocal[12] = new SqlParameter("@Max", config.Max);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectSearchUser()
        {
            string strCommandText = "selSearchMe";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void InsertUpdateSearchMe(string strUserName, int intTypeId)
        {
            string strCommandText = "insSearchMe";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@FromMember", strUserName);
            paraLocal[1] = new SqlParameter("@TypeId", intTypeId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }


    }
}
