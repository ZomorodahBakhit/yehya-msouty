using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp1.Models;
namespace ConsoleApp1
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasOne(g => g.Assignment)
            .WithMany()
            .HasForeignKey(g => g.AssignmentId);

            builder.HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentId);
        }
    }
}
