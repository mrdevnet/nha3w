using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BResults
    {
        //protected DAnas n;
        public BResults()
        {
        }

        public static void Insert(EResults er)
        {
            DResults dr = new DResults();
            dr.Insert(er);
        }
        public static void Update(EResults er)
        {
            DResults dr = new DResults();
            dr.Update(er);
        }
        public static void Delete(int Id)
        {
            DResults dr = new DResults();
            dr.Delete(Id);
        }
        public static void Reply(int Id)
        {
            DResults dr = new DResults();
            dr.Reply(Id);
        }
        public static DataTable SelectByPollId(int id)
        {
            DResults dr = new DResults();
            return dr.SelectByPollID(id);
        }

    }
}


