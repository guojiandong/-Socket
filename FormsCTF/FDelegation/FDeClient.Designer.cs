namespace FormsCTF.FDelegation
{
    partial class FDeClient
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
            this.btnClient = new System.Windows.Forms.Button();
            this.txtClientMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(103, 141);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(131, 38);
            this.btnClient.TabIndex = 4;
            this.btnClient.Text = "客户端发送消息";
            this.btnClient.UseVisualStyleBackColor = true;
            // 
            // txtClientMsg
            // 
            this.txtClientMsg.Location = new System.Drawing.Point(103, 214);
            this.txtClientMsg.Multiline = true;
            this.txtClientMsg.Name = "txtClientMsg";
            this.txtClientMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClientMsg.Size = new System.Drawing.Size(623, 206);
            this.txtClientMsg.TabIndex = 3;
            // 
            // FDeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 560);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.txtClientMsg);
            this.Name = "FDeClient";
            this.Text = "FDeClient";
            this.Shown += new System.EventHandler(this.FDeClient_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.TextBox txtClientMsg;
    }
}