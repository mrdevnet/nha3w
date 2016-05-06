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
    public class EnForum
    {
        public EnForum()
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

        private string name;
        public string Name
        {
            get { return name; } 
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private DateTime datecreation;
        public DateTime DateCreation
        {
            get { return datecreation; }
            set { datecreation = value; }
        }

        private DateTime orderby;
        public DateTime OrderBy
        {
            get { return orderby; }
            set { orderby = value; }
        }


        private int subforumid;
        public int SubForumId
        {
            get { return subforumid; }
            set { subforumid = value; }
        }

        private int typeid;
        public int TypeId
        {
            get { return typeid; }
            set { typeid = value; }
        }

        private int totaltopics;
        public int TotalTopics
        {
            get { return totaltopics; }
            set { totaltopics = value; }
        }

        private int totalmessages;
        public int TotalMessages
        {
            get { return totalmessages; }
            set { totalmessages = value; }
        }

        private int categoryid;
        public int CateId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }
    }
}
