using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Queries.Entities.Tachograph;

namespace ProjectX.Queries.Database.Configuration
{
    public class TachographConfiguration : IEntityTypeConfiguration<Tachograph>
    {
        public void Configure(EntityTypeBuilder<Tachograph> builder)
        {
            builder.ToTable("Tachograph", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName("IsExpired").IsRequired();

            builder.Property(x => x.TruckId).HasColumnName("TruckId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Truck).WithMany(x => x.Tachographs).HasForeignKey(x => x.TruckId);
        }
    }
}
