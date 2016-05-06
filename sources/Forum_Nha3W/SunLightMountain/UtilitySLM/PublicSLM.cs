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

/// <summary>
/// Summary description for Ent_Connection
/// </summary>
/// 
namespace SLMF.Utility
{
    public class UtiGeneralClass
    {
        public UtiGeneralClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private const string chars = "a1bA2cB3dC4eD5fE6gF7hG8H9kK1NnUuVvXxYyZz";
        public string GenerateRandomCode(int NumberOfKeys)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int charLength = chars.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < NumberOfKeys; i++)
            {
                int idx = random.Next(0, charLength);
                sb.Append(chars.Substring(idx, 1));
            }
            return sb.ToString();
        }

        private const string chars2 = "1A2B3C4D5E6F7G8H9K1N2U3V4X5Y6Z7";
        public string RdnCode(int Keys)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int charLength = chars2.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Keys; i++)
            {
                int idx = random.Next(0, charLength);
                sb.Append(chars2.Substring(idx, 1));
            }
            return sb.ToString();
        }
        public bool clies(string To, string subject, string body)
        {
            SmtpClient smtpclient = new SmtpClient();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            try
            {
                string From = ConfigurationManager.AppSettings["FromMail"];
                string strDisplayName = ConfigurationManager.AppSettings["TitleOfMail"];
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(From, strDisplayName);
                smtpclient.Host = ConfigurationManager.AppSettings["MailServer"];
                smtpclient.Port = 25;
                smtpclient.Credentials = new System.Net.NetworkCredential("nha3w@nha3w.com", "123456789qwert");
                message.From = fromAddress;
                message.To.Add(To);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = body;
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                string strEx = ex.ToString();
                return false;
            }
        }
        public bool SendMailSmtpClient(string To, string subject, string body)
        {

            SmtpClient smtpclient = new SmtpClient();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            try
            {
                string From = ConfigurationManager.AppSettings["FromMail"];
                string strDisplayName = ConfigurationManager.AppSettings["TitleOfMail"];
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(From, strDisplayName);
                smtpclient.Host = ConfigurationManager.AppSettings["MailServer"];
                smtpclient.Port = 25;
                message.From = fromAddress;
                message.To.Add(To);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = body;
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                string strEx = ex.ToString();
                return false;
            }
        }

        public string LoadLangs(string strAttributeA, string strAttributeB)
        {
            StringBuilder strReport = new StringBuilder();

            XmlTextReader xmlReader = null;

            try
            {
                xmlReader = new XmlTextReader(xmlLangs);
                while (xmlReader.Read())
                {
                    // Process a start of element node.
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        //Ignore <Error> and <Position> elements.
                        if ((xmlReader.Name != "SunLightMountain" && (xmlReader.Name != "SlmfLang")))
                        {
                            if (xmlReader.Name == "Element")
                            {
                                //XmlNode attr = 
                                xmlReader.MoveToAttribute("Name");
                                if (xmlReader.Value == strAttributeA)
                                {
                                    xmlReader.MoveToAttribute("Area");
                                    if (xmlReader.Value == strAttributeB)
                                    {
                                        while (xmlReader.Read())
                                        {
                                            if (xmlReader.Name == "Report")
                                            {
                                                xmlReader.Read();
                                                if (xmlReader.NodeType == XmlNodeType.Text)
                                                {
                                                    strReport.Append(xmlReader.Value);
                                                    return strReport.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (XmlException ex)
            {
                strReport.Append("An XML exception occurred: " + ex.ToString());
            }
            catch (Exception ex)
            {
                strReport.Append("A general exception occurred: " + ex.ToString());
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
            return strReport.ToString();
        }

        public static SqlConnection ConnectData()
        {
            SqlConnection connPlayNet = new SqlConnection(ConfigurationManager.AppSettings["connFrontEndPlayNet"]);
            return connPlayNet;
        }

        public static SqlConnection ConnectDataString()
        {
            SqlConnection connPlayNet = new SqlConnection(ConfigurationManager.AppSettings["connFrontEndPlayNet"]);
            return connPlayNet;
        }


        //Class SunLight Mountain Forum Connection 

        //private static string strconnection = ConfigurationManager.AppSettings["connFrontEndPlayNet"];
        private static string strconnection = ConfigurationManager.ConnectionStrings["SLMFConnection"].ToString();
        public static string ConnectionString
        {
            get { return strconnection; }
            set { strconnection = value; }
        }

        private static string cn2 = ConfigurationManager.ConnectionStrings["HungLocSon"].ToString();
        public static string Connect2
        {
            get { return cn2; }
            set { cn2 = value; }
        }

        private static string strLangs = (new Page()).Server.MapPath("~\\SlmLangs\\vietnamese.xml");
        //private static XmlTextReader xmlreader = new XmlTextReader(strXML);
        public static string xmlLangs
        {
            get { return strLangs; }
            set { strLangs = value; }
        }
    }
}
