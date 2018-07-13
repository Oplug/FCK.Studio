using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Members")]
    public class Members : Entity<int>, IHasCreationTime, IMustHaveTenant
    {
        /// <summary>
        /// 身份证
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string UserID { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(20)]
        public string NickName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string TrueName { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        [MaxLength(20)]
        public string Relations { get; set; }
        [MaxLength(2)]
        public string Sex { get; set; }
        [MaxLength(50)]
        public string Birthday { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [MaxLength(20)]
        public string Nation { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        [MaxLength(20)]
        public string Country { get; set; }
        /// <summary>
        /// 省/州
        /// </summary>
        [MaxLength(20)]
        public string State { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [MaxLength(20)]
        public string City { get; set; }
        /// <summary>
        /// 行政区
        /// </summary>
        [MaxLength(20)]
        public string District { get; set; }
        /// <summary>
        /// 社区
        /// </summary>
        [MaxLength(20)]
        public string Community { get; set; }
        /// <summary>
        /// 公寓名称/小区楼盘
        /// </summary>
        [MaxLength(20)]
        public string Apartment { get; set; }
        [MaxLength(10)]
        public string UnitNum { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        [MaxLength(20)]
        public string DoorCard { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        [MaxLength(50)]
        public string Address { get; set; }
        /// <summary>
        /// 原户籍地址
        /// </summary>
        [MaxLength(50)]
        public string Address2 { get; set; }
        /// <summary>
        /// 是否户籍户口
        /// </summary>
        public bool HhdRegister { get; set; }
        /// <summary>
        /// 服务处所，8-28周岁需填写入学学校、年级、班级，其他填工作单位
        /// </summary>
        [MaxLength(50)]
        public string ServiceAddr { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [MaxLength(20)]
        public string Duties { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        [MaxLength(20)]
        public string PoliticalRole { get; set; }
        /// <summary>
        /// 党支部
        /// </summary>
        [MaxLength(50)]
        public string PartyBranch { get; set; }
        /// <summary>
        /// 楼道组长
        /// </summary>
        public bool CorridorLeader { get; set; }
        /// <summary>
        /// 户组长
        /// </summary>
        public bool HouseLeader { get; set; }
        /// <summary>
        /// 居民代表
        /// </summary>
        public bool ResidentRepresentative { get; set; }
        /// <summary>
        /// 居民组长
        /// </summary>
        public bool ResidentLeader { get; set; }
        /// <summary>
        /// 是否愿意参加公益活动
        /// </summary>
        public bool Pipwa { get; set; }
        /// <summary>
        /// 是否愿意从事居民服务
        /// </summary>
        public bool Eira { get; set; }        
        /// <summary>
        /// 特长
        /// </summary>
        [MaxLength(50)]
        public string Speciality { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Phone2 { get; set; }
        [MaxLength(20)]
        public string QQ { get; set; }
        [MaxLength(50)]
        public string QQOpenID { get; set; }
        [MaxLength(50)]
        public string WXOpenID { get; set; }
        [DefaultValue(0)]
        public int Points { get; set; }
        /// <summary>
        /// 信用等级分
        /// </summary>
        public int CreditRate { get; set; }
        public bool Approved { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        [Required]
        public int TenantId { get; set; }
        public bool IsReger { get; set; }
    }
}
