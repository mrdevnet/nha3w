using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BViolations
    {
        //protected DAnas n;
        public BViolations()
        {
        }

        public static void IVios(EViolations c, EMember r)
        {
            DViolations l = new DViolations();
            l.IVios(c, r);
        }

    }
}

