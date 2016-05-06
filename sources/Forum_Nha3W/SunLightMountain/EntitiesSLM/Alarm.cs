using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnAlarm
    {
        public EnAlarm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int alarmid;
        public int AlarmId
        {
            get { return alarmid; }
            set { alarmid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string report;
        public string Report
        {
            get { return report; }
            set { report = value; }
        }

        private DateTime alarmtime;
        public DateTime AlarmTime
        {
            get { return alarmtime; }
            set { alarmtime = value; }
        }

        private int priority;
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private int messageid;
        public int MessageId
        {
            get { return messageid; }
            set { messageid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }
    }
}
