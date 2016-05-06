using System;

namespace HungLocSon.EHLS
{
    public class EFlowing
    {
        public EFlowing()
        {
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string user;
        public string UserName
        {
            get { return user; }
            set { user = value; }
        }

        private string full;
        public string FullName
        {
            get { return full; }
            set { full = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private int tomember;
        public int ToMember
        {
            get { return tomember; }
            set { tomember = value; }
        }

        private bool flws;
        public bool Flws
        {
            get { return flws; }
            set { flws = value; }
        }

        private bool prive;
        public bool Prive
        {
            get { return prive; }
            set { prive = value; }
        }

        private bool approves;
        public bool Approves
        {
            get { return approves; }
            set { approves = value; }
        }

        private bool blocks;
        public bool Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        private bool blked;
        public bool BlockEd
        {
            get { return blked; }
            set { blked = value; }
        }

        private bool spams;
        public bool Spams
        {
            get { return spams; }
            set { spams = value; }
        }

        private bool removes;
        public bool Removes
        {
            get { return removes; }
            set { removes = value; }
        }

        private DateTime flat;
        public DateTime FlAt
        {
            get { return flat; }
            set { flat = value; }
        }

        private DateTime fdate;
        public DateTime Fdate
        {
            get { return fdate; }
            set { fdate = value; }
        }

        private DateTime blockat;
        public DateTime BLockAt
        {
            get { return blockat; }
            set { blockat = value; }
        }

        private DateTime spamat;
        public DateTime SpamAt
        {
            get { return spamat; }
            set { spamat = value; }
        }

        private DateTime aproat;
        public DateTime AproAt
        {
            get { return aproat; }
            set { aproat = value; }
        }

        private DateTime revat;
        public DateTime RevAt
        {
            get { return revat; }
            set { revat = value; }
        }
    }
}

