using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using SLMF.Entity;
using SLMF.Utility;
using SLMF.Business;

public partial class vlfrss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["TopicId"] != null)
        {
            int intTopicId = int.Parse(Request.Params["TopicId"].ToString());
            EnTopic tpc = new EnTopic();
            tpc.TopicId = intTopicId;
            EnRssFeed rss = new EnRssFeed();
            rss = BuRssFeed.SelectRssForumTitle(tpc);

            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);

            WriteChannel(writer, rss);
            SqlDataReader datrRss = BuRssFeed.SelectRssForum(tpc);
            CrtRssForum(datrRss, writer);
            if (datrRss.IsClosed == false)
            {
                datrRss.Close();
                datrRss.Dispose();
            }

            WriteRSSClosing(writer);

            writer.Flush();
            writer.Close();

            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.End();	
        }
        else if (Request.Params["ForumId"] != null)
        {
            int intForumId = int.Parse(Request.Params["ForumId"].ToString());
            EnForum frm = new EnForum();
            frm.ForumId = intForumId;
            EnRssFeed rss = new EnRssFeed();
            rss = BuRssFeed.SelectRssCateTitle(frm);

            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);

            WriteChannel(writer, rss);
            SqlDataReader datrRss = BuRssFeed.SelectRssCate(frm);
            CrtRssForum(datrRss, writer);

            WriteRSSClosing(writer);

            writer.Flush();
            writer.Close();

            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/xml";
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.End();
        }
    }

    public XmlTextWriter CrtRssForum(IDataReader reader, XmlTextWriter writer)
    {
        EnRssFeed rss = new EnRssFeed();
        while (reader.Read())
        {
            rss.ItemTitle = reader["Title"].ToString();
            rss.ItemDescription = reader["Message"].ToString();
            rss.ItemPubdate = DateTime.Parse(reader["CreationDate"].ToString());
            rss.ItemLink = reader["MessageId"].ToString();
            rss.ItemMember = reader["UserName"].ToString();

            writer.WriteStartElement("item");
            writer.WriteElementString("title", rss.ItemTitle + " (" + AnnounceTime(rss.ItemPubdate) + ") " +
                    LoadSLMF("SLMF_RssFeed", "ByMember") + " " + rss.ItemMember);
            writer.WriteElementString("link", LoadSLMF("SLMF_RssFeed", "LocationHost") + "/showtopic.aspx?messageid=" + rss.ItemLink + "#message" + rss.ItemLink);
            writer.WriteElementString("description", rss.ItemDescription);
            writer.WriteElementString("pubDate", rss.ItemPubdate.ToString("R"));
            writer.WriteEndElement();
            //AddRSSItem(writer, rss);
        }
        return writer;
    }

    //public XmlTextWriter CrtRssCate(DataTable reader, XmlTextWriter writer)
    //{
    //    EnRssFeed rss = new EnRssFeed();
    //    //while (reader.Rows.Count > 0)
    //    //{
    //        //rss.ItemTitle = reader["Title"].ToString();
    //        rss.ItemTitle = reader.Rows[0][1].ToString();
    //        //rss.ItemDescription = reader["Message"].ToString();
    //        rss.ItemDescription = reader.Rows[0][2].ToString();
    //        //rss.ItemPubdate = DateTime.Parse(reader["CreationDate"].ToString());
    //        rss.ItemPubdate = DateTime.Parse(reader.Rows[0][4].ToString());
    //        //rss.ItemLink = reader["MessageId"].ToString();
    //        rss.ItemLink = reader.Rows[0][0].ToString();
    //        //rss.ItemMember = reader["UserName"].ToString();
    //        rss.ItemMember = reader.Rows[0][3].ToString();

    //        writer.WriteStartElement("item");
    //        writer.WriteElementString("title", rss.ItemTitle + " (" + AnnounceTime(rss.ItemPubdate) + ") " +
    //                LoadSLMF("SLMF_RssFeed", "ByMember") + " " + rss.ItemMember);
    //        writer.WriteElementString("link", LoadSLMF("SLMF_RssFeed", "LocationHost") + "/showtopic.aspx?messageid=" + rss.ItemLink + "#message" + rss.ItemLink);
    //        writer.WriteElementString("description", rss.ItemDescription);
    //        writer.WriteElementString("pubDate", rss.ItemPubdate.ToString("R"));
    //        writer.WriteEndElement();
    //        //AddRSSItem(writer, rss);
    //    //}
    //    return writer;
    //}

    private string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    public XmlTextWriter WriteChannel(XmlTextWriter writer, EnRssFeed rss)
    {
        UtiString utiMsg = new UtiString();
        writer.WriteStartDocument();
        writer.WriteComment(LoadSLMF("SLMF_RssFeed", "Comment") + " " + DateTime.Now.ToString("R"));
        writer.WriteStartElement("rss");
        writer.WriteAttributeString("version", "2.0");
        writer.WriteStartElement("channel");
        writer.WriteElementString("title", rss.ChannelTitle);
        //writer.WriteElementString("link", "showtopic.aspx?);
        writer.WriteElementString("description", utiMsg.ReleaseInput(rss.ChannelDesc, 679));
        writer.WriteElementString("copyright", LoadSLMF("SLMF_RssFeed", "Copyright"));
        writer.WriteElementString("generator", LoadSLMF("SLMF_RssFeed", "Generator"));
        return writer;
    }

    public XmlTextWriter AddRSSItem(XmlTextWriter writer, EnRssFeed rss)
    {
        writer.WriteStartElement("item");
        writer.WriteElementString("title", rss.ItemTitle);
        writer.WriteElementString("link", "showtopic.aspx?messageid=" + rss.ItemLink + "#message" + rss.ItemLink);
        writer.WriteElementString("description", rss.ItemDescription);
        writer.WriteElementString("pubDate", rss.ItemPubdate.ToString("R"));
        writer.WriteEndElement();
        return writer;
    }

    public XmlTextWriter AddRSSItem(XmlTextWriter writer, bool bDescAsCDATA, EnRssFeed rss)
    {
        writer.WriteStartElement("item");
        writer.WriteElementString("title", rss.ItemTitle);
        writer.WriteElementString("link", "showtopic.aspx?messageid=" + rss.ItemLink + "#message" + rss.ItemLink);

        if (bDescAsCDATA == true)
        {
            // Now we can write the description as CDATA to support html content.
            // We find this used quite often in aggregators

            writer.WriteStartElement("description");
            writer.WriteCData(rss.ItemDescription);
            writer.WriteEndElement();
        }
        else
        {
            writer.WriteElementString("description", rss.ItemDescription);
        }

        writer.WriteElementString("pubDate", rss.ItemPubdate.ToString("R"));
        writer.WriteEndElement();

        return writer;
    }

    public XmlTextWriter WriteRSSClosing(XmlTextWriter writer)
    {
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();

        return writer;
    }

    private string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }
}
