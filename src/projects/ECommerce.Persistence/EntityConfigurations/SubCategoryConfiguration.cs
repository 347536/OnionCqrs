using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable(nameof(SubCategory)).HasKey(sc => sc.Id);
        builder.Property(sc => sc.Name).HasColumnName("Name");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(sc => sc.Category)
          .WithMany(c => c.SubCategories)
          .HasForeignKey(sc => sc.CategoryId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}
