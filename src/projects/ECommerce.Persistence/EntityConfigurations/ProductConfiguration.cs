using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product)).HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.Price).HasColumnName("Price").IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.Stock).HasColumnName("Stock").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder
          .HasOne(p => p.SubCategory)
          .WithMany(sc => sc.Products)
          .HasForeignKey(p => p.SubCategoryId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}
