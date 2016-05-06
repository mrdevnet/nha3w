using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SLMF.Entity;
using SLMF.DataAccess;


namespace SLMF.Business
{
    public class BuAdminGroup
    {
        public BuAdminGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable SelectAdminGroup()
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            return dagrp.SelectAdminGroup();
        }

        public static DataTable SelectUserGrps(EnAdmin admin)
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            return dagrp.SelectUserGrps(admin);
        }

        public static void DeleteAdminGrps(EnAdmin admin)
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            dagrp.DeleteAdminGrps(admin);
        }

        public static void DeleteAdmins(EnAdmin admin)
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            dagrp.DeleteAdmins(admin);
        }

        public static void InsertAdminGrps(EnAdmin admin)
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            dagrp.InsertAdminGrps(admin);
        }

        public static EnAdminGroup SelectAdminDetails(EnMember mbr)
        {
            DaAdminGroup dagrp = new DaAdminGroup();
            return dagrp.SelectAdminDetails(mbr);
        }
    }
}
