using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Storage.Entities.EmissionClass;

namespace ProjectX.Storage.Database.Configuration
{
    public class EmissionClassConfiguration : IEntityTypeConfiguration<EmissionClass>
    {
        public void Configure(EntityTypeBuilder<EmissionClass> builder)
        {
            builder.ToTable("EmissionClass", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(255).IsRequired();
        }
    }
}
