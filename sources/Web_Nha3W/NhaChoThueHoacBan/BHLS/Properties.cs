using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BProperties
    {
        //protected static DProperties p;
        public BProperties()
        {
            
        }

        public static EProperties pro(EProperties e)
        {
            DProperties p = new DProperties();
            return p.pr(e);
        }
    }
}
