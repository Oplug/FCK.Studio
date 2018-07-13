namespace FCK.Studio.Tools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.toolFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.toolSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBtnSelectFile = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.progressBarM = new System.Windows.Forms.ProgressBar();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnSelectFile,
            this.toolFilePath,
            this.toolBtnUpload,
            this.toolStripSeparator2,
            this.toolBtnDownload,
            this.toolStripSeparator3,
            this.toolBtnAdd,
            this.toolStripSeparator4,
            this.toolBtnDel,
            this.toolStripSeparator1,
            this.toolBtnSave,
            this.toolStripSeparator5,
            this.toolBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnUpload
            // 
            this.toolBtnUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnUpload.Image = global::FCK.Studio.Tools.Properties.Resources.upload;
            this.toolBtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUpload.Name = "toolBtnUpload";
            this.toolBtnUpload.Size = new System.Drawing.Size(24, 24);
            this.toolBtnUpload.Text = "上传";
            this.toolBtnUpload.Click += new System.EventHandler(this.toolBtnUpload_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnDownload
            // 
            this.toolBtnDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDownload.Image = global::FCK.Studio.Tools.Properties.Resources.down;
            this.toolBtnDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDownload.Name = "toolBtnDownload";
            this.toolBtnDownload.Size = new System.Drawing.Size(24, 24);
            this.toolBtnDownload.Text = "下载";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnAdd
            // 
            this.toolBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnAdd.Image = global::FCK.Studio.Tools.Properties.Resources.add;
            this.toolBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdd.Name = "toolBtnAdd";
            this.toolBtnAdd.Size = new System.Drawing.Size(24, 24);
            this.toolBtnAdd.Text = "添加";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnDel
            // 
            this.toolBtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDel.Image = global::FCK.Studio.Tools.Properties.Resources.del;
            this.toolBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDel.Name = "toolBtnDel";
            this.toolBtnDel.Size = new System.Drawing.Size(24, 24);
            this.toolBtnDel.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSave.Image = global::FCK.Studio.Tools.Properties.Resources.save;
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(24, 24);
            this.toolBtnSave.Text = "保存";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnRefresh
            // 
            this.toolBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnRefresh.Image = global::FCK.Studio.Tools.Properties.Resources.refresh;
            this.toolBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRefresh.Name = "toolBtnRefresh";
            this.toolBtnRefresh.Size = new System.Drawing.Size(24, 24);
            this.toolBtnRefresh.Text = "刷新";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolSLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 27;
            this.dgvMain.Size = new System.Drawing.Size(882, 251);
            this.dgvMain.TabIndex = 2;
            // 
            // toolFilePath
            // 
            this.toolFilePath.Name = "toolFilePath";
            this.toolFilePath.Size = new System.Drawing.Size(300, 27);
            // 
            // toolSLabel
            // 
            this.toolSLabel.Name = "toolSLabel";
            this.toolSLabel.Size = new System.Drawing.Size(39, 20);
            this.toolSLabel.Text = "就绪";
            // 
            // toolBtnSelectFile
            // 
            this.toolBtnSelectFile.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolBtnSelectFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnSelectFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolBtnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSelectFile.Image")));
            this.toolBtnSelectFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSelectFile.Name = "toolBtnSelectFile";
            this.toolBtnSelectFile.Size = new System.Drawing.Size(85, 24);
            this.toolBtnSelectFile.Text = "选择文件...";
            this.toolBtnSelectFile.Click += new System.EventHandler(this.toolBtnSelectFile_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxError);
            this.splitContainer1.Panel2.Controls.Add(this.labelCount);
            this.splitContainer1.Panel2.Controls.Add(this.progressBarM);
            this.splitContainer1.Size = new System.Drawing.Size(882, 502);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 3;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // progressBarM
            // 
            this.progressBarM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarM.Location = new System.Drawing.Point(12, 3);
            this.progressBarM.Name = "progressBarM";
            this.progressBarM.Size = new System.Drawing.Size(858, 23);
            this.progressBarM.TabIndex = 0;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(13, 33);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(92, 15);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "完成：0/100";
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(12, 121);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(858, 123);
            this.textBoxError.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 554);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "FCKStudio工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnUpload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolBtnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolBtnAdd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolBtnRefresh;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStripTextBox toolFilePath;
        private System.Windows.Forms.ToolStripStatusLabel toolSLabel;
        private System.Windows.Forms.ToolStripButton toolBtnSelectFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ProgressBar progressBarM;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxError;
    }
}

