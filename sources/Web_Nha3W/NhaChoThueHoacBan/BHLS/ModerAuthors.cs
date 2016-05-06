using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BModerAuthors
    {
        //protected DAnas n;
        public BModerAuthors()
        {
        }

        public static EModerAuthors ModerAuthors(EModers m)
        {
            DModerAuthors t = new DModerAuthors();
            return t.ModerAuthors(m);
        }

        public static EModerAuthors ModerAuthors2(EMember m)
        {
            DModerAuthors t = new DModerAuthors();
            return t.ModerAuthors2(m);
        }

        public static void UModerAuthors(EModerAuthors c)
        {
            DModerAuthors t = new DModerAuthors();
            t.UModerAuthors(c);
        }

    }
}

