using System;

namespace HungLocSon.EHLS
{
    public class EUps
    {
        public EUps()
        {
        }

        private int upid;
        public int UpId
        {
            get { return upid; }
            set { upid = value; }
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        private int service;
        public int Service
        {
            get { return service; }
            set { service = value; }
        }

        private DateTime updated;
        public DateTime Updated
        {
            get { return updated; }
            set { updated = value; }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        public EUps(int c)
        {
            this.UpId = c;
        }
    }
}


