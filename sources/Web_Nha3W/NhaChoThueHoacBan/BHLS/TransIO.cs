using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BTransIO
    {
        //protected DAnas n;
        public BTransIO()
        {
        }

        public static void ITransIn(ETransIn tr)
        {
            DTransIO l = new DTransIO();
            l.ITransIn(tr);
        }

        public static int MyWallet(string Uid)
        {
            DTransIO l = new DTransIO();
            return l.MyWallet(Uid);
        }

        public static string ITransOut(ETransIn tr)
        {
            DTransIO l = new DTransIO();
            return l.ITransOut(tr);
        }
    }
}

