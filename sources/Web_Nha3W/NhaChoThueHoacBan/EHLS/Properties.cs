using System;

namespace HungLocSon.EHLS
{
    public class EProperties
    {
        public EProperties()
        {
        }

        private int postid;
        public int PostId
        {
            get { return postid; }
            set { postid = value; }
        }

        private int docid;
        public int DocId
        {
            get { return docid; }
            set { docid = value; }
        }

        private int floor;
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        private int sittingroom;
        public int SittingRoom
        {
            get { return sittingroom; }
            set { sittingroom = value; }
        }

        private int bedroom;
        public int BedRoom
        {
            get { return bedroom; }
            set { bedroom = value; }
        }

        private int bathroom;
        public int BathRoom
        {
            get { return bathroom; }
            set { bathroom = value; }
        }

        private int setid;
        public int SetId
        {
            get { return setid; }
            set { setid = value; }
        }

        private int sizeofland;
        public int SizeOfLane
        {
            get { return sizeofland; }
            set { sizeofland = value; }
        }

        private string docname;
        public string DocName
        {
            get { return docname; }
            set { docname = value; }
        }

        private string setname;
        public string SetName
        {
            get { return setname; }
            set { setname = value; }
        }

        public EProperties(int i)
        {
            this.PostId = i;
        }

        private int other;
        public int Other
        {
            get { return other; }
            set { other = value; }
        }
    }
}
