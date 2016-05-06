using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SLMF.Entity
{
    public class EnAvatar
    {
        public EnAvatar()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int avatarid;
        public int AvatarId
        {
            get { return avatarid; }
            set { avatarid = value; }
        }

        private string avatar;
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
    }
}
