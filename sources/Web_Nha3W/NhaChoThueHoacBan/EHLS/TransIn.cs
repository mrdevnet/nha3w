using System;

namespace HungLocSon.EHLS
{
    public class ETransIn
    {
        public ETransIn()
        {
        }

        private int transin;
        public int TransIn
        {
            get { return transin; }
            set { transin = value; }
        }

        private int typeid;
        public int TypeId
        {
            get { return typeid; }
            set { typeid = value; }
        }

        private string typename;
        public string TypeName
        {
            get { return typename; }
            set { typename = value; }
        }

        private string resp;
        public string Resp
        {
            get { return resp; }
            set { resp = value; }
        }

        private string numberp;
        public string NumberP
        {
            get { return numberp; }
            set { numberp = value; }
        }

        private string portp;
        public string PortP
        {
            get { return portp; }
            set { portp = value; }
        }

        private DateTime transdate;
        public DateTime TransDate
        {
            get { return transdate; }
            set { transdate = value; }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private string memberid;
        public string MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private string bymember;
        public string ByMember
        {
            get { return bymember; }
            set { bymember = value; }
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        public ETransIn(int c)
        {
            this.TransIn = c;
        }
    }
}