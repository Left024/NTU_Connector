﻿
namespace NTU
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.xyw = new System.Windows.Forms.RadioButton();
            this.cmcc = new System.Windows.Forms.RadioButton();
            this.unicom = new System.Windows.Forms.RadioButton();
            this.telecom = new System.Windows.Forms.RadioButton();
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.runlogin = new System.Windows.Forms.CheckBox();
            this.startlogin = new System.Windows.Forms.CheckBox();
            this.autoreconnect = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xyw
            // 
            this.xyw.AutoSize = true;
            this.xyw.Location = new System.Drawing.Point(30, 24);
            this.xyw.Name = "xyw";
            this.xyw.Size = new System.Drawing.Size(59, 16);
            this.xyw.TabIndex = 0;
            this.xyw.Text = "校园网";
            this.xyw.UseVisualStyleBackColor = true;
            // 
            // cmcc
            // 
            this.cmcc.AutoSize = true;
            this.cmcc.Location = new System.Drawing.Point(109, 24);
            this.cmcc.Name = "cmcc";
            this.cmcc.Size = new System.Drawing.Size(47, 16);
            this.cmcc.TabIndex = 1;
            this.cmcc.Text = "移动";
            this.cmcc.UseVisualStyleBackColor = true;
            // 
            // unicom
            // 
            this.unicom.AutoSize = true;
            this.unicom.Location = new System.Drawing.Point(180, 24);
            this.unicom.Name = "unicom";
            this.unicom.Size = new System.Drawing.Size(47, 16);
            this.unicom.TabIndex = 2;
            this.unicom.Text = "联通";
            this.unicom.UseVisualStyleBackColor = true;
            // 
            // telecom
            // 
            this.telecom.AutoSize = true;
            this.telecom.Location = new System.Drawing.Point(258, 24);
            this.telecom.Name = "telecom";
            this.telecom.Size = new System.Drawing.Size(47, 16);
            this.telecom.TabIndex = 3;
            this.telecom.Text = "电信";
            this.telecom.UseVisualStyleBackColor = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(65, 69);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(41, 12);
            this.username.TabIndex = 4;
            this.username.Text = "用户名";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(65, 108);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(29, 12);
            this.password.TabIndex = 5;
            this.password.Text = "密码";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(152, 66);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(138, 21);
            this.UsernameTextBox.TabIndex = 6;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(152, 105);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(138, 21);
            this.PasswordTextBox.TabIndex = 7;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(81, 147);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 32);
            this.login.TabIndex = 8;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(215, 147);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 32);
            this.logout.TabIndex = 9;
            this.logout.Text = "注销";
            this.logout.UseVisualStyleBackColor = true;
            // 
            // runlogin
            // 
            this.runlogin.AutoSize = true;
            this.runlogin.Location = new System.Drawing.Point(12, 185);
            this.runlogin.Name = "runlogin";
            this.runlogin.Size = new System.Drawing.Size(132, 16);
            this.runlogin.TabIndex = 10;
            this.runlogin.Text = "软件启动时自动连接";
            this.runlogin.UseVisualStyleBackColor = true;
            // 
            // startlogin
            // 
            this.startlogin.AutoSize = true;
            this.startlogin.Location = new System.Drawing.Point(150, 185);
            this.startlogin.Name = "startlogin";
            this.startlogin.Size = new System.Drawing.Size(96, 16);
            this.startlogin.TabIndex = 11;
            this.startlogin.Text = "开机自动连接";
            this.startlogin.UseVisualStyleBackColor = true;
            // 
            // autoreconnect
            // 
            this.autoreconnect.AutoSize = true;
            this.autoreconnect.Location = new System.Drawing.Point(258, 185);
            this.autoreconnect.Name = "autoreconnect";
            this.autoreconnect.Size = new System.Drawing.Size(72, 16);
            this.autoreconnect.TabIndex = 12;
            this.autoreconnect.Text = "自动重连";
            this.autoreconnect.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 209);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(362, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 231);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.autoreconnect);
            this.Controls.Add(this.startlogin);
            this.Controls.Add(this.runlogin);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.login);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.telecom);
            this.Controls.Add(this.unicom);
            this.Controls.Add(this.cmcc);
            this.Controls.Add(this.xyw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "校园网";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton xyw;
        private System.Windows.Forms.RadioButton cmcc;
        private System.Windows.Forms.RadioButton unicom;
        private System.Windows.Forms.RadioButton telecom;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.CheckBox runlogin;
        private System.Windows.Forms.CheckBox startlogin;
        private System.Windows.Forms.CheckBox autoreconnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
