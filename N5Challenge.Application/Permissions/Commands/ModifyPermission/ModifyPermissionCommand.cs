using ErrorOr;
using MediatR;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Commands.ModifyPermission
{
    public record ModifyPermissionCommand(int PermissionId, string? EmployeeName, string? EmployeeSurname, int PermissionTypeId) : IRequest<ErrorOr<Permission>>;
}
