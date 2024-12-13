using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order)).HasKey(o => o.Id);
        builder.Property(o => o.Total).HasColumnName("Total").IsRequired();
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder
          .HasOne(o => o.User)
          .WithMany(u => u.Orders)
          .HasForeignKey(o => o.UserId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
