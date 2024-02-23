using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Infrastructure.Permissions
{
    public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(p => p.PermissionType).WithMany().HasForeignKey(p => p.PermissionTypeId);

            builder.Property(r => r.EmployeeName).IsRequired().HasMaxLength(60);

            builder.Property(r => r.EmployeeSurname).IsRequired().HasMaxLength(80);

            builder.Property(r => r.PermissionTypeId).IsRequired();

            builder.Property(r => r.GrantedDate).IsRequired();
        }
    }
}
