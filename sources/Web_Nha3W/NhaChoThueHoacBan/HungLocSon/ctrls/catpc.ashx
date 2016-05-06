<%@ WebHandler Language="C#" Class="catpc" %>

using System;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using HungLocSon.UHLS;

public class catpc : IHttpHandler {
    private Random ran;
    public void ProcessRequest (HttpContext context) {
        
        context.Response.Cache.SetNoStore();
        context.Response.ContentType = "image/gif";
        ran = new Random();
        GUHLS c = new GUHLS();
        string i = c.Codes(6);
        coc(i);
        sc(i + string.Empty);
    }

    private void coc(string c)
    {
        HttpCookie coc1 = new HttpCookie("hlscoc1");
        DateTime dateSLMF = DateTime.Now;
        coc1.Value = c;
        coc1.Expires = dateSLMF.AddDays(3);
        HttpContext.Current.Response.Cookies.Add(coc1);
    }

    private void sc(string text)
    {
        string[] fonts = new string[] { "Tahoma", "Arial" };
        HatchStyle[] styles = new HatchStyle[] { HatchStyle.ForwardDiagonal, HatchStyle.BackwardDiagonal };

        Color c1 = Color.FromArgb(ran.Next(100, 255), ran.Next(200, 255), ran.Next(220, 255), ran.Next(200, 255));
        Color c2 = Color.FromArgb(ran.Next(100, 155), ran.Next(0, 155), ran.Next(0, 155), ran.Next(0, 255));
        Color c3 = Color.FromArgb(ran.Next(100, 255), ran.Next(0, 155), ran.Next(0, 155), ran.Next(0, 255));
        Color c4 = Color.FromArgb(ran.Next(250, 255), ran.Next(250, 255), ran.Next(250, 255));

        Brush br = new HatchBrush(styles[ran.Next(0, 2)], c1, c2);

        Bitmap re = new Bitmap(85, 22);
        Graphics gr = Graphics.FromImage(re);
        gr.CompositingQuality = CompositingQuality.HighQuality;
        gr.SmoothingMode = SmoothingMode.HighQuality;

        int fz = ran.Next(14, 18);
        Brush tb = new HatchBrush(styles[ran.Next(0, 2)], c2, c4);
        Font fo = new Font(fonts[ran.Next(0, 2)], fz);

        gr.FillRectangle(br, 0, 0, 90, 22);
        gr.DrawString(text, fo, tb, 16 - fz, 0);

        fo.Dispose();
        gr.Flush();
        br.Dispose();
        tb.Dispose();
        gr.Dispose();

        MemoryStream str = new MemoryStream();
        re.Save(str, ImageFormat.Gif);
        str.WriteTo(HttpContext.Current.Response.OutputStream);
        str.Flush();
        str.Close();
        re.Dispose();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}