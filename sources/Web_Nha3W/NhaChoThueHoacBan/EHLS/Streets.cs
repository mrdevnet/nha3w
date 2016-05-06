using System;

namespace HungLocSon.EHLS
{
    public class EStreets
    {
        public EStreets()
        {
        }

        private int streetid;
        public int StreetId
        {
            get { return streetid; }
            set { streetid = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int districtid;
        public int DistrictId
        {
            get { return districtid; }
            set { districtid = value; }
        }

        private int wardid;
        public int WardId
        {
            get { return wardid; }
            set { wardid = value; }
        }

        public EStreets(int c)
        {
            this.StreetId = c;
        }
    }
}
