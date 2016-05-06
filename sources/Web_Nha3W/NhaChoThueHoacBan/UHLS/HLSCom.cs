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
namespace HungLocSon.UHLS
{
    public class GUHLS
    {
        public GUHLS()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private const string cr2 = "a1bA2cB3dC4eD5fE6gF7hG8H9kK1NnUuVvXxYyZz";
        public string Codes2(int k)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int charLength = cr2.Length;
            StringBuilder sb = new StringBuilder();
            int idx = 0;
            for (int i = 0; i < k; i++)
            {
                idx = random.Next(0, charLength);
                sb.Append(cr2.Substring(idx, 1));
            }
            return sb.ToString();
        }

        public static string AutoID()
        {
            Random random = new Random();
            return DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString() +
                random.Next(0, 1000);
        }

        public static string NetId()
        {
            return DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                HttpContext.Current.Session.SessionID + "nha3w_com";
        }

        public string ReleaseInput(string input, int limit) // Only use it here? (Jwendl)
        {
            string output = input;

            // Check if the string is longer than the allowed amount
            // otherwise do nothing
            if (output.Length > limit && limit > 0)
            {

                // cut the string down to the maximum number of characters
                output = output.Substring(0, limit);

                // Check if the space right after the truncate point 
                // was a space. if not, we are in the middle of a word and 
                // need to cut out the rest of it
                if (input.Substring(output.Length, 1) != " ")
                {
                    int LastSpace = output.LastIndexOf(" ");

                    // if we found a space then, cut back to that space
                    if (LastSpace != -1)
                    {
                        output = output.Substring(0, LastSpace);
                    }
                }
                // Finally, add the "..."
                output += "...";
            }
            return output;
        }
        
        public bool SendMailSmtpClient(string From, string To, string subject, string body)
        {

            SmtpClient smtpclient = new SmtpClient();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            try
            {
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

        public bool ExEmail(string e)
        {
            bool r = false;
            string p = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            System.Text.RegularExpressions.Regex theRegEx = new System.Text.RegularExpressions.Regex(p, System.Text.RegularExpressions.RegexOptions.Compiled);

            if (theRegEx.IsMatch(e))
            {
                r = true;
            }
            return r;
        }

        private const string cr = "1A2B3C4D5E6F7G8H9K1N2U3V4X5Y6Z7";
        public string Codes(int k)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int charLength = cr.Length;
            StringBuilder sb = new StringBuilder();
            int idx = 0;
            for (int i = 0; i < k; i++)
            {
                idx = random.Next(0, charLength);
                sb.Append(cr.Substring(idx, 1));
            }
            return sb.ToString();
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

        public TimeSpan TimeZoneOffsetUser
        {
            get
            {
                return new TimeSpan(0);
            }
        }

        public TimeSpan TimeOffset
        {
            get
            {
                return TimeZoneOffsetUser;
            }
        }

        public string TimeServer(DateTime dateServer)
        {
            string strOutput = "";
            DateTime dateNow = DateTime.Now + TimeOffset;
            DateTime dateMessage = dateServer + TimeOffset;

            if (dateMessage.Date == dateNow.Date)
            {
                //strOutput = slmNew.LoadLangs("SLMF_Forum", "Today") + dateServer.ToLongTimeString();
                strOutput = "Hôm nay " + dateServer.ToLongTimeString();
            }
            else if (dateMessage.Date == dateNow.AddDays(-1).Date)
            {
                //strOutput = slmNew.LoadLangs("SLMF_Forum", "Yesterday") + dateServer.ToLongTimeString();
                strOutput = "Hôm qua " + dateServer.ToLongTimeString();
            }
            else
            {
                strOutput = dateServer.Day.ToString() + "/" + dateServer.Month.ToString() + "/" +
                            dateServer.Year.ToString() + " " + dateServer.ToLongTimeString();
            }
            return strOutput;
        }


        //Class SunLight Mountain Forum Connection 

        //private static string strconnection = ConfigurationManager.AppSettings["connFrontEndPlayNet"];
        private static string cn = ConfigurationManager.ConnectionStrings["HungLocSon"].ToString();
        public static string hls
        {
            get { return cn; }
            set { cn = value; }
        }

        private static string cnf = ConfigurationManager.ConnectionStrings["SLMFConnection"].ToString();
        public static string hlsf
        {
            get { return cnf; }
            set { cnf = value; }
        }

        private static int usd = int.Parse(ConfigurationManager.AppSettings["usd"]);
        public static int USD
        {
            get { return usd; }
            set { usd = value; }
        }

        private static int sjc = int.Parse(ConfigurationManager.AppSettings["sjc"]);
        public static int SJC
        {
            get { return sjc; }
            set { sjc = value; }
        }

        private static int size = int.Parse(ConfigurationManager.AppSettings["size"]);
        public static int Size
        {
            get { return size; }
            set { size = value; }
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

