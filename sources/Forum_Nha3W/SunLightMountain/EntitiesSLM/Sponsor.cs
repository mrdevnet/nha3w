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
    public class EnSponsor
    {
        public EnSponsor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int sponsorid;
        public int SponsorId
        {
            get { return sponsorid; }
            set { sponsorid = value; }
        }

        private string scripts;
        public string Scripts
        {
            get { return scripts; }
            set { scripts = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
