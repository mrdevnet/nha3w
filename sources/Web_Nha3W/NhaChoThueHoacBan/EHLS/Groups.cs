using System;

namespace HungLocSon.EHLS
{
    public class EGroups
    {
        public EGroups()
        {
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private string groupname;
        public string GroupName
        {
            get { return groupname; }
            set { groupname = value; }
        }

        private int posts;
        public int Posts
        {
            get { return posts; }
            set { posts = value; }
        }

        private string rank;
        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private int pm;
        public int Pm
        {
            get { return pm; }
            set { pm = value; }
        }

        public EGroups(int c)
        {
            this.GroupId = c;
        }

        public EGroups(int _GroupId, string _GroupName, int _Posts, string _Rank, int _Pm)
        {
            this.GroupId = _GroupId;
            this.GroupName = _GroupName;
            this.Posts = _Posts;
            this.Rank = _Rank;
            this.Pm = _Pm;
        }
        
    }
}
