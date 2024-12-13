using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable(nameof(ProductImage)).HasKey(pi => pi.Id);
        builder.Property(pi => pi.Url).HasColumnName("Url").IsRequired();
        builder.Property(pi => pi.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(pi => pi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pi => pi.DeletedDate).HasColumnName("DeletedDate");

        builder
          .HasOne(pi => pi.Product)
          .WithMany(p => p.ProductImages)
          .HasForeignKey(pi => pi.ProductId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
