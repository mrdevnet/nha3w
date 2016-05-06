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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        //a.Text = HungLocSon.UHLS.EncryptM.ToInput(a.Text);
        a.Text = a.Text + HungLocSon.UHLS.GUHLS.AutoID();

        //b.Text = HungLocSon.UHLS.EncryptM.ToOutput(a.Text);

    }
    protected void blki2_Click(object sender, EventArgs e)
    {

    }
}
