using System;

namespace HungLocSon.EHLS
{
    public class EViolations
    {
        public EViolations()
        {
        }

        private int vioid;
        public int VioId
        {
            get { return vioid; }
            set { vioid = value; }
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        private DateTime viodate;
        public DateTime VioDate
        {
            get { return viodate; }
            set { viodate = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        public EViolations(int c)
        {
            this.VioId = c;
        }
    }
}


