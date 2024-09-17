﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Queries.Entities.CemtCertificate;

namespace ProjectX.Queries.Database.Configuration
{
    public class TrailerCemtCertificateConfiguration : IEntityTypeConfiguration<TrailerCemtCertificate>
    {
        public void Configure(EntityTypeBuilder<TrailerCemtCertificate> builder)
        {
            builder.ToTable("TrailerCemtCertificate", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.IsExpired).HasColumnName("IsExpired").IsRequired();

            builder.Property(x => x.TrailerId).HasColumnName("TrailerId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Trailer).WithMany(x => x.CemtCertificates).HasForeignKey(x => x.TrailerId);
        }
    }
}