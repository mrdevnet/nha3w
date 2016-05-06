using System;

namespace HungLocSon.EHLS
{
    public class EColors
    {
        public EColors()
        {
        }

        private int colorid;
        public int ColorId
        {
            get { return colorid; }
            set { colorid = value; }
        }

        private int cmtid;
        public int CommentId
        {
            get { return cmtid; }
            set { cmtid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private int author2;
        public int Author2
        {
            get { return author2; }
            set { author2 = value; }
        }

        private int author;
        public int Author
        {
            get { return author; }
            set { author = value; }
        }

        private string autname;
        public string AutName
        {
            get { return autname; }
            set { autname = value; }
        }

        private DateTime crdate;
        public DateTime CrDate
        {
            get { return crdate; }
            set { crdate = value; }
        }

        private bool show;
        public bool Show
        {
            get { return show; }
            set { show = value; }
        }

        private int n3w;
        public int N3w
        {
            get { return n3w; }
            set { n3w = value; }
        }

        private DateTime shwdate;
        public DateTime ShwDate
        {
            get { return shwdate; }
            set { shwdate = value; }
        }

        private string hash;
        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        private string colors;
        public string Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        private string via;
        public string Via
        {
            get { return via; }
            set { via = value; }
        }

        private string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        private DateTime colordate;
        public DateTime ColorDate
        {
            get { return colordate; }
            set { colordate = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        public EColors(int c)
        {
            this.ColorId = c;
        }
    }
}

