using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class SSHNmap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Visible = false;
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            String host = "192.168.127.151";
            String user = "root";
            String password = "root";
            String userinputip = IP.Text;
            bool userinputipcheck = ValidateIPv4(userinputip);

            SshClient ssh = new SshClient(host, user, password);

            if (userinputipcheck == true)
            {
                using (ssh)
                {
                    ssh.Connect();

                    Output.Text = "Connected to Remote Kali Linux Server. Command is now running...\n";

                    var terminal = ssh.RunCommand("nmap " + userinputip);

                    var output = terminal.Result;

                    Output.Text += output;
                    ssh.Disconnect();
                }
            }
            else if (userinputipcheck == false)
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