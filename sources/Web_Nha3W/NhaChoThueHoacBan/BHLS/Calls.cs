using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BCalls
    {
        //protected DAnas n;
        public BCalls()
        {
        }

        public static void ICalls(ECalls c, EMember r)
        {
            DCalls l = new DCalls();
            l.ICalls(c, r);
        }
    }
}
