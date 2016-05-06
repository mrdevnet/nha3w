using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuAlarm
    {
        public BuAlarm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertAlarm(EnAlarm alarm)
        {
            DaAlarm daal = new DaAlarm();
            daal.InsertAlarm(alarm);
        }

        public static DataTable SelectAlarm()
        {
            DaAlarm daal = new DaAlarm();
            return daal.SelectAlarm();
        }

        public static void DeleteAlarm(EnAlarm lrm)
        {
            DaAlarm daal = new DaAlarm();
            daal.DeleteAlarm(lrm);
        }

        public static void SelectAlarmDetails(ref EnAlarm alrm)
        {
            DaAlarm lrm = new DaAlarm();
            lrm.SelectAlarmDetails(ref alrm);
        }
    }
}
