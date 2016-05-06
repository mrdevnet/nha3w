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
using HungLocSon.BHLS;
using HungLocSon.EHLS;

public partial class Polls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EPolls ep = BPolls.SelectShow();
            ch.InnerText = ep.Title;
            this.bc.InnerText = string.Format(" ( Tổng {0} phiếu )",ep.Total);
            this.bc.Visible = false;
            rbl.DataSource = BResults.SelectByPollId(ep.PollId);
            rbl.DataBind();
            rbl.SelectedIndex = -1;
            LoadVote();
            if (ep.Repeat == false)
            {
                if (BVotes.TestIP(Request.UserHostAddress.ToString(), ep.PollId))
                {
                    oke.Enabled = false;
                    oke.Text = "Đã bình chọn";
                }
            }
        }
    }    
    protected void show_Click(object sender, EventArgs e)
    {
        LoadVote();
        divT.Visible = this.bc.Visible = !divT.Visible;
    }
    protected void oke_Click(object sender, EventArgs e)
    {
        EPolls ep = BPolls.SelectShow();
        ch.InnerText = ep.Title;
        if (ep.Repeat == false)
        {
            if (BVotes.TestIP(Request.UserHostAddress.ToString(), ep.PollId))
            {
                oke.Enabled = false;
                oke.Text = "Đã bình chọn";
                return;
            }
        }
        if (rbl.SelectedIndex == -1)
        {
            Err.InnerText = "Bạn chưa chọn câu trả lời.";
            return;
        }
        BResults.Reply(int.Parse(rbl.SelectedValue.ToString()));
        EVotes EV = new EVotes();
        EV.IP = Request.UserHostAddress;
        EV.PollId = ep.PollId;
        // EV.UserId = ;        
        this.bc.InnerText = string.Format("( Tổng {0} phiếu )", ep.Total + 1);
        BVotes.Insert(EV);
        LoadVote();
        this.bc.Visible = true;
        divT.Visible = true;
    }
    private void LoadVote()
    {
        Err.InnerText = "";
        string html = "<table width=\"300px\" style=\"border-color:#3B5998;\">";
        EPolls ep = BPolls.SelectShow();
        System.Data.DataTable rs = BResults.SelectByPollId(ep.PollId);
        int i = 0,dem =0,tam=0;
        //string div = "";
        if (ep.Total == 0)
        {
            html += "<tr><td style=\"color:#3B5998 ; font:11pt Tahoma;font-weight:bold;\">Chưa có bình chọn nào !</td></tr></table>";
            divT.InnerHtml = html;
        return;
        }
        foreach (System.Data.DataRow row in rs.Rows)
        {
            i++;
            html +=
                "<tr>" +"<td style=\"padding:0px; overflow:hidden; height:16px;\">";
            tam = (int)System.Math.Round((float)(int.Parse(row["Total"].ToString()) * 100) / ep.Total);
            dem = (i == rs.Rows.Count) ? dem : dem + tam;
            html += "<table height=\"16px\" width=\"300px\"><tr><td style=\"background-color:#67a54a\" width=\"" + tam.ToString() + "%\"></td><td nowrap=\"nowrap\">";
            tam = (i == rs.Rows.Count) ? (100 - dem):tam;
            html += tam.ToString() + "% - " + row["Total"].ToString() +" Phiếu";
            html += "</td></tr></table>";
            html += "</td>" +"</tr>";
        }
        html+= "</table>";
        divT.InnerHtml = html;
    }
}
