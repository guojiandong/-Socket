namespace WinMySqlTool
{
    partial class FrmMain
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
            this.lvRemoteDB = new System.Windows.Forms.ListView();
            this.DBName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvRemoteTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvRemoteDB
            // 
            this.lvRemoteDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DBName});
            this.lvRemoteDB.Location = new System.Drawing.Point(12, 69);
            this.lvRemoteDB.Name = "lvRemoteDB";
            this.lvRemoteDB.Size = new System.Drawing.Size(300, 475);
            this.lvRemoteDB.TabIndex = 0;
            this.lvRemoteDB.UseCompatibleStateImageBehavior = false;
            this.lvRemoteDB.View = System.Windows.Forms.View.Details;
            this.lvRemoteDB.Click += new System.EventHandler(this.lvRemoteDB_Click);
            // 
            // DBName
            // 
            this.DBName.Text = "名称";
            // 
            // lvRemoteTable
            // 
            this.lvRemoteTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRemoteTable.Location = new System.Drawing.Point(343, 69);
            this.lvRemoteTable.Name = "lvRemoteTable";
            this.lvRemoteTable.Size = new System.Drawing.Size(300, 475);
            this.lvRemoteTable.TabIndex = 1;
            this.lvRemoteTable.UseCompatibleStateImageBehavior = false;
            this.lvRemoteTable.View = System.Windows.Forms.View.Details;
            this.lvRemoteTable.Click += new System.EventHandler(this.lvRemoteTable_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 570);
            this.Controls.Add(this.lvRemoteTable);
            this.Controls.Add(this.lvRemoteDB);
            this.Name = "FrmMain";
            this.Text = "MySql工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRemoteDB;
        private System.Windows.Forms.ColumnHeader DBName;
        private System.Windows.Forms.ListView lvRemoteTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

