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
    public class EnReport
    {
        public EnReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private int reportid;
        public int ReportId
        {
            get { return reportid; }
            set { reportid = value; }
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

        private DateTime startdate;
        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        private DateTime finishdate;
        public DateTime FinishDate
        {
            get { return finishdate; }
            set { finishdate = value; }
        }
            
        private bool showall;
        public bool ShowAll
        {
            get { return showall; }
            set { showall = value; }
        }

        private bool allforum;
        public bool AllForum
        {
            get { return allforum; }
            set { allforum = value; }
        }

        private bool istop;
        public bool IsTop
        {
            get { return istop; }
            set { istop = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private int totalviews;
        public int TotalViews
        {
            get { return totalviews; }
            set { totalviews = value; }
        }
    }
}
