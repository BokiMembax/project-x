using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Queries.Entities.Trailer;

namespace ProjectX.Queries.Database.Configuration
{
    public class TrailerConfiguration : IEntityTypeConfiguration<Trailer>
    {
        public void Configure(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Vin).HasColumnName("Vin").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ManufacturedOn).HasColumnName("ManufacturedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.Registration).HasColumnName("Registration").HasMaxLength(255).IsRequired();
            builder.Property(x => x.RegistrationExpiryDate).HasColumnName("RegistrationExpiryDate").HasColumnType("datetime2");

            builder.Property(x => x.CompanyId).HasColumnName("CompanyId").HasColumnType("int").IsRequired();
            builder.Property(x => x.TruckId).HasColumnName("TruckId").HasColumnType("int");

            builder.HasOne(x => x.Company).WithMany(x => x.Trailers).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.Truck).WithOne().HasForeignKey<Trailer>(x => x.TruckId);
            builder.HasMany(x => x.CemtCertificates).WithOne(x => x.Trailer).HasForeignKey(x => x.TrailerId);
            builder.HasMany(x => x.GreenCardCertificates).WithOne(x => x.Trailer).HasForeignKey(x => x.TrailerId);
            builder.HasMany(x => x.YellowCertificates).WithOne(x => x.Trailer).HasForeignKey(x => x.TrailerId);
            builder.HasMany(x => x.Users).WithOne(x => x.Trailer).HasForeignKey(x => x.TrailerId);
        }
    }
}
