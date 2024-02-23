using FluentAssertions;
using N5Challenge.Application.Permissions.Commands.RequestPermission;
using N5Challenge.Domain.Permissions;

namespace TestCommon.Permissions
{
    public static class PermissionValidator
    {
        public static void AssertCreatedFrom(this Permission permission, RequestPermissionCommand command)
        {
            permission.EmployeeName.Should().Be(command.EmployeeName);
            permission.EmployeeSurname.Should().Be(command.EmployeeSurname);
            permission.PermissionTypeId.Should().Be(command.PermissionTypeId);
        }
    }
}
