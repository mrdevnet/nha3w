using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnAnalytics
    {
        public EnAnalytics()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private DateTime today;
        public DateTime Today
        {
            get { return today; }
            set { today = value; }
        }

        private int members;
        public int Members
        {
            get { return members; }
            set { members = value; }
        }

        private int messages;
        public int Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private int moderators;
        public int Moderators
        {
            get { return moderators; }
            set { moderators = value; }
        }

        private int topics;
        public int Topics
        {
            get { return topics; }
            set { topics = value; }
        }

        private int forums;
        public int Forums
        {
            get { return forums; }
            set { forums = value; }
        }

        private int memberid;
        public int MemberId
        {
            get { return memberid; }
            set { memberid = value; }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private int newestmemberid;
        public int NewestMemberId
        {
            get { return newestmemberid; }
            set { newestmemberid = value; }
        }

        private string newmember;
        public string NewMember
        {
            get { return newmember; }
            set { newmember = value; }
        }

        private DateTime newpost;
        public DateTime NewPost
        {
            get { return newpost; }
            set { newpost = value; }
        }

        private int registercount;
        public int RegisterCount
        {
            get { return registercount; }
            set { registercount = value; }
        }

        private int logincount;
        public int LoginCount
        {
            get { return logincount; }
            set { logincount = value; }
        }
    }
}
