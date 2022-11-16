using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ObjectDetection
{
    public partial class fromObjDetect : Form
    {
        public fromObjDetect()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Creating new process info
            ProcessStartInfo psi = new ProcessStartInfo();
            string virtualEnvironment = getPath() + "venv\\Scripts\\python.exe";
            psi.FileName = virtualEnvironment;

            // Scripts and args
            var script = getPath() + "Face-Mask-Detection-system\\detect_mask_video.py";
            psi.Arguments = $"\"{script}\"";

            // Process config
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;

            //var process = Process.Start(psi);
            //string errors = "Errors\n" + process.StandardError.ReadToEnd();
            //string output = "Output\n" + process.StandardOutput.ReadToEnd();

            //MessageBox.Show(errors, "Errors");
            //MessageBox.Show(output, "Outputs");

            ThreadStart newThreadInf = new ThreadStart(() => Process.Start(psi));
            Thread newThread = new Thread(newThreadInf);
            newThread.Start();
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getPath() + "Without_Mask_Images");
        }
       
        private string getPath()
        {
            var path = Directory.GetCurrentDirectory();
            string[] mainPath = path.Split('\\');
            int n = mainPath.Length;
            string ans = "";
            for(int i = 0; i < n - 4; i++)
            {
                ans += mainPath[i] + "\\";
            }
            return ans;
        }
    }
}
