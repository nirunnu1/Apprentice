using Jobb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jobb
{
    public partial class MyContext : DbContext
    {
        public MyContext() : base(nameOrConnectionString: "sqlcon") { }

        
        public DbSet<meeting> meeting { get; set; }
        public DbSet<profile> profile { get; set; }

        public DbSet<company> company { get; set; }
        public DbSet<resume> resume { get; set; }
        public DbSet<regis> regis { get; set; }
        public DbSet<add_apprentice> add_apprentice { get; set; }
        public DbSet<status_proj> status_proj { get; set; }
        public DbSet<status_coop> status_coop { get; set; }
        public DbSet<supervision> supervision { get; set; }
        public DbSet<ins> ins { get; set; }

    }
}
