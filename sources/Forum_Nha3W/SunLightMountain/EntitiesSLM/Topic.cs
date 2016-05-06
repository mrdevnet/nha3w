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
    public class EnTopic
    {
        public EnTopic()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private int topicid;
        public int TopicId
        {
            get { return topicid; }
            set { topicid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        private int forumid;
        public int ForumId
        {
            get { return forumid; }
            set { forumid = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private int totalviews;
        public int TotalViews
        {
            get { return totalviews; }
            set { totalviews = value; } 
        }

        private int totalreplies;
        public int TotalReplies
        {
            get { return totalreplies; }
            set { totalreplies = value; }
        }
            
        private int lastmessageid;
        public int LastMessageId
        {
            get { return lastmessageid; }
            set { lastmessageid = value; }
        }

        private string lastauthor;
        public string LastAuthor
        {
            get { return lastauthor; }
            set { lastauthor = value; }
        }

        private int lastauthorid;
        public int LastAuthorId
        {
            get { return lastauthorid; }
            set { lastauthorid = value; }
        }

        private int messageid;
        public int MessageId
        {
            get { return messageid; }
            set { messageid = value; }
        }
            

        private bool ispinned;
        public bool IsPinned
        {
            get { return ispinned; }
            set { ispinned = value; }
        }

        private DateTime lastpinned;
        public DateTime LastPinned
        {
            get { return lastpinned; }
            set { lastpinned = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private bool islocked;
        public bool IsLocked
        {
            get { return islocked; }
            set { islocked = value; }
        }

        private bool isapproved;
        public bool IsApproved
        {
            get { return isapproved; }
            set { isapproved = value; }
        }

        private int pollid;
        public int PollId
        {
            get { return pollid; }
            set { pollid = value; }
        }

        private int moveto;
        public int MoveTo
        {
            get { return moveto; }
            set { moveto = value; }
        }

    }
}
