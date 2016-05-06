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
    public class EnBlockMember
    {
        public EnBlockMember()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int blockid;
        public int BlockId
        {
            get { return blockid; }
            set { blockid = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime start;
        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        private DateTime finish;
        public DateTime Finish
        {
            get { return finish; }
            set { finish = value; }
        }

        private string reason;
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        private int moderator;
        public int Moderator
        {
            get { return moderator; }
            set { moderator = value; }
        }

    }
}
