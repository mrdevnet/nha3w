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
    public class EnVote
    {
        public EnVote()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int voteid;
        public int VoteId
        {
            get { return voteid; }
            set { voteid = value; }
        }

        private int pollid;
        public int PollId
        {
            get { return pollid; }
            set { pollid = value; }
        }

        private int userid;
        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private DateTime votedate;
        public DateTime VoteDate
        {
            get { return votedate; }
            set { votedate = value; }
        }
    }
}
