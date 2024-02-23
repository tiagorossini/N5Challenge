using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Challenge.Domain.PermissionTypes;

namespace N5Challenge.Infrastructure.PermissionTypes
{
    public class PermissionTypeConfigurations : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description).IsRequired().HasMaxLength(50);
        }
    }
}
