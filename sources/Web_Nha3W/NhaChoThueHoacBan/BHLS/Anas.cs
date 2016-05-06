using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BAnas
    {
        //protected DAnas n;
        public BAnas()
        {
        }

        public static void IAnas(EAnas a)
        {
            DAnas n = new DAnas();
            n.IAnas(a);
        }

        public static EAnas IAnas2(EAnas a)
        {
            DAnas n = new DAnas();
            return n.IAnas2(a);
        }

        public static List<EAnas> LstNets()
        {
            DAnas n = new DAnas();
            return n.LstNets();
        }

        public static string VwO()
        {
            DAnas n = new DAnas();
            return n.VwO();
        }


    }
}
