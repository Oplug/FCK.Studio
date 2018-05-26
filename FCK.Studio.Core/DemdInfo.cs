using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("DemdInfo")]
    public class DemdInfo : Entity<long>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>
    {
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }
        [Column(TypeName = "text")]
        public string Contents { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public int CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public virtual Members Members { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }
        [MaxLength(50)]
        public string Keywords { get; set; }
        [MaxLength(50)]
        public string Tags { get; set; }

        [Required]
        public int TenantId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public string Contactor { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string QQ { get; set; }
        [MaxLength(50)]
        public string Weixin { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [DefaultValue(0)]
        public int Hits { get; set; }
        public bool IsChecked { get; set; }
    }
}
