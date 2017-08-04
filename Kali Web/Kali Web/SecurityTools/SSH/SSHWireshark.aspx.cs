using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class SSHWireshark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }*/
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
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

                var terminal = ssh.RunCommand("tshark -a duration:60");

                var output = terminal.Result;

                Output.Text += output;
                ssh.Disconnect();
            }
        }
    }
}