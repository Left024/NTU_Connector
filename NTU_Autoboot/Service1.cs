using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SimpleWifi;
using System.Timers;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace NTU_Autoboot
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        Timer timer1 = new Timer();

        public class CommonData
        {
            public static string yys;
            public static string username;
            public static string password;
            public static string url;
            public static string ip;
            public static string netstatus;
            public static int Bcheck;
        }

        Wifi g_wifi;
        string serviceName = "NTU";
        String[] logintxt = new String[100];

        protected override void OnStart(string[] args)
        {
            StreamReader sr = new StreamReader($"{System.AppDomain.CurrentDomain.BaseDirectory}\\NTU_login.txt", System.Text.Encoding.Default);
            for (int i = 0; i < 10; i++)
            {
                logintxt[i] = sr.ReadLine();
            }
            timer1.Interval = 1000;
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() => {
                Netcheck();
                if (Netcheck() == false)
                {
                    CommonData.netstatus = "-1";
                    denglu();
                }
                else
                {
                    timer1.Enabled = false;
                    using (ServiceController control = new ServiceController(serviceName))
                    {
                        if (control.Status == ServiceControllerStatus.Running)
                        {
                            control.Stop();
                        }
                    }
                }
            });
        }

        protected override void OnStop()
        {
            
        }

        public void denglu()
        {
            try
            {
                g_wifi = new Wifi();
                var t = g_wifi.GetAccessPoints();
                string name = Dns.GetHostName();
                CommonData.ip = GetLocalIP();
                CommonData.yys = logintxt[0];
                CommonData.username = logintxt[1];
                CommonData.password = logintxt[2];
                CommonData.url = "http://210.29.79.141:801/eportal/?c=Portal&a=login&callback=dr1003&login_method=1&user_account=%2C0%2C" + CommonData.username + CommonData.yys + "&user_password=" + CommonData.password + "&wlan_user_ip=" + CommonData.ip + "&wlan_user_ipv6=&wlan_user_mac=000000000000&wlan_ac_ip=&wlan_ac_name=ME60&jsVersion=3.3.2&v=6376";
                foreach (var item in t)
                {
                    if (item.Name == "NTU")
                    {
                        AuthRequest ar = new AuthRequest(item);
                        ar.Password = "";
                        if (item.IsConnected == false)
                        {
                            item.Connect(ar);
                            for (; ; )
                            {
                                if (item.IsConnected == true)
                                {
                                    for (; ; )
                                    {
                                        //string baidu = GetHtmlByUrl("http://baidu.com/1.txt");
                                        if (CommonData.netstatus == "-1")
                                        {
                                            string url = string.Format(CommonData.url);
                                            using (var wc = new WebClient())
                                            {
                                                Encoding enc = Encoding.GetEncoding("UTF-8");
                                                Byte[] pageData = wc.DownloadData(url);
                                                string re = enc.GetString(pageData);
                                            }
                                            break;
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            string url = string.Format(CommonData.url);
                            using (var wc = new WebClient())
                            {
                                Encoding enc = Encoding.GetEncoding("UTF-8");
                                Byte[] pageData = wc.DownloadData(url);
                                string re = enc.GetString(pageData);
                            }
                        }

                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取当前使用的IP
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string result = RunApp("route", "print", true);
            Match m = Regex.Match(result, @"0.0.0.0\s+0.0.0.0\s+(\d+.\d+.\d+.\d+)\s+(\d+.\d+.\d+.\d+)");
            if (m.Success)
            {
                return m.Groups[2].Value;
            }
            else
            {
                try
                {
                    System.Net.Sockets.TcpClient c = new System.Net.Sockets.TcpClient();
                    c.Connect("www.baidu.com", 80);
                    string ip = ((System.Net.IPEndPoint)c.Client.LocalEndPoint).Address.ToString();
                    c.Close();
                    return ip;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取本机主DNS
        /// </summary>
        /// <returns></returns>
        public static string GetPrimaryDNS()
        {
            string result = RunApp("nslookup", "", true);
            Match m = Regex.Match(result, @"\d+\.\d+\.\d+\.\d+");
            if (m.Success)
            {
                return m.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 运行一个控制台程序并返回其输出参数。
        /// </summary>
        /// <param name="filename">程序名</param>
        /// <param name="arguments">输入参数</param>
        /// <returns></returns>
        public static string RunApp(string filename, string arguments, bool recordLog)
        {
            try
            {
                if (recordLog)
                {
                    Trace.WriteLine(filename + " " + arguments);
                }
                Process proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    //string txt = sr.ReadToEnd();
                    //sr.Close();
                    //if (recordLog)
                    //{
                    //    Trace.WriteLine(txt);
                    //}
                    //if (!proc.HasExited)
                    //{
                    //    proc.Kill();
                    //}
                    //上面标记的是原文，下面是我自己调试错误后自行修改的
                    Thread.Sleep(100);           //貌似调用系统的nslookup还未返回数据或者数据未编码完成，程序就已经跳过直接执行
                                                 //txt = sr.ReadToEnd()了，导致返回的数据为空，故睡眠令硬件反应
                    if (!proc.HasExited)         //在无参数调用nslookup后，可以继续输入命令继续操作，如果进程未停止就直接执行
                    {                            //txt = sr.ReadToEnd()程序就在等待输入，而且又无法输入，直接掐住无法继续运行
                        proc.Kill();
                    }
                    string txt = sr.ReadToEnd();
                    sr.Close();
                    if (recordLog)
                        Trace.WriteLine(txt);
                    return txt;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return ex.Message;
            }
        }

        public static bool Netcheck()
        {
            string baidu = GetHtmlByUrl("http://baidu.com/1.txt");

            try
            {
                if (!Regex.IsMatch(baidu, @"baidu"))
                {
                    return false;
                }
                else
                {
                    CommonData.Bcheck = CommonData.Bcheck + 1;
                    if (CommonData.Bcheck == 1000)
                    {
                        CommonData.Bcheck = 2;
                    }
                    return true;
                }
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public static string GetHtmlByUrl(string url)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.UseDefaultCredentials = true;
                    wc.Proxy = new WebProxy();
                    wc.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    wc.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    byte[] bt = wc.DownloadData(url);
                    string txt = System.Text.Encoding.GetEncoding("GB2312").GetString(bt);
                    switch (GetCharset(txt).ToUpper())
                    {
                        case "UTF-8":
                            txt = System.Text.Encoding.UTF8.GetString(bt);
                            break;
                        case "UNICODE":
                            txt = System.Text.Encoding.Unicode.GetString(bt);
                            break;
                        default:
                            break;
                    }
                    return txt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static string GetCharset(string html)
        {
            string charset = "";
            Regex regCharset = new Regex(@"content=[""'].*\s*charset\b\s*=\s*""?(?<charset>[^""']*)", RegexOptions.IgnoreCase);
            if (regCharset.IsMatch(html))
            {
                charset = regCharset.Match(html).Groups["charset"].Value;
            }
            if (charset.Equals(""))
            {
                regCharset = new Regex(@"<\s*meta\s*charset\s*=\s*[""']?(?<charset>[^""']*)", RegexOptions.IgnoreCase);
                if (regCharset.IsMatch(html))
                {
                    charset = regCharset.Match(html).Groups["charset"].Value;
                }
            }
            return charset;
        }
    }


}
