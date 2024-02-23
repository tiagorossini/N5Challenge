using ErrorOr;
using MediatR;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Commands.RequestPermission
{
    public record RequestPermissionCommand(string EmployeeName, string EmployeeSurname, int PermissionTypeId) : IRequest<ErrorOr<Permission>>;
    
}
