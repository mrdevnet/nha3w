using System;

namespace HungLocSon.EHLS
{
    public class EContacts
    {
        public EContacts()
        {
        }

        private int contactid;
        public int ContactId
        {
            get { return contactid; }
            set { contactid = value; }
        }

        private string contactname;
        public string ContactName
        {
            get { return contactname; }
            set { contactname = value; }
        }

        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public EContacts(int c)
        {
            this.ContactId = c;
        }
    }
}
