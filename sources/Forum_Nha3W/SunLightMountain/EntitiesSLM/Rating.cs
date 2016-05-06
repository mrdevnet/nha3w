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
    public class EnRating
    {
        public EnRating()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int rateid;
        public int RateId
        {
            get { return rateid; }
            set { rateid = value; }
        }

        private int typeid;
        public int TypeId
        {
            get { return typeid; }
            set { typeid = value; }
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

        private DateTime ratingdate;
        public DateTime RatingDate
        {
            get { return ratingdate; }
            set { ratingdate = value; }
        }

        private string from;
        public string From
        {
            get { return from; }
            set { from = value; }
        }
    }
}
