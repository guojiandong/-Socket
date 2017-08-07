namespace FormsServer
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
            this.SelectClient = new System.Windows.Forms.ComboBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.btnSendContext = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnZhenDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectClient
            // 
            this.SelectClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectClient.FormattingEnabled = true;
            this.SelectClient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SelectClient.IntegralHeight = false;
            this.SelectClient.Location = new System.Drawing.Point(649, 24);
            this.SelectClient.Name = "SelectClient";
            this.SelectClient.Size = new System.Drawing.Size(173, 23);
            this.SelectClient.TabIndex = 17;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(410, 21);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(112, 32);
            this.btnListen.TabIndex = 16;
            this.btnListen.Text = "开始监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "客户端：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(324, 27);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(62, 25);
            this.txtPort.TabIndex = 14;
            this.txtPort.Text = "2000";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(113, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(104, 25);
            this.txtIP.TabIndex = 13;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "端号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "服务器IP：";
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(307, 88);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContext.Size = new System.Drawing.Size(515, 157);
            this.txtContext.TabIndex = 18;
            // 
            // btnSendContext
            // 
            this.btnSendContext.Location = new System.Drawing.Point(697, 474);
            this.btnSendContext.Name = "btnSendContext";
            this.btnSendContext.Size = new System.Drawing.Size(125, 37);
            this.btnSendContext.TabIndex = 19;
            this.btnSendContext.Text = "发送文本信息";
            this.btnSendContext.UseVisualStyleBackColor = true;
            this.btnSendContext.Click += new System.EventHandler(this.btnSendContext_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(531, 474);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(125, 37);
            this.btnSendFile.TabIndex = 20;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(348, 474);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(125, 37);
            this.btnSelectFile.TabIndex = 21;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(37, 474);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(277, 37);
            this.txtFile.TabIndex = 22;
            // 
            // listBoxUser
            // 
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.ItemHeight = 15;
            this.listBoxUser.Location = new System.Drawing.Point(37, 88);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(237, 349);
            this.listBoxUser.TabIndex = 23;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(307, 266);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(515, 157);
            this.txtSendMsg.TabIndex = 24;
            // 
            // btnZhenDong
            // 
            this.btnZhenDong.Location = new System.Drawing.Point(697, 517);
            this.btnZhenDong.Name = "btnZhenDong";
            this.btnZhenDong.Size = new System.Drawing.Size(125, 37);
            this.btnZhenDong.TabIndex = 25;
            this.btnZhenDong.Text = "震动";
            this.btnZhenDong.UseVisualStyleBackColor = true;
            this.btnZhenDong.Click += new System.EventHandler(this.btnZhenDong_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 555);
            this.Controls.Add(this.btnZhenDong);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.listBoxUser);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSendContext);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.SelectClient);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormServer";
            this.Text = "服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectClient;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Button btnSendContext;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button btnZhenDong;
    }
}

