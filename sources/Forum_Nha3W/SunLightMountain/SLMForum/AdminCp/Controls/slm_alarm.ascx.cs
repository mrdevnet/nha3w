using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SLMF.Entity;
using SLMF.Utility;
using SLMF.Business;

public partial class AdminCp_Controls_slm_alarm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAlarm();
        }
    }

    private void LoadAlarm()
    {
        grvAlarm.DataSource = BuAlarm.SelectAlarm();
        grvAlarm.DataBind();
    }

    public string AnnounceTime(DateTime strInput)
    {
        UtiString unew = new UtiString();
        string strI = unew.TimeServer(strInput);
        return strI;
    }

    public string LoadSLMF(string strA, string strB)
    {
        UtiGeneralClass slmNew = new UtiGeneralClass();
        string strOutput = slmNew.LoadLangs(strA, strB);
        return strOutput;
    }

    public int RowId(int intMsgId)
    {
        EnMessage msg = new EnMessage();
        msg.MessageId = intMsgId;
        int intTpcId = BuMessage.SelectTopicId(msg);
        EnTopic tn = new EnTopic();
        tn.TopicId = intTpcId;
        return BuTopic.SelectRecordId(tn, msg);
    }
    protected void grvAlarm_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int intAlarmId = int.Parse(grvAlarm.DataKeys[e.RowIndex].Value.ToString());
        EnAlarm lrm = new EnAlarm();
        lrm.AlarmId = intAlarmId;
        BuAlarm.DeleteAlarm(lrm);
        LoadAlarm();
    }
    protected void grvAlarm_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvAlarm.SelectedRow;
        int intAlarmId = int.Parse(grvAlarm.DataKeys[row.RowIndex].Value.ToString());
        LoadAlarmDetails(intAlarmId);
    }

    private void LoadAlarmDetails(int intAlarmId)
    {
        EnAlarm lrm = new EnAlarm();
        lrm.AlarmId = intAlarmId;
        BuAlarm.SelectAlarmDetails(ref lrm);
        TitleDetail.Text = lrm.Title + " (" + lrm.AlarmTime.Day + "/" + lrm.AlarmTime.Month + 
                "/" + lrm.AlarmTime.Year + ")";
        ReportDetail.Text = lrm.Report.ToString();
        trDetails.Visible = true;
    }
    protected void grvAlarm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAlarm.PageIndex = e.NewPageIndex;
        LoadAlarm();
        trDetails.Visible = false;
    }
}
