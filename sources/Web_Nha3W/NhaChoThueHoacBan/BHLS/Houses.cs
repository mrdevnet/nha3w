using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BHouses
    {
        //protected static DUtilities p;

        public BHouses()
        {
            
        }

        public static void IHouses(EHouses t)
        {
            DHouses br = new DHouses();
            br.IHouses(t);
        }

        public static void UHouses(EHouses t)
        {
            DHouses br = new DHouses();
            br.UHouses(t);
        }

        public static List<EHouses> utis(EHouses e)
        {
            DHouses p = new DHouses();
            return p.pr(e);
        }

        public static List<EHouses> utis2(EHouses e)
        {
            DHouses p = new DHouses();
            return p.prst(e);
        }

        public static void EHouses(int i)
        {
            DHouses p = new DHouses();
            p.EHouses(i);
        }


    }
}

