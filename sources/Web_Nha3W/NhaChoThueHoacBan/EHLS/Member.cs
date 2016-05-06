using System;

namespace HungLocSon.EHLS
{
    public class EMember
    {
        public EMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string sessaut;
        public string SessAuts
        {
            get { return sessaut; }
            set { sessaut = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string salt;
        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        private DateTime datecreation;
        public DateTime DateCreation
        {
            get { return datecreation; }
            set { datecreation = value; }
        }

        private bool isactivated;
        public bool IsActivated
        {
            get { return isactivated; }
            set { isactivated = value; }
        }

        private bool enablelogin;
        public bool EnableLogin
        {
            get { return enablelogin; }
            set { enablelogin = value; }
        }

        private DateTime lastlogin;
        public DateTime LastLogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }

        private DateTime dateactivation;
        public DateTime DateActivation
        {
            get { return dateactivation; }
            set { dateactivation = value; }
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private string groupname;
        public string GroupName
        {
            get { return groupname; }
            set { groupname = value; }
        }

        public EMember(int i)
        {
            this.MemberId = i;
        }
        private int moderid;
        public int ModerId
        {
            get { return moderid; }
            set { moderid = value; }
        }

        public EMember(int _MemberId, string _UserName, string _Password, string _Salt, DateTime _DateCreation, bool _IsActivated, bool _EnableLogin, DateTime _LastLogin, DateTime _DateActivation, int _GroupId, int _ModerId)
        {
           this.MemberId = _MemberId ;
           this.UserName = _UserName ;
           this.Password = _Password ;
           this.Salt = _Salt ;
           this.DateCreation = _DateCreation ;
           this.IsActivated = _IsActivated ;
           this.EnableLogin = _EnableLogin ;
           this.LastLogin = _LastLogin ;
           this.DateActivation = _DateActivation ;
           this.GroupId = _GroupId ;
           this.ModerId = _ModerId ;
        }
    }
}
