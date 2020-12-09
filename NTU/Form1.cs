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


namespace NTU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
