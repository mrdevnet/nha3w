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
    public class EnSearchMe
    {
        public EnSearchMe()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
    }
}
