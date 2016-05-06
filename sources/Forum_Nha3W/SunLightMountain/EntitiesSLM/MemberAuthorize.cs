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
    public class EnMemberAuthorize
    {
        public EnMemberAuthorize()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private int forumid;
        public int ForumId
        {
            get { return forumid; }
            set { forumid = value; }
        }

        private bool postauthor;
        public bool PostAuthor
        {
            get { return postauthor; }
            set { postauthor = value; }
        }

        private bool replyauthor;
        public bool ReplyAuthor
        {
            get { return replyauthor; }
            set { replyauthor = value; }
        }

        private bool pollauthor;
        public bool PollAuthor
        {
            get { return pollauthor; }
            set { pollauthor = value; }
        }

        private bool voteauthor;
        public bool VoteAuthor
        {
            get { return voteauthor; }
            set { voteauthor = value; }
        }

        private bool ratingauthor;
        public bool RatingAuthor
        {
            get { return ratingauthor; }
            set { ratingauthor = value; }
        }

        private bool viewprofile;
        public bool ViewProfile
        {
            get { return viewprofile; }
            set { viewprofile = value; }
        }
            
        private bool uploadauthor;
        public bool UploadAuthor
        {
            get { return uploadauthor; }
            set { uploadauthor = value; }
        }

        private int sizeauthor;
        public int SizeAuthor
        {
            get { return sizeauthor; }
            set { sizeauthor = value; }
        }

        private bool isapproved;
        public bool IsApproved
        {
            get { return isapproved; }
            set { isapproved = value; }
        }

        private bool editmsgauthor;
        public bool EditMsgAuthor
        {
            get { return editmsgauthor; }
            set { editmsgauthor = value; }
        }

        private bool deletemsgauthor;
        public bool DeleteMsgAuthor
        {
            get { return deletemsgauthor; }
            set { deletemsgauthor = value; }
        }

        private bool deletetopicauthor;
        public bool DeleteTopicAuthor
        {
            get { return deletetopicauthor; }
            set { deletetopicauthor = value; }
        }

        private bool locktopicauthor;
        public bool LockTopicAuthor
        {
            get { return locktopicauthor; }
            set { locktopicauthor = value; }
        }

        private bool stickytopicauthor;
        public bool StickTopicAuthor
        {
            get { return stickytopicauthor; }
            set { stickytopicauthor = value; }
        }
            
        private bool movetopicauthor;
        public bool MoveTopicAuthor
        {
            get { return movetopicauthor; }
            set { movetopicauthor = value; }
        }

        private bool quotemsgauthor;
        public bool QuoteMsgAuthor
        {
            get { return quotemsgauthor; }
            set { quotemsgauthor = value; }
        }

        private bool forwardmsgauthor;
        public bool ForwardMsgAuthor
        {
            get { return forwardmsgauthor; }
            set { forwardmsgauthor = value; }
        }

        private bool alwayssig;
        public bool AlwaysSig
        {
            get { return alwayssig; }
            set { alwayssig = value; }
        }
        
        private bool pm;
        public bool SendPm
        {
            get { return pm; }
            set { pm = value; }
        }

        private bool em;
        public bool SendEm
        {
            get { return em; }
            set { em = value; }
        }

        private bool unlock;
        public bool UnLockTopic
        {
            get { return unlock; }
            set { unlock = value; }
        }

        private bool aprauthor;
        public bool ApproveMsg
        {
            get { return aprauthor; }
            set { aprauthor = value; }
        }

        private bool viewip;
        public bool ViewIp
        {
            get { return viewip; }
            set { viewip = value; }
        }

        private bool report;
        public bool ReportAuthor
        {
            get { return report; }
            set { report = value; }
        }

        private bool thank;
        public bool ThankAuthor
        {
            get { return thank; }
            set { thank = value; }
        }
    }
}
