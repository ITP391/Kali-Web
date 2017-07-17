using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools
{
    public partial class HomeLect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String permission = (String) Session["permission"];

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else if (permission == "student")
            {
                Response.Redirect("HomeStud.aspx");
            }
            
        }
    }
}