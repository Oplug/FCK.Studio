using FCK.Studio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Core
{
    [Table("Tenants")]
    public class Tenants : Entity<int>,IHasCreationTime
    {
        [MaxLength(50)]
        public string TenantName { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public Guid SecretKey { get; set; }
        [MaxLength(50)]
        public string AppDomain { get; set; }
        public bool IsRoot { get; set; }
        [MaxLength(50)]
        public string WXAppId { get; set; }
        [MaxLength(50)]
        public string WXAppSecret { get; set; }
        [Column(TypeName = "ntext")]
        public string TenantConfig { get; set; }

        public DateTime CreationTime { get; set; }
        public Tenants()
        {
            CreationTime = DateTime.Now;
        }
    }
}
