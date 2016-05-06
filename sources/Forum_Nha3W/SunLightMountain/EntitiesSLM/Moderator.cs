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
    public class EnModerator
    {
        public EnModerator()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private int forumid;
        public int ForumId
        {
            get { return forumid; }
            set { forumid = value; }
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


        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private DateTime jobdate;
        public DateTime JobDate
        {
            get { return jobdate; }
            set { jobdate = value; }
        }


        private int postsmoderated;
        public int PostsModerated
        {
            get { return postsmoderated; }
            set { postsmoderated = value; }
        }

        private bool issuper;
        public bool IsSuper
        {
            get { return issuper; }
            set { issuper = value; }
        }
    }
}
