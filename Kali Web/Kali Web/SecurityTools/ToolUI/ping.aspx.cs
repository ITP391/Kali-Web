using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class ping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String permission = (String)Session["permission"];

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            String input = IP.Text;

            Process p = new Process();
            // No need to use the CMD processor - just call ping directly.
            p.StartInfo.FileName = "ping.exe";
            //p.StartInfo.Arguments = "-a 127.0.0.1";
            p.StartInfo.Arguments = " -a " + input;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            var output = p.StandardOutput.ReadToEnd();
            Output.Text = output;
        }
    }
}