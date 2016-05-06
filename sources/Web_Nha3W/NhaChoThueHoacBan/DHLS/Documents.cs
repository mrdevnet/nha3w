using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.EHLS;

namespace HungLocSon.DHLS
{
    public class DDocuments
    {
        public DDocuments()
        {
        }

        public List<EDocuments> LstDocuments()
        {
            using (IDataReader r = HLSPro.ExecuteReader(CommandType.StoredProcedure, "shDos", null))
            {
                List<EDocuments> p = new List<EDocuments>();
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

        private EDocuments Ct(IDataReader i)
        {
            EDocuments p = new EDocuments();
            p.DocId = (int)i["DocId"];
            p.DocName = (string)i["DocName"];
            return p;
        }


    }
}

