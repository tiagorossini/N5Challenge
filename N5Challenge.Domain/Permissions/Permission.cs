using ErrorOr;
using N5Challenge.Domain.PermissionTypes;

namespace N5Challenge.Domain.Permissions
{
    public class Permission
    {
        public int Id { get; }
        public string EmployeeName { get; private set; }
        public string EmployeeSurname { get; private set; }
        public int PermissionTypeId { get; private set; }
        public DateTime GrantedDate { get; private set; }
        public PermissionType PermissionType { get; private set; }

        public Permission(string employeeName, string employeeSurname, int permissionTypeId)
        {
            EmployeeName = employeeName;
            EmployeeSurname = employeeSurname;
            PermissionTypeId = permissionTypeId;
            GrantedDate = DateTime.UtcNow;
        }

        public ErrorOr<Success> Update(string? employeeName, string? employeeSurname, int permissionTypeId)
        {
            EmployeeName = string.IsNullOrEmpty(employeeName) ? EmployeeName : employeeName;
            EmployeeSurname = string.IsNullOrEmpty(employeeSurname) ? EmployeeSurname : employeeSurname;
            PermissionTypeId = permissionTypeId;
            GrantedDate = DateTime.UtcNow;

            return Result.Success;
        }

        private Permission()
        {
            
        }
    }
}
