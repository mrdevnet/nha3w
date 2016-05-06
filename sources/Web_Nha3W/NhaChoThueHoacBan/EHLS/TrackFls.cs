using System;

namespace HungLocSon.EHLS
{
    public class ETrackFls
    {
        public ETrackFls()
        {
        }

        private int lstid;
        public int LstId
        {
            get { return lstid; }
            set { lstid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private int checkin;
        public int CheckIn
        {
            get { return checkin; }
            set { checkin = value; }
        }

        private int checkout;
        public int CheckOut
        {
            get { return checkout; }
            set { checkout = value; }
        }
        
        private string checkindate;
        public string CheckInDate
        {
            get { return checkindate; }
            set { checkindate = value; }
        }

        private string checkoutdate;
        public string CheckOutDate
        {
            get { return checkoutdate; }
            set { checkoutdate = value; }
        }
        
    }
}

