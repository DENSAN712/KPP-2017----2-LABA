using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NotebookWebApp.Models
{
    public class NotebookContext : DbContext
    {
        public NotebookContext() : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}