using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;


namespace WanThingConsole
{
    class Program
    {
        static bool debug = false;
        public static string outfile;
        static StringComparison comp = StringComparison.OrdinalIgnoreCase;
        public static string filterfile = "latestfilters.txt";
        public static string hostsfile = "latesthosts.txt";
        static void Main(string[] args)
        {
           if(!File.Exists(filterfile))
            {
                File.WriteAllText(filterfile, "");

            }
           if(!File.Exists(hostsfile))
            {
                Console.WriteLine("Error! {0} is missing from bin directory. Cannot continue!", hostsfile);
                return;
            }
            outfile = args[0];
            if (args.Length < 1)
            {
                Console.WriteLine("Error! I need 1 param! {0} output_file", args[0]);
                return;
            }
            DoStuff();
            

        }
        public static string Get(string uri, int timeout, string UA)
        {
            string testexception = "The remote server returned an error: (401) Unauthorized.";
            int tstcounter = 0;
            if (debug)
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
                request.Timeout = timeout * 1000;

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
                switch (UA)
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

                if (response.ContentType == "image/jpeg") // bug
                    return "jpeg file";
                if (response.ContentType == "multipart/x-mixed-replace; boundary=--BoundaryString")
                    return "another weird jpeg server thingy";
                if (response.Server == "Motion/4.0")
                    return "webcam stream";

                using (StreamReader kek = new StreamReader(stream))
                {
                    Char[] fuk  = new char[4096]; // fuck yes, speed shit up by only reading the first 4 kb
                    kek.Read(fuk, 0, fuk.Length);
                    string s = new string(fuk);
                    return s;
                    //return kek.ReadToEnd();
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

        public static string handleit(string cock)
        {
            string contents = File.ReadAllText(filterfile);
                if (cock.Contains(contents, comp))
                {
                    return "Filtered some BS out...\r\n\r\n";
                }
            
            
            return cock;

        }

        private static void DoStuff()
        {

            string[] lines = File.ReadAllLines(hostsfile);
            int x = 1;
            foreach (string line in lines)
            {
                StreamWriter sw = new StreamWriter(outfile, true);
                string contents = Get(line, 5 , "Google Bot");
                sw.WriteLine("========================= " + line + " =======================================\r\n\r\n");
                if (File.ReadAllText(filterfile) != "")
                {
                    sw.WriteLine("================================================================\r\n\r\n ");
                    sw.WriteLine(handleit(contents));
                    sw.WriteLine("\r\n\r\n");
                }
                else
                {
                    sw.WriteLine("================================================================\r\n\r\n ");
                    sw.WriteLine(handleit(contents));
                    sw.WriteLine("\r\n\r\n");
                }
                sw.WriteLine("==================================END==============================\r\n\r\n");
                Console.WriteLine("Working on item " + x.ToString() + " of " + lines.Length);
                sw.Close();
                x++;
            }


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
