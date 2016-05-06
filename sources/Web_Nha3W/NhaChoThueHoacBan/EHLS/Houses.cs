using System;

namespace HungLocSon.EHLS
{
    public class EHouses
    {
        public EHouses()
        {
        }


        private int houseid;
        public int HouseId
        {
            get { return houseid; }
            set { houseid = value; }
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        private string images;
        public string Images
        {
            get { return images; }
            set { images = value; }
        }

        private DateTime creation;
        public DateTime CreationDate
        {
            get { return creation; }
            set { creation = value; }
        }


        public EHouses(int c)
        {
            this.HouseId = c;
        }
    }
}

