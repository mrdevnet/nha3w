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
    public class EnCategory
    {
        public EnCategory()
        {
            //
            // TODO: Add constructor logic here
            //
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

        private int orderby;
        public int OrderBy
        {
            get { return orderby; }
            set { orderby = value; }
        }

        private DateTime datecreation;
        public DateTime DateCreation
        {
            get { return datecreation; }
            set { datecreation = value; }
        }
    }
}
