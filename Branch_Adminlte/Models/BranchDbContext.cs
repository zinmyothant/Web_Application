using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Branch_Adminlte.Models
{
    public class BranchDbContext:DbContext
    {
        public BranchDbContext():base("name=BranchDbContext"){
        
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Branch>().ToTable("Branch");
            mb.Entity<City>().ToTable("City");
        }

    }
}