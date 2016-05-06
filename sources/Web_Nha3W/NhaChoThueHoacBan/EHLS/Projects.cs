using System;

namespace HungLocSon.EHLS
{
    public class EProjects
    {
        public EProjects()
        {
        }

        private int projectid;
        public int ProjectId
        {
            get { return projectid; }
            set { projectid = value; }
        }

        private int districtid;
        public int DistrictId
        {
            get { return districtid; }
            set { districtid = value; }
        }

        private string projectname;
        public string ProjectName
        {
            get { return projectname; }
            set { projectname = value; }
        }

        public EProjects(int c)
        {
            this.ProjectId = c;
        }
    }
}