using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BEmails
    {
        //protected DAnas n;
        public BEmails()
        {
        }

        public static DataTable Emails_Outbox(int id)
        {
            DEmails em = new DEmails();
            return em.Emails_Outbox(id);
        }
        public static void Emails_Del(int id)
        {
            DEmails em = new DEmails();
            em.Emails_Del(id);
        }
        public static void Emails_DelOutbox(int fid)
        {
            DEmails em = new DEmails();
            em.Emails_DelOutbox(fid);
        }
        public static void Emails_Insert(EEmails m)
        {
            DEmails em = new DEmails();
            em.Emails_Insert(m);
        }
        public static string Group_Email(int grid)
        {
            DEmails sm = new DEmails();
            return sm.Group_Email(grid);
        }
        public static string Group_FullName(int gr, string em)
        {
            DEmails sm = new DEmails();
            return sm.Group_FullName(gr, em);
        }

        public static void Emails_Insert2(EEmails e, EMember c)
        {
            DEmails em = new DEmails();
            em.Emails_Insert2(e,c);
        }
    }
}
