using N5Challenge.Domain.Permissions;

namespace N5Challenge.Application.Common.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetPermission(Permission permission, CancellationToken cancellationToken);
        Task<Permission?> GetPermissionById(int id, CancellationToken cancellationToken);
        Task AddAsync(Permission permission, CancellationToken cancellationToken);
        Task Update(Permission permission);
        Task<List<Permission>> GetAll(CancellationToken cancellationToken);
    }
}
