using System;

namespace HungLocSon.EHLS
{
    public class EClasses
    {
        public EClasses()
        {
        }

        private int classid;
        public int ClassId
        {
            get { return classid; }
            set { classid = value; }
        }

        private string classname;
        public string ClassName
        {
            get { return classname; }
            set { classname = value; }
        }

        public EClasses(int c)
        {
            this.ClassId = c;
        }
    }
}
