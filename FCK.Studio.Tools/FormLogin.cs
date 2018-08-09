using FCK.Studio.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCK.Studio.Tools
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string username = textBoxUser.Text;
            string password = textBoxPsw.Text;
            int tenantid = AppBase.CInt(comboBoxTenant.SelectedValue);
            int cateid = AppBase.CInt(comboBoxCate.SelectedValue);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入用户名和密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tenantid == 0)
            {
                MessageBox.Show("请选择站点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cateid == 0)
            {
                MessageBox.Show("请选择社区！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (AdminsService admin = new AdminsService())
            {
                var model = admin.Reposity.GetAllList().Where(o => o.LoginName == username).FirstOrDefault();
                if (model != null)
                {
                    if (model.Password == password)
                    {
                        FormMain form = new FormMain(tenantid, cateid, model.Id, comboBoxCate.Text, model.LoginName);
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = ProductName +" v"+ ProductVersion;
                using (TenantsService objserv = new TenantsService())
                {
                    var list = objserv.Reposity.GetAllList();
                    comboBoxTenant.DataSource = list.Select(o => new { o.TenantName, o.Id }).ToList();
                    comboBoxTenant.DisplayMember = "TenantName";
                    comboBoxTenant.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTenant_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxCate.DataSource = null;
            using (CategoriesService objserv = new CategoriesService())
            {
                int tenantid = AppBase.CInt(comboBoxTenant.SelectedValue.ToString());
                var list = objserv.Reposity.GetAllList(o => o.TenantId == tenantid && o.Layout == "Zone" && o.Level==3);
                comboBoxCate.DataSource = list.Select(o => new { o.CategoryName, o.Id }).ToList();
                comboBoxCate.DisplayMember = "CategoryName";
                comboBoxCate.ValueMember = "Id";
            }
        }
    }
}
