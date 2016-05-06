using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace SLMF.Utility
{
    public class UtiRegEmail
    {
        public UtiRegEmail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool RegExEmail(string strEmail)
        {
            bool bolReg = false;
            string strPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            System.Text.RegularExpressions.Regex theRegEx = new System.Text.RegularExpressions.Regex(strPattern, System.Text.RegularExpressions.RegexOptions.Compiled);

            if (theRegEx.IsMatch(strEmail))
            {
                bolReg = true;
            }
            return bolReg;
        }


    }
}
