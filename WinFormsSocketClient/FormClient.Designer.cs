namespace WinFormsSocketClient
{
    partial class FormClient
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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.btnSendContext = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(423, 48);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 25);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "2000";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(140, 50);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(194, 25);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "端号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器IP：";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(604, 49);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "连接服务器";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(37, 106);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContext.Size = new System.Drawing.Size(364, 300);
            this.txtContext.TabIndex = 9;
            // 
            // btnSendContext
            // 
            this.btnSendContext.Location = new System.Drawing.Point(662, 426);
            this.btnSendContext.Name = "btnSendContext";
            this.btnSendContext.Size = new System.Drawing.Size(113, 23);
            this.btnSendContext.TabIndex = 10;
            this.btnSendContext.Text = "发生文本信息";
            this.btnSendContext.UseVisualStyleBackColor = true;
            this.btnSendContext.Click += new System.EventHandler(this.btnSendContext_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.AllowDrop = true;
            this.txtSendMsg.Location = new System.Drawing.Point(434, 106);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(378, 300);
            this.txtSendMsg.TabIndex = 11;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 513);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.btnSendContext);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormClient";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Button btnSendContext;
        private System.Windows.Forms.TextBox txtSendMsg;
    }
}

