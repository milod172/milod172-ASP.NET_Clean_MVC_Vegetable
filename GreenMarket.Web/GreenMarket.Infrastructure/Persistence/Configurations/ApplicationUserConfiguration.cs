using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.Transactions)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);

            builder.HasData(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "4cb5df7e-135d-42cf-8723-f40f0c919e2c",
                    FullName = "System Admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",                 
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0932100437",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1"),
                    LockoutEnabled = true,
                 },
                new ApplicationUser
                {
                    Id = "41d2d46d-6c0d-4fcc-86fe-ba65362fe40c",
                    FullName = "Nguyễn Xuân Dũng",
                    UserName = "milod",
                    NormalizedUserName = "MILOD",
                    Email = "ngxdung172@gmail.com",
                    NormalizedEmail = "NGXDUNG172@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0932100437",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1"),
                    LockoutEnabled = true,
                }
             });
        }
    }
}