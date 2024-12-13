using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable(nameof(UserOperationClaim)).HasKey(uoc => uoc.Id);
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
            builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(uoc => uoc.User)
              .WithMany(u => u.UserOperationClaims)
              .HasForeignKey(uoc => uoc.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uoc => uoc.OperationClaim)
              .WithMany()
              .HasForeignKey(uoc => uoc.OperationClaimId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
