﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Submenu
{
    public partial class Quizes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String permission = (String)Session["permission"];
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }
    }
}