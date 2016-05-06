using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using HungLocSon.DHLS;
using HungLocSon.EHLS;

namespace HungLocSon.BHLS
{
    public class BPms
    {
        //protected DAnas n;
        public BPms()
        {
        }

        public static DataTable PMS_Inbox(int id)
        {
            DPms pm = new DPms();
            return pm.PMS_Inbox(id);
        }
        public static DataTable PMS_Outbox(int id)
        {
            DPms pm = new DPms();
            return pm.PMS_Outbox(id);
        }
        public static DataTable PMS_InboxIs(int id, bool ir)
        {
            DPms pm = new DPms();
            return pm.PMS_InboxIs(id, ir);
        }
        public static DataTable PMS_OutboxIs(int id, bool ir)
        {
            DPms pm = new DPms();
            return pm.PMS_OutboxIs(id, ir);
        }
        public static void PMS_Delete(int id)
        {
            DPms pm = new DPms();
            pm.PMS_Delete(id);
        }
        public static void PMS_InSert(EPms sms)
        {
            DPms pm = new DPms();
            pm.PMS_Insert(sms);
        }
        public static void PMS_DelInbox(int fid)
        {
            DPms pm = new DPms();
            pm.PMS_DelInbox(fid);
        }
        public static void PMS_DelOutbox(int tid)
        {
            DPms pm = new DPms();
            pm.PMS_DelOutbox(tid);
        }
        public static void PMS_Read(int id)
        {
            DPms pm = new DPms();
            pm.PMS_Read(id);
        }
        public static string PMS_NewInbox(int tid)
        {
            DPms pm = new DPms();
            return pm.PMS_NewInbox(tid);
        }

        public static void PMS_Insert2(EPms pm, EMember c)
        {
            DPms pm2 = new DPms();
            pm2.PMS_Insert2(pm,c);
        }

        

    }
}
