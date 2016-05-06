using System;
using System.Collections.Generic;
using System.Text;

namespace SLMF.Entity
{
    public class EnAdmin
    {
        public EnAdmin()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int groupid;
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }

        private int adminid;
        public int AdminId
        {
            get { return adminid; }
            set { adminid = value; }
        }
    }
}