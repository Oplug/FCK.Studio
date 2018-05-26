namespace FCK.Studio.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Core;

    public partial class FCKStudioDbContext : DbContext
    {
        public FCKStudioDbContext(string ConnStr = "FCKStudioDbContext")
            : base("name=" + ConnStr + "")
        {
        }
        public FCKStudioDbContext()
            : base("name=FCKStudioDbContext")
        {
        }
        public virtual IDbSet<Articles> Articles { get; set; }
        public virtual IDbSet<Products> Products { get; set; }
        public virtual IDbSet<Categories> Categories { get; set; }
        public virtual IDbSet<Admins> Admins { get; set; }
        public virtual IDbSet<Members> Members { get; set; }
        public virtual IDbSet<Tenants> Tenants { get; set; }
        public virtual IDbSet<Comments> Comments { get; set; }
        public virtual IDbSet<SignUpBespeak> SignUpBespeak { get; set; }
        public virtual IDbSet<DemdInfo> DemdInfo { get; set; }
        public virtual IDbSet<Election> Election { get; set; }
        public virtual IDbSet<CreditRecords> CreditRecords { get; set; }
        public virtual IDbSet<Houses> Houses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
