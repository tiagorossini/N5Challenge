using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5Challenge.Application.Permissions.Commands.ModifyPermission;
using N5Challenge.Application.Permissions.Commands.RequestPermission;
using N5Challenge.Application.Permissions.Queries.GetAllPermissions;
using N5Challenge.Contracts.Permissions;
using N5Challenge.Domain.Permissions;

namespace N5Challenge.Api.Controllers
{
    [Route("[controller]")]
    public class PermissionsController(ISender _mediator) : ApiController
    {
        [HttpPost("Request")]
        public async Task<IActionResult> RequestPermission(RequestPermissionRequest request)
        {
            var command = new RequestPermissionCommand(request.EmployeeName, request.EmployeeSurname, request.PermissionTypeId);
            var result = await _mediator.Send(command);

            return result.Match(
                permission => Ok(ToDto(permission)),
                Problem);
        }

        [HttpPut("Modify")]
        public async Task<IActionResult> ModifyPermission(ModifyPermissionRequest request)
        {
            var command = new ModifyPermissionCommand(request.PermissionId, request.EmployeeName, request.EmployeeSurname, request.PermissionTypeId);
            var result = await _mediator.Send(command);

            return result.Match(
                permission => Ok(ToDto(permission)),
                Problem);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var query = new GetAllPermissionsQuery();
            var result = await _mediator.Send(query);

            return result.Match(
                permissions => Ok(permissions.ConvertAll(ToDto)),
                Problem);
        }

        private PermissionResponse ToDto(Permission permission) =>
        new(permission.EmployeeName, permission.EmployeeSurname, permission.PermissionTypeId, permission.GrantedDate);
    }
}
