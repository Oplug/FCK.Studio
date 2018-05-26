using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("CreditRecords")]
    public class CreditRecords : Entity<int>, IMustHaveTenant,ISoftDelete
    {
        public int TenantId { get; set; }
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Members Members { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Contents { get; set; }
        [MaxLength(500)]
        public string Images { get; set; }
        public int Points { get; set; }
        public bool IsDeleted { get; set; }
    }
}
