namespace FormsCTF
{
    partial class frmMain
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
            this.txtContext = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tvDir = new System.Windows.Forms.TreeView();
            this.btnStartDir = new System.Windows.Forms.Button();
            this.btnStopDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(622, 95);
            this.txtContext.Name = "txtContext";
            this.txtContext.Size = new System.Drawing.Size(296, 25);
            this.txtContext.TabIndex = 0;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(622, 152);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(296, 25);
            this.txtMsg.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(622, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 46);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(808, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 46);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // tvDir
            // 
            this.tvDir.Location = new System.Drawing.Point(12, 95);
            this.tvDir.Name = "tvDir";
            this.tvDir.Size = new System.Drawing.Size(575, 416);
            this.tvDir.TabIndex = 4;
            // 
            // btnStartDir
            // 
            this.btnStartDir.Location = new System.Drawing.Point(12, 12);
            this.btnStartDir.Name = "btnStartDir";
            this.btnStartDir.Size = new System.Drawing.Size(110, 46);
            this.btnStartDir.TabIndex = 5;
            this.btnStartDir.Text = "开始显示目录";
            this.btnStartDir.UseVisualStyleBackColor = true;
            // 
            // btnStopDir
            // 
            this.btnStopDir.Location = new System.Drawing.Point(214, 12);
            this.btnStopDir.Name = "btnStopDir";
            this.btnStopDir.Size = new System.Drawing.Size(110, 46);
            this.btnStopDir.TabIndex = 6;
            this.btnStopDir.Text = "停止显示目录";
            this.btnStopDir.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 523);
            this.Controls.Add(this.btnStopDir);
            this.Controls.Add(this.btnStartDir);
            this.Controls.Add(this.tvDir);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtContext);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TreeView tvDir;
        private System.Windows.Forms.Button btnStartDir;
        private System.Windows.Forms.Button btnStopDir;
    }
}