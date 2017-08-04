using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Kali_Web.Security_Tools.Tool_UI
{
    public class SSH
    {
        public string SSHConnect(String command)
        {
            String host = "192.168.127.151";
            String user = "root";
            String password = "root";
            String result;

            SshClient ssh = new SshClient(host, user, password);

            using (ssh)
            {
                ssh.Connect();

                var terminal = ssh.RunCommand(command);

                var output = terminal.Result;

                result = output;
                ssh.Disconnect();
            }

            return result;
        }
    }
}