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
    public class EnPm
    {
        public EnPm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int pmid;
        public int PmId
        {
            get { return pmid; }
            set { pmid = value; }
        }

        private int frommember;
        public int FromMember
        {
            get { return frommember; }
            set { frommember = value; }
        }

        private int tomember;
        public int ToMember
        {
            get { return tomember; }
            set { tomember = value; }
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

        private DateTime sent;
        public DateTime Sent
        {
            get { return sent; }
            set { sent = value; }
        }

        private bool isread;
        public bool IsRead
        {
            get { return isread; }
            set { isread = value; }
        }

        private bool isview;
        public bool IsView
        {
            get { return isview; }
            set { isview = value; }
        }
    }
}
