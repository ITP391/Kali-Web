using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools
{
    public partial class nmap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process si = new System.Diagnostics.Process();
            //si.StartInfo.WorkingDirectory = "~/Security Binaries/Nmap/";
            si.StartInfo.UseShellExecute = false;
            //si.StartInfo.FileName = "~/Security Binaries/Nmap/nmap.exe";
            si.StartInfo.FileName = "C:\\Tmp\\Kali-Web\\Nmap\\nmap.exe"; //NEED TO CHANGE THE FILE PATH FOR EVERYONE'S COMPUTER
            si.StartInfo.Arguments = "/c nmap 127.0.0.1";
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