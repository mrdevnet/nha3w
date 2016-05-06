using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BProjects
    {
        //protected DAnas n;
        public BProjects()
        {
        }

        public static List<EProjects> Projects(EProjects t)
        {
            DProjects n = new DProjects();
            return n.LstProjects(t);
        }

        public static DataTable AProjects(ECities c)
        {
            DProjects n = new DProjects();
            return n.AProjects(c);
        }

        public static void IProjects(EProjects p)
        {
            DProjects n = new DProjects();
            n.IProjects(p);
        }

        public static DataTable AProjects2(EProjects c)
        {
            DProjects n = new DProjects();
            return n.AProjects2(c);
        }

        public static void EProjects(EProjects c)
        {
            DProjects n = new DProjects();
            n.EProjects(c);
        }

        public static void UProjects(EProjects c)
        {
            DProjects n = new DProjects();
            n.UProjects(c);
        }

    }
}