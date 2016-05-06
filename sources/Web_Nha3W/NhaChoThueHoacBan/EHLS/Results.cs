using System;

namespace HungLocSon.EHLS
{
    public class EResults
    {
        public EResults()
        {
        }

        private int _ResultId;
        private int _PollId;
        private string _Title;
        private int _Total;

        public int ResultId
        {
            get { return _ResultId; }
            set { _ResultId = value; }
        }
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
    }
}

