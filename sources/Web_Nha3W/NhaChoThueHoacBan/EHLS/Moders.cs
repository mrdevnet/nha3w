using System;

namespace HungLocSon.EHLS
{
    public class EModers
    {
        public EModers()
        {
        }

        private int moderid;
        public int ModerId
        {
            get { return moderid; }
            set { moderid = value; }
        }

        private string modername;
        public string ModerName
        {
            get { return modername; }
            set { modername = value; }
        }

        public EModers(int c)
        {
            this.ModerId = c;
        }

    }
}

