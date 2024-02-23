using ErrorOr;
using MediatR;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Queries.GetAllPermissions
{
    public record GetAllPermissionsQuery() : IRequest<ErrorOr<List<Permission>>>;
}
