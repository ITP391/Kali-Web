﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools
{
    public partial class Wireshark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String permission = (String)Session["permission"];
            /*String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }*/
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process si = new System.Diagnostics.Process();
            si.StartInfo.UseShellExecute = false;
            si.StartInfo.FileName = @"C:\Tmp\Kali-Web\Wireshark\tshark.exe";
            si.StartInfo.Arguments = "-i Wi-Fi -a duration:10";
            si.StartInfo.CreateNoWindow = true;
            si.StartInfo.RedirectStandardInput = true;
            si.StartInfo.RedirectStandardOutput = true;
            si.StartInfo.RedirectStandardError = true;
            si.Start();
            string output = si.StandardOutput.ReadToEnd();
            si.Close();

            Output.Text = output;
        }
    }
}