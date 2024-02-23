using ErrorOr;
using MediatR;
using N5Challenge.Application.Common.DTO;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Commands.RequestPermission
{
    public class RequestPermissionCommandHandler(IPermissionRepository _permissionRepository, IUnitOfWork _unitOfWork, IElasticsearchService<ElasticRegistryDTO> _elasticsearchService) 
		: IRequestHandler<RequestPermissionCommand, ErrorOr<Permission>>
    {
        public async Task<ErrorOr<Permission>> Handle(RequestPermissionCommand command, CancellationToken cancellationToken)
        {
			try
			{
				var permission = new Permission(command.EmployeeName, command.EmployeeSurname, command.PermissionTypeId);

				var permissionAlreadyExists = await _permissionRepository.GetPermission(permission, cancellationToken);

				if(permissionAlreadyExists != null)
				{
					return Error.Conflict(description: "The permission already exists for that employee.");
				}

				await _permissionRepository.AddAsync(permission, cancellationToken);
				await _unitOfWork.SaveChangesAsync(cancellationToken);

                var elasticRegistryDTO = new ElasticRegistryDTO()
				{ Id = permission.Id, EmployeeName = permission.EmployeeName, EmployeeSurname = permission.EmployeeSurname, PermissionTypeId = permission.PermissionTypeId, GrantedDate = permission.GrantedDate.ToString("dd/MM/yyyy") };

				bool result = await _elasticsearchService.CreateRegisterAsync(elasticRegistryDTO);
				if (!result)
				{
                    return Error.Unexpected(description: "An unexpected error occurred while creating the permission registry.");
                }

                return permission;
			}
			catch (Exception)
			{
                throw;
            }
        }
    }
}
