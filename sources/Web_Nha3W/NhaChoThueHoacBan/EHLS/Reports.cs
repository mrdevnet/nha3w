using System;

namespace HungLocSon.EHLS
{
    public class EReports
    {
        public EReports()
        {
        }

        private int rptid;
        public int RptId
        {
            get { return rptid; }
            set { rptid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private int bymember;
        public int ByMember
        {
            get { return bymember; }
            set { bymember = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private bool isshow;
        public bool IsShow
        {
            get { return isshow; }
            set { isshow = value; }
        }

        private DateTime updated;
        public DateTime Updated
        {
            get { return updated; }
            set { updated = value; }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public EReports(int c)
        {
            this.RptId = c;
        }
    }
}

