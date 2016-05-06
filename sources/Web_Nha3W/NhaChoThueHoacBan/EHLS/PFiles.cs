using System;

namespace HungLocSon.EHLS
{
    public class EPFiles
    {
        public EPFiles()
        {
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private int flcount;
        public int FlCount
        {
            get { return flcount; }
            set { flcount = value; }
        }

        private int frcount;
        public int FrCount
        {
            get { return frcount; }
            set { frcount = value; }
        }

        private int lstrcount;
        public int LstRCount
        {
            get { return lstrcount; }
            set { lstrcount = value; }
        }

        private int lstfcount;
        public int LstFCount
        {
            get { return lstfcount; }
            set { lstfcount = value; }
        }

        private int msgcount;
        public int MsgCount
        {
            get { return msgcount; }
            set { msgcount = value; }
        }

        private bool prive;
        public bool Prive
        {
            get { return prive; }
            set { prive = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string talk;
        public string Talk
        {
            get { return talk; }
            set { talk = value; }
        }

        private DateTime talkdate;
        public DateTime TalkDate
        {
            get { return talkdate; }
            set { talkdate = value; }
        }

        private int autid;
        public int AutId
        {
            get { return autid; }
            set { autid = value; }
        }

        private string autname;
        public string AutName
        {
            get { return autname; }
            set { autname = value; }
        }

        private string via;
        public string Via
        {
            get { return via; }
            set { via = value; }
        }

        public EPFiles(int c)
        {
            this.MemberId = c;
        }
    }
}

