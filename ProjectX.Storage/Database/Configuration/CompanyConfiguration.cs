using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Entities.Company;

namespace ProjectX.Storage.Database.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Embs).HasColumnName("Embs").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Address).HasColumnName("Address").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Users).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
