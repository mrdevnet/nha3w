using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DProperties
    {
        public DProperties()
        {
        }

        private EProperties pro(IDataReader i)
        {
            EProperties p = new EProperties();
            if (i["DocId"] != null && i["DocId"].ToString() != "") p.DocId = int.Parse(i["DocId"].ToString());
            p.Floor = int.Parse(i["Floor"].ToString());
            p.SittingRoom = int.Parse(i["SittingRoom"].ToString());
            p.BedRoom = int.Parse(i["BedRoom"].ToString());
            p.BathRoom = int.Parse(i["BathRoom"].ToString());
            if (i["SetId"] != null && i["SetId"].ToString() != "") p.SetId = int.Parse(i["SetId"].ToString());
            p.SizeOfLane = int.Parse(i["SizeOfLane"].ToString());
            p.DocName = i["DocName"].ToString();
            p.SetName = i["SetName"].ToString();
            p.Other = int.Parse(i["Othr"].ToString());
            return p;
        }

        public EProperties pr(EProperties p)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pid", p.PostId);
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shpr", pr))
            {
                EProperties e = new EProperties();
                if (r.Read())
                {
                    e = pro(r);
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return e;
            }
        }



    }
}
