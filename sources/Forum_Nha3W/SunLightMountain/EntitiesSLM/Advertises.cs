using System;

namespace SLMF.Entity
{
    public class EAdvertises
    {
        public EAdvertises()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int advertiseid;
        public int AdvertiseId
        {
            get { return advertiseid; }
            set { advertiseid = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string bodytext;
        public string BodyText
        {
            get { return bodytext; }
            set { bodytext = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private DateTime creationdate;
        public DateTime CreationDate
        {
            get { return creationdate; }
            set { creationdate = value; }
        }

        private DateTime expiration;
        public DateTime Expiration
        {
            get { return expiration; }
            set { expiration = value; }
        }
        
        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private int views;
        public int Views
        {
            get { return views; }
            set { views = value; }
        }

        private int clicks;
        public int Clicks
        {
            get { return clicks; }
            set { clicks = value; }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private int setting;
        public int Setting
        {
            get { return setting; }
            set { setting = value; }
        }

        private int bymember;
        public int ByMember
        {
            get { return bymember; }
            set { bymember = value; }
        }

        public EAdvertises(int intadid)
        {
            this.AdvertiseId = intadid;
        }

        public EAdvertises(int adv, string tit, string bod, string url, string img, DateTime cre, 
            DateTime exp, int mem, bool sta, int vie, int cli, string sip, int set, int bym)
        {
            this.AdvertiseId = adv;
            this.Title = tit;
            this.BodyText = bod;
            this.Url = url;
            this.Image = img;
            this.CreationDate = cre;
            this.Expiration = exp;
            this.MemberId = mem;
            this.Status = sta;
            this.Views = vie;
            this.Clicks = cli;
            this.IP = sip;
            this.Setting = set;
            this.ByMember = bym;
        }
    }
}
