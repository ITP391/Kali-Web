using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public partial class SSHTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            var host = "192.168.127.151";
            var username = "root";
            var password = "root";

            using (var client = new SshClient(host, username, password))
            {
                client.Connect();
                var cmd = client.CreateCommand(Input.Text);
                var result = cmd.Execute();

                Console.Write(result);

                var reader = new StreamReader(cmd.ExtendedOutputStream);
                Console.WriteLine("DEBUG:");
                Console.Write(reader.ReadToEnd());

                client.Disconnect();
            }
        }
    }
}