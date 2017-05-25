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

            String feedback = RequestInfo("192.168.127.146", "root", "root", new string[] { "nmap 172.0.0.1" }); //Enter command in array

            Output.Text = feedback;
        }

        public string RequestInfo(string remoteHost, string userName, string password, string[] lstCommands)
        {
            m_szFeedback = "Feedback from: " + remoteHost + "\r\n";

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "C:\\Tmp\\Kali-Web\\plink\\plink.exe", // A const or a readonly string that points to the plink executable
                Arguments = String.Format("-ssh {0}@{1} -pw {2}", userName, remoteHost, password),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process p = Process.Start(psi);

            m_objLock = new Object();
            m_blnDoRead = true;

            AsyncReadFeedback(p.StandardOutput); // start the async read of stdout
            AsyncReadFeedback(p.StandardError); // start the async read of stderr

            StreamWriter strw = p.StandardInput;

            foreach (string cmd in lstCommands)
            {
                strw.WriteLine(cmd); // send commands
            }
            strw.WriteLine("exit"); // send exit command at the end

            p.WaitForExit(); // block thread until remote operations are done
            return m_szFeedback;
        }

        private String m_szFeedback; // hold feedback data
        private Object m_objLock; // lock object
        private Boolean m_blnDoRead; // boolean value keeping up the read (may be used to interrupt the reading process)

        public void AsyncReadFeedback(StreamReader strr)
        {
            Thread trdr = new Thread(new ParameterizedThreadStart(__ctReadFeedback));
            trdr.Start(strr);
        }
        private void __ctReadFeedback(Object objStreamReader)
        {
            StreamReader strr = (StreamReader)objStreamReader;
            string line;
            while (!strr.EndOfStream && m_blnDoRead)
            {
                line = strr.ReadLine();
                // lock the feedback buffer (since we don't want some messy stdout/err mix string in the end)
                lock (m_objLock) { m_szFeedback += line + "\r\n"; }
            }
        }
    }
}