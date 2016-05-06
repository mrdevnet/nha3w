using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BSaves
    {
        //protected DAnas n;
        public BSaves()
        {
        }

        public static int ASaves(EMember r)
        {
            DSaves l = new DSaves();
            return l.ASaves(r);
        }
    }
}

