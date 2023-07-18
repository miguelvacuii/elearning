using elearning.src.IAM.Token.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elearning.src.IAM.Token.Infrastructure.Persistence.Mapping
{
    public class TokenMap : IEntityTypeConfiguration<Domain.Token>
    {
        public void Configure(EntityTypeBuilder<Domain.Token> builder)
        {
            builder.ToTable("token");
            builder.HasKey(c => c.hash);

            builder
                .Property(c => c.hash)
                .HasColumnType("nvarchar(350)")
                .HasConversion(
                    v => v.Value,
                    v => new TokenHash(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userId)
                .HasColumnType("nvarchar(36)")
                .HasColumnName("user_id")
                .HasConversion(
                    v => v.Value,
                    v => new TokenUserId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.createdAt)
                .HasColumnType("datetime2")
                .HasColumnName("created_at")
                .HasConversion(
                    v => v.Value,
                    v => new TokenCreatedAt(v)
                )
                .IsRequired();

            builder
                .Property(c => c.updatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updated_at")
                .HasConversion(
                    v => v.Value,
                    v => new TokenUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
