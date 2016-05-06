using System;
using System.Data;

namespace HungLocSon.EHLS
{
    public class ECatalogs
    {
        public ECatalogs()
        {
        }

        private  int _CatalogId ;
        private  string _Name ;
        private string _SubName;
        private  int _SubId ;
        private  short _OrderBy ;
        private  bool _TopDefault ;
        private DataTable _NewsByCatalog;
        private int _CntNews;
        
        public ECatalogs(int _CatalogId, string _Name, int _SubId, short _OrderBy, bool _TopDefault)
        {
           this.CatalogId = _CatalogId ;
           this.Name = _Name ;
           this.SubId = _SubId ;
           this.OrderBy = _OrderBy ;
           this.TopDefault = _TopDefault ;
        }
        public DataTable NewsByCatalog
        {
            get { return _NewsByCatalog; }
            set { _NewsByCatalog = value; }
        }
        public int CatalogId
        {
            get { return _CatalogId ; }
            set { _CatalogId = value ; }
        }
        public string Name
        {
            get { return _Name ; }
            set { _Name = value ; }
        }
        public string SubName
        {
            get { return _SubName; }
            set { _SubName = value; }
        }
        public int SubId
        {
            get { return _SubId ; }
            set { _SubId = value ; }
        }
        public short OrderBy
        {
            get { return _OrderBy ; }
            set { _OrderBy = value ; }
        }
        public bool TopDefault
        {
            get { return _TopDefault ; }
            set { _TopDefault = value ; }
        }
        public int CntNews
        {
            get { return _CntNews; }
            set { _CntNews = value; }
        }
    }
}

