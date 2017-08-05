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