using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.CodeFirstMigration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);
            builder.Property(x => x.Size)
               .HasPrecision(15, 2);

            builder.ToTable("Drinks");


            builder.HasData(LoadCourses());
        }

        private static List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, Name = "Mathmatics", Price = 1000m, Size="10"},
                new Course { Id = 2, Name = "Physics", Price = 2000m,Size="1"},
                new Course { Id = 3, Name = "Chemistry", Price = 1500m,Size="32"},
                new Course { Id = 4, Name = "Biology", Price = 1200m,Size="32"},
                new Course { Id = 5, Name = "CS-50", Price = 3000m,Size="32"},
            };
        }
    }
}