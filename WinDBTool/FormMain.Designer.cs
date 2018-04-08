namespace WinDBTool
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.btnConnectionDB = new System.Windows.Forms.Button();
            this.lvRemoteDB = new System.Windows.Forms.ListView();
            this.DBName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMenuStripDB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMReaderRemoteDB = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMenuStripDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectionDB
            // 
            this.btnConnectionDB.Location = new System.Drawing.Point(13, 5);
            this.btnConnectionDB.Name = "btnConnectionDB";
            this.btnConnectionDB.Size = new System.Drawing.Size(127, 48);
            this.btnConnectionDB.TabIndex = 0;
            this.btnConnectionDB.Text = "连接数据库";
            this.btnConnectionDB.UseVisualStyleBackColor = true;
            this.btnConnectionDB.Click += new System.EventHandler(this.btnConnectionDB_Click);
            // 
            // lvRemoteDB
            // 
            this.lvRemoteDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DBName});
            this.lvRemoteDB.ContextMenuStrip = this.cMenuStripDB;
            this.lvRemoteDB.Location = new System.Drawing.Point(12, 77);
            this.lvRemoteDB.Name = "lvRemoteDB";
            this.lvRemoteDB.Size = new System.Drawing.Size(319, 511);
            this.lvRemoteDB.TabIndex = 1;
            this.lvRemoteDB.UseCompatibleStateImageBehavior = false;
            this.lvRemoteDB.View = System.Windows.Forms.View.Details;
            // 
            // DBName
            // 
            this.DBName.Text = "  名称";
            // 
            // cMenuStripDB
            // 
            this.cMenuStripDB.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuStripDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMReaderRemoteDB});
            this.cMenuStripDB.Name = "cMenuStripDB";
            this.cMenuStripDB.Size = new System.Drawing.Size(139, 28);
            // 
            // tSMReaderRemoteDB
            // 
            this.tSMReaderRemoteDB.Name = "tSMReaderRemoteDB";
            this.tSMReaderRemoteDB.Size = new System.Drawing.Size(138, 24);
            this.tSMReaderRemoteDB.Text = "读取数据";
            this.tSMReaderRemoteDB.Click += new System.EventHandler(this.tSMReaderRemoteDB_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.cMenuStripDB;
            this.listView1.Location = new System.Drawing.Point(351, 77);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(319, 511);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "  名称";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 600);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lvRemoteDB);
            this.Controls.Add(this.btnConnectionDB);
            this.Name = "FormMain";
            this.Text = "读取远程数据库工具";
            this.cMenuStripDB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectionDB;
        private System.Windows.Forms.ListView lvRemoteDB;
        private System.Windows.Forms.ColumnHeader DBName;
        private System.Windows.Forms.ContextMenuStrip cMenuStripDB;
        private System.Windows.Forms.ToolStripMenuItem tSMReaderRemoteDB;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

