using System;

namespace HungLocSon.EHLS
{
    public class EEmails
    {
        public EEmails()
        {
        }

        private  int _MailID ;
        private  int _FromMember ;
        private  int _ToMember ;
        private  DateTime _CreationDate ;
        private  string _Title ;
        private  string _Message ;
        
        public  EEmails( int _MailID ,int _FromMember ,int _ToMember ,DateTime _CreationDate ,string _Title ,string _Message  )
        {
           this.MailID = _MailID ;
           this.FromMember = _FromMember ;
           this.ToMember = _ToMember ;
           this.CreationDate = _CreationDate ;
           this.Title = _Title ;
           this.Message = _Message ;
        }
        public int MailID
        {
            get { return _MailID ; }
            set { _MailID = value ; }
        }
        public int FromMember
        {
            get { return _FromMember ; }
            set { _FromMember = value ; }
        }
        public int ToMember
        {
            get { return _ToMember ; }
            set { _ToMember = value ; }
        }
        public DateTime CreationDate
        {
            get { return _CreationDate ; }
            set { _CreationDate = value ; }
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
    }
}

