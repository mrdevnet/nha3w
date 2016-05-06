using System;

namespace HungLocSon.EHLS
{
    public class ELocations
    {
        public ELocations()
        {
        }

        private int locationid;
        public int LocationId
        {
            get { return locationid; }
            set { locationid = value; }
        }

        private string localname;
        public string LocaName
        {
            get { return localname; }
            set { localname = value; }
        }

        public ELocations(int c)
        {
            this.locationid = c;
        }
    }
}
