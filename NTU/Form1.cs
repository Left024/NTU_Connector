using System;
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

namespace NTU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class CommonData
        {
            public static string yys;
            public static string username;
            public static string password;
            public static string url;
            public static string ip;
        }

        Wifi g_wifi;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            
            //校园网选项框读取
            String xywStr = ConfigurationManager.AppSettings["xyw"].ToString();
            if (xywStr == "True")
            {
                xyw.Checked = true;
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
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        //校园网选项框
        private void xyw_CheckedChanged(object sender, EventArgs e)
        {
            if (xyw.Checked == true)
            {
                cmcc.Checked = false;
                unicom.Checked = false;
                telecom.Checked = false;
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
            
            g_wifi = new Wifi();
            var t = g_wifi.GetAccessPoints();
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
                autoreconnect.Checked = false;
            }
            else
            {
                string name = Dns.GetHostName();
                IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
                CommonData.ip = ipadrlist[1].ToString();
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
                CommonData.url = "http://210.29.79.141:801/eportal/?c=Portal&a=login&callback=dr1003&login_method=1&user_account=%2C0%2C" + CommonData.username + CommonData.yys + "&user_password=" + CommonData.password + "&wlan_user_ip=" + CommonData.ip + "&wlan_user_ipv6=&wlan_user_mac=000000000000&wlan_ac_ip=&wlan_ac_name=ME60&jsVersion=3.3.2&v=5722";
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
                                    string url = string.Format(CommonData.url);
                                    using (var wc = new WebClient())
                                    {
                                        Encoding enc = Encoding.GetEncoding("UTF-8");
                                        Byte[] pageData = wc.DownloadData(url);
                                        string re = enc.GetString(pageData);
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
        }

        private void logout_Click(object sender, EventArgs e)
        {
            
        }
    }
}
