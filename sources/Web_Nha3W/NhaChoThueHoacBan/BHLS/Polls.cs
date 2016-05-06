using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BPolls
    {
        //protected DAnas n;
        public BPolls()
        {
        }

        public static void Insert(EPolls ep)
        {
            DPolls dp = new DPolls();
            dp.Insert(ep);
        }
        public static void Update(EPolls ep)
        {
            DPolls dp = new DPolls();
            dp.Update(ep);
        }
        public static void Delete(int Id)
        {
            DPolls dp = new DPolls();
            dp.Delete(Id);
        }
        public static DataTable SelectAll()
        {
            DPolls dp = new DPolls();
            return dp.SelectAll();
        }
        public static List<EPolls> ListAll()
        {
            DPolls dp = new DPolls();
            return dp.ListAll();
        }
        public static EPolls SelectById(int id)
        {
            DPolls dp = new DPolls();
            return dp.SelectByID(id);
        }


        //public static EPolls SelectShow()
        //{
        //    DPolls dp = new DPolls();
        //    return dp.SelectShow();
        //}


        private static EPolls LstSelShows()
        {
            DPolls dp = new DPolls();
            string ch = "LstSelShows";
            if (BServer.Get(ch) == null)
            {
                BServer.Insert(ch, dp.SelectShow(), "SelectShows");
            }
            return (EPolls)BServer.Get(ch);
        }

        public static EPolls SelectShow()
        {
            EPolls tmp = new EPolls();
            tmp = LstSelShows();
            if (tmp == null || tmp.PollId == 0)
            {
                BServer.Remove("SelectShows", true);
                tmp = LstSelShows();
            }
            return tmp;
        }
    }
}
