namespace ClientDemo
{
    partial class frmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_open1 = new System.Windows.Forms.Button();
            this.btn_open2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "注册程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 118);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(714, 286);
            this.textBox1.TabIndex = 1;
            // 
            // btn_open1
            // 
            this.btn_open1.Location = new System.Drawing.Point(495, 25);
            this.btn_open1.Name = "btn_open1";
            this.btn_open1.Size = new System.Drawing.Size(93, 36);
            this.btn_open1.TabIndex = 2;
            this.btn_open1.Text = "打开窗体1";
            this.btn_open1.UseVisualStyleBackColor = true;
            this.btn_open1.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_open2
            // 
            this.btn_open2.Location = new System.Drawing.Point(639, 25);
            this.btn_open2.Name = "btn_open2";
            this.btn_open2.Size = new System.Drawing.Size(93, 36);
            this.btn_open2.TabIndex = 2;
            this.btn_open2.Text = "打开窗体2";
            this.btn_open2.UseVisualStyleBackColor = true;
            this.btn_open2.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "运行前用管理员运行注册程序，注册成功后，需要退出程序从新使用普通用户打开";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_open2);
            this.Controls.Add(this.btn_open1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_open1;
        private System.Windows.Forms.Button btn_open2;
        private System.Windows.Forms.Label label1;
    }
}

