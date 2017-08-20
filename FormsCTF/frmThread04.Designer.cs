namespace FormsCTF
{
    partial class frmThread04
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDanStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnDanStart);
            this.groupBox1.Location = new System.Drawing.Point(110, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 86);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单进度显示";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(447, 23);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 1;
            // 
            // btnDanStart
            // 
            this.btnDanStart.Location = new System.Drawing.Point(21, 49);
            this.btnDanStart.Name = "btnDanStart";
            this.btnDanStart.Size = new System.Drawing.Size(75, 23);
            this.btnDanStart.TabIndex = 0;
            this.btnDanStart.Text = "start";
            this.btnDanStart.UseVisualStyleBackColor = true;
            this.btnDanStart.Click += new System.EventHandler(this.btnDanStart_Click);
            // 
            // frmThread04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 558);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThread04";
            this.Text = "frmThread04";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDanStart;
    }
}