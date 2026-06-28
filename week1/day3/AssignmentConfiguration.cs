using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AssignmentTitle).IsRequired();
            builder.Property(c => c.Weight).IsRequired();
            builder.Property(c => c.MaxGrade).IsRequired();
            builder.Property(c => c.DueDate).IsRequired();

            builder.HasMany(a => a.Comments)
                .WithOne(c => c.Assignment)
                .HasForeignKey(c => c.AssignmentId);
        }
    }
}
