using elearning.src.IAM.User.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elearning.src.IAM.User.Infrastructure.Persistence.Mapping
{
    public class UserMap : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.id);

            builder
                .Property(c => c.id)
                .HasColumnType("nvarchar(36)")
                .HasConversion(
                    v => v.Value,
                    v => new UserId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.email)
                .HasColumnType("nvarchar(60)")
                .HasConversion(
                    v => v.Value,
                    v => new UserEmail(v)
                )
                .IsRequired();

            builder
                .Property(c => c.password)
                .HasColumnType("nvarchar(90)")
                .HasConversion(
                    v => v.Value,
                    v => new UserHashedPassword(v)
                )
                .IsRequired();

            builder
                .Property(c => c.firstName)
                .HasColumnType("nvarchar(15)")
                .HasColumnName("first_name")
                .HasConversion(
                    v => v.Value,
                    v => new UserFirstName(v)
                )
                .IsRequired();

            builder
                .Property(c => c.lastName)
                .HasColumnType("nvarchar(30)")
                .HasColumnName("last_name")
                .HasConversion(
                    v => v.Value,
                    v => new UserLastName(v)
                )
                .IsRequired();

            builder
                .Property(c => c.role)
                .HasColumnType("nvarchar(15)")
                .HasConversion(
                    v => v.Value,
                    v => new UserRole(v)
                )
                .IsRequired();

            builder
                .Property(c => c.createdAt)
                .HasColumnType("datetime2")
                .HasColumnName("created_at")
                .HasConversion(
                    v => v.Value,
                    v => new UserCreatedAt(v)
                )
                .IsRequired();

            builder
                .Property(c => c.updatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updated_at")
                .HasConversion(
                    v => v.Value,
                    v => new UserUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
