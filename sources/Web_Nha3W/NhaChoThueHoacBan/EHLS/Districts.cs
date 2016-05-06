using System;

namespace HungLocSon.EHLS
{
    public class EDistricts
    {
        public EDistricts()
        {
        }

        private int districtid;
        public int DistrictId
        {
            get { return districtid; }
            set { districtid= value; }
        }

        private int cityid;
        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        private string districtname;
        public string DistrictName
        {
            get { return districtname; }
            set { districtname= value; }
        }

        public EDistricts(int c)
        {
            this.DistrictId = c;
        }
    }
}
