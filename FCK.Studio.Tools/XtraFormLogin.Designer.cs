namespace FCK.Studio.Tools
{
    partial class XtraFormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFormLogin));
            this.simpleButtonLogin = new DevExpress.XtraEditors.SimpleButton();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.dropDownButton2 = new DevExpress.XtraEditors.DropDownButton();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.textEditPsw = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPsw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonLogin
            // 
            this.simpleButtonLogin.Location = new System.Drawing.Point(104, 180);
            this.simpleButtonLogin.Name = "simpleButtonLogin";
            this.simpleButtonLogin.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonLogin.TabIndex = 0;
            this.simpleButtonLogin.Text = "登录";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Location = new System.Drawing.Point(73, 96);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(135, 23);
            this.dropDownButton1.TabIndex = 1;
            this.dropDownButton1.Text = "选择站点";
            // 
            // dropDownButton2
            // 
            this.dropDownButton2.Location = new System.Drawing.Point(73, 125);
            this.dropDownButton2.Name = "dropDownButton2";
            this.dropDownButton2.Size = new System.Drawing.Size(135, 23);
            this.dropDownButton2.TabIndex = 2;
            this.dropDownButton2.Text = "选择社区";
            // 
            // textEditUser
            // 
            this.textEditUser.Location = new System.Drawing.Point(73, 32);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Size = new System.Drawing.Size(135, 20);
            this.textEditUser.TabIndex = 3;
            // 
            // textEditPsw
            // 
            this.textEditPsw.Location = new System.Drawing.Point(73, 58);
            this.textEditPsw.Name = "textEditPsw";
            this.textEditPsw.Properties.PasswordChar = '*';
            this.textEditPsw.Size = new System.Drawing.Size(135, 20);
            this.textEditPsw.TabIndex = 4;
            // 
            // XtraFormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textEditPsw);
            this.Controls.Add(this.textEditUser);
            this.Controls.Add(this.dropDownButton2);
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.simpleButtonLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XtraFormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPsw.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonLogin;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraEditors.DropDownButton dropDownButton2;
        private DevExpress.XtraEditors.TextEdit textEditUser;
        private DevExpress.XtraEditors.TextEdit textEditPsw;
    }
}