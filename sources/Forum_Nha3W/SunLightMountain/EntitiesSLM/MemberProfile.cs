using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SLMF.Entity
{
    public class EnMemberProfile
    {
        public EnMemberProfile()
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

        private string aboutme;
        public string AboutMe
        {
            get { return aboutme; }
            set { aboutme = value; }
        }

        private string interests;
        public string Interests
        {
            get { return interests; }
            set { interests = value; }
        }

        private string job;
        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private DateTime birthday;
        public DateTime BirthDay
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private string yahoo;
        public string Yahoo
        {
            get { return yahoo; }
            set { yahoo = value; }
        }

        private string aim;
        public string Aim
        {
            get { return aim; }
            set { aim = value; }
        }

        private string icq;
        public string Icq
        {
            get { return icq; }
            set { icq = value; }
        }

        private string msn;
        public string Msn
        {
            get { return msn; }
            set { msn = value; }
        }

        private string blog;
        public string Blog
        {
            get { return blog; }
            set { blog = value; }
        }

        private string homepage;
        public string HomePage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        private string avatar;
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        private string membertitle;
        public string MemberTitle
        {
            get { return membertitle; }
            set { membertitle = value; }
        }

        private string signature;
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        private bool alwayssig;
        public bool AlwaysSig
        {
            get { return alwayssig; }
            set { alwayssig = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private bool isemailpublished;
        public bool IsEmailPublished
        {
            get { return isemailpublished; }
            set { isemailpublished = value; }
        }

        private int totalposts;
        public int TotalPosts
        {
            get { return totalposts; }
            set { totalposts = value; }
        }

        private int countlostpass;
        public int CountLostPass
        {
            get { return countlostpass; }
            set { countlostpass = value; }
        }

        private DateTime lastlogin;
        public DateTime LastLogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }

        private DateTime lastbrowse;
        public DateTime LastBrowse
        {
            get { return lastbrowse; }
            set { lastbrowse = value; }
        }

        private bool userstatus;
        public bool UserStatus
        {
            get { return userstatus; }
            set { userstatus = value; }
        }

        private bool gender;
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private DateTime posted;
        public DateTime Posted
        {
            get { return posted; }
            set { posted = value; }
        }

        private bool cansende;
        public bool CanSendE
        {
            get { return cansende; }
            set { cansende = value; }
        }

        private int thank;
        public int Thank
        {
            get { return thank; }
            set { thank = value; }
        }

        private int thanked;
        public int Thanked
        {
            get { return thanked; }
            set { thanked = value; }
        }

        private string myrss;
        public string MyRSS
        {
            get { return myrss; }
            set { myrss = value; }
        }
    }
}
