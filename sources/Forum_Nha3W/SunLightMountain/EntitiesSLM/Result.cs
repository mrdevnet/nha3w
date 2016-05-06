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
    public class EnResult
    {
        public EnResult()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int resultid;
        public int ResultId
        {
            get { return resultid; }
            set { resultid = value; }
        }

        private int pollid;
        public int PollId
        {
            get { return pollid; }
            set { pollid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

    }
}
