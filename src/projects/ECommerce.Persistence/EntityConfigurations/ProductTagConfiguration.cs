using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable(nameof(ProductTag)).HasKey(pt => pt.Id);
        builder.Property(pt => pt.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(pt => pt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pt => pt.DeletedDate).HasColumnName("DeletedDate");

        builder
          .HasOne(pt => pt.Product)
          .WithMany(p => p.ProductTags)
          .HasForeignKey(pt => pt.ProductId)
          .OnDelete(DeleteBehavior.Cascade);

        builder
          .HasOne(pt => pt.Tag)
          .WithMany(t => t.ProductTags)
          .HasForeignKey(pt => pt.TagId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
