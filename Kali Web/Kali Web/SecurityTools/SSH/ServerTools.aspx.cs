using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class SSHTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Output.Text = "";

            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else if (permission == "student")
            {
                Response.Redirect("HomeStud.aspx");
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            String host = "192.168.127.151";
            String user = "root";
            String password = "root";

            SshClient ssh = new SshClient(host, user, password);

            using (ssh)
            {
                try
                {
                    ssh.Connect();

                    ssh.RunCommand("shutdown now");

                    ssh.Disconnect();
                } catch
                {
                    Output.Text = "Server shutting down now...\nPlease contact your administrator to start the server again.";
                }
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            SSH s = new SSH();

            String cmdInput = "ifconfig";

            Output.Text = s.SSHConnect(cmdInput);
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            String host = "192.168.127.151";
            String user = "root";
            String password = "root";

            SshClient ssh = new SshClient(host, user, password);

            using (var client = new SshClient(host, user, password))
            {
                try
                {
                    client.Connect();

                    client.RunCommand("reboot now");

                    client.Disconnect();
                } catch
                {
                    Output.Text = "Server rebooting now...\nPlease wait while the server reboots. This may take up to 5 minutes.";
                }
            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            SSH s = new SSH();

            String cmdInput = "date";

            Output.Text = s.SSHConnect(cmdInput);
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            SSH s = new SSH();

            String cmdInput = "ps";

            Output.Text = s.SSHConnect(cmdInput);
        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            SSH s = new SSH();

            String cmdInput = "who";

            Output.Text = s.SSHConnect(cmdInput);
        }
    }
}