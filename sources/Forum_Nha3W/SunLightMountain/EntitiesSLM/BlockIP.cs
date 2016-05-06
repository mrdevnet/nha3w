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
    public class EnBlockIP
    {
        public EnBlockIP()
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

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime dateblock;
        public DateTime DateBlock
        {
            get { return dateblock; }
            set { dateblock = value; }
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