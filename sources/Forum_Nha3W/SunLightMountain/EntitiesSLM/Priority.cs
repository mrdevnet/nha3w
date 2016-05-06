using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnPriority
    {
        public EnPriority()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int priorityid;
        public int PriorityId
        {
            get {return priorityid; }
            set { priorityid = value; }
        }

        private string priorityname;
        public string PriorityName
        {
            get { return priorityname; }
            set { priorityname = value; }
        }
    }
}
