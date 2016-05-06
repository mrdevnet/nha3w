using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnRssFeed
    {
        public EnRssFeed()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string channeltitle;
        public string ChannelTitle
        {
            get { return channeltitle; }
            set { channeltitle = value; }
        }

        private string channellink;
        public string ChannelLink
        {
            get { return channellink; }
            set { channellink = value; }
        }

        private string channeldesc;
        public string ChannelDesc
        {
            get { return channeldesc; }
            set { channeldesc = value; }
        }

        private DateTime channeldate;
        public DateTime ChannelDate
        {
            get { return channeldate; }
            set { channeldate = value; }
        }

        private string channelcopyright;
        public string ChannelCopyright
        {
            get { return channelcopyright; }
            set { channelcopyright = value; }
        }

        private string channelgenerator;
        public string ChannelGenerator
        {
            get { return channelgenerator; }
            set { channelgenerator = value; }
        }

        private string itemtitle;
        public string ItemTitle
        {
            get { return itemtitle; }
            set { itemtitle = value; }
        }

        private string itemlink;
        public string ItemLink
        {
            get { return itemlink; }
            set { itemlink = value; }
        }

        private string itemdescription;
        public string ItemDescription
        {
            get { return itemdescription; }
            set { itemdescription = value; }
        }

        private DateTime itempubdate;
        public DateTime ItemPubdate
        {
            get { return itempubdate; }
            set { itempubdate = value; }
        }

        private string itemmember;
        public string ItemMember
        {
            get { return itemmember; }
            set { itemmember = value; }
        }
    }
}
