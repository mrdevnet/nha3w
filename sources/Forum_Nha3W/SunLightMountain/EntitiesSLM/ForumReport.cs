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
    public class EnForumReport
    {
        public EnForumReport()
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

        private int reportid;
        public int ReportId
        {
            get { return reportid; }
            set { reportid = value; }
        }

    }
}
