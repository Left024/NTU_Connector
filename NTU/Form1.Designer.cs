
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无线连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.有线连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xyw
            // 
            this.xyw.AutoSize = true;
            this.xyw.Location = new System.Drawing.Point(35, 28);
            this.xyw.Name = "xyw";
            this.xyw.Size = new System.Drawing.Size(59, 16);
            this.xyw.TabIndex = 0;
            this.xyw.Text = "校园网";
            this.xyw.UseVisualStyleBackColor = true;
            this.xyw.CheckedChanged += new System.EventHandler(this.xyw_CheckedChanged);
            // 
            // cmcc
            // 
            this.cmcc.AutoSize = true;
            this.cmcc.Location = new System.Drawing.Point(109, 28);
            this.cmcc.Name = "cmcc";
            this.cmcc.Size = new System.Drawing.Size(47, 16);
            this.cmcc.TabIndex = 1;
            this.cmcc.Text = "移动";
            this.cmcc.UseVisualStyleBackColor = true;
            this.cmcc.CheckedChanged += new System.EventHandler(this.cmcc_CheckedChanged);
            // 
            // unicom
            // 
            this.unicom.AutoSize = true;
            this.unicom.Location = new System.Drawing.Point(180, 28);
            this.unicom.Name = "unicom";
            this.unicom.Size = new System.Drawing.Size(47, 16);
            this.unicom.TabIndex = 2;
            this.unicom.Text = "联通";
            this.unicom.UseVisualStyleBackColor = true;
            this.unicom.CheckedChanged += new System.EventHandler(this.unicom_CheckedChanged);
            // 
            // telecom
            // 
            this.telecom.AutoSize = true;
            this.telecom.Location = new System.Drawing.Point(258, 28);
            this.telecom.Name = "telecom";
            this.telecom.Size = new System.Drawing.Size(47, 16);
            this.telecom.TabIndex = 3;
            this.telecom.Text = "电信";
            this.telecom.UseVisualStyleBackColor = true;
            this.telecom.CheckedChanged += new System.EventHandler(this.telecom_CheckedChanged);
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
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(215, 147);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 32);
            this.logout.TabIndex = 9;
            this.logout.Text = "注销";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
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
            this.runlogin.Click += new System.EventHandler(this.runlogin_Click);
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
            this.startlogin.Click += new System.EventHandler(this.startlogin_Click);
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
            this.autoreconnect.Click += new System.EventHandler(this.autoreconnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "NTU";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.CheckOnClick = true;
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem.Text = "连接通知";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.CheckOnClick = true;
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem2.Text = "自启高优先级";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.自启高优先级ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "关闭软件";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接方式ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(362, 25);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 连接方式ToolStripMenuItem
            // 
            this.连接方式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.无线连接ToolStripMenuItem,
            this.有线连接ToolStripMenuItem});
            this.连接方式ToolStripMenuItem.Name = "连接方式ToolStripMenuItem";
            this.连接方式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.连接方式ToolStripMenuItem.Text = "连接方式";
            // 
            // 无线连接ToolStripMenuItem
            // 
            this.无线连接ToolStripMenuItem.Name = "无线连接ToolStripMenuItem";
            this.无线连接ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.无线连接ToolStripMenuItem.Text = "无线连接";
            this.无线连接ToolStripMenuItem.Click += new System.EventHandler(this.无线连接ToolStripMenuItem_Click);
            // 
            // 有线连接ToolStripMenuItem
            // 
            this.有线连接ToolStripMenuItem.Name = "有线连接ToolStripMenuItem";
            this.有线连接ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.有线连接ToolStripMenuItem.Text = "有线连接";
            this.有线连接ToolStripMenuItem.Click += new System.EventHandler(this.有线连接ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 231);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
            this.MainMenuStrip = this.menuStrip1;
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 连接方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无线连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 有线连接ToolStripMenuItem;
    }
}

