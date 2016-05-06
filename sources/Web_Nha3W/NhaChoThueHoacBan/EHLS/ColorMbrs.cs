using System;

namespace HungLocSon.EHLS
{
    public class EColorMbrs
    {
        public EColorMbrs()
        {
        }

        private int colorid;
        public int ColorId
        {
            get { return colorid; }
            set { colorid = value; }
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

        private string byid;
        public string ById
        {
            get { return byid; }
            set { byid = value; }
        }
        
        private DateTime colordate;
        public DateTime ColorDate
        {
            get { return colordate; }
            set { colordate = value; }
        }

        private DateTime showdate;
        public DateTime ShowDate
        {
            get { return showdate; }
            set { showdate = value; }
        }

        private bool show;
        public bool Show
        {
            get { return show; }
            set { show = value; }
        }
    }
}

