using System;

namespace HungLocSon.EHLS
{
    public class EProfile
    {
        public EProfile()
        {
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string company;
        public string Company
        {
            get { return company;}
            set { company = value;}
        }

        private string address;
        public string Address
        {
            get { return address;}
            set { address = value;}
        }
        private string tel;
        public string Tel
        {
            get { return tel;}
            set { tel= value;}
        }
        private string mobile;
        public string Mobile
        {
            get { return mobile;}
            set { mobile= value;}
        }
        
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday;}
            set { birthday= value;}
        }

        private bool gender;
        public bool Gender
        {
            get { return gender;}
            set { gender = value;}
        }

        private string email;
        public string Email
        {
            get { return email;}
            set { email = value;}
        }

        private bool getnews;
        public bool GetNews
        {
            get { return getnews;}
            set { getnews = value;}
        }

        private string yahoo;
        public string Yahoo
        {
            get { return yahoo;}
            set { yahoo = value;}
        }

        private string skype;
        public string Skype
        {
            get { return skype;}
            set { skype = value;}
        }

        private string website;
        public string Website
        {
            get { return website;}
            set { website = value;}
        }
        private string logo;
        public string Logo
        {
            get { return logo;}
            set { logo = value;}
        }
        //private string activation;
        //public string Activation
        //{
        //    get { return activation;}
        //    set { activation = value;}
        //}

        private Guid _Activation;
        public Guid Activation
        {
            get { return _Activation; }
            set { _Activation = value; }
        }

        private bool hidein;
        public bool HideIn
        {
            get { return hidein;}
            set { hidein = value;}
        }

        private bool prive;
        public bool Private
        {
            get { return prive; }
            set { prive = value; }
        }

        private string regip;
        public string RegIP
        {
            get { return regip;}
            set { regip = value;}
        }

        private string lastip;
        public string LastIP
        {
            get { return lastip;}
            set { lastip = value;}
        }

        private bool isblocked;
        public bool IsBlocked
        {
            get { return isblocked;}
            set { isblocked = value;}
        }

        private int totalup;
        public int TotalUp
        {
            get { return totalup; }
            set { totalup = value; }
        }
        private bool _Up;
        public bool Up
        {
            get { return _Up; }
            set { _Up = value; }
        }
        private DateTime _LastIn;
        public DateTime LastIn
        {
            get { return _LastIn; }
            set { _LastIn = value; }
        }

        public EProfile(int i)
        {
            this.MemberId = i;
        }
    }
}
