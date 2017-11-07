namespace FormsCTF
{
    partial class FormLaiKey
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
            this.txtMSg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMSg
            // 
            this.txtMSg.Location = new System.Drawing.Point(36, 110);
            this.txtMSg.Multiline = true;
            this.txtMSg.Name = "txtMSg";
            this.txtMSg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMSg.Size = new System.Drawing.Size(604, 306);
            this.txtMSg.TabIndex = 0;
            // 
            // FormLaiKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 508);
            this.Controls.Add(this.txtMSg);
            this.Name = "FormLaiKey";
            this.Text = "FormLaiKey";
            this.Load += new System.EventHandler(this.FormLaiKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMSg;
    }
}