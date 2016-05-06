using System;

namespace HungLocSon.EHLS
{
    public class ELogs
    {
        public ELogs()
        {
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        private string sdid;
        public string SdId
        {
            get { return sdid; }
            set { sdid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public ELogs(int c)
        {
            this.PostId = c;
        }
    }
}

