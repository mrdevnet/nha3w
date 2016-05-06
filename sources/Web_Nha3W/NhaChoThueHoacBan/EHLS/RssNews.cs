using System;
using System.Xml;

namespace HungLocSon.EHLS
{
    public class ERssNews
    {
        private XmlDocument _rss = null;
        public struct RssImage
        {
            public string Link;
            public string Title;
            public string Url;
        }
        public struct RssChannel
        {
            public string Title;
            public string Link;
            public string Copyright;
            public string Language;
            public string Description;
        }
        private RssChannel _rsscha;
        public struct RssItem
        {
            public string Title;
            public string Link;
            public string PubDate;
            public string Description;
        }
        public RssChannel rsscha
        {
            get { return _rsscha; }
            set { _rsscha = value; }
        }
        private static XmlDocument addRssChannel(XmlDocument xmlDocument, RssChannel channel)
        {
            XmlElement channelElement = xmlDocument.CreateElement("channel");
            XmlNode rssElement = xmlDocument.SelectSingleNode("rss");
            rssElement.AppendChild(channelElement);

            XmlElement titleElement = xmlDocument.CreateElement("title");
            titleElement.InnerText = channel.Title;
            channelElement.AppendChild(titleElement);

            XmlElement linkElement = xmlDocument.CreateElement("link");
            linkElement.InnerText = channel.Link;
            channelElement.AppendChild(linkElement);

            XmlElement copyrightElement = xmlDocument.CreateElement("copyright");
            copyrightElement.InnerText = channel.Copyright;
            channelElement.AppendChild(copyrightElement);


            XmlElement languageElement = xmlDocument.CreateElement("language");
            languageElement.InnerText = channel.Language;
            channelElement.AppendChild(languageElement);

            XmlElement descriptionElement = xmlDocument.CreateElement("description");
            descriptionElement.InnerText =  channel.Description;
            channelElement.AppendChild(descriptionElement);

            return xmlDocument;
        }
        private static XmlDocument addRssItem(XmlDocument xmlDocument, RssItem item)
        {
            XmlElement itemElement = xmlDocument.CreateElement("item");
            XmlNode channelElement = xmlDocument.SelectSingleNode("rss/channel");

            XmlElement titleElement = xmlDocument.CreateElement("title");
            titleElement.InnerText = item.Title;
            itemElement.AppendChild(titleElement);

            XmlElement linkElement = xmlDocument.CreateElement("link");
            linkElement.InnerText = item.Link;
            itemElement.AppendChild(linkElement);

            XmlElement pubDateElement = xmlDocument.CreateElement("pubDate");
            pubDateElement.InnerText = item.PubDate;
            itemElement.AppendChild(pubDateElement);

            XmlElement descriptionElement = xmlDocument.CreateElement("description");
            descriptionElement.InnerText = item.Description;
            itemElement.AppendChild(descriptionElement);

            channelElement.AppendChild(itemElement);

            return xmlDocument;
        }
        private static XmlDocument addRssImages(XmlDocument xmlDocument, RssImage image)
            {
                XmlElement imageElement = xmlDocument.CreateElement("image");

                XmlNode channelElement = xmlDocument.SelectSingleNode("rss/channel");

                XmlElement titleElement = xmlDocument.CreateElement("title");
                titleElement.InnerText = image.Title;
                imageElement.AppendChild(titleElement);

                XmlElement linkElement = xmlDocument.CreateElement("link");
                linkElement.InnerText = image.Link;
                imageElement.AppendChild(linkElement);

                XmlElement urlElement = xmlDocument.CreateElement("url");
                urlElement.InnerText = image.Url;
                imageElement.AppendChild(urlElement);

                // append the item

                channelElement.AppendChild(imageElement);

                return xmlDocument;
            }
        public ERssNews()
        {
            _rss = new XmlDocument();
            XmlDeclaration xmlDeclaration = _rss.CreateXmlDeclaration("1.0", "utf-8", null);
            _rss.InsertBefore(xmlDeclaration, _rss.DocumentElement);

            XmlElement rssElement = _rss.CreateElement("rss");
            XmlAttribute rssVersionAttribute = _rss.CreateAttribute("version");

            rssVersionAttribute.InnerText = "2.0";
            rssElement.Attributes.Append(rssVersionAttribute);

            _rss.AppendChild(rssElement);
        }
        public void AddRssChannel(RssChannel channel)
        {
            _rss = addRssChannel(_rss, channel);
        }
        public void AddRssItem(RssItem item)
        {
            _rss = addRssItem(_rss, item);
        }
        public void AddRssImage(RssImage image)
        {
            _rss = addRssImages(_rss, image);
        }
        public string RssDocument
        {
            get
            {
                return _rss.OuterXml;
            }
        }
        public XmlDocument RssXMLDocument
        {
            get 
            {
                return _rss;
            }
        }
    }
}

