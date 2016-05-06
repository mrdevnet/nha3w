using System;
using System.Data;
using System.Data.SqlClient;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BMember
    {
        //protected static DMember br;
        public BMember()
        {
            
        }

        public static int IMember(EMember m, EProfile p)
        {
            DMember br = new DMember();
            return br.IMember(m, p);
        }

        public static string SMember(EMember m)
        {
            DMember br = new DMember();
            return br.SaMember(m);
        }

        public static DataTable AWallets(string a)
        {
            DMember br = new DMember();
            return br.AWallets(a);
        }
        public static string APwds(string a)
        {
            DMember br = new DMember();
            return br.APwds(a);
        }

        public static int LMember(EMember m, EProfile p)
        {
            DMember br = new DMember();
            return br.LMember(m, p);
        }

        public static string ShwSeid(string aui)
        {
            DMember br = new DMember();
            return br.ShwSeid(aui);
        }

        public static EProfile PMember(EMember m)
        {
            DMember br = new DMember();
            return br.PMember(m);
        }

        public static EProfile PMemberI(EMember m)
        {
            DMember br = new DMember();
            return br.PMemberI(m);
        }

        public static DataTable APermiss(string strUserFull)
        {
            DMember br = new DMember();
            return br.APermiss(strUserFull);
        }

        public static void UMbrPrs(EMember c, EProfile p)
        {
            DMember br = new DMember();
            br.UMbrPrs(c, p);
        }

        public static int Login(int id, string us, string pw)
        {
            DMember log = new DMember();
            return log.Login(id, us, pw);
        }

        public static EMember Detail(int id)
        {
            DMember mb = new DMember();
            return mb.Detail(id);
        }
        public static void ChangePassword(int id, string pw, string sl)
        {
            DMember mb = new DMember();
            mb.ChangePassword(id, pw, sl);
        }
        public static int ReturnId(string something)
        {
            DMember mb = new DMember();
            return mb.ReturnId(something);
        }
        public static void ChangePublic(int id, string yh, string sp, string ws)
        {
            DMember mb = new DMember();
            mb.ChangePublic(id, yh, sp, ws);
        }
        public static DataTable Search(string info)
        {
            DMember mb = new DMember();
            return mb.Search(info);
        }
        public static void ChangeProfile(int id, string fn, string cpn, string ad, string tel, string mb, DateTime bir, bool gd)
        {
            DMember pf = new DMember();
            pf.ChangeProfile(id, fn, cpn, ad, tel, mb, bir, gd);
        }
        public static void ChangeEmail(int id, string email)
        {
            DMember mb = new DMember();
            mb.ChangeEmail(id, email);
        }
        public static void ChangeLogo(int id, string lg)
        {
            DMember mb = new DMember();
            mb.ChangeLogo(id, lg);
        }
        public static void ChangeFullName(int id, string fn)
        {
            DMember mb = new DMember();
            mb.ChangeFullName(id, fn);
        }

        public static string PMemberU(EMember m)
        {
            DMember mb = new DMember();
            return mb.PMemberU(m);
        }

        public static string PMemberU(int m)
        {
            DMember mb = new DMember();
            return mb.PMemberU(m);
        }

        public static EProfile Details(int id)
        {
            DProfile pf = new DProfile();
            return pf.Detail(id);
        }

        public static void UFlPri(EMember c, EPFiles p)
        {
            DMember pf = new DMember();
            pf.UFlPri(c,p);
        }
    }
}
