using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Entities.User;

namespace ProjectX.Storage.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Embg).HasColumnName("Embg").HasMaxLength(255).IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(255).IsRequired();
            builder.Property(x => x.DateOfEmployment).HasColumnName("DateOfEmployment").HasColumnType("datetime2");

            builder.Property(x => x.DriversCertificateSerialNumber).HasColumnName("DriversCertificateSerialNumber").HasMaxLength(255);
            builder.Property(x => x.DriversCertificateIssueDate).HasColumnName("DriversCertificateIssueDate").HasColumnType("datetime2");
            builder.Property(x => x.DriversCertificateExpiryDate).HasColumnName("DriversCertificateExpiryDate").HasColumnType("datetime2");

            builder.Property(x => x.DrivingLicenseSerialNumber).HasColumnName("DrivingLicenseSerialNumber").HasMaxLength(255);
            builder.Property(x => x.DrivingLicenseIssueDate).HasColumnName("DrivingLicenseIssueDate").HasColumnType("datetime2");
            builder.Property(x => x.DrivingLicenseExpiryDate).HasColumnName("DrivingLicenseExpiryDate").HasColumnType("datetime2");

            builder.Property(x => x.PassportSerialNumber).HasColumnName("PassportSerialNumber").HasMaxLength(255);
            builder.Property(x => x.PassportIssueDate).HasColumnName("PassportIssueDate").HasColumnType("datetime2");
            builder.Property(x => x.PassportExpiryDate).HasColumnName("PassportExpiryDate").HasColumnType("datetime2");

            builder.Property(x => x.IdentityCardSerialNumber).HasColumnName("IdentityCardSerialNumber").HasMaxLength(255);
            builder.Property(x => x.IdentityCardIssueDate).HasColumnName("IdentityCardIssueDate").HasColumnType("datetime2");
            builder.Property(x => x.IdentityCardExpiryDate).HasColumnName("IdentityCardExpiryDate").HasColumnType("datetime2");

            builder.Property(x => x.TruckId).HasColumnName("TruckId").HasColumnType("int");
            builder.Property(x => x.CompanyId).HasColumnName("CompanyId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Truck).WithMany(x => x.Users).HasForeignKey(x => x.TruckId);
            builder.HasOne(x => x.Company).WithMany(x => x.Users).HasForeignKey(x => x.CompanyId);
        }
    }
}
