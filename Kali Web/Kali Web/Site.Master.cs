using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NotLoggedIn.Visible = false;
            LoggedIn.Visible = false;

            if (Session["email"] != null)
            {
                LoggedIn.Visible = true;
            }
            else
            {
                NotLoggedIn.Visible = true;
            }
        }
    }
}