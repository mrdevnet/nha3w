using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuRssFeed
    {
        public BuRssFeed()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlDataReader SelectRssForum(EnTopic tpc)
        {
            //EnRssFeed rss = new EnRssFeed();
            DaRssFeed darss = new DaRssFeed();
            SqlDataReader rss = darss.SelectRssForum(tpc);
            return rss;
        }

        public static EnRssFeed SelectRssForumTitle(EnTopic tpc)
        {
            EnRssFeed rss = new EnRssFeed();
            DaRssFeed darss = new DaRssFeed();
            rss = darss.SelectRssForumTitle(tpc);
            return rss;
        }

        public static SqlDataReader SelectRssCate(EnForum frm)
        {
            DaRssFeed darss = new DaRssFeed();
            SqlDataReader rss = darss.SelectRssCategory(frm);
            return rss;
        }

        public static EnRssFeed SelectRssCateTitle(EnForum frm)
        {
            EnRssFeed rss = new EnRssFeed();
            DaRssFeed darss = new DaRssFeed();
            rss = darss.SelectRssCategoryTitle(frm);
            return rss;
        }



    }
}
