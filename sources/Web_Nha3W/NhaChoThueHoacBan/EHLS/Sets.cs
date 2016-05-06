using System;

namespace HungLocSon.EHLS
{
    public class ESets
    {
        public ESets()
        {
        }


        private int setid;
        public int SetId
        {
            get { return setid; }
            set { setid = value; }
        }

        private string setname;
        public string SetName
        {
            get { return setname; }
            set { setname = value; }
        }

        public ESets(int c)
        {
            this.SetId = c;
        }
    }
}

