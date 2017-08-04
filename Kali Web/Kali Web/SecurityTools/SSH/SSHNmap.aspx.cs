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
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            /* System.Diagnostics.Process si = new System.Diagnostics.Process();
            //si.StartInfo.WorkingDirectory = "~/Security Binaries/Nmap/";
            si.StartInfo.UseShellExecute = false;
            //si.StartInfo.FileName = "~/Security Binaries/Nmap/nmap.exe";
            si.StartInfo.FileName = "C:\\Tmp\\Kali-Web\\plink\\plink.exe";
            si.StartInfo.Arguments = "/c plink root@192.168.127.146 -pw root";
            si.StartInfo.CreateNoWindow = true;
            si.StartInfo.RedirectStandardInput = true;
            si.StartInfo.RedirectStandardOutput = true;
            si.StartInfo.RedirectStandardError = true;
            si.Start();
            string output = si.StandardOutput.ReadToEnd();
            si.Close();

            Output.Text = output; */

            Output.Text = "";

            String host = "192.168.127.151";
            String user = "root";
            String password = "root";
            String userinputip = IP.Text;

            SshClient ssh = new SshClient(host, user, password);

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
    }
}