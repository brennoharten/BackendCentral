using System.Net.Mime;
using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Context
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupProfile> GroupProfiles { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityHistory> ActivityHistorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Group>(new GroupMap().Configure);
            modelBuilder.Entity<GroupProfile>(new GroupProfileMap().Configure);
            modelBuilder.Entity<Note>(new NoteMap().Configure);
            modelBuilder.Entity<Activity>(new ActivityMap().Configure);
            modelBuilder.Entity<ActivityHistory>(new ActivityHistoryMap().Configure);
        }
    }
}