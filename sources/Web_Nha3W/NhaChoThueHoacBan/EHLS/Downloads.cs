using System;

namespace HungLocSon.EHLS
{
    public class EDownloads
    {
        public EDownloads()
        {
        }

        private int _DownloadId;
        private string _Title;
        private string _Descs;
        private DateTime _Upload;
        private string _Files;
        private string _URL;
        private string _IP;
        private bool _Visible;
        private int _Download;
        private int _CatalogId;
        private int _MemberId;
        private string _User;

        public EDownloads(int _DownloadId, string _Title, string _Descs, DateTime _Upload, string _Files, string _URL, string _IP, bool _Visible, int _Download, int _CatalogId, int _MemberId)
        {
            this.DownloadId = _DownloadId;
            this.Title = _Title;
            this.Descs = _Descs;
            this.Upload = _Upload;
            this.Files = _Files;
            this.URL = _URL;
            this.IP = _IP;
            this.Visible = _Visible;
            this.Download = _Download;
            this.CatalogId = _CatalogId;
            this.MemberId = _MemberId;
        }
        public int DownloadId
        {
            get { return _DownloadId; }
            set { _DownloadId = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Descs
        {
            get { return _Descs; }
            set { _Descs = value; }
        }
        public DateTime Upload
        {
            get { return _Upload; }
            set { _Upload = value; }
        }
        public string Files
        {
            get { return _Files; }
            set { _Files = value; }
        }
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        public int Download
        {
            get { return _Download; }
            set { _Download = value; }
        }
        public int CatalogId
        {
            get { return _CatalogId; }
            set { _CatalogId = value; }
        }
        public int MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }

        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
    }
}

