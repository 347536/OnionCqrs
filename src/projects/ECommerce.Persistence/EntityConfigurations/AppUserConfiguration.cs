using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ECommerce.Persistence.EntityConfigurations;
public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable(nameof(AppUser));
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(a => a.Orders)
          .WithOne(o => o.User)
          .HasForeignKey(o => o.UserId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
