namespace FormsCTF
{
    partial class frmFile
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
            this.btnTestThread = new System.Windows.Forms.Button();
            this.btnTestThread02 = new System.Windows.Forms.Button();
            this.btnTestThread03 = new System.Windows.Forms.Button();
            this.btnTestThread04 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestThread
            // 
            this.btnTestThread.Location = new System.Drawing.Point(42, 36);
            this.btnTestThread.Name = "btnTestThread";
            this.btnTestThread.Size = new System.Drawing.Size(120, 61);
            this.btnTestThread.TabIndex = 0;
            this.btnTestThread.Text = "测试线程1";
            this.btnTestThread.UseVisualStyleBackColor = true;
            this.btnTestThread.Click += new System.EventHandler(this.btnTestThread_Click);
            // 
            // btnTestThread02
            // 
            this.btnTestThread02.Location = new System.Drawing.Point(222, 36);
            this.btnTestThread02.Name = "btnTestThread02";
            this.btnTestThread02.Size = new System.Drawing.Size(120, 61);
            this.btnTestThread02.TabIndex = 1;
            this.btnTestThread02.Text = "测试线程2";
            this.btnTestThread02.UseVisualStyleBackColor = true;
            this.btnTestThread02.Click += new System.EventHandler(this.btnTestThread02_Click);
            // 
            // btnTestThread03
            // 
            this.btnTestThread03.Location = new System.Drawing.Point(406, 36);
            this.btnTestThread03.Name = "btnTestThread03";
            this.btnTestThread03.Size = new System.Drawing.Size(120, 61);
            this.btnTestThread03.TabIndex = 2;
            this.btnTestThread03.Text = "测试线程3";
            this.btnTestThread03.UseVisualStyleBackColor = true;
            this.btnTestThread03.Click += new System.EventHandler(this.btnTestThread03_Click);
            // 
            // btnTestThread04
            // 
            this.btnTestThread04.Location = new System.Drawing.Point(594, 36);
            this.btnTestThread04.Name = "btnTestThread04";
            this.btnTestThread04.Size = new System.Drawing.Size(120, 61);
            this.btnTestThread04.TabIndex = 3;
            this.btnTestThread04.Text = "测试线程3";
            this.btnTestThread04.UseVisualStyleBackColor = true;
            this.btnTestThread04.Click += new System.EventHandler(this.btnTestThread04_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // frmFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestThread04);
            this.Controls.Add(this.btnTestThread03);
            this.Controls.Add(this.btnTestThread02);
            this.Controls.Add(this.btnTestThread);
            this.Name = "frmFile";
            this.Text = "文件夹及文件操作";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestThread;
        private System.Windows.Forms.Button btnTestThread02;
        private System.Windows.Forms.Button btnTestThread03;
        private System.Windows.Forms.Button btnTestThread04;
        private System.Windows.Forms.Label label1;
    }
}