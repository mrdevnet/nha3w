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
    public class EnRateType
    {
        public EnRateType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int typeid;
        public int TypeId
        {
            get { return typeid; }
            set { typeid = value; }
        }

        private string ratename;
        public string RateName
        {
            get { return ratename; }
            set { ratename = value; }
        }

        private int ratepoints;
        public int RatePoints
        {
            get { return ratepoints; }
            set { ratepoints = value; }
        }
    }
}
