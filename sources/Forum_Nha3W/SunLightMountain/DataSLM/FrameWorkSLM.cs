using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using SLMF.Utility;


namespace SLMF.DataAccess
{
    public abstract class SqlHelper
    {

        // Hashtable to store cached parameters
        private static Hashtable parasCache = Hashtable.Synchronized(new Hashtable());

        public static void ExecuteNonQuery(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(UtiGeneralClass.ConnectionString);
            try
            {
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open) SqlConnection.ClearPool(connect);
                throw ex;
            }
            //finally
            //{
            //}
        }

        public static DataTable ExecuteData(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(UtiGeneralClass.ConnectionString);
            try
            {
                DataTable dattTopic = new DataTable();
                SqlDataAdapter dataTopic = new SqlDataAdapter(cmdCommand);
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                dataTopic.Fill(dattTopic);
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
                return dattTopic;
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open) SqlConnection.ClearPool(connect);
                throw ex;
            }
            //finally
            //{
            //    connect.Close();
            //    SqlConnection.ClearPool(connect);
            //}
        }

        public static SqlDataReader ExecuteReader(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connConnection = new SqlConnection(UtiGeneralClass.ConnectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmdCommand, connConnection, null, cmdCommandType, cmdCommandString, cmdParameters);
                SqlDataReader datrDataReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
                cmdCommand.Parameters.Clear();
                return datrDataReader;
            }
            catch (SqlException ex)
            {
                connConnection.Close();
                SqlConnection.ClearPool(connConnection);
                throw ex;
            }
        }

        private static void PrepareCommand(SqlCommand cmdCommand, SqlConnection connConnection, SqlTransaction trasTransaction,
                                            CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)
        {
            if (connConnection.State != ConnectionState.Open)
            {
                connConnection.Open();
            }
            cmdCommand.Connection = connConnection;
            cmdCommand.CommandText = cmdCommandString;
            if (trasTransaction != null)
            {
                cmdCommand.Transaction = trasTransaction;
            }
            cmdCommand.CommandType = cmdCommandType;
            if (cmdParameters != null)
            {
                foreach (SqlParameter para in cmdParameters)
                {
                    cmdCommand.Parameters.Add(para);
                }
            }
        }

        public static void PrepareCommand(SqlCommand cmdCommand, CommandType cmdCommandType, string cmdCommandString,
                                            SqlParameter[] cmdParameters)
        {
            cmdCommand.Parameters.Clear();
            cmdCommand.CommandType = cmdCommandType;
            cmdCommand.CommandText = cmdCommandString;
            if (cmdParameters != null)
                foreach (SqlParameter para in cmdParameters)
                    cmdCommand.Parameters.Add(para);
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParameters)
        {
            parasCache[cacheKey] = cmdParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parasCache[cacheKey];

            if (cachedParms == null)
            {
                return null;
            }
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }

    }
}
