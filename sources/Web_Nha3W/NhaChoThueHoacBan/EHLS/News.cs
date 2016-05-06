using System;
using System.Collections.Generic;

namespace HungLocSon.EHLS
{
    public class ENews
    {
        public ENews()
        {
        }

        private int _NewsId;
        private string _Title;
        private string _Summary;
        private string _Contents;
        private DateTime _Posted;
        private int _MemberId;
        private string _User;
        private int _Views;
        private int _Rating;
        private string _Tag;
        private string _IP;
        private bool _Vip;
        private int _CatalogId;
        private string _Images;
        private ECatalogs _Catalog;
        private List<ECatalogs> _LC;
        
        public ENews(int _NewsId, string _Title, string _Images, string _Summary, string _Contents, DateTime _Posted, int _MemberId, int _Views, int _Rating, string _Tag, string _IP, bool _Vip, int _CatalogId)
        {
            this.NewsId = _NewsId;
            this.Title = _Title;
            this.Summary = _Summary;
            this.Contents = _Contents;
            this.Posted = _Posted;
            this.MemberId = _MemberId;
            this.Views = _Views;
            this.Rating = _Rating;
            this.Tag = _Tag;
            this.IP = _IP;
            this.Vip = _Vip;
            this.CatalogId = _CatalogId;
            this.Images = _Images;
        }
        public List<ECatalogs> LLC
        {
            get { return _LC; }
            set { _LC = value; }
        }
        public ECatalogs Catalog
        {
            get { return _Catalog; }
            set { _Catalog = value; }
        }
        public int NewsId
        {
            get { return _NewsId; }
            set { _NewsId = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Images
        {
            get { return _Images; }
            set { _Images = value; }
        }
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        public DateTime Posted
        {
            get { return _Posted; }
            set { _Posted = value; }
        }
        public int MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        public int Views
        {
            get { return _Views; }
            set { _Views = value; }
        }
        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public string Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        public bool Vip
        {
            get { return _Vip; }
            set { _Vip = value; }
        }
        public int CatalogId
        {
            get { return _CatalogId; }
            set { _CatalogId = value; }
        }
    }
}

