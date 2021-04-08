
namespace ChatDemo
{
    partial class ClientSocket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send = new System.Windows.Forms.Button();
            this.textBox_msg = new System.Windows.Forms.TextBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(493, 249);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(100, 55);
            this.btn_send.TabIndex = 23;
            this.btn_send.Text = "发送消息";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // textBox_msg
            // 
            this.textBox_msg.Location = new System.Drawing.Point(438, 142);
            this.textBox_msg.Multiline = true;
            this.textBox_msg.Name = "textBox_msg";
            this.textBox_msg.Size = new System.Drawing.Size(232, 81);
            this.textBox_msg.TabIndex = 22;
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(30, 103);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(364, 339);
            this.textBox_log.TabIndex = 21;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(372, 36);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 20;
            this.btn_start.Text = "连接服务端";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(267, 36);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(70, 21);
            this.textBox_port.TabIndex = 19;
            this.textBox_port.Text = "8888";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(57, 35);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(151, 21);
            this.textBox_ip.TabIndex = 17;
            this.textBox_ip.Text = "192.168.2.9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "IP:";
            // 
            // ClientSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 541);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.textBox_msg);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label1);
            this.Name = "ClientSocket";
            this.Text = "ClientSocket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox textBox_msg;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
    }
}