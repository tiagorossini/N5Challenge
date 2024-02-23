namespace N5Challenge.Contracts.Permissions
{
    public record PermissionResponse(string EmployeeName, string EmployeeSurname, int PermissionTypeId, DateTime GrantedDate);
}
