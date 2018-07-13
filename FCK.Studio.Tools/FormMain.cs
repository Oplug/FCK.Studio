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
    public partial class FormMain : Form
    {
        private int totalRow = 0;
        private int compRow = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            using (MembersService members = new MembersService())
            {
                //var resp = members.Reposity.GetPageList(1, 100, o => o.TenantId == 2);
                //if (resp != null)
                //{
                //    dgvMain.DataSource = resp.datas;
                //}
            }
        }

        private void toolBtnUpload_Click(object sender, EventArgs e)
        {
            MembersService ObjServ = new MembersService();
            MembersService ObjServRead = new MembersService();
            TenantsService ObjTenant = new TenantsService();
            string community = "兴塘社区";
            int TenantId = 2;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row != null)
                {
                    string userid = row.Cells["身份证号"].Value.ToString();
                    try
                    {
                        var obj = ObjServRead.Reposity.GetAllList(o => o.UserID == userid && o.UserID != "0").FirstOrDefault();
                        if (obj != null)
                        {
                            obj.TrueName = row.Cells["姓名"].Value.ToString();
                            obj.Relations = row.Cells["关系"].Value.ToString();
                            obj.Sex = CellVal(headerRow, "性别", row);
                            obj.Nation = CellVal(headerRow, "民族", row);
                            //obj.Birthday = CellVal(headerRow, "出生年月", row);
                            obj.Age = int.Parse(CellVal(headerRow, "年龄", row));
                            obj.Apartment = CellVal(headerRow, "楼盘", row);
                            obj.UnitNum = CellVal(headerRow, "单元", row);
                            obj.DoorCard = CellVal(headerRow, "门牌号", row);
                            obj.UserID = CellVal(headerRow, "身份证号", row);
                            obj.Address = CellVal(headerRow, "现户籍地址", row);
                            obj.Address2 = CellVal(headerRow, "原户籍地址", row);
                            obj.HhdRegister = CellVal(headerRow, "是否兴塘社区户籍", row) == "是";
                            obj.ServiceAddr = CellVal(headerRow, "服务处所", row);
                            obj.Duties = CellVal(headerRow, "职务", row);
                            obj.Phone = CellVal(headerRow, "联系电话1", row);
                            obj.Phone2 = CellVal(headerRow, "联系电话2", row);
                            obj.PoliticalRole = CellVal(headerRow, "政治面貌", row);
                            obj.PartyBranch = CellVal(headerRow, "党员所在支部", row);
                            obj.CorridorLeader = CellVal(headerRow, "是否楼道组长", row) == "是";
                            obj.HouseLeader = CellVal(headerRow, "是否户代表", row) == "是";
                            obj.ResidentRepresentative = CellVal(headerRow, "是否居民代表", row) == "是";
                            obj.ResidentLeader = CellVal(headerRow, "是否居民组长", row) == "是";
                            obj.Pipwa = CellVal(headerRow, "是否愿意参加公益", row) == "是";
                            obj.Eira = CellVal(headerRow, "是否愿意从事居民事务", row) == "是";
                            obj.UpdateTime = DateTime.Now;
                            obj.Speciality = CellVal(headerRow, "特长备注", row);
                            obj.TenantId = TenantId;
                            obj.Community = community;
                            obj.IsReger = false;
                            ObjServ.Reposity.Update(obj);
                        }
                        else
                        {
                            Members entity = new Members();
                            entity.TrueName = CellVal(headerRow, "姓名", row);
                            entity.Relations = CellVal(headerRow, "关系", row);
                            entity.Sex = CellVal(headerRow, "性别", row);
                            entity.Nation = CellVal(headerRow, "民族", row);
                            //entity.Birthday = CellVal(headerRow, "出生年月", row);
                            //entity.Age = int.Parse(CellVal(headerRow, "年龄", row));
                            entity.Apartment = CellVal(headerRow, "楼盘", row);
                            entity.UnitNum = CellVal(headerRow, "单元", row);
                            entity.DoorCard = CellVal(headerRow, "门牌号", row);
                            entity.UserID = CellVal(headerRow, "身份证号", row);
                            entity.Address = CellVal(headerRow, "现户籍地址", row);
                            entity.Address2 = CellVal(headerRow, "原户籍地址", row);
                            entity.HhdRegister = CellVal(headerRow, "是否兴塘社区户籍", row) == "是";
                            entity.ServiceAddr = CellVal(headerRow, "服务处所", row);
                            entity.Duties = CellVal(headerRow, "职务", row);
                            entity.Phone = CellVal(headerRow, "联系电话1", row);
                            entity.Phone2 = CellVal(headerRow, "联系电话2", row);
                            entity.PoliticalRole = CellVal(headerRow, "政治面貌", row);
                            entity.PartyBranch = CellVal(headerRow, "党员所在支部", row);
                            entity.CorridorLeader = CellVal(headerRow, "是否楼道组长", row) == "是";
                            entity.HouseLeader = CellVal(headerRow, "是否户代表", row) == "是";
                            entity.ResidentRepresentative = CellVal(headerRow, "是否居民代表", row) == "是";
                            entity.ResidentLeader = CellVal(headerRow, "是否居民组长", row) == "是";
                            entity.Pipwa = CellVal(headerRow, "是否愿意参加公益", row) == "是";
                            entity.Eira = CellVal(headerRow, "是否愿意从事居民事务", row) == "是";
                            entity.UpdateTime = DateTime.Now;
                            entity.Speciality = CellVal(headerRow, "特长备注", row);
                            entity.UserName = GetRndCode(6);
                            entity.Password = "96E79218965EB72C92A549DD5A330112";
                            entity.Email = "-";
                            entity.CreationTime = DateTime.Now;
                            entity.TenantId = TenantId;
                            entity.Community = community;
                            entity.IsReger = false;
                            BirthdayAgeSex user = AppBase.GetBirthdayAgeSex(entity.UserID);
                            if (user != null)
                            {
                                entity.Age = user.Age;
                                entity.Birthday = user.Birthday;
                                entity.Sex = user.Sex;
                            }
                            else
                            {
                                entity.UserID = "身份证号码不合法";
                            }
                            ObjServ.Reposity.Insert(entity);
                        }
                        compRow++;
                    }
                    catch (Exception ex)
                    {
                        textBoxError.Text = userid + "导入发生错误：" + ex.Message + "\r\n";
                        continue;
                    }
                }
            }
            ObjServ.Dispose();
            ObjServRead.Dispose();
            ObjTenant.Dispose();
        }

        private void toolBtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.toolFilePath.Text = file.FileName;
                var dt = ExcelHelper.ImportFromExcel(file.FileName, 0);
                dgvMain.DataSource = dt.Tables[0];
                totalRow = dt.Tables[0].Rows.Count;
                labelCount.Text = "完成：" + compRow + "/" + totalRow;
                progressBarM.Maximum = totalRow;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            labelCount.Text = "完成：" + compRow + "/" + totalRow;
            progressBarM.Value = compRow;
        }
    }
}
