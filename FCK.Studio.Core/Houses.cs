using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Houses")]
    public class Houses : Entity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }
        [MaxLength(50)]
        public string HouseName { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        [MaxLength(50)]
        public string UnitNum { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        [MaxLength(50)]
        public string DoorCard { get; set; }
        /// <summary>
        /// 类型，住宅/商品房
        /// </summary>
        [MaxLength(8)]
        public string HouseType { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        [MaxLength(8)]
        public string HouseArea { get; set; }
        /// <summary>
        /// 销售状态
        /// </summary>
        [MaxLength(8)]
        public string SaleStatus { get; set; }
        /// <summary>
        /// 建造状态
        /// </summary>
        [MaxLength(8)]
        public string BuildStatus { get; set; }
        /// <summary>
        /// 是否户籍户
        /// </summary>
        public bool HhdRegister { get; set; }
        /// <summary>
        /// 产权所有人
        /// </summary>
        [MaxLength(50)]
        public string Owner { get; set; }
        /// <summary>
        /// 产权所有人2
        /// </summary>
        [MaxLength(50)]
        public string Owner2 { get; set; }
        /// <summary>
        /// 产权所有人3
        /// </summary>
        [MaxLength(50)]
        public string Owner3 { get; set; }
        /// <summary>
        /// 产权所有人4
        /// </summary>
        [MaxLength(50)]
        public string Owner4 { get; set; }
        /// <summary>
        /// 产权所有人5
        /// </summary>
        [MaxLength(50)]
        public string Owner5 { get; set; }
        [MaxLength(50)]
        public string Memo { get; set; }
        [MaxLength(50)]
        public string ShortChar1 { get; set; }
        [MaxLength(50)]
        public string ShortChar2 { get; set; }
    }
}
