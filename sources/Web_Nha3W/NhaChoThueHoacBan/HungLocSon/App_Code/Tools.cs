using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;

namespace HungLocSon.Tools
{
    public static class WebTools
    {
        public static string FormatDateTime(DateTime day)
        {
            DateTime today = DateTime.Now;
            TimeSpan total = today - day;
            if (total.Days > 1)
                return string.Format("{0:dd/MM/yyyy} {1:T}", day, day);
            else if (total.Days == 1 & today.Day - day.Day == 2)
                return string.Format("{0:dd/MM/yyyy} {1:t}", day, day);
            else if (today.Day - day.Day == 1)
                return string.Format("Hôm qua , {0:T}", day);
            else if (total.Hours > 6)
                return string.Format("Hôm nay , {0:T}", day);
            else if (total.Hours > 0)
                return string.Format("Cách đây {0} giờ, {1} phút", total.Hours, total.Minutes);
            else if (total.Minutes > 0)
                return string.Format("Cách đây {0} phút", total.Minutes);
            else
                return "Vài giây trước";
        }
        public static bool TestDateTime(DateTime day)
        {
            bool kt = false;
            TimeSpan total = DateTime.Now - day;
            if ((total.Days == 0) && (total.Hours < 7)) kt = true;
            return kt;
        }
        public static void CreateFolder(string PathURL)
        {
            PathURL = PathURL.StartsWith("~") ? PathURL : "~" + PathURL;

            string DuongdanThuMuc = HttpContext.Current.Server.MapPath(PathURL);
            if (!Directory.Exists(DuongdanThuMuc))
                Directory.CreateDirectory(DuongdanThuMuc);

        }
        public static void DeleteFolder(string directoryURL)
        {
            directoryURL = directoryURL.StartsWith("~") ? directoryURL : "~" + directoryURL;
            string directoryPath = System.Web.HttpContext.Current.Server.MapPath(directoryURL);
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    ClearFolder(new DirectoryInfo(directoryPath));//xóa bên trong
                    Directory.Delete(directoryPath, true);// xóa thu mục hiện hành
                }
            }
            catch
            {


            }

        }
        private static void ClearFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                ClearFolder(subfolder);
            }
        }
        public static void MoveFolder(string sourceURL, string destURL)
        {
            sourceURL = sourceURL.StartsWith("~") ? sourceURL : "~" + sourceURL;
            destURL = destURL.StartsWith("~") ? destURL : "~" + destURL;

            string sourcePath = System.Web.HttpContext.Current.Server.MapPath(sourceURL);
            string destPath = System.Web.HttpContext.Current.Server.MapPath(destURL);
            if (Directory.Exists(sourcePath))
            {
                DeleteFolder(destURL);
                Directory.Move(sourcePath, destPath);
            }
        }
        public static void RunJaVa(string javastr)
        {
            string script = "<script type='text/javascript'>" + javastr;
            script += "</script>";
            System.Web.HttpContext.Current.Response.Write(script);
        }
        public static string Paging(int MaxRow, int PageIndex, int PageShow, int RowsShow, string Query)
        {
            if (MaxRow == 0) return "";
            int PageNumber = 1, i = 1, Pages;
            Pages = (MaxRow % RowsShow > 0) ? (MaxRow / RowsShow + 1) : (MaxRow / RowsShow);
            int Star = 0;
            string TextPage = "Trang: " + PageIndex.ToString() + "/" + Pages.ToString() + "&nbsp;&nbsp;";
            if (PageIndex <= Pages)
                if (PageIndex == 1)
                {
                    PageNumber = PageShow;
                    if (PageNumber > Pages) PageNumber = Pages;
                    Star = 1;
                }
                else
                {
                    TextPage += "<a href=\"?" + Query + "&Page=1\">[<-</a> " +
                                "<a href=\"?" + Query + "&Page=" + (PageIndex - 1) + "\"><<</a>&nbsp;&nbsp;";
                    if ((Pages - PageIndex) < (PageShow / 2))
                    {
                        Star = Pages - PageShow + 1;
                        if (Star < 0) Star = 1;
                        PageNumber = Pages;
                    }
                    else
                    {
                        if (PageIndex - (PageShow / 2) == 0)
                        {
                            Star = 1;
                            PageNumber = PageIndex + (PageShow / 2) + 1;
                            if (Pages < PageNumber) PageNumber = Pages;
                        }
                        else
                        {
                            Star = PageIndex - (PageShow / 2);
                            if (Star < 0) Star = 1;
                            PageNumber = PageIndex + (PageShow / 2);
                            if (Pages < PageNumber)
                                PageNumber = Pages;
                            else
                                if (PageNumber < PageShow) PageNumber = PageShow;
                        }
                    }
                }
            i = Star;
            while (i <= PageNumber)
            {
                if (i == PageIndex)
                    TextPage += "[" + i + "] ";
                else
                    TextPage += "<a href=\"?" + Query + "&Page=" + i.ToString() + "\">" + i.ToString() + "</a> ";
                i++;
            }
            if (PageIndex < Pages)
            {
                TextPage += "&nbsp;<a href=\"?" + Query + "&Page=" + (PageIndex + 1) + "\">>></a> "
                            + "<a href=\"?" + Query + "&Page=" + Pages.ToString() + "\">->]</a>";
            }
            return TextPage + "&nbsp;&nbsp;" + MaxRow.ToString() + " : Kết quả";

        }
    }
    public static class Support
    {

        public static string FormatDateTime(DateTime date)
        {
            string ThoiGian = date.ToString("[!] dd [@] MM [$] yyyy");
            ThoiGian = ThoiGian.Replace("[!]", "Ngày");
            ThoiGian = ThoiGian.Replace("[@]", "Tháng");
            ThoiGian = ThoiGian.Replace("[$]", "Năm");
            string Thu = "";
            switch ((int)date.DayOfWeek)
            {
                case 1: Thu = "Thứ Hai "; break;
                case 2: Thu = "Thứ Ba "; break;
                case 3: Thu = "Thứ Tư "; break;
                case 4: Thu = "Thứ Năm "; break;
                case 5: Thu = "Thứ Sáu "; break;
                case 6: Thu = "Thứ Bảy "; break;
                default: Thu = "Chủ Nhật "; break;
            }
            return Thu + ThoiGian;

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
        public static string DateTimeToURL(string date)
        {
            DateTime time = DateTime.Parse(date);
            string url = "~/ImagesNews/" + time.Year.ToString() + "/" + time.Month.ToString() + "/";
            return url;
        }

        public static string calr(DateTime st)
        {
            return st.Day + "/" + st.Month + " : " + st.ToShortTimeString();
        }

        public static string ReleaseInput(string input, int limit) // Only use it here? (Jwendl)
        {
            if (input == null) return "";
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

        public static string ReleaseInput2(string input, int limit) // Only use it here? (Jwendl)
        {
            if (input == null) return "";
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
                //output += "...";
            }
            return output;
        }
    }
    

    public static class SendMail
    {
        public static String FromAddress
        {
            get
            {
                SmtpSection config = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                return config.Network.UserName;
            }
        }
        public static void Sendmail(string Host, int Port, string FromAddress, string FDisplayName, string UserName, string PassWord, string Domain, string ToAddress, string TDisplayName, string Subject, string Content, bool isHtml, bool isSSL)
        {
            SmtpClient client = new SmtpClient(Host, Port);
            client.EnableSsl = isSSL;
            MailAddress from = new MailAddress(FromAddress, FDisplayName);
            NetworkCredential myCreds = new NetworkCredential(UserName, PassWord, Domain);
            client.Credentials = myCreds;
            MailAddress to = new MailAddress(ToAddress, TDisplayName);
            MailMessage message = new MailMessage(from, to);
            message.Body = Content;
            message.IsBodyHtml = isHtml;
            message.Subject = Subject;
            try
            {
                client.Send(message);
            }
            catch
            {

            }
        }
        public static bool clies(string To, string subject, string body)
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
        public static void Sendmail(string DisplayName, string ToAddress, string Subject, string Content, bool isHtml, bool isSSL)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress(FromAddress, DisplayName);

                    mail.To.Add(ToAddress);

                    mail.Subject = Subject;

                    mail.Body = Content;

                    mail.IsBodyHtml = isHtml;

                    SmtpClient client = new SmtpClient();

                    client.EnableSsl = isSSL;

                    client.Send(mail);

                }

            }
            catch
            {

            }
        }
    }
}