using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Storage.Entities.YellowCertificate;

namespace ProjectX.Storage.Database.Configuration
{
    public class TrailerYellowCertificateConfiguration : IEntityTypeConfiguration<TrailerYellowCertificate>
    {
        public void Configure(EntityTypeBuilder<TrailerYellowCertificate> builder)
        {
            builder.ToTable("TrailerYellowCertificate", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName("IsExpired").IsRequired();

            builder.HasOne(x => x.Trailer).WithMany(x => x.YellowCertificates).HasForeignKey(x => x.TrailerId);
        }
    }
}
