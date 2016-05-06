using System;
using System.Collections.Generic;
using System.Text;
using SLMF.Entity;
using SLMF.DataAccess;


namespace SLMF.Business
{
    public class BuAnalytics
    {
        public BuAnalytics()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static EnAnalytics SelectAnalytics(EnAnalytics analday)
        {
            DaAnalytics daAnal = new DaAnalytics();
            return daAnal.SelectAnalytics(analday);
        }



    }
}