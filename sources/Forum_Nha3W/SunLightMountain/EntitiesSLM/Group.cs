using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SLMF.Entity
{
    public class EnGroup
    {
        public EnGroup()
        {
            //
            // TODO: Add constructor logic here
            //
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


        private int getposts;
        public int GetPosts
        {
            get { return getposts; }
            set { getposts = value; }
        }


        private string rankimage;
        public string RankImage
        {
            get { return rankimage; }
            set { rankimage = value; }
        }


        private int pmlimit;
        public int PmLimit
        {
            get { return pmlimit; }
            set { pmlimit = value; }
        }


    }
}
