using System;

namespace HungLocSon.EHLS
{
    public class ETransOut
    {
        public ETransOut()
        {
        }

        private int transout;
        public int TransOut
        {
            get { return transout; }
            set { transout = value; }
        }

        private int feeid;
        public int FeeId
        {
            get { return feeid; }
            set { feeid = value; }
        }

        private int pid;
        public int PId
        {
            get { return pid; }
            set { pid = value; }
        }

        private int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private string feedesc;
        public string FeeDesc
        {
            get { return feedesc; }
            set { feedesc = value; }
        }

        private DateTime transdate;
        public DateTime TransDate
        {
            get { return transdate; }
            set { transdate = value; }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private string bymember;
        public string ByMember
        {
            get { return bymember; }
            set { bymember = value; }
        }

        public ETransOut(int c)
        {
            this.TransOut = c;
        }
    }
}
