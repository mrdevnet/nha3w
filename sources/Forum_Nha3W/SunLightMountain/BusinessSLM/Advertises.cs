using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SLMF.Entity;
using SLMF.DataAccess;

/// <summary>
/// Summary description for Bus_IdType
/// </summary>
/// 
namespace SLMF.Business
{
    public class BAdvertises
    {
        protected DAdvertises a;
        public BAdvertises()
        {
            a = new DAdvertises();
        }

        private List<EAdvertises> LstAdvertise()
        {
            string cache = "lstAdvertises";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, a.ListAdvertises(), "Advertises");
            }
            return (List<EAdvertises>)BServer.Get(cache);
        }

        public List<EAdvertises> RndAds()
        {
            List<EAdvertises> ea = new List<EAdvertises>();
            List<EAdvertises> tmp = new List<EAdvertises>();
            tmp = LstAdvertise();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Advertises", true);
                tmp = LstAdvertise();
            }
            if (tmp != null && tmp.Count > 0)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                //int length = tmp.Count - 1;
                int rd = 0;
                for (int i = 0; i < 4; i++)
                {
                    rd = random.Next(0, tmp.Count);
                    if (ea.Count > 0)
                    {
                        bool tag = false;
                        foreach (EAdvertises j in ea)
                        {
                            if (j.AdvertiseId == tmp[rd].AdvertiseId)
                            {
                                tag = true;
                                break;
                            }
                        }
                        if (!tag)
                        {
                            ea.Add(tmp[rd]);
                        }
                    }
                    else
                    {
                        ea.Add(tmp[rd]);
                    }
                    i = ea.Count -1;
                }
            }
            return ea;
        }

        private static List<EReports> LstReports()
        {
            string cache = "lstReports";
            DAdvertises c = new DAdvertises();
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, c.LstReports(), "Reports");
            }
            return (List<EReports>)BServer.Get(cache);
        }

        public static List<EReports> Reports()
        {
            List<EReports> tmp = new List<EReports>();
            tmp = LstReports();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("Reports", true);
                tmp = LstReports();
            }
            return tmp;
        }

        //public List<Banners> GetList()
        //{
        //    string cacheName = "lstBanners";
        //    if (ServerCache.Get(cacheName) == null)
        //    {
        //        ServerCache.Insert(cacheName, objBannersDA.GetList(), "Banners");
        //    }
        //    return (List<Banners>)ServerCache.Get(cacheName);
        //}

        //public static int CheckMemberExists(EnMember member)
        //{
        //    DaMember MemExists = new DaMember();
        //    int intResult = 0;
        //    intResult = MemExists.CheckMemberExists(member);
        //    return intResult;
        //}

        //    public static SqlDataReader SelectMemberLst(EnPagerF pager)
        //{
        //    DaMember topic = new DaMember();
        //    SqlDataReader datrTopic = topic.SelectMemberLst(pager);
        //    return datrTopic;
        //}
    }
}


