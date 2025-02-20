using Microsoft.EntityFrameworkCore;
using Pixiepin.Backend.Domain.Entities.Account;

namespace Pixiepin.Backend.Persistence.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<AccountEntity> {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AccountEntity> builder) {
        _ = builder.ToTable("Accounts");
        _ = builder
                .HasIndex(a => a.Email)
                .IsUnique();
        _ = builder
                .HasIndex(a => a.Username)
                .IsUnique();
        _ = builder
                .Property(a => a.Email)
                .IsRequired(false)
                .HasColumnName("email");
        _ = builder
                .Property(a => a.Username)
                .IsRequired(true)
                .HasColumnName("username")
                .HasColumnType("varchar(20)");
        _ = builder
                .Property(a => a.Password)
                .IsRequired(true)
                .HasColumnName("password");
        _ = builder.Property(a => a.LastLoginAt)
                .IsRequired(false)
                .HasColumnName("lastLoginAt");
        _ = builder.Property(a => a.FirstName)
                .IsRequired(true)
                .HasColumnName("firstName")
                .HasColumnType("varchar(50)");
        _ = builder.Property(a => a.LastName)
                .IsRequired(true)
                .HasColumnName("lastName")
                .HasColumnType("varchar(50)");
        _ = builder.Property(a => a.CompanyName)
                .IsRequired(true)
                .HasColumnName("companyName")
                .HasColumnType("varchar(100)");
        _ = builder.Property(a => a.AccessToken)
                .IsRequired(false)
                .HasColumnName("accessToken");
        _ = builder.Property(a => a.RefreshToken)
                .IsRequired(false)
                .HasColumnName("refreshToken");
    }
}
