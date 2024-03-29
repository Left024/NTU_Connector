﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using SimpleWifi;
using System.Net;
using Thread = System.Threading.Thread;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;
using System.Security.AccessControl;

namespace NTU
{
    public partial class Form1 : Form
    {
        BackgroundWorker bgworker = new BackgroundWorker();
        String arg = null;
        public Form1(String[] args)
        {
            if (args.Length > 0)
            {
                //获取启动时的命令行参数  
                arg = args[0];
            }
            InitializeComponent();

            bgworker.WorkerReportsProgress = true;
            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += bgworker_DoWork;
            //bgworker.ProgressChanged += bgworker_ProgressChanged;
            //bgworker.RunWorkerCompleted += bgworker_RunWorkerCompleted;
        }

        string serviceFilePath = $"{Application.StartupPath}\\NTU_Autoboot.exe";
        string serviceName = "NTU";
        //string loginTXT = $"{Application.StartupPath}\\NTU_login.txt";

        public class CommonData
        {
            public static string yys;
            public static string username;
            public static string password;
            public static string url;
            public static string ip;
            public static string logout;
            public static string netstatus;
            public static int Bcheck;
            public static bool isW;
        }

        Wifi g_wifi;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (arg != null)
            {
                //arg不为空,说明有启动参数,是从注册表启动的,则直接最小化到托盘  
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            /*notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(20000, "NTU", ""+GetLocalIP(), ToolTipIcon.Info);*/
            //连接类型读取
            String isWifi = ConfigurationManager.AppSettings["iswifi"].ToString();
            if (isWifi == "True")
            {
                无线连接ToolStripMenuItem.Checked = true;
                有线连接ToolStripMenuItem.Checked = false;
                CommonData.isW = true;
            }
            else 
            {
                无线连接ToolStripMenuItem.Checked = false;
                有线连接ToolStripMenuItem.Checked = true;
                CommonData.isW = false;
            }
            //校园网选项框读取
            String xywStr = ConfigurationManager.AppSettings["xyw"].ToString();
            if (xywStr == "True")
            {
                xyw.Checked = true;
                CommonData.yys = "";
            }
            else
            { 
                xyw.Checked = false;
            }
            //移动选项框读取
            String cmccStr = ConfigurationManager.AppSettings["cmcc"].ToString();
            if (cmccStr == "True")
            {
                cmcc.Checked = true;
                CommonData.yys = "%40cmcc";
            }
            else
            {
                cmcc.Checked = false;
            }
            //联通选项框读取
            String unicomStr = ConfigurationManager.AppSettings["unicom"].ToString();
            if (unicomStr == "True")
            {
                unicom.Checked = true;
                CommonData.yys = "%40unicom";
            }
            else
            {
                unicom.Checked = false;
            }
            //电信选项框读取
            String telecomStr = ConfigurationManager.AppSettings["telecom"].ToString();
            if (telecomStr == "True")
            {
                telecom.Checked = true;
                CommonData.yys = "%40telecom";
            }
            else
            {
                telecom.Checked = false;
            }
            //用户名读取
            UsernameTextBox.Text = ConfigurationManager.AppSettings["username"].ToString();
            //密码读取
            PasswordTextBox.Text = ConfigurationManager.AppSettings["password"].ToString();
            //软件启动连接读取
            String runStr= ConfigurationManager.AppSettings["runlogin"].ToString();
            if (runStr == "True")
            {
                runlogin.Checked = true;
            }
            else
            {
                runlogin.Checked = false;
            }
            //开机自动连接读取
            String startStr = ConfigurationManager.AppSettings["startlogin"].ToString();
            if (startStr == "True")
            {
                startlogin.Checked = true;
            }
            else
            {
                startlogin.Checked = false;
            }
            //自动重连读取
            String autoStr = ConfigurationManager.AppSettings["autoreconnect"].ToString();
            if (autoStr == "True")
            {
                autoreconnect.Checked = true;
            }
            else
            {
                autoreconnect.Checked = false;
            }
            //连接通知读取
            String notifycheck = ConfigurationManager.AppSettings["connectnotify"].ToString();
            if (notifycheck == "True")
            {
                ToolStripMenuItem.Checked = true;
            }
            else
            {
                ToolStripMenuItem.Checked = false;
            }
            bgworker.RunWorkerAsync();
            //软件启动时连接功能
            if (runlogin.Checked == true)
            {
                denglu();
            }
            if (this.IsServiceExisted("NTU"))
            {
                ToolStripMenuItem2.Checked = true;
            }
            else
            {
                ToolStripMenuItem2.Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            //System.Environment.Exit(0);
            //System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            //tt.Kill();//直接杀死与本程序相关的所有进程，有可能会导致数据丢失，但是不会抛出异常。  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            savesettings();
            System.Environment.Exit(0);
            System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            tt.Kill();//直接杀死与本程序相关的所有进程，有可能会导致数据丢失，但是不会抛出异常。  
        }

        //校园网选项框
        private void xyw_CheckedChanged(object sender, EventArgs e)
        {
            if (xyw.Checked == true)
            {
                cmcc.Checked = false;
                unicom.Checked = false;
                telecom.Checked = false;
                CommonData.yys = "";
            }
        }

        //移动选项框
        private void cmcc_CheckedChanged(object sender, EventArgs e)
        {
            if (cmcc.Checked == true)
            {
                xyw.Checked = false;
                unicom.Checked = false;
                telecom.Checked = false;
                CommonData.yys = "%40cmcc";
            }
        }

        //联通选项框
        private void unicom_CheckedChanged(object sender, EventArgs e)
        {
            if (unicom.Checked == true)
            {
                xyw.Checked = false;
                cmcc.Checked = false;
                telecom.Checked = false;
                CommonData.yys = "%40unicom";
            }
        }

        //电信选项框
        private void telecom_CheckedChanged(object sender, EventArgs e)
        {
            if (telecom.Checked == true)
            {
                xyw.Checked = false;
                unicom.Checked = false;
                cmcc.Checked = false;
                CommonData.yys = "%40telecom";
            }
        }

        
        //软件启动选项框
        private void runlogin_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
                autoreconnect.Checked = false;
            }
        }

        //开机启动选项框
        private void startlogin_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
            }
            if (startlogin.Checked == true)
            {
                AutoStart();
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey run = key.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                run.SetValue("NTU", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + " -s");
                

            }
            else
            {
                CancelAutoStart();
                RegistryKey key = Registry.CurrentUser;

                RegistryKey software = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                try
                {
                    software.DeleteValue("NTU");
                }
                catch
                { }
            }
            
        }

        //自动重连选项框
        private void autoreconnect_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
                autoreconnect.Checked = false;
            }
        }

        //登录按钮
        private void login_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
                autoreconnect.Checked = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                denglu();
                savesettings();
            }            
        }

        private void logout_Click(object sender, EventArgs e)
        {
            string url = string.Format("http://210.29.79.141:801/eportal/?c=Portal&a=logout&callback=dr1003&login_method=1&user_account=drcom&user_password=123&ac_logout=0&register_mode=1&wlan_user_ip="+CommonData.ip+"&wlan_user_ipv6=&wlan_vlan_id=0&wlan_user_mac=000000000000&wlan_ac_ip=&wlan_ac_name=ME60&jsVersion=3.3.2&v=4080");
            using (var wc = new WebClient())
            {
                Encoding enc = Encoding.GetEncoding("UTF-8");
                Byte[] pageData = wc.DownloadData(url);
                string re = enc.GetString(pageData);
            }
            CommonData.logout = "1";
            autoreconnect.Checked = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (; ; )
            {
                Thread.Sleep(1000);
                if (autoreconnect.Checked == true && CommonData.isW)
                {
                    g_wifi = new Wifi();
                    var t = g_wifi.GetAccessPoints();
                    foreach (var item in t)
                    {
                        if (item.IsConnected == false)
                        {
                            if (item.Name == "NTU")
                            {
                                AuthRequest ar = new AuthRequest(item);
                                ar.Password = "";
                                item.Connect(ar);
                            }
                        }
                    }
                }
                if (Netcheck()==false)
                {
                    toolStripStatusLabel1.Text = "未连接";
                    CommonData.netstatus = "-1";
                    CommonData.Bcheck = 0;
                    if (autoreconnect.Checked == true)
                    {
                        denglu();
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "已连接";
                    CommonData.ip = GetLocalIP();
                    toolStripStatusLabel2.Text = CommonData.ip;
                    if (ToolStripMenuItem.Checked==true)
                    {
                        if (CommonData.Bcheck == 1)
                        {
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(20000, "NTU", "已连接至校园网",
                                ToolTipIcon.Info);
                        }
                    }
                }
                
                
                
            }
            
        }

        //https://www.jb51.net/article/53657.htm
        public static string GetHtmlByUrl(string url)
        {
            /*using (WebClient wc = new WebClient())
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
            }*/
            string urll = string.Format(url);
            using (var wc = new WebClient())
            {
                Encoding enc = Encoding.GetEncoding("UTF-8");
                Byte[] pageData = wc.DownloadData(url);
                string re = enc.GetString(pageData);
                return re;
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

        public static bool Netcheck()
        {
            string baidu = GetHtmlByUrl("http://210.29.79.141/drcom/chkstatus?callback=dr1002&v=4857");

            try
            {
                if (!Regex.IsMatch(baidu, @CommonData.username))
                {
                    return false;
                }
                else
                {
                    CommonData.Bcheck = CommonData.Bcheck +1;
                    if (CommonData.Bcheck == 1000)
                    {
                        CommonData.Bcheck = 2;
                    }
                    return true;
                }
            }
            catch(ArgumentNullException)
            {
                return false;
            }
        }

        //https://www.cnblogs.com/lijianda/p/6604651.html
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

        public void denglu()
        {
            try
            {
                CommonData.ip = GetLocalIP();
                if (xyw.Checked == true)
                {
                    CommonData.yys = "";
                }
                else if (cmcc.Checked == true)
                {
                    CommonData.yys = "%40cmcc";
                }
                else if (unicom.Checked == true)
                {
                    CommonData.yys = "%40unicom";
                }
                else if (telecom.Checked == true)
                {
                    CommonData.yys = "%40telecom";
                }
                CommonData.username = UsernameTextBox.Text;
                CommonData.password = PasswordTextBox.Text;
                CommonData.url = "http://210.29.79.141:801/eportal/?c=Portal&a=login&callback=dr1003&login_method=1&user_account=%2C0%2C" + CommonData.username + CommonData.yys + "&user_password=" + CommonData.password + "&wlan_user_ip=" + CommonData.ip + "&wlan_user_mac=000000000000&wlan_ac_ip=&wlan_ac_name=&jsVersion=3.3.2&v=7723";
                if (CommonData.isW)
                {
                    g_wifi = new Wifi();
                    var t = g_wifi.GetAccessPoints();
                    string name = Dns.GetHostName();
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
                else 
                {
                    /*while (true) 
                    {
                        if (CommonData.netstatus == "-1")
                        {
                            string url = string.Format(CommonData.url);
                            using (var wc = new WebClient())
                            {
                                Encoding enc = Encoding.GetEncoding("UTF-8");
                                Byte[] pageData = wc.DownloadData(url);
                                string re = enc.GetString(pageData);
                            }
                        }
                        else 
                        {
                            break;
                        }
                    }*/

                    string url = string.Format(CommonData.url);
                    using (var wc = new WebClient())
                    {
                        Encoding enc = Encoding.GetEncoding("UTF-8");
                        Byte[] pageData = wc.DownloadData(url);
                        string re = enc.GetString(pageData);
                    }
                }
                
            }
            catch
            {
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*if (this.Visible)
            {
                this.Hide();
            }
            else
            {*/
            //this.Show();
            //}
            ShowForm();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            savesettings();
            System.Environment.Exit(0);
            System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            tt.Kill();//直接杀死与本程序相关的所有进程，有可能会导致数据丢失，但是不会抛出异常。
            notifyIcon1.Visible = false;   //设置图标不可见
            this.Close();                  //关闭窗体
            this.Dispose();                //释放资源
            Application.Exit();            //关闭应用程序窗体
        }

        private void 自启高优先级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem2.Checked == true)
            {
                if (startlogin.Checked == true)
                {
                    if (UsernameTextBox.Text == "")
                    {
                        MessageBox.Show("用户名未填写", "提示");
                        ToolStripMenuItem2.Checked = false;
                    }
                    else
                    {
                        if (PasswordTextBox.Text == "")
                        {
                            MessageBox.Show("密码未填写", "提示");
                            ToolStripMenuItem2.Checked = false;
                        }
                        else
                        {
                            System.IO.File.Delete($"{Application.StartupPath}\\NTU_login.txt");
                            WriteFile(CommonData.yys);
                            WriteFile(UsernameTextBox.Text);
                            WriteFile(PasswordTextBox.Text);
                            //安装服务
                            if (this.IsServiceExisted(serviceName)) this.UninstallService(serviceName);
                            this.InstallService(serviceFilePath);
                            //启动服务
                            //if (this.IsServiceExisted(serviceName)) this.ServiceStart(serviceName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("开机自启未勾选", "提示");
                    ToolStripMenuItem2.Checked = false;
                }
            }
            else
            {
                //停止服务
                if (this.IsServiceExisted(serviceName)) this.ServiceStop(serviceName);
                //卸载服务
                if (this.IsServiceExisted(serviceName))
                {
                    this.ServiceStop(serviceName);
                    this.UninstallService(serviceFilePath);
                }
                
            }
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //安装服务
        private void InstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        private void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }

        //启动服务
        private void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                }
            }
        }

        //停止服务
        private void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }

        public static void WriteFile(String str)
        {
            StreamWriter sw = new StreamWriter($"{Application.StartupPath}\\NTU_login.txt", true, System.Text.Encoding.Default);
            sw.WriteLine(str);
            sw.Close();
        }

        //https://blog.csdn.net/m0_37670686/article/details/108356836
        private void AutoStart()
        {
            var starupPath = GetType().Assembly.Location;
            try
            {
                var fileName = starupPath + " -s";
                var shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                //打开子键节点
                var myReg = Registry.LocalMachine.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree,
                    RegistryRights.FullControl);
                if (myReg == null)
                {
                    //如果子键节点不存在，则创建之
                    myReg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                if (myReg != null && myReg.GetValue(shortFileName) != null)
                {
                    //在注册表中设置自启动程序
                    myReg.DeleteValue(shortFileName);
                    myReg.SetValue(shortFileName, fileName);
                }

                else if (myReg != null && myReg.GetValue(shortFileName) == null)
                {
                    myReg.SetValue(shortFileName, fileName);

                }
            }
            catch
            {
                return;
            }
        }

        private void CancelAutoStart()
        {
            var starupPath = GetType().Assembly.Location;
            try
            {
                var fileName = starupPath + " -s";
                var shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                //打开子键节点
                var myReg = Registry.LocalMachine.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree,
                    RegistryRights.FullControl);
                if (myReg == null)
                {
                    //如果子键节点不存在，则创建之
                    myReg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                if (myReg != null && myReg.GetValue(shortFileName) != null)
                {
                    //在注册表中设置自启动程序
                    myReg.DeleteValue(shortFileName);
                    // myReg.SetValue(shortFileName, fileName);
                }

                else if (myReg != null && myReg.GetValue(shortFileName) == null)
                {
                    // myReg.SetValue(shortFileName, fileName);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public void savesettings()
        {
            string file = System.Windows.Forms.Application.ExecutablePath;

            Configuration config = ConfigurationManager.OpenExeConfiguration(file);

            //校园网选项框记录
            config.AppSettings.Settings["xyw"].Value = xyw.Checked.ToString().Trim();
            //移动选项框记录
            config.AppSettings.Settings["cmcc"].Value = cmcc.Checked.ToString().Trim();
            //联通选项框记录
            config.AppSettings.Settings["unicom"].Value = unicom.Checked.ToString().Trim();
            //电信选项框记录
            config.AppSettings.Settings["telecom"].Value = telecom.Checked.ToString().Trim();
            //用户名记录
            config.AppSettings.Settings["username"].Value = UsernameTextBox.Text.Trim();
            //密码记录
            config.AppSettings.Settings["password"].Value = PasswordTextBox.Text.Trim();
            //软件启动选项记录
            config.AppSettings.Settings["runlogin"].Value = runlogin.Checked.ToString().Trim();
            //启动连接选项记录
            config.AppSettings.Settings["startlogin"].Value = startlogin.Checked.ToString().Trim();
            //自动重连选项记录
            config.AppSettings.Settings["autoreconnect"].Value = autoreconnect.Checked.ToString().Trim();
            //连接通知选项记录
            config.AppSettings.Settings["connectnotify"].Value = ToolStripMenuItem.Checked.ToString().Trim();
            //连接类型记录
            config.AppSettings.Settings["iswifi"].Value = 无线连接ToolStripMenuItem.Checked.ToString().Trim();
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.ShowInTaskbar = true;
            SetVisibleCore(true);
        }

        private void 无线连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            无线连接ToolStripMenuItem.Checked = true;
            有线连接ToolStripMenuItem.Checked = false;
            CommonData.isW = true;
        }

        private void 有线连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            无线连接ToolStripMenuItem.Checked = false;
            有线连接ToolStripMenuItem.Checked = true;
            CommonData.isW = false;
        }
    }
}
