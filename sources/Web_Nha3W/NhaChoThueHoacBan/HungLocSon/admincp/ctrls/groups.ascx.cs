using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using Subgurim.Controles;

public partial class admincp_ctrls_groups : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Groups();
        }
        if (fp1.IsPosting) this.managePost1();
    }

    private void managePost1()
    {
        HttpPostedFileAJAX pf = fp1.PostedFile;
        if ((pf.Type == HttpPostedFileAJAX.fileType.image) && (pf.ContentLength <= 5 * 1024 * 1024))
        {
            fp1.SaveAs("~/images/", pf.FileName);
            //crble(pf.FileName);
        }
        fp1.PostedFile.responseMessage_Uploaded_NotSaved = "<span style=\"font-family: Tahoma; font-size: 11px;\">File không hợp lệ.</span>";
    }

    private void Groups()
    {
        gCities.DataSource = BGroups.AGroups();
        gCities.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        EGroups g = new EGroups();
        g.GroupName = txtGroupName.Value.ToString().Trim();
        g.Posts = int.Parse(txtPosts.Value.ToString());

        List<HttpPostedFileAJAX> fpn = new List<HttpPostedFileAJAX>();
        fpn = fp1.historial;

        g.Rank = fpn[0].FileName;
        g.Pm = int.Parse(txtPm.Value.ToString());
        BGroups.IGroups(g);
        Groups();
    }
    protected void gCities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EGroups t = new EGroups();
        t.GroupId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        BGroups.EGroups(t);
        Groups();
    }
    protected void gCities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gCities.EditIndex = e.NewEditIndex;
        Groups();
    }
    protected void gCities_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gCities.EditIndex = -1;
        Groups();
    }
    protected void gCities_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EGroups t = new EGroups();
        t.GroupId = int.Parse(gCities.DataKeys[e.RowIndex].Values[0].ToString());
        TextBox grpname = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtGroupName2");
        t.GroupName = grpname.Text.ToString();
        TextBox pst = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtPosts2");
        t.Posts = int.Parse(pst.Text.ToString());
        TextBox pm = (TextBox)gCities.Rows[e.RowIndex].FindControl("txtPm2");
        t.Pm = int.Parse(pm.Text.ToString());
        BGroups.UGroups(t);
        gCities.EditIndex = -1;
        Groups();
    }
    protected void gCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Value.ToString());
        EGroups t = new EGroups(i);
        EAuthorizations a = new EAuthorizations();
        a = BAuthorizations.Authors(t);
        if (a.Post) { rbt1posty.Checked = true; rbt1postn.Checked = false; }
        else { rbt1posty.Checked = false; rbt1postn.Checked = true; }
        if (a.Edit) { rbt2edity.Checked = true; rbt2editn.Checked = false; }
        else { rbt2edity.Checked = false; rbt2editn.Checked = true; }
        if (a.Del) { rbt3dely.Checked = true; rbt3deln.Checked = false; }
        else { rbt3dely.Checked = false; rbt3deln.Checked = true; }
        if (a.IsApproved) { rbt4IsApproy.Checked = true; rbt4IsAppron.Checked = false; }
        else { rbt4IsApproy.Checked = false; rbt4IsAppron.Checked = true; }
        if (a.Comment) { rbt5Commenty.Checked = true; rbt5Commentn.Checked = false; }
        else { rbt5Commenty.Checked = false; rbt5Commentn.Checked = true; }
        if (a.PM) { rbt6Pmy.Checked = true; rbt6Pmn.Checked = false; }
        else { rbt6Pmy.Checked = false; rbt6Pmn.Checked = true; }
        if (a.Email) { rbt7Emy.Checked = true; rbt7Emn.Checked = false; }
        else { rbt7Emy.Checked = false; rbt7Emn.Checked = true; }
        if (a.Alert) { rbt8Alerty.Checked = true; rbt8Alertn.Checked = false; }
        else { rbt8Alerty.Checked = false; rbt8Alertn.Checked = true; }
        if (a.Call) { rbt9Cally.Checked = true; rbt9Calln.Checked = false; }
        else { rbt9Cally.Checked = false; rbt9Calln.Checked = true; }
        if (a.Save) { rbt10Savey.Checked = true; rbt10Saven.Checked = false; }
        else { rbt10Savey.Checked = false; rbt10Saven.Checked = true; }
        if (a.Vote) { rbt11Votey.Checked = true; rbt11Voten.Checked = false; }
        else { rbt11Votey.Checked = false; rbt11Voten.Checked = true; }
        if (a.Rate) { rbt12Ratey.Checked = true; rbt12Raten.Checked = false; }
        else { rbt12Ratey.Checked = false; rbt12Raten.Checked = true; }
        if (a.Upload) { rbt13Uploady.Checked = true; rbt13Uploadn.Checked = false; }
        else { rbt13Uploady.Checked = false; rbt13Uploadn.Checked = true; }
        txtSize.Value = a.Size.ToString();
        txtFiles.Value = a.Files.ToString();
        if (a.ViewProfile) { rbt16Profiley.Checked = true; rbt16Profilen.Checked = false; }
        else { rbt16Profiley.Checked = false; rbt16Profilen.Checked = true; }
        if (a.HideProfile) { rbt17Hidey.Checked = true; rbt17Hiden.Checked = false; }
        else { rbt17Hidey.Checked = false; rbt17Hiden.Checked = true; }
        if (a.Up) { rbt18Upy.Checked = true; rbt18Upn.Checked = false; }
        else { rbt18Upy.Checked = false; rbt18Upn.Checked = true; }
        txtCountUp.Value = a.CountUp.ToString();
        if (a.Vip) { rbt20Vipy.Checked = true; rbt20Vipn.Checked = false; }
        else { rbt20Vipy.Checked = false; rbt20Vipn.Checked = true; }
        if (a.IP) { rbt21Ipy.Checked = true; rbt21Ipn.Checked = false; }
        else { rbt21Ipy.Checked = false; rbt21Ipn.Checked = true; }
        if (a.Download) { rbt22Downloady.Checked = true; rbt22Downloadn.Checked = false; }
        else { rbt22Downloady.Checked = false; rbt22Downloadn.Checked = true; }
        if (a.Approve) { rbt23Aprrovey.Checked = true; rbt23Aprroven.Checked = false; }
        else { rbt23Aprrovey.Checked = false; rbt23Aprroven.Checked = true; }
        txtCVip.Value = a.CVip.ToString();
        txtCIp.Value = a.CIp.ToString();
        if (a.Renew) { rbt24Renewy.Checked = true; rbt24Renewn.Checked = false; }
        else { rbt24Renewy.Checked = false; rbt24Renewn.Checked = true; }
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        GridViewRow row = gCities.SelectedRow;
        int i = int.Parse(gCities.DataKeys[row.RowIndex].Value.ToString());
        EAuthorizations a = new EAuthorizations();
        a.GroupId = i;
        if (rbt1posty.Checked) a.Post = true;
        else a.Post = false;
        if (rbt2edity.Checked) a.Edit = true;
        else a.Edit = false;
        if (rbt3dely.Checked) a.Del = true;
        else a.Del = false;
        if (rbt4IsApproy.Checked) a.IsApproved = true;
        else a.IsApproved = false;
        if (rbt5Commenty.Checked) a.Comment = true;
        else a.Comment = false;
        if (rbt6Pmy.Checked) a.PM = true;
        else a.PM = false;
        if (rbt7Emy.Checked) a.Email = true;
        else a.Email = false;
        if (rbt8Alerty.Checked) a.Alert = true;
        else a.Alert = false;
        if (rbt9Cally.Checked) a.Call = true;
        else a.Call = false;
        if (rbt10Savey.Checked) a.Save = true;
        else a.Save = false;
        if (rbt11Votey.Checked) a.Vote = true;
        else a.Vote = false;
        if (rbt12Ratey.Checked) a.Rate = true;
        else a.Rate = false;
        if (rbt13Uploady.Checked) a.Upload = true;
        else a.Upload = false;
        a.Size = int.Parse(txtSize.Value.ToString());
        a.Files = int.Parse(txtFiles.Value.ToString());
        if (rbt16Profiley.Checked) a.ViewProfile = true;
        else a.ViewProfile = false;
        if (rbt17Hidey.Checked) a.HideProfile = true;
        else a.HideProfile = false;
        if (rbt18Upy.Checked) a.Up = true;
        else a.Up = false;
        a.CountUp = int.Parse(txtCountUp.Value.ToString());
        if (rbt20Vipy.Checked) a.Vip = true;
        else a.Vip = false;
        if (rbt21Ipy.Checked) a.IP = true;
        else a.IP = false;
        if (rbt22Downloady.Checked) a.Download = true;
        else a.Download = false;
        if (rbt23Aprrovey.Checked) a.Approve = true;
        else a.Approve = false;
        a.CVip = int.Parse(txtCVip.Value.ToString());
        a.CIp = int.Parse(txtCIp.Value.ToString());
        if (rbt24Renewy.Checked) a.Renew = true;
        else a.Renew = false;
        BAuthorizations.UAuthors(a);
    }
}
