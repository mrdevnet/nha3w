using System;

namespace HungLocSon.EHLS
{
    public class ECategories
    {
        public ECategories()
        {
        }

        private int categoryid;
        public int CategoryId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }

        private string catename;
        public string CateName
        {
            get { return catename; }
            set { catename = value; }
        }

        public ECategories(int c)
        {
            this.CategoryId = c;
        }
    }
}
