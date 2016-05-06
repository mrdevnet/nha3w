using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BAuthorizations
    {
        //protected DAnas n;
        public BAuthorizations()
        {
        }

        public static EAuthorizations Authors(EGroups m)
        {
            DAuthorizations t = new DAuthorizations();
            return t.Authors(m);
        }

        public static void UAuthors(EAuthorizations c)
        {
            DAuthorizations t = new DAuthorizations();
            t.UAuthors(c);
        }

        public static EAuthorizations Authors2(EMember m)
        {
            DAuthorizations t = new DAuthorizations();
            return t.Authors2(m);
        }



    }
}
