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

public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "wall")
            {
                Nwall1.Visible = true;
                Flowings1.Visible = false;
                Fgps1.Visible = false;
                Pst1.Visible = false;
            }
            else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && (Request.Params["v"].ToString() == "frs" || Request.Params["v"].ToString() == "flws"))
            {
                Nwall1.Visible = false;
                Flowings1.Visible = true;
                Fgps1.Visible = false;
                Pst1.Visible = false;
            }
            else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "grps")
            {
                Nwall1.Visible = false;
                Flowings1.Visible = false;
                Fgps1.Visible = true;
                Pst1.Visible = false;
            }
            else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "favs")
            {
                Nwall1.Visible = true;
                Flowings1.Visible = false;
                Fgps1.Visible = false;
                Pst1.Visible = false;
            }
            else if (Request.Params["m"] != null && Request.Params["m"].ToString() != "" && Request.Params["v"] != null && Request.Params["v"].ToString() == "psts")
            {
                Nwall1.Visible = false;
                Flowings1.Visible = false;
                Fgps1.Visible = false;
                Pst1.Visible = true;
            }
        }
    }
}
