using System;

namespace HungLocSon.EHLS
{
    public class EWallet
    {
        public EWallet()
        {
        }

        private int walletid;
        public int WalletId
        {
            get { return walletid; }
            set { walletid = value; }
        }

        private string user;
        public string UserName
        {
            get { return user; }
            set { user = value; }
        }

        private string full;
        public string FullName
        {
            get { return full; }
            set { full = value; }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private DateTime updated;
        public DateTime Updated
        {
            get { return updated; }
            set { updated = value; }
        }

        public EWallet(int c)
        {
            this.WalletId = c;
        }
    }
}


