using System;

namespace HungLocSon.EHLS
{
    public class EPager
    {
        public EPager()
        {
        }

        private int size;
        public int PageSize
        {
            get { return size; }
            set { size = value; }
        }

        private int curr;
        public int CurrentPage
        {
            get { return curr; }
            set { curr = value; }
        }

        private int rows;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        //private int total;
        public int Total
        {
            get 
            {
                if (this.Rows % this.PageSize > 0)
                    return (this.Rows / this.PageSize) + 1;
                else
                    return (this.Rows / this.PageSize);
            }
        }

        public EPager(int c, int s,int r)
        {
            this.CurrentPage = c;
            this.PageSize = s;
            this.Rows = r;
        }
    }
}
