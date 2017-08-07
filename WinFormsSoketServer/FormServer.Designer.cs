namespace WinFormsSoketServer
{
    partial class FormServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.btnSendContext = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.SelectClient = new System.Windows.Forms.ComboBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "端号：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(112, 49);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(104, 25);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(323, 47);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(62, 25);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "2000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户端：";
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(36, 103);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContext.Size = new System.Drawing.Size(378, 300);
            this.txtContext.TabIndex = 6;
            // 
            // btnSendContext
            // 
            this.btnSendContext.Location = new System.Drawing.Point(692, 428);
            this.btnSendContext.Name = "btnSendContext";
            this.btnSendContext.Size = new System.Drawing.Size(125, 37);
            this.btnSendContext.TabIndex = 7;
            this.btnSendContext.Text = "发生文本信息";
            this.btnSendContext.UseVisualStyleBackColor = true;
            this.btnSendContext.Click += new System.EventHandler(this.btnSendContext_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(409, 41);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(112, 32);
            this.btnListen.TabIndex = 8;
            this.btnListen.Text = "开始监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.AllowDrop = true;
            this.txtSendMsg.Location = new System.Drawing.Point(439, 103);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(378, 300);
            this.txtSendMsg.TabIndex = 9;
            // 
            // SelectClient
            // 
            this.SelectClient.FormattingEnabled = true;
            this.SelectClient.Location = new System.Drawing.Point(648, 44);
            this.SelectClient.Name = "SelectClient";
            this.SelectClient.Size = new System.Drawing.Size(173, 23);
            this.SelectClient.TabIndex = 10;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(544, 428);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(125, 37);
            this.btnSendFile.TabIndex = 11;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 436);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 25);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "127.0.0.1";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(372, 428);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(125, 37);
            this.btnSelectFile.TabIndex = 13;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 513);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.SelectClient);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.btnSendContext);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormServer";
            this.Text = "服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Button btnSendContext;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.ComboBox SelectClient;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSelectFile;
    }
}

