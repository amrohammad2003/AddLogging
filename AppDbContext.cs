using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF010.CodeFirstMigration.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}