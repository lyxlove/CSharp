namespace JCWK_DEMO
{
    partial class Form1
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
            this.btnSend = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colHPHM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJCLSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLWLSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJYXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(713, 36);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHPHM,
            this.colJCLSH,
            this.colLWLSH,
            this.colJYXM});
            this.dgvMain.Location = new System.Drawing.Point(12, 100);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(776, 338);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            // 
            // colHPHM
            // 
            this.colHPHM.DataPropertyName = "HPHM";
            this.colHPHM.HeaderText = "号牌号码";
            this.colHPHM.Name = "colHPHM";
            this.colHPHM.ReadOnly = true;
            // 
            // colJCLSH
            // 
            this.colJCLSH.DataPropertyName = "JCLSH";
            this.colJCLSH.HeaderText = "检测流水号";
            this.colJCLSH.Name = "colJCLSH";
            this.colJCLSH.ReadOnly = true;
            this.colJCLSH.Width = 200;
            // 
            // colLWLSH
            // 
            this.colLWLSH.DataPropertyName = "AJLSH";
            this.colLWLSH.HeaderText = "联网流水号";
            this.colLWLSH.Name = "colLWLSH";
            this.colLWLSH.ReadOnly = true;
            this.colLWLSH.Width = 200;
            // 
            // colJYXM
            // 
            this.colJYXM.DataPropertyName = "JYXM";
            this.colJYXM.HeaderText = "检验项目";
            this.colJYXM.Name = "colJYXM";
            this.colJYXM.ReadOnly = true;
            this.colJYXM.Width = 200;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(794, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(269, 426);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(620, 36);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(75, 23);
            this.btnGetResult.TabIndex = 4;
            this.btnGetResult.Text = "获取结果";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(518, 36);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPHM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJCLSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLWLSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJYXM;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.Button btnRefresh;
    }
}

