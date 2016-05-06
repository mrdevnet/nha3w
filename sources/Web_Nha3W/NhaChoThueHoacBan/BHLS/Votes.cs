using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BVotes
    {
        //protected DAnas n;
        public BVotes()
        {
        }

        public static void Insert(EVotes ev)
        {
            DVotes dv = new DVotes();
            dv.Insert(ev);
        }
        public static DataTable SelectByPollId(int id)
        {
            DVotes dv = new DVotes();
            return dv.SelectByPollID(id);
        }
        public static bool TestIP(string IP, int PollID)
        {
            DVotes dv = new DVotes();
            return dv.TestIP(IP, PollID);
        }

        

    }
}
