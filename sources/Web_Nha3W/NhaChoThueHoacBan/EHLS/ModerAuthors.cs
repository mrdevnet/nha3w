using System;

namespace HungLocSon.EHLS
{
    public class EModerAuthors
    {
        public EModerAuthors()
        {
        }

        private int moderid;
        public int ModerId
        {
            get { return moderid; }
            set { moderid = value; }
        }

        private bool edit;
        public bool Edit
        {
            get { return edit; }
            set { edit = value; }
        }

        private bool del;
        public bool Del
        {
            get { return del; }
            set { del = value; }
        }

        private bool approve;
        public bool Approve
        {
            get { return approve; }
            set { approve = value; }
        }

        private bool vip;
        public bool Vip
        {
            get { return vip; }
            set { vip = value; }
        }

        private bool silver;
        public bool Silver
        {
            get { return silver; }
            set { silver = value; }
        }

        private bool renew;
        public bool Renew
        {
            get { return renew; }
            set { renew = value; }
        }

        private bool ups;
        public bool Ups
        {
            get { return ups; }
            set { ups = value; }
        }

    }
}
