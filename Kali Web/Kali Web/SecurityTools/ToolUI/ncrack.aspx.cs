using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class ncrack : System.Web.UI.Page
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
            String IP = IPinput.Text;

            System.Diagnostics.Process si = new System.Diagnostics.Process();
            //si.StartInfo.WorkingDirectory = "~/Security Binaries/Nmap";
            si.StartInfo.UseShellExecute = false;
            //si.StartInfo.FileName = "C:\\Users\\155126N\\Source\\Repos\\Kali-Web\\Kali Web\\Kali Web\\Security Binaries\\Ncrack\\ncrack.exe";
            si.StartInfo.FileName = "C:\\Tmp\\Kali-Web\\Ncrack\\ncrack.exe";
            //si.StartInfo.Arguments = "/c ncrack 127.0.0.1:3389";
            si.StartInfo.Arguments = "/c ncrack " + IP + ":3389";
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