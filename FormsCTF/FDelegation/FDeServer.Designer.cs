namespace FormsCTF.FDelegation
{
    partial class FDeServer
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
            this.txtServerMsg = new System.Windows.Forms.TextBox();
            this.btnServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerMsg
            // 
            this.txtServerMsg.Location = new System.Drawing.Point(38, 108);
            this.txtServerMsg.Multiline = true;
            this.txtServerMsg.Name = "txtServerMsg";
            this.txtServerMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtServerMsg.Size = new System.Drawing.Size(623, 206);
            this.txtServerMsg.TabIndex = 1;
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(38, 35);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(131, 38);
            this.btnServer.TabIndex = 2;
            this.btnServer.Text = "服务器发送消息";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // FDeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 528);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.txtServerMsg);
            this.Name = "FDeServer";
            this.Text = "FDeServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerMsg;
        private System.Windows.Forms.Button btnServer;
    }
}