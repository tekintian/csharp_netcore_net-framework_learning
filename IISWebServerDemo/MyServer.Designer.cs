
namespace IISWebServerDemo
{
    partial class MyServer
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
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_basePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.server_status = new System.Windows.Forms.Label();
            this.label_online = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(54, 150);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(433, 281);
            this.textBox_log.TabIndex = 11;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(381, 74);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "开启服务";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(291, 74);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(70, 21);
            this.textBox_port.TabIndex = 9;
            this.textBox_port.Text = "8888";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(81, 73);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(151, 21);
            this.textBox_ip.TabIndex = 7;
            this.textBox_ip.Text = "192.168.2.9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP:";
            // 
            // textBox_basePath
            // 
            this.textBox_basePath.Location = new System.Drawing.Point(162, 28);
            this.textBox_basePath.Name = "textBox_basePath";
            this.textBox_basePath.Size = new System.Drawing.Size(213, 21);
            this.textBox_basePath.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "web服务路径:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // server_status
            // 
            this.server_status.AutoSize = true;
            this.server_status.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.server_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.server_status.Location = new System.Drawing.Point(219, 116);
            this.server_status.Name = "server_status";
            this.server_status.Size = new System.Drawing.Size(0, 14);
            this.server_status.TabIndex = 15;
            // 
            // label_online
            // 
            this.label_online.AutoSize = true;
            this.label_online.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_online.Location = new System.Drawing.Point(238, 462);
            this.label_online.Name = "label_online";
            this.label_online.Size = new System.Drawing.Size(47, 12);
            this.label_online.TabIndex = 16;
            this.label_online.Text = "在线0人";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(460, 471);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 12);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "My Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MyServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 504);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_online);
            this.Controls.Add(this.server_status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_basePath);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label1);
            this.Name = "MyServer";
            this.Text = "C# Web Server  By TekinTian";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_basePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label server_status;
        private System.Windows.Forms.Label label_online;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

