using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class MContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<dic_Statuses> Statuses { get; set; }

        public DbSet<dic_Countries> Countries { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<dic_BugStatuses> BugStatuses { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}