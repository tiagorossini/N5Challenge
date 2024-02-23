using ErrorOr;
using MediatR;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler(IPermissionRepository _permissionRepository) : IRequestHandler<GetAllPermissionsQuery, ErrorOr<List<Permission>>>
    {
        public async Task<ErrorOr<List<Permission>>> Handle(GetAllPermissionsQuery query, CancellationToken cancellationToken)
        {
			try
			{
				var permissions = await _permissionRepository.GetAll(cancellationToken);

				return permissions;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
