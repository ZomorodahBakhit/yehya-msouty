using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp1.Models;
namespace ConsoleApp1
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CourseName)
           .HasMaxLength(100);

            builder.Property(c => c.TeacherId).IsRequired(false);
            builder.HasOne(c => c.Syllabus)
                .WithOne(s => s.Course)
                .HasForeignKey<Course>(c => c.SyllabusId);
        }
    }
}
