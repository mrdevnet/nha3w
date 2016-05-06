using System;

namespace HungLocSon.EHLS
{
    public class ESaves
    {
        public ESaves()
        {
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

        private DateTime saved;
        public DateTime Saved
        {
            get { return saved; }
            set { saved = value; }
        }

        public ESaves(int c,int d)
        {
            this.MemberId = c;
            this.PostId = d;
        }
    }
}