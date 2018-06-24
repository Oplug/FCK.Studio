using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("ElectionHead")]
    public class ElectionHead : Entity<int>, IHasCreationTime, IMustHaveTenant
    {
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CandiNum { get; set; }
        public int VoteNum { get; set; }
        [Column(TypeName = "text")]
        public string Intro { get; set; }
        public int TenantId { get; set; }
        public bool IsOpen { get; set; }
    }
}
