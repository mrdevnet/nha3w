using System;

namespace HungLocSon.EHLS
{
    public class ETracks
    {
        public ETracks()
        {
        }

        private int listid;
        public int ListId
        {
            get { return listid; }
            set { listid = value; }
        }

        private int islist;
        public int IsList
        {
            get { return islist; }
            set { islist = value; }
        }

        private string lstname;
        public string LstName
        {
            get { return lstname; }
            set { lstname = value; }
        }

        private string lstdesc;
        public string LstDesc
        {
            get { return lstdesc; }
            set { lstdesc = value; }
        }

        private bool prive;
        public bool Prive
        {
            get { return prive; }
            set { prive = value; }
        }

        private bool checkin;
        public bool CheckIn
        {
            get { return checkin; }
            set { checkin = value; }
        }

        private bool checkout;
        public bool CheckOut
        {
            get { return checkout; }
            set { checkout = value; }
        }

        private int flwc;
        public int Flwc
        {
            get { return flwc; }
            set { flwc = value; }
        }

        private int flrc;
        public int Flrc
        {
            get { return flrc; }
            set { flrc = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string iname;
        public string IName
        {
            get { return iname; }
            set { iname = value; }
        }

        private string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        private DateTime lstdate;
        public DateTime LstDate
        {
            get { return lstdate; }
            set { lstdate = value; }
        }

        private bool show;
        public bool Show
        {
            get { return show; }
            set { show = value; }
        }

        private DateTime shwdate;
        public DateTime ShwDate
        {
            get { return shwdate; }
            set { shwdate = value; }
        }

        public ETracks(int c)
        {
            this.ListId = c;
        }
    }
}

