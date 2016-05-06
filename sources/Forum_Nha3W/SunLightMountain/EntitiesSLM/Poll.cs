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
    public class EnPoll
    {
        public EnPoll()
        {
            //
            // TODO: Add constructor logic here
            //
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

        private bool repeat;
        public bool Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        private DateTime finishdate;
        public DateTime FinishDate
        {
            get { return finishdate; }
            set { finishdate = value; }
        }

        private int numberoffinish;
        public int NumberOfFinish
        {
            get { return numberoffinish; }
            set { numberoffinish = value; }
        }

        private int numberofloop;
        public int NumberOfLoop
        {
            get { return numberofloop; }
            set { numberofloop = value; }
        }

    }
}
