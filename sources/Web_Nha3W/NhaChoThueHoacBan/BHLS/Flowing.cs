using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BFlowing
    {
        //protected DAnas n;
        public BFlowing()
        {
        }

        public static int IFlowing(EFlowing m)
        {
            DFlowing f = new DFlowing();
            return f.IFlowing(m);
        }

        public static void UFlws(EFlowing m)
        {
            DFlowing f = new DFlowing();
            f.UFlws(m);
        }

        public static EFlowing SFlowing(EFlowing m)
        {
            DFlowing f = new DFlowing();
            return f.SFlowing(m);
        }

        public static List<ETracks> LstTr4u(ETracks m)
        {
            DFlowing f = new DFlowing();
            return f.LstTr4u(m);
        }

        public static List<ETracks> LstTr4u3(ETracks m)
        {
            DFlowing f = new DFlowing();
            return f.LstTr4u3(m);
        }

        public static List<ETracks> LstTr4u4(ETracks m)
        {
            DFlowing f = new DFlowing();
            return f.LstTr4u4(m);
        }

        public static void ITr4u(ETracks m)
        {
            DFlowing f = new DFlowing();
            f.ITr4u(m);
        }

        public static List<EAnas> LstMFrs(EFlowing f)
        {
            DFlowing r = new DFlowing();
            return r.LstMFrs(f);
        }

        public static List<EAnas> LstMFrs2(EFlowing f)
        {
            DFlowing r = new DFlowing();
            return r.LstMFrs2(f);
        }

        //public static List<EAnas> LstTpMrs()
        //{
        //    DFlowing r = new DFlowing();
        //    return r.LstTpMrs();
        //}

        public static List<EFlowing> LstFlwings(int i)
        {
            DFlowing r = new DFlowing();
            return r.LstFlwings(i);
        }

        public static List<EFlowing> LstFlwings3(int i)
        {
            DFlowing r = new DFlowing();
            return r.LstFlwings3(i);
        }

        public static List<EFlowing> LstAproMbrs(int i)
        {
            DFlowing r = new DFlowing();
            return r.LstAproMbrs(i);
        }

        private static List<EAnas> LstTpFlws()
        {
            DFlowing r = new DFlowing();
            string cache = "lstTpFlws";
            if (BServer.Get(cache) == null)
            {
                BServer.Insert(cache, r.LstTpMrs(), "TopFlwrs");
            }
            return (List<EAnas>)BServer.Get(cache);
        }

        public static List<EAnas> TopFlwrings()
        {
            List<EAnas> tmp = new List<EAnas>();
            tmp = LstTpFlws();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("TopFlwrs", true);
                tmp = LstTpFlws();
            }
            return tmp;
        }

        public static List<EAnas> TopFlwrings2()
        {
            List<EAnas> ea = new List<EAnas>();
            List<EAnas> tmp = new List<EAnas>();
            tmp = LstTpFlws();
            if (tmp == null || tmp.Count == 0)
            {
                BServer.Remove("TopFlwrs", true);
                tmp = LstTpFlws();
            }
            if (tmp != null && tmp.Count > 0)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                int length = tmp.Count - 1;
                int rd = 0;
                List<int> a = new List<int>();
                bool clr = true;
                for (int i = 0; i <= 26; i++) //If > 18 then change it
                {
                    rd = random.Next(0, length+1);
                    clr = true;
                    if (a.Count > 0)
                    {
                        foreach (int j in a)
                        {
                            if (j == rd)
                            {
                                clr = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        a.Add(rd);
                        ea.Add(tmp[rd]);
                        clr = false;
                    }
                    if (clr)
                    {
                        a.Add(rd);
                        ea.Add(tmp[rd]);
                    }
                    i = ea.Count - 1;

                    //if (ea.Count > 0)
                    //{
                    //    bool tag = false;
                    //    foreach (EAnas j in ea)
                    //    {
                    //        if (j.MI == tmp[rd].MI)
                    //        {
                    //            tag = true;
                    //            break;
                    //        }
                    //    }
                    //    if (!tag)
                    //    {
                            
                    //    }
                    //}
                    //else
                    //{
                    //    ea.Add(tmp[rd]);
                    //}
                    
                }
            }
            return ea;
        }

        public static EPFiles PFiles(EPFiles m)
        {
            DFlowing r = new DFlowing();
            return r.PFiles(m);
        }

        

    }
}

