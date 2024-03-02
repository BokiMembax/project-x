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
            builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(255).IsRequired();

            builder.Property(x => x.CompanyId).HasColumnName("CompanyId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Company).WithMany(x => x.Users).HasForeignKey(x => x.CompanyId);
        }
    }
}
