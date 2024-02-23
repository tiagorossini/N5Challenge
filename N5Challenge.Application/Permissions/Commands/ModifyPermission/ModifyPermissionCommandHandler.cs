using ErrorOr;
using MediatR;
using N5Challenge.Application.Common.DTO;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Permissions.Commands.ModifyPermission
{
    public class ModifyPermissionCommandHandler(IPermissionRepository _permissionRepository, IUnitOfWork _unitOfWork, IElasticsearchService<ElasticRegistryDTO> _elasticsearchService) 
        : IRequestHandler<ModifyPermissionCommand, ErrorOr<Permission>>
    {
        public async Task<ErrorOr<Permission>> Handle(ModifyPermissionCommand command, CancellationToken cancellationToken)
        {
			try
			{
				var permission = await _permissionRepository.GetPermissionById(command.PermissionId, cancellationToken);

				if(permission is null)
				{
                    return Error.NotFound(description: "The indicated permission was not found.");
                }

				permission.Update(command.EmployeeName, command.EmployeeSurname, command.PermissionTypeId);

				await _permissionRepository.Update(permission);
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
