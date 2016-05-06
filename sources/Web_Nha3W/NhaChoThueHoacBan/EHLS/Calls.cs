using System;

namespace HungLocSon.EHLS
{
    public class ECalls
    {
        public ECalls()
        {
        }

        private int callid;
        public int CallId
        {
            get { return callid; }
            set { callid = value; }
        }


        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
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

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private DateTime calldate;
        public DateTime CallDate
        {
            get { return calldate; }
            set { calldate = value; }
        }

        public ECalls(int c)
        {
            this.CallId = c;
        }
    }
}

