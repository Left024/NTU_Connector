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


namespace NTU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //test
        }

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
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void xyw_CheckedChanged(object sender, EventArgs e)
        {
            if (xyw.Checked == true)
            {
                cmcc.Checked = false;
                unicom.Checked = false;
                telecom.Checked = false;
            }
        }

        private void cmcc_CheckedChanged(object sender, EventArgs e)
        {
            if (cmcc.Checked == true)
            {
                xyw.Checked = false;
                unicom.Checked = false;
                telecom.Checked = false;
            }
        }

        private void unicom_CheckedChanged(object sender, EventArgs e)
        {
            if (unicom.Checked == true)
            {
                xyw.Checked = false;
                cmcc.Checked = false;
                telecom.Checked = false;
            }
        }

        private void telecom_CheckedChanged(object sender, EventArgs e)
        {
            if (telecom.Checked == true)
            {
                xyw.Checked = false;
                unicom.Checked = false;
                cmcc.Checked = false;
            }
        }

        

        private void runlogin_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
            }
        }

        private void startlogin_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("请填写用户名或者密码！");
                startlogin.Checked = false;
                runlogin.Checked = false;
            }
        }
    }
}
