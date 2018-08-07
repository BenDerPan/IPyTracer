namespace winform_example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnRun = new System.Windows.Forms.ToolStripButton();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tvVariable = new System.Windows.Forms.TreeView();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnOpen,
            this.toolBtnSave,
            this.toolBtnRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(945, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnRun
            // 
            this.toolBtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnRun.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnRun.Image")));
            this.toolBtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRun.Name = "toolBtnRun";
            this.toolBtnRun.Size = new System.Drawing.Size(23, 22);
            this.toolBtnRun.Text = "执行";
            this.toolBtnRun.Click += new System.EventHandler(this.toolBtnRun_Click);
            // 
            // tbCode
            // 
            this.tbCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCode.Location = new System.Drawing.Point(0, 25);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCode.Size = new System.Drawing.Size(945, 377);
            this.tbCode.TabIndex = 1;
            this.tbCode.Text = resources.GetString("tbCode.Text");
            // 
            // tvVariable
            // 
            this.tvVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvVariable.Location = new System.Drawing.Point(0, 402);
            this.tvVariable.Name = "tvVariable";
            this.tvVariable.Size = new System.Drawing.Size(945, 278);
            this.tvVariable.TabIndex = 2;
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSave.Image")));
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(23, 22);
            this.toolBtnSave.Text = "保存";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolBtnOpen
            // 
            this.toolBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnOpen.Image")));
            this.toolBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnOpen.Name = "toolBtnOpen";
            this.toolBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.toolBtnOpen.Text = "打开";
            this.toolBtnOpen.Click += new System.EventHandler(this.toolBtnOpen_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 680);
            this.Controls.Add(this.tvVariable);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "Python脚本运行跟踪";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnRun;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TreeView tvVariable;
        private System.Windows.Forms.ToolStripButton toolBtnOpen;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
    }
}

