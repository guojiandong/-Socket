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
            this.SuspendLayout();
            // 
            // btnTestThread
            // 
            this.btnTestThread.Location = new System.Drawing.Point(452, 30);
            this.btnTestThread.Name = "btnTestThread";
            this.btnTestThread.Size = new System.Drawing.Size(120, 61);
            this.btnTestThread.TabIndex = 0;
            this.btnTestThread.Text = "测试线程";
            this.btnTestThread.UseVisualStyleBackColor = true;
            // 
            // frmFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 600);
            this.Controls.Add(this.btnTestThread);
            this.Name = "frmFile";
            this.Text = "文件夹及文件操作";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestThread;
    }
}