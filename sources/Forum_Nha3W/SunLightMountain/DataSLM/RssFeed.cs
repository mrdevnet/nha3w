using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;

namespace SLMF.DataAccess
{
    public class DaRssFeed
    {
        public DaRssFeed()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlDataReader SelectRssForum(EnTopic tpc)
        {
            //EnRssFeed []rss = new EnRssFeed();
            string strCommandText = "selRssForum";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            SqlDataReader dtrRss = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return dtrRss;
            /*CrtRssForum(datrTopic, ref rss);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }*/
        }

        private void CrtRssForum(IDataReader reader, ref EnRssFeed rss)
        {
            if (reader.Read())
            {
                rss.ItemTitle = reader["Title"].ToString();
                rss.ItemDescription = reader["Message"].ToString();
                rss.ItemPubdate = DateTime.Parse(reader["CreationDate"].ToString());
                rss.ItemLink = reader["MessageId"].ToString();
                rss.ItemMember = reader["UserName"].ToString();
            }
        }

        public EnRssFeed SelectRssForumTitle(EnTopic tpc)
        {
            EnRssFeed rss = new EnRssFeed();
            string strCommandText = "selRssForumTitle";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@TopicId", tpc.TopicId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CrtRssForumTitle(datrTopic, ref rss);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
            return rss;
        }

        private void CrtRssForumTitle(IDataReader reader, ref EnRssFeed rss)
        {
            if (reader.Read())
            {
                rss.ChannelTitle = reader["Title"].ToString();
                rss.ChannelDesc = reader["Message"].ToString();
                rss.ChannelDate = DateTime.Parse(reader["CreationDate"].ToString());
            }
        }

        public SqlDataReader SelectRssCategory(EnForum frm)
        {
            string strCommandText = "selRssCategory";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            SqlDataReader dtrRss = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            return dtrRss;
        }

        public EnRssFeed SelectRssCategoryTitle(EnForum frm)
        {
            EnRssFeed rss = new EnRssFeed();
            string strCommandText = "selRssCategoryTitle";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@ForumId", frm.ForumId);
            SqlDataReader datrTopic = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CrtRssCateTitle(datrTopic, ref rss);
            if (datrTopic.IsClosed == false)
            {
                datrTopic.Close();
                datrTopic.Dispose();
            }
            return rss;
        }

        private void CrtRssCateTitle(IDataReader reader, ref EnRssFeed rss)
        {
            if (reader.Read())
            {
                rss.ChannelTitle = reader["Name"].ToString();
                rss.ChannelDesc = reader["Description"].ToString();
                rss.ChannelDate = DateTime.Parse(reader["DateCreation"].ToString());
            }
        }

    }
}
