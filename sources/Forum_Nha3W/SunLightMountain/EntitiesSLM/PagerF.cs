using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnPagerF
    {
        public EnPagerF()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int pageindex;
        public int PageIndex
        {
            get { return pageindex; }
            set { pageindex = value; }
        }

        private int pagesize;
        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        private int currentpage;
        public int CurrentPage
        {
            get { return currentpage; }
            set { currentpage = value; }
        }

        private int itemcount;
        public int ItemCount
        {
            get { return itemcount; }
            set { itemcount = value; }
        }
    }
}
