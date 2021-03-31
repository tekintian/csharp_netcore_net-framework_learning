namespace LearnNF
{
    partial class ConvertTools
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_from = new System.Windows.Forms.ComboBox();
            this.btn_transform = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_to = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_from);
            this.groupBox1.Controls.Add(this.btn_transform);
            this.groupBox1.Controls.Add(this.txt_result);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_value);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbox_to);
            this.groupBox1.Location = new System.Drawing.Point(33, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 170);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进制转换";
            // 
            // cbox_from
            // 
            this.cbox_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_from.FormattingEnabled = true;
            this.cbox_from.Items.AddRange(new object[] {
            "十进制",
            "二进制",
            "八进制",
            "十六进制"});
            this.cbox_from.Location = new System.Drawing.Point(176, 32);
            this.cbox_from.Name = "cbox_from";
            this.cbox_from.Size = new System.Drawing.Size(79, 20);
            this.cbox_from.TabIndex = 7;
            // 
            // btn_transform
            // 
            this.btn_transform.Location = new System.Drawing.Point(180, 72);
            this.btn_transform.Name = "btn_transform";
            this.btn_transform.Size = new System.Drawing.Size(75, 23);
            this.btn_transform.TabIndex = 0;
            this.btn_transform.Text = "转换";
            this.btn_transform.UseVisualStyleBackColor = true;
            this.btn_transform.Click += new System.EventHandler(this.btn_transform_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(91, 112);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(164, 21);
            this.txt_result.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入数值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "转换结果：";
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(91, 32);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(79, 21);
            this.txt_value.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "转换为：";
            // 
            // cbox_to
            // 
            this.cbox_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_to.FormattingEnabled = true;
            this.cbox_to.Items.AddRange(new object[] {
            "十进制",
            "二进制",
            "八进制",
            "十六进制"});
            this.cbox_to.Location = new System.Drawing.Point(91, 73);
            this.cbox_to.Name = "cbox_to";
            this.cbox_to.Size = new System.Drawing.Size(79, 20);
            this.cbox_to.TabIndex = 3;
            // 
            // ConvertTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 242);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConvertTools";
            this.Text = "进制转换工具";
            this.Load += new System.EventHandler(this.ConvertTools_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_from;
        private System.Windows.Forms.Button btn_transform;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_to;
    }
}