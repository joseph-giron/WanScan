﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace WanThingConsole
{
    class Program
    {
        static bool debug, hostsonly = false;
        public static string outfile;
        static StringComparison comp = StringComparison.OrdinalIgnoreCase;
        public static string filterfile = "latestfilters.txt";
        public static string hostsfile = "latesthosts.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("                       .88888888:.");
            Console.WriteLine("                      88888888.88888.");
            Console.WriteLine("                    .8888888888888888.");
            Console.WriteLine("                    888888888888888888");
            Console.WriteLine(" |==============|   88' _`88'_  `88888");
            Console.WriteLine(" |Windows Blows!|   88 88 88 88  88888");
            Console.WriteLine(" |=======|======|   88_88_::_88_:88888");
            Console.WriteLine("         |          88:::,::,:::::8888");
            Console.WriteLine("         |_________ 88`:::::::::'`8888");
            Console.WriteLine("                   .88  `::::'    8:88.");
            Console.WriteLine("                  8888            `8:888.");
            Console.WriteLine("                .8888'             `888888.");
            Console.WriteLine("               .8888:..  .::.  ...:'8888888:.");
            Console.WriteLine("              .8888.'     :'     `'::`88:88888");
            Console.WriteLine("             .8888        '         `.888:8888.");
            Console.WriteLine("            888:8         .           888:88888");
            Console.WriteLine("          .888:88        .:           888:88888:");
            Console.WriteLine("          8888888.       ::           88:888888");
            Console.WriteLine("          `.::.888.      ::          .88888888");
            Console.WriteLine("         .::::::.888.    ::         :::`8888'.:.");
            Console.WriteLine("        ::::::::::.888   '         .::::::::::::");
            Console.WriteLine("        ::::::::::::.8    '      .:8::::::::::::.");
            Console.WriteLine("       .::::::::::::::.        .:888:::::::::::::");
            Console.WriteLine("       :::::::::::::::88:.__..:88888:::::::::::'");
            Console.WriteLine("        `'.:::::::::::88888888888.88:::::::::'");
            Console.WriteLine("              `':::_:' -- '' -'-' `':_::::'`");

            if (!File.Exists(filterfile))
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
            
            if (args.Length >=2 && args[1].Equals("skip"))
                debug = true;
            if (args.Length >= 2 && args[1].Equals("hostsonly"))
                hostsonly = true;
            if (args.Length >= 3 && args[2].Equals("skip"))
                debug = true;
            if (args.Length >= 3 && args[2].Equals("hostsonly"))
                hostsonly = true;
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
                    password = "password1";
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
                    // so sick of this fucking endpoint firewall, this is the ONLY way to get rid of it.
                    Char[] md5check = new char[261];
                    kek.Read(md5check, 0, md5check.Length);
                    string e = new string(md5check);


                    Char[] fuk = new char[4096]; // fuck yes, speed shit up by only reading the first 4 kb
                    kek.Read(fuk, 0, fuk.Length);
                    string s = new string(fuk);
                    Uri uuu = new Uri(uri);
                    // maybe we do our filters within the request instead of on the loop where we write files?
                    return handleit(s.Trim('\0'), uuu, e); // now it stops with the extra null byte shit. Keeps output smaller. 
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
        public static string Md5ToString(string md5check)
        {
            MD5 mD = MD5.Create();
            byte[] array2 = mD.ComputeHash(Encoding.ASCII.GetBytes(md5check));
            string md5text = "";
            for (int i = 0; i < array2.Length; i++)
            {
                md5text += string.Format("{0:X2}", array2[i]);
            }
            return md5text;
        }

        public static string handleit(string clock, Uri uritest, string md5check)
        {
            String[] lines = File.ReadAllLines(filterfile);
            for (int y = 0; y < lines.Length; y++)
            {
                
                string contents = lines[y];
                if (clock.Contains(contents, comp))
                {
                    return "####### Filtered some BS out on " + uritest.OriginalString + " #######"; 
                }
            }
            if (hostsonly) // just return the hostname and port
            { return "#_#_#_#_#_#_# " + uritest.OriginalString + " #_#_#_#_#_#_#"; }
            // so sick of this fucking endpoint firewall, this is the ONLY way to get rid of it.
            string md5_val = Md5ToString(md5check); if (md5_val == "C435CBD159B4356B02B144148635AD80") { return "Filtered some BS out on " + uritest.Host + ":" + uritest.Port.ToString() + "\r\n\r\n"; }
            return "####### " + uritest.OriginalString +  " #######" + "\r\n\r\n" + clock; // just return contents HTML style
        }

        private static void DoStuff()
        {

            string[] lines = File.ReadAllLines(hostsfile);
            int x = 1;
            foreach (string line in lines)
            {
                StreamWriter sw = new StreamWriter(outfile, true);
                string contents = Get(line, 5 , "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
                if (contents.Contains("<html",comp) || contents.Contains("<meta",comp) || contents.Contains("Filtered some BS",comp) || contents.Contains("#_#_#_#_#_#_#", comp))
                {
                    sw.WriteLine(contents + "\r\n\r\n");
                    sw.WriteLine("================================END================================\r\n\r\n");
                }
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
