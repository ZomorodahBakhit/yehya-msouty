using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Data.Entities;

namespace University.Data.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).ValueGeneratedOnAdd();


            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(s => s.Weight)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
