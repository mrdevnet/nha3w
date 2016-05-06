using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuGroup
    {
        public BuGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertGuestGroup(EnMember mbr, EnMemberProfile mbrpro, EnGroup grp)
        {
            DaGroup g = new DaGroup();
            g.InsertGuestGroup(mbr, mbrpro, grp);
        }

        public static SqlDataReader SelectAllGroups()
        {
            DaGroup dagrp = new DaGroup();
            return dagrp.SelectAllGroups();
        }

        public static DataTable SelectAllGroups2()
        {
            DaGroup dagrp = new DaGroup();
            return dagrp.SelectAllGroups2();
        }

        public static int DeleteGroup(EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            return dagrp.DeleteGroup(grp);
        }

        public static void SelectGroupDetails(ref EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            dagrp.SelectGroupDetails(ref grp);
        }

        public static void InsertRankImage(EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            dagrp.InsertRankImage(grp);
        }

        public static SqlDataReader SelectRankImage()
        {
            DaGroup dagrp = new DaGroup();
            return dagrp.SelectRankImage();
        }

        public static void InsertGroup(EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            dagrp.InsertGroup(grp);
        }

        public static void UpdateGroups(EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            dagrp.UpdateGroups(grp);
        }

        public static int InsertGroupsMembers(EnMember mbr, EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            return dagrp.InsertGroupsMembers(mbr, grp);
        }

        public static void DeleteMbrGrp(EnMember mbr, EnGroup grp)
        {
            DaGroup dagrp = new DaGroup();
            dagrp.DeleteMbrGrp(mbr, grp);
        }
    }
}
