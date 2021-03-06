﻿using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Tools.Dto
{
    public class MemberOutDto
    {
        public int Id { get; set; }
        public string TrueName { get; set; }
        public string Relations { get; set; }
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }
        public int Age { get; set; }
        public string Apartment { get; set; }
        public string UnitNum { get; set; }
        public string DoorCard { get; set; }
        public string UserID { get; set; }        
        public string Birthday { get; set; }        
        public string Address { get; set; }
        public string Address2 { get; set; }
        /// <summary>
        /// 是否户籍户口
        /// </summary>
        public bool HhdRegister { get; set; }
        /// <summary>
        /// 服务处所，8-28周岁需填写入学学校、年级、班级，其他填工作单位
        /// </summary>
        public string ServiceAddr { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string Duties { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string PoliticalRole { get; set; }
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
        public string UpdateTime { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        public string Speciality { get; set; }
    }

    public class HouseDto
    {
        public string HouseName { get; set; }
        public string UnitNum { get; set; }
        public string DoorCard { get; set; }
        public string HouseType { get; set; }
        public string HouseArea { get; set; }
        public string SaleStatus { get; set; }
        public string BuildStatus { get; set; }
        public string Owner { get; set; }
        public string Owner2 { get; set; }
        public string Owner3 { get; set; }
        public string Owner4 { get; set; }
        public string Owner5 { get; set; }       
        public string ShortChar1 { get; set; }
        public string ShortChar2 { get; set; }
        public string Memo { get; set; }
    }
}
