using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BTracks
    {
        public BTracks()
        {
        }

        public static void ICalls(ETracks c)
        {
            DTracks l = new DTracks();
            l.ICalls(c);
        }

        public static void UCalls(ETracks c)
        {
            DTracks l = new DTracks();
            l.UCalls(c);
        }

        public static void DCalls(int c)
        {
            DTracks l = new DTracks();
            l.DCalls(c);
        }

        public static List<ETracks> LstTracks(string i)
        {
            DTracks t = new DTracks();
            return t.LstTracks(i);
        }

        public static void GrpDtls(ref ETracks i)
        {
            DTracks t = new DTracks();
            t.GrpDtls(ref i);
        }

        public static ETracks LstTracks1(int i)
        {
            DTracks t = new DTracks();
            return t.LstTracks1(i);
        }
    }
}
