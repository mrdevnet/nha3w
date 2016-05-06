using System;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HungLocSon.UHLS
{
    public class EncryptM
    {
        public EncryptM()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Md5Encode(string strEnc)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strEnc));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string NetOn(int net)
        {
            int a = net / 60;
            int b = net % 60;
            if (a > 0)
            {
                if (a >= 24)
                {
                    int c = a / 24;
                    int d = a % 24;
                    if (d>0) return c + " ngày, " + d + " giờ, " + b + " phút";
                    else return c + " ngày";
                }
                return a + " giờ, " + b + " phút";
            }
            else return b + " phút";
        }

        public static string ToInput(string mobile)
        {

            return SwapAB(SwapAB(mobile.Trim()));
        }
        public static string ToOutput(string pass)
        {
            return SwapBA(SwapBA(pass));
        }
        private static string SwapAB(string S)
        {
            string RT = "";
            if (S != null && S.ToString() != "")
            {
                for (int i = 0; i <= S.Length / 2; i++)
                {
                    if (i < S.Length - 1 - i)
                        RT += S[i].ToString() + S[S.Length - 1 - i].ToString();
                    else if (i == S.Length - 1 - i)
                        RT += S[i].ToString();
                }
            }
            return RT;
        }
        private static string SwapBA(string S)
        {
            string L = "", R = "";
            if (S != null && S.ToString() != "")
            {
                for (int i = 0; i < S.Length; i++)
                {
                    if ((i + 2) % 2 == 0)
                        L += S[i].ToString();
                    else
                        R = S[i].ToString() + R;
                }
            }
            return L + R;
        }

        public static Bitmap ResizeBitmap(Bitmap src, int newWidth, int newHeight)
        {
            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(src, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        public static Bitmap AutoResizeBitmap(Bitmap src, int maxWidth, int maxHeight)
        {
            int w = src.Width;
            int h = src.Height;

            int longestDimension = (w > h) ? w : h;
            int shortestDimension = (w < h) ? w : h;

            float factor = ((float)longestDimension) / shortestDimension;

            double newWidth = maxWidth;
            double newHeight = maxWidth / factor;

            if (w < h)
            {
                newWidth = maxHeight / factor;
                newHeight = maxHeight;
            }

            Bitmap result = new Bitmap((int)newWidth, (int)newHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(src, 0, 0, (int)newWidth, (int)newHeight);
            }

            return result;
        }

        public static Bitmap CreateThumbnail(Bitmap loBMP, int lnWidth, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                //Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight) return loBMP;
                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }

                // System.Drawing.Image imgOut =

                //      loBMP.GetThumbnailImage(lnNewWidth,lnNewHeight,

                //                              null,IntPtr.Zero);

                // *** This code creates cleaner (though bigger) thumbnails and properly
                // *** and handles GIF files better by generating a white background for
                // *** transparent images (as opposed to black)
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);
                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }
        
        public static bool isMobileBrowser(ref string via)
        {  
        //GETS THE CURRENT USER CONTEXT 
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            bool flg = false;
        //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                flg = true;
            }
        //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER  
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                flg = true;
            }
        //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null && context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                flg = true;
            }  
        //AND FINALLY CHECK THE HTTP_USER_AGENT   
        //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types  
                string[] mobiles =  new string[]{
                    "midp", "j2me", "avant", "docomo",
                    "novarra", "palmos", "palmsource",
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/",
                    "blackberry", "mib/", "symbian",
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio",
                    "SIE-", "SEC-", "samsung", "HTC",
                    "mot-", "mitsu", "sagem", "sony",
                    "alcatel", "lg", "eric", "vx",
                    "NEC", "philips", "mmm", "xx",
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java",
                    "pt", "pg", "vox", "amoi",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo",
                    "sgh", "gradi", "jb", "dddi",
                    "moto", "iphone"
                };
            //Loop through each item in the list created above   
            //and check if the header contains that text  
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        flg = true;
                        via = s.ToLower();
                    }
                }
            }
            return flg;
        }

        public static Bitmap ChangeLogo(Bitmap bm, Bitmap logo, int xI, int yI)
        {

            Bitmap img = new Bitmap(bm);
            Bitmap lg = new Bitmap(logo);
            int x, y;
            x = ((lg.Width + xI) < img.Width) ? (lg.Width - 1) : (img.Width - 1);
            y = ((lg.Height + yI) < img.Height) ? (lg.Height - 1) : (img.Height - 1);
            Color c;
            //Byte gray;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    c = lg.GetPixel(j, i);
                    if (c.A != 0)
                        img.SetPixel(j + xI, i + yI, Color.FromArgb(c.R, c.G, c.B));

                }
            }
            return img;
        }

    }

}


