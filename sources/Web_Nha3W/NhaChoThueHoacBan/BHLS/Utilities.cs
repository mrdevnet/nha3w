using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BUtilities
    {
        //protected static DUtilities p;
        public BUtilities()
        {
            
        }

        public static List<EUtilities> utis(EProperties e)
        {
            DUtilities p = new DUtilities();
            return p.pr(e);
        }

        public static void IUtilities(EUtilities t)
        {
            DUtilities br = new DUtilities();
            br.IUtilities(t);
        }

        public static void UUtilities(EUtilities t)
        {
            DUtilities br = new DUtilities();
            br.UUtilities(t);
        }

    }
}
