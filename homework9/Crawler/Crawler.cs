using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;//计时

namespace Crawler {
    class Crawler {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args) {
            
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            //string startUrl = "http://www.baidu.com/";
            //if (args[0].Length >= 1) {
            //  startUrl = args[0];
            // }
            myCrawler.urls.Add(startUrl, false);
            new Thread(myCrawler.ParallelCrawl).Start();//start to crawl

            }

        private void Crawl() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("start to crawl....");
            while (true) {
                string current = null;
                foreach (string url in urls.Keys) {
                    if ((bool)urls[url]) {
                        continue;
                    }
                    current = url;
                }
                if (current == null || count > 15) {
                    break;
                }
                Console.WriteLine("Is crawling" + current + "||html!");
                string html = Download(current);
                urls[current] = true;
                count++;

                Parse(html);
            }
            

            Console.WriteLine("crawl over!!");

            stopwatch.Stop();
            Console.WriteLine("Parallel run " + stopwatch.ElapsedMilliseconds + " ms.");

        }

        private void ParallelCrawl() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("start to crawl....");
            while (true) {
                List<string> current = new List<string>();
                
                foreach (string url in urls.Keys) {
                    if ((bool)urls[url]) {
                        continue;
                    }
                    current.Add(url);
                    //Console.WriteLine("Is crawling" + current + "||html!");
                    //Task task1 = new Task(() => Download1(current[current.Count-1]));
                    //task1.Start();
                    //urls[url] = true;
                    
                }
                if (current == null || count > 15) {
                    break;
                }
                Parallel.ForEach(current, url => {
                    Console.WriteLine("Is crawling" + url + "||html!");
                    Download1(url);
                    urls[url] = true;
                    
                });
                //Console.WriteLine("Is crawling" + current + "||html!");
                //Task task1 = new Task(() => Download1(current));
                //task1.Start();
                //urls[current] = true;
                //count++;
                //Task.WaitAll();
            }
            

            Console.WriteLine("crawl over!!");

            stopwatch.Stop();
            Console.WriteLine("Parallel run " + stopwatch.ElapsedMilliseconds + " ms.");

        }

        public void Download1(string url) {
            string html = "";
            try {
                lock (this) {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    html = webClient.DownloadString(url);
                    string fileName = count.ToString();
                    File.WriteAllText(@".\" + fileName + ".txt", html, Encoding.UTF8);
                    urls[url] = true;
                    count++;
                }
                
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                html = "";
            }
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches) {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim
                    ('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) {
                    continue;
                }
                if (urls[strRef] == null) {
                    urls[strRef] = false;
                }
            }
        }
        public string Download(string url) {
            try {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(@".\" + fileName + ".txt", html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html) {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches) {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim
                    ('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) {
                    continue;
                }
                if (urls[strRef] == null) {
                    urls[strRef] = false;
                }
            }
        }
    }
}
