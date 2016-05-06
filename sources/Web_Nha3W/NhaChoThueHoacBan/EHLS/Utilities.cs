using System;

namespace HungLocSon.EHLS
{
    public class EUtilities
    {
        public EUtilities()
        {
        }

        private int utilityid;
        public int UtilityId
        {
            get { return utilityid; }
            set { utilityid = value; }
        }

        private string utiname;
        public string UtiName
        {
            get { return utiname; }
            set { utiname = value; }
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }
    }
}
