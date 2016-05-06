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
    public class EnMessage
    {
        public EnMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int msgcount;
        private int messageid;
        public int MessageId
        {
            get { return messageid; }
            set { messageid = value; }
        }

        private int topicid;
        public int TopicId
        {
            get { return topicid; }
            set { topicid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string authorname;
        public string AuthorName
        {
            get { return authorname; }
            set { authorname = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
            

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }


        private DateTime creationdate;
        public DateTime CreationDate
        {
            get { return creationdate; }
            set { creationdate = value; }
        }


        private bool isapproved;
        public bool IsApproved
        {
            get { return isapproved; }
            set { isapproved = value; }
        }

        private DateTime dateapproved;
        public DateTime DateApproved
        {
            get { return dateapproved; }
            set { dateapproved = value; }
        }
            

        private DateTime edited;
        public DateTime Edited
        {
            get { return edited; }
            set { edited = value; } 
        }

        private int bymember;
        public int ByMember
        {
            get { return bymember; }
            set { bymember = value; }
        }

        private string myicon;
        public string MyIcon
        {
            get { return myicon; }
            set { myicon = value; }
        }

        private bool signature;
        public bool Signature
        {
            get { return signature; }
            set { signature = value; }
        }
    }
}
