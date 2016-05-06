using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BGroups
    {
        //protected DAnas n;
        public BGroups()
        {
        }

        public static DataTable AGroups()
        {
            DGroups d = new DGroups();
            return d.AGroups();
        }

        public static void IGroups(EGroups c)
        {
            DGroups d = new DGroups();
            d.IGroups(c);
        }

        public static void EGroups(EGroups c)
        {
            DGroups d = new DGroups();
            d.EGroups(c);
        }

        public static void UGroups(EGroups c)
        {
            DGroups d = new DGroups();
            d.UGroups(c);
        }



    }
}
