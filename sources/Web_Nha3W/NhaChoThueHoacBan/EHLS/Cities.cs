using System;

namespace HungLocSon.EHLS
{
    public class ECities
    {
        public ECities()
        {
        }

        private int cityid;
        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        private string cityname;
        public string CityName
        {
            get { return cityname; }
            set { cityname = value; }
        }

        public ECities(int c)
        {
            this.CityId = c;
        }
    }
}
