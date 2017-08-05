using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class nmapVul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Visible = false;
            //String permission = (String)Session["permission"];
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            String input = IP.Text;
            bool inputcheck = ValidateIPv4(input);

            if (inputcheck == true)
            {
                System.Diagnostics.Process si = new System.Diagnostics.Process();
                //si.StartInfo.WorkingDirectory = "~/Security Binaries/Nmap/";
                si.StartInfo.UseShellExecute = false;
                //si.StartInfo.FileName = "~/Security Binaries/Nmap/nmap.exe";
                si.StartInfo.FileName = "C:\\Tmp\\Kali-Web\\Nmap\\nmap.exe";
                //si.StartInfo.Arguments = "/c nmap 127.0.0.1";
                si.StartInfo.Arguments = "/c nmap -O " + input;
                si.StartInfo.CreateNoWindow = true;
                si.StartInfo.RedirectStandardInput = true;
                si.StartInfo.RedirectStandardOutput = true;
                si.StartInfo.RedirectStandardError = true;
                si.Start();
                string output = si.StandardOutput.ReadToEnd();
                si.Close();

                Output.Text = output;
            }
            else if (inputcheck == false)
            {
                Label4.Visible = true;
            }
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}