using elearning.src.StudentParticipation.Enrollment.Domain;
using EnrollmentAggregate = elearning.src.StudentParticipation.Enrollment.Domain.Enrollment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Persistence.Mapping
{
    public class EnrollmentMap : IEntityTypeConfiguration<EnrollmentAggregate>
    {
        public void Configure(EntityTypeBuilder<EnrollmentAggregate> builder)
        {
            builder.ToTable("enrollment");
            builder.HasKey(c => c.id);

            builder
                .Property(c => c.id)
                .HasColumnType("nvarchar(36)")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.progress)
                .HasColumnType("tinyint(100)")
                .HasColumnName("progress")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentProgress(v)
                )
                .IsRequired();

            builder
                .Property(c => c.courseId)
                .HasColumnType("nvarchar(36)")
                .HasColumnName("course_id")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentCourseId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.studentId)
                .HasColumnType("nvarchar(36)")
                .HasColumnName("student_id")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentStudentId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.createdAt)
                .HasColumnType("datetime2")
                .HasColumnName("created_at")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentCreatedAt(v)
                )
                .IsRequired();

            builder
                .Property(c => c.updatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updated_at")
                .HasConversion(
                    v => v.Value,
                    v => new EnrollmentUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
