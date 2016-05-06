using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DClasses
    {
        public DClasses()
        {
        }

        public List<EClasses> LstClasses()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shCln", null))
            {
                List<EClasses> p = new List<EClasses>();
                while (r.Read())
                {
                    p.Add(Ct(r));
                }
                if (r.IsClosed == false)
                {
                    r.Close();
                    r.Dispose();
                }
                return p;
            }
        }

        private EClasses Ct(IDataReader i)
        {
            EClasses p = new EClasses();
            p.ClassId = (int)i["ClassId"];
            p.ClassName = (string)i["ClassName"];
            return p;
        }


    }
}
