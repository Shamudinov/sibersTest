using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SibersTest.DAL.Seeds;
using SibersTest.DAL.Entities;
using System.Reflection;

namespace SibersTest.DAL.DbContext
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }

            private AppConfiguration settings { get; set; }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
        }

        public DatabaseContext() : base()
        {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectsUsers { get; set; }
        public DbSet<UTask> Tasks { get; set; }


        public static OptionBuild ops = new OptionBuild();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

    }
}
