using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SLMF.Entity;
using SLMF.DataAccess;

namespace SLMF.Business
{
    public class BuEm
    {
        public BuEm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertEm(EnMember mbr1, EnMember mbr2, EnEm em)
        {
            DaEm pmn = new DaEm();
            pmn.InsertEm(mbr1, mbr2, em);
        }

    }
}
