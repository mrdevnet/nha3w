using System;

namespace HungLocSon.EHLS
{
    public class EAccounts
    {
        public EAccounts()
        {
        }

        private int accountId;
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        private DateTime datecharge;
        public DateTime DateCharge
        {
            get { return datecharge; }
            set { datecharge = value; }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        public EAccounts(int c)
        {
            this.AccountId = c;
        }
    }
}

