using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(nameof(OrderItem)).HasKey(oi => oi.Id);
        builder.Property(oi => oi.Count).HasColumnName("Count").IsRequired();
        builder.Property(oi => oi.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(oi => oi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oi => oi.DeletedDate).HasColumnName("DeletedDate");

        builder
          .HasOne(oi => oi.Order)
          .WithMany(o => o.OrderItems)
          .HasForeignKey(oi => oi.OrderId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
