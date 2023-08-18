using elearning.src.CourseAdministration.Course.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseAggregate = elearning.src.CourseAdministration.Course.Domain.Course;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Persistence.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<CourseAggregate>
    {
        public void Configure(EntityTypeBuilder<CourseAggregate> builder)
        {
            builder.ToTable("course");
            builder.HasKey(c => c.id);

            builder
                .Property(c => c.id)
                .HasColumnType("nvarchar(36)")
                .HasConversion(
                    v => v.Value,
                    v => new CourseId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.name)
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.Value,
                    v => new CourseName(v)
                )
                .IsRequired();

            builder
                .Property(c => c.description)
                .HasColumnType("nvarchar(100)")
                .HasConversion(
                    v => v.Value,
                    v => new CourseDescription(v)
                )
                .IsRequired();

            builder
                .Property(c => c.status)
                .HasColumnType("nvarchar(10)")
                .HasColumnName("status")
                .HasConversion(
                    v => v.Value,
                    v => new CourseStatus(v)
                )
                .IsRequired();

            builder
                .Property(c => c.teacherId)
                .HasColumnType("nvarchar(36)")
                .HasColumnName("teacher_id")
                .HasConversion(
                    v => v.Value,
                    v => new CourseTeacherId(v)
                )
                .IsRequired();
        }
    }
}
