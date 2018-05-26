using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Election")]
    public class Election : Entity<int>, IHasCreationTime, IMustHaveTenant
    {
        [Column(TypeName = "text")]
        public string Voter { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }
        [MaxLength(500)]
        public string Photo { get; set; }
        public int TenantId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Candidate { get; set; }
        public int NumOfVote { get; set; }
        public bool IsOpen { get; set; }
    }
}
