using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuPriority
    {
        public BuPriority()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectPriority()
        {
            DaPriority report = new DaPriority();
            SqlDataReader datrReport = report.SelectPriority();
            return datrReport;
        }

        public static DataTable SelectAllPrio()
        {
            DaPriority report = new DaPriority();
            return report.SelectAllPrio();
        }

    }

}
