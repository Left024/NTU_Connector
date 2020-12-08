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
            UsernameTextBox.Text = ConfigurationManager.AppSettings["username"].ToString();

            String xyw = ConfigurationManager.AppSettings["xyw"].ToString();

            if (xyw == "true")
            { 
                
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            string file = System.Windows.Forms.Application.ExecutablePath;

            Configuration config = ConfigurationManager.OpenExeConfiguration(file);

            config.AppSettings.Settings["username"].Value = UsernameTextBox.Text.Trim();

            config.AppSettings.Settings["xyw"].Value = xyw.Checked.ToString();

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
