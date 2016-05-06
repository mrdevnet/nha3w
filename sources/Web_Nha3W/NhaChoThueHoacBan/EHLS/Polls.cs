using System;

namespace HungLocSon.EHLS
{
    public class EPolls
    {
        public EPolls()
        {
        }
        
        private int _PollId;
        private string _Title;
        private int _Total;
        private bool _Repeat;
        private DateTime _FinishDate;

        public int PollId
        {
            get { return _PollId; }
            set { _PollId = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public bool Repeat
        {
            get { return _Repeat; }
            set { _Repeat = value; }
        }
        public DateTime FinishDate
        {
            get { return _FinishDate; }
            set { _FinishDate = value; }
        }
    }
}
