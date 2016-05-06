using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Ent_Account
/// </summary>
/// 
namespace SLMF.Entity
{
    public class EnMember
    {
        public EnMember()
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

        private int forumid;
        public int ForumId
        {
            get { return forumid; }
            set { forumid = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string newpassword;
        public string NewPassword
        {
            get { return newpassword; }
            set { newpassword = value; }
        }

        private string salt;
        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string fullname;
        public string FullName
        {
            get { return fullname; } 
            set { fullname = value; }
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
        
        private string activatestring;
        public string ActivateString
        {
            get { return activatestring; }
            set { activatestring = value; }
        }
    }
}
