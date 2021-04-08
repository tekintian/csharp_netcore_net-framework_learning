
namespace ThreadFrmDemo
{
    partial class MainForm
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
            this.btn_loop = new System.Windows.Forms.Button();
            this.btn_process_info = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_loop
            // 
            this.btn_loop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_loop.Location = new System.Drawing.Point(92, 55);
            this.btn_loop.Name = "btn_loop";
            this.btn_loop.Size = new System.Drawing.Size(75, 23);
            this.btn_loop.TabIndex = 0;
            this.btn_loop.Text = "开启循环";
            this.btn_loop.UseVisualStyleBackColor = true;
            this.btn_loop.Click += new System.EventHandler(this.btn_loop_Click);
            // 
            // btn_process_info
            // 
            this.btn_process_info.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_process_info.Location = new System.Drawing.Point(486, 55);
            this.btn_process_info.Name = "btn_process_info";
            this.btn_process_info.Size = new System.Drawing.Size(156, 23);
            this.btn_process_info.TabIndex = 1;
            this.btn_process_info.Text = "显示当前系统所有进程";
            this.btn_process_info.UseVisualStyleBackColor = true;
            this.btn_process_info.Click += new System.EventHandler(this.btn_process_info_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.Location = new System.Drawing.Point(465, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开记事本";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_stop.Location = new System.Drawing.Point(223, 48);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(86, 30);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "停止循环";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_process_info);
            this.Controls.Add(this.btn_loop);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_loop;
        private System.Windows.Forms.Button btn_process_info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_stop;
    }
}

