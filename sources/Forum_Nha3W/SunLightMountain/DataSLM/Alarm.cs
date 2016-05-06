using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;


namespace SLMF.DataAccess
{
    public class DaAlarm
    {
        public DaAlarm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertAlarm(EnAlarm alarm)
        {
            string strCommandText = "insAlarms";
            SqlParameter[] paraLocal = new SqlParameter[5];
            paraLocal[0] = new SqlParameter("@Title", alarm.Title);
            paraLocal[1] = new SqlParameter("@Report", SqlDbType.NText);
            paraLocal[1].Value = alarm.Report;
            paraLocal[2] = new SqlParameter("@Priority", alarm.Priority);
            paraLocal[3] = new SqlParameter("@MessageId", alarm.MessageId);
            paraLocal[4] = new SqlParameter("@MemberId", alarm.MemberId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public DataTable SelectAlarm()
        {
            string strCommandText = "selAlarmsAll";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public void DeleteAlarm(EnAlarm lrm)
        {
            string strCommandText = "delAlarms";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@AlarmId", lrm.AlarmId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void SelectAlarmDetails(ref EnAlarm alrm)
        {
            string strCommandText = "selAlarmDetail";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@AlarmId", alrm.AlarmId);
            SqlDataReader datrGrp = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateAlarm(datrGrp, ref alrm);
            if (datrGrp.IsClosed == false)
            {
                datrGrp.Close();
                datrGrp.Dispose();
            }
        }

        private void CreateAlarm(IDataReader reader, ref EnAlarm lrm)
        {
            if (reader.Read())
            {
                lrm.Title = reader["Title"].ToString();
                lrm.Report = reader["Report"].ToString();
                lrm.AlarmTime = DateTime.Parse(reader["AlarmTime"].ToString());
            }
        }

    }

}
