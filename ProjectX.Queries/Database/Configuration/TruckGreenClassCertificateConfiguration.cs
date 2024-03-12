using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Queries.Entities.GreenClassCertificate;

namespace ProjectX.Queries.Database.Configuration
{
    public class TruckGreenClassCertificateConfiguration : IEntityTypeConfiguration<TruckGreenClassCertificate>
    {
        public void Configure(EntityTypeBuilder<TruckGreenClassCertificate> builder)
        {
            builder.ToTable("GreenClassCertificate", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName("IsExpired").IsRequired();

            builder.Property(x => x.EmissionClassId).HasColumnName("EmissionClassId").HasColumnType("int");

            builder.HasOne(x => x.EmissionClass).WithOne().HasForeignKey<TruckGreenClassCertificate>(x => x.EmissionClassId);
        }
    }
}
