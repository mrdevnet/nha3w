using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;


namespace SLMF.DataAccess
{
    public class DaAdminGroup
    {
        public DaAdminGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectAdminGroup()
        {
            string strCommandText = "selAdminGroups";
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, null);
        }

        public DataTable SelectUserGrps(EnAdmin admin)
        {
            string strCommandText = "selUserGrpAdmins";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@AdminId", admin.AdminId);
            return SqlHelper.ExecuteData(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void DeleteAdminGrps(EnAdmin admin)
        {
            string strCommandText = "delAdminsGrps";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@AdminId", admin.AdminId);
            paraLocal[1] = new SqlParameter("@GroupId", admin.GroupId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public void InsertAdminGrps(EnAdmin admin)
        {
            string strCommandText = "insAdminGrps";
            SqlParameter[] paraLocal = new SqlParameter[2];
            paraLocal[0] = new SqlParameter("@AdminId", admin.AdminId);
            paraLocal[1] = new SqlParameter("@GroupId", admin.GroupId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }

        public EnAdminGroup SelectAdminDetails(EnMember mbr)
        {
            EnAdminGroup admin = new EnAdminGroup();
            string strCommandText = "selAdminDetails";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@Admin", mbr.UserName);
            SqlDataReader datrAdmin = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strCommandText, paraLocal);
            CreateAdmin(ref admin, datrAdmin);
            if (datrAdmin.IsClosed == false)
            {
                datrAdmin.Close();
                datrAdmin.Dispose();
            }
            return admin;
        }

        private void CreateAdmin(ref EnAdminGroup admin, IDataReader datrAdmin)
        {
            while (datrAdmin.Read())
            {
                string strName = datrAdmin["Name"].ToString();
                switch (strName)
                {
                    case "sysc":
                    {
                        admin.Sysc = true;
                        break;
                    }
                case "analytics":
                    {
                        admin.Analytics = true;
                        break;
                    }
                case "blckuser":
                    {
                        admin.Blckuser = true;
                        break;
                    }
                case "addrpt":
                    {
                        admin.Addrpt = true;
                        break;
                    }
                case "updelrpt":
                    {
                        admin.Updelrpt = true;
                        break;
                    }
                case "rptman":
                    {
                        admin.Rptman = true;
                        break;
                    }
                case "addfrm":
                    {
                        admin.Addfrm = true;
                        break;
                    }
                case "updelfrm":
                    {
                        admin.Updelfrm = true;
                        break;
                    }
                case "updfrm":
                    {
                        admin.Updfrm = true;
                        break;
                    }
                case "cateman":
                    {
                        admin.Cateman = true;
                        break;
                    }
                case "privfrm":
                    {
                        admin.Privfrm = true;
                        break;
                    }
                case "userman":
                    {
                        admin.Userman= true;
                        break;
                    }
                case "addgrp":
                    {
                        admin.Addgrp= true;
                        break;
                    }
                case "grpman":
                    {
                        admin.Grpman= true;
                        break;
                    }
                case "usrgrp":
                    {
                        admin.Usrgrp= true;
                        break;
                    }
                case "grpfrm":
                    {
                        admin.Grpfrm = true;
                        break;
                    }
                case "memberpro":
                    {
                        admin.Memberpro = true;
                        break;
                    }
                case "moder":
                    {
                        admin.Moder= true;
                        break;
                    }
                case "almdrs":
                    {
                        admin.Almdrs = true;
                        break;
                    }
                case "armman":
                    {
                        admin.Armman= true;
                        break;
                    }
                case "prioman":
                    {
                        admin.Prioman= true;
                        break;
                    }
                case "addava":
                    {
                        admin.Addava= true;
                        break;
                    }

                case "vionline":
                    {
                        admin.Vionline = true;
                        break;
                    }
                case "blcmbr":
                    {
                        admin.Blcmbr = true;
                        break;
                    }
                case "blcip":
                    {
                        admin.Blcip= true;
                        break;
                    }
                case "addbnr":
                    {
                        admin.Addbnr = true;
                        break;
                    }
                case "admman":
                    {
                        admin.Admman = true;
                        break;
                    }
                case "aladms":
                    {
                        admin.Aladms = true;
                        break;
                    }
                }
            }
        }

        public void DeleteAdmins(EnAdmin admin)
        {
            string strCommandText = "delAdmins";
            SqlParameter[] paraLocal = new SqlParameter[1];
            paraLocal[0] = new SqlParameter("@AdminId", admin.AdminId);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, strCommandText, paraLocal);
        }



    }
}