using Microsoft.EntityFrameworkCore;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Domain.Permissions;
using N5Challenge.Infrastructure.Common;

namespace N5Challenge.Infrastructure.Permissions
{
    public class PermissionRepository(AppDbContext _dbContext) : IPermissionRepository
    {
        public async Task AddAsync(Permission permission, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(permission, cancellationToken);
        }

        public async Task<List<Permission>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Permissions.ToListAsync(cancellationToken);
        }

        public async Task<Permission?> GetPermission(Permission permission, CancellationToken cancellationToken)
        {
            return await _dbContext.Permissions
                .Where(p => p.EmployeeName == permission.EmployeeName && p.EmployeeSurname == permission.EmployeeSurname && p.PermissionTypeId == permission.PermissionTypeId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Permission?> GetPermissionById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Permissions.FindAsync(id, cancellationToken);
        }

        public async Task Update(Permission permission)
        {
            _dbContext.Update(permission);
        }
    }
}
