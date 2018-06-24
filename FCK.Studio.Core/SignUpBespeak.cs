using FCK.Studio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Core
{
    [Table("SignUpBespeak")]
    public class SignUpBespeak : Entity<long>, IHasCreationTime, IMustHaveTenant
    {
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Telphone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string QQ { get; set; }
        [MaxLength(50)]
        public string IDCardNo { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [DefaultValue(0)]
        public bool IsMarry { get; set; }
        [MaxLength(10)]
        public string CulturalLevel { get; set; }
        [MaxLength(10)]
        public string PoliticalStatus { get; set; }
        [MaxLength(50)]
        public string ActvTitle { get; set; }        
        public long ActvID { get; set; }
        public string Memo { get; set; }
        public DateTime CreationTime { get; set; }
        public int TenantId { get; set; }
        [MaxLength(50)]
        public string MemberName { get; set; }

        public SignUpBespeak()
        {
            CreationTime = DateTime.Now;
        }
    }
}
