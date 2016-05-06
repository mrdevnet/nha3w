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
    public class EnInformation
    {
        public EnInformation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string detailid;
        public string DetailId
        {
            get { return detailid; }
            set { detailid = value; }
        }

        private int forumid;
        public int ForumId
        {
            get { return forumid; }
            set { forumid = value; }
        }

        private int topicid;
        public int TopicId
        {
            get { return topicid; }
            set { topicid = value; }
        }

        private int messageid;
        public int MessageId
        {
            get { return messageid; }
            set { messageid = value; }
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private DateTime request;
        public DateTime Request
        {
            get { return request; }
            set { request = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private DateTime posted;
        public DateTime Posted
        {
            get { return posted; }
            set { posted = value; }
        }
    }
}
