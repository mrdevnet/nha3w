using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DCategories
    {
        public DCategories()
        {
        }

        public List<ECategories> LstCategories()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shCtn", null))
            {
                List<ECategories> p = new List<ECategories>();
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

        private ECategories Ct(IDataReader i)
        {
            ECategories p = new ECategories();
            p.CategoryId = (int)i["CategoryId"];
            p.CateName = (string)i["CateName"];
            return p;
        }


    }
}