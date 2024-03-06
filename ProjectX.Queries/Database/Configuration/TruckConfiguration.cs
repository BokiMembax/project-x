using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Entities.Truck;

namespace ProjectX.Queries.Database.Configuration
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.CombinationNumber).HasColumnName("CombinationNumber").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Vin).HasColumnName("Vin").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ManufacturedOn).HasColumnName("ManufacturedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.Registration).HasColumnName("Registration").HasMaxLength(255).IsRequired();
            builder.Property(x => x.RegistrationExpiryDate).HasColumnName("RegistrationExpiryDate").HasColumnType("datetime2");

            builder.HasMany(x => x.Users).WithOne(x => x.Truck).HasForeignKey(x => x.TruckId);
        }
    }
}
