using System;

namespace HungLocSon.EHLS
{
    public class EAuthorizations
    {
        public EAuthorizations()
        {
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private bool post;
        public bool Post
        {
            get { return post; }
            set { post = value; }
        }

        private bool edit;
        public bool Edit
        {
            get { return edit; }
            set { edit = value; }
        }

        private bool del;
        public bool Del
        {
            get { return del; }
            set { del = value; }
        }

        private bool isapproved;
        public bool IsApproved
        {
            get { return isapproved; }
            set { isapproved = value; }
        }

        private bool comment;
        public bool Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private bool pm;
        public bool PM
        {
            get { return pm; }
            set { pm = value; }
        }

        private bool email;
        public bool Email
        {
            get { return email; }
            set { email = value; }
        }

        private bool alert;
        public bool Alert
        {
            get { return alert; }
            set { alert = value; }
        }

        private bool call;
        public bool Call
        {
            get { return call; }
            set { call = value; }
        }

        private bool save;
        public bool Save
        {
            get { return save; }
            set { save = value; }
        }

        private bool vote;
        public bool Vote
        {
            get { return vote; }
            set { vote = value; }
        }

        private bool rate;
        public bool Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        private bool upload;
        public bool Upload
        {
            get { return upload; }
            set { upload = value; }
        }

        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        private int files;
        public int Files
        {
            get { return files; }
            set { files = value; }
        }

        private bool viewprofile;
        public bool ViewProfile
        {
            get { return viewprofile; }
            set { viewprofile = value; }
        }

        private bool hideprofile;
        public bool HideProfile
        {
            get { return hideprofile; }
            set { hideprofile = value; }
        }

        private bool up;
        public bool Up
        {
            get { return up; }
            set { up = value; }
        }

        private int countup;
        public int CountUp
        {
            get { return countup; }
            set { countup = value; }
        }

        private bool vip;
        public bool Vip
        {
            get { return vip; }
            set { vip = value; }
        }

        private bool ip;
        public bool IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private bool download;
        public bool Download
        {
            get { return download; }
            set { download = value; }
        }

        private bool approve;
        public bool Approve
        {
            get { return approve; }
            set { approve = value; }
        }

        private int cvip;
        public int CVip
        {
            get { return cvip; }
            set { cvip = value; }
        }

        private int cip;
        public int CIp
        {
            get { return cip; }
            set { cip = value; }
        }

        private bool renew;
        public bool Renew
        {
            get { return renew; }
            set { renew = value; }
        }

        public EAuthorizations(int c)
        {
            this.GroupId = c;
        }
    }
}
