using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasColumnName("FirstName");
            builder.Property(u => u.LastName).HasColumnName("LastName");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(u => u.Status).HasColumnName("Status");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(u => u.UserOperationClaims)
              .WithOne(uoc => uoc.User)
              .HasForeignKey(uoc => uoc.UserId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
