using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cardPortal.Models;

namespace cardPortal.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Todo> Todos { get; set; }

        
    }
}
