namespace FormsCTF
{
    partial class FTextBox
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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.txtClient2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(12, 136);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(623, 206);
            this.txtMsg.TabIndex = 0;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(12, 12);
            this.txtServer.Multiline = true;
            this.txtServer.Name = "txtServer";
            this.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtServer.Size = new System.Drawing.Size(623, 92);
            this.txtServer.TabIndex = 1;
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(677, 36);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(119, 68);
            this.btnServer.TabIndex = 2;
            this.btnServer.Text = "服务器";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(677, 198);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(119, 68);
            this.btnClient.TabIndex = 3;
            this.btnClient.Text = "客户端";
            this.btnClient.UseVisualStyleBackColor = true;
            // 
            // txtClient2
            // 
            this.txtClient2.Location = new System.Drawing.Point(12, 361);
            this.txtClient2.Multiline = true;
            this.txtClient2.Name = "txtClient2";
            this.txtClient2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClient2.Size = new System.Drawing.Size(623, 206);
            this.txtClient2.TabIndex = 4;
            // 
            // FTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 647);
            this.Controls.Add(this.txtClient2);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtMsg);
            this.Name = "FTextBox";
            this.Text = "FTextBox";
            this.Load += new System.EventHandler(this.FTextBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.TextBox txtClient2;
    }
}