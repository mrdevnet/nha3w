using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnConfig
    {
        public EnConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string adminemail;
        public string AdminEmail
        {
            get { return adminemail; }
            set { adminemail = value; }
        }

        private bool allowsignup;
        public bool AllowSignUp
        {
            get { return allowsignup; }
            set { allowsignup = value; }
        }

        private bool allowlogin;
        public bool AllowLogIn
        {
            get { return allowlogin; }
            set { allowlogin = value; }
        }
         
        private int maxmsg;
        public int MaxMsg
        {
            get { return maxmsg; }
            set { maxmsg = value; }
        }

        private int sessiontimeout;
        public int SessionTimeOut
        {
            get { return sessiontimeout; }
            set { sessiontimeout = value; }
        }

        private bool guestsearch;
        public bool GuestSearch
        {
            get { return guestsearch; }
            set { guestsearch = value; }
        }

        private bool guestprofile;
        public bool GuestProfile
        {
            get { return guestprofile; }
            set { guestprofile = value; }
        }

        private bool guestmember;
        public bool GuestMember
        {
            get { return guestmember; }
            set { guestmember = value; }
        }

        private bool hiderec;
        public bool HideRecyleForum
        {
            get { return hiderec; }
            set { hiderec = value; }
        }

        
        private bool activemember;
        public bool ActiveMember
        {
            get { return activemember; }
            set { activemember = value; }
        }

        
        private bool reviewmember;
        public bool ReviewMember
        {
            get { return reviewmember; }
            set { reviewmember = value; }
        }

           
        private int timepostagain;
        public int TimePostAgain
        {
            get { return timepostagain; }
            set { timepostagain = value; }
        }

        
        private int max;
        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        
        private DateTime addsite;
        public DateTime AddSite
        {
            get { return addsite; }
            set { addsite = value; }
        }
    }
}
