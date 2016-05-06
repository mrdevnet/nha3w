using System;

namespace HungLocSon.EHLS
{
    public class EPms
    {
        public EPms()
        {
        }

        private  int _PmID ;
        private  int _FromMember ;
        private  int _ToMemberId ;
        private  string _Title ;
        private  string _Message ;
        private  DateTime _Sent ;
        private  bool _IsRead ;
        private  bool _IsShow ;

        public EPms(int _PmID, int _FromMember, int _ToMemberId, string _Title, string _Message, DateTime _Sent, bool _IsRead, bool _IsShow)
        {
           this.PmID = _PmID ;
           this.FromMember = _FromMember ;
           this.ToMemberId = _ToMemberId ;
           this.Title = _Title ;
           this.Message = _Message ;
           this.Sent = _Sent ;
           this.IsRead = _IsRead ;
           this.IsShow = _IsShow ;
        }
        public int PmID
        {
            get { return _PmID ; }
            set { _PmID = value ; }
        }
        public int FromMember
        {
            get { return _FromMember ; }
            set { _FromMember = value ; }
        }
        public int ToMemberId
        {
            get { return _ToMemberId ; }
            set { _ToMemberId = value ; }
        }
        public string Title
        {
            get { return _Title ; }
            set { _Title = value ; }
        }
        public string Message
        {
            get { return _Message ; }
            set { _Message = value ; }
        }
        public DateTime Sent
        {
            get { return _Sent ; }
            set { _Sent = value ; }
        }
        public bool IsRead
        {
            get { return _IsRead ; }
            set { _IsRead = value ; }
        }
        public bool IsShow
        {
            get { return _IsShow ; }
            set { _IsShow = value ; }
        } 
    }
}

