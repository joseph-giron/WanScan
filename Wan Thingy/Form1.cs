using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Drawing.Imaging;
using System.Management.Instrumentation;

namespace Wan_Thingy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool skipornot;
        public string filename = "";
        public string excludelist = "";
        StringComparison comp = StringComparison.OrdinalIgnoreCase;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            tbHostList.Enabled = false;
            tbExcludeList.Enabled = false;
            lbUA.Enabled = false;
            tbTimeOut.Enabled = false;
            btnClearFilter.Enabled = false;
            btnClearURL.Enabled = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*Text File (.txt)|*.txt";
            sfd.ShowDialog();
            filename = sfd.FileName;

            if (filename == "")
            {
                filename = Application.StartupPath + "\\results.txt";
            }
            label1.Text = "Status: Working on " + tbHostList.Lines.Length.ToString() + " items.";
            if (tbExcludeList.Text == "")
            {
                excludelist = "";
                bg.RunWorkerAsync();
                return;
            }
            excludelist = tbExcludeList.Text;
            bg.RunWorkerAsync();
            return;
        }
       
        public string Get(string uri)
        {
            string testexception = "The remote server returned an error: (401) Unauthorized.";
            int tstcounter = 0;
            if (cbDebug.Checked)
            {
                tstcounter = 4;
            }
           
            string username = "admin";
            string password = "";
            here:
            try
            {
                // default is admin /  no password
                // ignore ssl error and force TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Timeout = Convert.ToInt32(tbTimeOut.Text) * 1000;

                //basic auth header
                if (tstcounter == 1)
                {
                    password = "admin";
                }
                if (tstcounter == 2)
                {
                    password = "password";
                }
                if (tstcounter == 3)
                {
                    password = "admin123";
                   
                }
                string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                request.Headers.Add("Authorization", "Basic " + encoded);
                switch (lbUA.Text)
                {
                    case "Google Bot":
                        request.UserAgent = "Googlebot/2.1 (+http://www.google.com/bot.html)";
                        break;
                    case "Bing Bot":
                        request.UserAgent = "Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)";
                        break;
                    case "DuckDuckBot":
                        request.UserAgent = "DuckDuckBot/1.0; (+http://duckduckgo.com/duckduckbot.html)";
                        break;
                    case "Baidu Bot":
                        request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)";
                        break;
                    case "Yandex Bot":
                        request.UserAgent = "Mozilla/5.0 (compatible; YandexBot/3.0; +http://yandex.com/bots)";
                        break;
                    case "Internet Explorer":
                        request.UserAgent = "Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
                        break;
                    case "FireFox":
                        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:64.0) Gecko/20100101 Firefox/64.0";
                        break;
                    case "Chrome":
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";
                        break;
                    case "America Online":
                        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; America Online Browser 1.1; Windows NT 5.1; (R1 1.5); .NET CLR 2.0.50727; InfoPath.1)";
                        break;
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // make request
                if (response.StatusCode == HttpStatusCode.Unauthorized) // 401 / unauthorized? go back and try again with another password
                // never makes it here, put it in the catch statement with a check
                {
                    tstcounter++;
                    goto here; // fuck yeah, goto! 
                }

                // not a 401? 
                Stream stream = response.GetResponseStream();

                if (response.ContentType == "image/jpeg") // bug fixes vvvvvvvvv
                    return "jpeg file";
                if (response.ContentType == "multipart/x-mixed-replace; boundary=--BoundaryString")
                    return "another weird jpeg server thingy";
                if (response.Server == "Motion/4.0")
                    return "webcam stream";

                using (StreamReader kek = new StreamReader(stream))
                {
                    Char[] fuk = new char[4096]; // fuck yes, speed shit up by only reading the first 4 kb
                    kek.Read(fuk, 0, fuk.Length);
                    string s = new string(fuk);
                    Uri uuu = new Uri(uri);
                    // maybe we do our filters within the request instead of on the loop where we write files?
                    return handleit(s.Trim('\0'), uuu); // now it stops with the extra null byte shit. Keeps output smaller. 
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
                if (ex.Message == testexception && tstcounter < 3)
                {
                    tstcounter++;
                    goto here; // fuck yeah, goto! 
                }
                else
                {
                    return "got an error accessing " + uri + "\r\n" + ex.Message + "\r\n";
                }
            }
        }

        public string handleit(string cock, Uri uritest)
        {
            for (int y = 0; y < tbExcludeList.Lines.Length; y++)
            {
                string contents = tbExcludeList.Lines[y];
                if (cock.Contains(contents, comp))
                {
                    if (CbFilteredOutput.Checked)
                    { skipornot = true; return "Filtered some BS out on " + uritest.Host + ":" + uritest.Port.ToString() + "\r\n\r\n"; ; }

                   return "Filtered some BS out...\r\n\r\n";
                }
            }
            if (CbFilteredOutput.Checked) // just return the hostname and port
            { return uritest.Host + ":" + uritest.Port.ToString() + "\r\n\r\n"; }
            return uritest.Host + ":" + uritest.Port.ToString() + "\r\n\r\n" + cock; // just return contents HTML style

        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
                for (int x = 0; x < tbHostList.Lines.Length; x++)
                {
                    if(bg.CancellationPending)
                    {
                    e.Cancel = true;
                    break;
                    }
                StreamWriter sw = new StreamWriter(filename, true);
                int percent = (x + 1) * 100 / tbHostList.Lines.Length;
                string contents = Get(tbHostList.Lines[x]);
                if (skipornot)
                { 
                    // found a filtered item, but dont want to output "filtered some BS out". Or do we? Maybe we should with the host and port?
                }
                //  sw.WriteLine("========================= " + tbHostList.Lines[x] + " =======================================\r\n\r\n");
                sw.WriteLine("===================================================================\r\n\r\n");
                // vvvvvvvvvvvv should return the URI and port followed by a new line entry plus the HTML, or just the URI and port entry if we want to skip.
                sw.WriteLine("###### "+contents+" ######\r\n\r\n"); // checked for filtered shit within get() function instead
                // so i guess we need a way to only return the hostlist entry if the item isnt filtered?  maybe do it within get() and write the URI there? but
                // only if the CbFilteredOutput item is checked. Otherwise, just leave the above function alone. 
                // scratch that, we're doing checking for that checkbox and returning of proper hostline data 
                sw.WriteLine("==================================END==============================\r\n\r\n");
                label1.Text = "Working on item " + x.ToString() + " of " + tbHostList.Lines.Length.ToString();
                bg.ReportProgress(percent);
                sw.Close();
                skipornot = false;
                
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bg.CancelAsync();
            // test
            pb.Value = 100;
            button1.Enabled = true;
            tbHostList.Enabled = true;
            tbExcludeList.Enabled = true;
            lbUA.Enabled = true;
            tbTimeOut.Enabled = true;
            btnClearFilter.Enabled = true;
            btnClearURL.Enabled = true;
            btnClearFilter.Enabled = true;
            btnClearURL.Enabled = true;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (CbFilteredOutput.Checked)
                skipornot = true;
            if (File.Exists("latestfilters.txt"))
            { 
                tbExcludeList.Text = File.ReadAllText("latestfilters.txt");
            }
            Form1.CheckForIllegalCrossThreadCalls = false;
            lbUA.SelectedIndex = 0;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(tbHostList, "https://ip_or_host_on_each_line/");
        }

        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (bg.CancellationPending)
            {
                bg.CancelAsync();
                return;
            }
            pb.Value = e.ProgressPercentage;
        }


        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        
            if(e.Cancelled)
            {
                label1.Text = "Status: Cancelled!!!";
            }
            else
            {
                label1.Text = "Status: Completed :D";
            }
            
            button1.Enabled = true;
            tbHostList.Enabled = true;
            tbExcludeList.Enabled = true;
            lbUA.Enabled = true;
            tbTimeOut.Enabled = true;
            btnClearFilter.Enabled = true;
            btnClearURL.Enabled = true;
            btnClearFilter.Enabled = true;
            btnClearURL.Enabled = true;
        }

        private void btnClearURL_Click(object sender, EventArgs e)
        {
            tbHostList.Clear();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            tbExcludeList.Clear();
        }

        private void btnLoadURLS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Select a file...",
                Filter = "Text Files (*.txt)|*.txt",
                // Filter = "XML Files (*.xml)|*.xml|Text Files (*.txt)|*.txt",
                Title = "Open text file"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                if (filename == "")
                {
                    return;
                }
                if (Path.GetExtension(filename) == ".txt")
                    tbHostList.Text = File.ReadAllText(filename);
            }
        }
        private void btnLoadFilters_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                if (filename == "")
                {
                    return;
                }
                tbExcludeList.Text = File.ReadAllText(filename);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Outset);
        }
    }
    public static class StringExtensions
    {
        public static bool Contains(this String str, String substring,
                                StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                                                "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison",
                                            "comp");
            return str.IndexOf(substring, comp) >= 0;
        }
    }
}
