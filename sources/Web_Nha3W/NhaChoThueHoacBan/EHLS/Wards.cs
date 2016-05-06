using System;

namespace HungLocSon.EHLS
{
    public class EWards
    {
        public EWards()
        {
        }


        private int wardid;
        public int WardId
        {
            get { return wardid; }
            set { wardid = value; }
        }

        private string name;
        public string WardName
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

        public EWards(int c)
        {
            this.WardId = c;
        }
    }
}
