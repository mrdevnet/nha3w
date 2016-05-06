using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnEm
    {
        public EnEm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int mailid;
        public int MailId
        {
            get { return mailid; }
            set { mailid = value; }
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

        private DateTime creationdate;
        public DateTime CreationDate
        {
            get { return creationdate; }
            set { creationdate = value; }
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
    }
}
