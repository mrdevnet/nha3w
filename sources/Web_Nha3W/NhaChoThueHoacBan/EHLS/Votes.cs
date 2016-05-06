using System;

namespace HungLocSon.EHLS
{
    public class EVotes
    {
        public EVotes()
        {
        }

        private int _VoteId;
        private int _PollId;
        private int? _UserId = null;
        private string _IP;
        private DateTime _VoteDate;

        public int VoteId
        {
            get { return _VoteId; }
            set { _VoteId = value; }
        }
        public int PollId
        {
            get { return _PollId; }
            set { _PollId = value; }
        }
        public int? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        public DateTime VoteDate
        {
            get { return _VoteDate; }
            set { _VoteDate = value; }
        }
    }
}

