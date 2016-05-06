using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SLMF.Utility
{
    public class UtiString
    {
        public UtiString()
        {
            //
            // TODO: Add constructor logic here
            //
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

            UtiGeneralClass slmNew = new UtiGeneralClass();
            if (dateMessage.Date == dateNow.Date)
            {
                strOutput = slmNew.LoadLangs("SLMF_Forum", "Today") + dateServer.ToLongTimeString();
            }
            else if (dateMessage.Date == dateNow.AddDays(-1).Date)
            {
                strOutput = slmNew.LoadLangs("SLMF_Forum", "Yesterday") + dateServer.ToLongTimeString();
            }
            else
            {
                strOutput = dateServer.Day.ToString() + "/" + dateServer.Month.ToString() + "/" + 
                            dateServer.Year.ToString() + " " + dateServer.ToLongTimeString();
            }
            return strOutput;
        }

        static private RegexOptions strOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline;

        static private Regex quote2 = new Regex(@"\[quote=(?<quote>[^\]]*)\](?<inner>(.*?))\[/quote\]", strOptions);
        static private Regex quote1 = new Regex(@"\[quote\](?<inner>(.*?))\[/quote\]", strOptions);

        static public string FormatBody(string strBody)
        {
            string localQuoteStr = "Quote:";
            string localQuoteWroteStr = "{0} đã viết:";
            string tmpReplaceStr;

            tmpReplaceStr = string.Format(@"<div class=""find1""><b>{0}</b><div class=""find2"">{1}</div></div>", localQuoteWroteStr.Replace("{0}", "${quote}"), "${inner}");

            while (quote2.IsMatch(strBody))
                strBody = quote2.Replace(strBody, tmpReplaceStr);

            tmpReplaceStr = string.Format(@"<div class=""find1""><b>{0}</b><div class=""find2"">{1}</div></div>", localQuoteStr, "${inner}");

            while (quote1.IsMatch(strBody))
                strBody = quote1.Replace(strBody, tmpReplaceStr);

            return strBody;
        }

        public static string clrs(string input, int limit) // Only use it here? (Jwendl)
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

        public static string calr(DateTime st)
        {
            return st.Day + "/" + st.Month + " : " + st.ToShortTimeString();
        }
    }
}
