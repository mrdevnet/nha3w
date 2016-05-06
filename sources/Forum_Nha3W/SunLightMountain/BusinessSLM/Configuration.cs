using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuConfiguration
    {
        public BuConfiguration()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int SelectPostAgain()
        {
            DaConfiguration damoder = new DaConfiguration();
            int bolModer = damoder.SelectPostAgain();
            return bolModer;
        }

        public static void SelectConfiguration(ref EnConfig config)
        {
            DaConfiguration daConfig = new DaConfiguration();
            daConfig.SelectConfiguration(ref config);
        }

        public static void UpdateConfiguration(EnConfig config)
        {
            DaConfiguration daConfig = new DaConfiguration();
            daConfig.UpdateConfiguration(config);
        }

        public static DataTable SelectSearchUser()
        {
            DaConfiguration config = new DaConfiguration();
            return config.SelectSearchUser();
        }

        public static void InsertUpdateSearchMe(string strUserName, int intTypeId)
        {
            DaConfiguration config = new DaConfiguration();
            config.InsertUpdateSearchMe(strUserName, intTypeId);
        }



    }
}
