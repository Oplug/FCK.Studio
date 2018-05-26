using FCK.Studio.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Products")]
    public class Products : Entity<long>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>
    {
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }
        [Column(TypeName = "text")]
        public string Contents { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }
        [MaxLength(50)]
        public string Keywords { get; set; }
        [MaxLength(50)]
        public string Tags { get; set; }

        public int TenantId { get; set; }
        [Required, MaxLength(500)]
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Pictures { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public virtual Members Members { get; set; }
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
        [MaxLength(20)]
        public string Apartment { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Contactor { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string QQ { get; set; }
        [MaxLength(50)]
        public string Weixin { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [MaxLength(50)]
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [MaxLength(50)]
        public string Latitude { get; set; }
        public Products()
        {
            CreationTime = DateTime.Now;
        }
    }
}
