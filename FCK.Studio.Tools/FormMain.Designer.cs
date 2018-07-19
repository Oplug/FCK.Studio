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
            this.toolBtnSelectFile = new System.Windows.Forms.ToolStripButton();
            this.toolFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.toolBtnValid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvHouse = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.progressBarM = new System.Windows.Forms.ProgressBar();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHouse)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnSelectFile,
            this.toolFilePath,
            this.toolBtnValid,
            this.toolStripSeparator2,
            this.toolBtnUpload,
            this.toolStripSeparator3,
            this.toolBtnDownload,
            this.toolStripSeparator4,
            this.toolBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnSelectFile
            // 
            this.toolBtnSelectFile.BackColor = System.Drawing.SystemColors.Control;
            this.toolBtnSelectFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolBtnSelectFile.Image = global::FCK.Studio.Tools.Properties.Resources.excel;
            this.toolBtnSelectFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnSelectFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSelectFile.Name = "toolBtnSelectFile";
            this.toolBtnSelectFile.Size = new System.Drawing.Size(101, 24);
            this.toolBtnSelectFile.Text = "选择文件...";
            this.toolBtnSelectFile.Click += new System.EventHandler(this.toolBtnSelectFile_Click);
            // 
            // toolFilePath
            // 
            this.toolFilePath.Name = "toolFilePath";
            this.toolFilePath.Size = new System.Drawing.Size(300, 27);
            // 
            // toolBtnValid
            // 
            this.toolBtnValid.BackColor = System.Drawing.SystemColors.Control;
            this.toolBtnValid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolBtnValid.Image = global::FCK.Studio.Tools.Properties.Resources.success;
            this.toolBtnValid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnValid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnValid.Name = "toolBtnValid";
            this.toolBtnValid.Size = new System.Drawing.Size(59, 24);
            this.toolBtnValid.Text = "校验";
            this.toolBtnValid.Click += new System.EventHandler(this.toolBtnValid_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnUpload
            // 
            this.toolBtnUpload.BackColor = System.Drawing.SystemColors.Control;
            this.toolBtnUpload.Enabled = false;
            this.toolBtnUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolBtnUpload.Image = global::FCK.Studio.Tools.Properties.Resources.upload;
            this.toolBtnUpload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUpload.Name = "toolBtnUpload";
            this.toolBtnUpload.Size = new System.Drawing.Size(59, 24);
            this.toolBtnUpload.Text = "上传";
            this.toolBtnUpload.Click += new System.EventHandler(this.toolBtnUpload_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnDownload
            // 
            this.toolBtnDownload.BackColor = System.Drawing.SystemColors.Control;
            this.toolBtnDownload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolBtnDownload.Image = global::FCK.Studio.Tools.Properties.Resources.down;
            this.toolBtnDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDownload.Name = "toolBtnDownload";
            this.toolBtnDownload.Size = new System.Drawing.Size(59, 24);
            this.toolBtnDownload.Text = "下载";
            this.toolBtnDownload.Click += new System.EventHandler(this.toolBtnDownload_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolBtnRefresh
            // 
            this.toolBtnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.toolBtnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolBtnRefresh.Image = global::FCK.Studio.Tools.Properties.Resources.refresh;
            this.toolBtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRefresh.Name = "toolBtnRefresh";
            this.toolBtnRefresh.Size = new System.Drawing.Size(59, 24);
            this.toolBtnRefresh.Text = "刷新";
            this.toolBtnRefresh.Click += new System.EventHandler(this.toolBtnRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSLabel,
            this.toolSLabel2,
            this.toolSLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(883, 29);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolSLabel
            // 
            this.toolSLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolSLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolSLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSLabel.Name = "toolSLabel";
            this.toolSLabel.Size = new System.Drawing.Size(43, 24);
            this.toolSLabel.Text = "就绪";
            // 
            // toolSLabel2
            // 
            this.toolSLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolSLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolSLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSLabel2.Name = "toolSLabel2";
            this.toolSLabel2.Size = new System.Drawing.Size(43, 24);
            this.toolSLabel2.Text = "就绪";
            // 
            // toolSLabel3
            // 
            this.toolSLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolSLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolSLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSLabel3.Name = "toolSLabel3";
            this.toolSLabel3.Size = new System.Drawing.Size(43, 24);
            this.toolSLabel3.Text = "就绪";
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(3, 3);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 27;
            this.dgvMain.Size = new System.Drawing.Size(866, 202);
            this.dgvMain.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelTotal);
            this.splitContainer1.Panel2.Controls.Add(this.labelError);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxError);
            this.splitContainer1.Panel2.Controls.Add(this.labelCount);
            this.splitContainer1.Panel2.Controls.Add(this.progressBarM);
            this.splitContainer1.Size = new System.Drawing.Size(883, 498);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMain.Location = new System.Drawing.Point(3, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(880, 241);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "户籍";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvHouse);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "房屋";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHouse
            // 
            this.dgvHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHouse.Location = new System.Drawing.Point(3, 3);
            this.dgvHouse.Name = "dgvHouse";
            this.dgvHouse.RowTemplate.Height = 27;
            this.dgvHouse.Size = new System.Drawing.Size(866, 202);
            this.dgvHouse.TabIndex = 0;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotal.Location = new System.Drawing.Point(337, 40);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(39, 20);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "总共";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelError.Location = new System.Drawing.Point(201, 40);
            this.labelError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(63, 20);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "错误：0";
            // 
            // textBoxError
            // 
            this.textBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxError.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxError.Location = new System.Drawing.Point(0, 72);
            this.textBoxError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.ReadOnly = true;
            this.textBoxError.Size = new System.Drawing.Size(880, 169);
            this.textBoxError.TabIndex = 2;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCount.Location = new System.Drawing.Point(13, 40);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(96, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "完成：0/100";
            // 
            // progressBarM
            // 
            this.progressBarM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarM.Location = new System.Drawing.Point(12, 9);
            this.progressBarM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarM.Name = "progressBarM";
            this.progressBarM.Size = new System.Drawing.Size(859, 22);
            this.progressBarM.TabIndex = 0;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 554);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "DMT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
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
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnUpload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolBtnValid;
        private System.Windows.Forms.StatusStrip statusStrip1;
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
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvHouse;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolSLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolSLabel3;
    }
}

