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
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class admincp_polls_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Nhà 3W - Kết nối & Xanh & Hiện đại";
        if (!IsPostBack)
        {
            LoadGri();
        }
    }

    private void LoadGri()
    {
        griPoll.DataSource = BPolls.ListAll();
        griPoll.DataBind();
    }
    protected void griPoll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        griPoll.EditIndex = e.NewEditIndex;
        LoadGri();
    }
    protected void griPoll_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        griPoll.EditIndex = -1;
        LoadGri();
    }
    protected void griPoll_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EPolls ep = new EPolls();
        ep.PollId = int.Parse(griPoll.DataKeys[e.RowIndex].Values[0].ToString());
        ep.Repeat = (griPoll.Rows[e.RowIndex].Cells[1].FindControl("ckbRe") as CheckBox).Checked;
        ep.Title = (griPoll.Rows[e.RowIndex].Cells[0].FindControl("txtTe") as TextBox).Text;
        BPolls.Update(ep);
        griPoll.EditIndex = -1;
        LoadGri();
    }
    protected void griPoll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "del":
                {
                    BPolls.Delete(int.Parse(e.CommandArgument.ToString()));
                    LoadGri();
                } break;
            case "vote":
                {
                    ShowPoll.Visible = false;
                    EPolls ep = BPolls.SelectById(int.Parse(e.CommandArgument.ToString()));
                    lbPollId.Text = ep.PollId.ToString();
                    lbPollT.Text = ep.Title;
                    griVote.DataSource = BVotes.SelectByPollId(ep.PollId);
                    griVote.DataBind();
                    ShowTitle.Visible = ShowVote.Visible = true;

                } break;
            case "result":
                {
                    ShowPoll.Visible = false;
                    EPolls ep = BPolls.SelectById(int.Parse(e.CommandArgument.ToString()));
                    lbPollId.Text = ep.PollId.ToString();
                    lbPollT.Text = ep.Title;
                    LoadGriRs();
                    ShowResult.Visible = ShowTitle.Visible = true;
                } break;
        }


    }
    protected void griPoll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griPoll.PageIndex = e.NewPageIndex;
        LoadGri();
    }
    protected void btok_Click(object sender, EventArgs e)
    {
        if (txtT.Text.Trim() == "") return;
        EPolls ep = new EPolls();
        ep.Title = txtT.Text;
        ep.Repeat = ckbR.Checked;
        BPolls.Insert(ep);
        txtT.Text = "";
        ckbR.Checked = false;
        LoadGri();
    }
    protected void lCl_Click(object sender, EventArgs e)
    {
        ShowResult.Visible = ShowVote.Visible = ShowTitle.Visible = false;
        ShowPoll.Visible = true;
    }
    protected void griVote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griVote.PageIndex = e.NewPageIndex;
        griVote.DataSource = BVotes.SelectByPollId(int.Parse(lbPollId.Text));
        griVote.DataBind();
    }
    protected void btRs_Click(object sender, EventArgs e)
    {
        EResults er = new EResults();
        er.PollId = int.Parse(lbPollId.Text);
        er.Title = txtRe.Text;
        txtRe.Text = "";
        BResults.Insert(er);
        LoadGriRs();
    }
    private void LoadGriRs()
    {
        if (lbPollId.Text != "")
        {
            griResult.DataSource = BResults.SelectByPollId(int.Parse(lbPollId.Text));
            griResult.DataBind();
        }
    }
    protected void griResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        griResult.EditIndex = e.NewEditIndex;
        LoadGriRs();
    }
    protected void griResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        griResult.EditIndex = -1;
        LoadGriRs();
    }
    protected void griResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EResults er = new EResults();
        er.ResultId = int.Parse(griResult.DataKeys[e.RowIndex].Values[0].ToString());
        er.Title = (griResult.Rows[e.RowIndex].Cells[0].FindControl("txtTe2") as TextBox).Text;
        BResults.Update(er);
        griResult.EditIndex = -1;
        LoadGriRs();
    }
    protected void griResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            BResults.Delete(int.Parse(e.CommandArgument.ToString()));
            LoadGriRs();
        }
    }
}
