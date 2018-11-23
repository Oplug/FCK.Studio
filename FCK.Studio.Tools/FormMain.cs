using AutoMapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using FCK.Studio.Application;
using FCK.Studio.Core;
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
    public partial class FormMain : XtraForm
    {
        private int totalRow = 0;
        private int compRow = 0;
        private int errorRow = 0;
        private string Community = "兴塘社区";
        private int TenantId = 2;
        private int CateId = 0;
        private int MemberId = 0;
        private string MemberName = "sa";
        public FormMain(int tenantId, int cateid, int memberId,string community,string memberName)
        {
            InitializeComponent();
            TenantId = tenantId;
            CateId = cateid;
            MemberId = memberId;
            Community = community;
            MemberName = memberName;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = ProductName + " v" + ProductVersion;
            try
            {
                toolSLabel.Text = Community;
                toolSLabel2.Text = "CID:" + CateId;
                toolSLabel3.Text = MemberName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void toolBtnUpload_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                UploadHouse();
            }
            else
            {
                UploadMember();
            }
        }
        private void UploadMember()
        {
            toolBtnUpload.Enabled = false;
            Task.Run(() =>
            {
                MembersService ObjServ = new MembersService();
                MembersService ObjServRead = new MembersService();

                errorRow = 0;
                compRow = 0;
                List<Members> members = new List<Members>();
                try
                {
                    members = ObjServRead.Reposity.GetAllList(o => o.TenantId == TenantId);
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        textBoxError.Text = "获取数据错误：" + ex.Message + "\r\n";
                    }));
                }
                ObjServRead.Dispose();
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    if (row != null)
                    {
                        string userid = row.Cells["身份证号"].Value != null ? row.Cells["身份证号"].Value.ToString() : "";
                        try
                        {
                            var obj = members.Where(o => o.UserID == userid && o.UserID != "0").FirstOrDefault();
                            if (obj != null)
                            {
                                #region update
                                obj.TrueName = row.Cells["姓名"].Value.ToString();
                                obj.Relations = row.Cells["关系"].Value.ToString();
                                obj.Sex = row.Cells["性别"].Value.ToString();
                                obj.Nation = row.Cells["民族"].Value.ToString();
                                //obj.Birthday = row.Cells["出生年月"].Value.ToString();
                                obj.Age = AppBase.CInt(row.Cells["年龄"].Value);
                                obj.Apartment = row.Cells["楼盘"].Value.ToString();
                                obj.UnitNum = AppBase.CInt(row.Cells["单元"].Value);
                                obj.DoorCard = AppBase.CInt(row.Cells["门牌号"].Value.ToString());
                                obj.UserID = row.Cells["身份证号"].Value.ToString();
                                obj.Address = row.Cells["现户籍地址"].Value.ToString();
                                obj.Address2 = row.Cells["原户籍地址"].Value.ToString();
                                obj.HhdRegister = row.Cells["是否兴塘社区户籍"].Value.ToString() == "是";
                                obj.ServiceAddr = row.Cells["服务处所"].Value.ToString();
                                obj.Duties = row.Cells["职务"].Value.ToString();
                                obj.Phone = row.Cells["联系电话1"].Value.ToString();
                                obj.Phone2 = row.Cells["联系电话2"].Value.ToString();
                                obj.PoliticalRole = row.Cells["政治面貌"].Value.ToString();
                                obj.PartyBranch = row.Cells["党员所在支部"].Value.ToString();
                                obj.CorridorLeader = row.Cells["是否楼道组长"].Value.ToString() == "是";
                                obj.HouseLeader = row.Cells["是否户代表"].Value.ToString() == "是";
                                obj.ResidentRepresentative = row.Cells["是否居民代表"].Value.ToString() == "是";
                                obj.ResidentLeader = row.Cells["是否居民组长"].Value.ToString() == "是";
                                obj.Pipwa = row.Cells["是否愿意参加公益"].Value.ToString() == "是";
                                obj.Eira = row.Cells["是否愿意从事居民事务"].Value.ToString() == "是";
                                obj.UpdateTime = DateTime.Now;
                                obj.Speciality = row.Cells["特长备注"].Value.ToString();
                                obj.TenantId = TenantId;
                                obj.Community = Community;
                                obj.IsReger = false;
                                ObjServ.Reposity.Update(obj);
                                #endregion
                            }
                            else
                            {
                                #region insert
                                Members entity = new Members();
                                entity.TrueName = row.Cells["姓名"].Value.ToString();
                                entity.Relations = row.Cells["关系"].Value.ToString();
                                entity.Nation = row.Cells["民族"].Value.ToString();
                                entity.Apartment = row.Cells["楼盘"].Value.ToString();
                                entity.UnitNum = AppBase.CInt(row.Cells["单元"].Value);
                                entity.DoorCard = AppBase.CInt(row.Cells["门牌号"].Value);
                                entity.UserID = row.Cells["身份证号"].Value.ToString();
                                entity.Address = row.Cells["现户籍地址"].Value.ToString();
                                entity.Address2 = row.Cells["原户籍地址"].Value.ToString();
                                entity.HhdRegister = row.Cells["是否兴塘社区户籍"].Value.ToString() == "是";
                                entity.ServiceAddr = row.Cells["服务处所"].Value.ToString();
                                entity.Duties = row.Cells["职务"].Value.ToString();
                                entity.Phone = row.Cells["联系电话1"].Value.ToString();
                                entity.Phone2 = row.Cells["联系电话2"].Value.ToString();
                                entity.PoliticalRole = row.Cells["政治面貌"].Value.ToString();
                                entity.PartyBranch = row.Cells["党员所在支部"].Value.ToString();
                                entity.CorridorLeader = row.Cells["是否楼道组长"].Value.ToString() == "是";
                                entity.HouseLeader = row.Cells["是否户代表"].Value.ToString() == "是";
                                entity.ResidentRepresentative = row.Cells["是否居民代表"].Value.ToString() == "是";
                                entity.ResidentLeader = row.Cells["是否居民组长"].Value.ToString() == "是";
                                entity.Pipwa = row.Cells["是否愿意参加公益"].Value.ToString() == "是";
                                entity.Eira = row.Cells["是否愿意从事居民事务"].Value.ToString() == "是";
                                entity.UpdateTime = DateTime.Now;
                                entity.Speciality = row.Cells["特长备注"].Value.ToString();
                                entity.UserName = AppBase.GetRndCode(6);
                                entity.Password = "96E79218965EB72C92A549DD5A330112";
                                entity.Email = "-";
                                entity.CreationTime = DateTime.Now;
                                entity.TenantId = TenantId;
                                entity.Community = Community;
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
                                    entity.UserID = "no valid";
                                }
                                ObjServ.Reposity.Insert(entity);
                                #endregion
                            }

                        }
                        catch (Exception ex)
                        {
                            errorRow++;
                            this.BeginInvoke(new Action(() =>
                            {
                                textBoxError.Text += "导入[" + userid + "]发生错误：" + ex.Message + "      ";
                            }));
                        }
                        compRow++;
                        this.BeginInvoke(new Action(() =>
                        {
                            progressBarM.Value = compRow > progressBarM.Maximum ? progressBarM.Maximum : compRow;
                            labelCount.Text = "完成：" + progressBarM.Value + "/" + totalRow;
                            labelError.Text = "错误：" + (errorRow > progressBarM.Maximum ? progressBarM.Maximum : errorRow);
                            toolBtnUpload.Enabled = progressBarM.Value == totalRow;
                            if (totalRow == progressBarM.Value)
                            {
                                XtraMessageBox.Show("导入完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }));
                    }
                }
                ObjServ.Dispose();
            });
        }
        private void UploadHouse()
        {
            toolBtnUpload.Enabled = false;
            Task.Run(() =>
            {
                HouseService ObjServ = new HouseService();
                HouseService ObjServRead = new HouseService();

                errorRow = 0;
                compRow = 0;
                List<Houses> houses = new List<Houses>();
                try
                {
                    houses = ObjServRead.Reposity.GetAllList(o => o.TenantId == TenantId);
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        textBoxError.Text += "获取数据错误：" + ex.Message + "\r\n";
                    }));
                }
                ObjServRead.Dispose();
                foreach (DataGridViewRow row in dgvHouse.Rows)
                {
                    if (row != null)
                    {
                        string houseName = row.Cells["楼盘名称"].Value != null ? row.Cells["楼盘名称"].Value.ToString() : "0";
                        int unitNum = AppBase.CInt(row.Cells["单元号"].Value);
                        int doorCard = AppBase.CInt(row.Cells["门牌号"].Value);
                        try
                        {
                            var obj = houses.Where(o => o.HouseName == houseName && o.UnitNum == unitNum && o.DoorCard == doorCard).FirstOrDefault();
                            if (obj != null)
                            {
                                #region update
                                obj.HouseType = row.Cells["房屋属性"].Value.ToString();
                                obj.HouseArea = row.Cells["房屋面积"].Value.ToString();
                                obj.SaleStatus = row.Cells["销售状态"].Value.ToString();
                                obj.BuildStatus = row.Cells["已建未建"].Value.ToString();
                                obj.Owner = row.Cells["产权所有人1"].Value.ToString();
                                obj.Owner2 = row.Cells["产权所有人2"].Value.ToString();
                                obj.Owner3 = row.Cells["产权所有人3"].Value.ToString();
                                obj.Owner4 = row.Cells["产权所有人4"].Value.ToString();
                                obj.Owner5 = row.Cells["产权所有人5"].Value.ToString();
                                obj.ShortChar1 = row.Cells["网格名称"].Value.ToString();
                                obj.ShortChar2 = row.Cells["网格员"].Value.ToString();
                                obj.Memo = row.Cells["备注"].Value.ToString();
                                obj.TenantId = TenantId;
                                obj.CategoryId = CateId;
                                ObjServ.Reposity.Update(obj);
                                #endregion
                            }
                            else
                            {
                                #region insert
                                Houses entity = new Houses();
                                entity.HouseName = row.Cells["楼盘名称"].Value.ToString();
                                entity.UnitNum = AppBase.CInt(row.Cells["单元号"].Value);
                                entity.DoorCard = AppBase.CInt(row.Cells["门牌号"].Value);
                                entity.HouseType = row.Cells["房屋属性"].Value.ToString();
                                entity.HouseArea = row.Cells["房屋面积"].Value.ToString();
                                entity.SaleStatus = row.Cells["销售状态"].Value.ToString();
                                entity.BuildStatus = row.Cells["已建未建"].Value.ToString();
                                entity.Owner = row.Cells["产权所有人1"].Value.ToString();
                                entity.Owner2 = row.Cells["产权所有人2"].Value.ToString();
                                entity.Owner3 = row.Cells["产权所有人3"].Value.ToString();
                                entity.Owner4 = row.Cells["产权所有人4"].Value.ToString();
                                entity.Owner5 = row.Cells["产权所有人5"].Value.ToString();
                                entity.ShortChar1 = row.Cells["网格名称"].Value.ToString();
                                entity.ShortChar2 = row.Cells["网格员"].Value.ToString();
                                entity.Memo = row.Cells["备注"].Value.ToString();
                                entity.TenantId = TenantId;
                                entity.CategoryId = CateId;
                                ObjServ.Reposity.Insert(entity);
                                #endregion
                            }

                        }
                        catch (Exception ex)
                        {
                            errorRow++;
                            this.BeginInvoke(new Action(() =>
                            {
                                textBoxError.Text += "导入[" + houseName + unitNum + doorCard + "]发生错误：" + ex.Message + "      ";
                            }));
                        }
                        compRow++;
                        this.BeginInvoke(new Action(() =>
                        {
                            progressBarM.Value = compRow > progressBarM.Maximum ? progressBarM.Maximum : compRow;
                            labelCount.Text = "完成：" + progressBarM.Value + "/" + totalRow;
                            labelError.Text = "错误：" + (errorRow > progressBarM.Maximum ? progressBarM.Maximum : errorRow);
                            toolBtnUpload.Enabled = progressBarM.Value == totalRow;
                            if (totalRow == progressBarM.Value)
                            {
                                XtraMessageBox.Show("导入完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }));
                    }
                }
                ObjServ.Dispose();
            });

        }
        private void toolBtnSelectFile_Click(object sender, EventArgs e)
        {
            compRow = 0;
            errorRow = 0;
            textBoxError.Text = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "Excel文件|*.xls";
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.toolFilePath.Text = file.FileName;
                var ds = ExcelHelper.ImportFromExcel(file.FileName, 0);
                if (tabControlMain.SelectedIndex == 0)
                {
                    dgvMain.DataSource = ds.Tables[0];
                    XtraDgvMain.DataSource = ds.Tables[0];
                }
                else
                    dgvHouse.DataSource = ds.Tables[0];
                totalRow = ds.Tables[0].Rows.Count;
                labelCount.Text = "完成：" + compRow + "/" + totalRow;
                progressBarM.Maximum = totalRow;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            labelCount.Text = "完成：" + compRow + "/" + totalRow;
            labelError.Text = "错误：" + errorRow;
            progressBarM.Value = compRow;
        }

        private void toolBtnRefresh_Click(object sender, EventArgs e)
        {
            textBoxError.Text = "";
            if (tabControlMain.SelectedIndex == 1)
            {
                using (HouseService objserv = new HouseService())
                {
                    var resp = objserv.Reposity.GetAllList(o => o.TenantId == TenantId);
                    if (resp != null)
                    {
                        labelTotal.Text = "总共：" + resp.Count;
                        var lists = Mapper.Map<List<Dto.HouseDto>>(resp);
                        dgvHouse.DataSource = AppBase.ToDataTable<Dto.HouseDto>(lists);
                        SetHeaderHs();
                    }
                }
            }
            else
            {
                using (MembersService members = new MembersService())
                {
                    var resp = members.Reposity.GetAllList(o => o.TenantId == TenantId && o.IsReger == false);
                    if (resp != null)
                    {
                        labelTotal.Text = "总共：" + resp.Count;
                        var lists = Mapper.Map<List<Dto.MemberOutDto>>(resp);
                        //dgvMain.DataSource = AppBase.ToDataTable<Dto.MemberOutDto>(lists);
                        XtraDgvMain.DataSource = lists;
                        SetHeader();
                    }
                }
            }

        }
        private void SetHeader()
        {
            //dgvMain.Columns[3].Frozen = true;
            string[] headerArr = ("ID|姓名|关系|性别|民族|年龄|楼盘|单元|门牌号|身份证号|出生年月|现户籍地址|原户籍地址|是否兴塘社区户籍|服务处所|职务|联系电话1|联系电话2|政治面貌|党员所在支部|是否楼道组长|是否户代表|是否居民代表|是否居民组长|是否愿意参加公益|是否愿意从事居民事务|调查时间|特长备注").Split('|');
            XtraGridViewM.Columns[0].Visible = false;
            
            for (int i = 0; i < headerArr.Length; i++)
            {
                //dgvMain.Columns[i].HeaderCell.Value = headerArr[i];
                XtraGridViewM.Columns[i].Caption = headerArr[i];
            }
        }

        private void SetHeaderHs()
        {
            dgvHouse.Columns[3].Frozen = true;
            string[] headerArr = ("楼盘名称|单元号|门牌号|房屋属性|房屋面积|销售状态|已建未建|产权所有人1|产权所有人2|产权所有人3|产权所有人4|产权所有人5|网格名称|网格员|备注").Split('|');
            for (int i = 0; i < headerArr.Length; i++)
            {
                dgvHouse.Columns[i].HeaderCell.Value = headerArr[i];
            }
        }

        private void toolBtnDownload_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                ExcelHelper.ExportToExcel(dgvMain);
            else
                ExcelHelper.ExportToExcel(dgvHouse);
        }

        private void toolBtnValid_Click(object sender, EventArgs e)
        {
            DataGridView DGV = dgvMain;
            string[] CellArr = ("姓名|关系|性别|民族|年龄|楼盘|单元|门牌号|身份证号|现户籍地址|原户籍地址|是否兴塘社区户籍|服务处所|职务|联系电话1|联系电话2|政治面貌|党员所在支部|是否楼道组长|是否户代表|是否居民代表|是否居民组长|是否愿意参加公益|是否愿意从事居民事务|调查时间|特长备注").Split('|');
            if (tabControlMain.SelectedIndex == 1)
            {
                CellArr = ("楼盘名称|单元号|门牌号|房屋属性|房屋面积|销售状态|已建未建|产权所有人1|产权所有人2|产权所有人3|产权所有人4|产权所有人5|网格名称|网格员|备注").Split('|');
                DGV = dgvHouse;
            }
            List<string> columlist = new List<string>();
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                columlist.Add(DGV.Columns[i].Name);
            }
            bool isvalid = true;
            foreach (string item in CellArr)
            {
                if (!columlist.Contains(item))
                {
                    XtraMessageBox.Show("缺少必要字段" + item, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isvalid = false;
                    break;
                }
            }
            if (isvalid)
            {
                XtraMessageBox.Show("验证通过！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolBtnUpload.Enabled = true;
            }
            else
                toolBtnUpload.Enabled = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
