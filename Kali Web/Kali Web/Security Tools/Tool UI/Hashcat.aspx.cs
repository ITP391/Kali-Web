using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class Hashcat : System.Web.UI.Page
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
            System.Diagnostics.Process si = new System.Diagnostics.Process();
            //si.StartInfo.WorkingDirectory = "~/Security Binaries/Nmap";
            si.StartInfo.UseShellExecute = false;
            si.StartInfo.FileName = "C:\\Users\\155126N\\Source\\Repos\\Kali-Web\\Kali Web\\Kali Web\\Security Binaries\\oclHashcat\\hashcat64.exe";
            si.StartInfo.Arguments = "/c hashcat64 -m 100 -a 3 3d1887ee7d13952ac91b7f0e6045ab4965ae5617";
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