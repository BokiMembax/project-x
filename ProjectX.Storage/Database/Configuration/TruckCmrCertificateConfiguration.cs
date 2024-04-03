﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Storage.Entities.CmrCertificate;

namespace ProjectX.Storage.Database.Configuration
{
    public class TruckCmrCertificateConfiguration : IEntityTypeConfiguration<TruckCmrCertificate>
    {
        public void Configure(EntityTypeBuilder<TruckCmrCertificate> builder)
        {
            builder.ToTable("TruckCmrCertificate", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName("IsExpired").IsRequired();

            builder.Property(x => x.TruckId).HasColumnName("TruckId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Truck).WithMany(x => x.CmrCertificates).HasForeignKey(x => x.TruckId);
        }
    }
}
